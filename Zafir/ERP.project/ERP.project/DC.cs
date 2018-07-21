﻿using System;
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
    public partial class DC : Form
    {
        Form1 conn = new Form1();
        public DC()
        {
            InitializeComponent();
        }

        private void DC_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            int c = 0;
            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("select count(DCID) from DelChalan ", conn.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                c = Convert.ToInt32(dr[0]);
                c++;
            }

            textBox4.Text = "DC-0" + c.ToString() + "-" + System.DateTime.Today.Year;


            OleDbCommand cmd1 = new OleDbCommand("Select SOID from SO where Status = 'OPEN' ", conn.oleDbConnection1);
            OleDbDataReader dr1 = cmd1.ExecuteReader();
            while (dr1.Read())
            {
                comboBox1.Items.Add(dr1["SOID"]).ToString();
            }

            conn.oleDbConnection1.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Select *from SO where SOID ='" + comboBox1.Text + "' ", conn.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                textBox1.Text = dr["CID"].ToString();
                textBox2.Text = dr["CName"].ToString();
                textBox3.Text = dr["SODate"].ToString();
               // textBox5.Text = dr["DDate"].ToString();

            }

            OleDbDataAdapter da = new OleDbDataAdapter("Select  *from SOProducts ", conn.oleDbConnection1);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.oleDbConnection1.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Insert into DelChalan(DCID,SOID,Status,CName,DDate,DCDate,CID) values(@DCID,@SOID,@Status,@CName,@DDate,@DCDate,@CID)", conn.oleDbConnection1);
            cmd.Parameters.AddWithValue("@DCID", textBox4.Text);
            cmd.Parameters.AddWithValue("@SOID", comboBox1.Text);
            cmd.Parameters.AddWithValue("@Status", "CLOSE");
            cmd.Parameters.AddWithValue("@CName", textBox2.Text);
            cmd.Parameters.AddWithValue("@DDate", textBox3.Text);
            cmd.Parameters.AddWithValue("@DCate", dateTimePicker1);
            cmd.Parameters.AddWithValue("@CID", textBox1.Text);
            cmd.ExecuteNonQuery();

            conn.oleDbConnection1.Close();
            MessageBox.Show("TRANSACTION COMPLETED");
        }
    }
}
