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

        private void EditForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.AcceptButton = btn_edit_apply;
            //Console.WriteLine(this.Width.ToString() + " " + this.Height.ToString());
            //Console.WriteLine(this.btn_edit_apply.Width.ToString() + " " + this.btn_edit_apply.Height.ToString());
        }

        public enum Mode
        {
            Create,
            EditUser,
            EditAdmin
        }

        Mode mode = Mode.Create;

        // Changes EditForm's mode
        public void SetMode(Mode mode)
        {
            Color highlightColor = System.Drawing.Color.Coral;
            Color backgroundColor = System.Drawing.Color.Yellow;

            //if (mode != Mode.Create)
            //{
            //    Form1 callerForm1 = (Form1)this.Owner;
            //    Person inputPerson = callerForm1.GetSelectedPerson(callerForm1.GetSelectedIndex());
            //    text_name.Text = inputPerson.Name;
            //    text_card.Text = Convert.ToString(inputPerson.CardNumber);
            //    date_picker.Value = inputPerson.Birthday;
            //}

            this.mode = mode;

            switch (mode)
            {
                case Mode.EditUser:
                    //this.mode = Mode.EditUser;
                    text_card.Enabled = false;
                    date_picker.Enabled = false;
                    break;
                case Mode.EditAdmin:
                    //this.mode = Mode.EditAdmin;
                    text_card.Enabled = true;
                    date_picker.Enabled = true;
                    label_card.BackColor = highlightColor;
                    label_date.BackColor = highlightColor;
                    BackColor = backgroundColor;
                    break;
                default:
                    //this.mode = Mode.Create;
                    date_picker.Value = defaultBirthday;
                    break;
            }
        }

        // Values initialization
        int oldCardNumber = -1;
        int cardNumber = -1;
        string name = "";
        DateTime defaultBirthday = new DateTime(2000, 1, 1, 0, 0, 0);
        DateTime birthday = DateTime.Now;
        String incorrectCardNumberMessage = "Номер карты должен состоять ровно из 5 цифр!";
        String incorrectBirthdayMessage = "Человек из будущего!";

        private void btn_edit_apply_Click(object sender, EventArgs e)
        {
            // Read values (mustn't be empty)
            if (text_name.TextLength > 0 && text_card.TextLength > 0)
            {
                // If card number is incorrect, show message and clean field if it contains letters
                bool parseSuccess = int.TryParse(text_card.Text, out cardNumber);
                if (!parseSuccess || text_card.Text.Length != 5 || cardNumber < 10000)
                {
                    MessageBox.Show(incorrectCardNumberMessage);
                    if (!parseSuccess)
                    {
                        text_card.Text = "";
                    }
                }
                // If birthday is incorrect, show message and set field to current time
                else if (date_picker.Value > DateTime.Now)
                {
                    MessageBox.Show(incorrectBirthdayMessage);
                    date_picker.Value = defaultBirthday;
                }
                // Else (everything correct) set values and return OK
                else
                {
                    name = text_name.Text;
                    birthday = date_picker.Value;
                    this.DialogResult = DialogResult.OK;
                }
            }
            // Close LoginForm, if opened
            if (loginFormOpened)
            {
                loginForm.Close();
                loginFormOpened = false;
            }
        }

        // On cancel, close LoginForm, if opened
        private void btn_edit_cancel_Click(object sender, EventArgs e)
        {
            if (loginFormOpened)
            {
                loginForm.Close();
                loginFormOpened = false;
            }
        }

        // Send entered values as a person (called from Form1 if EditForm returns OK, i.e. the values are correct)
        public Person GetPerson()
        {
            Person person = new Person(cardNumber, name, birthday);
            return person;
        }

        // Open login form if ctrl+shift+L is pressed and if mode is set to EditUser (not Create or EditAdmin, in which case it doesn't make sense)
        bool loginFormOpened = false; // Flag to prevent opening of multiple LoginForms
        LoginForm loginForm = new LoginForm();
        private void KeyDown_OpenLogin(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Shift && e.KeyCode == Keys.L && mode == Mode.EditUser && !loginFormOpened)
            {
                loginForm = new LoginForm();
                loginForm.FormClosed += LoginForm_Closed;
                loginForm.Show();
                loginFormOpened = true;
            }        
        }

        // Close LoginForm (called if user is set to 'user' or if password in 'admin' is correct)
        void LoginForm_Closed(object sender, FormClosedEventArgs e)
        {
            if (loginForm.loginSuccessful)
            {
                this.SetMode(Mode.EditAdmin);
                //bool parseSuccess = int.TryParse(text_card.Text, out cardNumber);
                //if (!(parseSuccess && text_card.Text.Length == 5))
                //{
                //    MessageBox.Show(wrongCardNumberMessage);
                //}
            }
            loginFormOpened = false;
        }

        // Button's mouse escaping algorithm
        void ButtonEscape(Button button)
        {
            if (button.Location.X <= 15 - button.Location.X)
            {
                button.Location = new Point(this.Width - button.Width, button.Location.Y);
            }
            button.Location = new Point(button.Location.X - 15, button.Location.Y);
        }

        private void btn_edit_apply_mouseEnter(object sender, EventArgs e)
        {
            // In 'admin' mode, if card number is changed, 'apply' button starts to escape mouse, avoiding being pushed
            if (mode == Mode.EditAdmin)
            {
                if (!int.TryParse(text_card.Text, out cardNumber))
                {
                    //text_card.Text = oldCardNumber.ToString();
                }
            }
        }
    }
}
