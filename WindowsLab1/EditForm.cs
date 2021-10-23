using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsLab1
{
    public partial class EditForm : Form
    {

        public EditForm()
        {
            InitializeComponent();
        }



        public enum Mode
        {
            Create,
            EditUser,
            EditAdmin
        }

        Mode mode = Mode.Create;

        public void setMode(Mode mode)
        {
            Color highlightColor = System.Drawing.Color.Coral;

            switch (mode)
            {
                case Mode.EditUser:
                    this.mode = Mode.EditUser;
                    this.text_card.Enabled = false;
                    this.date_picker.Enabled = false;
                    break;
                case Mode.EditAdmin:
                    this.mode = Mode.EditAdmin;
                    this.text_card.Enabled = true;
                    this.date_picker.Enabled = true;
                    this.label_card.BackColor = highlightColor;
                    this.label_date.BackColor = highlightColor;
                    break;
                default:
                    break;
            }
        }



        // Values initialization
        int cardNumber = -1;
        string name = "";
        DateTime birthday = DateTime.Today;

        private void btn_edit_apply_Click(object sender, EventArgs e)
        {
            // Check for proper entered values, then read text boxes
            if (text_name.TextLength > 0 && text_card.TextLength > 0)
            {
                bool parseSuccess = int.TryParse(text_card.Text, out cardNumber);
                if (parseSuccess && text_card.Text.Length == 5)
                {
                    name = text_name.Text;
                    birthday = date_picker.Value;
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Номер карты состоит из 5 цифр и не содержит букв!");
                }
            }
        }

        // Send entered person
        public Person getPerson()
        {
            Person person = new Person(cardNumber, name, birthday);
            return person;
        }

        // Open login form

        LoginForm loginForm = new LoginForm();

        private void KeyDown_OpenLogin(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Shift && e.KeyCode == Keys.L && mode == Mode.EditUser)
            {
                loginForm.FormClosed += LoginForm_Closed;
                loginForm.Show();
            }        
        }

        int oldCardNumber;

        void LoginForm_Closed(object sender, FormClosedEventArgs e)
        {
            if (loginForm.passwordCorrect())
            {
                this.setMode(Mode.EditAdmin);
                oldCardNumber = Convert.ToInt32(text_card.Text);
            }
            else
            {
                MessageBox.Show("Неверный пароль!");
            }
        }

        private void btn_edit_apply_mouseEnter(object sender, EventArgs e)
        {
            if (mode == Mode.EditAdmin)
            {
                if (Convert.ToInt32(text_card.Text) != oldCardNumber)
                {
                    if (btn_edit_apply.Location.Y > 50 && btn_edit_apply.Location.X < 100)
                        btn_edit_apply.Location = new Point(btn_edit_apply.Location.X, btn_edit_apply.Location.Y - 50);
                    else if (btn_edit_apply.Location.X < 300)
                        btn_edit_apply.Location = new Point(btn_edit_apply.Location.X + 80, btn_edit_apply.Location.Y);
                    else if (btn_edit_apply.Location.Y < 200)
                        btn_edit_apply.Location = new Point(btn_edit_apply.Location.X, btn_edit_apply.Location.Y + 50);
                    else
                        btn_edit_apply.Location = new Point(btn_edit_apply.Location.X - 80, btn_edit_apply.Location.Y);
                }
            }
        }

        private void EditForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }
    }
}
