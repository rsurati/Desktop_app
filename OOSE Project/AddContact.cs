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
    public partial class AddContact : Form
    {
        public static string lid = "";
        public AddContact()
        {
            InitializeComponent();
        }

        private void AddContact_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Deepang\source\repos\OOSE Project\OOSE Project\DTC.mdf; Integrated Security = True";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "INSERT INTO CONTACTS (Fname, Lname, C_Email, Contact_Number, C_Birthday, C_Address, C_Occupation, EmergencyContact)" +
                "OUTPUT INSERTED.ID VALUES (@FName, @LName, @Email, @Mobile_Number, @Birthday, @Address, @Occupation, @EM)";
            cmd.Parameters.AddWithValue("@FName", textBox1.Text);
            cmd.Parameters.AddWithValue("@LName", textBox2.Text);
            cmd.Parameters.AddWithValue("@Email", textBox3.Text);
            cmd.Parameters.AddWithValue("@Mobile_Number", textBox4.Text);
            cmd.Parameters.AddWithValue("@Birthday", textBox5.Text);
            cmd.Parameters.AddWithValue("@Address", textBox6.Text);
            cmd.Parameters.AddWithValue("@Occupation", textBox7.Text);
            cmd.Parameters.AddWithValue("@EM", "No");
            cmd.Connection = con;
            con.Open();
            lid = cmd.ExecuteScalar().ToString();
            con.Close();
            cmd.CommandText = "INSERT INTO CONTACTINFO (User_Id, Contact_Id) VALUES (@uid, @cid)";
            cmd.Parameters.AddWithValue("@uid", Contacts.uid);
            cmd.Parameters.AddWithValue("@cid", lid);
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Contacts co = new Contacts();
            co.Show();
            this.Hide();
        }

        private void AddContact_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Contacts co = new Contacts();
            co.Show();
            this.Hide();
        }
    }
}