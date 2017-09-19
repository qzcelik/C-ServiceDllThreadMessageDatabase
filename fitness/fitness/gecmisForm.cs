using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fitness
{
    public partial class gecmisForm : Form
    {
        String kulAdi;
        public gecmisForm(String kulAdi)
        {
            InitializeComponent();
            this.kulAdi = kulAdi;
        }

        kisiVeriDll.Class1 kisiDll = new kisiVeriDll.Class1();
        ArrayList veri = new ArrayList();
        private void gecmisForm_Load(object sender, EventArgs e)
        {
            String[] sonDeger = new String[veri.Capacity+50];
            int j = 0,gun1,gun2,gun3,gun4,gun5; 
            String[] parcala = kisiDll.servisVeri(kulAdi).Split('#');
            String sonuc = null;
            label8.Text = "Tüm Vücut Antreman "+parcala[1].ToString()+"\nBacak Antreman "+ parcala[2].ToString()+"\nKarin Antreman "+ parcala[3].ToString()+"\nKol Antreman "+ parcala[4].ToString()+"\nBaldir Antreman "+parcala[6].ToString()+"\nAtılan Adım Sayısı "+parcala[5].ToString();
            veri=kisiDll.tumVeri(kulAdi);
            foreach (String i in veri)
            {
                sonDeger[j] = i;
                j++;  
            } 
            if(sonDeger[0]!=null)
            {
                String[] parcalaTumVeri = sonDeger[0].Split('#');
                gun1 = Convert.ToInt32(parcalaTumVeri[1]) + Convert.ToInt32(parcalaTumVeri[2]) + Convert.ToInt32(parcalaTumVeri[3]) + Convert.ToInt32(parcalaTumVeri[4]) + Convert.ToInt32(parcalaTumVeri[6]);
                if (progress(gun1) == 1)
                {
                    progressBar1.Value = gun1;
                }
                else
                {
                    progressBar1.Value = 200;
                }

                label10.Text = "Yapılan Skor : " + gun1.ToString() +" "+hesapla(gun1);

                String []tarih= parcalaTumVeri[7].ToString().Split(' ');
                label1.Text = tarih[0].ToString();
            }
            if (sonDeger[1]!=null)
            {
                String[] parcalaTumVeri2 = sonDeger[1].Split('#');
                gun2 = Convert.ToInt32(parcalaTumVeri2[1]) + Convert.ToInt32(parcalaTumVeri2[2]) + Convert.ToInt32(parcalaTumVeri2[3]) + Convert.ToInt32(parcalaTumVeri2[4]) + Convert.ToInt32(parcalaTumVeri2[6]);
                if (progress(gun2) == 1)
                {
                    progressBar2.Value = gun2;
                }
                else
                {
                    progressBar2.Value = 200;
                }
                label11.Text = "Yapılan Skor : " + gun2.ToString()+" "+hesapla(gun2);

                String[] tarih = parcalaTumVeri2[7].ToString().Split(' ');
                label2.Text = tarih[0].ToString();
            }
            if (sonDeger[2]!=null)
            {

                String[] parcalaTumVeri3 = sonDeger[2].Split('#');
                gun3 = Convert.ToInt32(parcalaTumVeri3[1]) + Convert.ToInt32(parcalaTumVeri3[2]) + Convert.ToInt32(parcalaTumVeri3[3]) + Convert.ToInt32(parcalaTumVeri3[4]) + Convert.ToInt32(parcalaTumVeri3[6]);
                if (progress(gun3) == 1)
                {
                    progressBar3.Value = gun3;
                }
                else
                {
                    progressBar3.Value = 200;
                }
                label12.Text = "Yapılan Skor : " + gun3.ToString()+" "+hesapla(gun3);
                String[] tarih = parcalaTumVeri3[7].ToString().Split(' ');
                label3.Text = tarih[0].ToString();
            }
            if (sonDeger[3] != null)
            {

                String[] parcalaTumVeri4 = sonDeger[3].Split('#');
                gun4 = Convert.ToInt32(parcalaTumVeri4[1]) + Convert.ToInt32(parcalaTumVeri4[2]) + Convert.ToInt32(parcalaTumVeri4[3]) + Convert.ToInt32(parcalaTumVeri4[4]) + Convert.ToInt32(parcalaTumVeri4[6]);
                if (progress(gun4) == 1)
                {
                    progressBar4.Value = gun4;
                }
                else
                {
                    progressBar4.Value = 200;
                }
                label13.Text = "Yapılan Skor : " + gun4.ToString()+" "+hesapla(gun4);
                String[] tarih = parcalaTumVeri4[7].ToString().Split(' ');
                label4.Text = tarih[0].ToString();
            }
            if (sonDeger[4] != null)
            {

                String[] parcalaTumVeri5 = sonDeger[4].Split('#');
                gun5 = Convert.ToInt32(parcalaTumVeri5[1]) + Convert.ToInt32(parcalaTumVeri5[2]) + Convert.ToInt32(parcalaTumVeri5[3]) + Convert.ToInt32(parcalaTumVeri5[4]) + Convert.ToInt32(parcalaTumVeri5[6]);
                if (progress(gun5) == 1)
                {
                    progressBar5.Value = gun5;
                }
                else
                {
                    progressBar5.Value = 200;
                }
                label14.Text = "Yapılan Skor : " + gun5.ToString()+" "+hesapla(gun5);
                String[] tarih = parcalaTumVeri5[7].ToString().Split(' ');
                label5.Text = tarih[0].ToString();
            }



        }
        public String hesapla(int deger)
        {
            if(deger<30)
            {
                return "iyi degil";
            }
            if (deger > 30&&deger<50)
            {
                return "biraz iyi";
            }
            if (deger > 50&&deger<100)
            {
                return "iyi";
            }
            if (deger > 100&&deger<150)
            {
                return "çok iyi";
            }
            if (deger > 150)
            {
                return "harika";
            }
            return "fazla iyi";
        }

        private int progress(int deger)
        {
            if (deger >= 200)
                return 0;
            else
                return 1;
        }
    }
}
