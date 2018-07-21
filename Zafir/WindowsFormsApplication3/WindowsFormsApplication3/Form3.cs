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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string s = textBox1.Text + textBox2.Text + comboBox1.Text;
            string d = textBox1.Text + textBox2.Text + comboBox1.Text;
            if (File.Exists(s))
            {

                DialogResult dr = MessageBox.Show("File already Exist You want to replace file","",MessageBoxButtons.OKCancel);
                if (dr == DialogResult.OK)
                {
                    File.Delete(d);

                    FileStream fs = new FileStream(s, FileMode.OpenOrCreate, FileAccess.Write);
                    byte[] bb = new byte[2000];
                    char[] ch = new char[2000];
                    ch = this.textBox3.Text.ToCharArray();
                    Encoder enn = Encoding.UTF8.GetEncoder();
                    enn.GetBytes(ch, 0, ch.Length, bb, 0, true);
                    fs.Write(bb, 0, 100);
                     MessageBox.Show("File written");
                     fs.Close();

                }
               
             }

            else
            {
                string fname = textBox1.Text + textBox2.Text + comboBox1.Text;
                FileStream fs = new FileStream(fname, FileMode.OpenOrCreate, FileAccess.Write);
                byte[] bb = new byte[5000];
                char[] ch = new char[5000];
                ch = this.textBox3.Text.ToCharArray();
                Encoder enn = Encoding.UTF8.GetEncoder();
                enn.GetBytes(ch, 0, ch.Length, bb, 0, true);
                fs.Write(bb, 0, 100);
               
                MessageBox.Show("File written");

                fs.Close();   
            }
          

            
                
           }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            comboBox1.Text = "Select Extension";
            string[] extension = { ".txt" };
            comboBox1.Items.AddRange(extension);
            this.textBox3.ScrollBars = ScrollBars.Both;
        }
    }
}
