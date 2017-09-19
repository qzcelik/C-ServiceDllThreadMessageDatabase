using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
namespace fitness
{
    public partial class karinAtreman : Form
    {
        String kullaniciAd;
        Thread time;
        public karinAtreman(String kullaniciAd)
        {
            InitializeComponent();
            this.kullaniciAd = kullaniciAd;
            System.Windows.Forms.Form.CheckForIllegalCrossThreadCalls = false;
            time = new Thread(sure);
            time.Start();
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

        private void button1_Click(object sender, EventArgs e)
        {
            time.Suspend();
            //dll'ler statik yüklendi
            kisiVeriDll.Class1 kisiDll = new kisiVeriDll.Class1();
        
            String gelenTarih = null, tarih;
            int oncekiSkor = 0;
            gelenTarih = kisiDll.tarihGetir(kullaniciAd);
            tarih = System.DateTime.Now.ToString();
            MessageBox.Show(kullaniciAd);
            if (gelenTarih == null)//eğer yeni üye ilk defa antreman yapcaksa eklemek için
            {
                kisiDll.skorEkle(kullaniciAd, null, null, totalSkor.ToString(), null, null, null, tarih);
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
                    String oncekiAlan = kisiDll.alanGetir("karin", siraNo[1].ToString());
                    if (oncekiAlan.Equals(""))
                    {
                       
                        oncekiAlan = "1";
                    }

                    oncekiSkor = Convert.ToInt32(oncekiAlan) + totalSkor;
                    kisiDll.skorGuncelle("karin", oncekiSkor.ToString(), siraNo[1].ToString());//güncellenecek verileri gönderiyor
                    MessageBox.Show("veri güncellendi");
                }
                else
                {
                    kisiDll.skorEkle(kullaniciAd, null, null, totalSkor.ToString(), null, null, null, tarih);//eğer başka bir güne geçtiyse yeni kayıt yapıyor o gün için
                    MessageBox.Show("Veriler Eklendi");
                }
        }
    }
        int totalSkor = 0;
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"C:\Users\Acer\Desktop\ileriProgramlamaFinalProje\sporFoto\karinCitirdamak.jpg");
            label2.Text = "Orta";
            label3.Text = "Yerde, ayakta";
            label5.Text = "Normal";
            label7.Text = "Arka Kanat";
            if (radioButton1.Checked == true)
            {
                totalSkor += 6;
                skorLabel.Text = "" + totalSkor;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"C:\Users\Acer\Desktop\ileriProgramlamaFinalProje\sporFoto\topuk.jpg");
            label2.Text = "Orta";
            label3.Text = "Yerde";
            label5.Text = "Normal";
            label7.Text = "Karın Kas";
            if (radioButton2.Checked == true)
            {
                totalSkor += 5;
                skorLabel.Text = "" + totalSkor;
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"C:\Users\Acer\Desktop\ileriProgramlamaFinalProje\sporFoto\plank.jpg");
            label2.Text = "Orta";
            label3.Text = "Yerde";
            label5.Text = "Normal";
            label7.Text = "İlye kas geliştirme,karın kas";
            if (radioButton4.Checked == true)
            {
                totalSkor += 2;
                skorLabel.Text = "" + totalSkor;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

            pictureBox1.Image = Image.FromFile(@"C:\Users\Acer\Desktop\ileriProgramlamaFinalProje\sporFoto\bacakKaldir.jpg");
            label2.Text = "Zor";
            label3.Text = "Yerde";
            label5.Text = "Yüksek";
            label7.Text = "Karın kas,baldır eritme";
            if (radioButton3.Checked == true)
            {
                totalSkor += 4;
                skorLabel.Text = "" + totalSkor;
            }
        }

        private void karinAtreman_FormClosing(object sender, FormClosingEventArgs e)
        {
            time.Suspend();
        }
    }
}
