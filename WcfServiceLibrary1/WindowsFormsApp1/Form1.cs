using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string value = textBox1.Text;
            ServiceReference1.Service1Client
                sv= new ServiceReference1.Service1Client(); 
            string result=sv.GetData(value);
            label1.Text= result;    
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string v1= textBox1.Text;  
            string v2= textBox2.Text;   

            int a=  Convert.ToInt32(v1);    
            int b= Convert.ToInt32(v2); 

            ServiceReference1.Service1Client
                sv = new ServiceReference1.Service1Client();
            label1.Text = Convert.ToString(sv.cong(a,b));  

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ServiceReference2.Service2Client sv
                = new ServiceReference2.Service2Client();
            ServiceReference2.Employee LsE = sv.GetEmployee();
        }
    }
}
