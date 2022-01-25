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

namespace AIS_exchangeOffice
{
    public partial class AdminWindow : Form
    {
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
            Application.Exit();
        }

        private void exitButton_exchange_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void exitButton_clients_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
    }
}
