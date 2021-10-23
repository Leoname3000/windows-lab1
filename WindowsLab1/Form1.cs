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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Person list initialization
        List<Person> personList = new List<Person>();

        void updateListBox()
        {
            listBox_person.BeginUpdate();
            listBox_person.Items.Clear();
            for (int i = 0; i < personList.Count(); i++)
            {
                listBox_person.Items.Add(personList[i].CardNumber.ToString() + "   ---   " + personList[i].Name + "   ---   " + personList[i].calcAge(personList[i].Birthday).ToString());
            }
            listBox_person.EndUpdate();
        }

        void callEditForm(EditForm.Mode mode)
        {
            EditForm editForm = new EditForm();

            editForm.setMode(mode);
            int indexToEdit = -1;

            // Set current values
            if (mode != EditForm.Mode.Create)
            {
                indexToEdit = listBox_person.SelectedIndex;
                editForm.text_name.Text = personList[indexToEdit].Name;
                editForm.text_card.Text = Convert.ToString(personList[indexToEdit].CardNumber);
                editForm.date_picker.Value = personList[indexToEdit].Birthday;
            }

            DialogResult result = editForm.ShowDialog();
            Person personToAdd = editForm.getPerson();

            // If editForm returned OK, check if new values are proper, then apply them
            if (result == DialogResult.OK && personToAdd.CardNumber > -1 && personToAdd.Name != "")
            {
                if (personToAdd.Birthday > DateTime.Now)
                {
                    MessageBox.Show("Человек из будущего!");
                }
                else 
                {
                    if (mode == EditForm.Mode.Create)
                    {
                        personList.Add(personToAdd);
                        updateListBox();
                    }
                    else
                    {
                        personList[indexToEdit] = personToAdd;
                        updateListBox();
                    } 
                }
            }
        }
        public int getSelectedIndex()
        {
            return listBox_person.SelectedIndex;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            callEditForm(EditForm.Mode.Create);
        }

        private void btn_change_Click(object sender, EventArgs e)
        {
            if (listBox_person.SelectedIndex >= 0)
            {
                callEditForm(EditForm.Mode.EditUser);
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            // Check if any person is selected, then proceed
            if (listBox_person.SelectedIndex >= 0)
            {
                string deleteMessage = "Вы действительно хотите удалить запись?";
                string deleteTitle = "Удаление";

                DialogResult deleteResult = MessageBox.Show(this, deleteMessage, deleteTitle, MessageBoxButtons.YesNo);
                if (deleteResult == DialogResult.Yes)
                {
                    int indexToDelete = listBox_person.SelectedIndex;
                    listBox_person.Items.RemoveAt(indexToDelete);
                    personList.RemoveAt(indexToDelete);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }
    }
}
