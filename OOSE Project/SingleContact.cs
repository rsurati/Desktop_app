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
    public partial class SingleContact : Form
    {
        public SingleContact()
        {
            InitializeComponent();
        }

        private void SingleContact_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Deepang\source\repos\OOSE Project\OOSE Project\DTC.mdf; Integrated Security = True";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select Fname,Lname,C_Email,Contact_Number,C_Birthday,C_Address,C_Occupation,EmergencyContact from Contacts where Id=@id";
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@id", Contacts.cid);
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                label9.Text = rdr["Fname"].ToString();
                label10.Text = rdr["Lname"].ToString();
                label11.Text = rdr["C_Email"].ToString();
                label12.Text = rdr["Contact_Number"].ToString();
                label13.Text = rdr["C_Birthday"].ToString();
                label14.Text = rdr["C_Address"].ToString();
                label15.Text = rdr["C_Occupation"].ToString();
                label16.Text = rdr["EmergencyContact"].ToString();
            }
            rdr.Close();
            con.Close();
        }

        private void SingleContact_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Contacts co = new Contacts();
            co.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string ci = Contacts.cid;
            string ui = Contacts.uid;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Deepang\source\repos\OOSE Project\OOSE Project\DTC.mdf; Integrated Security = True";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "DELETE FROM CONTACTINFO WHERE Contact_Id = @cid and User_Id = @uid";
            cmd.Parameters.AddWithValue("@cid", ci);
            cmd.Parameters.AddWithValue("@uid", ui);
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            cmd.Parameters.Clear();
            cmd.CommandText = "DELETE FROM CONTACTS WHERE Id = @cid";
            cmd.Parameters.AddWithValue("@cid", ci);
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            Contacts co = new Contacts();
            co.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string ci = Contacts.cid;
            string isEmer = "";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Deepang\source\repos\OOSE Project\OOSE Project\DTC.mdf; Integrated Security = True";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT EmergencyContact FROM CONTACTS WHERE Id = @cid1";
            cmd.Parameters.AddWithValue("@cid1", ci);
            cmd.Connection = con;
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                isEmer = rdr["EmergencyContact"].ToString();
            }
            rdr.Close();
            con.Close();
            cmd.CommandText = "UPDATE CONTACTS SET EmergencyContact = @emer WHERE Id = @cid";
            cmd.Parameters.AddWithValue("@cid", ci);
            if (isEmer.Equals("No        "))
            {
                cmd.Parameters.AddWithValue("@emer", "Yes");
            }
            if (isEmer.Equals("Yes       "))
            {
                cmd.Parameters.AddWithValue("@emer", "No");
            }
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            SingleContact sc = new SingleContact();
            sc.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateContact uc = new UpdateContact();
            uc.Show();
            this.Hide();
        }
    }
}
