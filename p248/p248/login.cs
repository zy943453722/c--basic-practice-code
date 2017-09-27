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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            /*连接字符串生成器
            SqlConnectionStringBuilder strings = new SqlConnectionStringBuilder();
            strings.DataSource = @".";
            strings.InitialCatalog = "Financing";
            strings.IntegratedSecurity = true;
            建立连接*/
            //SqlConnection connection = new SqlConnection(strings.ConnectionString);
            /*格式化获取与输入对应的数据库中存在的帐号和密码*/
            database data = new database();
            string sql = string.Format("select count(*) from [User] where UserName = '{0}' and Password = '{1}'", username,password);
            try
            {
                data.connection.Open();
                SqlCommand comm = new SqlCommand(sql, data.connection);
                int n = (int)comm.ExecuteScalar();
                if (n == 1)
                {
                    this.DialogResult = DialogResult.OK;
                    MessageBox.Show("欢迎进入个人理财管理系统！", "登陆成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    main ma = new main();
                    ma.Show();
                    this.Hide();
                    this.Tag = true;//登陆成功的记录
                }
                else
                {
                    MessageBox.Show("您输入的用户名或密码有误！", "登录失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Tag = false;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "操作数据库出错！", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Tag = false;
            }
            finally
            {
                data.connection.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }
    }
}
