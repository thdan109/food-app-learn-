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
using QuanLyQuanCafe.DAO;
using QuanLyQuanCafe.DTO;

namespace QuanLyQuanCafe
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtUser;
        }
        private void FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Bạn có chắc muốn thoát không ?", "Thông báo",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.OK) Application.Exit();
        }

        private void chkNho_CheckedChanged(object sender, EventArgs e)
        {
            txtPass.UseSystemPasswordChar = !chkNho.Checked;
        }

        bool Login(string userName, string passWord)
        {
            return AccountDAO.Instance.Login(userName, passWord);
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            if (txtUser.Text == "" || txtPass.Text == "")
            {
                MessageBox.Show("Please provide UserName and Password", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                string userName = txtUser.Text;
                string passWord = txtPass.Text;
                if (Login(userName, passWord))
                {
                    MessageBox.Show("Login successfullllllllllllllllllllllllllllllllllllllllll!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Account loginAccount = AccountDAO.Instance.GetAccountByUserName(userName);
                    Form frm = new HomePage(loginAccount);
                    frm.FormClosed += new FormClosedEventHandler(FormClosed);
                    frm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Không đúng tên người dùng / mậtkhẩu !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtUser.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
