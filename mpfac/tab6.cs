using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mpfac
{
    public partial class tab6 : Form
    {
        public tab6()
        {
            InitializeComponent();
        }

        private void iconcerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
     
        private void iconmaxi_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            iconrestore.Visible = true;
            iconmaxi.Visible = false;
        }

        private void iconrestore_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            iconrestore.Visible = false;
            iconmaxi.Visible = true;
        }


        private void iconmini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label120_Click(object sender, EventArgs e)
        {

        }
    }
}
