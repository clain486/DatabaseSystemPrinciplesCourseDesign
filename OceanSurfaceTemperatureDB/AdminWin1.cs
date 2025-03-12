using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace OceanSurfaceTemperatureDB
{
    public partial class AdminWin1 : Form
    {
        private Dao dao;
        public AdminWin1()
        {
            InitializeComponent();
            dao = new Dao();
            this.FormClosing += new FormClosingEventHandler(AdminWin1_FormClosing);
        }

        private void AdminWin1_Load(object sender, EventArgs e)
        {
            Table();
            try
            {
                label15.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                label16.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                label17.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                label18.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                label19.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            }
            catch { }
        }

        private void AdminWin1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 释放资源
            dao.Dispose();
            this.Dispose();
        }

        private void ExportToCsv()
        {
            // 提示用户选择保存路径
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "CSV文件|*.csv", FileName = "DataExport.csv" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    // 创建文件流
                    using (StreamWriter sw = new StreamWriter(sfd.FileName, false, Encoding.UTF8))
                    {
                        // 写入列标题
                        var columnHeaders = dataGridView1.Columns.Cast<DataGridViewColumn>();
                        sw.WriteLine(string.Join(",", columnHeaders.Select(column => column.HeaderText).ToArray()));

                        // 写入行数据
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            if (!row.IsNewRow)
                            {
                                var cells = row.Cells.Cast<DataGridViewCell>();
                                sw.WriteLine(string.Join(",", cells.Select(cell => cell.Value?.ToString()).ToArray()));
                            }
                        }
                    }

                    MessageBox.Show("数据已成功导出！", "导出完成", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private new void Update()
        {
            Table();
            try
            {
                label15.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                label16.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                label17.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                label18.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                label19.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            }
            catch { }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                label15.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                label16.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                label17.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                label18.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                label19.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminWin11 adminwin11 = new AdminWin11();
            adminwin11.ShowDialog();
            Update();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string lon = dataGridView1.SelectedRows[0].Cells[0].Value.ToString(); 
                string lat = dataGridView1.SelectedRows[0].Cells[1].Value.ToString(); 
                string depth = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                string time = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                string temp = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();

                label15.Text = lon;
                label16.Text = lat;
                label17.Text = depth;
                label18.Text = time;
                label19.Text = temp;

                AdminWin12 admin12 = new AdminWin12(lon, lat, depth, time, temp);
                admin12.ShowDialog();
            }
            catch { }

            Update();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string lon = dataGridView1.SelectedRows[0].Cells[0].Value.ToString(); 
                string lat = dataGridView1.SelectedRows[0].Cells[1].Value.ToString(); 
                string depth = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                string time = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                string temp = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();

                label15.Text = lon;
                label16.Text = lat;
                label17.Text = depth;
                label18.Text = time;
                label19.Text = temp;

                DialogResult dr = MessageBox.Show("确认删除吗？", "信息提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    string sql = $"delete from t_user where UserID = '{lon}'and Username = '{lat}' and Password = '{depth}' and Email = '{time}' and UserRole ='{temp}'";
                    int n = dao.Execute(sql);
                    if (n > 0)
                    {
                        MessageBox.Show("删除成功");
                    }
                    else
                    {
                        MessageBox.Show("删除失败");
                    }
                }
            }
            catch
            {
                MessageBox.Show("删除失败");
            }
            Update();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Update();
        }

        // 直接调用数据库显示到表格中
        private void Table()
        {
            dataGridView1.Rows.Clear(); // 清空旧数据
            string sql = "SELECT * FROM t_user";
            using (SqlDataReader reader = dao.ExecuteReader(sql))
            {
                while (reader.Read())
                {
                    dataGridView1.Rows.Add(
                        reader[0].ToString(),
                        reader[1].ToString(),
                        reader[2].ToString(),
                        reader[3].ToString(),
                        reader[4].ToString());
                }
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            ExportToCsv();
        }
    }
}
