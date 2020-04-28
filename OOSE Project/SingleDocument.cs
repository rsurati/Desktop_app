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
    public partial class SingleDocument : Form
    {
        public static string dp = "";
        public static string doctype = "";
        public SingleDocument()
        {
            InitializeComponent();
        }

        private void SingleDocument_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Deepang\source\repos\OOSE Project\OOSE Project\DTC.mdf; Integrated Security = True";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select DocName,DocDesc,DocPath,DocType from Documents where Id=@id";
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@id", Documents.did);
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                label9.Text = rdr["DocName"].ToString();
                label10.Text = rdr["DocDesc"].ToString();
                label12.Text = rdr["DocType"].ToString();
                doctype = label12.Text;
                dp = rdr["DocPath"].ToString();
            }
            rdr.Close();
            con.Close();
        }

        private void SingleDocument_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Documents doc = new Documents();
            doc.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (doctype.Equals("JPG       ") || doctype.Equals("PNG       ") || doctype.Equals("JPEG      ") || doctype.Equals("GIF       "))
            {
                ViewImage vi = new ViewImage();
                vi.Show();
                this.Hide();
            }
            if (doctype.Equals("PDF       "))
            {
                string filePath = dp;
                string adobeReaderPath = @"C:\ProgramData\Microsoft\Windows\Start Menu\Programs\Acrobat Reader DC.lnk";
                System.Diagnostics.Process.Start(adobeReaderPath, filePath);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string did = Documents.did;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Deepang\source\repos\OOSE Project\OOSE Project\DTC.mdf; Integrated Security = True";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "DELETE FROM DOCUMENTS WHERE Id = @Did";
            cmd.Parameters.AddWithValue("@Did", did);
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            Documents doc = new Documents();
            doc.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpdateDocDetails ud = new UpdateDocDetails();
            ud.Show();
            this.Hide();
        }
    }
}
