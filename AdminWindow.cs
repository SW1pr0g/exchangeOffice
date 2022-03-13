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

        private void SaledRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            //datagrid
            string connStr = "server=localhost;user=root;database=aisdatabd;password=root123;";
            MySqlConnection conn = new MySqlConnection(connStr);

            MySqlCommand command = new MySqlCommand();
            string commandString = "SELECT * FROM saled;";
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
                this.dataGridView1.Columns.Add("surname", "Surname");
                this.dataGridView1.Columns["surname"].Width = 100;
                this.dataGridView1.Columns.Add("patronymic", "Patronymic");
                this.dataGridView1.Columns["patronymic"].Width = 100;
                this.dataGridView1.Columns.Add("summ", "Summ");
                this.dataGridView1.Columns["summ"].Width = 100;
                this.dataGridView1.Columns.Add("currency", "Currency");
                this.dataGridView1.Columns["currency"].Width = 100;
                this.dataGridView1.Columns.Add("date", "Date");
                this.dataGridView1.Columns["date"].Width = 100;
                while (reader.Read())
                {
                    classes.reversedate reversedate = new classes.reversedate();
                    dataGridView1.Rows.Add(reader["id"].ToString(), reader["name"].ToString(), reader["surname"].ToString(), reader["patronymic"].ToString(), reader["summ"].ToString(), reader["currency"].ToString(), reversedate.datetimeReverse(reader["date"].ToString()));
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

        private void PurchasedRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            //datagrid
            string connStr = "server=localhost;user=root;database=aisdatabd;password=root123;";
            MySqlConnection conn = new MySqlConnection(connStr);

            MySqlCommand command = new MySqlCommand();
            string commandString = "SELECT * FROM purchased;";
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
                this.dataGridView1.Columns.Add("surname", "Surname");
                this.dataGridView1.Columns["surname"].Width = 100;
                this.dataGridView1.Columns.Add("patronymic", "Patronymic");
                this.dataGridView1.Columns["patronymic"].Width = 100;
                this.dataGridView1.Columns.Add("summ", "Summ");
                this.dataGridView1.Columns["summ"].Width = 100;
                this.dataGridView1.Columns.Add("currency", "Currency");
                this.dataGridView1.Columns["currency"].Width = 100;
                this.dataGridView1.Columns.Add("date", "Date");
                this.dataGridView1.Columns["date"].Width = 100;
                while (reader.Read())
                {
                    classes.reversedate reversedate = new classes.reversedate();
                    dataGridView1.Rows.Add(reader["id"].ToString(), reader["name"].ToString(), reader["surname"].ToString(), reader["patronymic"].ToString(), reader["summ"].ToString(), reader["currency"].ToString(), reversedate.datetimeReverse(reader["date"].ToString()));
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
                this.dataGridView1.Columns.Add("id", "ID");
                this.dataGridView1.Columns["id"].Width = 20;
                this.dataGridView1.Columns.Add("name", "Name");
                this.dataGridView1.Columns["name"].Width = 50;
                this.dataGridView1.Columns.Add("surname", "Surname");
                this.dataGridView1.Columns["surname"].Width = 100;
                this.dataGridView1.Columns.Add("patronymic", "Patronymic");
                this.dataGridView1.Columns["patronymic"].Width = 100;
                this.dataGridView1.Columns.Add("date_birth", "Date_birth");
                this.dataGridView1.Columns["date_birth"].Width = 100;
                this.dataGridView1.Columns.Add("seriesDoc", "SeriesDoc");
                this.dataGridView1.Columns["seriesDoc"].Width = 100;
                this.dataGridView1.Columns.Add("numberDoc", "NumberDoc");
                this.dataGridView1.Columns["numberDoc"].Width = 100;
                while (reader.Read())
                {
                    classes.reversedate reversedate = new classes.reversedate();
                    dataGridView1.Rows.Add(reader["id"].ToString(), reader["name"].ToString(), reader["surname"].ToString(), reader["patronymic"].ToString(), reversedate.dateReverse(reader["date_birth"].ToString()), reader["seriesDoc"].ToString(), reader["numberDoc"].ToString());
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
                this.dataGridView1.Columns.Add("id", "ID");
                this.dataGridView1.Columns["id"].Width = 20;
                this.dataGridView1.Columns.Add("login", "Login");
                this.dataGridView1.Columns["login"].Width = 50;
                this.dataGridView1.Columns.Add("password", "Password");
                this.dataGridView1.Columns["password"].Width = 100;
                this.dataGridView1.Columns.Add("name", "Name");
                this.dataGridView1.Columns["name"].Width = 100;
                this.dataGridView1.Columns.Add("type", "Type");
                this.dataGridView1.Columns["type"].Width = 100;
                while (reader.Read())
                {
                    dataGridView1.Rows.Add(reader["id"].ToString(), reader["login"].ToString(), reader["password"].ToString(), reader["name"].ToString(), reader["type"].ToString());
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
                    int id = dataGridView1.Rows.Count;
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
                            break;
                        }
                        try
                        {
                            for (int j = 0; j <= (dataGridView1.Rows.Count - 3); j++)
                            {
                                if (Convert.ToInt32(dataGridView1[0, 0].Value.ToString()) != 1 || Convert.ToInt32(dataGridView1[0, j].Value.ToString()) != (Convert.ToInt32(dataGridView1[0, j + 1].Value.ToString()) - 1))
                                {
                                    enderr = true;
                                    MessageBox.Show("ID не инкрементируется с каждым следующим полем, либо начинается не с 1. Проверьте поля id.");
                                    break;
                                }
                            }
                            if (enderr == true)
                            {
                                break;
                            }
                            id = Convert.ToInt32(dataGridView1[0, i].Value.ToString());
                            name = dataGridView1[1, i].Value.ToString();
                            summsale = dataGridView1[2, i].Value.ToString();
                            summpurchase = dataGridView1[3, i].Value.ToString();
                            string query = "UPDATE currencycourse SET name = '" + name + "', summsale = " + summsale.Replace(',', '.') + ", summpurchase = " + summpurchase.Replace(',', '.') + " WHERE id = " + id;
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
                else if (SaledRadioBtn.Checked == true)
                {
                    bool enderr = false;
                    int id = 0;
                    string name = "", surname = "", patronymic = "", currency = "", date = "", summ = "", query = "";                    
                    for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                    {
                        MySqlCommand command = new MySqlCommand(query, connection);                                                                      
                        try
                        {
                            id = Convert.ToInt32(dataGridView1[0, i].Value.ToString());
                            name = dataGridView1[1, i].Value.ToString();
                            surname = dataGridView1[2, i].Value.ToString();
                            patronymic = dataGridView1[3, i].Value.ToString();
                            summ = dataGridView1[4, i].Value.ToString();
                            currency = dataGridView1[5, i].Value.ToString();
                            date = dataGridView1[6, i].Value.ToString();
                            for (int j = 0; j <= (dataGridView1.Rows.Count - 2); j++)
                            {
                                try 
                                { 
                                    if (Convert.ToInt32(dataGridView1[0, 0].Value.ToString()) != 1 || Convert.ToInt32(dataGridView1[0, j].Value.ToString()) != (Convert.ToInt32(dataGridView1[0, j + 1].Value.ToString()) - 1))
                                    {
                                        enderr = true;
                                        MessageBox.Show("ID не инкрементируется с каждым следующим полем, либо начинается не с 1. Проверьте поля id.");
                                        break;
                                    }
                                }
                                catch (NullReferenceException)
                                {
                                    //
                                }
                            }
                            if (enderr == true)
                            {
                                break;
                            }
                            query = "UPDATE saled SET name = '" + name + "', surname = '" + surname + "', patronymic = '" + patronymic + "', summ = " + summ.Replace(',', '.') + ", date = '" + date + "' WHERE id = " + id;
                            command = new MySqlCommand(query, connection);
                            var tr = command.ExecuteNonQuery();
                            if (tr == 0)
                            {    
                                query = "INSERT INTO saled (id, name, surname, patronymic, summ, currency, date) VALUES (" + id + ", '" + name + "', '" + surname + "', '" + patronymic + "', " + summ.Replace(',', '.') + ", '" + currency + "', '" + date + "')";
                                command = new MySqlCommand(query, connection);
                                command.ExecuteNonQuery();    
                            }
                                                      
                        }
                        catch (MySqlException)
                        {
                            if (currency.Length > 1)
                            {
                                enderr = true;
                                MessageBox.Show("Поля currency не может содержать больше 1 символа. Проверьте поля currency.");
                                break;
                            }
                            else
                            {
                                enderr = true;
                                MessageBox.Show("Возникла непредвиденная ошибка данных. Проверьте на корректность ввода только что введённые значения.");
                                break;
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
                else if (PurchasedRadioBtn.Checked == true)
                {
                    bool enderr = false;
                    int id = 0;
                    string name = "", surname = "", patronymic = "", currency = "", date = "", summ = "", query = "";
                    for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                    {
                        MySqlCommand command = new MySqlCommand(query, connection);                        
                        try
                        {
                            id = Convert.ToInt32(dataGridView1[0, i].Value.ToString());
                            name = dataGridView1[1, i].Value.ToString();
                            surname = dataGridView1[2, i].Value.ToString();
                            patronymic = dataGridView1[3, i].Value.ToString();
                            summ = dataGridView1[4, i].Value.ToString();
                            currency = dataGridView1[5, i].Value.ToString();
                            date = dataGridView1[6, i].Value.ToString();
                            for (int j = 0; j <= (dataGridView1.Rows.Count - 2); j++)
                            {
                                try
                                {
                                    if (Convert.ToInt32(dataGridView1[0, 0].Value.ToString()) != 1 || Convert.ToInt32(dataGridView1[0, j].Value.ToString()) != (Convert.ToInt32(dataGridView1[0, j + 1].Value.ToString()) - 1))
                                    {
                                        enderr = true;
                                        MessageBox.Show("ID не инкрементируется с каждым следующим полем, либо начинается не с 1. Проверьте поля id.");
                                        break;
                                    }
                                }
                                catch (NullReferenceException)
                                {
                                    //
                                }
                            }
                            if (enderr == true)
                            {
                                break;
                            }
                            query = "UPDATE purchased SET name = '" + name + "', surname = '" + surname + "', patronymic = '" + patronymic + "', summ = " + summ.Replace(',', '.') + ", date = '" + date + "' WHERE id = " + id;
                            command = new MySqlCommand(query, connection);
                            var tr = command.ExecuteNonQuery();
                            if (tr == 0)
                            {
                                query = "INSERT INTO purchased (id, name, surname, patronymic, summ, currency, date) VALUES (" + id + ", '" + name + "', '" + surname + "', '" + patronymic + "', " + summ.Replace(',', '.') + ", '" + currency + "', '" + date + "')";
                                command = new MySqlCommand(query, connection);
                                command.ExecuteNonQuery();
                            }

                        }
                        catch (MySqlException)
                        {
                            if (currency.Length > 1)
                            {
                                enderr = true;
                                MessageBox.Show("Поля currency не может содержать больше 1 символа. Проверьте поля currency.");
                                break;
                            }
                            else
                            {
                                enderr = true;
                                MessageBox.Show("Возникла непредвиденная ошибка данных. Проверьте на корректность ввода только что введённые значения.");
                                break;
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
                else if (ClientsRadioBtn.Checked == true)
                {
                    bool enderr = false;
                    int id = 0, seriesDoc = 0, numberDoc = 0;
                    string name = "", surname = "", patronymic = "", date_birth = "", query = "";
                    for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                    {
                        MySqlCommand command = new MySqlCommand(query, connection);                                              
                        try
                        {
                            id = Convert.ToInt32(dataGridView1[0, i].Value.ToString());
                            name = dataGridView1[1, i].Value.ToString();
                            surname = dataGridView1[2, i].Value.ToString();
                            patronymic = dataGridView1[3, i].Value.ToString();
                            date_birth = dataGridView1[4, i].Value.ToString();
                            seriesDoc = Convert.ToInt32(dataGridView1[5, i].Value.ToString());
                            numberDoc = Convert.ToInt32(dataGridView1[6, i].Value.ToString());
                            for (int j = 0; j <= (dataGridView1.Rows.Count - 2); j++)
                            {
                                try
                                {
                                    if (Convert.ToInt32(dataGridView1[0, 0].Value.ToString()) != 1 || Convert.ToInt32(dataGridView1[0, j].Value.ToString()) != (Convert.ToInt32(dataGridView1[0, j + 1].Value.ToString()) - 1))
                                    {
                                        enderr = true;
                                        MessageBox.Show("ID не инкрементируется с каждым следующим полем, либо начинается не с 1. Проверьте поля id.");
                                        break;
                                    }
                                }
                                catch (NullReferenceException)
                                {
                                    //
                                }
                            }
                            if (enderr == true)
                            {
                                break;
                            }
                            if (seriesDoc > 9999 || seriesDoc < 1000 || numberDoc > 999999 || numberDoc < 100000)
                            {
                                enderr = true;
                                MessageBox.Show("Серия паспорта состоит из 4 цифр, а номер паспорта состоит из 6 цифр. Проверьте поля seriesDoc и numberDoc.");
                                break;
                            }
                            query = "UPDATE clients SET name = '" + name + "', surname = '" + surname + "', patronymic = '" + patronymic + "', date_birth = '" + date_birth + "', seriesDoc = " + seriesDoc + ", numberDoc = " + numberDoc + " WHERE id = " + id;
                            command = new MySqlCommand(query, connection);
                            var tr = command.ExecuteNonQuery();
                            if (tr == 0)
                            {
                                query = "INSERT INTO clients (id, name, surname, patronymic, date_birth, seriesDoc, numberDoc) VALUES (" + id + ", '" + name + "', '" + surname + "', '" + patronymic + "', '" + date_birth + "', " + seriesDoc + ", " + numberDoc + ")";
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
                    int id = 0;
                    string name = "", login = "", password = "", query = "", type = "";
                    for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                    {
                        MySqlCommand command = new MySqlCommand(query, connection);
                        try
                        {
                            id = Convert.ToInt32(dataGridView1[0, i].Value.ToString());
                            login = dataGridView1[1, i].Value.ToString();
                            password = dataGridView1[2, i].Value.ToString();
                            name = dataGridView1[3, i].Value.ToString();
                            type = dataGridView1[4, i].Value.ToString();
                            for (int j = 0; j <= (dataGridView1.Rows.Count - 2); j++)
                            {
                                try
                                {
                                    if (Convert.ToInt32(dataGridView1[0, 0].Value.ToString()) != 1 || Convert.ToInt32(dataGridView1[0, j].Value.ToString()) != (Convert.ToInt32(dataGridView1[0, j + 1].Value.ToString()) - 1))
                                    {
                                        enderr = true;
                                        MessageBox.Show("ID не инкрементируется с каждым следующим полем, либо начинается не с 1. Проверьте поля id.");
                                        break;
                                    }
                                }
                                catch (NullReferenceException)
                                {
                                    //
                                }
                            }
                            if (enderr == true)
                            {
                                break;
                            }                                                                                                             
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
                            query = "UPDATE users SET login = '" + login + "', password = '" + password + "', name = '" + name + "', type = '" + type + "' WHERE id = " + id;
                            command = new MySqlCommand(query, connection);
                            var tr = command.ExecuteNonQuery();
                            if (tr == 0)
                            {
                                query = "INSERT INTO users (id, login, password, name) VALUES (" + id + ", '" + login + "', '" + password + "', '" + name + "', '" + type + "')";
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
                    if (SaledRadioBtn.Checked == true)
                    {
                        table = "saled";
                    }
                    else if (PurchasedRadioBtn.Checked == true)
                    {
                        table = "purchased";
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
                    query = "DELETE FROM " + table + " WHERE id = " + Convert.ToInt32(dataGridView1[0, e.Row.Index].Value.ToString());
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
            for (int j = 0; j <= (dataGridView1.Rows.Count - 2); j++)
            {
                try
                {
                    if (Convert.ToInt32(dataGridView1[0, 0].Value.ToString()) != 1 || Convert.ToInt32(dataGridView1[0, j].Value.ToString()) != (Convert.ToInt32(dataGridView1[0, j + 1].Value.ToString()) - 1))
                    {
                        MessageBox.Show("ID не инкрементируется с каждым следующим полем, либо начинается не с 1. Проверьте поля id.");
                        break;
                    }
                }
                catch (NullReferenceException)
                {
                    //
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
