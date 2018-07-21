using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace ERP.project
{
    public partial class Form2 : Form
    {
        Form1 conn = new Form1();
        public Form2()
        {
            
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.panel2.Visible = false; 
            this.panel1.Visible = true;
            //this.panel1.Show();
            //this.button20.Visible = true;
            //this.button24.Visible = true;
            //this.button28.Visible = true;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form7 f7 = new Form7();
            f7.Show();
  
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form9 f9 = new Form9();
            f9.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form8 f9 = new Form8();
            f9.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //this.panel2.Show();
            this.panel1.Visible = false;
            this.panel2.Visible = true;

            //this.Hide();
            //Form10 f10 = new Form10();
            //f10.Show();
           
        }

        private void button6_Click(object sender, EventArgs e)
        {

            Application.Exit();
            
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.panel1.Visible = false;
            this.panel2.Visible = false;
            //this.button20.Visible = false;
            //this.button24.Visible = false;
            //this.button28.Visible = false;

        }

        private void vENDERToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pOToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void gRNToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void gRNRecieverToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {

        }

        private void button18_Click(object sender, EventArgs e)
        {

        }

        private void button25_Click(object sender, EventArgs e)
        {

        }

        private void button26_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {

        }

        private void button23_Click(object sender, EventArgs e)
        {

        }

        private void button22_Click(object sender, EventArgs e)
        {

        }

        private void button21_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {

        }

        private void button19_Click(object sender, EventArgs e)
        {

        }

        private void button27_Click(object sender, EventArgs e)
        {

        }

        private void button20_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 f4 = new Form4();
            f4.Show();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 f3 = new Form3();
            f3.Show();
        }

        private void button28_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form5 f3 = new Form5();
            f3.Show();
            
        }

        private void button29_Click(object sender, EventArgs e)
        {
            this.Hide();
           
            so s = new so();
            s.Show();
        }

        private void button31_Click(object sender, EventArgs e)
        {
            this.Hide();
            DC dc = new DC();
            dc.Show();

        }

        private void button30_Click(object sender, EventArgs e)
        {
            this.Hide();
            invorec ic = new invorec();
            ic.Show();
        }

        private void button33_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form10 f10 = new Form10();
            f10.Show();
        }

        private void button34_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form11 f11 = new Form11();
            f11.Show();
        }

        private void button32_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form13 f13 = new Form13();
            f13.Show();

        }
    }
}
