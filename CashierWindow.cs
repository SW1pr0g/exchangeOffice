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
using Word = Microsoft.Office.Interop.Word;

namespace AIS_exchangeOffice
{
    public partial class CashierWindowMain : Form
    {
        public bool searchEdit = false;
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]        
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);
        public CashierWindowMain()
        {
            InitializeComponent();

            //визуальное сопровождение панели навигации
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            pnlNav.Height = MainBtn.Height;
            pnlNav.Top = MainBtn.Top;
            pnlNav.Left = MainBtn.Left;
            MainBtn.BackColor = Color.FromArgb(46, 51, 73);      
            
        }

        private void MainBtn_Click(object sender, EventArgs e)
        {
            //отображение главного меню
            pnlNav.Height = MainBtn.Height;
            pnlNav.Top = MainBtn.Top;
            pnlNav.Left = MainBtn.Left;
            MainBtn.BackColor = Color.FromArgb(46, 51, 73);
            mainPanel.Visible = true;
            clientsPanel.Visible = false;
            exchangePanel.Visible = false;
            searchPanel.Visible = false;
            addclientPanel.Visible = false;
            currencies_exchangePanel.Visible = false;
        }
        private void MainBtn_Leave(object sender, EventArgs e)
        {
            //визуальное сопровождение выбранного главного меню в
            //панели навигации
            MainBtn.BackColor = Color.FromArgb(11, 100, 103);           
        }
        private void ClientsBtn_Click(object sender, EventArgs e)
        {
            //отображение панели клиенты
            pnlNav.Height = ClientsBtn.Height;
            pnlNav.Top = ClientsBtn.Top;
            pnlNav.Left = ClientsBtn.Left;
            ClientsBtn.BackColor = Color.FromArgb(46, 51, 73);
            mainPanel.Visible = false;
            clientsPanel.Visible = true;
            exchangePanel.Visible = false;
            searchPanel.Visible = false;
            addclientPanel.Visible = false;
            currencies_exchangePanel.Visible = false;
        }
        private void ClientsBtn_Leave(object sender, EventArgs e)
        {
            //визуальное сопровождение выбранной панели клиенты в
            //панели навигации
            ClientsBtn.BackColor = Color.FromArgb(11, 100, 103);          
        }
        private void ExchangeBtn_Click(object sender, EventArgs e)
        {
            //отображение панели обмен валюты
            pnlNav.Height = ExchangeBtn.Height;
            pnlNav.Top = ExchangeBtn.Top;
            pnlNav.Left = ExchangeBtn.Left;
            ExchangeBtn.BackColor = Color.FromArgb(46, 51, 73);
            mainPanel.Visible = false;
            clientsPanel.Visible = false;
            exchangePanel.Visible = true;
            searchPanel.Visible = false;
            addclientPanel.Visible = false;
            currencies_exchangePanel.Visible = false;
        }
        private void ExchangeBtn_Leave(object sender, EventArgs e)
        {
            //визуальное сопровождение выбранной панели обмен валюты в
            //панели навигации
            ExchangeBtn.BackColor = Color.FromArgb(11, 100, 103);
        }

        private void exit_Click(object sender, EventArgs e)
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

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            //отображение панели поиск
            pnlNav.Height = SearchBtn.Height;
            pnlNav.Top = SearchBtn.Top;
            pnlNav.Left = SearchBtn.Left;
            SearchBtn.BackColor = Color.FromArgb(46, 51, 73);
            mainPanel.Visible = false;
            clientsPanel.Visible = false;
            exchangePanel.Visible = false;
            searchPanel.Visible = true;
            addclientPanel.Visible = false;
            currencies_exchangePanel.Visible = false;
        }

        private void SearchBtn_Leave(object sender, EventArgs e)
        {
            //визуальное сопровождение выбранной панели поиск в
            //панели навигации
            SearchBtn.BackColor = Color.FromArgb(11, 100, 103);
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
                //ничего не делать
            }
        }

        private void CashierWindowMain_Load(object sender, EventArgs e)
        {
            //при загрузке формы отображаем имя текущего кассира
            CashierName.Text = AuthForm.nameUser;
        }        
        private void mainPanel_VisibleChanged(object sender, EventArgs e)
        {
            string connStr = "server=localhost;user=root;database=aisdatabd;password=root123;";
            MySqlConnection conn = new MySqlConnection(connStr);

            //выборка данных о валютах для отображения на форме
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

        //визуальное сопровождение поля поиска
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

        private void SearchBut_Click(object sender, EventArgs e)
        {
            string search_string = searchBox.Text;

            //проверяем, не пусто ли в поле для поиска
            if (search_string == " Введите для поиска..." || search_string == "")
            {
                MessageBox.Show("Ошибка! Введите строку для поиска.");
                return;
            }

            //подчищаем данные после прошлого поиска
            dataGridView3.Rows.Clear();
            dataGridView3.Columns.Clear();
            
            //datagrid
            string connStr = "server=localhost;user=root;database=aisdatabd;password=root123;";
            MySqlConnection conn = new MySqlConnection(connStr);

            MySqlCommand command = new MySqlCommand();
            string commandString;
            MySqlDataReader reader;
            if (search_values.Checked == true)
            {
                //SQL-запрос по поиску данных по таблицам
                commandString = "SELECT * FROM currencycourse WHERE (u_num LIKE" + " '%" + search_string + "%') OR (name LIKE" + " '%" + search_string + "%') OR (summsale LIKE" + " '%" + search_string.Replace(',', '.') + "%') OR (summpurchase LIKE" + " '%" + search_string + "%')";
                command.CommandText = commandString;
                command.Connection = conn;
                try
                {
                    command.Connection.Open();
                    reader = command.ExecuteReader();
                    try
                    {
                        this.dataGridView3.Columns.Add("u_num", "u_num");
                        this.dataGridView3.Columns["u_num"].Width = 50;
                        this.dataGridView3.Columns.Add("name", "Name");
                        this.dataGridView3.Columns["name"].Width = 130;
                        this.dataGridView3.Columns.Add("summsale", "SummSale");
                        this.dataGridView3.Columns["summsale"].Width = 226;
                        this.dataGridView3.Columns.Add("summpurchase", "SummPurchase");
                        this.dataGridView3.Columns["summpurchase"].Width = 226;
                        //вывод результатов поиска
                        while (reader.Read())
                        {
                            dataGridView3.Rows.Add(reader["u_num"].ToString(), reader["name"].ToString(), reader["summsale"].ToString(), reader["summpurchase"].ToString());
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
                        this.dataGridView3.Columns.Add("u_num", "u_num");
                        this.dataGridView3.Columns["u_num"].Width = 50;
                        this.dataGridView3.Columns.Add("surname", "Surname");
                        this.dataGridView3.Columns["surname"].Width = 90;
                        this.dataGridView3.Columns.Add("name", "Name");
                        this.dataGridView3.Columns["name"].Width = 70;
                        this.dataGridView3.Columns.Add("patronymic", "Patronymic");
                        this.dataGridView3.Columns["patronymic"].Width = 90;
                        this.dataGridView3.Columns.Add("type", "Type");
                        this.dataGridView3.Columns["type"].Width = 60;
                        this.dataGridView3.Columns.Add("quantity", "Quantity");
                        this.dataGridView3.Columns["quantity"].Width = 65;
                        this.dataGridView3.Columns.Add("summ", "Summ");
                        this.dataGridView3.Columns["summ"].Width = 80;
                        this.dataGridView3.Columns.Add("date", "Date");
                        this.dataGridView3.Columns["date"].Width = 127;
                        while (reader.Read())
                        {
                            classes.reversedate reversedate = new classes.reversedate();
                            dataGridView3.Rows.Add(reader["u_num"].ToString(), reader["surname"].ToString(), reader["name"].ToString(), reader["patronymic"].ToString(), reader["type"].ToString(), reader["quantity"].ToString(), reader["summ"].ToString(), reversedate.datetimeReverse(reader["date"].ToString()));
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
                        this.dataGridView3.Columns.Add("u_num", "№");
                        this.dataGridView3.Columns["u_num"].Width = 45;
                        this.dataGridView3.Columns.Add("surname", "Фамилия");
                        this.dataGridView3.Columns["surname"].Width = 110;
                        this.dataGridView3.Columns.Add("name", "Имя");
                        this.dataGridView3.Columns["name"].Width = 90;
                        this.dataGridView3.Columns.Add("patronymic", "Отчество");
                        this.dataGridView3.Columns["patronymic"].Width = 110;
                        this.dataGridView3.Columns.Add("date_birth", "Дата рождения");
                        this.dataGridView3.Columns["date_birth"].Width = 89;
                        this.dataGridView3.Columns.Add("seriesDoc", "Серия документа");
                        this.dataGridView3.Columns["seriesDoc"].Width = 94;
                        this.dataGridView3.Columns.Add("numberDoc", "Номер документа");
                        this.dataGridView3.Columns["numberDoc"].Width = 94;
                        while (reader.Read())
                        {
                            classes.reversedate reversedate = new classes.reversedate();
                            dataGridView3.Rows.Add(reader["u_num"].ToString(), reader["surname"].ToString(), reader["name"].ToString(), reader["patronymic"].ToString(), reversedate.dateReverse(reader["date_birth"].ToString()), reader["seriesDoc"].ToString(), reader["numberDoc"].ToString());
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

        
        private void clientsPanel_VisibleChanged(object sender, EventArgs e)
        {            
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            //datagrid
            string connStr = "server=localhost;user=root;database=aisdatabd;password=root123;";
            MySqlConnection conn = new MySqlConnection(connStr);

            //отображаем таблицу с клиентами
            MySqlCommand command = new MySqlCommand();
            string commandString = "SELECT * FROM clients;";
            command.CommandText = commandString;
            command.Connection = conn;
            MySqlDataReader reader;
            try
            {
                command.Connection.Open();
                reader = command.ExecuteReader();
                this.dataGridView1.Columns.Add("u_num", "№");
                this.dataGridView1.Columns["u_num"].Width = 45;
                this.dataGridView1.Columns.Add("surname", "Фамилия");
                this.dataGridView1.Columns["surname"].Width = 110;
                this.dataGridView1.Columns.Add("name", "Имя");
                this.dataGridView1.Columns["name"].Width = 90;               
                this.dataGridView1.Columns.Add("patronymic", "Отчество");
                this.dataGridView1.Columns["patronymic"].Width = 110;
                this.dataGridView1.Columns.Add("date_birth", "Дата рождения");
                this.dataGridView1.Columns["date_birth"].Width = 90;
                this.dataGridView1.Columns.Add("seriesDoc", "Серия документа");
                this.dataGridView1.Columns["seriesDoc"].Width = 85;
                this.dataGridView1.Columns.Add("numberDoc", "Номер документа");
                this.dataGridView1.Columns["numberDoc"].Width = 85;
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

            //отображаем количество клиентов
            clientsNumT.Text = dataGridView1.RowCount.ToString();

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
                //ничего не делать
            }
        }
        
        
        //отображение панели добавление клиентов
       private void AddClientsBtn_Click(object sender, EventArgs e)
        {
            mainPanel.Visible = false;
            clientsPanel.Visible = false;
            exchangePanel.Visible = false;
            searchPanel.Visible = false;
            addclientPanel.Visible = true;
            currencies_exchangePanel.Visible = false;
        }

        private void exitButton_addclient_Click(object sender, EventArgs e)
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
        // иницилизируем кнопку которая поможет
        //возвращаться на предыдущую панель
        private void GoBackClientsPanel_Click(object sender, EventArgs e)
        {
            mainPanel.Visible = false;
            clientsPanel.Visible = true;
            exchangePanel.Visible = false;
            searchPanel.Visible = false;
            addclientPanel.Visible = false;
            currencies_exchangePanel.Visible = false;
        }

        //делаем красивый ввод-выход в поля добавления клиента
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
        //-----------------------------------------------------------------------
        private void AddClientBtn_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Вы уверены что хотите добавить нового клиента?", "Добавление нового клиента", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    //проверка заполненности полей и корректности ввода данных
                    if (nameBox.Text == "Введите имя" || surnameBox.Text == "Введите фамилию" || patronymicBox.Text == "Введите отчество" || seriesBox.Text == "Введите серию документа" || numberBox.Text == "Введите номер документа")
                    {
                        MessageBox.Show("Одно или несколько полей не заполнены!");
                    }
                    else if (seriesBox.Text.Length != 4 || numberBox.Text.Length != 6)
                    {
                        MessageBox.Show("Серия имеет 4 цифры, а номер 6! Проверьте введённые значения и повторите попытку.");
                    }
                    //--------------------------------------------------------------
                    else
                    {
                        string connectionString = "server = localhost; user = root; database = aisdatabd; password = root123;";
                        MySqlConnection connection = new MySqlConnection(connectionString);
                        connection.Open();
                        classes.reversedate getDate = new classes.reversedate();
                        Random rnd = new Random();

                        //производим добавление в MySQL - БД
                        string query = "INSERT INTO clients (u_num, surname, name, patronymic, date_birth, seriesDoc, numberDoc) VALUES (" + rnd.Next(100000, 999999) +  ", '" + surnameBox.Text + "', '" + nameBox.Text + "', '" + patronymicBox.Text + "', '" + getDate.dateReverse(dateTimePicker1.Value.ToString().Substring(0, 10)) + "', " + seriesBox.Text + ", " + numberBox.Text + ")";
                        MySqlCommand command = new MySqlCommand(query, connection);
                        command.ExecuteNonQuery();

                        //отображение результатов работы пользователю и чистка полей добавления
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
                        mainPanel.Visible = false;
                        clientsPanel.Visible = true;
                        exchangePanel.Visible = false;
                        searchPanel.Visible = false;
                        addclientPanel.Visible = false;
                        currencies_exchangePanel.Visible = false;
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

        //запрет ввода недопустимых значений
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

        private void seriesBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8){}
            else
            {
                if (Char.IsDigit(e.KeyChar)) return;
                else
                    e.Handled = true;
            }
        }

        private void numberBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8){}
            else
            {
                if (Char.IsDigit(e.KeyChar)) return;
                else
                    e.Handled = true;
            }            
        }
        //-------------------------------------------------------------------------------------
        private void goBackExchangeBtn_Click(object sender, EventArgs e)
        {
            selectClientBox.Items.Clear();
            nameBox.Text = "Введите имя";
            surnameBox.Text = "Введите фамилию";
            patronymicBox.Text = "Введите отчество";
            dateTimePicker1.Text = "01.01.2022";
            seriesBox.Text = "Введите серию документа";
            numberBox.Text = "Введите номер документа";
            mainPanel.Visible = false;
            clientsPanel.Visible = false;
            exchangePanel.Visible = true;
            searchPanel.Visible = false;
            addclientPanel.Visible = false;
            currencies_exchangePanel.Visible = false;
        }
        //отображение панели покупки валюты
        private void buy_valuesBtn_Click(object sender, EventArgs e)
        {
            mainPanel.Visible = false;
            clientsPanel.Visible = false;
            exchangePanel.Visible = false;
            searchPanel.Visible = false;
            addclientPanel.Visible = false;
            currencies_exchangePanel.Visible = true;
        }

        //производим вывод бд в панель обмена валют
        private void exchangePanel_VisibleChanged(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            dataGridView2.Columns.Clear();

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
                this.dataGridView2.Columns.Add("u_num", "Уникальный номер");
                this.dataGridView2.Columns["u_num"].Width = 75;
                this.dataGridView2.Columns.Add("surname", "Фамилия");
                this.dataGridView2.Columns["surname"].Width = 66;
                this.dataGridView2.Columns.Add("name", "Имя");
                this.dataGridView2.Columns["name"].Width = 60;
                this.dataGridView2.Columns.Add("patronymic", "Отчество");
                this.dataGridView2.Columns["patronymic"].Width = 75;
                this.dataGridView2.Columns.Add("type", "Тип операции");
                this.dataGridView2.Columns["type"].Width = 65;
                this.dataGridView2.Columns.Add("value", "Валюта");
                this.dataGridView2.Columns["value"].Width = 55;
                this.dataGridView2.Columns.Add("quantity", "Количество валюты");
                this.dataGridView2.Columns["quantity"].Width = 69;
                this.dataGridView2.Columns.Add("summ", "Сумма операции");
                this.dataGridView2.Columns["summ"].Width = 60;
                this.dataGridView2.Columns.Add("date", "Дата и время");
                this.dataGridView2.Columns["date"].Width = 107;
                while (reader.Read())
                {
                    classes.reversedate reversedate = new classes.reversedate();
                    dataGridView2.Rows.Add(reader["u_num"].ToString(), reader["surname"].ToString(), reader["name"].ToString(), reader["patronymic"].ToString(), reader["type"].ToString(), reader["value"].ToString(), reader["quantity"].ToString().Replace(',', '.'), reader["summ"].ToString().Replace(',', '.'), reversedate.datetimeReverse(reader["date"].ToString()));
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
            clientsNumT.Text = dataGridView1.RowCount.ToString();            
        }

        private void selectClientBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar)) { e.Handled = true; } else { e.Handled = true; }  
        }

        //добавляем выбор всех доступных клиентов в ComboBox
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

        private void selectClientBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectClientBox.ForeColor = Color.FromArgb(11, 100, 103); 
        }

        private void selectOperBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selectOperBox.SelectedIndex == 0)
            {
                quantityBox.ForeColor = Color.Silver;
                panel13.Size = new Size(430, 76);
                quantityBox.Size = new Size(413, 62);
                quantityBox.Location = new Point(9, 6);
                panel12.Location = new Point(3, 375);
                exchangedBtn.Location = new Point(112, 437);
                panel11.Size = new Size(437, 491);
                quantityBox.Text = "Введите количество покупаемой валюты";
            }
            else if (selectOperBox.SelectedIndex == 1)
            {
                quantityBox.ForeColor = Color.Silver;
                panel13.Size = new Size(430, 76);
                quantityBox.Size = new Size(413, 62);
                quantityBox.Location = new Point(9, 6);
                panel12.Location = new Point(3, 375);
                exchangedBtn.Location = new Point(112, 437);
                panel11.Size = new Size(437, 491);
                quantityBox.Text = "Введите количество продаваемой валюты";
            }
            else
            {
                quantityBox.ForeColor = Color.Silver;
                panel13.Size = new Size(430, 54);
                quantityBox.Size = new Size(413, 30);
                quantityBox.Location = new Point(8, 11);
                panel12.Location = new Point(3, 356);
                exchangedBtn.Location = new Point(112, 425);
                panel11.Size = new Size(437, 479);
                quantityBox.Text = "Введите количество валюты";
            }

            selectOperBox.ForeColor = Color.FromArgb(11, 100, 103);
            if (selectOperBox.SelectedIndex == 0)
            {
                selectValueBox.Text = "Выберите покупаемую валюту";
                selectValueBox.ForeColor = Color.Silver;
            }
            else if (selectOperBox.SelectedIndex == 1)
            {
                selectValueBox.Text = "Выберите продаваемую валюту";
                selectValueBox.ForeColor = Color.Silver;
            }                        
        }
        //красивый ввод-вывод
        private void selectSaledValueBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectValueBox.ForeColor = Color.FromArgb(11, 100, 103);
        }       
        private void quantityBox_Enter(object sender, EventArgs e)
        {
            if (selectOperBox.SelectedIndex == -1 || selectValueBox.SelectedIndex == -1)
            {
                MessageBox.Show("Операция или валюта не выбраны!");
                this.ActiveControl = null;
            }
                           
            if (quantityBox.Text == "Введите количество покупаемой валюты" || quantityBox.Text == "Введите количество продаваемой валюты")
            {
                quantityBox.ForeColor = Color.FromArgb(11, 100, 103);
                panel13.Size = new Size(430, 54);
                quantityBox.Size = new Size(413, 30);
                quantityBox.Location = new Point(8, 11);
                panel12.Location = new Point(3, 356);
                exchangedBtn.Location = new Point(112, 425);
                panel11.Size = new Size(437, 479);
                quantityBox.Text = "";
            }
            
            if (quantityBox.Text == "Введите сумму покупаемой валюты" || quantityBox.Text == "Введите сумму продаваемой валюты")
            {
                quantityBox.ForeColor = Color.FromArgb(11, 100, 103);
                panel13.Size = new Size(430, 54);
                quantityBox.Size = new Size(413, 30);
                quantityBox.Location = new Point(8, 11);
                panel12.Location = new Point(3, 356);
                exchangedBtn.Location = new Point(112, 425);
                panel11.Size = new Size(437, 479);
                quantityBox.Text = "";
            }
        }

        private void quantityBox_Leave(object sender, EventArgs e)
        {            
            if (quantityBox.Text == "")
            {
                quantityBox.ForeColor = Color.Silver;
                panel13.Size = new Size(430, 76);
                quantityBox.Size = new Size(413, 62);
                quantityBox.Location = new Point(9, 6);
                panel12.Location = new Point(3, 375);
                exchangedBtn.Location = new Point(112, 437);
                panel11.Size = new Size(437, 491);
                quantityBox.Text = "Введите количество покупаемой валюты";
                summBox.Text = "Сумма сделки: 0 рублей";
            }         
        }
        //----------------------------------------------------
        private void exchangedBtn_Click(object sender, EventArgs e)
        {
            //производим обмен по данным
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

                        //также для корректности добавления конвертируем дату через самописный класс
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
                        string query = "INSERT INTO operations (u_num, surname, name, patronymic, type, value, quantity, summ, date) VALUES (" + u_num + ", '" + FIO[0] + "', '" + FIO[1] + "', '" + FIO[2] + "', '" + selectOperBox.Text + "', '" + selectValueBox.Text[0] + "', " + quantityBox.Text + ", " + summ[1].Replace(',', '.') + ", '" + DateTime.Now.ToString("yyyy-MM-dd H:mm:ss") + "');";
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
                            { "_<value>_", selectValueBox.Text },
                            { "_<quantity>_", quantityBox.Text },
                            { "_<currency>_", currency.Replace(',', '.') },
                            { "_<summ_oper>_", summ[1].Replace(',', '.') },
                            { "_<name_client>_", FIO[0] + " " + FIO[1].ToString()[0] + ". " + FIO[2].ToString()[0] + "." },
                            { "_<name_cashier>_", CashierName.Text },
                            { "_<date_long>_", DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss") },
                        };
                        //подчищаем остатки предыдущей операции и сообщаем пользователю о работе
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
                        mainPanel.Visible = false;
                        clientsPanel.Visible = false;
                        exchangePanel.Visible = true;
                        searchPanel.Visible = false;
                        addclientPanel.Visible = false;
                        currencies_exchangePanel.Visible = false;
                    }
                }                
                catch (MySqlException)
                {
                    MessageBox.Show("Произошла ошибка данных! Проверьте введённые данные.");
                }
                catch (FormatException)
                {
                    MessageBox.Show("Произошла ошибка данных! Поле количества валюты некорректно, либо пустое.");
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                //do nothing
            }                       
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

        //динамический вывод предварительной стоимости операции
        private void quantityBox_TextChanged(object sender, EventArgs e)
        {

            //добавляем все валюты в массивы для дальнейшей переброски в класс
            double[] valuesBuy = { Convert.ToDouble(USD_buy.Text.Replace('.', ',')), Convert.ToDouble(EUR_buy.Text.Replace('.', ',')), Convert.ToDouble(GBP_buy.Text.Replace('.', ',')), Convert.ToDouble(CHF_buy.Text.Replace('.', ',')), Convert.ToDouble(JPY_buy.Text.Replace('.', ',')) };
            double[] valuesSell = { Convert.ToDouble(USD_sell.Text.Replace('.', ',')), Convert.ToDouble(EUR_sell.Text.Replace('.', ',')), Convert.ToDouble(GBP_sell.Text.Replace('.', ',')), Convert.ToDouble(CHF_sell.Text.Replace('.', ',')), Convert.ToDouble(JPY_sell.Text.Replace('.', ',')) };
            
            try
            {
                classes.summValues summValues = new classes.summValues();
                if (quantityBox.Text.ToString()[0] == '.')
                {
                    MessageBox.Show("Значение не может начинаться с '.' или ','");
                    quantityBox.Text = "";
                }
                else if (selectValueBox.SelectedIndex == -1 || selectOperBox.SelectedIndex == -1)
                {
                    //
                }
                else
                {
                    //обновляем постоянно предварительную стоимость
                    summBox.Text = "Сумма: " + summValues.summoutputValues(selectOperBox.SelectedIndex, selectValueBox.SelectedIndex, Convert.ToDouble(quantityBox.Text.Replace('.', ',')), valuesBuy, valuesSell).ToString().Replace(',', '.') + " рублей";
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        //визуализация ввода
        private void ValueradioButton_CheckedChanged(object sender, EventArgs e)
        {           
            if (selectOperBox.SelectedIndex == 0)
            {
                quantityBox.ForeColor = Color.Silver;
                panel13.Size = new Size(430, 76);
                quantityBox.Size = new Size(413, 62);
                quantityBox.Location = new Point(9, 6);
                panel12.Location = new Point(3, 375);
                exchangedBtn.Location = new Point(112, 437);
                panel11.Size = new Size(437, 491);
                quantityBox.Text = "Введите количество покупаемой валюты";
            }
            else if (selectOperBox.SelectedIndex == 1)
            {
                quantityBox.ForeColor = Color.Silver;
                panel13.Size = new Size(430, 76);
                quantityBox.Size = new Size(413, 62);
                quantityBox.Location = new Point(9, 6);
                panel12.Location = new Point(3, 375);
                exchangedBtn.Location = new Point(112, 437);
                panel11.Size = new Size(437, 491);
                quantityBox.Text = "Введите количество продаваемой валюты";
            }
            else
            {
                quantityBox.ForeColor = Color.FromArgb(11, 100, 103);
                panel13.Size = new Size(430, 54);
                quantityBox.Size = new Size(413, 30);
                quantityBox.Location = new Point(8, 11);
                panel12.Location = new Point(3, 356);
                exchangedBtn.Location = new Point(112, 425);
                panel11.Size = new Size(437, 479);
                quantityBox.ForeColor = Color.Silver;
                quantityBox.Text = "Введите количество валюты";
            }
        }

        //подчищаем результаты работы приложения
        private void search_values_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView3.Rows.Clear();
            dataGridView3.Columns.Clear();
        }

        private void search_operations_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView3.Rows.Clear();
            dataGridView3.Columns.Clear();
        }

        private void search_clients_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView3.Rows.Clear();
            dataGridView3.Columns.Clear();
        }
        //-------------------------------------------

        //модернизирование поиска с помощью клавиши Enter
        private void searchBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && searchBox.Text != "")
            {
                SearchBut_Click(sender, e);         //вызываем функцию поиска при нажатии на Enter
                                                    //и если поле поиска не пустое
            }
        }
    }
}
