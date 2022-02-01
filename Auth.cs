using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AIS_exchangeOffice
{
    public partial class AuthForm : Form
    {
        public AuthForm()
        {
            InitializeComponent();           
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void loginBox_Click(object sender, EventArgs e)
        {
            loginBox.BackColor = Color.White;
            loginPanel.BackColor = Color.White;
            passwordPanel.BackColor = SystemColors.Control;
            passBox.BackColor = SystemColors.Control;
        }

        private void passBox_Click(object sender, EventArgs e)
        {
            passBox.BackColor = Color.White;
            passwordPanel.BackColor = Color.White;
            loginPanel.BackColor = SystemColors.Control;
            loginBox.BackColor = SystemColors.Control;
        }

        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            passBox.UseSystemPasswordChar = false;
        }

        private void pictureBox3_MouseUp(object sender, MouseEventArgs e)
        {
            passBox.UseSystemPasswordChar = true;
        }

        private void logBtn_Click(object sender, EventArgs e)
        {
            string connStr = "server=localhost;user=root;database=aisdatabd;password=root123;";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();

            string login = loginBox.Text, pass = passBox.Text;

            string sql = "SELECT password FROM users WHERE login = '" + login + "'";

            MySqlCommand command = new MySqlCommand(sql, conn);
            try
            {
                if (pass == command.ExecuteScalar().ToString())
                {
                    MessageBox.Show("Авторизация успешна");
                    string data = command.ExecuteScalar().ToString();
                    switch (data)
                    {
                        case "cashier":
                            CashierWindowMain showCashier = new CashierWindowMain();
                            showCashier.Show();
                            this.Hide();
                            break;
                        case "admin":
                            AdminWindow showAdmin = new AdminWindow();
                            showAdmin.Show();
                            this.Hide();
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Пароль некорректен!");
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException)
            {
                MessageBox.Show("Такого пользователя нет в системе");
            }
            conn.Close();                      
        }
    }
}
