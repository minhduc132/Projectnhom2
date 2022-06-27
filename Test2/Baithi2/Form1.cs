using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Baithi2
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
            comboBox1.Items.Add("USD");
            comboBox1.Items.Add("EUR");
            comboBox1.Items.Add("AUD");
            comboBox1.Items.Add("JPY");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string value = textBox1.Text;
            double number = Convert.ToDouble(value);
            ServiceReference1.Service1Client
                sv = new ServiceReference1.Service1Client();
            double result = sv.DoiTien(number);
            if (comboBox1.SelectedValue.Equals("USD"))
            {
                result = result * 23260;
            }
            else if (comboBox1.SelectedValue.Equals("EUR"))
            {
                result = result * 27061;
            }
            else if (comboBox1.SelectedValue.Equals("AUD"))
            {
                result = result * 16798;
            }
            else
            {
                result = result * 20704;
            }

            label3.Text = result.ToString();
        }
    }
}
