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
    public partial class UpdateContact : Form
    {
        public UpdateContact()
        {
            InitializeComponent();
        }

        private void UpdateContact_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }

        private void UpdateContact_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string field = listBox1.SelectedItem.ToString();
            string ci = Contacts.cid;
            string n = textBox1.Text;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Deepang\source\repos\OOSE Project\OOSE Project\DTC.mdf; Integrated Security = True";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "UPDATE CONTACTS SET "+ field +" = @new WHERE Id = @cid";
            cmd.Parameters.AddWithValue("@cid", ci);
            cmd.Parameters.AddWithValue("@new", n);
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            SingleContact sc = new SingleContact();
            sc.Show();
            this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SingleContact sc = new SingleContact();
            sc.Show();
            this.Hide();
        }
    }
}
