using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace @event
{
    public partial class Form1 : Form
    {

        Random r = new Random();
        TemWarn tw = new TemWarn();//创建温度报警器对象,触发事件类的对象
        public Form1()
        {
            InitializeComponent();
            tw.onWarn += new TemWarn.TemHand(tw_onwarn);//订阅事件，结构是触发事件类+=new 触发事件类中的委托事件（事件方法名）
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void tw_onwarn(object sender,TemEvent e)//定义一个事件方法,用来写onwarn函数的具体实现
        {
            if(e.Tem < 35)
            {
                label2.Text = "正常";
                label3.BackColor = Color.Blue;
            }
            else if(e.Tem < 37)
            {
                label2.Text = "高温黄色预警！";
                label3.BackColor = Color.Yellow;
            }
            else if(e.Tem < 40)
            {
                label2.Text = "高温橙色预警！";
                label3.BackColor = Color.Orange;
            }
            else
            {
                label2.Text = "高温红色预警！";
                label3.BackColor = Color.Red;
            }
        }

         private void timer1_Tick(object sender, EventArgs e)//每隔一秒钟激发该方法
        {
            int nowTemp;
            if (textBox1.Text == "")
                nowTemp = 35;
            else
                nowTemp = Convert.ToInt32(textBox1.Text);
            int change = r.Next(-2, 3);//产生随机数
            textBox1.Text = (change + nowTemp).ToString();
            tw.Monitor(change + nowTemp);
        }

    }
    class TemEvent: EventArgs//创建事件的派生事件类，用于封装事件信息
    {
        private int tem;
        public TemEvent(int tem1)
        {
            tem = tem1;
        }
        public int Tem
        {
            get
            {
                return tem;
            }
        }
    }
    class TemWarn//触发事件类
    {
        public delegate void TemHand(object sender, TemEvent e);//通过委托来实现某个自定义事件
        public event TemHand onWarn;//把事件名称叫做onwarn,时间名叫啥都可以，只是个临时变量
        public void Monitor(int tp)
        {
            TemEvent e = new TemEvent(tp);//利用某一个温度实现实例化
            if(onWarn != null)
            {
                onWarn(this, e);//此事件有两个参数，一个sender，一个e
            }
        }
    }

}
