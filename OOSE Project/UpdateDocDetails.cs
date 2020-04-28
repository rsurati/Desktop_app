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

namespace OOSE_Project
{
    public partial class UpdateDocDetails : Form
    {
        public UpdateDocDetails()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string field = listBox1.SelectedItem.ToString();
            string di = Documents.did;
            string n = textBox1.Text;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Deepang\source\repos\OOSE Project\OOSE Project\DTC.mdf; Integrated Security = True";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "UPDATE CONTACTS SET " + field + " = @new WHERE Id = @did";
            cmd.Parameters.AddWithValue("@did", di);
            cmd.Parameters.AddWithValue("@new", n);
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            SingleDocument sd = new SingleDocument();
            sd.Show();
            this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SingleDocument sd = new SingleDocument();
            sd.Show();
            this.Hide();
        }

        private void UpdateDocDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void UpdateDocDetails_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }
    }
}
