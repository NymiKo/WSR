using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpisokStudents
{
    public partial class formLogin : Form
    {
        public formLogin()
        {
            InitializeComponent();
        }

        //События labelLogin
        private void textLogin_Enter(object sender, EventArgs e)
        {
            if (textLogin.Text == "Логин")
            {
                textLogin.Text = "";
                textLogin.ForeColor = Color.Black;
            }
        }

        private void textLogin_Leave(object sender, EventArgs e)
        {
            if (textLogin.Text == "")
            {
                textLogin.Text = "Логин";
                textLogin.ForeColor = Color.Silver;
            }
        }

        //События labelPassword
        private void textPassword_Enter(object sender, EventArgs e)
        {
            if (textPassword.Text == "Пароль")
            {
                textPassword.Text = "";
                textPassword.ForeColor = Color.Black;
            }
        }

        private void textPassword_Leave(object sender, EventArgs e)
        {
            if (textPassword.Text == "")
            {
                textPassword.Text = "Пароль";
                textPassword.ForeColor = Color.Silver;
            }
        }


        //События btnLogin
        //При нажатии кнопки
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if((textLogin.Text == "admin") && (textPassword.Text == "admin"))
            {
                this.Hide();
                Spisok Spisok = new Spisok();
                Spisok.Show();
            }
            else
            {
                this.Height = 261;
                btnLogin.Location = new Point(82, 166);
                var labelError = new Label();
                labelError.Location = new Point(10, 137);
                labelError.Width = 281;
                labelError.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
                labelError.Text = "Логин или пароль введены неверно!";
                labelError.ForeColor = Color.Red;
                Controls.Add(labelError);
            }
        }

        private void formLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
