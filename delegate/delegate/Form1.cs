using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace @delegate
{
    public delegate int Caculate(int x, int y);
    public partial class Form1 : Form
    {
        public Caculate handler;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int a = Convert.ToInt32(textBox1.Text);
            int b = Convert.ToInt32(textBox2.Text);
            /*Mymath math = new Mymath();
            handler = new Caculate(math.Add);//实例化的同时调用委托者的方法
            label1.Text = "两数之和为：" + handler(a, b);
            handler += new Caculate(math.Multiply);
            label1.Text += "\n两数之积为：" + handler(a, b);//在创建的委托对象中赋初值
            */
            Mymath math = new Mymath();
            handler = new Caculate(math.Add);
            handler += new Caculate(math.Multiply);//多路广播委托
            label1.Text = "调用后的结果为：" + handler(a, b);//程序会先后执行add和multiply方法，但只有最后一种方法的返回值被返回
        }
    }
    class Mymath
    {
        public int Add(int x, int y)
        {
            return x + y; 
        }
        public int Multiply(int x, int y)
        {
            return x * y;
        }
    }
}
