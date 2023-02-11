using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Example_17_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //----------------------------------------------------------------------
        int x1, y1, x2, y2;
        Graphics gr;
        enum Jahat { LEFT, TOP, RIGHT, BOTTOM };
        Jahat jahat1, jahat2;
        //----------------------------------------------------------------------
        private void Form1_Load(object sender, EventArgs e)
        {
            x1 = 0;
            y1 = y2 = this.ClientSize.Height / 2;
            x2 = this.ClientSize.Width;
            gr = this.CreateGraphics();
            jahat1 = Jahat.LEFT;
            jahat2 = Jahat.RIGHT;
            this.BackColor = Color.Black;
            this.Width = 320;
            this.Height = 300;
            timer1.Enabled = true;
            timer1.Interval = 10;
        }
        //----------------------------------------------------------------------
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now.Millisecond % 4 == 0)
                gr.Clear(Color.Black);
            gr.DrawLine(new Pen(Color.White), x1, y1, x2, y2);
            CreateDot(ref jahat1, ref x1, ref y1);
            CreateDot(ref jahat2, ref x2, ref y2);
        }
        //----------------------------------------------------------------------
        void CreateDot(ref Jahat jahat, ref int x, ref int y)
        {
            switch (jahat)
            {
                case Jahat.LEFT:
                    y -= 5;
                    if (y <= 0)
                        jahat = Jahat.TOP;
                    break;
                case Jahat.TOP:
                    x += 5;
                    if (x >= this.ClientSize.Width)
                        jahat = Jahat.RIGHT;
                    break;
                case Jahat.RIGHT:
                    y += 5;
                    if (y >= this.ClientSize.Height)
                        jahat = Jahat.BOTTOM;
                    break;
                case Jahat.BOTTOM:
                    x -= 5;
                    if (x <= 0)
                        jahat = Jahat.LEFT;
                    break;
            }
        }
        //----------------------------------------------------------------------
    }
}
