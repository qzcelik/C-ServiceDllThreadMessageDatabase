using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using System.Threading;
namespace fitness
{
    public partial class profil : Form
    {
        String kulAd,kullaniciBilgi;
        Thread kulAdYaz;
        public profil(String kulAd)
        {
            InitializeComponent();
            this.kulAd = kulAd;
            veriDllGetir();
            hesap();
            girisMesaji.Text ="Merhaba "+kulAdi+" "+aralikBul(idealKilo);

            kulAdYaz = new Thread(threadOku);
            
            kulAdYaz.Start();
        
        }
        String kulAdi;
        double idealKilo;
      

        public void threadOku()
        {
            String gelenDeger;

            while (true)
            {
                StreamReader oku = new StreamReader(@"C:\Users\Acer\Desktop\ileriProgramlamaFinalProje\servisGeriDonen.txt");
                gelenDeger = oku.ReadToEnd();
                oku.Close();
                Thread.Sleep(5000);
                pencere(gelenDeger);
            }
         }

        public void pencere(String gelenDeger)
        {
            
                Thread.Sleep(5000);
                switch (gelenDeger.Trim())
                {
                    case "bacak":
                        {

                            MessageBox.Show("bacak antremanı zamanı geldi " + kulAdi);
                            break;
                        }
                    case "tumVucut":
                        {

                            MessageBox.Show("tumvucut antremanı zamanı geldi " + kulAdi);
                            break;
                        }
                    case "kol":
                        {

                            MessageBox.Show("kol antremanı zamanı geldi " + kulAdi);
                            break;
                        }
                    case "baldir":
                        {

                            MessageBox.Show("baldir antremanı zamanı geldi " + kulAdi);
                            break;
                        }
                    case "karin":
                        {

                            MessageBox.Show("karin antremanı zamanı geldi " + kulAdi);
                            break;
                        }
                    case "adimSayisi":
                        {

                            MessageBox.Show("yürüyüş  zamanı geldi " + kulAdi);
                            break;
                        }
 
            }
    
            
        }
       
        private void hesap()
        {
            String[] dizi = kullaniciBilgi.Split('#');
            kulAdi = dizi[1];
           
            float b= (float)Convert.ToInt32(dizi[3]) / 100;
            float a =(float) b * b;
            idealKilo =Convert.ToInt32(dizi[4]) / a;

        }

        private String aralikBul(double endex)
        {
            
            if(endex<15)
            {
                return "Çok ciddi derecede düşük kilolusun";
            }
            if (endex > 15&&endex<16)
            {
                return "Ciddi derecede düşük kilolusun";
            }
            if (endex > 16&&endex<18)
            {
                return "Düşük kilolusun";
            }
            if (endex > 18 && endex < 25)
            {
                return "Normal kilolusun";
            }
            if (endex > 25 && endex < 30)
            {
                return "Fazla kilolusun";
            }
            if (endex > 30 && endex < 35)
            {
                return "1. Derece Obezsin";
            }
            if (endex > 35 && endex < 40)
            {
                return "2. Derece Obezsin";
            }
            return "Hata";
        }
        kisiVeriDll.Class1 servisYaz = new kisiVeriDll.Class1();
        private void profil_Load(object sender, EventArgs e)
        {
            servisYaz.servisVeri(kulAd);

        }

        private void button1_Click(object sender, EventArgs e)
        {
        
            tumVucutForm tumVucut = new tumVucutForm(kulAd);
            tumVucut.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            kolAntreman getir = new kolAntreman(kulAd);
            getir.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bacakAntreman getir = new bacakAntreman(kulAd);
            getir.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            karinAtreman getir = new karinAtreman(kulAd);
            getir.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            baldirAntreman getir = new baldirAntreman(kulAd);
            getir.Show();
        }

        kisiVeriDll.Class1 kisiDll = new kisiVeriDll.Class1();

        private void button4_Click(object sender, EventArgs e)
        {
            gecmisForm getir = new gecmisForm(kulAd);
            getir.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            
           kulAdYaz.Suspend();
           
            Form1 getir = new Form1();
            getir.Show();
            
            this.Dispose();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            String gelenTarih = null, tarih;
            int oncekiSkor = 0;
            gelenTarih = kisiDll.tarihGetir(kulAd);
            tarih = System.DateTime.Now.ToString();
            MessageBox.Show(kulAdi);
            if (gelenTarih == null)//eğer yeni üye ilk defa antreman yapcaksa eklemek için
            {
                kisiDll.skorEkle(kulAd, null, null, null, null, null, textBox1.Text.ToString(), tarih);
                MessageBox.Show("Veriler Eklendi");
            }
            else//zaten üyeyse tarihlerin gerekli alanları alınıyor 
            {
                String[] tumTarih = gelenTarih.Split(' ');
                String[] sistemTarih = tarih.Split(' ');

                String[] parcaTarih = tumTarih[0].Split('.');
                String[] sistemParcaTarih = sistemTarih[0].Split('.');

                //günü alıp şuanki günle karşılaştırıyor eğer geçmişteki bir günse yeni kayıt yapıyor
                if (parcaTarih[0].Equals(sistemParcaTarih[0].ToString()))//hangi satırdaki veri güncellenecek
                {
                    String[] siraNo = gelenTarih.Split('#');//satır numarası
                    String oncekiAlan = kisiDll.alanGetir("adimSayisi", siraNo[1].ToString());
                    if (oncekiAlan.Equals(""))
                    {
                        MessageBox.Show("girdi");
                        oncekiAlan = "1";
                    }

                    oncekiSkor = Convert.ToInt32(oncekiAlan) + Convert.ToInt32(textBox1.Text);
                    kisiDll.skorGuncelle("adimSayisi", oncekiSkor.ToString(), siraNo[1].ToString());//güncellenecek verileri gönderiyor
                    MessageBox.Show("veri güncellendi");
                }
                else
                {
                    kisiDll.skorEkle(kulAd, null, null, null, null, textBox1.Text.ToString(), null, tarih);//eğer başka bir güne geçtiyse yeni kayıt yapıyor o gün için
                    MessageBox.Show("Veriler Eklendi");
                }

            }
        }

        private void profil_FormClosing(object sender, FormClosingEventArgs e)
        {
            kulAdYaz.Suspend();
        }

        private void button9_Click(object sender, EventArgs e)
        {
             
        }

        private void veriDllGetir()
        {
            var dll = Assembly.LoadFile(@"C:\Users\Acer\Desktop\ileriProgramlamaFinalProje\kisiVeriDll\kisiVeriDll\bin\Debug\kisiVeriDll.dll");
            var tip = dll.GetType("kisiVeriDll.Class1");
            var istek = Activator.CreateInstance(tip);
            var metod = tip.GetMethod("kisiGenelVeri");
            kullaniciBilgi = (String)metod.Invoke(istek, new object[] { kulAd });
        }
      
    }
    
}
