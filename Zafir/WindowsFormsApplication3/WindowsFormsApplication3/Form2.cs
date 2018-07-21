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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

       

        private void button2_Click_1(object sender, EventArgs e)
        {
            string s = textBox1.Text + textBox2.Text+comboBox1.Text;
            if (File.Exists(s))
            {
                string fname = textBox1.Text + textBox2.Text + comboBox1.Text;


                FileStream sr = new FileStream(fname, FileMode.Open);
                byte[] bb = new byte[2000];
                char[] ch = new char[2000];

                sr.Read(bb, 0, 100);
                Decoder de = Encoding.UTF8.GetDecoder();
                de.GetChars(bb, 0, bb.Length, ch, 0);
                foreach (char C in ch)
                {
                    this.textBox3.Text += C;

                }

                sr.Close();
            }

            else
            {
                MessageBox.Show("File not Exist");
            }

           
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            comboBox1.Text = "Select Extension";
            string[] extension = { ".txt" };
            comboBox1.Items.AddRange(extension);
            this.textBox3.ScrollBars = ScrollBars.Both;
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form6 f6 = new Form6();
            f6.Show();
        }

        private void button3_Click(object sender, EventArgs e)
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
    }
}
