using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOSE_Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            Thread t = new Thread(new ThreadStart(StartForm));
            t.Start();
            Thread.Sleep(5000);
            InitializeComponent();
            t.Abort();
        }
        public void StartForm()
        {
            Application.Run(new SplashScreen());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Docs - ToDo - Contacts - master\OOSE Project\DTC_new.mdf;Integrated Security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "INSERT INTO USERS (FName, LName, Email, Mobile_Number, Birthday, Address, Occupation, Password)" +
                "VALUES (@FName, @LName, @Email, @Mobile_Number, @Birthday, @Address, @Occupation, @Pass)";
            cmd.Parameters.AddWithValue("@FName", textBox1.Text);
            cmd.Parameters.AddWithValue("@LName", textBox2.Text);
            cmd.Parameters.AddWithValue("@Email", textBox3.Text);
            cmd.Parameters.AddWithValue("@Mobile_Number", textBox4.Text);
            cmd.Parameters.AddWithValue("@Birthday", textBox5.Text);
            cmd.Parameters.AddWithValue("@Address", textBox6.Text);
            cmd.Parameters.AddWithValue("@Occupation", textBox7.Text);
            cmd.Parameters.AddWithValue("@Pass", textBox8.Text);
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            label10.Text = "Registration Successful";
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }
    }
}