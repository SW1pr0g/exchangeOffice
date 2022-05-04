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
        //инициализация переменных, доступ к 
        //которым необходим из любой части проекта
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
                Application.Exit();     //закрываем приложение
            }
            else if (dialogResult == DialogResult.No)
            {
                //ничего не делать
            }
        }

        private void loginBox_Click(object sender, EventArgs e)
        {
            //визуальное сопровождение фокуса 
            //на ввод логина
            loginBox.BackColor = Color.White;
            loginPanel.BackColor = Color.White;
            passwordPanel.BackColor = SystemColors.Control;
            passBox.BackColor = SystemColors.Control;
        }

        private void passBox_Click(object sender, EventArgs e)
        {
            //визуальное сопровождение фокуса 
            //на ввод пароля
            passBox.BackColor = Color.White;
            passwordPanel.BackColor = Color.White;
            loginPanel.BackColor = SystemColors.Control;
            loginBox.BackColor = SystemColors.Control;
        }

        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            //скрываем пароль
            passBox.UseSystemPasswordChar = false;
        }

        private void pictureBox3_MouseUp(object sender, MouseEventArgs e)
        {
            //показываем пароль
            passBox.UseSystemPasswordChar = true;
        }

        private void logBtn_Click(object sender, EventArgs e)
        {
            resultBtn = false;      //никакой пользователь не авторизирован

            //подключаемся к БД MySQL
            string connStr = "server=localhost;user=root;database=aisdatabd;password=root123;";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();

            string login = loginBox.Text, pass = passBox.Text;      //запоминаем введенные логин и пароль

            //делаем выборку пароля для введённого пользователем логина
            string sql = "SELECT password FROM users WHERE login = '" + login + "'";

            MySqlCommand cmd = new MySqlCommand(sql, conn);         //инициализируем новую SQL-команду

            try
            {
                if (pass == cmd.ExecuteScalar().ToString())         //сравнение и идентификация
                {
                    MessageBox.Show("Авторизация успешна");

                    //запоминаем логин и пароль в публичные переменные
                    //нужно будет в дальнейшем для AdminWindow
                    AdminWindow.admin_login = login;
                    AdminWindow.admin_password = pass;

                    //получаем права пользователя
                    sql = "SELECT type FROM users WHERE login = '" + login + "'";
                    cmd = new MySqlCommand(sql, conn);                    
                    string data = cmd.ExecuteScalar().ToString();

                    //получаем имя пользователя
                    sql = "SELECT name FROM users WHERE login = '" + login + "'";
                    cmd = new MySqlCommand(sql, conn);

                    //также запоминаем имя залогинившегося
                    nameUser = cmd.ExecuteScalar().ToString();

                    //логиним пользователя в соответствии с его правами
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

                    //данные некорректны
                    resultBtn = true;       
                    dialog = MessageBox.Show("Пароль некорректен!");

                }
            }
            //ошибки - следовательно данных о введённом пользователе нет 
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
            
            //обязательно нужно закрыть подключение к MySQL
            conn.Close();                     
        }

        //настраиваем удобство перехода при вводе логина
        //и пароля - при нажатии клавиш Enter и стрелочек
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
        //-----------------------------------------------------------------

        private void AuthForm_Shown(object sender, EventArgs e)
        {
            loginBox.Focus();
        }

        private void AuthForm_Load(object sender, EventArgs e)
        {
            //резервное копирование БД
            File.Delete(Directory.GetCurrentDirectory() + "\\bd_reserveCopy\\reserve_bd.zip");      //удаление предыдущей резервной копии
            string pathBD = Directory.GetCurrentDirectory();
            pathBD = pathBD + "\\bd\\";
            string pathReserve = Directory.GetCurrentDirectory() + "\\bd_reserveCopy\\reserve_bd.zip";
            ZipFile.CreateFromDirectory(pathBD, pathReserve);       //создание новой резервной копии
        }
    }
}
