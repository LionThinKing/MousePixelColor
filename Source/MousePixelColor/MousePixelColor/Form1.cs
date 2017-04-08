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

namespace MousePixelColor
{
    public partial class Form1 : Form
    {

        Thread Hilo;
        bool bHilo;
        public Form1()
        {
            InitializeComponent();
            bHilo = true;
            this.TopMost=true;

             Hilo = new Thread(GetPixel);
            Hilo.Start();
        }


        public void GetPixel()
        {
            while (bHilo)
            {

                int X=Cursor.Position.X ,Y=Cursor.Position.Y;
                Color PixelColor = GetPixelColor.GetMousePixelColor(X,Y);
                panel1.BackColor = PixelColor;

                toolStripStatusLabel1.Text = "Mouse: X=" + Cursor.Position.X + " Y=" + Cursor.Position.Y + " R G B: "+PixelColor.R.ToString()+" "+PixelColor.G.ToString()+" "+PixelColor.B.ToString();
                Thread.Sleep(10);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            bHilo = false;
        }




    }
}
