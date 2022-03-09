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

        private void mainPanel_EnabledChanged(object sender, EventArgs e)
        {
            //sell
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
                string r = reader["summsale"].ToString();
                string r1 = reader["summpurchase"].ToString();
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
