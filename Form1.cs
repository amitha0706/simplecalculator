using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simple_calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            value.Text = comboBox1.Text;
        }



        private void button1_Click(object sender, EventArgs e)

        {
            try
            {
                string Result;
                string operator1 = "+";
                string operator2 = "-";
                string operator3 = "*";
                string operator4 = "/";
                textBox1.Text = textBox1.Text.Replace(",", "");
                textBox2.Text = textBox2.Text.Replace(",", "");
                bool isIntString = textBox1.Text.All(char.IsDigit);
                bool isIntString1 = textBox1.Text.All(char.IsDigit);
                if (!isIntString && !isIntString1)
                {
                    MessageBox.Show("Invalid Input ! Please provide the correct input");
                    return;

                }
                else
                {
                    if (comboBox1.Text.Equals(operator1))
                    {
                        Result = CalculatorOperation.Sum(textBox1.Text.ToString(), textBox2.Text.ToString());
                        textBox3.Text = Result.ToString();
                    }
                    else if (comboBox1.Text.Equals(operator2))
                    {
                        Result = CalculatorOperation.Sub(textBox1.Text.ToString(), textBox2.Text.ToString());
                        textBox3.Text = Result.ToString();
                    }
                    else if (comboBox1.Text.Equals(operator3))
                    {
                        Result = CalculatorOperation.Mult(textBox1.Text.ToString(), textBox2.Text.ToString());
                        textBox3.Text = Result.ToString();
                    }
                    else if (comboBox1.Text.Equals(operator4))
                    {
                        try
                        {
                            if (textBox2.Text == "0")
                                throw new DivideByZeroException("Division by zero is not allowed");
                            Result = CalculatorOperation.Div(textBox1.Text.ToString(), textBox2.Text.ToString());
                            textBox3.Text = Result.ToString();
                        }
                        catch (DivideByZeroException ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

                    }
                }
            }
            finally
            {

            }



        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
        }
     
    }
}





