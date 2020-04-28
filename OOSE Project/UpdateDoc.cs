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
    public partial class UpdateDoc : Form
    {
        public UpdateDoc()
        {
            InitializeComponent();
        }

        private void UpdateDoc_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void UpdateDoc_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }
    }
}
