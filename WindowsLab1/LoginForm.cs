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
            this.AcceptButton = btn_login_apply;
            this.comboBox_login.SelectedIndex = 0;
            this.Location = new Point(625, 215);
        }

        private void comboBox_login_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_login.SelectedIndex == 1)
            {
                text_password.Enabled = true;
            }
            else
            {
                text_password.Enabled = false;
                text_password.Text = "";
            }
        }

        String GetHash(String sourceString)
        {
            //using (MD5 md5 = MD5.Create())
            //{
                MD5 md5 = MD5.Create();
                byte[] sourceBytes = Encoding.ASCII.GetBytes(sourceString);
                byte[] hashBytes = md5.ComputeHash(sourceBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2"));
                }
                return sb.ToString();
            //}
        }

        bool CompareHash(String sourceString)
        {
            String hashString = "3f11e8d8d634bc8704b1a1acae919228"; // password = "aboba"
            if (hashString == GetHash(sourceString))
            {
                return true;
            }
            return false;
        }

        public bool loginSuccessful = false;

        private void btn_login_apply_Click(object sender, EventArgs e)
        {
            String loginPassConcat = comboBox_login.Text + text_password.Text;
            loginSuccessful = CompareHash(loginPassConcat);
            //Console.WriteLine(GetHash(loginPassConcat)); // <-- Uncomment to get hash
            if (comboBox_login.SelectedIndex == 1 && !loginSuccessful)
            {
                MessageBox.Show("Неверный пароль!");
                text_password.Text = "";
            }
            else
            {
                this.Close();
            }
        }

        private void btn_login_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
