using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace signal2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int i = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Start")
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
                i = 60;
            //初始让直行为红灯，左转为红灯，朝前走
            if (i > 30 && i <= 60)//直行的红灯30秒,同时左转也红灯了30s
            {
                pictureBox3.Image = this.imageList1.Images[7];
                pictureBox4.Image = this.imageList1.Images[7];
                pictureBox2.Image = this.imageList1.Images[5];
                this.label1.ForeColor = Color.Red;
                this.label1.Text = (100 + (i - 30)).ToString().Substring(1, 2);

                pictureBox5.Image = pictureBox6.Image = this.imageList1.Images[1];
                pictureBox7.Image = this.imageList1.Images[9];
                this.label2.ForeColor = Color.Red;
                this.label2.Text = (100 + (i - 30)).ToString().Substring(1, 2);
                if (i > 43)//看左方右方的指示灯变化，当前为直行绿，左转红
                {
                    pictureBox8.Image = pictureBox9.Image = this.imageList1.Images[4];
                    pictureBox10.Image = this.imageList1.Images[1];
                    this.label3.ForeColor = Color.Green;
                    this.label3.Text = (100 + (i - 43)).ToString().Substring(1, 2);

                    pictureBox12.Image = pictureBox13.Image = this.imageList1.Images[8];
                    pictureBox11.Image = this.imageList1.Images[7];
                    this.label4.ForeColor = Color.Green;
                    this.label4.Text = (100 + (i - 43)).ToString().Substring(1, 2);
                }
                else
                {
                    if (i > 40)//左方绿灯变成黄灯3s
                    {
                        pictureBox8.Image = pictureBox9.Image = this.imageList1.Images[6];
                        pictureBox10.Image = this.imageList1.Images[1];
                        this.label3.ForeColor = Color.Yellow;
                        this.label3.Text = (100 + (i - 40)).ToString().Substring(1, 2);

                        pictureBox12.Image = pictureBox13.Image = this.imageList1.Images[10];
                        pictureBox11.Image = this.imageList1.Images[7];
                        this.label4.ForeColor = Color.Yellow;
                        this.label4.Text = (100 + (i - 40)).ToString().Substring(1, 2);
                    }
                    else//左方黄灯变红灯
                    {
                        if (i > 33)
                        {
                            pictureBox8.Image = pictureBox9.Image = this.imageList1.Images[5];
                            pictureBox10.Image = this.imageList1.Images[0];
                            this.label3.ForeColor = Color.Green;
                            this.label3.Text = (100 + (i - 33)).ToString().Substring(1, 2);

                            pictureBox12.Image = pictureBox13.Image = this.imageList1.Images[9];
                            pictureBox11.Image = this.imageList1.Images[3];
                            this.label4.ForeColor = Color.Green;
                            this.label4.Text = (100 + (i - 33)).ToString().Substring(1, 2);
                        }
                        else
                        {
                            pictureBox8.Image = pictureBox9.Image = this.imageList1.Images[5];
                            pictureBox10.Image = this.imageList1.Images[2];
                            this.label3.ForeColor = Color.Yellow;
                            this.label3.Text = (100 + (i - 30)).ToString().Substring(1, 2);

                            pictureBox12.Image = pictureBox13.Image = this.imageList1.Images[9];
                            pictureBox11.Image = this.imageList1.Images[12];
                            this.label4.ForeColor = Color.Yellow;
                            this.label4.Text = (100 + (i - 30)).ToString().Substring(1, 2);
                        }
                    }
                }
            }
            else//前方直行变为绿灯
            {
                pictureBox8.Image = pictureBox9.Image = this.imageList1.Images[5];
                pictureBox10.Image = this.imageList1.Images[1];
                this.label3.ForeColor = Color.Red;
                this.label3.Text = (100 + i).ToString().Substring(1, 2);

                pictureBox12.Image = pictureBox13.Image = this.imageList1.Images[9];
                pictureBox11.Image = this.imageList1.Images[7];
                this.label4.ForeColor = Color.Red;
                this.label4.Text = (100 + i).ToString().Substring(1, 2);
                if (i > 13)
                {
                    pictureBox3.Image = this.imageList1.Images[3];
                    pictureBox4.Image = this.imageList1.Images[3];
                    pictureBox2.Image = this.imageList1.Images[5];
                    this.label1.ForeColor = Color.Green;
                    this.label1.Text = (100 + (i - 13)).ToString().Substring(1, 2);

                    pictureBox5.Image = pictureBox6.Image = this.imageList1.Images[0];
                    pictureBox7.Image = this.imageList1.Images[9];
                    this.label2.ForeColor = Color.Green;
                    this.label2.Text = (100 + (i - 13)).ToString().Substring(1, 2);
                }
                else
                {
                    if (i > 10)  
                    {
                        pictureBox3.Image = this.imageList1.Images[12];
                        pictureBox4.Image = this.imageList1.Images[12];
                        pictureBox2.Image = this.imageList1.Images[5];
                        this.label1.ForeColor = Color.Yellow;
                        this.label1.Text = (100 + (i - 10)).ToString().Substring(1, 2);

                        pictureBox5.Image = pictureBox6.Image = this.imageList1.Images[2];
                        pictureBox7.Image = this.imageList1.Images[9];
                        this.label2.ForeColor = Color.Yellow;
                        this.label2.Text = (100 + (i - 10)).ToString().Substring(1, 2);
                    }
                    else
                    {
                        if (i >= 3)
                        {
                            pictureBox3.Image = this.imageList1.Images[7];
                            pictureBox4.Image = this.imageList1.Images[7];
                            pictureBox2.Image = this.imageList1.Images[4];
                            this.label1.ForeColor = Color.Green;
                            this.label1.Text = (100 + (i - 3)).ToString().Substring(1, 2);

                            pictureBox5.Image = pictureBox6.Image = this.imageList1.Images[1];
                            pictureBox7.Image = this.imageList1.Images[8];
                            this.label2.ForeColor = Color.Green;
                            this.label2.Text = (100 + (i - 3)).ToString().Substring(1, 2);
                        }
                        else
                        {
                            pictureBox3.Image = this.imageList1.Images[3];
                            pictureBox4.Image = this.imageList1.Images[3];
                            pictureBox2.Image = this.imageList1.Images[6];
                            this.label1.ForeColor = Color.Yellow;
                            this.label1.Text = (100 + i).ToString().Substring(1, 2);

                            pictureBox5.Image = pictureBox6.Image = this.imageList1.Images[0];
                            pictureBox7.Image = this.imageList1.Images[10];
                            this.label2.ForeColor = Color.Yellow;
                            this.label2.Text = (100 + i).ToString().Substring(1, 2);
                        }
                    }
                }
            }
            i--;
        }
    }
}
