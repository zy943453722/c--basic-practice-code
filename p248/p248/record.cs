using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace p248
{
    public partial class record : Form
    {
        int num;
        public record()
        {
            InitializeComponent();
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {
           
        }

        private void record_Load(object sender, EventArgs e)
        {
            database data2 = new database();
            string sql2 = string.Format("select CategoryName,ISPayout,IeemName,IeemID from Category join Item on Category.CategoryID = Item.CategoryID");
            try
            {
                data2.connection.Open();
                SqlCommand comm2 = new SqlCommand(sql2, data2.connection);
                SqlDataReader reader = comm2.ExecuteReader();
                if (reader.Read())
                {
                    string choose = reader.GetString(1);
                    if(choose == "收入")
                    {
                        radioButton1.Checked = true;
                    }
                    else
                    {
                        radioButton2.Checked = true;
                    }
                    comboBox1.Text = reader.GetString(0);
                    textBox2.Text = reader.GetString(2);
                    num = reader.GetInt32(3);
                }
                this.Tag = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "操作数据库出错！", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Tag = false;
            }
            finally
            {
                data2.connection.Close();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(label9.Left >= this.Width)
            {
                label9.Left = 0;
            }
            label9.Left++;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            database data2 = new database();
            MessageBox.Show("保存成功！", "收支记录", MessageBoxButtons.OK, MessageBoxIcon.Information);
            string sql = string.Format("insert into List values('{0}','{1}','{2}','{3}')",num, dateTimePicker1.Value,textBox1.Text,textBox3.Text);
            try
            {
                data2.connection.Open();
                SqlCommand comm = new SqlCommand(sql, data2.connection);
                comm.ExecuteNonQuery();
                this.Tag = true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "操作数据库出错！", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Tag = false;
            }
            finally
            {
                data2.connection.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            textBox2.Text = "";
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = "";
        }

        private void textBox3_MouseClick(object sender, MouseEventArgs e)
        {
            textBox3.Text = "";
        }
    }
}
