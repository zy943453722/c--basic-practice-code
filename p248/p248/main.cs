using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace p248
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }

        private void 收支管理EToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tToolStripMenuItem_Click(object sender, EventArgs e)
        {
            table ta = new table();
            ta.MdiParent = this;
            ta.Show();
            toolStripStatusLabel2.Text = ta.Text;
        }

        private void main_Load(object sender, EventArgs e)
        {

        }

        private void 退出XCtrlXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 添加收支PCtrlPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            record rec = new record();
            rec.MdiParent = this;
            rec.Show();
            toolStripStatusLabel2.Text = rec.Text;
        }

        private void 添加收支项目ICtrlIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            informatation infor = new informatation();
            infor.MdiParent = this;
            infor.Show();
            toolStripStatusLabel2.Text = infor.Text;
        }

        private void 用户登录LCtrlLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.Close();
            login log = new login();
            log.MdiParent = this;
            log.Show();
            toolStripStatusLabel2.Text = log.Text;
        }

        private void 关于ACtrlAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            about abo = new about();
            abo.ShowDialog();
            toolStripStatusLabel2.Text = abo.Text;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            record rec2 = new record();
            rec2.MdiParent = this;
            rec2.Show();
            toolStripStatusLabel2.Text = rec2.Text;
        }

        private void toolStripButton3_Click_1(object sender, EventArgs e)
        {
            informatation infor2 = new informatation();
            infor2.MdiParent = this;
            infor2.Show();
            toolStripStatusLabel2.Text = infor2.Text;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            table ta2 = new table();
            ta2.MdiParent = this;
            ta2.Show();
            toolStripStatusLabel2.Text = ta2.Text;
        }
    }
}
