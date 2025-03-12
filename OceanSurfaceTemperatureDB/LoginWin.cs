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

namespace OceanSurfaceTemperatureDB
{
    public partial class LoginWin : Form
    {
        public LoginWin()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBoxUid.Text.Length != 0 && textBoxPsw.Text.Length != 0)
            {
                CheckLogin();
            }
            else
            {
                MessageBox.Show("账号和密码有空，请重新输入");
            }
        }

        public void CheckLogin() //登录验证
        {
            if(radioButtonUser.Checked == true) //用户
            {
                using (Dao dao = new Dao())
                {
                    string sql = $"select * from t_user where UserID = '{textBoxUid.Text}' and Password = '{textBoxPsw.Text}'";
                    //MessageBox.Show(sql);
                    IDataReader dc = dao.ExecuteReader(sql);
                        //dc.Read();
                        //MessageBox.Show(dc["Username"].ToString());
                        if (dc.Read())
                        {
                            LoginData.Uid = dc["UserID"].ToString();
                            LoginData.Uname = dc["Username"].ToString();

                            MessageBox.Show("登陆成功");

                            UserWin userwin = new UserWin();
                            this.Hide();
                            userwin.ShowDialog();
                            this.Show();
                        }
                        else
                        {
                            MessageBox.Show("登陆失败");
                        }
                }
                //dao.DaoClose(); 
            }
            if(radioButtonAdmin.Checked == true) //管理员
            {
                using (Dao dao = new Dao())
                {
                    string sql = $"select * from t_admin where UserID = '{textBoxUid.Text}' and Password = '{textBoxPsw.Text}'";
                    //MessageBox.Show(sql);
                    IDataReader dc = dao.ExecuteReader(sql);
                    //dc.Read();
                    //MessageBox.Show(dc["Username"].ToString());
                    if (dc.Read())
                    {
                        LoginData.Uid = dc["UserID"].ToString();
                        LoginData.Uname = dc["Username"].ToString();

                        MessageBox.Show("登陆成功");

                        AdminWin adminwin = new AdminWin();
                        this.Hide();
                        adminwin.ShowDialog();
                        this.Show();
                    }
                    else
                    {
                        MessageBox.Show("登陆失败");
                    }
                }
                //dao.DaoClose();
            }
            return;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            register.ShowDialog();
        }
    }
}
