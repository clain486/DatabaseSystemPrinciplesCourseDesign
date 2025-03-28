﻿using System;
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
    public partial class AdminWin21 : Form
    {
        private Dao dao;
        public AdminWin21()
        {
            InitializeComponent();    
        }

        private void AdminWin21_Load(object sender, EventArgs e)
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
                    string sql = $"INSERT INTO t_temp (Lon, Lat, Depth, Time, Temp) VALUES ('{textBox1.Text}', '{textBox2.Text}', '{textBox3.Text}', '{textBox4.Text}', '{textBox5.Text}')";
                    int n = dao.Execute(sql);

                    if (n > 0)
                    {
                        MessageBox.Show($"添加成功");
                    }
                    else
                    {
                        MessageBox.Show("添加失败");
                    }
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                }
                else
                {
                    MessageBox.Show("输入内容不符合");
                }
            }
            catch
            {
                MessageBox.Show("添加失败");
            }
            dao.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }
    }
}
