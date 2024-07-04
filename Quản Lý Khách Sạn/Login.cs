using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quản_Lý_Khách_Sạn
{
    public partial class Login : Form
    {
        private Timer timer;
        private string TemptUser="abcd";
        public Login()
        {
            InitializeComponent();
             this.Login_Load(this,EventArgs.Empty);
        }

        public Login(string temptUser)
        {
            InitializeComponent();
            TemptUser = temptUser;
            
        }

        private void start()
        {
            
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            checkUser.Visible = false;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            checkPass.Visible = false;
        }

        private void txtUser_Click(object sender, EventArgs e)
        {
            if (txtUser.Text == "abcd")
            {
                txtUser.Text = "";
                txtUser.ForeColor = Color.White;
            }
        }

        private void txtUser_Leave(object sender, EventArgs e)
        {
            if (txtUser.Text == "")
            {
                txtUser.Text = "abcd";
                txtUser.ForeColor = Color.Gray;
            }
        }

        private void txtPassword_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == "*******")
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.White;
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                txtPassword.Text = "*******";
                txtPassword.ForeColor = Color.Gray;
            }
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            btnDangNhap.ForeColor = Color.Black;
        }

        private void btnDangNhap_MouseLeave(object sender, EventArgs e)
        {
            btnDangNhap.ForeColor = Color.White;
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (txtUser.Text == "abcd" || txtUser.Text == " ")
            {
                checkUser.Visible = true; return;      
            }
            if (txtPassword.Text == "*******" || txtPassword.Text == " ")
            {
                checkPass.Visible = true; return;
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private  void linkDangki_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register frm = new Register();
            
                frm.Show();
                this.Hide();
            
        }

        private void Login_Load(object sender, EventArgs e)
        {
            txtUser.Text = TemptUser;
            lblTime.Text = DateTime.Now.ToString("HH:mm:ss");
            // Tạo Timer
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += timer1_Tick;
            timer.Start();
        }
    }
}
