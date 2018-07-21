using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MYGAME
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
            if (textBox1.Text == "zafir" && textBox2.Text == "123")
            {
                MessageBox.Show("Login Successfully");
                Form2 f2 = new Form2();
                f2.Show();
            }
            else { MessageBox.Show("Password not correct"); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
