using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace signal
{
    public partial class Form1 : Form
    {
        Image img1 = Image.FromFile(@"e:\vs\homework\signal\1.jpg");//绿灯
        Image img2 = Image.FromFile(@"e:\vs\homework\signal\2.jpg");//红灯
        Image img3 = Image.FromFile(@"e:\vs\homework\signal\3.jpg");//黄灯
        int i = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(button1.Text == "Start")
            {
                timer1.Enabled = true;
                button1.Text = "Stop";
            }
            else
            {
                timer1.Enabled = false;
                button1.Text = "Start";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (i == 0)
                i = 20;
            if(i > 13 && i <= 20)
            {
                pictureBox2.Image = img2;//红灯
                pictureBox3.Image = img2;//红灯
                pictureBox4.Image = img1;//绿灯
                pictureBox5.Image = img1;//绿灯

                int j = i - 10;//红灯
                int k = i - 13;//绿灯

                label3.Text = k.ToString();          //绿灯
                label1.Text = j.ToString();          //红灯
                label4.Text = k.ToString();          //绿灯
                label2.Text = j.ToString();          //红灯
            }
            else if(i > 10 && i <= 13)
            {
                pictureBox2.Image = img2;//红灯
                pictureBox3.Image = img2;
                pictureBox4.Image = img3;
                pictureBox5.Image = img3;//黄灯

                int j = i - 10;//红灯
                int k = j;//黄灯

                label1.Text = j.ToString();          //红灯
                label2.Text = j.ToString();          //红灯
                label3.Text = k.ToString();          //黄灯
                label4.Text = k.ToString();          //黄灯
            }
            else if(i > 3 && i <= 10)
            {
                pictureBox2.Image = img1;//绿灯
                pictureBox3.Image = img1;
                pictureBox4.Image = img2;//红灯
                pictureBox5.Image = img2;

                int j = i - 3;//绿灯
                int k = i;//红灯

                label1.Text = j.ToString();          //绿灯
                label2.Text = j.ToString();          //绿灯
                label3.Text = k.ToString();          //红灯
                label4.Text = k.ToString();          //红灯
            }
            else
            {
                pictureBox2.Image = img3;//黄灯
                pictureBox3.Image = img3;
                pictureBox4.Image = img2;//红灯
                pictureBox5.Image = img2;

                int j = i;//黄灯
                int k = i;//红灯

                label1.Text = j.ToString();          //黄灯
                label2.Text = j.ToString();          //黄灯
                label3.Text = k.ToString();          //红灯
                label4.Text = k.ToString();          //红灯
            }
            i--;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
