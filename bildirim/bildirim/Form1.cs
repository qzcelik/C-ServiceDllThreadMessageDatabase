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
namespace bildirim
{
    public partial class Form1 : Form
    {
        Thread t1;
        public Form1()
        {
            InitializeComponent();
            System.Windows.Forms.Form.CheckForIllegalCrossThreadCalls = false;
            t1 = new Thread(yokEt);
            t1.Start();
        }

        void yokEt()
        {
            Thread.Sleep(5000);
           
            this.Close();
          
        }
        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"C:\Users\Acer\Desktop\ileriProgramlamaFinalProje\fitness\fitness\bin\Debug\fitness.exe");
            this.Close();
        }
    }
}
