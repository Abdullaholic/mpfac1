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
    public partial class Tabs : Form
    {
        public Tabs()
        {
            InitializeComponent();
            button7.BackgroundImageLayout = ImageLayout.Stretch;
            button8.BackgroundImageLayout = ImageLayout.Stretch;
            button9.BackgroundImageLayout = ImageLayout.Stretch;
            button10.BackgroundImageLayout = ImageLayout.Stretch;
            button11.BackgroundImageLayout = ImageLayout.Stretch;
            button12.BackgroundImageLayout = ImageLayout.Stretch;
            
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            tab1 objfrmMain = new mpfac.tab1();
            this.Hide();
            objfrmMain.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            tab2 objfrmMain = new mpfac.tab2();
            this.Hide();
            objfrmMain.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            tab3 objfrmMain = new mpfac.tab3();
            this.Hide();
            objfrmMain.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            tab4 objfrmMain = new mpfac.tab4();
            this.Hide();
            objfrmMain.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            tab5 objfrmMain = new mpfac.tab5();
            this.Hide();
            objfrmMain.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            tab6 objfrmMain = new mpfac.tab6();
            this.Hide();
            objfrmMain.Show();
        }
    }
}
