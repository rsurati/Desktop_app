using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOSE_Project
{
    public partial class ViewImage : Form
    {
        public ViewImage()
        {
            InitializeComponent();
        }

        private void ViewImage_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void ViewImage_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            pictureBox1.Image = new Bitmap(SingleDocument.dp);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SingleDocument sd = new SingleDocument();
            sd.Show();
            this.Hide();
        }
    }
}
