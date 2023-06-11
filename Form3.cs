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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection a = new SqlConnection(connectify.pcs);
            a.Open();
            SqlDataAdapter sd = new SqlDataAdapter("select * from foods", a);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            a.Close();
            SqlConnection b = new SqlConnection(@"Data Source=.;Initial Catalog=D:\PROJECT\DOPAMIN\DOPAMINETEAM\MOBILECENTERABADAN\BIN\RELEASE\DOPAMINE14.MDF;Integrated Security=True");
            b.Open();
           
            for (int i=0;i<dt.Rows.Count;i++)
            {
                int cal = 0;
                if (dt.Rows[i]["cal"].ToString()!="")
                     cal = int.Parse(dt.Rows[i]["cal"].ToString());
                SqlCommand bb = new SqlCommand("insert into foods (name,dastebandi,vahed,had,minimom,maximom,karbo,pro,charb,tozihat,cal,import) values('" + dt.Rows[i]["name"].ToString() + "','" + dt.Rows[i]["dastebandi"].ToString() + "','" + int.Parse(dt.Rows[i]["vahed"].ToString()) + "','" + dt.Rows[i]["had"].ToString() + "','" + dt.Rows[i]["minimom"].ToString() + "','" + dt.Rows[i]["maximom"].ToString() + "','" + dt.Rows[i]["karbo"].ToString() + "','" + dt.Rows[i]["pro"].ToString() + "','" + dt.Rows[i]["charb"].ToString() + "','" + dt.Rows[i]["tozihat"].ToString() + "','" + cal.ToString() + "','" + dt.Rows[i]["import"].ToString() + "')", b);
                bb.ExecuteNonQuery();
            }

        }
    }
}
