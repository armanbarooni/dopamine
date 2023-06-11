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
    public partial class edit : Form
    {
        public void clean()
        {
            richTextBox1.Text = bunifuMetroTextbox1.Text = bunifuMetroTextbox2.Text = bunifuMetroTextbox3.Text = bunifuMetroTextbox4.Text = bunifuMetroTextbox5.Text = bunifuMetroTextbox6.Text = bunifuMetroTextbox7.Text = comboBox1.Text = comboBox2.Text =bunifuMetroTextbox8.Text=bunifuMetroTextbox9.Text= "";
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
        public void color()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Index % 2 == 0)
                {

                    row.DefaultCellStyle.BackColor = Color.Lavender;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.LavenderBlush;

                }
            }
        }
        public void show()
        {
            SqlConnection a = new SqlConnection(connectify.pcs);
            a.Open();
            SqlCommand b = new SqlCommand("select id,name,had,minimom,maximom,karbo,pro,charb,cal,import from foods ", a);
            SqlDataAdapter sd = new SqlDataAdapter(b.CommandText, a);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        public edit()
        {
            InitializeComponent();
            fill_vahed();
            show();
            comboBox2.Items.Add("صبحانه");
            comboBox2.Items.Add("ناهار");
            comboBox2.Items.Add("شام");
            comboBox2.Items.Add("میان وعده");
            comboBox2.Items.Add("ساعت ده صبح");
            comboBox2.Items.Add("ساعت پنج عصر");
            comboBox2.Items.Add("همه");

        }

        private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void bunifuMetroTextbox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar) || char.IsPunctuation(e.KeyChar))) { e.Handled = true; MessageBox.Show("لطفا فقط عدد وارد کنید", "Alert!"); }

        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            clean();
            show();
            color();
            x = -1;
        }

        private void bunifuMetroTextbox2_Enter(object sender, EventArgs e)
        {
            color();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            Form2 s = new Form2();
            this.Close();
            s.Close();
        }
        public int x=-1;
        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            if (x == -1)
                MessageBox.Show("لطفا یک سطر انتخاب کنید");
            else
            {
                SqlConnection a = new SqlConnection(connectify.pcs);
                a.Open();
                SqlCommand b = new SqlCommand("delete from foods where id='" + int.Parse(dataGridView1.Rows[x].Cells[0].Value.ToString()) + "'", a);
                b.ExecuteNonQuery();
                clean();
                show();
                color();
                x = -1;
            }
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            if (x == -1)
                MessageBox.Show("لطفا یک سطر انتخاب کنید");
            else
            {
                SqlConnection a = new SqlConnection(connectify.pcs);
                a.Open();
                SqlCommand bb = new SqlCommand("select id from vahed where name='" + comboBox1.Text + "' ", a);
                SqlDataAdapter sdd = new SqlDataAdapter(bb.CommandText, a);
                DataTable dtt = new DataTable();
                sdd.Fill(dtt);
                int vahed = int.Parse(dtt.Rows[0]["id"].ToString());
                SqlCommand b = new SqlCommand("update  foods set name='" + bunifuMetroTextbox2.Text + "' , vahed='" + vahed + "', dastebandi='" + comboBox2.Text + "',had='" + bunifuMetroTextbox1.Text + "',minimom='" + bunifuMetroTextbox3.Text + "',maximom='" + bunifuMetroTextbox4.Text + "',karbo='" + bunifuMetroTextbox5.Text + "',pro='" + bunifuMetroTextbox7.Text + "',charb='" + bunifuMetroTextbox6.Text + "',tozihat='" + richTextBox1.Text + "',cal='"+bunifuMetroTextbox9.Text+"',import='"+bunifuMetroTextbox8.Text+"' where id='" + idd + "'   ", a);
                b.ExecuteNonQuery();
                clean();
              //  show();
                color();
                x = -1;
            }
   
        }

        private void bunifuMetroTextbox2_KeyUp(object sender, KeyEventArgs e)
        {
            SqlConnection a = new SqlConnection(connectify.pcs);
            a.Open();
            SqlCommand b = new SqlCommand("select id,name,had,minimom,maximom,karbo,pro,charb,cal,import from foods where name like N'%"+bunifuMetroTextbox2.Text+"%' ", a);
            SqlDataAdapter sd = new SqlDataAdapter(b.CommandText, a);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dataGridView1.DataSource = dt;
            color();
        }
        public  int idd = -1;
        private void dataGridView1_RowHeaderMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            x = e.RowIndex;
            idd = int.Parse(dataGridView1.Rows[x].Cells[0].Value.ToString());
            int id = int.Parse(dataGridView1.Rows[x].Cells[0].Value.ToString());
            SqlConnection a = new SqlConnection(connectify.pcs);
            a.Open();
            SqlCommand b = new SqlCommand("select name,dastebandi,vahed,had,minimom,maximom,karbo,charb,pro,tozihat,cal,import from foods where id='" + id + "'", a);
            SqlDataAdapter sd = new SqlDataAdapter(b.CommandText, a);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            SqlCommand bb = new SqlCommand("select name from vahed where id='" + dt.Rows[0]["vahed"].ToString() + "' ", a);
            SqlDataAdapter sdd = new SqlDataAdapter(bb.CommandText, a);
            DataTable dtt = new DataTable();
            sdd.Fill(dtt);

            bunifuMetroTextbox2.Text = dt.Rows[0]["name"].ToString();
            comboBox2.Text = dt.Rows[0]["dastebandi"].ToString();
            comboBox1.Text = dtt.Rows[0]["name"].ToString();
            bunifuMetroTextbox1.Text = dt.Rows[0]["had"].ToString();
            bunifuMetroTextbox3.Text = dt.Rows[0]["minimom"].ToString();
            bunifuMetroTextbox4.Text = dt.Rows[0]["maximom"].ToString();
            bunifuMetroTextbox5.Text = dt.Rows[0]["karbo"].ToString();
            bunifuMetroTextbox6.Text = dt.Rows[0]["charb"].ToString();
            bunifuMetroTextbox7.Text = dt.Rows[0]["pro"].ToString();
            bunifuMetroTextbox9.Text = dt.Rows[0]["cal"].ToString();
            bunifuMetroTextbox8.Text = dt.Rows[0]["import"].ToString();

            richTextBox1.Text = dt.Rows[0]["tozihat"].ToString();

        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            show();
            clean();
            color();

        }
    }
}
