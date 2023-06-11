using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;
namespace MobileCenterAbadan
{
    public partial class barname : Form
    {
        public barname()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
         
         


        }
        bool chekmaximiz = true;

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            barname s = new barname();
            this.Close();
            s.Close();

        }

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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }

        private void bunifuMetroTextbox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar) || char.IsPunctuation(e.KeyChar))) { e.Handled = true; MessageBox.Show("لطفا فقط عدد وارد کنید", "Alert!"); }

        }

        private void bunifuMetroTextbox3_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuMetroTextbox3_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == char.ConvertFromUtf32(1740).ToCharArray()[0])
            {
                e.KeyChar = Char.ConvertFromUtf32(1610).ToCharArray()[0];
            }
            if (e.KeyChar == char.ConvertFromUtf32(1705).ToCharArray()[0])
            {
                e.KeyChar = Char.ConvertFromUtf32(1603).ToCharArray()[0];
            }
        }

        private void tableLayoutPanel13_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
        public int barname_id = -1;
        private void bunifuButton11_Click(object sender, EventArgs e)
        {
            SqlConnection a = new SqlConnection(connectify.pcs);
            a.Open();

            SqlCommand b = new SqlCommand("delete from barname", a);
            b.ExecuteNonQuery();
            b = new SqlCommand("delete from vade1", a);
            b.ExecuteNonQuery();
            b = new SqlCommand("delete from vade2", a);
            b.ExecuteNonQuery();
            b = new SqlCommand("delete from vade3", a);
            b.ExecuteNonQuery();
            b = new SqlCommand("delete from vade4", a);
            b.ExecuteNonQuery();
            b = new SqlCommand("delete from vade5", a);
            b.ExecuteNonQuery();
            b = new SqlCommand("delete from vade6", a);
            b.ExecuteNonQuery();
            b = new SqlCommand("delete from vade7", a);
            b.ExecuteNonQuery();
            b = new SqlCommand("delete from vade8", a);
            b.ExecuteNonQuery();


            if ((bunifuMetroTextbox1.Text=="")|| (bunifuMetroTextbox2.Text=="") || (bunifuMetroTextbox3.Text == "") || (bunifuMetroTextbox4.Text == "") || (bunifuMetroTextbox5.Text == "") || (bunifuMetroTextbox6.Text == "") || (bunifuMetroTextbox7.Text == "") )
            {
                MessageBox.Show("لطفا تمام اطلاعات را وارد کنید");
            }
            else
            {
                 b = new SqlCommand("insert into barname (info,karbo,pro,charb,rooz,mah,sal) values ('" + bunifuMetroTextbox3.Text + "','" + int.Parse(bunifuMetroTextbox7.Text) + "','" + int.Parse(bunifuMetroTextbox5.Text) + "','" + int.Parse(bunifuMetroTextbox4.Text) + "','" + int.Parse(bunifuMetroTextbox2.Text) + "','" + int.Parse(bunifuMetroTextbox1.Text) + "','" + int.Parse(bunifuMetroTextbox6.Text) + "'  ) ", a);
                b.ExecuteNonQuery();
                SqlDataAdapter sd = new SqlDataAdapter("select max(id) as test from barname", a);
                DataTable dt = new DataTable();
                sd.Fill(dt);
                groupBox3.Enabled = false;
                barname_id = int.Parse(dt.Rows[0]["test"].ToString());
                vade_id = 0;
            }
        }
        public static int vade_id = -1;
        public static float pro1 = 0;
        public static float karbo1 = 0;
        public static float charb1 = 0;
        
        private void bunifuButton10_Click(object sender, EventArgs e)
        {
            if (barname_id == -1)
            {
                MessageBox.Show("لطفا یک برنامه ثبت کنید");

            }
            else
            {
                if((bunifuMetroTextbox30.Text=="") || (bunifuMetroTextbox29.Text=="") || (bunifuMetroTextbox31.Text==""))
                {
                    MessageBox.Show("لطفا اطلاعات را وارد کنید");
                }
                else
                {
                    pro1 = (float.Parse(bunifuMetroTextbox30.Text.ToString()) / 100) * (float.Parse(bunifuMetroTextbox5.Text.ToString()));
                    karbo1 = (float.Parse(bunifuMetroTextbox29.Text.ToString()) / 100) * (float.Parse(bunifuMetroTextbox7.Text.ToString()));
                    charb1 = (float.Parse(bunifuMetroTextbox31.Text.ToString()) / 100) * (float.Parse(bunifuMetroTextbox4.Text.ToString()));
                    vade_id = 1;
                    barname2 f = new barname2();
                    f.ShowDialog();

                }
               
            }
          
          
        }

        private void bunifuButton9_Click(object sender, EventArgs e)
        {
            if (barname_id == -1)
            {
                MessageBox.Show("لطفا یک برنامه ثبت کنید");

            }
            else
            {
                if ((bunifuMetroTextbox26.Text == "") || (bunifuMetroTextbox27.Text == "") || (bunifuMetroTextbox28.Text == ""))
                {
                    MessageBox.Show("لطفا اطلاعات را وارد کنید");
                }
                else
                {
                    pro1 = (float.Parse(bunifuMetroTextbox27.Text.ToString()) / 100) * float.Parse(bunifuMetroTextbox5.Text.ToString());
                    karbo1 = (float.Parse(bunifuMetroTextbox26.Text.ToString()) / 100) * float.Parse(bunifuMetroTextbox7.Text.ToString());
                    charb1 = (float.Parse(bunifuMetroTextbox28.Text.ToString()) / 100) * float.Parse(bunifuMetroTextbox4.Text.ToString());
                    vade_id = 2;
                    barname2 f = new barname2();
                    f.ShowDialog();

                }

            }
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            if (barname_id == -1)
            {
                MessageBox.Show("لطفا یک برنامه ثبت کنید");

            }
            else
            {
                if ((bunifuMetroTextbox15.Text == "") || (bunifuMetroTextbox14.Text == "") || (bunifuMetroTextbox16.Text == ""))
                {
                    MessageBox.Show("لطفا اطلاعات را وارد کنید");
                }
                else
                {
                    pro1 = (float.Parse(bunifuMetroTextbox15.Text.ToString()) / 100) * float.Parse(bunifuMetroTextbox5.Text.ToString());
                    karbo1 = (float.Parse(bunifuMetroTextbox14.Text.ToString()) / 100) * float.Parse(bunifuMetroTextbox7.Text.ToString());
                    charb1 = (float.Parse(bunifuMetroTextbox16.Text.ToString()) / 100) * float.Parse(bunifuMetroTextbox4.Text.ToString());
                    vade_id = 3;
                    barname2 f = new barname2();
                    f.ShowDialog();

                }

            }
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            if (barname_id == -1)
            {
                MessageBox.Show("لطفا یک برنامه ثبت کنید");

            }
            else
            {
                if ((bunifuMetroTextbox10.Text == "") || (bunifuMetroTextbox8.Text == "") || (bunifuMetroTextbox11.Text == ""))
                {
                    MessageBox.Show("لطفا اطلاعات را وارد کنید");
                }
                else
                {
                    pro1 = (float.Parse(bunifuMetroTextbox10.Text.ToString()) / 100) * float.Parse(bunifuMetroTextbox5.Text.ToString());
                    karbo1 = (float.Parse(bunifuMetroTextbox4.Text.ToString()) / 100) * float.Parse(bunifuMetroTextbox7.Text.ToString());
                    charb1 = (float.Parse(bunifuMetroTextbox11.Text.ToString()) / 100) * float.Parse(bunifuMetroTextbox4.Text.ToString());
                    vade_id = 4;
                    barname2 f = new barname2();
                    f.ShowDialog();

                }

            }
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            if (barname_id == -1)
            {
                MessageBox.Show("لطفا یک برنامه ثبت کنید");

            }
            else
            {
                if ((bunifuMetroTextbox12.Text == "") || (bunifuMetroTextbox9.Text == "") || (bunifuMetroTextbox13.Text == ""))
                {
                    MessageBox.Show("لطفا اطلاعات را وارد کنید");
                }
                else
                {
                    pro1 = (float.Parse(bunifuMetroTextbox12.Text.ToString()) / 100) * float.Parse(bunifuMetroTextbox5.Text.ToString());
                    karbo1 = (float.Parse(bunifuMetroTextbox9.Text.ToString()) / 100) * float.Parse(bunifuMetroTextbox7.Text.ToString());
                    charb1 = (float.Parse(bunifuMetroTextbox13.Text.ToString()) / 100) * float.Parse(bunifuMetroTextbox4.Text.ToString());
                    vade_id = 5;
                    barname2 f = new barname2();
                    f.ShowDialog();

                }

            }
        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            if (barname_id == -1)
            {
                MessageBox.Show("لطفا یک برنامه ثبت کنید");

            }
            else
            {
                if ((bunifuMetroTextbox18.Text == "") || (bunifuMetroTextbox17.Text == "") || (bunifuMetroTextbox19.Text == ""))
                {
                    MessageBox.Show("لطفا اطلاعات را وارد کنید");
                }
                else
                {
                    pro1 = (float.Parse(bunifuMetroTextbox18.Text.ToString()) / 100) * float.Parse(bunifuMetroTextbox5.Text.ToString());
                    karbo1 = (float.Parse(bunifuMetroTextbox17.Text.ToString()) / 100) * float.Parse(bunifuMetroTextbox7.Text.ToString());
                    charb1 = (float.Parse(bunifuMetroTextbox19.Text.ToString()) / 100) * float.Parse(bunifuMetroTextbox4.Text.ToString());
                    vade_id = 6;
                    barname2 f = new barname2();
                    f.ShowDialog();

                }

            }
        }

        private void bunifuButton5_Click(object sender, EventArgs e)
        {
            if (barname_id == -1)
            {
                MessageBox.Show("لطفا یک برنامه ثبت کنید");

            }
            else
            {
                if ((bunifuMetroTextbox21.Text == "") || (bunifuMetroTextbox20.Text == "") || (bunifuMetroTextbox22.Text == ""))
                {
                    MessageBox.Show("لطفا اطلاعات را وارد کنید");
                }
                else
                {
                    pro1 = (float.Parse(bunifuMetroTextbox21.Text.ToString()) / 100) * float.Parse(bunifuMetroTextbox5.Text.ToString());
                    karbo1 = (float.Parse(bunifuMetroTextbox20.Text.ToString()) / 100) * float.Parse(bunifuMetroTextbox7.Text.ToString());
                    charb1 = (float.Parse(bunifuMetroTextbox22.Text.ToString()) / 100) * float.Parse(bunifuMetroTextbox4.Text.ToString());
                    vade_id = 7;
                    barname2 f = new barname2();
                    f.ShowDialog();

                }

            }
        }

        private void bunifuButton8_Click(object sender, EventArgs e)
        {
            if (barname_id == -1)
            {
                MessageBox.Show("لطفا یک برنامه ثبت کنید");

            }
            else
            {
                if ((bunifuMetroTextbox24.Text == "") || (bunifuMetroTextbox25.Text == "") || (bunifuMetroTextbox23.Text == ""))
                {
                    MessageBox.Show("لطفا اطلاعات را وارد کنید");
                }
                else
                {
                    pro1 = (float.Parse(bunifuMetroTextbox24.Text.ToString()) / 100) * float.Parse(bunifuMetroTextbox5.Text.ToString());
                    karbo1 = (float.Parse(bunifuMetroTextbox25.Text.ToString()) / 100) * float.Parse(bunifuMetroTextbox7.Text.ToString());
                    charb1 = (float.Parse(bunifuMetroTextbox23.Text.ToString()) / 100) * float.Parse(bunifuMetroTextbox4.Text.ToString());
                    vade_id = 8;
                    barname2 f = new barname2();
                    f.ShowDialog();

                }

            }
        }

        private void bunifuButton6_Click(object sender, EventArgs e)
        {
            groupBox3.Enabled = true;
            bunifuMetroTextbox1.Text = bunifuMetroTextbox2.Text = bunifuMetroTextbox3.Text = bunifuMetroTextbox4.Text = bunifuMetroTextbox5.Text = bunifuMetroTextbox6.Text = bunifuMetroTextbox7.Text = bunifuMetroTextbox8.Text = bunifuMetroTextbox9.Text = bunifuMetroTextbox10.Text = bunifuMetroTextbox11.Text = bunifuMetroTextbox12.Text = bunifuMetroTextbox13.Text = bunifuMetroTextbox14.Text = bunifuMetroTextbox13.Text = bunifuMetroTextbox14.Text = bunifuMetroTextbox15.Text = bunifuMetroTextbox16.Text = bunifuMetroTextbox17.Text = bunifuMetroTextbox18.Text = bunifuMetroTextbox19.Text = bunifuMetroTextbox20.Text = bunifuMetroTextbox21.Text = bunifuMetroTextbox22.Text = bunifuMetroTextbox23.Text = bunifuMetroTextbox24.Text = bunifuMetroTextbox25.Text = bunifuMetroTextbox26.Text = bunifuMetroTextbox27.Text = bunifuMetroTextbox28.Text = bunifuMetroTextbox29.Text = bunifuMetroTextbox30.Text = bunifuMetroTextbox31.Text = "";
            SqlConnection a = new SqlConnection(connectify.pcs);
            a.Open();
            SqlCommand b = new SqlCommand("delete from barname", a);
            b.ExecuteNonQuery();
            b = new SqlCommand("delete from vade1", a);
            b.ExecuteNonQuery();
            b = new SqlCommand("delete from vade2", a);
            b.ExecuteNonQuery();
            b = new SqlCommand("delete from vade3", a);
            b.ExecuteNonQuery();
            b = new SqlCommand("delete from vade4", a);
            b.ExecuteNonQuery();
            b = new SqlCommand("delete from vade5", a);
            b.ExecuteNonQuery();
            b = new SqlCommand("delete from vade6", a);
            b.ExecuteNonQuery();
            b = new SqlCommand("delete from vade7", a);
            b.ExecuteNonQuery();
            b = new SqlCommand("delete from vade8", a);
            b.ExecuteNonQuery();
        }

        private void bunifuMetroTextbox5_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuButton11_Click_1(object sender, EventArgs e)
        {

        }
    }
}
