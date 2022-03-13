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
    public partial class CashierWindowMain : Form
    {
        public bool searchEdit = false;
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]        
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);
        public CashierWindowMain()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            pnlNav.Height = MainBtn.Height;
            pnlNav.Top = MainBtn.Top;
            pnlNav.Left = MainBtn.Left;
            MainBtn.BackColor = Color.FromArgb(46, 51, 73);

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
        }
        private void ExchangeBtn_Leave(object sender, EventArgs e)
        {
            ExchangeBtn.BackColor = Color.FromArgb(11, 100, 103);
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
        }

        private void SearchBtn_Leave(object sender, EventArgs e)
        {
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

        private void CashierWindowMain_Load(object sender, EventArgs e)
        {
            CashierName.Text = AuthForm.nameUser;
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
            MessageBox.Show("Aloha");
        }

        private void clientsPanel_VisibleChanged(object sender, EventArgs e)
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
                this.dataGridView1.Columns.Add("id", "№");
                this.dataGridView1.Columns["id"].Width = 32;
                this.dataGridView1.Columns.Add("surname", "Фамилия");
                this.dataGridView1.Columns["surname"].Width = 110;
                this.dataGridView1.Columns.Add("name", "Имя");
                this.dataGridView1.Columns["name"].Width = 90;               
                this.dataGridView1.Columns.Add("patronymic", "Отчество");
                this.dataGridView1.Columns["patronymic"].Width = 110;
                this.dataGridView1.Columns.Add("date_birth", "Дата рождения");
                this.dataGridView1.Columns["date_birth"].Width = 90;
                this.dataGridView1.Columns.Add("seriesDoc", "Серия документа");
                this.dataGridView1.Columns["seriesDoc"].Width = 100;
                this.dataGridView1.Columns.Add("numberDoc", "Номер документа");
                this.dataGridView1.Columns["numberDoc"].Width = 100;
                while (reader.Read())
                {
                    classes.reversedate reversedate = new classes.reversedate();
                    dataGridView1.Rows.Add(reader["id"].ToString(), reader["surname"].ToString(), reader["name"].ToString(), reader["patronymic"].ToString(), reversedate.dateReverse(reader["date_birth"].ToString()), reader["seriesDoc"].ToString(), reader["numberDoc"].ToString());
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

        private void print_currencies_Click(object sender, EventArgs e)
        {
            classes.print_documents print_documents = new classes.print_documents();
            DialogResult dialogResult = MessageBox.Show("Вывести на печать данные о текущем курсе валют?", "Печать текущего курса валют", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                print_documents.print_currencies();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do nothing
            }
        }

        private void AddClientsBtn_Click(object sender, EventArgs e)
        {
            clientsPanel.Visible = false;
            addclientPanel.Visible = true;
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
                //do nothing
            }
        }

        private void GoBackClientsPanel_Click(object sender, EventArgs e)
        {
            clientsPanel.Visible = true;
            addclientPanel.Visible = false;
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
                        int id = dataGridView1.RowCount; id++;
                        string query = "INSERT INTO clients (id, surname, name, patronymic, date_birth, seriesDoc, numberDoc) VALUES (" + id +  ", '" + surnameBox.Text + "', '" + nameBox.Text + "', '" + patronymicBox.Text + "', '" + getDate.dateReverse(dateTimePicker1.Value.ToString().Substring(0, 10)) + "', " + seriesBox.Text + ", " + numberBox.Text + ")";
                        MySqlCommand command = new MySqlCommand(query, connection);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Клиент успешно добавлен!");
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
    }
}
