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
    public partial class table : Form
    {
        string information;
        public table()
        {
            InitializeComponent();
        }

        private void table_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch(comboBox1.Text)
            {
                case "收支明细编号":
                    information = "ListID";
                    break;
                case "收支项编号":
                    information = "IeemID";
                    break;
                case "收支日期":
                    information = "TradeDate";
                    break;
                case "说明":
                    information = "Explain";
                    break;
                case "备注":
                    information = "Remark";
                    break;
                default:
                    break;
            }
            database data2 = new database();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            /*对于列名不可在占位符加‘’，而值需要加*/
            string sql2 = string.Format("select * from List where {0} = '{1}'",information,textBox1.Text);
            try
            {
                data2.connection.Open();
                SqlCommand comm2 = new SqlCommand(sql2, data2.connection);
                da.SelectCommand = comm2;//把命令对象绑定到数据适配器对象
                SqlCommandBuilder builder = new SqlCommandBuilder(da);//自动
                da.Fill(ds,"myacount");//填充数据集
                dataGridView1.DataSource = ds.Tables["myacount"];//绑定数据表
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
