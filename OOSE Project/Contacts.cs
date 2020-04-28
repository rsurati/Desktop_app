using System;
using System.Collections;
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
    public partial class Contacts : Form
    {
        public static string uid = "";
        public static string cid = "";
        public static ArrayList al = new ArrayList();
        public Contacts()
        {
            InitializeComponent();
        }

        private void Contacts_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Deepang\source\repos\OOSE Project\OOSE Project\DTC.mdf; Integrated Security = True";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select Id from users where Email=@email";
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@email", Login.uname);
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read()) {
                uid = rdr["Id"].ToString();
            }
            rdr.Close();
            con.Close();
            DataTable dt = new DataTable();
            dt.Columns.Add("Fname");
            dt.Columns.Add("Lname");
            dt.Columns.Add("C_Email");
            dt.Columns.Add("EmergencyContact");
            con.Open();
            SqlCommand cmd1 = new SqlCommand();
            cmd1.CommandText = "select Contact_Id as Cid from ContactInfo where User_Id=@user";
            cmd1.Connection = con;
            cmd1.Parameters.AddWithValue("@user", uid);
            
            SqlDataReader rdr1 = cmd1.ExecuteReader();
            al = new ArrayList();
            while (rdr1.Read())
            {
                al.Add(rdr1["Cid"].ToString());
            }
            rdr1.Close();
            con.Close();
            SqlCommand cmd2 = new SqlCommand();
            foreach(string id in al)
            {
                cmd2.Parameters.Clear();
                con.Open();
                cmd2.CommandText = "select Fname,Lname,C_Email,EmergencyContact from Contacts where Id=@Cid1";
                cmd2.Connection = con;
                cmd2.Parameters.AddWithValue("@Cid1", id);
                SqlDataReader rdr2 = cmd2.ExecuteReader();
                while (rdr2.Read())
                {
                    dt.Rows.Add(rdr2["Fname"].ToString(), rdr2["Lname"].ToString(), rdr2["C_Email"].ToString(), rdr2["EmergencyContact"].ToString());
                }
                rdr2.Close();
                con.Close();
            }
            con.Open();

            dataGridView1.AutoGenerateColumns = false;

            
            dataGridView1.ColumnCount = 4;

            
            dataGridView1.Columns[0].Name = "Fname";
            dataGridView1.Columns[0].HeaderText = "First Name";
            dataGridView1.Columns[0].DataPropertyName = "Fname";

            dataGridView1.Columns[1].HeaderText = "Last Name";
            dataGridView1.Columns[1].Name = "Lname";
            dataGridView1.Columns[1].DataPropertyName = "Lname";

            dataGridView1.Columns[2].Name = "C_Email";
            dataGridView1.Columns[2].HeaderText = "Email";
            dataGridView1.Columns[2].DataPropertyName = "C_Email";

            dataGridView1.Columns[3].Name = "EmergencyContact";
            dataGridView1.Columns[3].HeaderText = "Emergency Contact";
            dataGridView1.Columns[3].DataPropertyName = "EmergencyContact";
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void Contacts_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                cid = al[e.RowIndex].ToString();
                SingleContact sc = new SingleContact();
                sc.Show();
                this.Hide();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Homepage hp = new Homepage();
            hp.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddContact ad = new AddContact();
            ad.Show();
            this.Hide();
        }
    }
}
