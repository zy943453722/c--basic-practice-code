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

namespace DB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string strconn = "Data Source = .;Initial Catalog = XSGL;Integrated Security = SSPI";
            using (SqlConnection conn = new SqlConnection(strconn))//建立数据库连接,用using块只需打开，不需要关闭，其自动释放
            {
                conn.Open();
                int i = 0;
                int j = 0;
                int k = 0;
                SqlCommand dbquery = new SqlCommand();//构造sql命令，可执行查询，修改等操作
                dbquery.Connection = conn;
                dbquery.CommandText = "insert into xsgliser(username,password,manager,worker,student)values('hello','hello','0','0','1')";
                i = dbquery.ExecuteNonQuery();
                dbquery.CommandText = "update xsgliser set password = '123456' where username = 'hello'";
                j = dbquery.ExecuteNonQuery();
                dbquery.CommandText = "delete from xsgliser where username = 'hello'";
                k = dbquery.ExecuteNonQuery();
                MessageBox.Show("成功插入" + i + "条记录\n" + "成功更新" + j + "条记录\n" + "成功删除" + k + "条记录\n");
            }
        }
    }
}
