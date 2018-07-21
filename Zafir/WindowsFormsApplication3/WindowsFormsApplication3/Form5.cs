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
    public partial class Form5 : Form
    {
      
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            comboBox1.Text = "Select Extension";
            string[] extension = {".txt"};
            comboBox1.Items.AddRange(extension);
            this.textBox3.ScrollBars = ScrollBars.Both;
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            string st = textBox1.Text + textBox2.Text + comboBox1.Text;
            if (File.Exists(st))
            {
                StreamReader sr = new StreamReader(textBox1.Text + textBox2.Text + comboBox1.Text);
                textBox3.Text = sr.ReadToEnd();
                sr.Close();
                
            }
            else
            {
                MessageBox.Show("File not Exuist");
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string p = textBox3.Text;
            //string s1 = textBox3.Text;
            //char[] ch = s1.ToCharArray();
            //for (int c = 0; c < ch.Length; c++)
            //{

            //    if (ch[c] == "")
            //    {
                 
                    
               
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string s = textBox1.Text + textBox2.Text+comboBox1.Text;
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

        private void button4_Click(object sender, EventArgs e)
        {
           
           
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form6 f6 = new Form6();
            f6.Show();
            
        }
}
}
