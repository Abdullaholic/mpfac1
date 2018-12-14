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
    public partial class mainmenu : Form
    {
        public mainmenu()
        {
            InitializeComponent();
        }

        private void btnslide_Click_1(object sender, EventArgs e)
        {
            if (MenuVertical.Width == 250)
            {
                MenuVertical.Width = 70;
            }
            else
                MenuVertical.Width = 250;

        }

        private void iconcerrar_Click(object sender, EventArgs e)
        {
            {
                Application.Exit();
            }
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
        private void AbrirForminPanel(object Formhijo)
        {
            if (this.panel2.Controls.Count > 0)
                this.panel2.Controls.RemoveAt(0);
            Form fh = Formhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panel2.Controls.Add(fh);
            this.panel2.Tag = fh;
            fh.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            AbrirForminPanel(new tab2());
        }
    }
}
