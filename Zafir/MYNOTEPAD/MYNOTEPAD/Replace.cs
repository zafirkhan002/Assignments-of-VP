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

namespace MYNOTEPAD
{
    public partial class Replace : Form
    {
        Form1 f1;
        public Replace(Form1 ff1)
        {
            f1 = ff1;
            InitializeComponent();
        }

        private void Replace_Load(object sender, EventArgs e)
        {
            this.label1.Text = "Find What";
            this.label2.Text = "Replace with";
            this.button2.Text = "Replace";
            this.button1.Text = "Cancel";
            this.button3.Text = "Clear";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.textBox1.Clear();
            this.textBox2.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            f1.textBox1.Text = f1.textBox1.Text.Replace(this.textBox1.Text, this.textBox2.Text);
            this.Close();
        }
    }
}
