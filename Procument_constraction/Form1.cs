using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Procument_constraction
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=VIVOBOOK\\ASHIMI;Initial Catalog=CSSE;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            LoadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Form2().Show();
            this.Hide();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            comboBox1.ResetText();
            comboBox2.ResetText();
            dateTimePicker1.ResetText();
            textBox8.Clear();
            textBox1.Focus();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Insert Logic
            con.Open();

            cmd = new SqlCommand(@"INSERT INTO [dbo].[Employee]
           ([EmployeeID]
           ,[EmployeeNIC]
           ,[FirstName]
           ,[LastName]
           ,[Salary]
           ,[Designation]
           ,[Dlevel]
           ,[PhoneNumber]
           ,[DOB])
     VALUES
           ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + comboBox1.Text + "','" + comboBox2.Text + "','" + textBox8.Text + "','" + dateTimePicker1.Text + "')", con);
            cmd.ExecuteNonQuery();
            con.Close();

            //Reading Data
            LoadData();
        }

        private void LoadData()
        {
            sda = new SqlDataAdapter("Select * From [dbo].[Employee]", con);
            dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.Rows.Clear();
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = item["EmployeeID"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item["EmployeeNIC"].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item["FirstName"].ToString();
                dataGridView1.Rows[n].Cells[3].Value = item["LastName"].ToString();
                dataGridView1.Rows[n].Cells[4].Value = item["Salary"].ToString();
                dataGridView1.Rows[n].Cells[5].Value = item["Designation"].ToString();
                dataGridView1.Rows[n].Cells[6].Value = item["Dlevel"].ToString();
                dataGridView1.Rows[n].Cells[7].Value = item["PhoneNumber"].ToString();
                dataGridView1.Rows[n].Cells[8].Value = item["DOB"].ToString();
            }
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            comboBox2.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            textBox8.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            dateTimePicker1.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
        }

        private void displaydata()
        {
            con.Open();
            sda = new SqlDataAdapter("Select * From [dbo].[Employee]", con);
            dt = new DataTable();
            con.Close();
            
        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            
                try
                {
                    con.Open();
                    cmd = new SqlCommand("UPDATE [Employee] SET [EmployeeNIC] = '" + textBox2.Text + "' ,[FirstName] = '" + textBox3.Text + "' ,[LastName] = '" + textBox4.Text + "' ,[Salary] = '" + textBox5.Text + "' ,[Designation] = '" + comboBox1.Text + "' ,[Dlevel] = '" + comboBox2.Text + "' ,[PhoneNumber] = '" + textBox8.Text + "' ,[DOB] = '" + dateTimePicker1.Text + "' WHERE [EmployeeID] = '" + textBox1.Text + "'", con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record updated.");
                    con.Close();
                    LoadData();
                }

                catch (Exception)
                {
                    throw;
                }
            

            button2.FlatAppearance.BorderSize = 0;

            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("DELETE FROM [Employee] WHERE [EmployeeID] = '" + textBox1.Text + "'", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record deleted.");
                con.Close();
                LoadData();
            }

            catch (Exception)
            {
                throw;
            }
        }

    }
}
