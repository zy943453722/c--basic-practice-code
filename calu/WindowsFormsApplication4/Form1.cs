using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {            
            double a = Convert.ToDouble(textBox1.Text);
            double b = Convert.ToDouble(textBox3.Text);
            char c = Convert.ToChar(textBox2.Text);
            double d = 0.0;
            switch (c)
            {
                case '+':
                    d = a + b;
                    break;
                case '-':
                    d = a - b;
                    break;
                case '*':
                    d = a * b;
                    break;
                case '/':
                    d = a / b;
                    break;
                case '^':
                    d = Math.Pow(a, b);
                    break;
                case '%':
                    d = a % b;
                    break;
                default:
                    Form Frm2 = new Form();
                    
                    Frm2.Show();
                   // MessageBox.Show("请输入一个有效的运算符！\n注意，%表示求余、^表示求幂。");
                    break;
            }
            textBox4.Text = Convert.ToString(d);
        }
    }
}
