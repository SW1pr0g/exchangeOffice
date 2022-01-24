using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIS_exchangeOffice
{
    public partial class AuthForm : Form
    {
        public AuthForm()
        {
            InitializeComponent();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
    }
}
