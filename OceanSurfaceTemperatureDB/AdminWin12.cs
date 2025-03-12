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
    public partial class AdminWin12 : Form
    {
        private Dao dao;
        string Lon = "", Lat = "", Depth = "", Time = "", Temp = "";

        public AdminWin12()
        {
            InitializeComponent();
        }

        public AdminWin12(string lon, string lat, string depth, string time, string temp)
        {
            InitializeComponent();

            Lon = lon;
            Lat = lat;
            Depth = depth;
            Time = time;
            Temp = temp;

            textBox1.Text = lon;
            textBox2.Text = lat;
            textBox3.Text = depth;
            textBox4.Text = time;
            textBox5.Text = temp;
        }

        private void AdminWin12_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dao = new Dao();
            try
            {
                if (textBox1.Text != ""
                && textBox2.Text != ""
                && textBox3.Text != ""
                && textBox4.Text != "")
                {
                    string sql = $"update t_user set UserID = '{textBox1.Text}',Username = '{textBox2.Text}', Password = '{textBox3.Text}', Email = '{textBox4.Text}', UserRole = '{textBox5.Text}'" +
                        $"where UserID = '{Lon}' and Username = '{Lat}' and Password = '{Depth}' and Email = '{Time}' and UserRole = '{Temp}'";
                    int n = dao.Execute(sql);
                    if (n > 0)
                    {
                        MessageBox.Show("修改成功");
                    }
                    else
                    {
                        MessageBox.Show("修改失败");
                    }
                }
                else
                {
                    MessageBox.Show("输入内容不符合");
                }
            }
            catch
            {
                MessageBox.Show("修改失败");
            }
            dao.Dispose();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = Lon;
            textBox2.Text = Lat;
            textBox3.Text = Depth;
            textBox4.Text = Time;
            textBox5.Text = Temp;
        }
    }
}
