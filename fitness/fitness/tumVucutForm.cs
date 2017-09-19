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
using System.Threading;
namespace fitness
{
    public partial class tumVucutForm : Form
    {
        String kullaniciAd;
        Thread time;
        public tumVucutForm(String kullaniciAd)
        {
            InitializeComponent();
            this.kullaniciAd = kullaniciAd;
            System.Windows.Forms.Form.CheckForIllegalCrossThreadCalls = false;
            time = new Thread(sure);
            time.Start();
        }

      
        private void tumVucutForm_Load(object sender, EventArgs e)
        {
           
        }

        int sayac = 0;
        public void sure()
        {
            sayac = 0;
            while (true)
            {
                sayac++;
                zaman.Text = sayac.ToString();
                Thread.Sleep(1000);
                if (sayac >= 10)
                {
                    MessageBox.Show("Süre sona erdi 5 saniye mola sonra süre tekrar başlayacak");
                    sayac = 0;
                    Thread.Sleep(5000);
                    MessageBox.Show("Mola Bitti");
                }
            }
        }
        int totalSkor = 0;
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"C:\Users\Acer\Desktop\ileriProgramlamaFinalProje\sporFoto\sinav.jpg");
            label2.Text = "Zor";
            label3.Text = "Yerde";
            label5.Text = "Normal";
            label7.Text = "Karın kasları,Biseps,Triseps,Üst Sırt,Göğüs,Omuzlar";
            if (radioButton1.Checked==true)
            {
                totalSkor += 5;
                skorLabel.Text = "" + totalSkor;
            }
          
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"C:\Users\Acer\Desktop\ileriProgramlamaFinalProje\sporFoto\mekik.jpg");
            label2.Text = "Orta";
            label3.Text = "Yerde";
            label5.Text = "Normal";
            label7.Text = "Karın kasları";
            if (radioButton2.Checked == true)
            {
                totalSkor += 4;
                skorLabel.Text = "" + totalSkor;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"C:\Users\Acer\Desktop\ileriProgramlamaFinalProje\sporFoto\duvarMekik.jpg");
            label2.Text = "Kolay";
            label3.Text = "Ayakta";
            label5.Text = "Düşük";
            label7.Text = "Triseps,Üst Sırt,Göğüs,Omuzlar";
           if (radioButton3.Checked == true)
            {
                totalSkor += 2;
                skorLabel.Text = "" + totalSkor;
            }
        }
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"C:\Users\Acer\Desktop\ileriProgramlamaFinalProje\sporFoto\comel.jpg");
            label2.Text = "Orta";
            label3.Text = "Ayakta";
            label5.Text = "Normal";
            label7.Text = "Baldırlar,Kalça,Kuadriseps";
            if (radioButton4.Checked == true)
            {
                totalSkor += 3;
                skorLabel.Text = "" + totalSkor;
            }
        }

        //dll'ler statik yüklendi
        kisiVeriDll.Class1 kisiDll = new kisiVeriDll.Class1();
        private void button1_Click(object sender, EventArgs e)
        {
            String gelenTarih =null,tarih;
            int oncekiSkor = 0;
            gelenTarih = kisiDll.tarihGetir(kullaniciAd);
            tarih = System.DateTime.Now.ToString();
            MessageBox.Show(kullaniciAd);
            if (gelenTarih == null)//eğer yeni üye ilk defa antreman yapcaksa eklemek için
            {
                kisiDll.skorEkle(kullaniciAd, totalSkor.ToString(), null, null, null, null, null, tarih);
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
                    String oncekiAlan= kisiDll.alanGetir("tumVucut",siraNo[1].ToString());
                    oncekiSkor = Convert.ToInt32(0+oncekiAlan)+totalSkor;
                    kisiDll.skorGuncelle("tumVucut", oncekiSkor.ToString(), siraNo[1].ToString());//güncellenecek verileri gönderiyor
                    MessageBox.Show("veri güncellendi");
                }
                else
                {
                    kisiDll.skorEkle(kullaniciAd, totalSkor.ToString(), null, null, null, null, null, tarih);//eğer başka bir güne geçtiyse yeni kayıt yapıyor o gün için
                    MessageBox.Show("Veriler Eklendi");
                }

              }
            time.Suspend();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            kisiDll.veriSil();
            
        }

        private void skorLabel_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void tumVucutForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            time.Suspend();
        }
    }
}
