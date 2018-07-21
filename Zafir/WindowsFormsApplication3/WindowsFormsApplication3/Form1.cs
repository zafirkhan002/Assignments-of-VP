using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            this.button1.Text = "Stream Reader";
            this.button2.Text = "Reade";
            this.button3.Text = "Writer";
            this.button3.Visible = false;
            this.button2.Visible = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.Hide();
            Form5 f2 = new Form5();
            f2.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //this.Hide();
            Form4 f3 = new Form4();
            f3.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.button3.Visible = true;
            this.button2.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();

        }

       

        private void button7_Click_1(object sender, EventArgs e)
        {
            Form7 f6 = new Form7();
            f6.Show();
        }
    }
}
