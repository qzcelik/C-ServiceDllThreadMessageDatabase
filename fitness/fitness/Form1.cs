using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Reflection;
using System.IO;
namespace fitness
{
    public partial class Form1 : Form
    {
        OleDbConnection connection;
        OleDbDataAdapter adapter=new OleDbDataAdapter();
        OleDbCommand command=new OleDbCommand();
        DataSet data=new DataSet();
        public Form1()
        {
           InitializeComponent();
            dataGridView1.Visible = false;
 
        }
        String kulAd, kulSifre, kulAdSoyad, kulYas,kulBoy,kulKilo,kulCinsiyet="secilmedi";
        //boş alan kontrol------------------------------------------------------------------------------------------------------
        private void button1_Click(object sender, EventArgs e)//üye ol uton
        {

            boslukKontrol();
            textTemizle();
        }

        //kullanıcı bilgileri alma------------------------------------------------------------------------------------------------------
        bool kulAdKontrol = false;
        bool kulGirisKontrol = false;

        public void textTemizle()
        {
             kulAdiTxt.Text=null;
             kulSifreTxt.Text = null;
             kulAdSoyTxt.Text = null;
             kulYasTxt.Text = null;
             kulBoyTxt.Text = null;
             kulKiloTxt.Text = null;
        }
        private void button1_Click_2(object sender, EventArgs e)//giriş buton
        {
            girisEkrani();
        }

        String kulGir, sifreGir;

        private void button2_Click(object sender, EventArgs e)
        {
            connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0; Data Source = C:\Users\Acer\Desktop\ileriProgramlamaFinalProje\sporSalon.accdb");
            connection.Open();
            String cumle = "delete from kisi";
            command = new OleDbCommand(cumle,connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        private void girisEkrani()
        {
            kulGir = kulId.Text;
            sifreGir = sifreId.Text;
            dinamikDll("girisKontrol");

            if(kulGirisKontrol==true)
            {
                //profil form yüklme 
                profil profilForm = new profil(kulGir);
                profilForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı Adı veya Şifre Hatalı");
            }

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            StreamWriter yaz = new StreamWriter(@"C:\Users\Acer\Desktop\ileriProgramlamaFinalProje\bildirimKontrol.txt");
            yaz.WriteLine("1");
            yaz.Close();
        }

        private void boslukKontrol()
        {

            if (kulAdiTxt.Text.Equals("") || kulSifreTxt.Text.Equals("") || kulAdSoyTxt.Text.Equals("")
                || kulYasTxt.Text.Equals("") || kulBoyTxt.Text.Equals("") || kulKiloTxt.Text.Equals(""))
            {
                MessageBox.Show("Boş Alanları Doldurun");
            }
            else
            {
                kullaniciBilgi();
            }
        }
        private void kullaniciBilgi()
        {
            kulAd = kulAdiTxt.Text;
            kulSifre = kulSifreTxt.Text;
            kulAdSoyad = kulAdSoyTxt.Text;
            kulYas = kulYasTxt.Text;
            kulBoy = kulBoyTxt.Text;
            kulKilo = kulKiloTxt.Text;
            if(kadinRadio.Checked==true)
            {
                kulCinsiyet = "K";
            }
            if(erkekRadio.Checked==true)
            {
                kulCinsiyet = "E";
            }

            dinamikDll("kulAdKontrol");//kullanıcı kontrol ediliyor

            if(kulAdKontrol==false)
            {
                dinamikDll("ekle");
                MessageBox.Show("kişi eklendi");
            }
           else
            {
                MessageBox.Show("Bu Kullancı Adı Kullanılıyor Başka Bir Ad Seçin");
            }
           
          
        }
        //dinamik dll yükleme, dll fonksiyon bulma------------------------------------------------------------------------------------------------------
        public void dinamikDll(String fonkAdi)
        {
            var dll = Assembly.LoadFile(@"C:\Users\Acer\Desktop\ileriProgramlamaFinalProje\veritabaniDll\veritabaniDll\bin\Debug\veritabaniDll.dll");
            var tip = dll.GetType("veritabaniDll.Class1");
            var istek = Activator.CreateInstance(tip);
            var metod = tip.GetMethod(fonkAdi);
    
            if (fonkAdi.Equals("kulAdKontrol"))
            {
                kulAdKontrol= (bool) metod.Invoke(istek, new object[] {kulAd});
            }

            if (fonkAdi.Equals("ekle"))
            {
                metod.Invoke(istek, new object[] { kulAd, kulSifre, kulAdSoyad, kulYas, kulBoy, kulKilo, kulCinsiyet });
            }

            if(fonkAdi.Equals("girisKontrol"))
            {
                kulGirisKontrol = (bool)metod.Invoke(istek, new object[] { kulGir, sifreGir });
            }
        }
        //veritabani test------------------------------------------------------------------------------------------------------
        public void veritabani()
        {
            connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0; Data Source = C:\Users\Acer\Desktop\ileriProgramlamaFinalProje\sporSalon.accdb");
            connection.Open();
            adapter = new OleDbDataAdapter("select * from kisi", connection);
            adapter.Fill(data, "kisi");
            dataGridView1.DataSource = data.Tables["kisi"];
            connection.Close();
        }

        protected override void WndProc(ref Message m)
        {
            switch(m.Msg)
            {
                   case 515://çift tık sol veritabanını getirir
                    {
                        pictureBox1.Visible = false;
                       veritabani();
                        dataGridView1.Visible = true;
                    }
                    
                    break;
            }
            base.WndProc(ref m);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //veritabani();
            StreamWriter yaz = new StreamWriter(@"C:\Users\Acer\Desktop\ileriProgramlamaFinalProje\bildirimKontrol.txt");
            yaz.WriteLine("0");
            yaz.Close();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
