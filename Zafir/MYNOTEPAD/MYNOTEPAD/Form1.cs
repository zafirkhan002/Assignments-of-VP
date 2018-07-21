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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            openFileDialog1.Filter = "All text(*.txt) | *.txt     ";

            this.MaximizeBox = true;
            this.textBox1.CharacterCasing = CharacterCasing.Normal;
            this.textBox1.WordWrap = false;
            this.ShowIcon = true;
            this.Text = "Notepad";
            this.cutToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.X;
            this.copyToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.C;
            this.pasteToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.V;
            this.findToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.F;
            this.deleteToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.D;
            this.replaceToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.H;
            this.goToToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.G;
            this.selectAllToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.A;
            this.timeDateToolStripMenuItem.ShortcutKeys = Keys.F5;
            this.newToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.N;
            this.saveAsToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            this.openToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            this.printToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.P;

        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            this.textBox1.Multiline = true;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.textBox1.ScrollBars = ScrollBars.Both;

            this.textBox1.CharacterCasing = CharacterCasing.Lower;
            this.textBox1.TextAlign = HorizontalAlignment.Left;
            this.textBox1.Multiline = true;

        }

        private void wordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (wordWrapToolStripMenuItem.Checked == false)
            {
                this.wordWrapToolStripMenuItem.Checked = true;
                this.textBox1.WordWrap = true;
            }
            else if (wordWrapToolStripMenuItem.Checked == true)
            {
                this.wordWrapToolStripMenuItem.Checked = false;
                this.textBox1.WordWrap = false;

            }
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.textBox1.Cut();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.textBox1.Paste();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.textBox1.Copy();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.textBox1.Cut();
        }

        private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Replace rp = new Replace(this);
            rp.Show();

           
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.textBox1.SelectAll();
        }

        private void withColorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.fontDialog1.ShowColor = true;
            DialogResult dr = this.fontDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                this.textBox1.Font = this.fontDialog1.Font;
                this.textBox1.ForeColor = this.fontDialog1.Color;
            }
        }

        private void regularToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.withColorsToolStripMenuItem.Checked = false;
            this.withColorsToolStripMenuItem.Enabled = true;
            DialogResult dr = this.fontDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                this.textBox1.Font = this.fontDialog1.Font;
            }
        }

        private void colorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = this.colorDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                this.textBox1.ForeColor = this.colorDialog1.Color;

            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.saveFileDialog1.ShowDialog();
            saveFileDialog1.Filter = "Save File *.txt |*.txt";
            DialogResult dr = this.saveFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                string fname = saveFileDialog1.FileName;
                File.WriteAllText(fname, this.textBox1.Text);
                this.textBox1.Text = "";

            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Open File *.txt |*.txt";
            this.openFileDialog1.ShowDialog();
            DialogResult dr = this.openFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                string fname = openFileDialog1.FileName;
                this.textBox1.Text = File.ReadAllText(fname);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.saveFileDialog1.ShowDialog();
            saveFileDialog1.Filter = "Save File *.txt |*.txt";
            DialogResult dr = this.saveFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                string fname = saveFileDialog1.FileName;
                File.WriteAllText(fname, this.textBox1.Text);


            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Save File *.txt |*.txt";

            DialogResult dr = this.saveFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                string fname = saveFileDialog1.FileName;
                File.WriteAllText(fname, this.textBox1.Text);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Find f2 = new Find(this);
            f2.Show();
           
        }
    }
}
