using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace fitness
{
    class zaman
    {
        Thread time;
        public void calis()
        {
            time = new Thread(sure);
            time.Start();
        }
        int sayac = 0;

        private void sure()
        {
            while (true)
            {
                sayac++;
               
                Thread.Sleep(1000);
                if (sayac > 3)
                {
                    sayac = 0;
                    Thread.Sleep(5000);
                }
            }
        }
       
    }
}
