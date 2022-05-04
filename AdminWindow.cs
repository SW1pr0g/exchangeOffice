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
using System.IO;

namespace AIS_exchangeOffice
{
    public partial class AdminWindow : Form
    {
        
        public bool valuesEdited = false;
        public static string admin_login = "", admin_password = ""; 
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
            //выход из аккаунта
            DialogResult dialogResult = MessageBox.Show("Выйти из аккаунта?", "Выход из аккаунта", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                AuthForm showAuthForm = new AuthForm();
                showAuthForm.Show();
                this.Hide();
            }
            else if (dialogResult == DialogResult.No)
            {
                //ничего не делать
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
                //ничего не делать
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
                //ничего не делать
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
                //ничего не делать
            }
        }

        private void MainBtn_Click(object sender, EventArgs e)
        {
            pnlNav.Height = MainBtn.Height;
            pnlNav.Top = MainBtn.Top;
            pnlNav.Left = MainBtn.Left;
            MainBtn.BackColor = Color.FromArgb(46, 51, 73);
            otchetPanel.Visible = false;
            mainPanel.Visible = true;
            addclientPanel.Visible = false;
            add_valuesPanel.Visible = false;
            operationsOtchetBuyClient.Visible = false;
            operationsOtchetSellClient.Visible = false;
            searchPanel.Visible = false;
            exchangePanel.Visible = false;
            currencies_exchangePanel.Visible = false;
            clientsPanel.Visible = false;
            bdPanel.Visible = false;
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
            otchetPanel.Visible = false;
            mainPanel.Visible = false;
            addclientPanel.Visible = false;
            add_valuesPanel.Visible = false;
            operationsOtchetBuyClient.Visible = false;
            operationsOtchetSellClient.Visible = false;
            searchPanel.Visible = false;
            exchangePanel.Visible = false;
            currencies_exchangePanel.Visible = false;
            clientsPanel.Visible = true;
            bdPanel.Visible = false;
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
            otchetPanel.Visible = false;
            mainPanel.Visible = false;
            addclientPanel.Visible = false;
            add_valuesPanel.Visible = false;
            operationsOtchetBuyClient.Visible = false;
            operationsOtchetSellClient.Visible = false;
            searchPanel.Visible = false;
            exchangePanel.Visible = true;
            currencies_exchangePanel.Visible = false;
            clientsPanel.Visible = false;
            bdPanel.Visible = false;
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
            otchetPanel.Visible = false;
            mainPanel.Visible = false;
            addclientPanel.Visible = false;
            add_valuesPanel.Visible = false;
            operationsOtchetBuyClient.Visible = false;
            operationsOtchetSellClient.Visible = false;
            searchPanel.Visible = true;
            exchangePanel.Visible = false;
            currencies_exchangePanel.Visible = false;
            clientsPanel.Visible = false;
            bdPanel.Visible = false;
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
            otchetPanel.Visible = false;
            mainPanel.Visible = false;
            addclientPanel.Visible = false;
            add_valuesPanel.Visible = false;
            operationsOtchetBuyClient.Visible = false;
            operationsOtchetSellClient.Visible = false;
            searchPanel.Visible = false;
            exchangePanel.Visible = false;
            currencies_exchangePanel.Visible = false;
            clientsPanel.Visible = false;
            bdPanel.Visible = true;

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
            otchetPanel.Visible = true;
            mainPanel.Visible = false;
            addclientPanel.Visible = false;
            add_valuesPanel.Visible = false;
            operationsOtchetBuyClient.Visible = false;
            operationsOtchetSellClient.Visible = false;
            searchPanel.Visible = false;
            exchangePanel.Visible = false;
            currencies_exchangePanel.Visible = false;
            clientsPanel.Visible = false;
            bdPanel.Visible = false;
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
                this.dataGridView1.Columns["date_birth"].Width = 89;
                this.dataGridView1.Columns.Add("seriesDoc", "SeriesDoc");
                this.dataGridView1.Columns["seriesDoc"].Width = 75;
                this.dataGridView1.Columns.Add("numberDoc", "NumberDoc");
                this.dataGridView1.Columns["numberDoc"].Width = 81;
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
                                query = "INSERT INTO users (u_num, login, password, name, type) VALUES (" + u_num.ToString() + ", '" + login + "', '" + password + "', '" + name + "', '" + type + "');";
                                command = new MySqlCommand(query, connection);
                                command.ExecuteNonQuery();
                            }

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
                    MessageBox.Show("Удаление успешно!");
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
                string commandString1 = "SELECT COUNT(*) FROM clients;";
                command.CommandText = commandString1;
                ClientsNum.Text = command.ExecuteScalar().ToString();
                commandString = "SELECT summsale, summpurchase FROM currencycourse WHERE name = 'USD';";
                command.CommandText = commandString;
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
                commandString = "SELECT value FROM currency_values WHERE name = 'USD';";
                command.CommandText = commandString;
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    USD_value.Text = "$ " + reader["value"].ToString().Replace(',', '.');
                }
                reader.Close();
                commandString = "SELECT value FROM currency_values WHERE name = 'EUR';";
                command.CommandText = commandString;
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    EUR_value.Text = "€ " + reader["value"].ToString().Replace(',', '.');
                }
                reader.Close();
                commandString = "SELECT value FROM currency_values WHERE name = 'GBP';";
                command.CommandText = commandString;
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    GBP_value.Text = "£ " + reader["value"].ToString().Replace(',', '.');
                }
                reader.Close();
                commandString = "SELECT value FROM currency_values WHERE name = 'CHF';";
                command.CommandText = commandString;
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    CHF_value.Text = "₣ " + reader["value"].ToString().Replace(',', '.');
                }
                reader.Close();
                commandString = "SELECT value FROM currency_values WHERE name = 'JPY';";
                command.CommandText = commandString;
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    JPY_value.Text = "¥ " + reader["value"].ToString().Replace(',', '.');
                }
                reader.Close();
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("Error: \r\n{0}", ex.ToString());
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

        private void valuesEdit_btn_Click(object sender, EventArgs e)
        {
            if (valuesEdited == false)
            {
                sellUSD_edit.Visible = true;
                sellUSD_edit.Text = USD_sell.Text;
                buyUSD_edit.Visible = true;
                buyUSD_edit.Text = USD_buy.Text;
                sellEUR_edit.Visible = true;
                sellEUR_edit.Text = EUR_sell.Text;
                buyEUR_edit.Visible = true;
                buyEUR_edit.Text = EUR_buy.Text;
                sellGBP_edit.Visible = true;
                sellGBP_edit.Text = GBP_sell.Text;
                buyGBP_edit.Visible = true;
                buyGBP_edit.Text = GBP_buy.Text;
                sellCHF_edit.Visible = true;
                sellCHF_edit.Text = CHF_sell.Text;
                buyCHF_edit.Visible = true;
                buyCHF_edit.Text = CHF_buy.Text;
                sellJPY_edit.Visible = true;
                sellJPY_edit.Text = JPY_sell.Text;
                buyJPY_edit.Visible = true;
                buyJPY_edit.Text = JPY_buy.Text;
                valuesEdited = true;
                valuesEdit_btn.Image = Image.FromFile(@Directory.GetCurrentDirectory() + "\\images\\icons\\edit_accept.png");
            }
            else if (valuesEdited == true)
            {
                if (sellUSD_edit.Text == "" || buyUSD_edit.Text == "" || sellEUR_edit.Text == "" || buyEUR_edit.Text == "" || sellGBP_edit.Text == "" || buyGBP_edit.Text == "" || sellCHF_edit.Text == "" || buyCHF_edit.Text == "" || sellJPY_edit.Text == "" || buyJPY_edit.Text == "" || sellUSD_edit.Text.Count(chr => chr == '.') > 1 || buyUSD_edit.Text.Count(chr => chr == '.') > 1 || sellEUR_edit.Text.Count(chr => chr == '.') > 1 || buyEUR_edit.Text.Count(chr => chr == '.') > 1 || sellGBP_edit.Text.Count(chr => chr == '.') > 1 || buyGBP_edit.Text.Count(chr => chr == '.') > 1 || sellCHF_edit.Text.Count(chr => chr == '.') > 1 || buyCHF_edit.Text.Count(chr => chr == '.') > 1 || sellJPY_edit.Text.Count(chr => chr == '.') > 1 || buyJPY_edit.Text.Count(chr => chr == '.') > 1 || sellUSD_edit.Text[0] == '.' || buyUSD_edit.Text[0] == '.' || sellEUR_edit.Text[0] == '.' || buyEUR_edit.Text[0] == '.' || sellGBP_edit.Text[0] == '.' || buyGBP_edit.Text[0] == '.' || sellCHF_edit.Text[0] == '.' || buyCHF_edit.Text[0] == '.' || sellJPY_edit.Text[0] == '.' || buyJPY_edit.Text[0] == '.')
                {
                    MessageBox.Show("Ошибка! Заполните все поля изменения валюты или введите корректные значения в эти поля.");
                    return;
                }

                string connStr = "server=localhost;user=root;database=aisdatabd;password=root123;";
                MySqlConnection conn = new MySqlConnection(connStr);

                MySqlCommand command = new MySqlCommand();

                //вставить здесь редактирование БД
                command.Connection = conn;
                command.Connection.Open();
                string commandString = "UPDATE currencycourse SET summsale = " + Math.Round(Convert.ToDouble(sellUSD_edit.Text.Replace('.', ',')), 2).ToString().Replace(',', '.') + ", summpurchase = " + Math.Round(Convert.ToDouble(buyUSD_edit.Text.Replace('.', ',')), 2).ToString().Replace(',', '.') + " WHERE name = 'USD'";
                command = new MySqlCommand(commandString, conn);
                command.ExecuteNonQuery();
                commandString = "UPDATE currencycourse SET summsale = " + Math.Round(Convert.ToDouble(sellEUR_edit.Text.Replace('.', ',')), 2).ToString().Replace(',', '.') + ", summpurchase = " + Math.Round(Convert.ToDouble(buyEUR_edit.Text.Replace('.', ',')), 2).ToString().Replace(',', '.') + " WHERE name = 'EUR'";
                command = new MySqlCommand(commandString, conn);
                command.ExecuteNonQuery();
                commandString = "UPDATE currencycourse SET summsale = " + Math.Round(Convert.ToDouble(sellGBP_edit.Text.Replace('.', ',')), 2).ToString().Replace(',', '.') + ", summpurchase = " + Math.Round(Convert.ToDouble(buyGBP_edit.Text.Replace('.', ',')), 2).ToString().Replace(',', '.') + " WHERE name = 'GBP'";
                command = new MySqlCommand(commandString, conn);
                command.ExecuteNonQuery();
                commandString = "UPDATE currencycourse SET summsale = " + Math.Round(Convert.ToDouble(sellCHF_edit.Text.Replace('.', ',')), 2).ToString().Replace(',', '.') + ", summpurchase = " + Math.Round(Convert.ToDouble(buyCHF_edit.Text.Replace('.', ',')), 2).ToString().Replace(',', '.') + " WHERE name = 'CHF'";
                command = new MySqlCommand(commandString, conn);
                command.ExecuteNonQuery();
                commandString = "UPDATE currencycourse SET summsale = " + Math.Round(Convert.ToDouble(sellJPY_edit.Text.Replace('.', ',')), 2).ToString().Replace(',', '.') + ", summpurchase = " + Math.Round(Convert.ToDouble(buyJPY_edit.Text.Replace('.', ',')), 2).ToString().Replace(',', '.') + " WHERE name = 'JPY'";
                command = new MySqlCommand(commandString, conn);
                command.ExecuteNonQuery();

                command.Connection.Close();

                commandString = "SELECT summsale, summpurchase FROM currencycourse WHERE name = 'USD';";
                command.CommandText = commandString;
                command.Connection = conn;
                MySqlDataReader reader;
                try
                {
                    command.Connection.Open();
                    string commandString1 = "SELECT COUNT(*) FROM clients;";
                    command.CommandText = commandString1;
                    ClientsNum.Text = command.ExecuteScalar().ToString();
                    commandString = "SELECT summsale, summpurchase FROM currencycourse WHERE name = 'USD';";
                    command.CommandText = commandString;
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
                    commandString = "SELECT value FROM currency_values WHERE name = 'USD';";
                    command.CommandText = commandString;
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        USD_value.Text = "$ " + reader["value"].ToString().Replace(',', '.');
                    }
                    reader.Close();
                    commandString = "SELECT value FROM currency_values WHERE name = 'EUR';";
                    command.CommandText = commandString;
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        EUR_value.Text = "€ " + reader["value"].ToString().Replace(',', '.');
                    }
                    reader.Close();
                    commandString = "SELECT value FROM currency_values WHERE name = 'GBP';";
                    command.CommandText = commandString;
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        GBP_value.Text = "£ " + reader["value"].ToString().Replace(',', '.');
                    }
                    reader.Close();
                    commandString = "SELECT value FROM currency_values WHERE name = 'CHF';";
                    command.CommandText = commandString;
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        CHF_value.Text = "₣ " + reader["value"].ToString().Replace(',', '.');
                    }
                    reader.Close();
                    commandString = "SELECT value FROM currency_values WHERE name = 'JPY';";
                    command.CommandText = commandString;
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        JPY_value.Text = "¥ " + reader["value"].ToString().Replace(',', '.');
                    }
                    reader.Close();
                }
                catch (NullReferenceException ex)
                {
                    Console.WriteLine("Error: \r\n{0}", ex.ToString());
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Error: \r\n{0}", ex.ToString());
                }
                finally
                {
                    command.Connection.Close();
                }
                sellUSD_edit.Visible = false;
                buyUSD_edit.Visible = false;
                sellEUR_edit.Visible = false;
                buyEUR_edit.Visible = false;
                sellGBP_edit.Visible = false;
                buyGBP_edit.Visible = false;
                sellCHF_edit.Visible = false;
                buyCHF_edit.Visible = false;
                sellJPY_edit.Visible = false;
                buyJPY_edit.Visible = false;
                valuesEdited = false;
                valuesEdit_btn.Image = Image.FromFile(@Directory.GetCurrentDirectory() + "\\images\\icons\\edit.png");
            }
        }

        private void sellUSD_edit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8 || e.KeyChar == 127 || e.KeyChar == 46)
            {
                e.Handled = false;
            }
            else
            {
                if (Char.IsDigit(e.KeyChar)) return;
                else
                    e.Handled = true;
            }
        }

        private void buyUSD_edit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8 || e.KeyChar == 127 || e.KeyChar == 46)
            {
                e.Handled = false;
            }
            else
            {
                if (Char.IsDigit(e.KeyChar)) return;
                else
                    e.Handled = true;
            }
        }

        private void buyEUR_edit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8 || e.KeyChar == 127 || e.KeyChar == 46)
            {
                e.Handled = false;
            }
            else
            {
                if (Char.IsDigit(e.KeyChar)) return;
                else
                    e.Handled = true;
            }
        }

        private void buyGBP_edit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8 || e.KeyChar == 127 || e.KeyChar == 46)
            {
                e.Handled = false;
            }
            else
            {
                if (Char.IsDigit(e.KeyChar)) return;
                else
                    e.Handled = true;
            }
        }

        private void buyCHF_edit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8 || e.KeyChar == 127 || e.KeyChar == 46)
            {
                e.Handled = false;
            }
            else
            {
                if (Char.IsDigit(e.KeyChar)) return;
                else
                    e.Handled = true;
            }
        }

        private void buyJPY_edit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8 || e.KeyChar == 127 || e.KeyChar == 46)
            {
                e.Handled = false;
            }
            else
            {
                if (Char.IsDigit(e.KeyChar)) return;
                else
                    e.Handled = true;
            }
        }

        private void sellEUR_edit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8 || e.KeyChar == 127 || e.KeyChar == 46)
            {
                e.Handled = false;
            }
            else
            {
                if (Char.IsDigit(e.KeyChar)) return;
                else
                    e.Handled = true;
            }
        }

        private void sellGBP_edit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8 || e.KeyChar == 127 || e.KeyChar == 46)
            {
                e.Handled = false;
            }
            else
            {
                if (Char.IsDigit(e.KeyChar)) return;
                else
                    e.Handled = true;
            }
        }

        private void sellCHF_edit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8 || e.KeyChar == 127 || e.KeyChar == 46)
            {
                e.Handled = false;
            }
            else
            {
                if (Char.IsDigit(e.KeyChar)) return;
                else
                    e.Handled = true;
            }
        }

        private void sellJPY_edit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8 || e.KeyChar == 127 || e.KeyChar == 46)
            {
                e.Handled = false;
            }
            else
            {
                if (Char.IsDigit(e.KeyChar)) return;
                else
                    e.Handled = true;
            }
        }

        private void print_currencies_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Вывести на печать данные о текущем курсе валют?", "Печать текущего курса валют", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                var helper = new classes.wordHelper("wordDocs/currencycourse_print.docx");
                var items = new Dictionary<string, string>
                {
                    { "_<date>_", DateTime.Now.ToString().Substring(0, 10) },
                    { "_<date_update>_", DateTime.Now.ToString() },
                    { "_<USD_sell>_", USD_sell.Text },
                    { "_<USD_buy>_", USD_buy.Text },
                    { "_<EUR_sell>_", EUR_sell.Text },
                    { "_<EUR_buy>_", EUR_buy.Text },
                    { "_<GBP_sell>_", GBP_sell.Text },
                    { "_<GBP_buy>_", GBP_buy.Text },
                    { "_<CHF_sell>_", CHF_sell.Text },
                    { "_<CHF_buy>_", CHF_buy.Text },
                    { "_<JPY_sell>_", JPY_sell.Text },
                    { "_<JPY_buy>_", JPY_buy.Text },
                };
                MessageBox.Show("Сейчас откроется документ на печать. Документ находится в корневой папке программы(AIS_exchangeOffice/wordDocs)");
                helper.Process(items);
            }
            else if (dialogResult == DialogResult.No)
            {
                //do nothing
            }
        }

        private void goBackValuesBtn_Click(object sender, EventArgs e)
        {
            mainPanel.Visible = true;
            add_valuesPanel.Visible = false;
            bdPanel.Visible = false;
            otchetPanel.Visible = false;
            searchPanel.Visible = false;
            exchangePanel.Visible = false;
            clientsPanel.Visible = false;
        }

        private void add_valuesBtn_Click(object sender, EventArgs e)
        {
            mainPanel.Visible = false;
            add_valuesPanel.Visible = true;
            bdPanel.Visible = false;
            otchetPanel.Visible = false;
            searchPanel.Visible = false;
            exchangePanel.Visible = false;
            clientsPanel.Visible = false;
        }

        private void pictureBox12_MouseDown(object sender, MouseEventArgs e)
        {
            if (passBox.Text == "Введите ваш пароль")
            {
                //
            }
            else
            {
                passBox.UseSystemPasswordChar = false;
            }            
        }

        private void pictureBox12_MouseUp(object sender, MouseEventArgs e)
        {
            if (passBox.Text == "Введите ваш пароль")
            {
                //
            }
            else
            {
                passBox.UseSystemPasswordChar = true;
            }
        }

        private void passBox_Enter(object sender, EventArgs e)
        {
            if (passBox.Text == "Введите ваш пароль")
            {
                passBox.Text = "";
                passBox.ForeColor = Color.FromArgb(11, 100, 103);
                passBox.UseSystemPasswordChar = true;
            }
        }

        private void passBox_Leave(object sender, EventArgs e)
        {
            if (passBox.Text == "")
            {
                passBox.Text = "Введите ваш пароль";
                passBox.ForeColor = Color.Silver;
                passBox.UseSystemPasswordChar = false;
            }
        }

        private void quantityBox_Enter(object sender, EventArgs e)
        {
            if (quantityBox.Text == "Введите количество валюты")
            {
                quantityBox.ForeColor = Color.FromArgb(11, 100, 103);                
                quantityBox.Text = "";
            }
        }

        private void quantityBox_Leave(object sender, EventArgs e)
        {
            if (quantityBox.Text == "")
            {
                quantityBox.ForeColor = Color.Silver;
                quantityBox.Text = "Введите количество валюты";
            }
        }

        private void add_valuesPanel_VisibleChanged(object sender, EventArgs e)
        {
            name_admin.Text = NameAdmin.Text;
            login_admin.Text = "Ваш логин: " + admin_login;
        }

        private void exchangedBtn_Click(object sender, EventArgs e)
        {
            if (passBox.Text == "" || passBox.Text == "Введите ваш пароль")
            {
                MessageBox.Show("Ошибка! Пароль не введён.");
                return;
            }
            else if (selectValueBox.Text == "Выберите валюту для заказа")
            {
                MessageBox.Show("Ошибка! Валюта для заказа не выбрана.");
                return;
            }
            else if (quantityBox.Text == "Введите количество валюты")
            {
                MessageBox.Show("Ошибка! Количество валюты не выбрано.");
                return;
            }
            else if (passBox.Text != admin_password)
            {
                MessageBox.Show("Ошибка! Ваш пароль некорректен.");
                return;
            }
            else
            {
                string connectionString = "server = localhost; user = root; database = aisdatabd; password = root123;";
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();
                string query = "";
                MySqlCommand command = new MySqlCommand(query, connection);
                double numValue = 0.0;
                string nameValue = null;
                switch (selectValueBox.SelectedIndex)
                {
                    case 0:
                        numValue = Convert.ToDouble(USD_value.Text.Substring(1).Replace('.', ',')) + Convert.ToDouble(quantityBox.Text.Replace('.', ','));
                        nameValue = "USD";
                        break;
                    case 1:
                        numValue = Convert.ToDouble(EUR_value.Text.Substring(1).Replace('.', ',')) + Convert.ToDouble(quantityBox.Text.Replace('.', ','));
                        nameValue = "EUR";
                        break;
                    case 2:
                        numValue = Convert.ToDouble(GBP_value.Text.Substring(1).Replace('.', ',')) + Convert.ToDouble(quantityBox.Text.Replace('.', ','));
                        nameValue = "GBP";
                        break;
                    case 3:
                        numValue = Convert.ToDouble(CHF_value.Text.Substring(1).Replace('.', ',')) + Convert.ToDouble(quantityBox.Text.Replace('.', ','));
                        nameValue = "CHF";
                        break;
                    case 4:
                        numValue = Convert.ToDouble(JPY_value.Text.Substring(1).Replace('.', ',')) + Convert.ToDouble(quantityBox.Text.Replace('.', ','));
                        nameValue = "JPY";
                        break;
                }
                query = "UPDATE currency_values SET value = " + Math.Round(numValue, 3).ToString().Replace(',', '.') + " WHERE name = '" + nameValue + "'";
                command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();
                MessageBox.Show("Заказ успешно совершен!\nСейчас будет произведена печать документа о заказе валюты.");
                Random rnd = new Random();               
                var items = new Dictionary<string, string>
                        {
                            { "_<number>_", rnd.Next(99999, 1000000).ToString() },
                            { "_<date>_", DateTime.Now.ToString("dd.MM.yyyy") },
                            { "_<admin_name>_", NameAdmin.Text },
                            { "_<value>_", selectValueBox.Text },
                            { "_<quantity>_", quantityBox.Text },                                                      
                            { "_<date_long>_", DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss") },
                        };
                var helper = new classes.wordHelper("wordDocs/ordertransaction_print.docx");
                helper.Process(items);
                passBox.Text = "Введите ваш пароль";
                passBox.UseSystemPasswordChar = false;
                passBox.ForeColor = Color.Silver;
                selectValueBox.Text = "Выберите валюту для заказа";
                selectValueBox.ForeColor = Color.Silver;
                quantityBox.Text = "Введите количество валюты";
                quantityBox.ForeColor = Color.Silver;
                add_valuesPanel.Visible = false;
                mainPanel.Visible = true;
            }
        }

        private void selectValueBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectValueBox.ForeColor = Color.FromArgb(11, 100, 103);
        }

        private void selectValueBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar)) { e.Handled = true; } else { e.Handled = true; }
        }

        private void goBackExchangeBtn_Click(object sender, EventArgs e)
        {
            selectClientBox.Items.Clear();
            nameBox.Text = "Введите имя";
            surnameBox.Text = "Введите фамилию";
            patronymicBox.Text = "Введите отчество";
            dateTimePicker1.Text = "01.01.2022";
            seriesBox.Text = "Введите серию документа";
            numberBox.Text = "Введите номер документа";
            currencies_exchangePanel.Visible = false;
            exchangePanel.Visible = true;
        }

        private void currencies_exchangePanel_VisibleChanged(object sender, EventArgs e)
        {
            if (currencies_exchangePanel.Visible == true)
            {
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

                    while (reader.Read())
                    {
                        selectClientBox.Items.Add(reader["surname"].ToString() + " " + reader["name"].ToString() + " " + reader["patronymic"].ToString());
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
        private void clientsPanel_VisibleChanged(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            dataGridView2.Columns.Clear();

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
                this.dataGridView2.Columns.Add("u_num", "№");
                this.dataGridView2.Columns["u_num"].Width = 45;
                this.dataGridView2.Columns.Add("surname", "Фамилия");
                this.dataGridView2.Columns["surname"].Width = 110;
                this.dataGridView2.Columns.Add("name", "Имя");
                this.dataGridView2.Columns["name"].Width = 90;
                this.dataGridView2.Columns.Add("patronymic", "Отчество");
                this.dataGridView2.Columns["patronymic"].Width = 110;
                this.dataGridView2.Columns.Add("date_birth", "Дата рождения");
                this.dataGridView2.Columns["date_birth"].Width = 90;
                this.dataGridView2.Columns.Add("seriesDoc", "Серия документа");
                this.dataGridView2.Columns["seriesDoc"].Width = 100;
                this.dataGridView2.Columns.Add("numberDoc", "Номер документа");
                this.dataGridView2.Columns["numberDoc"].Width = 100;
                while (reader.Read())
                {
                    classes.reversedate reversedate = new classes.reversedate();
                    dataGridView2.Rows.Add(reader["u_num"].ToString(), reader["surname"].ToString(), reader["name"].ToString(), reader["patronymic"].ToString(), reversedate.dateReverse(reader["date_birth"].ToString()), reader["seriesDoc"].ToString(), reader["numberDoc"].ToString());
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
            clientsNumT.Text = dataGridView2.RowCount.ToString();
        }

        private void AddClientsBtn_Click(object sender, EventArgs e)
        {
            clientsPanel.Visible = false;
            addclientPanel.Visible = true;
        }

        private void GoBackClientsPanel_Click(object sender, EventArgs e)
        {
            clientsPanel.Visible = true;
            addclientPanel.Visible = false;
        }

        private void quantityBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8 || e.KeyChar == 127 || e.KeyChar == 46)
            {
                e.Handled = false;
            }
            else
            {
                if (Char.IsDigit(e.KeyChar)) return;
                else
                    e.Handled = true;
            }
        }
        private void surnameBox_Enter(object sender, EventArgs e)
        {
            if (surnameBox.Text == "Введите фамилию")
            {
                surnameBox.Text = null;
                surnameBox.ForeColor = Color.FromArgb(11, 100, 103);
            }
        }
        private void surnameBox_Leave(object sender, EventArgs e)
        {
            if (surnameBox.Text == "")
            {
                surnameBox.Text = "Введите фамилию";
                surnameBox.ForeColor = Color.Silver;
            }
        }
        private void surnameBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar))
                if ((e.KeyChar > 32 && e.KeyChar < 48) || (e.KeyChar > 57 && e.KeyChar < 65) || (e.KeyChar > 90 && e.KeyChar < 97) || (e.KeyChar > 122 && e.KeyChar < 256))
                    e.Handled = true;
                else
                    e.Handled = false;
            else if (e.KeyChar == 8)
                e.Handled = false;
            else
                e.Handled = true;
        }
        private void nameBox_Enter(object sender, EventArgs e)
        {
            if (nameBox.Text == "Введите имя")
            {
                nameBox.Text = null;
                nameBox.ForeColor = Color.FromArgb(11, 100, 103);
            }
        }

        private void nameBox_Leave(object sender, EventArgs e)
        {
            if (nameBox.Text == "")
            {
                nameBox.Text = "Введите имя";
                nameBox.ForeColor = Color.Silver;
            }
        }
        private void nameBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar))
                if ((e.KeyChar > 32 && e.KeyChar < 48) || (e.KeyChar > 57 && e.KeyChar < 65) || (e.KeyChar > 90 && e.KeyChar < 97) || (e.KeyChar > 122 && e.KeyChar < 256))
                    e.Handled = true;
                else
                    e.Handled = false;
            else if (e.KeyChar == 8)
                e.Handled = false;
            else
                e.Handled = true;
        }
        private void patronymicBox_Enter(object sender, EventArgs e)
        {
            if (patronymicBox.Text == "Введите отчество")
            {
                patronymicBox.Text = null;
                patronymicBox.ForeColor = Color.FromArgb(11, 100, 103);
            }
        }
        private void patronymicBox_Leave(object sender, EventArgs e)
        {
            if (patronymicBox.Text == "")
            {
                patronymicBox.Text = "Введите отчество";
                patronymicBox.ForeColor = Color.Silver;
            }
        }
        private void patronymicBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar))
                if ((e.KeyChar > 32 && e.KeyChar < 48) || (e.KeyChar > 57 && e.KeyChar < 65) || (e.KeyChar > 90 && e.KeyChar < 97) || (e.KeyChar > 122 && e.KeyChar < 256))
                    e.Handled = true;
                else
                    e.Handled = false;
            else if (e.KeyChar == 8)
                e.Handled = false;
            else
                e.Handled = true;
        }
        private void seriesBox_Enter(object sender, EventArgs e)
        {
            if (seriesBox.Text == "Введите серию документа")
            {
                seriesBox.Text = null;
                seriesBox.MaxLength = 4;
                seriesBox.ForeColor = Color.FromArgb(11, 100, 103);
            }
        }
        private void seriesBox_Leave(object sender, EventArgs e)
        {
            if (seriesBox.Text == "")
            {
                seriesBox.MaxLength = 32767;
                seriesBox.Text = "Введите серию документа";
                seriesBox.ForeColor = Color.Silver;
            }
        }
        private void seriesBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8) { }
            else
            {
                if (Char.IsDigit(e.KeyChar)) return;
                else
                    e.Handled = true;
            }
        }
        private void numberBox_Enter(object sender, EventArgs e)
        {
            if (numberBox.Text == "Введите номер документа")
            {
                numberBox.Text = null;
                numberBox.MaxLength = 6;
                numberBox.ForeColor = Color.FromArgb(11, 100, 103);
            }
        }
        private void numberBox_Leave(object sender, EventArgs e)
        {
            if (numberBox.Text == "")
            {
                seriesBox.MaxLength = 32767;
                numberBox.Text = "Введите номер документа";
                numberBox.ForeColor = Color.Silver;
            }
        }
        private void numberBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8) { }
            else
            {
                if (Char.IsDigit(e.KeyChar)) return;
                else
                    e.Handled = true;
            }
        }

        private void exchangePanel_VisibleChanged(object sender, EventArgs e)
        {
            dataGridView3.Rows.Clear();
            dataGridView3.Columns.Clear();

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
                this.dataGridView3.Columns.Add("u_num", "Уникальный номер");
                this.dataGridView3.Columns["u_num"].Width = 75;
                this.dataGridView3.Columns.Add("surname", "Фамилия");
                this.dataGridView3.Columns["surname"].Width = 66;
                this.dataGridView3.Columns.Add("name", "Имя");
                this.dataGridView3.Columns["name"].Width = 60;
                this.dataGridView3.Columns.Add("patronymic", "Отчество");
                this.dataGridView3.Columns["patronymic"].Width = 75;
                this.dataGridView3.Columns.Add("type", "Тип операции");
                this.dataGridView3.Columns["type"].Width = 65;
                this.dataGridView3.Columns.Add("value", "Валюта");
                this.dataGridView3.Columns["value"].Width = 55;
                this.dataGridView3.Columns.Add("quantity", "Количество валюты");
                this.dataGridView3.Columns["quantity"].Width = 69;
                this.dataGridView3.Columns.Add("summ", "Сумма операции");
                this.dataGridView3.Columns["summ"].Width = 60;
                this.dataGridView3.Columns.Add("date", "Дата и время");
                this.dataGridView3.Columns["date"].Width = 107;
                while (reader.Read())
                {
                    classes.reversedate reversedate = new classes.reversedate();
                    dataGridView3.Rows.Add(reader["u_num"].ToString(), reader["surname"].ToString(), reader["name"].ToString(), reader["patronymic"].ToString(), reader["type"].ToString(), reader["value"].ToString(), reader["quantity"].ToString().Replace(',', '.'), reader["summ"].ToString().Replace(',', '.'), reversedate.datetimeReverse(reader["date"].ToString()));
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

        private void buy_valuesBtn_Click(object sender, EventArgs e)
        {
            exchangePanel.Visible = false;
            currencies_exchangePanel.Visible = true;
        }

        private void goBackExchangeBtn_Click_1(object sender, EventArgs e)
        {

        }

        private void currencies_exchangePanel_VisibleChanged_1(object sender, EventArgs e)
        {

        }

        private void AddClientBtn_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Вы уверены что хотите добавить нового клиента?", "Добавление нового клиента", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    if (nameBox.Text == "Введите имя" || surnameBox.Text == "Введите фамилию" || patronymicBox.Text == "Введите отчество" || seriesBox.Text == "Введите серию документа" || numberBox.Text == "Введите номер документа")
                    {
                        MessageBox.Show("Одно или несколько полей не заполнены!");
                    }
                    else if (seriesBox.Text.Length != 4 || numberBox.Text.Length != 6)
                    {
                        MessageBox.Show("Серия имеет 4 цифры, а номер 6! Проверьте введённые значения и повторите попытку.");
                    }
                    else
                    {
                        string connectionString = "server = localhost; user = root; database = aisdatabd; password = root123;";
                        MySqlConnection connection = new MySqlConnection(connectionString);
                        connection.Open();
                        classes.reversedate getDate = new classes.reversedate();
                        Random rnd = new Random();
                        string query = "INSERT INTO clients (u_num, surname, name, patronymic, date_birth, seriesDoc, numberDoc) VALUES (" + rnd.Next(100000, 999999) + ", '" + surnameBox.Text + "', '" + nameBox.Text + "', '" + patronymicBox.Text + "', '" + getDate.dateReverse(dateTimePicker1.Value.ToString().Substring(0, 10)) + "', " + seriesBox.Text + ", " + numberBox.Text + ")";
                        MySqlCommand command = new MySqlCommand(query, connection);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Клиент успешно добавлен!");
                        nameBox.Text = "Введите имя";
                        nameBox.ForeColor = Color.Silver;
                        surnameBox.Text = "Введите фамилию";
                        surnameBox.ForeColor = Color.Silver;
                        patronymicBox.Text = "Введите отчество";
                        patronymicBox.ForeColor = Color.Silver;
                        dateTimePicker1.Text = "01.01.2000";
                        seriesBox.Text = "Введите серию документа";
                        seriesBox.ForeColor = Color.Silver;
                        numberBox.Text = "Введите номер документа";
                        numberBox.ForeColor = Color.Silver;
                        addclientPanel.Visible = false;
                        clientsPanel.Visible = true;
                    }
                }
                catch (MySqlException)
                {
                    MessageBox.Show("Произошла ошибка данных! Проверьте введённые данные.");
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                //do nothing
            }

        }

        

        private void quantityBox__TextChanged(object sender, EventArgs e)
        {
            double[] valuesBuy = { Convert.ToDouble(USD_buy.Text.Replace('.', ',')), Convert.ToDouble(EUR_buy.Text.Replace('.', ',')), Convert.ToDouble(GBP_buy.Text.Replace('.', ',')), Convert.ToDouble(CHF_buy.Text.Replace('.', ',')), Convert.ToDouble(JPY_buy.Text.Replace('.', ',')) };
            double[] valuesSell = { Convert.ToDouble(USD_sell.Text.Replace('.', ',')), Convert.ToDouble(EUR_sell.Text.Replace('.', ',')), Convert.ToDouble(GBP_sell.Text.Replace('.', ',')), Convert.ToDouble(CHF_sell.Text.Replace('.', ',')), Convert.ToDouble(JPY_sell.Text.Replace('.', ',')) };
            try
            {
                classes.summValues summValues = new classes.summValues();
                if (quantityBox_.Text.ToString()[0] == '.')
                {
                    MessageBox.Show("Значение не может начинаться с '.' или ','");
                    quantityBox_.Text = "";
                }
                else if (selectValueBox_.SelectedIndex == -1 || selectOperBox.SelectedIndex == -1)
                {
                    //
                }
                else
                {
                    summBox.Text = "Сумма: " + summValues.summoutputValues(selectOperBox.SelectedIndex, selectValueBox_.SelectedIndex, Convert.ToDouble(quantityBox_.Text.Replace('.', ',')), valuesBuy, valuesSell).ToString().Replace(',', '.') + " рублей";
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }            
        }

        private void quantityBox__Enter(object sender, EventArgs e)
        {
            if (selectOperBox.SelectedIndex == -1 || selectValueBox_.SelectedIndex == -1)
            {
                MessageBox.Show("Операция или валюта не выбраны!");
                this.ActiveControl = null;
            }

            if (quantityBox_.Text == "Введите количество покупаемой валюты" || quantityBox_.Text == "Введите количество продаваемой валюты")
            {
                quantityBox_.ForeColor = Color.FromArgb(11, 100, 103);
                panel7.Size = new Size(430, 54);
                quantityBox_.Size = new Size(413, 30);
                quantityBox_.Location = new Point(8, 11);
                panel12.Location = new Point(3, 356);
                exchangedBtn.Location = new Point(112, 425);
                panel6.Size = new Size(437, 479);
                quantityBox_.Text = "";
            }

            if (quantityBox_.Text == "Введите сумму покупаемой валюты" || quantityBox_.Text == "Введите сумму продаваемой валюты")
            {
                quantityBox_.ForeColor = Color.FromArgb(11, 100, 103);
                panel7.Size = new Size(430, 54);
                quantityBox_.Size = new Size(413, 30);
                quantityBox_.Location = new Point(8, 11);
                panel12.Location = new Point(3, 356);
                exchangedBtn.Location = new Point(112, 425);
                panel6.Size = new Size(437, 479);
                quantityBox_.Text = "";
            }
        }

        private void quantityBox__Leave(object sender, EventArgs e)
        {
            if (quantityBox_.Text == "")
            {
                quantityBox_.ForeColor = Color.Silver;
                panel7.Size = new Size(430, 76);
                quantityBox_.Size = new Size(413, 62);
                quantityBox_.Location = new Point(9, 6);
                panel12.Location = new Point(3, 375);
                exchangedBtn.Location = new Point(112, 437);
                panel6.Size = new Size(437, 491);
                quantityBox_.Text = "Введите количество покупаемой валюты";
                summBox.Text = "Сумма сделки: 0 рублей";
            }
        }

        private void quantityBox__KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8 || e.KeyChar == 127 || e.KeyChar == 46)
            {
                e.Handled = false;
            }
            else
            {
                if (Char.IsDigit(e.KeyChar)) return;
                else
                    e.Handled = true;
            }
        }

        private void selectClientBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectClientBox.ForeColor = Color.FromArgb(11, 100, 103); 
        }

        private void selectOperBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selectOperBox.SelectedIndex == 0)
            {
                quantityBox_.ForeColor = Color.Silver;
                panel7.Size = new Size(430, 76);
                quantityBox_.Size = new Size(413, 62);
                quantityBox_.Location = new Point(9, 6);
                panel12.Location = new Point(3, 375);
                exchangedBtn.Location = new Point(112, 437);
                panel6.Size = new Size(437, 491);
                quantityBox_.Text = "Введите количество покупаемой валюты";
            }
            else if (selectOperBox.SelectedIndex == 1)
            {
                quantityBox_.ForeColor = Color.Silver;
                panel7.Size = new Size(430, 76);
                quantityBox_.Size = new Size(413, 62);
                quantityBox_.Location = new Point(9, 6);
                panel12.Location = new Point(3, 375);
                exchangedBtn.Location = new Point(112, 437);
                panel6.Size = new Size(437, 491);
                quantityBox_.Text = "Введите количество продаваемой валюты";
            }
            else
            {
                quantityBox_.ForeColor = Color.Silver;
                panel7.Size = new Size(430, 54);
                quantityBox_.Size = new Size(413, 30);
                quantityBox_.Location = new Point(8, 11);
                panel12.Location = new Point(3, 356);
                exchangedBtn.Location = new Point(112, 425);
                panel6.Size = new Size(437, 479);
                quantityBox_.Text = "Введите количество валюты";
            }

            selectOperBox.ForeColor = Color.FromArgb(11, 100, 103);
            if (selectOperBox.SelectedIndex == 0)
            {
                selectValueBox_.Text = "Выберите покупаемую валюту";
                selectValueBox_.ForeColor = Color.Silver;
            }
            else if (selectOperBox.SelectedIndex == 1)
            {
                selectValueBox_.Text = "Выберите продаваемую валюту";
                selectValueBox_.ForeColor = Color.Silver;
            }                        
        }

        private void selectClientBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar)) { e.Handled = true; } else { e.Handled = true; }
        }

        private void selectValueBox__SelectedIndexChanged(object sender, EventArgs e)
        {
            selectValueBox_.ForeColor = Color.FromArgb(11, 100, 103);
        }

        private void searchBox_Enter(object sender, EventArgs e)
        {
            if (searchBox.Text == " Введите для поиска...")
            {
                searchBox.Text = null;
            }
        }

        private void searchBox_Leave(object sender, EventArgs e)
        {
            if (searchBox.Text == "")
            {
                searchBox.Text = " Введите для поиска...";
            }
        }

        private void searchBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && searchBox.Text != "")
            {
                SearchBut_Click(sender, e);
            }
        }

        private void exchangedBtn_Click_1(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Вы уверены что хотите произвести обмен по введённым данным?", "Обмен валюты", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    if (selectClientBox.Text == "Выберите клиента" || selectOperBox.Text == "Выберите операцию" || selectValueBox.Text == "Выберите продаваемую валюту" || selectValueBox.Text == "Выберите покупаемую валюту" || quantityBox.Text == "Введите количество покупаемой валюты")
                    {
                        MessageBox.Show("Одно или несколько полей не заполнены!");
                    }
                    else
                    {
                        string connectionString = "server = localhost; user = root; database = aisdatabd; password = root123;";
                        MySqlConnection connection = new MySqlConnection(connectionString);
                        connection.Open();
                        classes.reversedate getDate = new classes.reversedate();
                        Random rnd = new Random();
                        string[] FIO = selectClientBox.Text.Split(' ');
                        string[] summ = summBox.Text.Split(' ');
                        int u_num = rnd.Next(100000, 999999);
                        var helper = new classes.wordHelper("wordDocs/transaction_print.docx");
                        double[] valuesBuy = { Convert.ToDouble(USD_buy.Text.Replace('.', ',')), Convert.ToDouble(EUR_buy.Text.Replace('.', ',')), Convert.ToDouble(GBP_buy.Text.Replace('.', ',')), Convert.ToDouble(CHF_buy.Text.Replace('.', ',')), Convert.ToDouble(JPY_buy.Text.Replace('.', ',')) };
                        double[] valuesSell = { Convert.ToDouble(USD_sell.Text.Replace('.', ',')), Convert.ToDouble(EUR_sell.Text.Replace('.', ',')), Convert.ToDouble(GBP_sell.Text.Replace('.', ',')), Convert.ToDouble(CHF_sell.Text.Replace('.', ',')), Convert.ToDouble(JPY_sell.Text.Replace('.', ',')) };
                        string currency = "", nameValue = "";
                        double numValue = 0.0;
                        switch (selectValueBox.Text.ToString()[0])
                        {
                            case '$':
                                nameValue = "USD";
                                if (selectOperBox.Text == "Покупка")
                                {
                                    numValue = Convert.ToDouble(USD_value.Text.Substring(1).Replace('.', ',')) - Convert.ToDouble(quantityBox.Text.Replace('.', ','));
                                    if (numValue < 0) { MessageBox.Show("Операция не выполнена. Недостаточно валюты в кассе!"); return; }
                                    USD_value.Text = "$ " + Math.Round(numValue, 2).ToString().Replace(',', '.');
                                }
                                else if (selectOperBox.Text == "Продажа")
                                {
                                    numValue = Convert.ToDouble(USD_value.Text.Substring(1).Replace('.', ',')) + Convert.ToDouble(quantityBox.Text.Replace('.', ','));
                                    USD_value.Text = "$ " + Math.Round(numValue, 2).ToString().Replace(',', '.');
                                }
                                break;
                            case '€':
                                nameValue = "EUR";
                                if (selectOperBox.Text == "Покупка")
                                {
                                    numValue = Convert.ToDouble(EUR_value.Text.Substring(1).Replace('.', ',')) - Convert.ToDouble(quantityBox.Text.Replace('.', ','));
                                    if (numValue < 0) { MessageBox.Show("Операция не выполнена. Недостаточно валюты в кассе!"); return; }
                                    EUR_value.Text = "€ " + Math.Round(numValue, 2).ToString().Replace(',', '.');
                                }
                                else if (selectOperBox.Text == "Продажа")
                                {
                                    numValue = Convert.ToDouble(EUR_value.Text.Substring(1).Replace('.', ',')) + Convert.ToDouble(quantityBox.Text.Replace('.', ','));
                                    EUR_value.Text = "€ " + Math.Round(numValue, 2).ToString().Replace(',', '.');
                                }
                                break;
                            case '£':
                                nameValue = "GBP";
                                if (selectOperBox.Text == "Покупка")
                                {
                                    numValue = Convert.ToDouble(GBP_value.Text.Substring(1).Replace('.', ',')) - Convert.ToDouble(quantityBox.Text.Replace('.', ','));
                                    if (numValue < 0) { MessageBox.Show("Операция не выполнена. Недостаточно валюты в кассе!"); return; }
                                    GBP_value.Text = "£ " + Math.Round(numValue, 2).ToString().Replace(',', '.');
                                }
                                else if (selectOperBox.Text == "Продажа")
                                {
                                    numValue = Convert.ToDouble(GBP_value.Text.Substring(1).Replace('.', ',')) + Convert.ToDouble(quantityBox.Text.Replace('.', ','));
                                    GBP_value.Text = "£ " + Math.Round(numValue, 2).ToString();
                                }
                                break;
                            case '₣':
                                nameValue = "CHF";
                                if (selectOperBox.Text == "Покупка")
                                {
                                    numValue = Convert.ToDouble(CHF_value.Text.Substring(1).Replace('.', ',')) - Convert.ToDouble(quantityBox.Text.Replace('.', ','));
                                    if (numValue < 0) { MessageBox.Show("Операция не выполнена. Недостаточно валюты в кассе!"); return; }
                                    CHF_value.Text = "₣ " + Math.Round(numValue, 2).ToString().Replace(',', '.');
                                }
                                else if (selectOperBox.Text == "Продажа")
                                {
                                    numValue = Convert.ToDouble(CHF_value.Text.Substring(1).Replace('.', ',')) + Convert.ToDouble(quantityBox.Text.Replace('.', ','));
                                    CHF_value.Text = "₣ " + Math.Round(numValue, 2).ToString().Replace(',', '.');
                                }
                                break;
                            case '¥':
                                nameValue = "JPY";
                                if (selectOperBox.Text == "Покупка")
                                {
                                    numValue = Convert.ToDouble(JPY_value.Text.Substring(1).Replace('.', ',')) - Convert.ToDouble(quantityBox.Text.Replace('.', ','));
                                    if (numValue < 0) { MessageBox.Show("Операция не выполнена. Недостаточно валюты в кассе!"); return; }
                                    JPY_value.Text = "¥ " + Math.Round(numValue, 2).ToString().Replace(',', '.');
                                }
                                else if (selectOperBox.Text == "Продажа")
                                {
                                    numValue = Convert.ToDouble(JPY_value.Text.Substring(1).Replace('.', ',')) + Convert.ToDouble(quantityBox.Text.Replace('.', ','));
                                    JPY_value.Text = "¥ " + Math.Round(numValue, 2).ToString().Replace(',', '.');
                                }
                                break;
                        }
                        string query = "INSERT INTO operations (u_num, surname, name, patronymic, type, value, quantity, summ, date) VALUES (" + u_num + ", '" + FIO[0] + "', '" + FIO[1] + "', '" + FIO[2] + "', '" + selectOperBox.Text + "', '" + selectValueBox_.Text[0] + "', " + quantityBox_.Text + ", " + summ[1].Replace(',', '.') + ", '" + DateTime.Now.ToString("yyyy-MM-dd H:mm:ss") + "');";
                        MySqlCommand command = new MySqlCommand(query, connection);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Обмен успешно совершен!\nСейчас будет произведена печать чека по операции.");
                        switch (selectOperBox.Text)
                        {
                            case "Покупка":
                                currency = valuesBuy[selectOperBox.SelectedIndex].ToString();
                                query = "UPDATE currency_values SET value = " + numValue.ToString().Replace(',', '.') + " WHERE name = '" + nameValue + "'";
                                command = new MySqlCommand(query, connection);
                                command.ExecuteNonQuery();
                                break;
                            case "Продажа":
                                currency = valuesSell[selectOperBox.SelectedIndex].ToString();
                                query = "UPDATE currency_values SET value = " + numValue.ToString().Replace(',', '.') + " WHERE name = '" + nameValue + "'";
                                command = new MySqlCommand(query, connection);
                                command.ExecuteNonQuery();
                                break;
                        }
                        var items = new Dictionary<string, string>
                        {
                            { "_<number>_", u_num.ToString() },
                            { "_<date>_", DateTime.Now.ToString("dd.MM.yyyy") },
                            { "_<oper>_", selectOperBox.Text },
                            { "_<value>_", selectValueBox_.Text },
                            { "_<quantity>_", quantityBox_.Text },
                            { "_<currency>_", currency.Replace(',', '.') },
                            { "_<summ_oper>_", summ[1].Replace(',', '.') },
                            { "_<name_client>_", FIO[0] + " " + FIO[1].ToString()[0] + ". " + FIO[2].ToString()[0] + "." },
                            { "_<name_cashier>_", NameAdmin.Text },
                            { "_<date_long>_", DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss") },
                        };
                        helper.Process(items);
                        selectClientBox.Text = "Выберите клиента";
                        selectClientBox.ForeColor = Color.Silver;
                        selectOperBox.Text = "Выберите операцию";
                        selectOperBox.ForeColor = Color.Silver;
                        selectValueBox.Text = "Выберите валюту";
                        selectValueBox.ForeColor = Color.Silver;
                        summBox.Text = "Сумма сделки: 0 рублей";
                        quantityBox.Text = "Введите количество валюты";
                        quantityBox.ForeColor = Color.Silver;
                        numberBox.Text = "";
                        currencies_exchangePanel.Visible = false;
                        exchangePanel.Visible = true;
                    }
                }
                catch (MySqlException)
                {
                    MessageBox.Show("Произошла ошибка данных! Проверьте введённые данные.");
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                //do nothing
            }                   
        }
        private void search_values_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView4.Rows.Clear();
            dataGridView4.Columns.Clear();
        }

        private void search_operations_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView4.Rows.Clear();
            dataGridView4.Columns.Clear();
        }

        private void SearchBut_Click(object sender, EventArgs e)
        {
            string search_string = searchBox.Text;
            if (search_string == " Введите для поиска..." || search_string == "" || searchBox.Text == "" || searchBox.Text == null)
            {
                MessageBox.Show("Ошибка! Введите строку для поиска.");
                return;
            }
            dataGridView4.Rows.Clear();
            dataGridView4.Columns.Clear();

            //datagrid
            string connStr = "server=localhost;user=root;database=aisdatabd;password=root123;";
            MySqlConnection conn = new MySqlConnection(connStr);

            MySqlCommand command = new MySqlCommand();
            string commandString;
            MySqlDataReader reader;
            if (search_values.Checked == true)
            {
                commandString = "SELECT * FROM currencycourse WHERE (u_num LIKE" + " '%" + search_string + "%') OR (name LIKE" + " '%" + search_string + "%') OR (summsale LIKE" + " '%" + search_string.Replace(',', '.') + "%') OR (summpurchase LIKE" + " '%" + search_string + "%')";
                command.CommandText = commandString;
                command.Connection = conn;
                try
                {
                    command.Connection.Open();
                    reader = command.ExecuteReader();
                    try
                    {
                        this.dataGridView4.Columns.Add("u_num", "u_num");
                        this.dataGridView4.Columns["u_num"].Width = 50;
                        this.dataGridView4.Columns.Add("name", "Name");
                        this.dataGridView4.Columns["name"].Width = 130;
                        this.dataGridView4.Columns.Add("summsale", "SummSale");
                        this.dataGridView4.Columns["summsale"].Width = 226;
                        this.dataGridView4.Columns.Add("summpurchase", "SummPurchase");
                        this.dataGridView4.Columns["summpurchase"].Width = 226;
                        while (reader.Read())
                        {
                            dataGridView4.Rows.Add(reader["u_num"].ToString(), reader["name"].ToString(), reader["summsale"].ToString(), reader["summpurchase"].ToString());
                        }
                        reader.Close();
                    }
                    catch (MySqlException ex)
                    {
                        Console.WriteLine("Error: \r\n{0}", ex.ToString());
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Error: \r\n{0}", ex.ToString());
                }
            }
            else if (search_operations.Checked == true)
            {
                commandString = "SELECT * FROM operations WHERE (u_num LIKE" + " '%" + search_string + "%') OR (surname LIKE" + " '%" + search_string + "%') OR (name LIKE" + " '%" + search_string + "%') OR (patronymic LIKE" + " '%" + search_string + "%') OR (type LIKE" + " '%" + search_string + "%') OR (value LIKE" + " '%" + search_string + "%') OR (quantity LIKE" + " '%" + search_string.Replace(',', '.') + "%') OR (summ LIKE" + " '%" + search_string.Replace(',', '.') + "%') OR (CONVERT(`date` USING utf8) LIKE" + " '%" + search_string + "%');";
                command.CommandText = commandString;
                command.Connection = conn;
                try
                {
                    command.Connection.Open();
                    reader = command.ExecuteReader();
                    try
                    {
                        this.dataGridView4.Columns.Add("u_num", "u_num");
                        this.dataGridView4.Columns["u_num"].Width = 50;
                        this.dataGridView4.Columns.Add("surname", "Surname");
                        this.dataGridView4.Columns["surname"].Width = 90;
                        this.dataGridView4.Columns.Add("name", "Name");
                        this.dataGridView4.Columns["name"].Width = 70;
                        this.dataGridView4.Columns.Add("patronymic", "Patronymic");
                        this.dataGridView4.Columns["patronymic"].Width = 90;
                        this.dataGridView4.Columns.Add("type", "Type");
                        this.dataGridView4.Columns["type"].Width = 60;
                        this.dataGridView4.Columns.Add("quantity", "Quantity");
                        this.dataGridView4.Columns["quantity"].Width = 65;
                        this.dataGridView4.Columns.Add("summ", "Summ");
                        this.dataGridView4.Columns["summ"].Width = 80;
                        this.dataGridView4.Columns.Add("date", "Date");
                        this.dataGridView4.Columns["date"].Width = 127;
                        while (reader.Read())
                        {
                            classes.reversedate reversedate = new classes.reversedate();
                            dataGridView4.Rows.Add(reader["u_num"].ToString(), reader["surname"].ToString(), reader["name"].ToString(), reader["patronymic"].ToString(), reader["type"].ToString(), reader["quantity"].ToString(), reader["summ"].ToString(), reversedate.datetimeReverse(reader["date"].ToString()));
                        }
                        reader.Close();
                    }
                    catch (MySqlException ex)
                    {
                        Console.WriteLine("Error: \r\n{0}", ex.ToString());
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Error: \r\n{0}", ex.ToString());
                }
            }
            else if (search_clients.Checked == true)
            {
                commandString = "SELECT * FROM clients WHERE (u_num LIKE" + " '%" + search_string + "%') OR (surname LIKE" + " '%" + search_string + "%') OR (name LIKE" + " '%" + search_string + "%') OR (patronymic LIKE" + " '%" + search_string + "%') OR (CONVERT(`date_birth` USING utf8) LIKE" + " '%" + search_string + "%') OR (seriesDoc LIKE" + " '%" + search_string + "%') OR (numberDoc LIKE" + " '%" + search_string + "%');";
                command.CommandText = commandString;
                command.Connection = conn;
                try
                {
                    command.Connection.Open();
                    reader = command.ExecuteReader();
                    try
                    {
                        this.dataGridView4.Columns.Add("u_num", "№");
                        this.dataGridView4.Columns["u_num"].Width = 45;
                        this.dataGridView4.Columns.Add("surname", "Фамилия");
                        this.dataGridView4.Columns["surname"].Width = 110;
                        this.dataGridView4.Columns.Add("name", "Имя");
                        this.dataGridView4.Columns["name"].Width = 90;
                        this.dataGridView4.Columns.Add("patronymic", "Отчество");
                        this.dataGridView4.Columns["patronymic"].Width = 110;
                        this.dataGridView4.Columns.Add("date_birth", "Дата рождения");
                        this.dataGridView4.Columns["date_birth"].Width = 89;
                        this.dataGridView4.Columns.Add("seriesDoc", "Серия документа");
                        this.dataGridView4.Columns["seriesDoc"].Width = 94;
                        this.dataGridView4.Columns.Add("numberDoc", "Номер документа");
                        this.dataGridView4.Columns["numberDoc"].Width = 94;
                        while (reader.Read())
                        {
                            classes.reversedate reversedate = new classes.reversedate();
                            dataGridView4.Rows.Add(reader["u_num"].ToString(), reader["surname"].ToString(), reader["name"].ToString(), reader["patronymic"].ToString(), reversedate.dateReverse(reader["date_birth"].ToString()), reader["seriesDoc"].ToString(), reader["numberDoc"].ToString());
                        }
                        reader.Close();
                    }
                    catch (MySqlException ex)
                    {
                        Console.WriteLine("Error: \r\n{0}", ex.ToString());
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Error: \r\n{0}", ex.ToString());
                }
            }
        }

        private void otchetPanel_VisibleChanged(object sender, EventArgs e)
        {
            string connStr = "server=localhost;user=root;database=aisdatabd;password=root123;";
            MySqlConnection conn = new MySqlConnection(connStr);
            MySqlCommand command = new MySqlCommand();
            string commandString;
            MySqlDataReader reader;

            commandString = "SELECT * FROM otchets_quantity WHERE id = 1;";
            command.CommandText = commandString;
            command.Connection = conn;
            try
            {
                command.Connection.Open();
                reader = command.ExecuteReader();
                try
                {                    
                    while (reader.Read())
                    {
                        otchets_quantity.Text = reader["quantity"].ToString();
                    }
                    reader.Close();
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Error: \r\n{0}", ex.ToString());
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: \r\n{0}", ex.ToString());
            }
        }

        private void printOtchetClients_btn_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Произвести печать отчёта - информация о клиентах?", "Печать отчёта", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                
                classes.wordOtchets_print wordOtchets_print = new classes.wordOtchets_print();
                classes.reversedate reversedate = new classes.reversedate();
                string connStr = "server=localhost;user=root;database=aisdatabd;password=root123;";
                MySqlConnection conn = new MySqlConnection(connStr);
                MySqlCommand command = new MySqlCommand();
                string commandString;
                MySqlDataReader reader;
                command.Connection = conn;
                command.Connection.Open();
                commandString = "SELECT COUNT(*) FROM clients;";
                command.CommandText = commandString;
                string[] data = new string[Convert.ToInt32(command.ExecuteScalar())];
                commandString = "SELECT * FROM clients;";
                command.CommandText = commandString;
                
                try
                {                    
                    reader = command.ExecuteReader();
                    try
                    {
                        int i = 0;
                        while (reader.Read())
                        {

                            data[i] = reader["u_num"].ToString() + " " + reader["surname"].ToString() + " " + reader["name"].ToString() + " " + reader["patronymic"].ToString() + " " + reversedate.dateReverse(reader["date_birth"].ToString()) + " " + reader["seriesDoc"].ToString() + " " + reader["numberDoc"].ToString();
                            i++;
                        }
                        reader.Close();
                    }
                    catch (MySqlException ex)
                    {
                        Console.WriteLine("Error: \r\n{0}", ex.ToString());
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Error: \r\n{0}", ex.ToString());
                }
                wordOtchets_print.otchetClients_print(Environment.CurrentDirectory + "\\wordDocs\\otchetClients_print.docx", data, NameAdmin.Text);
                commandString = "UPDATE otchets_quantity SET quantity = " + (Convert.ToInt32(otchets_quantity.Text) + 1).ToString() + " WHERE id = 1";
                command.CommandText = commandString;
                command.ExecuteReader();
                command.Connection.Close();
                otchets_quantity.Text = (Convert.ToInt32(otchets_quantity.Text) + 1).ToString();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do nothing
            }
        }        
        private void printOtchetBuyValues_btn_Click(object sender, EventArgs e)
        {
            otchetPanel.Visible = false;
            mainPanel.Visible = false;
            addclientPanel.Visible = false;
            add_valuesPanel.Visible = false;
            operationsOtchetBuyClient.Visible = true;
            operationsOtchetSellClient.Visible = false;
            searchPanel.Visible = false;
            exchangePanel.Visible = false;
            currencies_exchangePanel.Visible = false;
            clientsPanel.Visible = false;
            bdPanel.Visible = false;
        }

        private void printOtchetSellValues_btn_Click(object sender, EventArgs e)
        {
            otchetPanel.Visible = false;
            mainPanel.Visible = false;
            addclientPanel.Visible = false;
            add_valuesPanel.Visible = false;
            operationsOtchetBuyClient.Visible = false;
            operationsOtchetSellClient.Visible = true;
            searchPanel.Visible = false;
            exchangePanel.Visible = false;
            currencies_exchangePanel.Visible = false;
            clientsPanel.Visible = false;
            bdPanel.Visible = false;
        }

        private void OtchetSellClientprint_btn_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Произвести печать отчёта - операции продаж?", "Печать отчёта", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                var date1 = dateTimePicker_startSell;
                var date2 = dateTimePicker_endSell;
                if (date1 == date2)
                {
                    MessageBox.Show("Ошибка! Даты одинаковы. Измените даты и попробуйте ещё раз");
                    return;
                }
                classes.wordOtchets_print wordOtchets_print = new classes.wordOtchets_print();
                classes.reversedate reversedate = new classes.reversedate();
                string connStr = "server=localhost;user=root;database=aisdatabd;password=root123;";
                MySqlConnection conn = new MySqlConnection(connStr);
                MySqlCommand command = new MySqlCommand();
                string commandString;
                MySqlDataReader reader;
                command.Connection = conn;
                command.Connection.Open();
                commandString = "SELECT COUNT(*) FROM operations WHERE (type = 'Продажа') AND (date BETWEEN '" + reversedate.datetimeReverse(date1.Value.ToString()) + "' AND '" + reversedate.datetimeReverse(date2.Value.ToString()) + "');";
                command.CommandText = commandString;
                string[] data = new string[Convert.ToInt32(command.ExecuteScalar())];
                commandString = "SELECT * FROM operations WHERE (type = 'Продажа') AND (date BETWEEN '" + reversedate.datetimeReverse(date1.Value.ToString()) + "' AND '" + reversedate.datetimeReverse(date2.Value.ToString()) + "');";
                command.CommandText = commandString;

                try
                {
                    reader = command.ExecuteReader();
                    try
                    {
                        int i = 0;
                        while (reader.Read())
                        {
                            data[i] = reader["u_num"].ToString() + " " + reader["surname"].ToString() + " " + reader["name"].ToString() + " " + reader["patronymic"].ToString() + " " + reader["value"].ToString() + " " + reader["quantity"].ToString() + " " + reader["summ"].ToString() + " " + reader["date"].ToString();
                            i++;
                        }
                        reader.Close();
                    }
                    catch (MySqlException ex)
                    {
                        Console.WriteLine("Error: \r\n{0}", ex.ToString());
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Error: \r\n{0}", ex.ToString());
                }
                wordOtchets_print.otchetSellValues_print(Environment.CurrentDirectory + "\\wordDocs\\otchetSellValues_print.docx", data, date1.Value, date2.Value, NameAdmin.Text);
                commandString = "UPDATE otchets_quantity SET quantity = " + (Convert.ToInt32(otchets_quantity.Text) + 1).ToString() + " WHERE id = 1";
                command.CommandText = commandString;
                command.ExecuteReader();
                command.Connection.Close();
                otchets_quantity.Text = (Convert.ToInt32(otchets_quantity.Text) + 1).ToString();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do nothing
            }
        }

        private void OtchetBuyClientprint_btn_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Произвести печать отчёта - операции покупок?", "Печать отчёта", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                var date1 = dateTimePicker_startBuy;
                var date2 = dateTimePicker_endBuy;
                if (date1 == date2)
                {
                    MessageBox.Show("Ошибка! Даты одинаковы. Измените даты и попробуйте ещё раз");
                    return;
                }
                classes.wordOtchets_print wordOtchets_print = new classes.wordOtchets_print();
                classes.reversedate reversedate = new classes.reversedate();
                string connStr = "server=localhost;user=root;database=aisdatabd;password=root123;";
                MySqlConnection conn = new MySqlConnection(connStr);
                MySqlCommand command = new MySqlCommand();
                string commandString;
                MySqlDataReader reader;
                command.Connection = conn;
                command.Connection.Open();
                commandString = "SELECT COUNT(*) FROM operations WHERE (type = 'Покупка') AND (date BETWEEN '" + reversedate.datetimeReverse(date1.Value.ToString()) + "' AND '" + reversedate.datetimeReverse(date2.Value.ToString()) + "');";
                command.CommandText = commandString;
                string[] data = new string[Convert.ToInt32(command.ExecuteScalar())];
                commandString = "SELECT * FROM operations WHERE (type = 'Покупка') AND (date BETWEEN '" + reversedate.datetimeReverse(date1.Value.ToString()) + "' AND '" + reversedate.datetimeReverse(date2.Value.ToString()) + "');";
                command.CommandText = commandString;

                try
                {
                    reader = command.ExecuteReader();
                    try
                    {
                        int i = 0;
                        while (reader.Read())
                        {
                            data[i] = reader["u_num"].ToString() + " " + reader["surname"].ToString() + " " + reader["name"].ToString() + " " + reader["patronymic"].ToString() + " " + reader["value"].ToString() + " " + reader["quantity"].ToString() + " " + reader["summ"].ToString() + " " + reader["date"].ToString();
                            i++;
                        }
                        reader.Close();
                    }
                    catch (MySqlException ex)
                    {
                        Console.WriteLine("Error: \r\n{0}", ex.ToString());
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Error: \r\n{0}", ex.ToString());
                }
                wordOtchets_print.otchetBuyValues_print(Environment.CurrentDirectory + "\\wordDocs\\otchetBuyValues_print.docx", data, date1.Value, date2.Value, NameAdmin.Text);
                commandString = "UPDATE otchets_quantity SET quantity = " + (Convert.ToInt32(otchets_quantity.Text) + 1).ToString() + " WHERE id = 1";
                command.CommandText = commandString;
                command.ExecuteReader();
                command.Connection.Close();
                otchets_quantity.Text = (Convert.ToInt32(otchets_quantity.Text) + 1).ToString();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do nothing
            }
        }

        private void goBackOtchetBtn_Click(object sender, EventArgs e)
        {
            otchetPanel.Visible = true;
            mainPanel.Visible = false;
            addclientPanel.Visible = false;
            add_valuesPanel.Visible = false;
            operationsOtchetBuyClient.Visible = false;
            operationsOtchetSellClient.Visible = false;
            searchPanel.Visible = false;
            exchangePanel.Visible = false;
            currencies_exchangePanel.Visible = false;
            clientsPanel.Visible = false;
            bdPanel.Visible = false;
        }

        private void search_clients_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView4.Rows.Clear();
            dataGridView4.Columns.Clear();
        }
    }
}
