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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            pictureBox1.Enabled = false;
            pictureBox2.Enabled = false;
            pictureBox3.Enabled = false;
            pictureBox4.Enabled = false;
            pictureBox5.Enabled = false;
            pictureBox6.Enabled = false;
            pictureBox7.Enabled = false;
            pictureBox8.Enabled = false;
            pictureBox8.Enabled = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.pictureBox1.Image = this.pictureBox3.Image;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

            this.pictureBox5.Image = this.pictureBox6.Image;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
           // this.pictureBox5.Image = this.pictureBox6.Image;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.pictureBox4.Image = this.pictureBox6.Image;
            this.pictureBox4.Image = this.pictureBox5.Image;
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            this.pictureBox9.Image = this.pictureBox8.Image;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            //if (this.pictureBox8.Image == this.pictureBox6.Image)
            //{
                
           // }
            this.pictureBox7.Image = this.pictureBox8.Image;
            MessageBox.Show("You Loose the game Play Again");
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            pictureBox8.Image = pictureBox1.Image;
            //&& pictureBox4.Image == pictureBox2.Image
                MessageBox.Show("You Won the Game Congratues");

            
            //else 
            //{
            //    MessageBox.Show("You Loose the game Play Again");
            //    pictureBox1.Enabled = false;
            //    pictureBox2.Enabled = false;
            //    pictureBox3.Enabled = false;
            //    pictureBox4.Enabled = false;
            //    pictureBox5.Enabled = false;
            //    pictureBox6.Enabled = false;
            //    pictureBox7.Enabled = false;
            //    pictureBox8.Enabled = false;
            //    pictureBox8.Enabled = false;
            
            //}

           
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Start Game!");
            pictureBox1.Enabled = true;
            pictureBox2.Enabled = true;
            pictureBox3.Enabled = true;
            pictureBox4.Enabled = true;
            pictureBox5.Enabled = true;
            pictureBox6.Enabled = true;
            pictureBox7.Enabled = true;
            pictureBox8.Enabled = true;
            pictureBox8.Enabled = true;

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.pictureBox2.Image = this.pictureBox4.Image;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.pictureBox3.Image = this.pictureBox4.Image;
        }
    }
}
