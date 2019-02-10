using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CGPACalculatorForm
{
    public partial class CGPACalculator : Form
    {
        double oldTotalCGPA, newTotalCGPA;
        List<string> data = new List<string>();
        int count = 0;
        string labelResult;

        public CGPACalculator()
        {
            InitializeComponent();
            button3.Enabled = false;
            labelResult = label5.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text.Trim()) && !string.IsNullOrWhiteSpace(textBox1.Text.Trim()))
            {
                if (!string.IsNullOrEmpty(textBox2.Text.Trim()) && !string.IsNullOrWhiteSpace(textBox2.Text.Trim()))
                {
                    if (!string.IsNullOrEmpty(textBox3.Text.Trim()) && !string.IsNullOrWhiteSpace(textBox3.Text.Trim()))
                    {
                        if (!string.IsNullOrEmpty(textBox4.Text.Trim()) && !string.IsNullOrWhiteSpace(textBox4.Text.Trim()))
                        {
                            try
                            {
                                oldTotalCGPA = (double.Parse(textBox1.Text.Trim())) * (double.Parse(textBox2.Text.Trim()));
                                newTotalCGPA = oldTotalCGPA + (double.Parse(textBox3.Text.Trim())) * (double.Parse(textBox4.Text.Trim()));
                                oldTotalCGPA = (newTotalCGPA / ((double.Parse(textBox2.Text.Trim())) + (double.Parse(textBox4.Text.Trim())))) + 0.01;
                                label5.Text = labelResult + oldTotalCGPA.ToString().Trim().Remove(4, (oldTotalCGPA.ToString().Length - 4));
                                data.Add(textBox1.Text.Trim());
                                data.Add(textBox2.Text.Trim());
                                data.Add(textBox3.Text.Trim());
                                data.Add(textBox4.Text.Trim());
                                data.Add((oldTotalCGPA.ToString().Trim().Remove(4, (oldTotalCGPA.ToString().Length - 4))).ToString().Trim());
                                button3.Enabled = true;
                                count++;
                            }
                            catch(Exception ex)
                            {
                                MessageBox.Show("Error..!\n"+ex);
                            }
                        }
                        else
                            MessageBox.Show("Error..!\nNew Semister Credit Box Is Empty!");
                    }
                    else
                        MessageBox.Show("Error..!\nNew Semister GPA Box Is Empty!");
                }
                else
                    MessageBox.Show("Error..!\nCompleted Credit Box Is Empty!");
            }
            else
                MessageBox.Show("Error..!\nCurrent CGPA Box Is Empty!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = null;
                textBox2.Text = null;
                textBox3.Text = null;
                textBox4.Text = null;
                label5.Text = label5.Text.Remove(26,(label5.Text.Length-26));
            }
            catch(Exception exce)
            {
                MessageBox.Show("Error..!\n"+exce);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = data[(count * 5) - 5].ToString();
                textBox2.Text = data[(count * 5) - 4].ToString();
                textBox3.Text = data[(count * 5) - 3].ToString();
                textBox4.Text = data[(count * 5) - 2].ToString();
                label5.Text = labelResult + data[(count * 5) - 1].ToString();
            }
            catch(Exception exc)
            {
                MessageBox.Show("Error..!\n"+exc);
            }
        }
    }
}
