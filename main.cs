using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MobileCenterAbadan
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

    //////////////////////////////////////////////////////////////////////aplications icon
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        bool chekmaximiz = true;
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (chekmaximiz == false)
            {
                this.WindowState = FormWindowState.Maximized;
                chekmaximiz = true;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                chekmaximiz = false;
            }
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            hesab F = new hesab();
            F.Show();
           
        }


        //////////////////////////////////////////////////////////////////////// end of aplication icon

    }
}
