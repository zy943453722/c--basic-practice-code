using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public abstract class Student
        {
            private string name;
            private int age;
            public Student(string na,int ag)
            {
                name = na;
                age = ag;
            }
            public static int number = 0;
            public string Name
            {
                get
                {
                    return name;
                }
            }
            public int Age
            {
                get
                {
                    return age;
                }
            }
            public abstract double Average();
        }
        public class Pupil : Student
        {
            private double chinese;
            private double math;
            public Pupil(string na, int ag, double chin, double ma) : base(na, ag)
            {
                chinese = chin;
                math = ma;
            }
            public override double Average()
            {
                return (chinese + math) / 2; 
            }
        }
        public class Middle:Student
        {
            private double chinese;
            private double math;
            private double english;
            public Middle(string na,int ag,double chin,double ma,double eng):base(na,ag)
            {
                chinese = chin;
                math = ma;
                english = eng;
            }
            public override double Average()
            {
                return (chinese + math + english) / 3; 
            }
        }
        public class College:Student
        {
            private double required;
            private double optional;
            public College(string na, int ag, double req, double opt) : base(na, ag)
            {
                required = req;
                optional = opt;
            }
            public override double Average()
            {
                return (required + optional) / 2;
            }
        }
        private void Show1(Student s)
        {
            textBox6.Text += "总人数:" + Student.number + ",姓名：" + s.Name + ",小学生" + ",平均成绩：" + s.Average()+System.Environment.NewLine; 
        }
        private void Show2(Student s)
        {
            textBox6.Text += "总人数:" + Student.number + ",姓名：" + s.Name + ",中学生" + ",平均成绩：" + s.Average()+System.Environment.NewLine;
        }
        private void Show3(Student s)
        {
            textBox6.Text += "总人数:" + Student.number + ",姓名：" + s.Name + ",大学生" + ",平均成绩：" + s.Average()+System.Environment.NewLine;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            double chin = Convert.ToDouble(textBox3.Text);
            double ma = Convert.ToDouble(textBox4.Text);
            string na = Convert.ToString(textBox1.Text);
            int ag = Convert.ToInt16(textBox2.Text);
            Pupil pu = new Pupil(na, ag, chin, ma);
            Student.number++;
            Show1(pu);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double chin = Convert.ToDouble(textBox3.Text);
            double ma = Convert.ToDouble(textBox4.Text);
            double eng = Convert.ToDouble(textBox5.Text);
            string na = Convert.ToString(textBox1.Text);
            int ag = Convert.ToInt16(textBox2.Text);
            Middle pu = new Middle(na, ag, chin, ma,eng);
            Student.number++;
            Show2(pu); 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            double req = Convert.ToDouble(textBox3.Text);
            double opt = Convert.ToDouble(textBox4.Text);
            string na = Convert.ToString(textBox1.Text);
            int ag = Convert.ToInt16(textBox2.Text);
            College pu = new College(na, ag, req, opt);
            Student.number++;
            Show3(pu);
        }
    }
}
