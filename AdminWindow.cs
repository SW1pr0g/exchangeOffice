using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using MySql.Data.MySqlClient;

namespace AIS_exchangeOffice
{
    public partial class AdminWindow : Form
    {
        //connect to BD
        //string connStr = "server=localhost;user=root;database=aisdatabd;password=root123;";
        //MySqlConnection conn = new MySqlConnection(connStr);
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);
        public AdminWindow()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            pnlNav.Height = MainBtn.Height;
            pnlNav.Top = MainBtn.Top;
            pnlNav.Left = MainBtn.Left;
            MainBtn.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void exitButton_search_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Выйти из аккаунта?", "Выход из аккаунта", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                AuthForm showAuthForm = new AuthForm();
                showAuthForm.Show();
                this.Hide();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do nothing
            }
        }

        private void exitButton_exchange_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Выйти из аккаунта?", "Выход из аккаунта", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                AuthForm showAuthForm = new AuthForm();
                showAuthForm.Show();
                this.Hide();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do nothing
            }
        }

        private void exitButton_clients_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Выйти из аккаунта?", "Выход из аккаунта", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                AuthForm showAuthForm = new AuthForm();
                showAuthForm.Show();
                this.Hide();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do nothing
            }
        }

        private void exit_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Выйти из аккаунта?", "Выход из аккаунта", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                AuthForm showAuthForm = new AuthForm();
                showAuthForm.Show();
                this.Hide();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do nothing
            }
        }

        private void MainBtn_Click(object sender, EventArgs e)
        {
            pnlNav.Height = MainBtn.Height;
            pnlNav.Top = MainBtn.Top;
            pnlNav.Left = MainBtn.Left;
            MainBtn.BackColor = Color.FromArgb(46, 51, 73);
            mainPanel.Visible = true;
            clientsPanel.Visible = false;
            exchangePanel.Visible = false;
            searchPanel.Visible = false;
            bdPanel.Visible = false;
            otchetPanel.Visible = false;
        }

        private void MainBtn_Leave(object sender, EventArgs e)
        {
            MainBtn.BackColor = Color.FromArgb(11, 100, 103);
        }

        private void ClientsBtn_Click(object sender, EventArgs e)
        {
            pnlNav.Height = ClientsBtn.Height;
            pnlNav.Top = ClientsBtn.Top;
            pnlNav.Left = ClientsBtn.Left;
            ClientsBtn.BackColor = Color.FromArgb(46, 51, 73);
            mainPanel.Visible = false;
            clientsPanel.Visible = true;
            exchangePanel.Visible = false;
            searchPanel.Visible = false;
            bdPanel.Visible = false;
            otchetPanel.Visible = false;
        }

        private void ClientsBtn_Leave(object sender, EventArgs e)
        {
            ClientsBtn.BackColor = Color.FromArgb(11, 100, 103);
        }

        private void ExchangeBtn_Click(object sender, EventArgs e)
        {
            pnlNav.Height = ExchangeBtn.Height;
            pnlNav.Top = ExchangeBtn.Top;
            pnlNav.Left = ExchangeBtn.Left;
            ExchangeBtn.BackColor = Color.FromArgb(46, 51, 73);
            exchangePanel.Visible = true;
            mainPanel.Visible = false;
            clientsPanel.Visible = false;
            searchPanel.Visible = false;
            bdPanel.Visible = false;
            otchetPanel.Visible = false;
        }

        private void ExchangeBtn_Leave(object sender, EventArgs e)
        {
            ExchangeBtn.BackColor = Color.FromArgb(11, 100, 103);
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            pnlNav.Height = SearchBtn.Height;
            pnlNav.Top = SearchBtn.Top;
            pnlNav.Left = SearchBtn.Left;
            SearchBtn.BackColor = Color.FromArgb(46, 51, 73);
            searchPanel.Visible = true;
            exchangePanel.Visible = false;
            mainPanel.Visible = false;
            clientsPanel.Visible = false;
            bdPanel.Visible = false;
            otchetPanel.Visible = false;
        }
        private void SearchBtn_Leave(object sender, EventArgs e)
        {
            SearchBtn.BackColor = Color.FromArgb(11, 100, 103);
        }
        private void BDbtn_Click(object sender, EventArgs e)
        {
            pnlNav.Height = BDbtn.Height;
            pnlNav.Top = BDbtn.Top;
            pnlNav.Left = BDbtn.Left;
            BDbtn.BackColor = Color.FromArgb(46, 51, 73);
            exchangePanel.Visible = false;
            mainPanel.Visible = false;
            clientsPanel.Visible = false;
            searchPanel.Visible = false;
            bdPanel.Visible = true;
            otchetPanel.Visible = false;

        }
        private void BDbtn_Leave(object sender, EventArgs e)
        {
            BDbtn.BackColor = Color.FromArgb(11, 100, 103);
        }        
        private void OtchetBtn_Click(object sender, EventArgs e)
        {
            pnlNav.Height = OtchetBtn.Height;
            pnlNav.Top = OtchetBtn.Top;
            pnlNav.Left = OtchetBtn.Left;
            OtchetBtn.BackColor = Color.FromArgb(46, 51, 73);
            exchangePanel.Visible = false;
            mainPanel.Visible = false;
            clientsPanel.Visible = false;
            searchPanel.Visible = false;
            bdPanel.Visible = false;
            otchetPanel.Visible = true;
        }       
        private void OtchetBtn_Leave(object sender, EventArgs e)
        {
            OtchetBtn.BackColor = Color.FromArgb(11, 100, 103);
        }

        private void exitButton_BD_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Выйти из аккаунта?", "Выход из аккаунта", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                AuthForm showAuthForm = new AuthForm();
                showAuthForm.Show();
                this.Hide();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do nothing
            }
        }

        private void exitButton_Otchet_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Выйти из аккаунта?", "Выход из аккаунта", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                AuthForm showAuthForm = new AuthForm();
                showAuthForm.Show();
                this.Hide();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do nothing
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void CourseRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            //datagrid
            string connStr = "server=localhost;user=root;database=aisdatabd;password=root123;";
            MySqlConnection conn = new MySqlConnection(connStr);

            MySqlCommand command = new MySqlCommand();
            string commandString = "SELECT * FROM currencycourse;";
            command.CommandText = commandString;
            command.Connection = conn;
            MySqlDataReader reader;
            try
            {
                command.Connection.Open();
                reader = command.ExecuteReader();
                this.dataGridView1.Columns.Add("u_num", "u_num");
                this.dataGridView1.Columns["u_num"].Width = 45;
                this.dataGridView1.Columns.Add("name", "Name");
                this.dataGridView1.Columns["name"].Width = 188;
                this.dataGridView1.Columns.Add("summsale", "SummSale");
                this.dataGridView1.Columns["summsale"].Width = 187;
                this.dataGridView1.Columns.Add("summpurchase", "SummPurchase");
                this.dataGridView1.Columns["summpurchase"].Width = 187;
                while (reader.Read())
                {
                    dataGridView1.Rows.Add(reader["u_num"].ToString(), reader["name"].ToString(), reader["summsale"].ToString(), reader["summpurchase"].ToString());
                }
                reader.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: \r\n{0}", ex.ToString());
            }
            finally
            {
                command.Connection.Close();
            }
        }
        private void OperationsRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            //datagrid
            string connStr = "server=localhost;user=root;database=aisdatabd;password=root123;";
            MySqlConnection conn = new MySqlConnection(connStr);

            MySqlCommand command = new MySqlCommand();
            string commandString = "SELECT * FROM operations;";
            command.CommandText = commandString;
            command.Connection = conn;
            MySqlDataReader reader;
            try
            {
                command.Connection.Open();
                reader = command.ExecuteReader();
                this.dataGridView1.Columns.Add("u_num", "u_num");
                this.dataGridView1.Columns["u_num"].Width = 45;
                this.dataGridView1.Columns.Add("surname", "Surname");
                this.dataGridView1.Columns["surname"].Width = 90;
                this.dataGridView1.Columns.Add("name", "Name");
                this.dataGridView1.Columns["name"].Width = 70;
                this.dataGridView1.Columns.Add("patronymic", "Patronymic");
                this.dataGridView1.Columns["patronymic"].Width = 90;
                this.dataGridView1.Columns.Add("type", "Type");
                this.dataGridView1.Columns["type"].Width = 60;
                this.dataGridView1.Columns.Add("quantity", "Quantity");
                this.dataGridView1.Columns["quantity"].Width = 62;
                this.dataGridView1.Columns.Add("summ", "Summ");
                this.dataGridView1.Columns["summ"].Width = 80;                
                this.dataGridView1.Columns.Add("date", "Date");
                this.dataGridView1.Columns["date"].Width = 110;
                while (reader.Read())
                {
                    classes.reversedate reversedate = new classes.reversedate();
                    dataGridView1.Rows.Add(reader["u_num"].ToString(), reader["surname"].ToString(), reader["name"].ToString(), reader["patronymic"].ToString(), reader["type"].ToString(), reader["quantity"].ToString(), reader["summ"].ToString(), reversedate.datetimeReverse(reader["date"].ToString()));
                }
                reader.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: \r\n{0}", ex.ToString());
            }
            finally
            {
                command.Connection.Close();
            }
        }        
        private void ClientsRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            //datagrid
            string connStr = "server=localhost;user=root;database=aisdatabd;password=root123;";
            MySqlConnection conn = new MySqlConnection(connStr);

            MySqlCommand command = new MySqlCommand();
            string commandString = "SELECT * FROM clients;";
            command.CommandText = commandString;
            command.Connection = conn;
            MySqlDataReader reader;
            try
            {
                command.Connection.Open();
                reader = command.ExecuteReader();
                this.dataGridView1.Columns.Add("u_num", "u_num");
                this.dataGridView1.Columns["u_num"].Width = 45;
                this.dataGridView1.Columns.Add("surname", "Surname");
                this.dataGridView1.Columns["surname"].Width = 100;
                this.dataGridView1.Columns.Add("name", "Name");
                this.dataGridView1.Columns["name"].Width = 100;
                this.dataGridView1.Columns.Add("patronymic", "Patronymic");
                this.dataGridView1.Columns["patronymic"].Width = 100;
                this.dataGridView1.Columns.Add("date_birth", "Date_birth");
                this.dataGridView1.Columns["date_birth"].Width = 100;
                this.dataGridView1.Columns.Add("seriesDoc", "SeriesDoc");
                this.dataGridView1.Columns["seriesDoc"].Width = 79;
                this.dataGridView1.Columns.Add("numberDoc", "NumberDoc");
                this.dataGridView1.Columns["numberDoc"].Width = 83;
                while (reader.Read())
                {
                    classes.reversedate reversedate = new classes.reversedate();
                    dataGridView1.Rows.Add(reader["u_num"].ToString(), reader["surname"].ToString(), reader["name"].ToString(), reader["patronymic"].ToString(), reversedate.dateReverse(reader["date_birth"].ToString()), reader["seriesDoc"].ToString(), reader["numberDoc"].ToString());
                }
                reader.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: \r\n{0}", ex.ToString());
            }
            finally
            {
                command.Connection.Close();
            }
        }

        private void UsersRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            //datagrid
            string connStr = "server=localhost;user=root;database=aisdatabd;password=root123;";
            MySqlConnection conn = new MySqlConnection(connStr);

            MySqlCommand command = new MySqlCommand();
            string commandString = "SELECT * FROM users;";
            command.CommandText = commandString;
            command.Connection = conn;
            MySqlDataReader reader;
            try
            {
                command.Connection.Open();
                reader = command.ExecuteReader();
                this.dataGridView1.Columns.Add("u_num", "u_num");
                this.dataGridView1.Columns["u_num"].Width = 45;
                this.dataGridView1.Columns.Add("login", "Login");
                this.dataGridView1.Columns["login"].Width = 140;
                this.dataGridView1.Columns.Add("password", "Password");
                this.dataGridView1.Columns["password"].Width = 140;
                this.dataGridView1.Columns.Add("name", "Name");
                this.dataGridView1.Columns["name"].Width = 149;
                this.dataGridView1.Columns.Add("type", "Type");
                this.dataGridView1.Columns["type"].Width = 133;
                while (reader.Read())
                {
                    dataGridView1.Rows.Add(reader["u_num"].ToString(), reader["login"].ToString(), reader["password"].ToString(), reader["name"].ToString(), reader["type"].ToString());
                }
                reader.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: \r\n{0}", ex.ToString());
            }
            finally
            {
                command.Connection.Close();
            }
        }

        private void bdPanel_Paint(object sender, PaintEventArgs e)
        {

        }
        private void saveBD_Click(object sender, EventArgs e)
        {           
            DialogResult dialogResult = MessageBox.Show("Вы уверены?", "Внесение изменений в БД", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string connectionString = "server = localhost; user = root; database = aisdatabd; password = root123;";
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();
                if (CourseRadioBtn.Checked == true)
                {                  
                    bool enderr = false;
                    int u_num = dataGridView1.Rows.Count;
                    string name = "";
                    string summsale = "", summpurchase = "";
                    for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
                    {
                        if (dataGridView1.Rows.Count > 6)
                        {                            
                            enderr = true;
                            MessageBox.Show("Нельзя добавлять новые валюты или изменять курс валют посредством добавления строк.");
                            dataGridView1.Rows.Clear();
                            dataGridView1.Columns.Clear();
                            MySqlConnection conn = new MySqlConnection(connectionString);

                            MySqlCommand command = new MySqlCommand();
                            string commandString = "SELECT * FROM currencycourse;";
                            command.CommandText = commandString;
                            command.Connection = conn;
                            MySqlDataReader reader;
                            command.Connection.Open();
                            reader = command.ExecuteReader();
                            this.dataGridView1.Columns.Add("u_num", "u_num");
                            this.dataGridView1.Columns["u_num"].Width = 20;
                            this.dataGridView1.Columns.Add("name", "Name");
                            this.dataGridView1.Columns["name"].Width = 50;
                            this.dataGridView1.Columns.Add("summsale", "SummSale");
                            this.dataGridView1.Columns["summsale"].Width = 100;
                            this.dataGridView1.Columns.Add("summpurchase", "SummPurchase");
                            this.dataGridView1.Columns["summpurchase"].Width = 100;
                            while (reader.Read())
                            {
                                dataGridView1.Rows.Add(reader["u_num"].ToString(), reader["name"].ToString(), reader["summsale"].ToString(), reader["summpurchase"].ToString());
                            }
                            reader.Close();
                            break;
                        }
                        try
                        {
                            u_num = Convert.ToInt32(dataGridView1[0, i].Value.ToString());
                            name = dataGridView1[1, i].Value.ToString();
                            summsale = dataGridView1[2, i].Value.ToString();
                            summpurchase = dataGridView1[3, i].Value.ToString();
                            string query = "UPDATE currencycourse SET name = '" + name + "', summsale = " + summsale.Replace(',', '.') + ", summpurchase = " + summpurchase.Replace(',', '.') + " WHERE u_num = " + u_num;
                            MySqlCommand command = new MySqlCommand(query, connection);
                            command.ExecuteNonQuery();                            
                        }
                        catch (MySqlException)
                        {
                            enderr = true;
                            MessageBox.Show("Возникла непредвиденная ошибка данных. Проверьте на корректность ввода только что введённые значения.");
                            break;
                        }
                        catch (NullReferenceException)
                        {
                            enderr = true;
                            MessageBox.Show("Какая-то из ячеек не заполнена полностью. Заполните пустые ячейки.");
                            break;
                        }
                        catch (FormatException)
                        {
                            enderr = true;
                            MessageBox.Show("В какой то из ячеек содержится некорректная информация, либо поле id не увеличивается на 1. Измените данные и попробуйте снова.");
                            break;
                        }
                    }
                    if (enderr == false)
                    {                        
                            MessageBox.Show("Изменения внесены!");
                            connection.Close();                                                
                    }
                }
                else if (OperationsRadioBtn.Checked == true)
                {
                    bool enderr = false;
                    int u_num = 0;
                    string name = "", surname = "", patronymic = "", type = "", quantity = "", date = "", summ = "", query = "";                    
                    for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                    {
                        MySqlCommand command = new MySqlCommand(query, connection);                                                                      
                        try
                        {
                            u_num = Convert.ToInt32(dataGridView1[0, i].Value.ToString());
                            surname = dataGridView1[1, i].Value.ToString();
                            name = dataGridView1[2, i].Value.ToString();
                            patronymic = dataGridView1[3, i].Value.ToString();
                            type = dataGridView1[4, i].Value.ToString();
                            summ = dataGridView1[5, i].Value.ToString();
                            quantity = dataGridView1[6, i].Value.ToString();
                            date = dataGridView1[7, i].Value.ToString();
                            query = "UPDATE operations SET surname = '" + surname + "', name = '" + name + "', patronymic = '" + patronymic + "', type = '" + type + "', quantity = " + quantity + ", summ = " + summ.Replace(',', '.') + ", date = '" + date + "' WHERE u_num = " + u_num;
                            command = new MySqlCommand(query, connection);
                            var tr = command.ExecuteNonQuery();
                            if (tr == 0)
                            {    
                                query = "INSERT INTO operations (u_num, surname, name, patronymic, type, quantity, summ, date) VALUES (" + u_num + ", '" + surname + "', '" + name + "', '" + patronymic + "', '" + type + "', " + quantity + ", " + summ.Replace(',', '.') + ", '" + date + "')";
                                command = new MySqlCommand(query, connection);
                                command.ExecuteNonQuery();    
                            }
                                                      
                        }
                        catch (MySqlException)
                        {                           
                            enderr = true;
                            MessageBox.Show("Возникла непредвиденная ошибка данных. Проверьте на корректность ввода только что введённые значения.");
                            break;
                        }
                        catch (NullReferenceException)
                        {
                            enderr = true;
                            MessageBox.Show("Какая-то из ячеек не заполнена полностью. Заполните пустые ячейки.");
                            break;
                        }
                        catch (FormatException)
                        {
                            enderr = true;
                            MessageBox.Show("В какой то из ячеек содержится некорректная информация, либо поле id не увеличивается на 1. Измените данные и попробуйте снова.");
                            break;
                        }

                    }
                    if (enderr == false)
                    {
                        MessageBox.Show("Изменения внесены!");                       
                        connection.Close();                        
                    }
                }                                
                else if (ClientsRadioBtn.Checked == true)
                {
                    bool enderr = false;
                    int u_num = 0, seriesDoc = 0, numberDoc = 0;
                    string name = "", surname = "", patronymic = "", date_birth = "", query = "";
                    for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                    {
                        MySqlCommand command = new MySqlCommand(query, connection);                                              
                        try
                        {
                            u_num = Convert.ToInt32(dataGridView1[0, i].Value.ToString());
                            name = dataGridView1[1, i].Value.ToString();
                            surname = dataGridView1[2, i].Value.ToString();
                            patronymic = dataGridView1[3, i].Value.ToString();
                            date_birth = dataGridView1[4, i].Value.ToString();
                            seriesDoc = Convert.ToInt32(dataGridView1[5, i].Value.ToString());
                            numberDoc = Convert.ToInt32(dataGridView1[6, i].Value.ToString());                            
                            if (seriesDoc > 9999 || seriesDoc < 1000 || numberDoc > 999999 || numberDoc < 100000)
                            {
                                enderr = true;
                                MessageBox.Show("Серия паспорта состоит из 4 цифр, а номер паспорта состоит из 6 цифр. Проверьте поля seriesDoc и numberDoc.");
                                break;
                            }
                            query = "UPDATE clients SET name = '" + name + "', surname = '" + surname + "', patronymic = '" + patronymic + "', date_birth = '" + date_birth + "', seriesDoc = " + seriesDoc + ", numberDoc = " + numberDoc + " WHERE u_num = " + u_num;
                            command = new MySqlCommand(query, connection);
                            var tr = command.ExecuteNonQuery();
                            if (tr == 0)
                            {
                                query = "INSERT INTO clients (u_num, name, surname, patronymic, date_birth, seriesDoc, numberDoc) VALUES (" + u_num + ", '" + name + "', '" + surname + "', '" + patronymic + "', '" + date_birth + "', " + seriesDoc + ", " + numberDoc + ")";
                                command = new MySqlCommand(query, connection);
                                command.ExecuteNonQuery();
                            }

                        }
                        catch (MySqlException)
                        {
                            enderr = true;
                            MessageBox.Show("Возникла непредвиденная ошибка данных. Проверьте на корректность ввода только что введённые значения.");
                            break;                           
                        }
                        catch (NullReferenceException)
                        {
                            enderr = true;
                            MessageBox.Show("Какая-то из ячеек не заполнена полностью. Заполните пустые ячейки.");
                            break;
                        }
                        catch (FormatException)
                        {
                            enderr = true;
                            MessageBox.Show("В какой то из ячеек содержится некорректная информация, либо поле id не увеличивается на 1. Измените данные и попробуйте снова.");
                            break;
                        }

                    }
                    if (enderr == false)
                    {
                        MessageBox.Show("Изменения внесены!");
                        connection.Close();
                    }
                }
                else if (UsersRadioBtn.Checked == true)
                {
                    bool enderr = false;
                    int u_num = 0;
                    string name = "", login = "", password = "", query = "", type = "";
                    for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                    {
                        MySqlCommand command = new MySqlCommand(query, connection);
                        try
                        {
                            u_num = Convert.ToInt32(dataGridView1[0, i].Value.ToString());
                            login = dataGridView1[1, i].Value.ToString();
                            password = dataGridView1[2, i].Value.ToString();
                            name = dataGridView1[3, i].Value.ToString();
                            type = dataGridView1[4, i].Value.ToString();                                                                                                                                      
                            if (type != "admin" )
                            {
                                if (type != "cashier")
                                {
                                    enderr = true;
                                    MessageBox.Show("В текущей АИС есть 2 типа прав пользователей(cashier - кассир, admin - администратор). Проверьте поля колонки type и попробуйте снова.");
                                    break;
                                }
                            }
                            else if(type != "cashier")
                            {
                                if (type != "admin")
                                {
                                    enderr = true;
                                    MessageBox.Show("В текущей АИС есть 2 типа прав пользователей(cashier - кассир, admin - администратор). Проверьте поля колонки type и попробуйте снова.");
                                    break;
                                }
                            }
                            query = "UPDATE users SET login = '" + login + "', password = '" + password + "', name = '" + name + "', type = '" + type + "' WHERE u_num = " + u_num;
                            command = new MySqlCommand(query, connection);
                            var tr = command.ExecuteNonQuery();
                            if (tr == 0)
                            {
                                query = "INSERT INTO users (id, login, password, name) VALUES (" + u_num + ", '" + login + "', '" + password + "', '" + name + "', '" + type + "')";
                                command = new MySqlCommand(query, connection);
                                command.ExecuteNonQuery();
                            }

                        }
                        catch (MySqlException)
                        {                                                       
                            enderr = true;
                            MessageBox.Show("Возникла непредвиденная ошибка данных. Проверьте на корректность ввода только что введённые значения.");
                            break;
                        }
                        catch (NullReferenceException)
                        {
                            enderr = true;
                            MessageBox.Show("Какая-то из ячеек не заполнена полностью. Заполните пустые ячейки.");
                            break;
                        }
                        catch (FormatException)
                        {
                            enderr = true;
                            MessageBox.Show("В какой то из ячеек содержится некорректная информация, либо поле id не увеличивается на 1. Измените данные и попробуйте снова.");
                            break;
                        }

                    }
                    if (enderr == false)
                    {
                        MessageBox.Show("Изменения внесены!");
                        connection.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Ошибка! Таблица не выбрана.");
                }
                
            }
            else if (dialogResult == DialogResult.No)
            {
                //do nothing
            }
        }
       
        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (CourseRadioBtn.Checked == true)
            {
                MessageBox.Show("Удаление строк в данной таблице невозможно!");                
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Удалить данную строку из БД", "Вы уверены?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    string table = "";
                    if (OperationsRadioBtn.Checked == true)
                    {
                        table = "operations";
                    }                    
                    else if (ClientsRadioBtn.Checked == true)
                    {
                        table = "clients";                        
                    }
                    else if (UsersRadioBtn.Checked == true)
                    {
                        table = "users";
                    }
                    string connectionString = "server = localhost; user = root; database = aisdatabd; password = root123;";
                    MySqlConnection connection = new MySqlConnection(connectionString);
                    connection.Open();
                    string query = "";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    query = "DELETE FROM " + table + " WHERE u_num = " + Convert.ToInt32(dataGridView1[0, e.Row.Index].Value.ToString());
                    command = new MySqlCommand(query, connection);
                    command.ExecuteNonQuery();
                    connection.Close();
                }                
            }
        }

        private void dataGridView1_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            if (CourseRadioBtn.Checked == true)
            {
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();

                //datagrid
                string connStr = "server=localhost;user=root;database=aisdatabd;password=root123;";
                MySqlConnection conn = new MySqlConnection(connStr);

                MySqlCommand command = new MySqlCommand();
                string commandString = "SELECT * FROM currencycourse;";
                command.CommandText = commandString;
                command.Connection = conn;
                MySqlDataReader reader;
                try
                {
                    command.Connection.Open();
                    reader = command.ExecuteReader();
                    this.dataGridView1.Columns.Add("id", "ID");
                    this.dataGridView1.Columns["id"].Width = 20;
                    this.dataGridView1.Columns.Add("name", "Name");
                    this.dataGridView1.Columns["name"].Width = 50;
                    this.dataGridView1.Columns.Add("summsale", "SummSale");
                    this.dataGridView1.Columns["summsale"].Width = 100;
                    this.dataGridView1.Columns.Add("summpurchase", "SummPurchase");
                    this.dataGridView1.Columns["summpurchase"].Width = 100;
                    while (reader.Read())
                    {
                        dataGridView1.Rows.Add(reader["id"].ToString(), reader["name"].ToString(), reader["summsale"].ToString(), reader["summpurchase"].ToString());
                    }
                    reader.Close();
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Error: \r\n{0}", ex.ToString());
                }
                finally
                {
                    command.Connection.Close();
                }
            }            
        }

        private void AdminWindow_Load(object sender, EventArgs e)
        {
            NameAdmin.Text = AuthForm.nameUser;
        }

        private void mainPanel_VisibleChanged(object sender, EventArgs e)
        {
            string connStr = "server=localhost;user=root;database=aisdatabd;password=root123;";
            MySqlConnection conn = new MySqlConnection(connStr);

            MySqlCommand command = new MySqlCommand();
            string commandString = "SELECT summsale, summpurchase FROM currencycourse WHERE name = 'USD';";
            command.CommandText = commandString;
            command.Connection = conn;
            MySqlDataReader reader;
            try
            {
                command.Connection.Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    USD_sell.Text = reader["summsale"].ToString().Replace(',', '.');
                    USD_buy.Text = reader["summpurchase"].ToString().Replace(',', '.');
                }
                reader.Close();
                commandString = "SELECT summsale, summpurchase FROM currencycourse WHERE name = 'EUR';";
                command.CommandText = commandString;
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    EUR_sell.Text = reader["summsale"].ToString().Replace(',', '.');
                    EUR_buy.Text = reader["summpurchase"].ToString().Replace(',', '.');
                }
                reader.Close();
                commandString = "SELECT summsale, summpurchase FROM currencycourse WHERE name = 'GBP';";
                command.CommandText = commandString;
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    GBP_sell.Text = reader["summsale"].ToString().Replace(',', '.');
                    GBP_buy.Text = reader["summpurchase"].ToString().Replace(',', '.');
                }
                reader.Close();
                commandString = "SELECT summsale, summpurchase FROM currencycourse WHERE name = 'CHF';";
                command.CommandText = commandString;
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    CHF_sell.Text = reader["summsale"].ToString().Replace(',', '.');
                    CHF_buy.Text = reader["summpurchase"].ToString().Replace(',', '.');
                }
                reader.Close();
                commandString = "SELECT summsale, summpurchase FROM currencycourse WHERE name = 'JPY';";
                command.CommandText = commandString;
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    JPY_sell.Text = reader["summsale"].ToString().Replace(',', '.');
                    JPY_buy.Text = reader["summpurchase"].ToString().Replace(',', '.');
                }
                reader.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: \r\n{0}", ex.ToString());
            }
            finally
            {
                command.Connection.Close();
            }
        }        
    }
}
