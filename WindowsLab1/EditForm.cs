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

        //if (mode != Mode.Create)
        //{
        //    Form1 callerForm1 = (Form1)this.Owner;
        //    Person inputPerson = callerForm1.GetSelectedPerson(callerForm1.GetSelectedIndex());
        //    text_name.Text = inputPerson.Name;
        //    text_card.Text = Convert.ToString(inputPerson.CardNumber);
        //    date_picker.Value = inputPerson.Birthday;
        //}

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
            this.Location = new Point(600, 165);
        }

        public enum Mode
        {
            Create,
            EditUser,
            EditAdmin
        }

        int oldCardNumber = -1;
        Mode mode = Mode.Create;

        // Changes EditForm's mode
        public void SetMode(Mode mode)
        {
            Color lightHighlightColor = Color.LightSalmon;
            Color darkHighlightColor = Color.LimeGreen;
            Color backgroundColor = Color.LightGoldenrodYellow;

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
                    oldCardNumber = int.Parse(text_card.Text);
                    text_name.BackColor = lightHighlightColor;
                    text_card.BackColor = lightHighlightColor;
                    btn_edit_apply.BackColor = darkHighlightColor;
                    btn_edit_cancel.BackColor = darkHighlightColor;
                    BackColor = backgroundColor;
                    break;
                default:
                    //this.mode = Mode.Create;
                    date_picker.Value = defaultBirthday;
                    break;
            }
        }

        // Values initialization
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
            // Close LoginForm if opened
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
            }
            loginFormOpened = false;
        }

        // Button's mouse escaping algorithm
        void ButtonEscape(Button button)
        {
            Point buttonCenter = new Point(button.Location.X + button.Height / 2, button.Location.Y + button.Height / 2);
            Point cursorLocation = Cursor.Position;
            int radiusX = button.Width / 2;
            int radiusY = button.Height / 2;
            int deltaX = radiusX - Math.Abs(buttonCenter.X - cursorLocation.X);
            int deltaY = radiusY - Math.Abs(buttonCenter.Y - cursorLocation.Y);
            int signX = Math.Sign(buttonCenter.X - cursorLocation.X);
            int signY = Math.Sign(buttonCenter.Y - cursorLocation.Y);
            button.Location = new Point(button.Location.X + signX * deltaX, button.Location.Y + signY * deltaY);
        }

        // Teleports button to random location
        void ButtonTeleport(Button button)
        {
            Random random = new Random();
            int randX = random.Next(16, this.Width - button.Width);
            int randY = random.Next(40, this.Height - button.Height);
            button.Location = new Point(randX - 16, randY - 40);
        }

        private void btn_edit_apply_mouseEnter(object sender, EventArgs e)
        {
            // In 'admin' mode, if card number is changed, 'apply' button starts to escape mouse, avoiding being pushed
            if (mode == Mode.EditAdmin && text_card.Text != oldCardNumber.ToString())
            {
                ButtonTeleport(btn_edit_apply);
            }
        }
    }
}
