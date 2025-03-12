using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace OceanSurfaceTemperatureDB
{
    public partial class AdminWin22 : Form
    {
        private Dao dao;
        string ID = "", Lon = "", Lat = "", Depth = "", Time = "", Temp = "";

        public AdminWin22()
        {
            InitializeComponent();
        }

        public AdminWin22(string id, string lon, string lat, string depth, string time, string temp)
        {
            InitializeComponent();

            ID = id;
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

        private void AdminWin22_Load(object sender, EventArgs e)
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
                    string sql = $"update t_temp set Lon = '{textBox1.Text}',Lat = '{textBox2.Text}', Depth = '{textBox3.Text}', Time = '{textBox4.Text}', Temp = '{textBox5.Text}'" +
                        $"where TempID = '{ID}' and Lon = '{Lon}' and Lat = '{Lat}' and Depth = '{Depth}' and Time = '{Time}' and Temp = '{Temp}'";
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
