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
    public partial class Form6 : Form
    {
       
        public Form6()
        {
            
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            comboBox1.Text = "Select Extension";
            string[] extension = { ".txt" };
            comboBox1.Items.AddRange(extension);
            this.label1.Text = "F.Add";
            this.label2.Text = "F.Name";

            this.button2.Text = "Copy";
            this.button3.Text = "Cancel";
        }

        
        

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form5 f1 = new Form5();
            f1.Show();
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string s = textBox1.Text + textBox2.Text + comboBox1.Text;
            string d = textBox3.Text + textBox4.Text + comboBox1.Text;
            if (File.Exists(d))
            {
                DialogResult dr = MessageBox.Show("You want to replace file");
                if (dr == DialogResult.OK)
                {
                    File.Delete(d);
                    File.Copy(s, d);
                    MessageBox.Show("File coied");

                }

            }
            else
            {
                if (File.Exists(s))
                {
                    File.Copy(s, d);
                    MessageBox.Show("File Copied");
                }
                else
                {
                    MessageBox.Show("File not Exist");
                }
            }
        }
    }
}
