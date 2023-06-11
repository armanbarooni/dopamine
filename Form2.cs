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
using System.IO;

namespace MobileCenterAbadan
{
    public partial class Form2 : Form
    {
        public void clean()
        {
            richTextBox1.Text = bunifuMetroTextbox1.Text = bunifuMetroTextbox2.Text = bunifuMetroTextbox3.Text = bunifuMetroTextbox4.Text = bunifuMetroTextbox5.Text = bunifuMetroTextbox6.Text = bunifuMetroTextbox7.Text = comboBox1.Text = comboBox2.Text = bunifuMetroTextbox8.Text = bunifuMetroTextbox9.Text= "";
        }
        public void fill_vahed()
        {
            comboBox1.Items.Clear();

            SqlConnection a = new SqlConnection(connectify.pcs);
            a.Open();
            SqlCommand b = new SqlCommand("select * from vahed", a);
            SqlDataAdapter sd = new SqlDataAdapter(b.CommandText, a);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            a.Close();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                comboBox1.Items.Add(dt.Rows[i]["name"].ToString());


            }
        }
        public Form2()
        {
            InitializeComponent();
            fill_vahed();
          
            comboBox2.Items.Add("صبحانه");
            comboBox2.Items.Add("ناهار");
            comboBox2.Items.Add("شام");
            comboBox2.Items.Add("میان وعده");
            comboBox2.Items.Add("ساعت ده صبح");
            comboBox2.Items.Add("ساعت پنج عصر");
            comboBox2.Items.Add(" غذای اصلی");
 //           comboBox2.Items.Add("همه");



            //foreach (DataGridViewRow row in dataGridView1.Rows)
            //    if (row.Index % 2 == 0)
            //    {
            //        row.DefaultCellStyle.BackColor = Color.Azure;
            //    }
            //    else
            //    {
            //        row.DefaultCellStyle.BackColor = Color.PaleTurquoise;

            //  }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form2 s = new Form2();
            this.Close();
            s.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

    
        private void bunifuMetroTextbox1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void bunifuMetroTextbox3_KeyPress(object sender, KeyPressEventArgs e)
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

        private void bunifuMetroTextbox1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar) || char.IsPunctuation(e.KeyChar))) { e.Handled = true; MessageBox.Show("لطفا فقط عدد وارد کنید", "Alert!"); }

        }

        private void bunifuMetroTextbox2_KeyPress(object sender, KeyPressEventArgs e)
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

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
                MessageBox.Show("لطفا نام یک واحد را وارد کنید");
            else
            {
                SqlConnection a = new SqlConnection(connectify.pcs);
                a.Open();
                SqlCommand b = new SqlCommand("insert into vahed (name) values ('" + comboBox1.Text + "')", a);
                b.ExecuteNonQuery();
                a.Close();
                fill_vahed();
                clean();
            }
          
        }
        public void text()
        {
            richTextBox1.Text = richTextBox1.Text.Replace("۰", "0").Replace("۱", "1").Replace("۲", "2").Replace("۳", "3").Replace("۴", "4").Replace("۵", "5").Replace("۶", "6").Replace("۷", "7").Replace("۸", "8").Replace("۹", "9");

        }
        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            clean();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            int type = 1;
            if (checkBox2.Checked == true)
                type = 3;
            if (checkBox3.Checked == true)
                type = 2;
            text();
            if ((comboBox1.Text == "") || (comboBox2.Text == "") || (bunifuMetroTextbox2.Text == "")|| (bunifuMetroTextbox9.Text == ""))
            {
                MessageBox.Show("لطفا  اطلاعات اولیه  را وارد کنید");
            }
            else if((bunifuMetroTextbox8.Text == "")&&((bunifuMetroTextbox5.Text == "") && (bunifuMetroTextbox6.Text == "") && (bunifuMetroTextbox7.Text == "")))
            {
                MessageBox.Show("لطفا  یا کالری یا مقادیر پورتئین چربی و کربوهیدرات وارد شود");

            }
            else
            {
                string min, max, had;
                string pro, charb, karbo;
                pro = charb = karbo = "0";
                min = max = "1";
                had = "0";
                if(bunifuMetroTextbox1.Text!="")
                {
                    had = bunifuMetroTextbox1.Text;
                }
                if (bunifuMetroTextbox3.Text != "")
                {
                    min = bunifuMetroTextbox3.Text;
                }
                if (bunifuMetroTextbox4.Text != "")
                {
                    max = bunifuMetroTextbox4.Text;
                }
                if (bunifuMetroTextbox6.Text != "")
                {
                    charb = bunifuMetroTextbox6.Text;
                }
                if (bunifuMetroTextbox7.Text != "")
                {
                     pro= bunifuMetroTextbox7.Text;
                }
                if (bunifuMetroTextbox5.Text != "")
                {
                   karbo = bunifuMetroTextbox5.Text;
                }
                SqlConnection a = new SqlConnection(connectify.pcs);
                a.Open();
                SqlDataAdapter sd = new SqlDataAdapter("select id from vahed where name=N'" + comboBox1.Text + "' ", a);
                DataTable dt = new DataTable();
                sd.Fill(dt);
                SqlCommand b;
                int vahed_id = int.Parse(dt.Rows[0]["id"].ToString());
                int cal = 0;
                if ((bunifuMetroTextbox8.Text == "") || (bunifuMetroTextbox8.Text == "0"))
                    cal = (int.Parse(bunifuMetroTextbox5.Text) * 4) + (int.Parse(bunifuMetroTextbox6.Text) * 9) + (int.Parse(bunifuMetroTextbox7.Text) * 4);
                else
                    cal = int.Parse(bunifuMetroTextbox8.Text);
                b = new SqlCommand("insert into foods (name,vahed,dastebandi,had,minimom,maximom,karbo,pro,charb,tozihat,cal,import,type) values ('" + bunifuMetroTextbox2.Text + "','" + vahed_id + "','" + comboBox2.Text + "','" +had + "','" + min + "','" + max + "','" + karbo + "','" + pro + "','" + charb + "','" + richTextBox1.Text + "','" + cal.ToString()+ "','"+bunifuMetroTextbox9.Text+"','"+type+"') ", a);
                b.ExecuteNonQuery();
                clean();
                a.Close();
                MessageBox.Show("افزودن با موفقیت انجام شد");
            }


        }

        private void bunifuMetroTextbox2_Enter(object sender, EventArgs e)
        {
        }

        private void comboBox1_Enter(object sender, EventArgs e)
        {
        }

        private void comboBox2_Enter(object sender, EventArgs e)
        {
        }

        private void bunifuMetroTextbox1_Enter(object sender, EventArgs e)
        {
        }

        private void bunifuMetroTextbox3_Enter(object sender, EventArgs e)
        {
        }

        private void bunifuMetroTextbox4_Enter(object sender, EventArgs e)
        {
        }

        private void bunifuMetroTextbox5_Enter(object sender, EventArgs e)
        {
        }

        private void bunifuMetroTextbox6_Enter(object sender, EventArgs e)
        {
        }

        private void bunifuMetroTextbox7_Enter(object sender, EventArgs e)
        {
        }

        private void bunifuMetroTextbox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                comboBox1.Focus();
            }
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                comboBox2.Focus();
            }

        }

        private void comboBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bunifuMetroTextbox1.Focus();
            }

            
        }

        private void bunifuMetroTextbox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                        bunifuMetroTextbox3.Focus();
            }
    

        }

        private void bunifuMetroTextbox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bunifuMetroTextbox4.Focus();
              
            }
           

        }

        private void bunifuMetroTextbox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bunifuMetroTextbox5.Focus();
            }           
        }

        private void bunifuMetroTextbox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bunifuMetroTextbox6.Focus();
            }
        }

        private void bunifuMetroTextbox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bunifuMetroTextbox7.Focus();
            }
        }

        private void bunifuMetroTextbox7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                richTextBox1.Focus();
            }
        }

        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    if ((bunifuMetroTextbox4.Text == "") || (bunifuMetroTextbox5.Text == "") || (bunifuMetroTextbox6.Text == "") || (bunifuMetroTextbox7.Text == "") || (comboBox1.Text == "") || (comboBox2.Text == "") || (bunifuMetroTextbox1.Text == "") || (bunifuMetroTextbox2.Text == "") || (bunifuMetroTextbox3.Text == ""))
            //    {
            //        MessageBox.Show("لطفا تمام اطلاعات را وارد کنید");
            //    }
            //    else
            //    {
            //        SqlConnection a = new SqlConnection(connectify.pcs);
            //        a.Open();
            //        SqlCommand b = new SqlCommand("select id from vahed where name='" + comboBox1.Text + "'", a);
            //        SqlDataAdapter sd = new SqlDataAdapter(b.CommandText, a);
            //        DataTable dt = new DataTable();
            //        sd.Fill(dt);
            //        int vahed_id = int.Parse(dt.Rows[0]["id"].ToString());
            //        b = new SqlCommand("insert into foods (name,vahed,dastebandi,had,minimom,maximom,karbo,pro,charb,tozihat) values ('" + bunifuMetroTextbox2.Text + "','" + vahed_id + "','" + comboBox2.Text + "','" + bunifuMetroTextbox1.Text + "','" + bunifuMetroTextbox3.Text + "','" + bunifuMetroTextbox4.Text + "','" + bunifuMetroTextbox5.Text + "','" + bunifuMetroTextbox6.Text + "','" + bunifuMetroTextbox7.Text + "','" + richTextBox1.Text + "') ", a);
            //        b.ExecuteNonQuery();
            //        clean();
            //        a.Close();
            //        MessageBox.Show("افزودن با موفقیت انجام شد");
            //    }
            //}
        }

        private void richTextBox1_KeyUp(object sender, KeyEventArgs e)
        {
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            clean();
        }

        private void bunifuButton4_Click_1(object sender, EventArgs e)
        {
            using (var reader = new StreamReader((@"C:\dopamin\dopamineteam\MobileCenterAbadan\bin\Debug\dopa.xlsx")))

            {
                List<string> listA = new List<string>();
                List<string> listB = new List<string>();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');

                    listA.Add(values[0]);
                }
            }
        }
    }
    }
    

