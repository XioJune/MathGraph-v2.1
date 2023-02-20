using System;
using System.Windows.Forms;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;
using System.Security.Cryptography.X509Certificates;


///
/// 
///
///                    if (radio == 1) { 
///                        x.Points.AddXY(i / 100, a * Math.Sin(i / 100 * b) + c);
///                        memory[i] = a * Math.Sin(i / 100 * b);
///                    }
///                    if (radio == 2) {
///                        x.Points.AddXY(i / 100, a * Math.Pow(i / 100, 3) + b * Math.Pow(i / 100, 2) + c * i / 100 + d);
///                        memory[i] = a * Math.Pow(i / 100, 3) + b * Math.Pow(i / 100, 2) + c * i / 100 + d;
///                    }
///                    if (radio == 3) {
///                        x.Points.AddXY(i / 100, a * i / 100 * i / 100 + b * i / 100 + c);
///                        memory[i] = a * i / 100 * i / 100 + b * i / 100 + c;
///                    }
///                    if (radio == 4) {
///                        x.Points.AddXY(i / 100, a * i + b);
///                        memory[i] = a * i / 100 + b;
///                    }
/// 
namespace MathGraph_v2._0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Hide();
            label2.Hide();
            label3.Hide();
            label5.Hide();
            textBox1.Hide();
            textBox2.Hide();    
            textBox3.Hide();
            textBox5.Hide();
            textBox1.Text = "0";
            textBox2.Text = "0";
            textBox3.Text = "0";
            textBox4.Text = "0";
            textBox5.Text = "0";
            f1.Name = "Function 1";
            f2.Name = "Function 2";
        }

        public int radio;

        Series f1 = new Series();
        Series f2 = new Series();
        Series square = new Series();
        double[] memory_f1 = new double[100];
        double[] memory_f2 = new double[100];
        
        public int func; 
        private void button1_Click(object sender, EventArgs e)
        {

            square.Points.Clear();
            try
            {
                chart1.Series.Remove(square);
            }
            catch (Exception ex) { }
            finally { 
            double summ = 0;
            for (int i = 0; i < memory_f1.Count(); i++) {
                summ += (memory_f1[i]/ memory_f1.Count() - memory_f2[i]/ memory_f1.Count());
                square.Points.AddXY(Convert.ToDouble(i) / 100, memory_f1[i]);
                square.Points.AddXY(Convert.ToDouble(i) / 100, memory_f2[i]);
            }
            square.ChartType = SeriesChartType.Line;
                square.Name = "Square";
                chart1.Series.Add(square);
            textBox4.Text = summ.ToString();
        }
        }

        public void update_function(object sender, EventArgs e, Series x) 
        {
            x.ChartType = SeriesChartType.Line;
            x.Points.Clear();
                double []memory = new double[100];
            try
            {
                double a = Convert.ToDouble(textBox1.Text);
                double b = Convert.ToDouble(textBox2.Text);
                double c = Convert.ToDouble(textBox3.Text);
                double d = Convert.ToDouble(textBox5.Text);
                for (int i = 0; i < 100; i++)
                {
                    double p = Convert.ToDouble(i) / 100;
                    if (radio == 1)
                    {
                        x.Points.AddXY(p, a * Math.Sin(p * b) + c);
                        memory[i] = a * Math.Sin(p * b)+c;
                    }
                    if (radio == 2) 
                    {
                        x.Points.AddXY(p, a * p * p * p + b * p * p + c * p + d);
                        memory[i] = a* p *p * p + b * p * p + c * p + d;
                    }
                    if (radio ==3) 
                    {
                        x.Points.AddXY(p, a * p * p + b * p + c);
                        memory[i] = a*p*p+ b*p +c;
                    }
                    if (radio == 4) 
                    {
                        x.Points.AddXY(p, a * p + b);
                        memory[i] = a * p + b;
                    }

                }         
                if (func ==1) memory_f1 = memory;
                else memory_f2 = memory;
                chart1.Series.Add(x);
                for (int i = 0; i < 100;i++)
                    Console.WriteLine(memory[i]);
             }
            catch (Exception ex) { Console.WriteLine("Some Errors was detected!"); }
            finally {}
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text = "a";
            label2.Text = "b";
            label3.Text = "c";
            label1.Show();
            label2.Show();
            label3.Show();
            textBox1.Show();
            textBox2.Show();
            textBox3.Show();
            radio = 1;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            if (func == 1)
                update_function(sender, e, f1);
            else update_function(sender, e, f2);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (func == 1)
                update_function(sender, e, f1);
            else update_function(sender, e, f2);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

            if (func == 1)
                update_function(sender, e, f1);
            else update_function(sender, e, f2);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            func = 1;
        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            func = 2;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text = "a";
            label2.Text = "b";
            label3.Text = "c";
            label5.Text = "d";
            label1.Show();
            label2.Show();
            label3.Show();
            label5.Show();
            textBox1.Show();
            textBox2.Show();
            textBox3.Show();
            textBox5.Show();
            radio = 2;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {

            radio = 3; 
            label1.Text = "a";
            label2.Text = "b";
            label3.Text = "c";
            label1.Show();
            label2.Show();
            label3.Show();
            textBox1.Show();
            textBox2.Show();
            textBox3.Show();
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text = "k";
            label2.Text = "b";
            label1.Show();
            label2.Show();
            textBox1.Show();
            textBox2.Show();
            radio = 4;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (func == 1)
                update_function(sender, e, f1);
            else update_function(sender, e, f2);
        }
    }
}