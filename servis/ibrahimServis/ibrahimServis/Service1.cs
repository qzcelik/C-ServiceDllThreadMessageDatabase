using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Configuration.Install;

namespace ibrahimServis
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();

           
        }
        Thread tiret1,tiret2;
        protected override void OnStart(string[] args)
        {
  
            tiret2 = new Thread(hesapla);
            tiret2.Start();
        }
      
        
        public void hesapla()
        {
            int[] kucukDeger = new int[6];
            int enk = 0, tumvucut, kol, bacak, baldir, karin, adimSayisi,index=0;
            while (true)
            {
                String[] parcala = oku().Split('#');

                tumvucut = Convert.ToInt32(parcala[0].ToString());
                bacak = Convert.ToInt32(parcala[1].ToString());
                karin = Convert.ToInt32(parcala[2].ToString());
                kol = Convert.ToInt32(parcala[3].ToString());
                adimSayisi = Convert.ToInt32(parcala[4].ToString());
                baldir = Convert.ToInt32(parcala[5].ToString());

                kucukDeger[0] = tumvucut;
                kucukDeger[1] = bacak;
                kucukDeger[2] = karin;
                kucukDeger[3] = kol;
                kucukDeger[4] = adimSayisi;
                kucukDeger[5] = baldir;
                enk = kucukDeger[0];
                for (int i = 0; i < kucukDeger.Length; i++)
                {
                    if (enk > kucukDeger[i])
                    {
                        enk = kucukDeger[i];
                    }
                }


                for (int i = 0; i < kucukDeger.Length; i++)
                {
                    if(enk==kucukDeger[i])
                    {
                        index = i;
                        break;
                    }
                }

                t1(index);

                Thread.Sleep(1000);
            }
         }


        //public void calistir()
        //{
        //    while(true)
        //    {
        //          ServiceController kontrol = new ServiceController(ServiceName);
        //         if(kontrol.Status==ServiceControllerStatus.Stopped)
        //         {
        //            kontrol.Refresh();
        //            kontrol.Start();
                 
        //         }
        //    }
            

        //}


        public void t1(int deger)
        {
                switch (deger)
                {
                    case 0:
                        {
                            yaz("tumVucut");
                        }
                        break;

                    case 1:
                        {
                            yaz("bacak");
                         
                        }
                        break;
                    case 2:
                        {
                            yaz("karin");
                        }
                        break;
                    case 3:
                        {
                            yaz("kol");
                        }
                        break;
                    case 4:
                        {
                            yaz("adimSayisi");
                        }
                        break;
                    case 5:
                        {
                            yaz("baldir");
                        }
                        break;
               }
              
         }

      
        public void yaz(String deger)
        {
         
                StreamWriter servisGeriDonen = new StreamWriter(@"C:\Users\Acer\Desktop\ileriProgramlamaFinalProje\servisGeriDonen.txt");
                servisGeriDonen.WriteLine(deger);
                servisGeriDonen.Close();
      }

        String okunanDeger;

        public String oku()
        {
            StreamReader oku = new StreamReader(@"C:\Users\Acer\Desktop\ileriProgramlamaFinalProje\servisGonder.txt");
            okunanDeger = oku.ReadLine();
            oku.Close();
            return okunanDeger;
        }
        protected override void OnStop()
        {
            
        }
        
    }
}
