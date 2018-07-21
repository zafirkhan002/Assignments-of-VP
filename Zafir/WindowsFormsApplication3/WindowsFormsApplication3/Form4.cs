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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            comboBox1.Text = "Select Extension";
            string[] extension = { ".txt" };
            comboBox1.Items.AddRange(extension);
            this.textBox3.ScrollBars = ScrollBars.Both;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string s = textBox1.Text + textBox2.Text+comboBox1.Text;
            string d = textBox1.Text + textBox2.Text + comboBox1.Text;
            if (File.Exists(s))
            {

                DialogResult dr = MessageBox.Show("File already Exist You want to replace file", "", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.OK)
                {
                    File.Delete(d);
                  
                    StreamWriter sw = new StreamWriter(textBox1.Text + textBox2.Text + comboBox1.Text);
                    sw.Write(this.textBox3.Text);
                    MessageBox.Show("File saved");
                    sw.Close();

                }
              

            }
            else
            {
                StreamWriter sw = new StreamWriter(textBox1.Text + textBox2.Text + comboBox1.Text);
                sw.Write(this.textBox3.Text);
                MessageBox.Show("File write");
                sw.Close();
               
            }
           
        }
    }
}
