using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;
using MySql.Data.MySqlClient;


namespace AIS_exchangeOffice
{
    public partial class AuthForm : Form
    {
        public DialogResult dialog;
        public bool resultBtn = false;
        public static string nameUser = "";
        public AuthForm()
        {
            InitializeComponent();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Вы уверены?", "Выход из приложения", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do nothing
            }
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
            resultBtn = false;
            string connStr = "server=localhost;user=root;database=aisdatabd;password=root123;";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();

            string login = loginBox.Text, pass = passBox.Text;

            string sql = "SELECT password FROM users WHERE login = '" + login + "'";

            MySqlCommand cmd = new MySqlCommand(sql, conn);

            try
            {
                if (pass == cmd.ExecuteScalar().ToString())
                {
                    MessageBox.Show("Авторизация успешна");
                    sql = "SELECT type FROM users WHERE login = '" + login + "'";
                    cmd = new MySqlCommand(sql, conn);                    
                    string data = cmd.ExecuteScalar().ToString();
                    sql = "SELECT name FROM users WHERE login = '" + login + "'";
                    cmd = new MySqlCommand(sql, conn);
                    nameUser = cmd.ExecuteScalar().ToString();
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
                    resultBtn = true;
                    dialog = MessageBox.Show("Пароль некорректен!");
                }
            }
            catch (NullReferenceException)
            {
                resultBtn = true;
                dialog = MessageBox.Show("Такого пользователя нет в системе");
            }
            catch (MySqlException)
            {
                resultBtn = true;
                dialog = MessageBox.Show("Такого пользователя нет в системе");
            }            
            conn.Close();                      
        }

        private void loginBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (resultBtn == true)
            {
                resultBtn = false;
            }
            else if (e.KeyCode == Keys.Enter && passBox.Text == "")
            {
                passBox.BackColor = Color.White;
                passwordPanel.BackColor = Color.White;
                loginPanel.BackColor = SystemColors.Control;
                loginBox.BackColor = SystemColors.Control;
                passBox.Focus();
            }
            else if (e.KeyCode == Keys.Enter && passBox.Text != "")
            {
                logBtn_Click(sender, e);
            }
            else if (e.KeyData == Keys.Down)
            {
                passBox.BackColor = Color.White;
                passwordPanel.BackColor = Color.White;
                loginPanel.BackColor = SystemColors.Control;
                loginBox.BackColor = SystemColors.Control;
                passBox.Focus();               
            }           
        }

        private void passBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (resultBtn == true)
            {
                resultBtn = false;
            }
            else if (e.KeyCode == Keys.Enter)
            {
                logBtn_Click(sender, e);
            }
            else if (e.KeyData == Keys.Up)
            {
                loginBox.BackColor = Color.White;
                loginPanel.BackColor = Color.White;
                passwordPanel.BackColor = SystemColors.Control;
                passBox.BackColor = SystemColors.Control;
                loginBox.Focus();
            }
        }

        private void AuthForm_Shown(object sender, EventArgs e)
        {
            loginBox.Focus();
        }

        private void AuthForm_Load(object sender, EventArgs e)
        {
            File.Delete(Directory.GetCurrentDirectory() + "\\bd_reserveCopy\\reserve_bd.zip");
            string pathBD = Directory.GetCurrentDirectory();
            pathBD = pathBD + "\\bd\\";
            string pathReserve = Directory.GetCurrentDirectory() + "\\bd_reserveCopy\\reserve_bd.zip";
            ZipFile.CreateFromDirectory(pathBD, pathReserve);                     
        }
    }
}
