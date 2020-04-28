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
    public partial class Documents : Form
    {
        public static string uid1 = "";
        public static string did = "";
        public static ArrayList al = new ArrayList();
        public Documents()
        {
            InitializeComponent();
        }

        private void Documents_Load(object sender, EventArgs e)
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
            while (rdr.Read())
            {
                uid1 = rdr["Id"].ToString();
            }
            rdr.Close();
            con.Close();
            DataTable dt = new DataTable();
            dt.Columns.Add("DocName");
            dt.Columns.Add("DocDesc");
            con.Open();
            SqlCommand cmd1 = new SqlCommand();
            cmd1.CommandText = "select Id from Documents where UId=@user";
            cmd1.Connection = con;
            cmd1.Parameters.AddWithValue("@user", uid1);

            SqlDataReader rdr1 = cmd1.ExecuteReader();
            al = new ArrayList();
            while (rdr1.Read())
            {
                al.Add(rdr1["Id"].ToString());
            }
            rdr1.Close();
            con.Close();
            SqlCommand cmd2 = new SqlCommand();
            foreach (string id in al)
            {
                cmd2.Parameters.Clear();
                con.Open();
                cmd2.CommandText = "select DocName,DocDesc from Documents where Id=@Cid1";
                cmd2.Connection = con;
                cmd2.Parameters.AddWithValue("@Cid1", id);
                SqlDataReader rdr2 = cmd2.ExecuteReader();
                while (rdr2.Read())
                {
                    dt.Rows.Add(rdr2["DocName"].ToString(), rdr2["DocDesc"].ToString());
                }
                rdr2.Close();
                con.Close();
            }
            con.Open();

            dataGridView1.AutoGenerateColumns = false;


            dataGridView1.ColumnCount = 2;


            dataGridView1.Columns[0].Name = "DocName";
            dataGridView1.Columns[0].HeaderText = "Document Name";
            dataGridView1.Columns[0].DataPropertyName = "DocName";

            dataGridView1.Columns[1].HeaderText = "Document Description";
            dataGridView1.Columns[1].Name = "DocDesc";
            dataGridView1.Columns[1].DataPropertyName = "DocDesc";

            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void Documents_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                did = al[e.RowIndex].ToString();
                SingleDocument sd = new SingleDocument();
                sd.Show();
                this.Hide();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddDocument ad = new AddDocument();
            ad.Show();
            this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Homepage hp = new Homepage();
            hp.Show();
            this.Hide();
        }
    }
}
