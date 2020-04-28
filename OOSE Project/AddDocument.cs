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
    public partial class AddDocument : Form
    {
        public AddDocument()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "C:/Users/Deepang/source/repos/OOSE Project/OOSE Project/Uploads";
            openFileDialog1.Title = "Select file to be upload.";
            openFileDialog1.Filter = "Document|*.pdf; *.jpg; *.png; *.jpeg; *.gif";
            openFileDialog1.FilterIndex = 1;
            try
            {
                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (openFileDialog1.CheckFileExists)
                    {
                        string path = System.IO.Path.GetFullPath(openFileDialog1.FileName);
                    }
                }
                else
                {
                    MessageBox.Show("Please Upload document.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string filename = System.IO.Path.GetFileName(openFileDialog1.FileName);
                if (filename == null)
                {
                    MessageBox.Show("Please select a valid document.");
                }
                else
                {
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Deepang\source\repos\OOSE Project\OOSE Project\DTC.mdf; Integrated Security = True";
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "INSERT INTO DOCUMENTS (DocName, DocDesc, DocPath, DocType, UId)" +
                        "VALUES (@DName, @DDesc, @DPath, @DType, @Uid)";
                    cmd.Parameters.AddWithValue("@DName", textBox1.Text);
                    cmd.Parameters.AddWithValue("@DDesc", textBox2.Text);
                    cmd.Parameters.AddWithValue("@DPath", "C:/Users/Deepang/source/repos/OOSE Project/OOSE Project" + filename);
                    cmd.Parameters.AddWithValue("@DType", textBox4.Text);
                    cmd.Parameters.AddWithValue("@Uid", Documents.uid1);
                    cmd.Connection = con;
                    string path = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
                    System.IO.File.Copy(openFileDialog1.FileName, path + filename);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Document uploaded.");
                    Documents doc = new Documents();
                    doc.Show();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddDocument_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void AddDocument_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Documents doc = new Documents();
            doc.Show();
            this.Hide();
        }
    }
}
