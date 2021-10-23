using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace WindowsLab1
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            this.comboBox_login.SelectedIndex = 0;
        }

        private void comboBox_login_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_login.SelectedIndex == 1)
            {
                this.text_password.Enabled = true;
            }
            else
            {
                this.text_password.Enabled = false;
            }
        }

        public bool passwordCorrect()
        {
            String password = "aboba";
            if (text_password.Text == password)
            {
                return true;
            }
            return false;
        }

        private void btn_login_apply_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_login_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
