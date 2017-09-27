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
    public partial class informatation : Form
    {
        string choose;
        public informatation()
        {
            InitializeComponent();
        }

        private void informatation_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Trim().Length == 0)
            {
                MessageBox.Show("输入信息不完整！", "信息录入有误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                tabControl1.SelectedIndex = 1;//转到“确认信息的选项卡”
            }
        }
        /*防止用户在未填写添加信息的选项卡时直接点确认信息*/
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                if (textBox1.Text.Trim().Length == 0)
                {
                    MessageBox.Show("输入信息不完整！", "输入信息有误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    tabControl1.SelectedIndex = 0;//切换选项卡
                }
                else/*否则显示内容*/
                {
                    database data2 = new database();
                    string sql2 = string.Format("select * from Category");
                    try
                    {
                        data2.connection.Open();
                        SqlCommand comm2 = new SqlCommand(sql2, data2.connection);
                        SqlDataReader reader = comm2.ExecuteReader();
                        if (reader.Read())
                        {
                            textBox2.Text = "要添加的收支项目为： " + textBox1.Text + System.Environment.NewLine;
                            textBox2.Text += "所属类别： " + reader.GetString(1) + System.Environment.NewLine;
                            textBox2.Text += "是" + reader.GetString(2) + "类型的项目";
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
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            database data1 = new database();
            MessageBox.Show("收支项目添加成功！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            string sql = string.Format("insert into Item values('{0}','{1}','{2}')",textBox1.Text, comboBox1.SelectedIndex, textBox3.Text); 
            try
            {
                data1.connection.Open();
                SqlCommand comm = new SqlCommand(sql,data1.connection);
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
                data1.connection.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if(cd.ShowDialog() == DialogResult.OK)
            {
                textBox2.ForeColor = cd.Color;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            if(fd.ShowDialog() == DialogResult.OK)
            {
                textBox2.Font = fd.Font;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim().Length == 0)
            {
                MessageBox.Show("输入信息不完整！", "信息录入有误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (radioButton1.Checked)
                {
                    choose = radioButton1.Text;
                }
                else
                {
                    choose = radioButton2.Text;
                }
                database data = new database();
                string sql1 = string.Format("insert into Category(CategoryID,CategoryName,ISPayout,Remark) values('{0}','{1}','{2}','{3}')", comboBox1.SelectedIndex, comboBox1.Text, choose, textBox3.Text);
                try
                {
                    data.connection.Open();
                    SqlCommand comm1 = new SqlCommand(sql1, data.connection);
                    comm1.ExecuteNonQuery();
                    this.Tag = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "操作数据库出错！", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Tag = false;
                }
                if (bool.Parse(this.Tag.ToString()) == true)
                {
                    MessageBox.Show("收支类别完成！", "添加成功！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                data.connection.Close();
            }
        }
    }
}
