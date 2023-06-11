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
    public partial class barnamejadid : Form
    {
        public barnamejadid()
        {
            InitializeComponent();
            SqlConnection a = new SqlConnection(connectify.pcs);
            a.Open();
            SqlCommand b = new SqlCommand("select * from list_mokamel", a);
            SqlDataAdapter sd = new SqlDataAdapter(b.CommandText, a);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            a.Close();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                comboBox2.Items.Add(dt.Rows[i]["name"].ToString());


            }
        }


        public void text1()
        {
            bunifuMetroTextbox1.Text = bunifuMetroTextbox1.Text.Replace("۰", "0").Replace("۱", "1").Replace("۲", "2").Replace("۳", "3").Replace("۴", "4").Replace("۵", "5").Replace("۶", "6").Replace("۷", "7").Replace("۸", "8").Replace("۹", "9");

        }
        public void text2()
        {
            bunifuMetroTextbox2.Text = bunifuMetroTextbox2.Text.Replace("۰", "0").Replace("۱", "1").Replace("۲", "2").Replace("۳", "3").Replace("۴", "4").Replace("۵", "5").Replace("۶", "6").Replace("۷", "7").Replace("۸", "8").Replace("۹", "9");

        }
        public void text3()
        {
            bunifuMetroTextbox3.Text = bunifuMetroTextbox3.Text.Replace("۰", "0").Replace("۱", "1").Replace("۲", "2").Replace("۳", "3").Replace("۴", "4").Replace("۵", "5").Replace("۶", "6").Replace("۷", "7").Replace("۸", "8").Replace("۹", "9");

        }
        public void text4()
        {
            bunifuMetroTextbox4.Text = bunifuMetroTextbox4.Text.Replace("۰", "0").Replace("۱", "1").Replace("۲", "2").Replace("۳", "3").Replace("۴", "4").Replace("۵", "5").Replace("۶", "6").Replace("۷", "7").Replace("۸", "8").Replace("۹", "9");

        }
        public void text5()
        {
            bunifuMetroTextbox5.Text = bunifuMetroTextbox5.Text.Replace("۰", "0").Replace("۱", "1").Replace("۲", "2").Replace("۳", "3").Replace("۴", "4").Replace("۵", "5").Replace("۶", "6").Replace("۷", "7").Replace("۸", "8").Replace("۹", "9");

        }
        public void text7()
        {
            bunifuMetroTextbox7.Text = bunifuMetroTextbox7.Text.Replace("۰", "0").Replace("۱", "1").Replace("۲", "2").Replace("۳", "3").Replace("۴", "4").Replace("۵", "5").Replace("۶", "6").Replace("۷", "7").Replace("۸", "8").Replace("۹", "9");

        }
        public void text6()
        {
            bunifuMetroTextbox13.Text = bunifuMetroTextbox13.Text.Replace("۰", "0").Replace("۱", "1").Replace("۲", "2").Replace("۳", "3").Replace("۴", "4").Replace("۵", "5").Replace("۶", "6").Replace("۷", "7").Replace("۸", "8").Replace("۹", "9");

        }
        public void text8()
        {
            bunifuMetroTextbox15.Text = bunifuMetroTextbox15.Text.Replace("۰", "0").Replace("۱", "1").Replace("۲", "2").Replace("۳", "3").Replace("۴", "4").Replace("۵", "5").Replace("۶", "6").Replace("۷", "7").Replace("۸", "8").Replace("۹", "9");

        }
        public static int protoein;
        public static int charbi;
        public static string name;
        private void bunifuButton11_Click(object sender, EventArgs e)
        {
            name = bunifuMetroTextbox8.Text;
            text1();
            text2();
            text3();
            text7();
            text4();
            text5();
            text6();
            text8();
            SqlConnection a = new SqlConnection(connectify.pcs);
            a.Open();
            if((bunifuMetroTextbox7.Text=="")|| (bunifuMetroTextbox5.Text == "")|| (bunifuMetroTextbox4.Text == "") || (bunifuMetroTextbox15.Text == "") || (bunifuMetroTextbox13.Text == ""))
            {
                MessageBox.Show("لطفا تمام اطلاعات را وارد کنید");
            }
            else
            {
                protoein = (int)((int.Parse(bunifuMetroTextbox7.Text)) * (float.Parse(bunifuMetroTextbox4.Text)));
                charbi = (int)((int.Parse(bunifuMetroTextbox7.Text)) * (float.Parse(bunifuMetroTextbox5.Text)));
                string hadaf = "";
                string tedad = "";
                double ghad = 4.799 * (float.Parse(bunifuMetroTextbox15.Text));
                double sen = (5.677 * float.Parse(bunifuMetroTextbox13.Text));
                double vazn = float.Parse(bunifuMetroTextbox7.Text) * 13.397;
                double weight = ghad-sen    + vazn + 88.362;
                double zarib = 1;
                int kasr = 0;
                int jam = 0;
                if (radioButton16.Checked == true)
                    zarib = 1.375;
               else if (radioButton1.Checked == true)
                    zarib = 1.55;
               else if (radioButton2.Checked == true)
                    zarib = 1.725;
                else if (radioButton3.Checked == true)
                    zarib = 1.9;
                if (radioButton6.Checked == true)
                    kasr = 5;
               else if (radioButton5.Checked == true)
                    kasr = 10;
                else if (radioButton4.Checked == true)
                    kasr = 15;
               else if (radioButton7.Checked == true)
                    kasr = 20;
                else if (radioButton8.Checked == true)
                    kasr = 25;
                else if (radioButton9.Checked == true)
                    kasr = 0;
                if (radioButton10.Checked == true)
                    jam = 0;
                else if (radioButton15.Checked == true)// mast islandi  27 g pro protoein vey scope 25 g sefide tokhm 3  shir 7 g
                    jam = 5;
                else if (radioButton14.Checked == true)
                    jam = 10;
                else if (radioButton13.Checked == true)
                    jam = 15;
                else if (radioButton12.Checked == true)
                    jam = 20;
                else if (radioButton11.Checked == true)
                    jam = 25;
                int cal =(int) (weight*zarib);
                if (bunifuMetroTextbox6.Text != "")
                    hadaf = bunifuMetroTextbox6.Text;
                if (bunifuMetroTextbox10.Text != "")
                    tedad = bunifuMetroTextbox10.Text;
                cal = ((cal * 100) - (cal * kasr)) / 100;
                cal = ((cal * 100) + (cal * jam)) / 100;
                weight = (int)weight;
                SqlCommand b = new SqlCommand("insert into barname (name,day,month,year,weight,cal,hadaf,tedad,first_cal,rezayat) values ('"+bunifuMetroTextbox8.Text+"','"+bunifuMetroTextbox1.Text+"','"+bunifuMetroTextbox2.Text+"','"+bunifuMetroTextbox3.Text+"','"+int.Parse(bunifuMetroTextbox7.Text)+"','"+cal+"','"+bunifuMetroTextbox6.Text+"','"+bunifuMetroTextbox10.Text+"','"+weight+"','"+bunifuMetroTextbox16.Text+"')", a);
                b.ExecuteNonQuery();
                bunifuMetroTextbox1.Text=bunifuMetroTextbox13.Text=bunifuMetroTextbox15.Text = bunifuMetroTextbox2.Text = bunifuMetroTextbox3.Text = bunifuMetroTextbox4.Text = bunifuMetroTextbox5.Text = bunifuMetroTextbox2.Text = bunifuMetroTextbox7.Text = bunifuMetroTextbox8.Text = bunifuMetroTextbox9.Text =bunifuMetroTextbox6.Text=bunifuMetroTextbox10.Text= "";
                bunifuMetroTextbox9.Text = cal.ToString();
                barname_id=0;
                b = new SqlCommand("delete from foodss", a);
                b.ExecuteNonQuery();
               
                    bunifuMetroTextbox9.Focus();
                
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            barname_id = -1;
            this.Close();
        }
        public static int barname_id=-1;
        public static int call = -1;
        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            if (barname_id == -1)
                MessageBox.Show("لطفا یک برنامه جدید ثبت کنید");
            else
            {
                SqlConnection a = new SqlConnection(connectify.pcs);
                a.Open();
                SqlDataAdapter sd = new SqlDataAdapter("select max(id)as maxim from barname", a);
                DataTable dt = new DataTable();
                sd.Fill(dt);
                barname_id = int.Parse(dt.Rows[0]["maxim"].ToString());
             sd = new SqlDataAdapter("select cal from barname where id='"+barname_id+"'", a);
             dt = new DataTable();
            sd.Fill(dt);
            call = int.Parse(dt.Rows[0]["cal"].ToString());
            barname2 f = new barname2();
                f.ShowDialog();
             
                SqlCommand c = new SqlCommand("delete from tozihat", a);
                c.ExecuteNonQuery();
            }
           

        }

        private void bunifuMetroTextbox7_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            bunifuMetroTextbox1.Text = bunifuMetroTextbox2.Text = bunifuMetroTextbox3.Text = bunifuMetroTextbox4.Text = bunifuMetroTextbox5.Text = bunifuMetroTextbox2.Text = bunifuMetroTextbox7.Text =bunifuMetroTextbox8.Text=bunifuMetroTextbox9.Text= "";
            bunifuMetroTextbox9.Text = "";
            barname_id = -1;
        }

        private void bunifuMetroTextbox2_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuMetroTextbox3_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuMetroTextbox1_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuMetroTextbox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar) || char.IsPunctuation(e.KeyChar))) { e.Handled = true; MessageBox.Show("لطفا فقط عدد وارد کنید", "Alert!"); }

        }

        private void bunifuMetroTextbox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar) || char.IsPunctuation(e.KeyChar))) { e.Handled = true; MessageBox.Show("لطفا فقط عدد وارد کنید", "Alert!"); }

        }

        private void bunifuMetroTextbox8_KeyDown(object sender, KeyEventArgs e)
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
                bunifuMetroTextbox2.Focus();
            }
        }

        private void bunifuMetroTextbox2_KeyDown(object sender, KeyEventArgs e)
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
                bunifuMetroTextbox7.Focus();
            }
        }

        private void bunifuMetroTextbox7_KeyDown(object sender, KeyEventArgs e)
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
                bunifuMetroTextbox4.Focus();
            }
        }

        private void bunifuMetroTextbox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bunifuMetroTextbox15.Focus();
            }
        }

        private void bunifuMetroTextbox9_Enter(object sender, EventArgs e)
        {
          
        }

        private void bunifuMetroTextbox9_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (barname_id == -1)
                    MessageBox.Show("لطفا یک برنامه جدید ثبت کنید");
                else
                {
                    SqlConnection a = new SqlConnection(connectify.pcs);
                    a.Open();
                    SqlDataAdapter sd = new SqlDataAdapter("select max(id)as maxim from barname", a);
                    DataTable dt = new DataTable();
                    sd.Fill(dt);
                    barname_id = int.Parse(dt.Rows[0]["maxim"].ToString());
                    sd = new SqlDataAdapter("select cal from barname where id='" + barname_id + "'", a);
                    dt = new DataTable();
                    sd.Fill(dt);
                    call = int.Parse(dt.Rows[0]["cal"].ToString());
                    barname2 f = new barname2();
                    f.ShowDialog();

                    SqlCommand c = new SqlCommand("delete from tozihat", a);
                    c.ExecuteNonQuery();
                }
            }
        }

        private void radioButton1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bunifuMetroTextbox5.Focus();
            }
        }

        private void radioButton2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bunifuMetroTextbox5.Focus();
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void radioButton3_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void radioButton9_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton9_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void bunifuMetroTextbox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bunifuMetroTextbox10.Focus();
            }
        }

        private void bunifuMetroTextbox10_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void bunifuMetroTextbox4_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuMetroTextbox6_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bunifuMetroTextbox10.Focus();
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton1_Click_1(object sender, EventArgs e)
        {
            if (barname_id == -1)
                MessageBox.Show("لطفا یک برنامه جدید ثبت کنید");
            else
            {
                SqlConnection a = new SqlConnection(connectify.pcs);
                a.Open();
                SqlDataAdapter sd = new SqlDataAdapter("select max(id)as maxim from barname", a);
                DataTable dt = new DataTable();
                sd.Fill(dt);
                barname_id = int.Parse(dt.Rows[0]["maxim"].ToString());
                sd = new SqlDataAdapter("select cal from barname where id='" + barname_id + "'", a);
                dt = new DataTable();
                sd.Fill(dt);
                call = int.Parse(dt.Rows[0]["cal"].ToString());
                barname2 f = new barname2();
                SqlCommand c = new SqlCommand("delete from tozihat", a);
                c.ExecuteNonQuery();

                c = new SqlCommand("delete from foodsss", a);
                c.ExecuteNonQuery();

                c = new SqlCommand("delete from pishnahad", a);
                c.ExecuteNonQuery();

                f.ShowDialog();


            }
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            if ((bunifuMetroTextbox11.Text != "") && (bunifuMetroTextbox12.Text != ""))
            {
                string name = bunifuMetroTextbox11.Text + "/" + bunifuMetroTextbox12.Text;
                SqlConnection a = new SqlConnection(connectify.pcs);
                a.Open();
                SqlCommand c = new SqlCommand("insert into list_mokamel (name) values ('" + name + "' )", a);
                c.ExecuteNonQuery();
                bunifuMetroTextbox11.Text = bunifuMetroTextbox12.Text = "";
            }
            else
                MessageBox.Show("لطفا اطلاعات را تکمیل کنید");
        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            if ((comboBox2.Text != "") )
            {
                if (bunifuMetroTextbox14.Text == "")
                {
                  if(  MessageBox.Show("ایا میخواهید توضیحات را خالی بگذارید؟", "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        if (barname_id == -1)
                            MessageBox.Show("لطفا یک برنامه جدید ثبت کنید");
                        else
                        {
                            SqlConnection a = new SqlConnection(connectify.pcs);
                            a.Open();
                            SqlDataAdapter sd = new SqlDataAdapter("select max(id)as maxim from barname", a);
                            DataTable dt = new DataTable();
                            sd.Fill(dt);
                            barname_id = int.Parse(dt.Rows[0]["maxim"].ToString());                     
                            SqlCommand c = new SqlCommand("insert into mokamel (tozihat,id_mokamel,name) values ('" + bunifuMetroTextbox14.Text + "','"+barname_id+"','" + comboBox2.Text + "')", a);
                            c.ExecuteNonQuery();
                            bunifuMetroTextbox11.Text = bunifuMetroTextbox12.Text = "";
                            sd = new SqlDataAdapter("select id,name,tozihat from mokamel where id_mokamel='"+barname_id+"'  ", a);
                            dt = new DataTable();
                            sd.Fill(dt);
                            dataGridView2.DataSource = dt;
                            a.Close();
                            comboBox2.Text = bunifuMetroTextbox14.Text = "";

                        }
                    }
                }
                else
                {
                    if (barname_id == -1)
                        MessageBox.Show("لطفا یک برنامه جدید ثبت کنید");
                    else
                    {
                        SqlConnection a = new SqlConnection(connectify.pcs);
                        a.Open();
                        SqlDataAdapter sd = new SqlDataAdapter("select max(id)as maxim from barname", a);
                        DataTable dt = new DataTable();
                        sd.Fill(dt);
                        barname_id = int.Parse(dt.Rows[0]["maxim"].ToString());
                        SqlCommand c = new SqlCommand("insert into mokamel (tozihat,id_mokamel,name) values ('" + bunifuMetroTextbox14.Text + "','" + barname_id + "','" + comboBox2.Text + "')", a);
                        c.ExecuteNonQuery();
                        bunifuMetroTextbox11.Text = bunifuMetroTextbox12.Text = "";
                        sd = new SqlDataAdapter("select id,name,tozihat from mokamel where id_mokamel='" + barname_id + "'  ", a);
                        dt = new DataTable();
                        sd.Fill(dt);
                        dataGridView2.DataSource = dt;
                        a.Close();
                        comboBox2.Text = bunifuMetroTextbox14.Text = "";
                    }
                }

            }
            else
                MessageBox.Show("لطفا اطلاعات را تکمیل کنید");
        }

        private void bunifuButton5_Click(object sender, EventArgs e)
        {
            if (id_delete != -1)
            {
                SqlConnection a = new SqlConnection(connectify.pcs);
                a.Open();
                SqlCommand c = new SqlCommand("delete from mokamel where id="+id_delete+" ", a);
                c.ExecuteNonQuery();
                a.Close();
                id_delete = -1;
                SqlDataAdapter sd = new SqlDataAdapter("select id,name,tozihat from mokamel where id_mokamel='" + barname_id + "'  ", a);
                DataTable dt = new DataTable();
                sd.Fill(dt);
                dataGridView2.DataSource = dt;
            }
            else
                MessageBox.Show("لطفا یک سطر را انتخاب کنید");
        }
        public int id_delete = -1;
        private void dataGridView2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int index = e.RowIndex;
            id_delete = int.Parse(dataGridView2.Rows[index].Cells[0].Value.ToString());
           
        }

        private void bunifuMetroTextbox15_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bunifuMetroTextbox13.Focus();
            }
        }

        private void bunifuMetroTextbox13_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bunifuMetroTextbox6.Focus();
            }
        }

        private void bunifuMetroTextbox15_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar) || char.IsPunctuation(e.KeyChar))) { e.Handled = true; MessageBox.Show("لطفا فقط عدد وارد کنید", "Alert!"); }

        }

        private void bunifuMetroTextbox13_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar) || char.IsPunctuation(e.KeyChar))) { e.Handled = true; MessageBox.Show("لطفا فقط عدد وارد کنید", "Alert!"); }

        }

        private void bunifuButton6_Click(object sender, EventArgs e)
        {
            name = bunifuMetroTextbox8.Text;
            text1();
            text2();
            text3();
            text7();
            text4();
            text5();
            text6();
            text8();
            SqlConnection a = new SqlConnection(connectify.pcs);
            a.Open();
            if ((bunifuMetroTextbox7.Text == "") || (bunifuMetroTextbox5.Text == "") || (bunifuMetroTextbox4.Text == "") || (bunifuMetroTextbox15.Text == "") || (bunifuMetroTextbox13.Text == ""))
            {
                MessageBox.Show("لطفا تمام اطلاعات را وارد کنید");
            }
            else
            {
                protoein = (int)((int.Parse(bunifuMetroTextbox7.Text)) * (float.Parse(bunifuMetroTextbox4.Text)));
                charbi = (int)((int.Parse(bunifuMetroTextbox7.Text)) * (float.Parse(bunifuMetroTextbox5.Text)));
                string hadaf = "";
                string tedad = "";
                double ghad = 3.098 * (float.Parse(bunifuMetroTextbox15.Text));
                double sen = (4.330 * float.Parse(bunifuMetroTextbox13.Text));
                double vazn = float.Parse(bunifuMetroTextbox7.Text) * 9.247;
                double weight = ghad - sen + vazn + 447.593;
                double zarib = 1;
                int kasr = 0;
                int jam = 0;
                if (radioButton16.Checked == true)
                    zarib = 1.375;
                else if (radioButton1.Checked == true)
                    zarib = 1.55;
                else if (radioButton2.Checked == true)
                    zarib = 1.725;
                else if (radioButton3.Checked == true)
                    zarib = 1.9;
                if (radioButton6.Checked == true)
                    kasr = 5;
                else if (radioButton5.Checked == true)
                    kasr = 10;
                else if (radioButton4.Checked == true)
                    kasr = 15;
                else if (radioButton7.Checked == true)
                    kasr = 20;
                else if (radioButton8.Checked == true)
                    kasr = 25;
                else if (radioButton9.Checked == true)
                    kasr = 0;
                if (radioButton10.Checked == true)
                    jam = 0;
                else if (radioButton15.Checked == true)// mast islandi  27 g pro protoein vey scope 25 g sefide tokhm 3  shir 7 g
                    jam = 5;
                else if (radioButton14.Checked == true)
                    jam = 10;
                else if (radioButton13.Checked == true)
                    jam = 15;
                else if (radioButton12.Checked == true)
                    jam = 20;
                else if (radioButton11.Checked == true)
                    jam = 25;
                int cal = (int)(weight * zarib);
                if (bunifuMetroTextbox6.Text != "")
                    hadaf = bunifuMetroTextbox6.Text;
                if (bunifuMetroTextbox10.Text != "")
                    tedad = bunifuMetroTextbox10.Text;
                cal = ((cal * 100) - (cal * kasr)) / 100;
                cal = ((cal * 100) + (cal * jam)) / 100;

                SqlCommand b = new SqlCommand("insert into barname (name,day,month,year,weight,cal,hadaf,tedad,first_cal) values ('" + bunifuMetroTextbox8.Text + "','" + bunifuMetroTextbox1.Text + "','" + bunifuMetroTextbox2.Text + "','" + bunifuMetroTextbox3.Text + "','" + int.Parse(bunifuMetroTextbox7.Text) + "','" + cal + "','" + bunifuMetroTextbox6.Text + "','" + bunifuMetroTextbox10.Text + "','"+weight+"')", a);
                b.ExecuteNonQuery();
                bunifuMetroTextbox1.Text = bunifuMetroTextbox2.Text = bunifuMetroTextbox13.Text = bunifuMetroTextbox15.Text = bunifuMetroTextbox3.Text = bunifuMetroTextbox4.Text = bunifuMetroTextbox5.Text = bunifuMetroTextbox2.Text = bunifuMetroTextbox7.Text = bunifuMetroTextbox8.Text = bunifuMetroTextbox9.Text = bunifuMetroTextbox6.Text = bunifuMetroTextbox10.Text = "";
                bunifuMetroTextbox9.Text = cal.ToString();
                barname_id = 0;
                b = new SqlCommand("delete from foodss", a);
                b.ExecuteNonQuery();

                bunifuMetroTextbox9.Focus();

            }
        }

        private void radioButton9_MouseClick(object sender, MouseEventArgs e)
        {
          
        }

        private void radioButton9_Click(object sender, EventArgs e)
        {
       

        }

        private void radioButton9_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void radioButton9_MouseUp(object sender, MouseEventArgs e)
        {
          
        }

        private void bunifuButton7_Click(object sender, EventArgs e)
        {
            radioButton1.Checked = radioButton10.Checked = radioButton11.Checked = radioButton12.Checked = radioButton13.Checked = radioButton14.Checked = radioButton15.Checked = false;
            radioButton16.Checked = radioButton2.Checked = radioButton3.Checked = radioButton4.Checked = radioButton5.Checked = radioButton6.Checked = radioButton7.Checked = radioButton8.Checked = radioButton9.Checked = false;
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void bunifuMetroTextbox15_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
