using Cinema.Handle;
using Quản_Lý_Khách_Sạn.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BCryptNet = BCrypt.Net.BCrypt;
using Quản_Lý_Khách_Sạn.ClassSupport;
namespace Quản_Lý_Khách_Sạn
{
    public partial class Register : Form
    {
        private readonly AppDbContext dbContext;
        public Register()
        {
            InitializeComponent();
            dbContext = new AppDbContext();
        }

        

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void Register_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            Login frm = new Login();
            frm.Show();
            this.Hide();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {

        }

        private void checkUser_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
        private int CodeEmail()
        {
            Random rd = new Random();
            return rd.Next(100000,1000000);
        }
        public void SendEmail(EmailTo emailTo)
        {

            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("buiminhthucvv2002@gmail.com", "rhum rqpf hvvm pbca"),
                EnableSsl = true
            };
            try
            {
                var message = new MailMessage();
                message.From = new MailAddress("buiminhthucvv2002@gmail.com");
                message.To.Add(emailTo.Mail);
                message.Subject = emailTo.Subject;
                message.Body = emailTo.Content;
                message.IsBodyHtml = true;
                smtpClient.Send(message);

                MessageBox.Show("Đăng kí thành công vui lòng kiểm tra email xác nhận tài khoản !");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi gửi email: " + ex.Message);
            }
        }
        private void bunifuButton3_Click(object sender, EventArgs e)
        {
           
        User user = new User
        {
            UserName = txtUsername.Text,
            PassWord = BCryptNet.HashPassword(txtPassword.Text),
            Email = txtEmail.Text,
            AvtUrl = picImage.Tag?.ToString(),
            PhoneNumber = txtSDT.Text,
            RoleID = 1,
            IsActive = false
        };
            dbContext.Users.Add(user);

            
            ComfirmEmail confirmEmail = new ComfirmEmail
            {
                Code = CodeEmail().ToString(),
                UserId = user.Id,
                EndTime = DateTime.Now.AddMinutes(10)
            };
            dbContext.ComfirmEmails.Add(confirmEmail);

           
            dbContext.SaveChanges();

         
            EmailTo emailTo = new EmailTo
            {
                Subject = "Xác nhận tài khoản khách sạn !",
                Mail = txtEmail.Text,
                Content = $"Mã xác nhận THUCHOTEL của bạn là {confirmEmail.Code} !"
            };
            SendEmail(emailTo);
            Login frm = new Login(txtUsername.Text);
            frm.Show();
            this.Hide();


        }

        private void bunifuButton3_MouseHover(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.Top -= 2;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Top += 2;
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg;*.jpeg;*.png;*.gif)|*.jpg;*.jpeg;*.png;*.gif|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                picImage.ImageLocation = openFileDialog.FileName;
                picImage.Tag= openFileDialog.FileName;
            }
        }

        private void Register_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void Register_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            checkUser.Visible = false;
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            if (Check_Input.IsWhiteSpace(txtUsername.Text) || txtUsername.Text.Length < 5 || txtUsername.Text.Length > 15)
            {
                checkUser.Visible = true;
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            checkPassword.Visible = false;
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (!Check_Input.Password_Ok(txtPassword.Text))
            {
                checkPassword.Visible = true;
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            checkEmail.Visible = false;
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (!Check_Input.IsValidEmail(txtEmail.Text))
            {
                checkEmail.Visible = true;
            }
        }

        private void txtSDT_TextChanged(object sender, EventArgs e)
        {
            CheckPhone.Visible = false;
        }

        private void txtSDT_Leave(object sender, EventArgs e)
        {
            if (!Check_Input.IsValidPhoneNumber(txtSDT.Text))
            {
                CheckPhone.Visible = true;
            }
        }
    }
}
