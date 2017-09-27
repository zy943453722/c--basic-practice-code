using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "实训2_2";
            Label label1 = new Label();
            label1.Location = new Point(10, 10);
            label1.Text = "存款金额：";
            this.Controls.Add(label1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int money = Convert.ToInt32(textBox5.Text);
            int year = Convert.ToInt32(textBox2.Text);
            double rate = Convert.ToDouble(textBox1.Text) / 100;
            double interest = money * rate * year;
            textBox3.Text = interest.ToString();
            double total = money + interest;
            textBox4.Text = total.ToString();
        }
    }
}
