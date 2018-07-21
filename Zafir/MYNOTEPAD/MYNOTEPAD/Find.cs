using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MYNOTEPAD
{
    public partial class Find : Form
    {
        Form1 f1;
        public Find(Form1 ff)
        {
            f1 = ff;
            InitializeComponent();
        }

        private void Find_Load(object sender, EventArgs e)
        {
            this.button1.Text = "Find";
            this.Text = "FIND";
            
        }

       
        

       
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (f1.textBox1.Text.Contains(this.textBox1.Text))
            {
                MessageBox.Show("  Find Successfully", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Not Found!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
        }
    }
}
