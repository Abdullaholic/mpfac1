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
using System.Data.SqlClient;
namespace mpfac
{
    public partial class Form1 : Form
    {


        SqlDataAdapter sda;
        DataTable dtbl;
        public Form1()
        {
            InitializeComponent();
        }
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void txtuser_Enter(object sender, EventArgs e)
        {
            if(txtuser.Text == "USERNAME")
            {
                txtuser.Text = "";
                txtuser.ForeColor = Color.Black;

            }
        }
        private void txtuser_Leave(object sender, EventArgs e)
        {
            if (txtuser.Text == "")
            {
                txtuser.Text = "USERNAME";
                txtuser.ForeColor = Color.DimGray;
            }
        }

        private void txtpass_Enter(object sender, EventArgs e)
        {
          if  (txtpass.Text == "PASSWORD")
            {
                txtpass.Text = "";
                txtpass.ForeColor = Color.Black;
                txtpass.UseSystemPasswordChar = true;
            }
        }

        private void txtpass_Leave(object sender, EventArgs e)
        {
            if (txtpass.Text == "")
            {
                txtpass.Text = "PASSWORD";
                txtpass.ForeColor = Color.DimGray;
                txtpass.UseSystemPasswordChar = false;
            }
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\FYP\Visual Studio 2015\Projects\WindowsFormsApplication5\DB\MPSDB.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            string query = "select * from sup where yup = '" + txtuser.Text.Trim() + "'";
            sda = new SqlDataAdapter(query, con);
            dtbl = new DataTable();
            sda.Fill(dtbl);



            con.Close();
            if (dtbl.Rows.Count == 1)
            {
                MessageBox.Show("Welcome " + txtuser.Text);

                Form2 objfrmMain = new mpfac.Form2();
                this.Hide();
                objfrmMain.Show();
            }
            else
                MessageBox.Show("Invalid Login");
            
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void iconmini_MouseEnter(object sender, EventArgs e)
        {
            iconmini.BackColor = Color.CadetBlue;
        }

        private void iconmini_MouseLeave(object sender, EventArgs e)
        {
            iconmini.BackColor = Color.White;
        }

        
        private void btncerrar_MouseEnter(object sender, EventArgs e)
        {
            btncerrar.BackColor = Color.Red;
        }

        private void btncerrar_MouseLeave(object sender, EventArgs e)
        {
            btncerrar.BackColor = Color.White;
        }
    }
}
