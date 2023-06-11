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
    public partial class barname2 : Form
    {
        bool jobrani;
        public bool searchforfood(int id, int k)
        {
            bool t = false;
            if(k==1)
            {
            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                if (int.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString()) == id)
                    return true;
            return t;
            }
            if(k==2)
            {
                for (int i = 0; i < dataGridView3.RowCount - 1; i++)
                    if (int.Parse(dataGridView3.Rows[i].Cells[0].Value.ToString()) == id)
                        return true;
                return t;
            }
            if (k == 3)
            {
                for (int i = 0; i < dataGridView2.RowCount - 1; i++)
                    if (int.Parse(dataGridView2.Rows[i].Cells[0].Value.ToString()) == id)
                        return true;
                return t;
            }
            return false;
        }
        public void mainb()
        {
            text7();
            text3();
            if ((bunifuMetroTextbox3.Text == "") || (bunifuMetroTextbox6.Text == "") || (bunifuMetroTextbox7.Text == "") || (comboBox1.Text == ""))
            {
                MessageBox.Show("لطفا تمام اطلاعات را وارد کنید");
            }
            else if ((int.Parse(bunifuMetroTextbox6.Text)) < (int.Parse(bunifuMetroTextbox7.Text)))
            {
                MessageBox.Show("مقدار انتخابی بیش از حد مجاز");

            }
            else
            {
                int type = 1;
                if (checkBox2.Checked == true)
                    type = 3;
                if (checkBox3.Checked == true)
                    type = 2;
                int cal = int.Parse(bunifuMetroTextbox7.Text);
                string name = comboBox1.Text;
                int tedad = int.Parse(bunifuMetroTextbox3.Text);
                int[] foods = new int[tedad];
                SqlConnection a = new SqlConnection(connectify.pcs);
                a.Open();
                SqlCommand b;
                SqlDataAdapter sd;
                DataTable dt;
                Double min = -1;

                if (name == "شام")
                {
                    sd = new SqlDataAdapter("select id,karbo,convert(int,pro) as pro,(cal/(CONVERT(int,pro)+1)) as maxim ,charb,cal,maximom,minimom from foods where type='" + type.ToString()+"' and (dastebandi!='صبحانه' and dastebandi!='میان وعده'  and dastebandi!='ساعت ده صبح' and dastebandi!='ساعت پنج عصر') and  import=5 order by maxim    ", a);
                    dt = new DataTable();
                    sd.Fill(dt);
                    int[] tfoods = new int[dt.Rows.Count];

                    int kk = 0;
                    int call = -1;
                    int max = -1;
                    int h = 0;
                    for (int k = 0; k < dt.Rows.Count && h<tedad; k++)
                    {
                        if ((dt.Rows[k]["cal"].ToString() != "") && (dt.Rows[k]["cal"].ToString() != "0"))
                        {
                            call = int.Parse(dt.Rows[k]["cal"].ToString());
                                                        max = int.Parse(dt.Rows[k]["maximom"].ToString()); min=.5; min=.5;


                        }
                        else
                        {
                            int iddd = int.Parse(dt.Rows[k]["id"].ToString());
                            int karbo = int.Parse(dt.Rows[k]["karbo"].ToString());
                            int charb = int.Parse(dt.Rows[k]["charb"].ToString());
                            int pro = int.Parse(dt.Rows[k]["pro"].ToString());
                            max = int.Parse(dt.Rows[k]["maximom"].ToString()); min=.5;

                            call = pro * 4 + karbo * 4 + charb * 9;
                        }
                        if ((call*min <= cal * 1.2) && (call * max >= cal * .8))
                        {
                            foods[h] = int.Parse(dt.Rows[k]["id"].ToString());
                            h++;
                        }
                    }
                    //Random rnd = new Random();
                    //for (int k = 0,l=0; (k < h) && (tedad > 0) &&(l<100);l++)
                    //{
                       
                    //    int rand = rnd.Next(h);
                    //    if ((tfoods[rand] != -1) &&(searchforfood(tfoods[rand],type)))
                    //    {
                    //        foods[kk] = tfoods[rand];
                    //        kk++;
                    //        tfoods[rand] = -1;
                    //        tedad--;
                    //        k++;
                    //    }
                    //}
                    h = 0;
                    sd = new SqlDataAdapter("select id,karbo,convert(int,pro) as pro,(cal/(CONVERT(int,pro)+1)) as maxim ,charb,cal,maximom,minimom from foods where type='" + type.ToString() + "' and (dastebandi!='صبحانه' and dastebandi!='میان وعده' and dastebandi!='ناهار' and dastebandi!='ساعت ده صبح' and dastebandi!='ساعت پنج عصر') and import<5 order by maxim     ", a);
                    dt = new DataTable();
                    sd.Fill(dt);
                    tfoods = new int[dt.Rows.Count];

                    for (int k = 0; k < dt.Rows.Count && h<tedad; k++)
                    {
                        if ((dt.Rows[k]["cal"].ToString() != "") && (dt.Rows[k]["cal"].ToString() != "0"))
                        {
                            call = int.Parse(dt.Rows[k]["cal"].ToString());
                                                        max = int.Parse(dt.Rows[k]["maximom"].ToString()); min=.5;

                        }
                        else
                        {
                            int iddd = int.Parse(dt.Rows[k]["id"].ToString());
                            int karbo = int.Parse(dt.Rows[k]["karbo"].ToString());
                            int charb = int.Parse(dt.Rows[k]["charb"].ToString());
                            int pro = int.Parse(dt.Rows[k]["pro"].ToString());
                            call = pro * 4 + karbo * 4 + charb * 9;
                                                        max = int.Parse(dt.Rows[k]["maximom"].ToString()); min=.5;

                        }
                        if ((call*min <= cal * 1.1) && (call * max >= cal * .9))
                        {
                            foods[h] = int.Parse(dt.Rows[k]["id"].ToString());
                            h++;
                        }
                    }
                    //rnd = new Random();
                    //for (int k = 0,l=0; (k < h) && (tedad > 0) &&(l<100);l++)
                    //{

                    //    int rand = rnd.Next(h);
                    //      if ((tfoods[rand] != -1) &&(searchforfood(tfoods[rand],type)))
                    //    {
                    //        foods[kk] = tfoods[rand];
                    //        kk++;
                    //        tfoods[rand] = -1;
                    //        tedad--;
                    //        k++;
                    //    }
                    //}
                }
                else if (name == "صبحانه")
                {
                    sd = new SqlDataAdapter("select id,karbo,convert(int,pro) as pro,(cal/(CONVERT(int,pro)+1)) as maxim ,charb,cal,maximom,minimom from foods where type='" + type.ToString() + "' and dastebandi='صبحانه'  and  import=5 order by maxim   ", a);
                    dt = new DataTable();
                    sd.Fill(dt);
                    int[] tfoods = new int[dt.Rows.Count];

                    int kk = 0;
                    int call = -1;
                    int max = -1;
                    int h = 0;

                    for (int k = 0; k < dt.Rows.Count && h<tedad; k++)
                    {
                        if ((dt.Rows[k]["cal"].ToString() != "") && (dt.Rows[k]["cal"].ToString() != "0"))
                        {
                            call = int.Parse(dt.Rows[k]["cal"].ToString());
                                                        max = int.Parse(dt.Rows[k]["maximom"].ToString()); min=.5;

                        }
                        else
                        {
                            int iddd = int.Parse(dt.Rows[k]["id"].ToString());
                            int karbo = int.Parse(dt.Rows[k]["karbo"].ToString());
                            int charb = int.Parse(dt.Rows[k]["charb"].ToString());
                            int pro = int.Parse(dt.Rows[k]["pro"].ToString());
                                                        max = int.Parse(dt.Rows[k]["maximom"].ToString()); min=.5;

                            call = pro * 4 + karbo * 4 + charb * 9;
                        }
                        if ((call*min <= cal * 1.1) && (call * max >= cal * .9))
                        {
                            foods[h] = int.Parse(dt.Rows[k]["id"].ToString());
                            h++;
                        }
                    }
                    //Random rnd = new Random();
                    //for (int k = 0,l=0; (k < h) && (tedad > 0) &&(l<100);l++)
                    //{

                    //    int rand = rnd.Next(h);
                    //      if ((tfoods[rand] != -1) &&(searchforfood(tfoods[rand],type)))
                    //    {
                    //        foods[kk] = tfoods[rand];
                    //        kk++;
                    //        tfoods[rand] = -1;
                    //        tedad--;
                    //        k++;
                    //    }
                    //}
                    h = 0;
                    sd = new SqlDataAdapter("select id,karbo,convert(int,pro) as pro,(cal/(CONVERT(int,pro)+1)) as maxim ,charb,cal,maximom,minimom from foods where type='" + type.ToString() + "' and  dastebandi='صبحانه'  and import<5 order by maxim     ", a);
                    dt = new DataTable();
                    sd.Fill(dt);
                    tfoods = new int[dt.Rows.Count];

                    for (int k = 0; k < dt.Rows.Count && h<tedad; k++)
                    {
                        if ((dt.Rows[k]["cal"].ToString() != "") && (dt.Rows[k]["cal"].ToString() != "0"))
                        {
                            call = int.Parse(dt.Rows[k]["cal"].ToString());
                                                        max = int.Parse(dt.Rows[k]["maximom"].ToString()); min=.5;

                        }
                        else
                        {
                            int iddd = int.Parse(dt.Rows[k]["id"].ToString());
                            int karbo = int.Parse(dt.Rows[k]["karbo"].ToString());
                            int charb = int.Parse(dt.Rows[k]["charb"].ToString());
                            int pro = int.Parse(dt.Rows[k]["pro"].ToString());
                            call = pro * 4 + karbo * 4 + charb * 9;
                                                        max = int.Parse(dt.Rows[k]["maximom"].ToString()); min=.5;

                        }
                        if ((call*min <= cal * 1.1) && (call * max >= cal * .9))
                        {
                            foods[h] = int.Parse(dt.Rows[k]["id"].ToString());
                            h++;
                        }
                    }
                    //rnd = new Random();
                    //for (int k = 0,l=0; (k < h) && (tedad > 0) &&(l<100);l++)
                    //{

                    //    int rand = rnd.Next(h);
                    //      if ((tfoods[rand] != -1) &&(searchforfood(tfoods[rand],type)))
                    //    {
                    //        foods[kk] = tfoods[rand];
                    //        kk++;
                    //        tfoods[rand] = -1;
                    //        tedad--;
                    //        k++;
                    //    }
                    //}
                }
                else if (name == "ناهار")
                {
                    sd = new SqlDataAdapter("select id,karbo,convert(int,pro) as pro,(cal/(CONVERT(int,pro)+1)) as maxim ,charb,cal,maximom,minimom from foods where type='" + type.ToString() + "' and (dastebandi!='صبحانه' and dastebandi!='میان وعده'  and dastebandi!='ساعت ده صبح' and dastebandi!='ساعت پنج عصر') and  import=5 order by maxim   ", a);
                    dt = new DataTable();
                    sd.Fill(dt);
                    int[] tfoods = new int[dt.Rows.Count];

                    int kk = 0;
                    int call = -1;
                    int max = -1;
                    int h = 0;
                    for (int k = 0; k < dt.Rows.Count && h<tedad; k++)
                    {
                       
                        if ((dt.Rows[k]["cal"].ToString() != "") && (dt.Rows[k]["cal"].ToString() != "0"))
                        {
                            call = int.Parse(dt.Rows[k]["cal"].ToString());
                           
                                                        max = int.Parse(dt.Rows[k]["maximom"].ToString()); min=.5;

                        }
                        else
                        {
                            int iddd = int.Parse(dt.Rows[k]["id"].ToString());
                            int karbo = int.Parse(dt.Rows[k]["karbo"].ToString());
                            int charb = int.Parse(dt.Rows[k]["charb"].ToString());
                            int pro = int.Parse(dt.Rows[k]["pro"].ToString());
                                                        max = int.Parse(dt.Rows[k]["maximom"].ToString()); min=.5;

                            call = pro * 4 + karbo * 4 + charb * 9;
                        }
                        if ((call*min <= cal * 1.1) && (call * max >= cal * .9))
                        {
                            foods[h] = int.Parse(dt.Rows[k]["id"].ToString());
                            h++;
                        }
                    }
                    //Random rnd = new Random();
                    //for (int k = 0,l=0; (k < h) && (tedad > 0) &&(l<100);l++)
                    //{

                    //    int rand = rnd.Next(h);
                    //      if ((tfoods[rand] != -1) &&(searchforfood(tfoods[rand],type)))
                    //    {
                    //        foods[kk] = tfoods[rand];
                    //        kk++;
                    //        tfoods[rand] = -1;
                    //        tedad--;
                    //        k++;
                    //    }
                    //}
                     
                    sd = new SqlDataAdapter("select id,karbo,convert(int,pro) as pro,(cal/(CONVERT(int,pro)+1)) as maxim ,charb,cal,maximom,minimom from foods where type='" + type.ToString() + "' and (dastebandi!='صبحانه' and dastebandi!='میان وعده' and dastebandi!='شام' and dastebandi!='ساعت ده صبح' and dastebandi!='ساعت پنج عصر') and import<5 order by maxim     ", a);
                    dt = new DataTable();
                    sd.Fill(dt);
                    tfoods = new int[dt.Rows.Count];

                    for (int k = 0; k < dt.Rows.Count && h<tedad; k++)
                    {
                        if ((dt.Rows[k]["cal"].ToString() != "") && (dt.Rows[k]["cal"].ToString() != "0"))
                        {
                            call = int.Parse(dt.Rows[k]["cal"].ToString());
                                                        max = int.Parse(dt.Rows[k]["maximom"].ToString()); min=.5;

                        }
                        else
                        {
                            int iddd = int.Parse(dt.Rows[k]["id"].ToString());
                            int karbo = int.Parse(dt.Rows[k]["karbo"].ToString());
                            int charb = int.Parse(dt.Rows[k]["charb"].ToString());
                            int pro = int.Parse(dt.Rows[k]["pro"].ToString());
                            call = pro * 4 + karbo * 4 + charb * 9;
                                                        max = int.Parse(dt.Rows[k]["maximom"].ToString()); min=.5;

                        }
                        if ((call*min <= cal * 1.1) && (call * max >= cal * .9))
                        {
                            foods[h] = int.Parse(dt.Rows[k]["id"].ToString());
                            h++;
                        }
                    }
                    //rnd = new Random();
                    //for (int k = 0,l=0; (k < h) && (tedad > 0) &&(l<100);l++)
                    //{

                    //    int rand = rnd.Next(h);
                    //      if ((tfoods[rand] != -1) &&(searchforfood(tfoods[rand],type)))
                    //    {
                    //        foods[kk] = tfoods[rand];
                    //        kk++;
                    //        tfoods[rand] = -1;
                    //        tedad--;
                    //        k++;
                    //    }
                    //}
                }//dastebandi='ميان وعده'


                else if (name == "ساعت ده صبح")
                {
                    sd = new SqlDataAdapter("select id,karbo,convert(int,pro) as pro,(cal/(CONVERT(int,pro)+1)) as maxim ,charb,cal,maximom,minimom from foods where type='" + type.ToString() + "' and (dastebandi='ساعت ده صبح' or dastebandi='میان وعده' ) and  import=5 order by maxim    ", a);
                    dt = new DataTable();
                    sd.Fill(dt);
                    int[] tfoods = new int[dt.Rows.Count];

                    int kk = 0;
                    int call = -1;
                    int max = -1;
                    int h = 0;
                    for (int k = 0; k < dt.Rows.Count && h<tedad; k++)
                    {

                        if ((dt.Rows[k]["cal"].ToString() != "") && (dt.Rows[k]["cal"].ToString() != "0"))
                        {
                            call = int.Parse(dt.Rows[k]["cal"].ToString());

                                                        max = int.Parse(dt.Rows[k]["maximom"].ToString()); min=.5;

                        }
                        else
                        {
                            int iddd = int.Parse(dt.Rows[k]["id"].ToString());
                            int karbo = int.Parse(dt.Rows[k]["karbo"].ToString());
                            int charb = int.Parse(dt.Rows[k]["charb"].ToString());
                            int pro = int.Parse(dt.Rows[k]["pro"].ToString());
                                                        max = int.Parse(dt.Rows[k]["maximom"].ToString()); min=.5;

                            call = pro * 4 + karbo * 4 + charb * 9;
                        }
                        if ((call*min <= cal * 1.1) && (call * max >= cal * .9))
                        {
                            foods[h] = int.Parse(dt.Rows[k]["id"].ToString());
                            h++;
                        }
                    }
                //    Random rnd = new Random();
                    //for (int k = 0,l=0; (k < h) && (tedad > 0) &&(l<100);l++)
                    //{

                    //    int rand = rnd.Next(h);
                    //      if ((tfoods[rand] != -1) &&(searchforfood(tfoods[rand],type)))
                    //    {
                    //        foods[kk] = tfoods[rand];
                    //        kk++;
                    //        tfoods[rand] = -1;
                    //        tedad--;
                    //        k++;
                    //    }
                    //}
                    sd = new SqlDataAdapter("select id,karbo,convert(int,pro) as pro,(cal/(CONVERT(int,pro)+1)) as maxim ,charb,cal,maximom,minimom from foods where type='" + type.ToString() + "' and (dastebandi='ساعت ده صبح' or dastebandi='میان وعده') and import<5 order by maxim     ", a);
                    dt = new DataTable();
                    sd.Fill(dt);
                    tfoods = new int[dt.Rows.Count];

                    for (int k = 0; k < dt.Rows.Count&& h<tedad; k++)
                    {
                        if ((dt.Rows[k]["cal"].ToString() != "") && (dt.Rows[k]["cal"].ToString() != "0"))
                        {
                            call = int.Parse(dt.Rows[k]["cal"].ToString());
                                                        max = int.Parse(dt.Rows[k]["maximom"].ToString()); min=.5;

                        }
                        else
                        {
                            int iddd = int.Parse(dt.Rows[k]["id"].ToString());
                            int karbo = int.Parse(dt.Rows[k]["karbo"].ToString());
                            int charb = int.Parse(dt.Rows[k]["charb"].ToString());
                            int pro = int.Parse(dt.Rows[k]["pro"].ToString());
                            call = pro * 4 + karbo * 4 + charb * 9;
                                                        max = int.Parse(dt.Rows[k]["maximom"].ToString()); min=.5;

                        }
                        if ((call*min <= cal * 1.1) && (call * max >= cal * .9))
                        {
                            foods[h] = int.Parse(dt.Rows[k]["id"].ToString());
                            h++;
                        }
                    }
                    //rnd = new Random();
                    //for (int k = 0,l=0; (k < h) && (tedad > 0) &&(l<100);l++)
                    //{

                    //    int rand = rnd.Next(h);
                    //      if ((tfoods[rand] != -1) &&(searchforfood(tfoods[rand],type)))
                    //    {
                    //        foods[kk] = tfoods[rand];
                    //        kk++;
                    //        tfoods[rand] = -1;
                    //        tedad--;
                    //        k++;
                    //    }
                    //}
                }//dastebandi='ميان وعده'


                else if (name == "ساعت پنج عصر")
                {
                    sd = new SqlDataAdapter("select id,karbo,convert(int,pro) as pro,(cal/(CONVERT(int,pro)+1)) as maxim ,charb,cal,maximom,minimom from foods where type='" + type.ToString() + "' and (dastebandi='ساعت پنج عصر' or dastebandi='میان وعده') and  import=5 order by maxim     ", a);
                    dt = new DataTable();
                    sd.Fill(dt);
                    int[] tfoods = new int[dt.Rows.Count];

                    int kk = 0;
                    int call = -1;
                    int max = -1;
                    int h = 0;
                    for (int k = 0; k < dt.Rows.Count && h<tedad; k++)
                    {

                        if ((dt.Rows[k]["cal"].ToString() != "") && (dt.Rows[k]["cal"].ToString() != "0"))
                        {
                            call = int.Parse(dt.Rows[k]["cal"].ToString());

                                                        max = int.Parse(dt.Rows[k]["maximom"].ToString()); min=.5;

                        }
                        else
                        {
                            int iddd = int.Parse(dt.Rows[k]["id"].ToString());
                            int karbo = int.Parse(dt.Rows[k]["karbo"].ToString());
                            int charb = int.Parse(dt.Rows[k]["charb"].ToString());
                            int pro = int.Parse(dt.Rows[k]["pro"].ToString());
                                                        max = int.Parse(dt.Rows[k]["maximom"].ToString()); min=.5;

                            call = pro * 4 + karbo * 4 + charb * 9;
                        }
                        if ((call*min <= cal * 1.1) && (call * max >= cal * .9))
                        {
                            foods[h] = int.Parse(dt.Rows[k]["id"].ToString());
                            h++;
                        }
                    }
                    //Random rnd = new Random();
                    //for (int k = 0,l=0; (k < h) && (tedad > 0) &&(l<100);l++)
                    //{

                    //    int rand = rnd.Next(h);
                    //      if ((tfoods[rand] != -1) &&(searchforfood(tfoods[rand],type)))
                    //    {
                    //        foods[kk] = tfoods[rand];
                    //        kk++;
                    //        tfoods[rand] = -1;
                    //        tedad--;
                    //        k++;
                    //    }
                    //}
                    h = 0;
                    sd = new SqlDataAdapter("select id,karbo,convert(int,pro) as pro,(cal/(CONVERT(int,pro)+1)) as maxim ,charb,cal,maximom,minimom from foods where type='" + type.ToString() + "' and (dastebandi='ساعت پنج عصر' or dastebandi='میان وعده') and import<5 order by maxim     ", a);
                    dt = new DataTable();
                    sd.Fill(dt);
                    tfoods = new int[dt.Rows.Count];

                    for (int k = 0; k < dt.Rows.Count && h<tedad; k++)
                    {
                        if ((dt.Rows[k]["cal"].ToString() != "") && (dt.Rows[k]["cal"].ToString() != "0"))
                        {
                            call = int.Parse(dt.Rows[k]["cal"].ToString());
                                                        max = int.Parse(dt.Rows[k]["maximom"].ToString()); min=.5;

                        }
                        else
                        {
                            int iddd = int.Parse(dt.Rows[k]["id"].ToString());
                            int karbo = int.Parse(dt.Rows[k]["karbo"].ToString());
                            int charb = int.Parse(dt.Rows[k]["charb"].ToString());
                            int pro = int.Parse(dt.Rows[k]["pro"].ToString());
                            call = pro * 4 + karbo * 4 + charb * 9;
                                                        max = int.Parse(dt.Rows[k]["maximom"].ToString()); min=.5;

                        }
                        if ((call*min <= cal * 1.1) && (call * max >= cal * .9))
                        {
                            tfoods[h] = int.Parse(dt.Rows[k]["id"].ToString());
                            h++;
                        }
                    }
                    //rnd = new Random();
                    //for (int k = 0,l=0; (k < h) && (tedad > 0) &&(l<100);l++)
                    //{

                    //    int rand = rnd.Next(h);
                    //      if ((tfoods[rand] != -1) &&(searchforfood(tfoods[rand],type)))
                    //    {
                    //        foods[kk] = tfoods[rand];
                    //        kk++;
                    //        tfoods[rand] = -1;
                    //        tedad--;
                    //        k++;
                    //    }
                    //}
                }//dastebandi='ميان وعده'


                else
                {
                    sd = new SqlDataAdapter("select id,karbo,convert(int,pro) as pro,(cal/(CONVERT(int,pro)+1)) as maxim ,charb,cal,maximom,minimom from foods where type='" + type.ToString() + "' and dastebandi='ميان وعده' and  import=5 order by maxim   ", a);
                    dt = new DataTable();
                    sd.Fill(dt);
                    int[] tfoods = new int[dt.Rows.Count];

                    int kk = 0;
                    int call = -1;
                    int max = -1;
                    int h = 0;
                    for (int k = 0; k < dt.Rows.Count && h<tedad; k++)
                    {
                        if ((dt.Rows[k]["cal"].ToString() != "") && (dt.Rows[k]["cal"].ToString() != "0"))
                        {
                            call = int.Parse(dt.Rows[k]["cal"].ToString());
                                                        max = int.Parse(dt.Rows[k]["maximom"].ToString()); min=.5;
                            int iddd = int.Parse(dt.Rows[k]["id"].ToString());

                        }
                        else
                        {
                            int iddd = int.Parse(dt.Rows[k]["id"].ToString());
                            int karbo = int.Parse(dt.Rows[k]["karbo"].ToString());
                            int charb = int.Parse(dt.Rows[k]["charb"].ToString());
                            int pro = int.Parse(dt.Rows[k]["pro"].ToString());
                                                        max = int.Parse(dt.Rows[k]["maximom"].ToString()); min=.5;

                            call = pro * 4 + karbo * 4 + charb * 9;
                        }
                        if ((call*min <= cal * 1.1) && (call * max >= cal * .9))
                        {
                            foods[h] = int.Parse(dt.Rows[k]["id"].ToString());
                            h++;
                        }
                    }
                    //Random rnd = new Random();
                    //for (int k = 0,l=0; (k < h) && (tedad > 0) &&(l<100);l++)
                    //{

                    //    int rand = rnd.Next(h);
                    //      if ((tfoods[rand] != -1) &&(searchforfood(tfoods[rand],type)))
                    //    {
                    //        foods[kk] = tfoods[rand];
                    //        kk++;
                    //        tfoods[rand] = -1;
                    //        tedad--;
                    //        k++;
                    //    }
                    //}
                    h = 0;
                    sd = new SqlDataAdapter("select id,karbo,convert(int,pro) as pro,(cal/(CONVERT(int,pro)+1)) as maxim ,charb,cal,maximom,minimom,minimom from foods where type='" + type.ToString() + "' and dastebandi='ميان وعده' and import<5 order by maxim     ", a);
                    dt = new DataTable();
                    sd.Fill(dt);
                    tfoods = new int[dt.Rows.Count];

                    for (int k = 0; k < dt.Rows.Count && h<tedad; k++)
                    {
                        if ((dt.Rows[k]["cal"].ToString() != "") && (dt.Rows[k]["cal"].ToString() != "0"))
                        {
                            call = int.Parse(dt.Rows[k]["cal"].ToString());
                        }
                        else
                        {
                            int iddd = int.Parse(dt.Rows[k]["id"].ToString());
                            int karbo = int.Parse(dt.Rows[k]["karbo"].ToString());
                            int charb = int.Parse(dt.Rows[k]["charb"].ToString());
                            int pro = int.Parse(dt.Rows[k]["pro"].ToString());
                            call = pro * 4 + karbo * 4 + charb * 9;
                                                        max = int.Parse(dt.Rows[k]["maximom"].ToString()); min=.5;

                        }
                        if ((call*min <= cal * 1.1) && (call * max >= cal * .9))
                        {
                            foods[h] = int.Parse(dt.Rows[k]["id"].ToString());
                            h++;
                        }
                    }
                    //rnd = new Random();
                    //for (int k = 0,l=0; (k < h) && (tedad > 0) &&(l<100);l++)
                    //{

                    //    int rand = rnd.Next(h);
                    //      if ((tfoods[rand] != -1) &&(searchforfood(tfoods[rand],type)))
                    //    {
                    //        foods[kk] = tfoods[rand];
                    //        kk++;
                    //        tfoods[rand] = -1;
                    //        tedad--;
                    //        k++;
                    //    }
                    //}
                }
                for (int k = 0; k < int.Parse(bunifuMetroTextbox3.Text); k++)
                {
                    int call = 0;
                    if (foods[k] != 0)
                    {
                        sd = new SqlDataAdapter("select id,name,cal,pro,charb,karbo from foods where type='" + type.ToString() + "' and id='" + foods[k] + "'", a);
                        dt = new DataTable();
                        sd.Fill(dt);
                        int iddd = int.Parse(dt.Rows[0]["id"].ToString());
                        if ((dt.Rows[0]["cal"].ToString() != "") && (dt.Rows[0]["cal"].ToString() != "0"))
                        {
                            call = int.Parse(dt.Rows[0]["cal"].ToString());
                        }
                        else
                        {
                            int karbo = int.Parse(dt.Rows[0]["karbo"].ToString());
                            int charb = int.Parse(dt.Rows[0]["charb"].ToString());
                            int pro = int.Parse(dt.Rows[0]["pro"].ToString());
                            call = pro * 4 + karbo * 4 + charb * 9;
                        }
                        dataGridView6.Rows.Add("", "", "", "");

                        dataGridView6.Rows[k].Cells[0].Value = iddd.ToString();
                        dataGridView6.Rows[k].Cells[1].Value = dt.Rows[0]["name"].ToString();
                        dataGridView6.Rows[k].Cells[2].Value = call.ToString();
                        i++;
                        color6();
                    }
                }




            }
        }
        public void color1()
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
        public void color2()
        {
            foreach (DataGridViewRow row in dataGridView2.Rows)
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
        public void color3()
        {
            foreach (DataGridViewRow row in dataGridView3.Rows)
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
        
        public void color5()
        {
            foreach (DataGridViewRow row in dataGridView5.Rows)
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
        public void color6()
        {
            foreach (DataGridViewRow row in dataGridView6.Rows)
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
        //public void color7()
        //{
        //    foreach (DataGridViewRow row in dataGridView7.Rows)
        //    {
        //        if (row.Index % 2 == 0)
        //        {

        //            row.DefaultCellStyle.BackColor = Color.Lavender;
        //        }
        //        else
        //        {
        //            row.DefaultCellStyle.BackColor = Color.LavenderBlush;

        //        }
        //    }
        //}
        int public_cal = 0;

        public void show1()
        {
            
            SqlConnection a = new SqlConnection(connectify.pcs);
            a.Open();
            if(true)
            {
                string datebandi =comboBox1.Text;
                if ((comboBox1.Text == "شام") )
                {
                    datebandi = "غذاي اصلي";
                }
                if ((comboBox1.Text == "ناهار"))
                {
                    datebandi = "غذاي اصلي";

                }
                if ((comboBox1.Text == "ساعت ده صبح"))
                {
                    datebandi = "ساعت";

                }
                if ((comboBox1.Text == "ساعت پنج عصر"))
                {
                    datebandi = "ساعت";

                }
                if ((comboBox1.Text == "ساعت هفت عصر"))
                {
                    datebandi = "ساعت";

                }
                if ((comboBox1.Text == "قبل خواب"))
                {
                    datebandi = "ساعت";

                }
                SqlCommand b = new SqlCommand("select id,name,cal as maxim from foods where type='1' and name like N'%" + bunifuMetroTextbox2.Text + "%' and id like N'%" + bunifuMetroTextbox1.Text + "%'  and   ((dastebandi like N'%" + datebandi+ "%' and dastebandi != 'همه'  )  ) ", a);
                SqlDataAdapter sd = new SqlDataAdapter(b.CommandText, a);
                DataTable dt = new DataTable();
                sd.Fill(dt);
                dataGridView1.DataSource = dt;
              
            }
            else
            {
                SqlCommand b = new SqlCommand("select id,name,cal as maxim from foods where type='1' and name like N'%" + bunifuMetroTextbox2.Text+"%' and id like N'%" + bunifuMetroTextbox1.Text + "%' and   (dastebandi like N'%"+comboBox1.Text + "%' and dastebandi != 'همه' )   ", a);
                SqlDataAdapter sd = new SqlDataAdapter(b.CommandText, a);
                DataTable dt = new DataTable();
                sd.Fill(dt);
                dataGridView1.DataSource = dt;

              
            }
        }
        public void show2()
        {
            SqlConnection a = new SqlConnection(connectify.pcs);
            a.Open();
            if (true)
            {
                string datebandi = comboBox1.Text;
                if ((comboBox1.Text == "شام"))
                {
                    datebandi = "غذاي اصلي";
                }
                if ((comboBox1.Text == "ناهار"))
                {
                    datebandi = "غذاي اصلي";

                }
                if ((comboBox1.Text == "ساعت ده صبح"))
                {
                    datebandi = "ساعت";

                }
                if ((comboBox1.Text == "ساعت پنج عصر"))
                {
                    datebandi = "ساعت";

                }
                if ((comboBox1.Text == "قبل خواب"))
                {
                    datebandi = "ساعت";

                }
                if ((comboBox1.Text == "ساعت هفت عصر"))
                {
                    datebandi = "ساعت";

                }
                SqlCommand b = new SqlCommand("select id,name,cal as maxim from foods where type='3' and name like N'%" + bunifuMetroTextbox2.Text + "%' and id like N'%" + bunifuMetroTextbox1.Text + "%'  and   ((dastebandi like N'%" + datebandi + "%' and dastebandi != 'همه'  )  ) ", a);
                SqlDataAdapter sd = new SqlDataAdapter(b.CommandText, a);
                DataTable dt = new DataTable();
                sd.Fill(dt);
                dataGridView2.DataSource = dt;

            }
            else
            {
                SqlCommand b = new SqlCommand("select id,name,cal as maxim from foods where type='3' and name like N'%" + bunifuMetroTextbox2.Text + "%' and id like N'%" + bunifuMetroTextbox1.Text + "%' and   (dastebandi like N'%" + comboBox1.Text + "%' and dastebandi != 'همه' )   ", a);
                SqlDataAdapter sd = new SqlDataAdapter(b.CommandText, a);
                DataTable dt = new DataTable();
                sd.Fill(dt);
                dataGridView2.DataSource = dt;
            }

        }
        public void show3()
        {
            SqlConnection a = new SqlConnection(connectify.pcs);
            a.Open();
            if (true)
            {
                string datebandi = comboBox1.Text;
                if ((comboBox1.Text == "شام"))
                {
                    datebandi = "غذاي اصلي";
                }
                if ((comboBox1.Text == "ناهار"))
                {
                    datebandi = "غذاي اصلي";

                }
                if ((comboBox1.Text == "ساعت ده صبح"))
                {
                    datebandi = "ساعت";

                }
                if ((comboBox1.Text == "ساعت پنج عصر"))
                {
                    datebandi = "ساعت";

                }
                if ((comboBox1.Text == "قبل خواب"))
                {
                    datebandi = "ساعت";

                }
                if ((comboBox1.Text == "ساعت هفت عصر"))
                {
                    datebandi = "ساعت";

                }
                SqlCommand b = new SqlCommand("select id,name,cal as maxim from foods where type='2' and name like N'%" + bunifuMetroTextbox2.Text + "%' and id like N'%" + bunifuMetroTextbox1.Text + "%'  and   ((dastebandi like N'%" + datebandi + "%' and dastebandi != 'همه'  )  ) ", a);
                SqlDataAdapter sd = new SqlDataAdapter(b.CommandText, a);
                DataTable dt = new DataTable();
                sd.Fill(dt);
                dataGridView3.DataSource = dt;

            }
            else
            {
                SqlCommand b = new SqlCommand("select id,name,cal as maxim from foods where type='2' and name like N'%" + bunifuMetroTextbox2.Text + "%' and id like N'%" + bunifuMetroTextbox1.Text + "%' and   (dastebandi like N'%" + comboBox1.Text + "%' and dastebandi != 'همه' )   ", a);
                SqlDataAdapter sd = new SqlDataAdapter(b.CommandText, a);
                DataTable dt = new DataTable();
                sd.Fill(dt);
                dataGridView3.DataSource = dt;
            }
        }
        

        public barname2()
        {
            InitializeComponent();
            counterr = 0;
            show1();
            show2();
            show3();
            comboBox2.Items.Add("صبحانه");
            comboBox2.Items.Add("ناهار");
            comboBox2.Items.Add("شام");
            comboBox2.Items.Add("ميان وعده");
            comboBox2.Items.Add("غذاي اصلي");
            comboBox2.Items.Add("ساعت ده صبح");
            comboBox2.Items.Add("ساعت پنج عصر");
            i = 0;
            bunifuMetroTextbox6.Text = barnamejadid.call.ToString();
            comboBox1.Items.Add("صبحانه");
            comboBox1.Items.Add("ساعت ده صبح");
            comboBox1.Items.Add("ناهار");
            comboBox1.Items.Add("ساعت پنج عصر");
            comboBox1.Items.Add("ساعت هفت عصر");

            comboBox1.Items.Add("شام");
            comboBox1.Items.Add("قبل خواب");
            comboBox1.Items.Add("4میان وعده");
            comboBox1.Items.Add("5میان وعده");
            jobrani = false;
            this.WindowState = FormWindowState.Maximized;

        }



        private void pictureBox1_Click(object sender, EventArgs e)
        {
            barname2 s = new barname2();
            this.Close();
            s.Close();
        }

       

        private void bunifuMetroTextbox2_KeyUp(object sender, KeyEventArgs e)
        {
            show1();
            color1();
            show2();
            color2();
            show3();
            color3();
      
        }

        private void bunifuMetroTextbox1_KeyUp(object sender, KeyEventArgs e)
        {
            show1();
            color1();
            show2();
            color2();
            show3();
            color3();
          
        }

      

        private void comboBox2_Enter(object sender, EventArgs e)
        {
            color1();
            color2(); color3(); 
        }
        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            
            show1();
            color1();
            show2();
            color2();
            show3();
            color3();
      
        }
       public int i;

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(dataGridView6.Rows.Count-1>=int.Parse(bunifuMetroTextbox3.Text))
            {
                MessageBox.Show("تعداد تکمیل است");
            }
            else
            {
                if(dataGridView6.Rows.Count==1)
                {
                    dastebandi_final = comboBox1.Text;
                }
                bool t = false;
                for (int i = 0; i < dataGridView6.Rows.Count - 1; i++)
                {
                    if ((dataGridView6.Rows[i].Cells[0].Value.ToString() == dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString()) && (dataGridView6.Rows[i].Cells[1].Value.ToString() == dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString()))
                    {
                        t = true;
                    }
                }
                if (t == false)
                {

                    dataGridView6.Rows.Add("", "", "");

                    dataGridView6.Rows[i].Cells[0].Value = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                    dataGridView6.Rows[i].Cells[1].Value = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    dataGridView6.Rows[i].Cells[2].Value = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();

                    color6();
                    i++;

                }

            }


        }

        private void dataGridView2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView6.Rows.Count >= int.Parse(bunifuMetroTextbox3.Text)+1)
            {
                MessageBox.Show("تعداد تکمیل است");
            }
            else
            {
                if (dataGridView6.Rows.Count == 1)
                {
                    dastebandi_final = comboBox1.Text;
                }
                bool t = false;
                for (int i = 0; i < dataGridView6.Rows.Count -1; i++)
                {
                    if ((dataGridView6.Rows[i].Cells[0].Value.ToString() == dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString()) && (dataGridView6.Rows[i].Cells[1].Value.ToString() == dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString()))
                    {
                        t = true;
                    }
                }
                if (t == false)
                {

                    dataGridView6.Rows.Add("", "", "");

                    dataGridView6.Rows[i].Cells[0].Value = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
                    dataGridView6.Rows[i].Cells[1].Value = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
                    dataGridView6.Rows[i].Cells[2].Value = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();

                    color6();
                    i++;

                }

            }

        }

        private void dataGridView3_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView6.Rows.Count >= int.Parse(bunifuMetroTextbox3.Text)+1)
            {
                MessageBox.Show("تعداد تکمیل است");
            }
            else
            {
                bool t = false;
                for (int i = 0; i < dataGridView6.Rows.Count - 1; i++)
                {
                    if ((dataGridView6.Rows[i].Cells[0].Value.ToString() == dataGridView3.Rows[e.RowIndex].Cells[0].Value.ToString()) && (dataGridView6.Rows[i].Cells[1].Value.ToString() == dataGridView3.Rows[e.RowIndex].Cells[1].Value.ToString()))
                    {
                        t = true;
                    }
                }
                if (t == false)
                {

                    dataGridView6.Rows.Add("", "", "");

                    dataGridView6.Rows[i].Cells[0].Value = dataGridView3.Rows[e.RowIndex].Cells[0].Value.ToString();
                    dataGridView6.Rows[i].Cells[1].Value = dataGridView3.Rows[e.RowIndex].Cells[1].Value.ToString();
                    dataGridView6.Rows[i].Cells[2].Value = dataGridView3.Rows[e.RowIndex].Cells[2].Value.ToString();

                    color6();
                    i++;

                }

            }

        }



        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            if (deletee == -1)
                MessageBox.Show("لطفا یک سطر انتخاب کنید");
            else
            {

                        dataGridView6.Rows.RemoveAt(deletee);
                        i--;
                        deletee--;
              
            }
           
         
           

        }



        private void bunifuButton6_Click(object sender, EventArgs e)
        {
            if ( (bunifuMetroTextbox6.Text == "") || (bunifuMetroTextbox7.Text == "") || (comboBox1.Text == ""))
            {
                MessageBox.Show("لطفا تمام اطلاعات را وارد کنید");
            }
            else if ((int.Parse(bunifuMetroTextbox6.Text)) < (int.Parse(bunifuMetroTextbox7.Text)))
            {
                MessageBox.Show("مقدار انتخابی بیش از حد مجاز");

            }
            else
            {
                int cal = int.Parse(bunifuMetroTextbox7.Text);
                int j = 0;
                int jj = 0;

                for (int k = 0; k < dataGridView6.Rows.Count - 1; k++)
                {
                    int id = int.Parse(dataGridView6.Rows[k].Cells[0].Value.ToString());
                    SqlConnection a = new SqlConnection(connectify.pcs);
                    a.Open();
                    SqlDataAdapter sd = new SqlDataAdapter("select * from foods where id='" + id + "'", a);
                    DataTable dt = new DataTable();
                    sd.Fill(dt);
                    int call = 0;
                    if ((dt.Rows[0]["cal"].ToString() != "") && (dt.Rows[0]["cal"].ToString() != "0"))
                    {
                        call = int.Parse(dt.Rows[0]["cal"].ToString());
                    }
                    else
                    {
                        int karbo = int.Parse(dt.Rows[0]["karbo"].ToString());
                        int charb = int.Parse(dt.Rows[0]["charb"].ToString());
                        int pro = int.Parse(dt.Rows[0]["pro"].ToString());
                        call = pro * 4 + karbo * 4 + charb * 9;
                    }
                    float min = float.Parse(dt.Rows[0]["minimom"].ToString());
                    float max = float.Parse(dt.Rows[0]["maximom"].ToString());
                    string ttttt = dt.Rows[0]["had"].ToString()+"f";
              
                   float had =0;
                    if (ttttt == ".5f")
                    {
                        had = .5f;

                    }
                    else if(ttttt == ".0f")
                    {
                        
                        had = float.Parse(ttttt);

                    }
                    bool t = false;

                    while (min <= max)
                    {
                        if ((cal * .9 <= call * min) && (call * min <= cal * 1.1))
                        {
                            dataGridView5.Rows.Add("", "", "", "");
                            dataGridView5.Rows[jj].Cells[0].Value = dt.Rows[0]["id"].ToString();

                            dataGridView5.Rows[jj].Cells[1].Value = dt.Rows[0]["name"].ToString();
                            dataGridView5.Rows[jj].Cells[2].Value = min.ToString();
                            SqlDataAdapter sdd = new SqlDataAdapter("select name from vahed where id='" + dt.Rows[0]["vahed"].ToString() + "'", a);
                            DataTable dtt = new DataTable();
                            sdd.Fill(dtt);
                            dataGridView5.Rows[jj].Cells[3].Value = dtt.Rows[0]["name"].ToString();
                            jj++;
                            t = true;
                            color5();
                            break;
                        }
                        else if (had == 0)
                            break;
                        else if((call*(min+had))>cal*1.2)
                        {
                            break;
                        }
                        else
                        {
                            min = min + had;
                        }
                    }
                    if (t == false)
                    {
                        dataGridView5.Rows.Add("", "", "", "");
                        dataGridView5.Rows[jj].Cells[0].Value = dt.Rows[0]["id"].ToString();

                        dataGridView5.Rows[jj].Cells[1].Value = dt.Rows[0]["name"].ToString();
                        dataGridView5.Rows[jj].Cells[2].Value = min.ToString();
                        SqlDataAdapter sdd = new SqlDataAdapter("select name from vahed where id='" + dt.Rows[0]["vahed"].ToString() + "'", a);
                        DataTable dtt = new DataTable();
                        sdd.Fill(dtt);
                        dataGridView5.Rows[jj].Cells[3].Value = dtt.Rows[0]["name"].ToString();
                        jj++;
                    }
                }
            }
        }//payane dokme
        public void text7()
        {
            bunifuMetroTextbox7.Text = bunifuMetroTextbox7.Text.Replace("۰", "0").Replace("۱", "1").Replace("۲", "2").Replace("۳", "3").Replace("۴", "4").Replace("۵", "5").Replace("۶", "6").Replace("۷", "7").Replace("۸", "8").Replace("۹", "9");

        }
        public void text3()
        {
            bunifuMetroTextbox3.Text = bunifuMetroTextbox3.Text.Replace("۰", "0").Replace("۱", "1").Replace("۲", "2").Replace("۳", "3").Replace("۴", "4").Replace("۵", "5").Replace("۶", "6").Replace("۷", "7").Replace("۸", "8").Replace("۹", "9");

        }
        public static string dastebandi_final = "";
        private void bunifuButton5_Click(object sender, EventArgs e)
        {
            dastebandi_final = comboBox1.Text;
            i = 0;
            for (int i = dataGridView6.Rows.Count - 1; i >= 1; i--)
            {
                dataGridView6.Rows.RemoveAt(0);

            }
            for (int i = dataGridView5.Rows.Count - 1; i >= 1; i--)
            {
                dataGridView5.Rows.RemoveAt(0);

            }
            mainb();
            
        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            dastebandi_final = "";
            i = 0;
            for (int i = dataGridView6.Rows.Count - 1; i >= 1; i--)
            {
                dataGridView6.Rows.RemoveAt(0);

            }
            for (int i = dataGridView5.Rows.Count - 1; i >= 1; i--)
            {
                dataGridView5.Rows.RemoveAt(0);

            }
        }
        bool first = true;
        public int counterr ;
        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            if (dataGridView5.Rows.Count > 0)
            {
                for (int i = 0; i < dataGridView5.Rows.Count - 1; i++)
                {
                    int id = int.Parse(dataGridView5.Rows[i].Cells[0].Value.ToString());
                    SqlConnection a = new SqlConnection(connectify.pcs);
                    a.Open();
                    SqlDataAdapter sd = new SqlDataAdapter("select * from foods where id='" + id + "'", a);
                    DataTable dt = new DataTable();
                    sd.Fill(dt);
                    float zarib1 = float.Parse(dataGridView5.Rows[i].Cells[2].Value.ToString()) / float.Parse(dt.Rows[0]["minimom"].ToString());
                    float t = float.Parse(dt.Rows[0]["pro"].ToString());
                    int darsad = (int)((t / (float)(barnamejadid.protoein)) * 100);
                    int prro = (int)(zarib1 * darsad);
                    t = float.Parse(dt.Rows[0]["charb"].ToString());
                    darsad = (int)((t / (float)(barnamejadid.charbi)) * 100);
                    int charbb = (int)(zarib1 * darsad);
                    SqlCommand bb = new SqlCommand("insert into foodss (name,tedad,vahed,barname_id,tozihat,vade,cdarsad,pdarsad) values ('" + dt.Rows[0]["name"].ToString() + "','" + dataGridView5.Rows[i].Cells[2].Value.ToString() + "','" + dataGridView5.Rows[i].Cells[3].Value.ToString() + "','" + barnamejadid.barname_id + "','" + dt.Rows[0]["tozihat"].ToString() + "','" + dastebandi_final + "','" + charbb + "','" + prro + "') ", a);
                    bb.ExecuteNonQuery();

                }
                SqlConnection aa = new SqlConnection(connectify.pcs);
                aa.Open();
                String desc = "";
                if (i==0 || i==4 || i== 3)
                    desc = "asc";
                else
                    desc = "desc";
                counterr++;
                SqlDataAdapter sdd = new SqlDataAdapter("select name,convert (int,pdarsad) as pdarsad,cdarsad,ABS (convert (int,pdarsad)-convert(int,cdarsad)) as maxim from foodss where vade='" + dastebandi_final + "' order by pdarsad "+desc+"  ", aa);
                DataTable dtt = new DataTable();
                sdd.Fill(dtt);
                string[] fooddd = { "", "", "", "", "", "", "" };
                int[] pro = { 0, 0, 0, 0, 0, 0, 0 };
                int[] charb ={0, 0, 0, 0, 0, 0, 0};
                int cdar=0;
                int pdar = 0;
                for (int k= 0; (k < 3) &&(k<dtt.Rows.Count) ;k++)
                {
                    fooddd[k] = dtt.Rows[k]["name"].ToString();
                  
                     //   string test1 = "p" + (k + 1).ToString();
                        pro[k] = int.Parse(dtt.Rows[k]["pdarsad"].ToString());
                    //    string test3 = "c" + (k + 1).ToString();
                        charb[k] =int.Parse( dtt.Rows[k]["cdarsad"].ToString());

                    
                }
                SqlCommand b = new SqlCommand("insert into foodsss (f1,p1,c1,f2,p2,c2,f3,p3,c3) values ('" + fooddd[0] + "'," + pro[0] + "," + charb[0] + ",'" + fooddd[1] + "'," + pro[1] + "," + charb[1] + ",'" + fooddd[2] + "'," + pro[2] + "," + charb[2] +  ")  ", aa);
                b.ExecuteNonQuery();
                i = 0;
                for (int i = dataGridView6.Rows.Count - 1; i >= 1; i--)
                {
                    dataGridView6.Rows.RemoveAt(0);

                }
                for (int i = dataGridView5.Rows.Count - 1; i >= 1; i--)
                {
                    dataGridView5.Rows.RemoveAt(0);

                }
                bunifuMetroTextbox6.Text = (int.Parse(bunifuMetroTextbox6.Text) - int.Parse(bunifuMetroTextbox7.Text)).ToString();
                bunifuMetroTextbox7.Text = comboBox1.Text = bunifuMetroTextbox3.Text = "";
            }
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            SqlConnection a = new SqlConnection(connectify.pcs);
            a.Open();
            if (!jobrani)
            {
                jobrani = true;         
                string name = "ماست ایسلندی";
                string tedad = "1";
                string vahed = "ظرف";
                string vade = "جبرانی";
                int charb = 0;
                float pro = ((27 / (float)barnamejadid.protoein) * 100);

                SqlCommand b = new SqlCommand("insert into foodss (name,tedad,vahed,barname_id,tozihat,vade,cdarsad,pdarsad) values ('" + name + "','" + tedad + "','" + vahed + "','" + barnamejadid.barname_id + "','" + "" + "','" + vade + "','" + charb + "','" + pro + "') ", a);
                b.ExecuteNonQuery();
                name = "پزوتئین وی ";
                tedad = "1";
                vahed = "اسکوپ";
                vade = "جبرانی";
                charb = 0;
                pro = ((25 / (float)barnamejadid.protoein) * 100);
                b = new SqlCommand("insert into foodss (name,tedad,vahed,barname_id,tozihat,vade,cdarsad,pdarsad) values ('" + name + "','" + tedad + "','" + vahed + "','" + barnamejadid.barname_id + "','" + "" + "','" + vade + "','" + charb + "','" + pro + "') ", a);
                b.ExecuteNonQuery();

                name = "شیر ";
                tedad = "1";
                vahed = "لیوان";
                vade = "جبرانی";
                charb = 0;
                pro = ((7 / (float)barnamejadid.protoein) * 100);
                b = new SqlCommand("insert into foodss (name,tedad,vahed,barname_id,tozihat,vade,cdarsad,pdarsad) values ('" + name + "','" + tedad + "','" + vahed + "','" + barnamejadid.barname_id + "','" + "" + "','" + vade + "','" + charb + "','" + pro + "') ", a);
                b.ExecuteNonQuery();


                name = "سفیده ";
                tedad = "1";
                vahed = "دانه";
                vade = "جبرانی";
                charb = 0;
                pro = ((3 / (float)barnamejadid.protoein) * 100);
                b = new SqlCommand("insert into foodss (name,tedad,vahed,barname_id,tozihat,vade,cdarsad,pdarsad) values ('" + name + "','" + tedad + "','" + vahed + "','" + barnamejadid.barname_id + "','" + "" + "','" + vade + "','" + charb + "','" + pro + "') ", a);
                b.ExecuteNonQuery();



            }


            SqlDataAdapter sd = new SqlDataAdapter("select name,weight,day,month,year,tedad,hadaf,cal,first_cal from barname where id='"+barnamejadid.barname_id+"'", a);
            DataTable dt = new DataTable();
            sd.Fill(dt);

            sd = new SqlDataAdapter("select name,tedad,vahed,vade,cdarsad,pdarsad from foodss where barname_id='" + barnamejadid.barname_id + "'", a);
            DataTable dtt = new DataTable();
            sd.Fill(dtt);

            sd = new SqlDataAdapter("select name,tozihat from foodss where barname_id='" + barnamejadid.barname_id + "'", a);
            DataTable dttt = new DataTable();
            sd.Fill(dttt);
            sd = new SqlDataAdapter("select max(id) as maxim from tozihat", a);
            DataTable bt = new DataTable();
            sd.Fill(bt);


            sd = new SqlDataAdapter("select * from mokamel where id_mokamel='"+barnamejadid.barname_id+"'", a);
            DataTable ct = new DataTable();
            sd.Fill(ct);


            DataTable btt = new DataTable() ;
            stiReport1.Load(Application.StartupPath + "/final_v.mrt");
            stiReport1.RegData("barname", dt);
            stiReport1.RegData("foodss", dtt);
            stiReport1.RegData("foodsss", dttt);
            stiReport1.RegData("mokamel", ct);

            if (bt.Rows[0]["maxim"].ToString()!="")
            {
                sd = new SqlDataAdapter("select tozihat.tozihat from tozihat where id='" + int.Parse(bt.Rows[0]["maxim"].ToString()) + "'", a);
               btt = new DataTable();
                sd.Fill(btt);
            }
            stiReport1.RegData("tozihat", btt);

            stiReport1.ReportName =barnamejadid.name;
            stiReport1.Show();

        }

        private void bunifuMetroTextbox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar) || char.IsPunctuation(e.KeyChar))) { e.Handled = true; MessageBox.Show("لطفا فقط عدد وارد کنید", "Alert!"); }

        }

        private void bunifuMetroTextbox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar) || char.IsPunctuation(e.KeyChar))) { e.Handled = true; MessageBox.Show("لطفا فقط عدد وارد کنید", "Alert!"); }

        }

        private void bunifuButton7_Click(object sender, EventArgs e)
        {
            SqlConnection a = new SqlConnection(connectify.pcs);
            a.Open();
            SqlCommand c = new SqlCommand("delete from tozihat", a);
            c.ExecuteNonQuery();
            SqlCommand b = new SqlCommand("insert into tozihat (tozihat) values('"+richTextBox1.Text+"')",a);
            b.ExecuteNonQuery();
            richTextBox1.Text = "";
        }

        private void bunifuMetroTextbox6_Enter(object sender, EventArgs e)
        {
            color1();
            color2(); color3();
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
                comboBox1.Focus();
            }
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
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
                dastebandi_final = comboBox1.Text;
                i = 0;
                for (int i = dataGridView6.Rows.Count - 1; i >= 1; i--)
                {
                    dataGridView6.Rows.RemoveAt(0);

                }
                for (int i = dataGridView5.Rows.Count - 1; i >= 1; i--)
                {
                    dataGridView5.Rows.RemoveAt(0);

                }
                mainb();
            }
        }
         public static int deletee = -1;
        private void dataGridView6_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            deletee = e.RowIndex;
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuMetroTextbox7_OnValueChanged(object sender, EventArgs e)
        {
            if (bunifuMetroTextbox7.Text == "")
            {
                public_cal = 0;
                show1();
                color1();
                show2();
                color2();
                show3();
                color3();
            }
            else
            {
                public_cal = int.Parse(bunifuMetroTextbox7.Text);
                show1();
                color1();
                show2();
                color2();
                show3();
                color3();
            }
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            show1();
            color1();
            show2();
            color2();
            show3();
            color3();
        }

        private void bunifuButton6_Click_1(object sender, EventArgs e)
        {
            if ((bunifuMetroTextbox6.Text == "") || (bunifuMetroTextbox7.Text == "") || (comboBox1.Text == ""))
            {
                MessageBox.Show("لطفا تمام اطلاعات را وارد کنید");
            }
            else if ((int.Parse(bunifuMetroTextbox6.Text)) < (int.Parse(bunifuMetroTextbox7.Text)))
            {
                MessageBox.Show("مقدار انتخابی بیش از حد مجاز");

            }
            else
            {
                int cal = int.Parse(bunifuMetroTextbox7.Text);
                int j = 0;
                int jj = 0;

                for (int k = 0; k < dataGridView6.Rows.Count - 1; k++)
                {
                    int id = int.Parse(dataGridView6.Rows[k].Cells[0].Value.ToString());
                    SqlConnection a = new SqlConnection(connectify.pcs);
                    a.Open();
                    SqlDataAdapter sd = new SqlDataAdapter("select * from foods where id='" + id + "'", a);
                    DataTable dt = new DataTable();
                    sd.Fill(dt);
                    int call = 0;
                    if ((dt.Rows[0]["cal"].ToString() != "") && (dt.Rows[0]["cal"].ToString() != "0"))
                    {
                        call = int.Parse(dt.Rows[0]["cal"].ToString());
                    }
                    else
                    {
                        int karbo = int.Parse(dt.Rows[0]["karbo"].ToString());
                        int charb = int.Parse(dt.Rows[0]["charb"].ToString());
                        int pro = int.Parse(dt.Rows[0]["pro"].ToString());
                        call = pro * 4 + karbo * 4 + charb * 9;
                    }
                    Double min =.5;
                    float max = float.Parse(dt.Rows[0]["maximom"].ToString());
                    string ttttt = dt.Rows[0]["had"].ToString() ;

                    Double had = 0;
                        had=.25;
                    bool t = false;

                            while(call*min<cal)
                            {
                                double t1 = cal - (call * min);
                                double t2 = cal - (call * (min + .25));
                                if (t2 <= cal)
                                    min = min + .25;
                                else
                                {
                                    if (cal - (call * min) > t2 - call)
                                        min = min + .25;
                                }
                            }
                            dataGridView5.Rows.Add("", "", "", "");
                            dataGridView5.Rows[jj].Cells[0].Value = dt.Rows[0]["id"].ToString();

                            dataGridView5.Rows[jj].Cells[1].Value = dt.Rows[0]["name"].ToString();
                            dataGridView5.Rows[jj].Cells[2].Value = min.ToString();
                            SqlDataAdapter sdd = new SqlDataAdapter("select name from vahed where id='" + dt.Rows[0]["vahed"].ToString() + "'", a);
                            DataTable dtt = new DataTable();
                            sdd.Fill(dtt);
                            dataGridView5.Rows[jj].Cells[3].Value = dtt.Rows[0]["name"].ToString();
                            jj++;
                            t = true;
                            color5();
                        
                   
                    
                }
            }
        }

        private void bunifuButton3_Click_1(object sender, EventArgs e)
        {
            SqlConnection a = new SqlConnection(connectify.pcs);
            a.Open();
            
                SqlDataAdapter ccc = new SqlDataAdapter("select * from foodsss ", a);
                DataTable count = new DataTable();
                ccc.Fill(count);
                for(int i=1;i<=3;i++)
                {
                    SqlDataAdapter sdd = new SqlDataAdapter("select f"+i.ToString()+" from foodsss", a);
                    DataTable arman = new DataTable();
                    sdd.Fill(arman);
                    SqlDataAdapter sddd = new SqlDataAdapter("select sum(p" + i.ToString() + ") as m1 ,sum(c" + i.ToString() + ") as m2 from foodsss", a);
                    DataTable arman2 = new DataTable();
                    sddd.Fill(arman2);
                    int cdar=0, pdar=0;
                    string[] vadeha = { "", "", "", "", "" };
                    try
                        {
                        vadeha[0]= arman.Rows[0]["f" + i.ToString()].ToString();
                        vadeha[1] = arman.Rows[1]["f" + i.ToString()].ToString();
                        vadeha[2] = arman.Rows[2]["f" + i.ToString()].ToString();
                        vadeha[3] = arman.Rows[3]["f" + i.ToString()].ToString();
                        vadeha[4] = arman.Rows[4]["f" + i.ToString()].ToString();

                    }
                    catch
                        {
                        goto a;
                    }
                    a:
                    if(arman2.Rows[0]["m1"].ToString()!="")
                    {
                        pdar = int.Parse(arman2.Rows[0]["m1"].ToString());
                    }
                    if (arman2.Rows[0]["m2"].ToString() != "")
                    {
                        cdar = int.Parse(arman2.Rows[0]["m2"].ToString());
                    }
                    
                            SqlCommand arman4 = new SqlCommand("insert into pishnahad (bre,mid1,lun,mid2,din,pdar,cdar) values ('" + vadeha[0] + "'      ,'" + vadeha[1] + "'         ,'" + vadeha[2] + "','" +vadeha[3] + "','" + vadeha[4] + "' ,'" + pdar + "','" + cdar + "')  ", a);
                            arman4.ExecuteNonQuery();





            }










            if (!jobrani)
            {
                jobrani = true;
                string name = "ماست ایسلندی";
                string tedad = "1";
                string vahed = "ظرف";
                string vade = "جبرانی";
                int charb = 0;
                float pro = ((27 / (float)barnamejadid.protoein) * 100);

                SqlCommand b = new SqlCommand("insert into foodss (name,tedad,vahed,barname_id,tozihat,vade,cdarsad,pdarsad) values ('" + name + "','" + tedad + "','" + vahed + "','" + barnamejadid.barname_id + "','" + "" + "','" + vade + "','" + charb + "','" + pro + "') ", a);
                b.ExecuteNonQuery();
                name = "پزوتئین وی ";
                tedad = "1";
                vahed = "اسکوپ";
                vade = "جبرانی";
                charb = 0;
                pro = ((25 / (float)barnamejadid.protoein) * 100);
                b = new SqlCommand("insert into foodss (name,tedad,vahed,barname_id,tozihat,vade,cdarsad,pdarsad) values ('" + name + "','" + tedad + "','" + vahed + "','" + barnamejadid.barname_id + "','" + "" + "','" + vade + "','" + charb + "','" + pro + "') ", a);
                b.ExecuteNonQuery();

                name = "شیر ";
                tedad = "1";
                vahed = "لیوان";
                vade = "جبرانی";
                charb = 0;
                pro = ((7 / (float)barnamejadid.protoein) * 100);
                b = new SqlCommand("insert into foodss (name,tedad,vahed,barname_id,tozihat,vade,cdarsad,pdarsad) values ('" + name + "','" + tedad + "','" + vahed + "','" + barnamejadid.barname_id + "','" + "" + "','" + vade + "','" + charb + "','" + pro + "') ", a);
                b.ExecuteNonQuery();


                name = "سفیده ";
                tedad = "1";
                vahed = "دانه";
                vade = "جبرانی";
                charb = 0;
                pro = ((3 / (float)barnamejadid.protoein) * 100);
                b = new SqlCommand("insert into foodss (name,tedad,vahed,barname_id,tozihat,vade,cdarsad,pdarsad) values ('" + name + "','" + tedad + "','" + vahed + "','" + barnamejadid.barname_id + "','" + "" + "','" + vade + "','" + charb + "','" + pro + "') ", a);
                b.ExecuteNonQuery();



            }


            SqlDataAdapter sd = new SqlDataAdapter("select name,weight,day,month,year,tedad,hadaf,cal,first_cal,rezayat from barname where id='" + barnamejadid.barname_id + "'", a);
            DataTable dt = new DataTable();
            sd.Fill(dt);

            sd = new SqlDataAdapter("select name,tedad,vahed,vade,cdarsad,pdarsad from foodss where barname_id='" + barnamejadid.barname_id + "'", a);
            DataTable dtt = new DataTable();
            sd.Fill(dtt);

            sd = new SqlDataAdapter("select name,tozihat from foodss where barname_id='" + barnamejadid.barname_id + "'", a);
            DataTable dttt = new DataTable();
            sd.Fill(dttt);
            sd = new SqlDataAdapter("select max(id) as maxim from tozihat", a);
            DataTable bt = new DataTable();
            sd.Fill(bt);


            sd = new SqlDataAdapter("select * from mokamel where id_mokamel='" + barnamejadid.barname_id + "'", a);
            DataTable ct = new DataTable();
            sd.Fill(ct);
            sd = new SqlDataAdapter("select * from pishnahad ", a);
            DataTable mt = new DataTable();
            sd.Fill(mt);


            DataTable btt = new DataTable();
            stiReport1.Load(Application.StartupPath + "/final.mrt");
            stiReport1.RegData("barname", dt);
            stiReport1.RegData("foodss", dtt);
            stiReport1.RegData("foodsss", dttt);
            stiReport1.RegData("mokamel", ct);
            stiReport1.RegData("pishnahad", mt);

            if (bt.Rows[0]["maxim"].ToString() != "")
            {
                sd = new SqlDataAdapter("select tozihat.tozihat from tozihat where id='" + int.Parse(bt.Rows[0]["maxim"].ToString()) + "'", a);
                btt = new DataTable();
                sd.Fill(btt);
            }
            stiReport1.RegData("tozihat", btt);

            stiReport1.ReportName = barnamejadid.name;
            stiReport1.Show();
          SqlCommand  arman3 = new SqlCommand("delete from pishnahad", a);
            arman3.ExecuteNonQuery();
        }
        private void bunifuMetroTextbox7_Leave(object sender, EventArgs e)
        {
            //if(bunifuMetroTextbox7.Text!="")
            //{
            //    DataTable dt;SqlCommand b;SqlDataAdapter sd;
            //    SqlConnection a = new SqlConnection(connectify.pcs);
            //    int tedad = dataGridView2.RowCount - 1;
            //    for (int i = 0; i < tedad; i++)
            //    {
            //        if (dataGridView2.Rows[i].Cells[0].Value.ToString() != "")
            //        {
            //            b = new SqlCommand("select * from foods where id=" + int.Parse(dataGridView2.Rows[i].Cells[0].Value.ToString()) + " ");
            //            sd = new SqlDataAdapter(b.CommandText, a);
            //            dt = new DataTable();
            //            sd.Fill(dt);
            //             double  min = .5;
            //            float max = float.Parse(dt.Rows[0]["maximom"].ToString());
            //            string ttttt = dt.Rows[0]["had"].ToString();

            //            Double had = .5;
            //            bool t = false;
            //            int karbo = int.Parse(dt.Rows[0]["karbo"].ToString());
            //            int charb = int.Parse(dt.Rows[0]["charb"].ToString());
            //            int pro = int.Parse(dt.Rows[0]["pro"].ToString());
            //            int call = pro * 4 + karbo * 4 + charb * 9;
            //            while (min <= max)
            //            {
            //                if ((public_cal * .9 <= call * min) && (call * min <= public_cal * 1.1))
            //                {
            //                    t = true;
            //                    break;
            //                }
            //                else if (had == 0)
            //                    break;
            //                else
            //                {
            //                    min = min + had;
            //                }
            //            }
            //            if (!t)
            //            {

            //                dataGridView2.Rows.RemoveAt(i);
            //                i = i - 1;
            //                tedad = tedad - 1;

            //            }
            //        }

            //    }
            //    tedad = dataGridView3.RowCount - 1;
            //    for (int i = 0; i < tedad; i++)
            //    {
            //        if (dataGridView1.Rows[i].Cells[0].Value.ToString() != "")
            //        {
            //            b = new SqlCommand("select * from foods where id=" + int.Parse(dataGridView3.Rows[i].Cells[0].Value.ToString()) + " ");
            //            sd = new SqlDataAdapter(b.CommandText, a);
            //            dt = new DataTable();
            //            sd.Fill(dt);

            //            string tt = dt.Rows[0]["minimom"].ToString();
            //            double min = 1;
            //            if (tt == ".5")
            //                min = .5; float max = float.Parse(dt.Rows[0]["maximom"].ToString());
            //            string ttttt = dt.Rows[0]["had"].ToString();
            //            Double had = .5;

            //            bool t = false;
            //            int karbo = int.Parse(dt.Rows[0]["karbo"].ToString());
            //            int charb = int.Parse(dt.Rows[0]["charb"].ToString());
            //            int pro = int.Parse(dt.Rows[0]["pro"].ToString());
            //            int call = pro * 4 + karbo * 4 + charb * 9;
            //            while (min <= max)
            //            {
            //                if ((public_cal * .9 <= call * min) && (call * min <= public_cal * 1.1))
            //                {
            //                    t = true;
            //                    break;
            //                }
            //                else if (had == 0)
            //                    break;
            //                else
            //                {
            //                    min = min + had;
            //                }
            //            }
            //            if (!t)
            //            {
            //                dataGridView3.Rows.RemoveAt(i);
            //                i = i - 1;
            //                tedad = tedad - 1;
            //            }
            //        }

            //    }
            //    tedad = dataGridView1.RowCount - 1;
            //    for (int i = 0; i < tedad; i++)
            //    {
            //        if (dataGridView1.Rows[i].Cells[0].Value.ToString() != "")
            //        {
            //            b = new SqlCommand("select * from foods where id=" + int.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString()) + " ");
            //            sd = new SqlDataAdapter(b.CommandText, a);
            //            dt = new DataTable(); sd.Fill(dt);
            //            string tt = dt.Rows[0]["minimom"].ToString();
            //            double min = 1;
            //            if (tt == ".5")
            //                min = .5; float max = float.Parse(dt.Rows[0]["maximom"].ToString());
            //            string ttttt = dt.Rows[0]["had"].ToString();

            //            Double had = .5;

            //            bool t = false;
            //            int karbo = int.Parse(dt.Rows[0]["karbo"].ToString());
            //            int charb = int.Parse(dt.Rows[0]["charb"].ToString());
            //            int pro = int.Parse(dt.Rows[0]["pro"].ToString());
            //            int call = pro * 4 + karbo * 4 + charb * 9;
            //            while (min <= max)
            //            {
            //                if ((public_cal * .9 <= call * min) && (call * min <= public_cal * 1.1))
            //                {
            //                    t = true;
            //                    break;
            //                }
            //                else if (had == 0)
            //                    break;
            //                else
            //                {
            //                    min = min + had;
            //                }
            //            }
            //            if (!t)
            //            {
            //                dataGridView1.Rows.RemoveAt(i);
            //                i = i -1;
            //                tedad = tedad - 1;
            //            }
            //        }


            //    }

        //    }
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
