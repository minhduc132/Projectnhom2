using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Baithi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string value = textBox1.Text;
            if (value == "")
            {
                label2.Text = "Khong co";
            }
            else
            {
                double number = Convert.ToDouble(value);
                ServiceReference1.Service1Client
                    sv = new ServiceReference1.Service1Client();
                double result = sv.DoiTien(number);
                string selectedBox = comboBox1.Text;
                if (selectedBox == "USD")
                {
                    result = result * 23260;
                    label2.Text = result.ToString();
                }
                else if (selectedBox == "EUR")
                {
                    result = result * 27061;
                    label2.Text = result.ToString();
                }
                else if (selectedBox == "AUD")
                {
                    result = result * 16798;
                    label2.Text = result.ToString();
                }
                else if (selectedBox == "JPY")
                {
                    result = result * 20704;
                    label2.Text = result.ToString();
                }
                else
                {
                    label2.Text = "Khong co";
                }

            }
        }
    }
}
