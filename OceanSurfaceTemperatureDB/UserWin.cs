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
    public partial class UserWin : Form
    {
        private Dao dao;
        public UserWin()
        {
            InitializeComponent();
            dao = new Dao();
            this.FormClosing += new FormClosingEventHandler(UserWin_FormClosing);
        }

        private void UserWin_Load(object sender, EventArgs e)
        {
            Table();
            try
            {
                label15.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                label16.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                label17.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                label18.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                label19.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                label21.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            }
            catch { }
        }

        private void UserWin_FormClosing(object sender, FormClosingEventArgs e)
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

        private void button4_Click(object sender, EventArgs e)
        {
            Update();
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
                label21.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            }
            catch { }
        }

        // 直接调用数据库显示到表格中
        private void Table()
        {
            dataGridView1.Rows.Clear(); // 清空旧数据
            string sql = "SELECT * FROM t_temp";
            using (SqlDataReader reader = dao.ExecuteReader(sql))
            {
                while (reader.Read())
                {
                    dataGridView1.Rows.Add(
                        reader[0].ToString(),
                        reader[1].ToString(),
                        reader[2].ToString(),
                        reader[3].ToString(),
                        reader[4].ToString(),
                        reader[5].ToString());
                }
            }
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
                label21.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            }
            catch { }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear(); // 清空旧数据

            // 构建基本的查询语句
            StringBuilder sql = new StringBuilder("SELECT * FROM t_temp WHERE 1=1");

            // 动态添加用户填写的条件
            if (!string.IsNullOrEmpty(textBox15.Text))
            {
                sql.Append($" AND TempID = {textBox15.Text}");
            }
            if (!string.IsNullOrEmpty(textBox9.Text))
            {
                sql.Append($" AND Lon = {textBox9.Text}");
            }
            if (!string.IsNullOrEmpty(textBox10.Text))
            {
                sql.Append($" AND Lat = {textBox10.Text}");
            }
            if (!string.IsNullOrEmpty(textBox11.Text))
            {
                sql.Append($" AND Depth = {textBox11.Text}");
            }
            if (!string.IsNullOrEmpty(textBox12.Text))
            {
                sql.Append($" AND Time = '{textBox12.Text}'");
            }

            // 执行查询
            using (SqlDataReader reader = dao.ExecuteReader(sql.ToString()))
            {
                while (reader.Read())
                {
                    dataGridView1.Rows.Add(
                        reader[0].ToString(),
                        reader[1].ToString(),
                        reader[2].ToString(),
                        reader[3].ToString(),
                        reader[4].ToString(),
                        reader[5].ToString());
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear(); // 清空旧数据
            
            // 构建基本的查询语句
            StringBuilder sql = new StringBuilder("SELECT * FROM t_temp WHERE 1=1");

            // 动态添加用户填写的条件
            if (!string.IsNullOrEmpty(textBox13.Text))
            {
                sql.Append($" AND TempID >= {textBox13.Text}");
            }
            if (!string.IsNullOrEmpty(textBox14.Text))
            {
                sql.Append($" AND TempID <= {textBox14.Text}");
            }
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                sql.Append($" AND Lon >= {textBox1.Text}");
            }
            if (!string.IsNullOrEmpty(textBox5.Text))
            {
                sql.Append($" AND Lon <= {textBox5.Text}");
            }
            if (!string.IsNullOrEmpty(textBox2.Text))
            {
                sql.Append($" AND Lat >= {textBox2.Text}");
            }
            if (!string.IsNullOrEmpty(textBox6.Text))
            {
                sql.Append($" AND Lat <= {textBox6.Text}");
            }
            if (!string.IsNullOrEmpty(textBox3.Text))
            {
                sql.Append($" AND Depth >= {textBox3.Text}");
            }
            if (!string.IsNullOrEmpty(textBox7.Text))
            {
                sql.Append($" AND Depth <= {textBox7.Text}");
            }
            if (!string.IsNullOrEmpty(textBox4.Text))
            {
                sql.Append($" AND Time >= {textBox4.Text}");
            }
            if (!string.IsNullOrEmpty(textBox8.Text))
            {
                sql.Append($" AND Time <= {textBox8.Text}");
            }

            // 执行查询
            using (SqlDataReader reader = dao.ExecuteReader(sql.ToString()))
            {
                while (reader.Read())
                {
                    dataGridView1.Rows.Add(
                        reader[0].ToString(),
                        reader[1].ToString(),
                        reader[2].ToString(),
                        reader[3].ToString(),
                        reader[4].ToString(),
                        reader[5].ToString());
                }
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            ExportToCsv();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox13.Text = "";
            textBox14.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            textBox15.Text = "";
        }
    }
}
