using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace mpfac
{
    public partial class Form2 : Form
    {
        
        public Form2()
        {
            InitializeComponent();
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.WindowState = FormWindowState.Maximized;
            
            
        }
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void btnslide_Click(object sender, EventArgs e)
        {
            if (MenuVertical.Width == 250)
            {
                MenuVertical.Width = 0;
            }
            else
                MenuVertical.Width = 250;
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

        private void MenuHori_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void AbrirForminPanel(object Formhijo)
        {
            if (this.ContainerPanel.Controls.Count > 0)
                this.ContainerPanel.Controls.RemoveAt(0);
            Form fh = Formhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.ContainerPanel.Controls.Add(fh);
            this.ContainerPanel.Tag = fh;
            fh.Show();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            recentlabel.Hide();
            recentlist.Hide();
            AbrirForminPanel(new Tabs());
            
            //mainmenu objfrmMain = new mpfac.mainmenu();
            //this.Hide();
            //objfrmMain.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mainmenu objfrmMain = new mpfac.mainmenu();
            this.Hide();
            objfrmMain.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            admin objfrmMain = new mpfac.admin();
            this.Hide();
            objfrmMain.Show();
        }

        private void iconmini_MouseEnter(object sender, EventArgs e)
        {
            iconmini.BackColor = Color.CadetBlue;
        }

        private void iconmini_MouseLeave(object sender, EventArgs e)
        {
            iconmini.BackColor = Color.Black;
        }


        private void iconrestore_MouseLeave(object sender, EventArgs e)
        {
            iconrestore.BackColor = Color.Black;
        }

        private void iconcerrar_MouseEnter(object sender, EventArgs e)
        {
            iconcerrar.BackColor = Color.Red;
        }

        private void iconcerrar_MouseLeave(object sender, EventArgs e)
        {
            iconcerrar.BackColor = Color.Black;
        }

        private void iconmaxi_MouseEnter(object sender, EventArgs e)
        {
            iconmaxi.BackColor = Color.CadetBlue;
        }

        private void iconmaxi_MouseLeave(object sender, EventArgs e)
        {
            iconmaxi.BackColor = Color.Black;
        }

        private void iconrestore_MouseEnter(object sender, EventArgs e)
        {
            iconrestore.BackColor = Color.CadetBlue;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'mPSDBDataSet1.Mission' table. You can move, or remove it, as needed.
            this.missionTableAdapter1.Fill(this.mPSDBDataSet1.Mission);
            // TODO: This line of code loads data into the 'mPSDBDataSet.Mission' table. You can move, or remove it, as needed.
            this.missionTableAdapter.Fill(this.mPSDBDataSet.Mission);

        }
    }
}
