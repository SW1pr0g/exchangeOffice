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
    public partial class CashierWindow : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);
        public CashierWindow()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            pnlNav.Height = MainBtn.Height;
            pnlNav.Top = MainBtn.Top;
            pnlNav.Left = MainBtn.Left;
            MainBtn.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void CashierWindow_Load(object sender, EventArgs e)
        {

        }

        private void MainBtn_Click(object sender, EventArgs e)
        {
            pnlNav.Height = MainBtn.Height;
            pnlNav.Top = MainBtn.Top;
            pnlNav.Left = MainBtn.Left;
            MainBtn.BackColor = Color.FromArgb(46, 51, 73);
            label3.Visible = true;
            BalancePanel.Visible = true;
            ClientsPanel.Visible = true;
            RatePanel.Visible = true;
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
            label3.Visible = false;
            BalancePanel.Visible = false;
            ClientsPanel.Visible = false;
            RatePanel.Visible = false;
        }
        private void ClientsBtn_Leave(object sender, EventArgs e)
        {
            ClientsBtn.BackColor = Color.FromArgb(11, 100, 103);
        }
        private void RecordsBtn_Click(object sender, EventArgs e)
        {
            pnlNav.Height = RecordsBtn.Height;
            pnlNav.Top = RecordsBtn.Top;
            pnlNav.Left = RecordsBtn.Left;
            RecordsBtn.BackColor = Color.FromArgb(46, 51, 73);
        }
        private void RecordsBtn_Leave(object sender, EventArgs e)
        {
            RecordsBtn.BackColor = Color.FromArgb(11, 100, 103);
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
