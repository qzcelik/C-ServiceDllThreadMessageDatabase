using CSCreateProcessAsUserFromService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
namespace servisDenemeSon
{
    public partial class Service1 : ServiceBase
    {
        String kontrol;
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            
            Thread ProcessCreationThread = new Thread(MyThreadFunc);//Uygulamamızı sürekli aktif tutmak için thread yazıyoruz
            ProcessCreationThread.Start();//yazdığımız thread'i başlatıyoruz
        }

        public   void MyThreadFunc()//thread'imize gösterdiğimiz fonksiyon
        {
           
            while(true)//thread sürekli çalışsın
            {
                Thread.Sleep(10000);//10 saniye bekleme süresi
                if (kontrol.Equals("1"))
                {
                    CreateProcessAsUserWrapper.LaunchChildProcess(@"C:\Users\Acer\Desktop\ileriProgramlamaFinalProje\bildirim\bildirim\bin\Debug\bildirim.exe");
                }
              
            }
            
        }
        protected override void OnStop()
        {
        }
       
        private void oku()
        {
            StreamReader oku = new StreamReader(@"C:\Users\Acer\Desktop\ileriProgramlamaFinalProje\bildirimKontrol.txt");
            kontrol = oku.ReadLine();
            oku.Close();
        }
    }
}
