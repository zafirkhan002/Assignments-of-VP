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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            this.label1.Text = "F.Add";
            this.label2.Text = "F.Name";
            comboBox1.Text = "Select Extension";
            string[] extension = { ".txt" };
            comboBox1.Items.AddRange(extension);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s = textBox1.Text + textBox2.Text + comboBox1.Text;
            if (File.Exists(s))
            {
                File.Delete(s);
                MessageBox.Show("File Deleted");

            }
            else
            {
                MessageBox.Show("File not Exist");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.Show();
        }
    }
}
