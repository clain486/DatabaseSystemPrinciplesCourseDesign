using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OceanSurfaceTemperatureDB
{
    public partial class AdminWin : Form
    {
        public AdminWin()
        {
            InitializeComponent();
        }

        private void AdminWin_Load(object sender, EventArgs e)
        {

        }

        private void SystemMenuItem_Click(object sender, EventArgs e)
        {
            using (AdminWin1 adminWin1 = new AdminWin1())
            {
                this.Hide();
                adminWin1.ShowDialog();
                this.Show();
            }
        }

        private void StatisticsMenuItem_Click(object sender, EventArgs e)
        {
            using (AdminWin2 adminWin2 = new AdminWin2())
            {
                this.Hide();
                adminWin2.ShowDialog();
                this.Show();
            }
        }
    }
}
