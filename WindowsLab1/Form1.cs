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

        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        //public int GetSelectedIndex()
        //{
        //    return listBox_person.SelectedIndex;
        //}

        //public Person GetSelectedPerson(int selectedIndex)
        //{
        //    //Person person = new Person(personList[selectedIndex].CardNumber, personList[selectedIndex].Name, personList[selectedIndex].Birthday);
        //    Person person = personList[selectedIndex];
        //    return person;
        //}

        void UpdateListBox()
        {
            listBox_person.BeginUpdate();
            listBox_person.Items.Clear();
            for (int i = 0; i < personList.Count(); i++)
            {
                listBox_person.Items.Add(personList[i].CardNumber.ToString() + "   ---   " + personList[i].Name + "   ---   " + personList[i].calcAge(personList[i].Birthday).ToString());
            }
            listBox_person.EndUpdate();
        }

        // Person list initialization
        List<Person> personList = new List<Person>();

        // Calls EditForm to create new person (Create Mode) or edit existing person (EditUser or EditAdmin Mode)
        void CallEditForm(EditForm.Mode mode)
        {
            EditForm editForm = new EditForm();

            editForm.SetMode(mode);
            int indexToEdit = -1;

            // If editForm is called to edit, get selected index (done before calling editForm, because it may be changed after)
            //if (mode != EditForm.Mode.Create)
            //{
            //    indexToEdit = GetSelectedIndex();
            //}

            // If form is called to edit (not create), set fields to selected person's values
            if (mode != EditForm.Mode.Create)
            {
                indexToEdit = listBox_person.SelectedIndex;
                editForm.text_name.Text = personList[indexToEdit].Name;
                editForm.text_card.Text = Convert.ToString(personList[indexToEdit].CardNumber);
                editForm.date_picker.Value = personList[indexToEdit].Birthday;
            }

            DialogResult result = editForm.ShowDialog(); // Call modal form
            // Modal form editForm, in turn, calls GetSelectedPerson method if needed (if it is called to edit)
            Person personToAdd = editForm.GetPerson(); // Get values from EditForm

            // If EditForm returned OK, apply values (values are always correct, otherwise editForm wouldn't return OK)
            if (result == DialogResult.OK && personToAdd.CardNumber > -1 && personToAdd.Name != "")
            {
                // Add new person if EditForm is called to create
                if (mode == EditForm.Mode.Create)
                {
                    personList.Add(personToAdd);
                }
                // Edit existing person, if EditForm is called to edit
                else
                {
                    personList[indexToEdit] = personToAdd;
                }
                UpdateListBox();
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            CallEditForm(EditForm.Mode.Create);
        }

        private void btn_change_Click(object sender, EventArgs e)
        {
            // Check if any person is selected, then call EditForm to edit as 'user'
            if (listBox_person.SelectedIndex >= 0)
            {
                CallEditForm(EditForm.Mode.EditUser);
            }
        }

        // An alternative for 'Edit selected' button
        private void listBox_person_doubleClick(object sender, MouseEventArgs e)
        {
            if (listBox_person.SelectedIndex >= 0)
            {
                CallEditForm(EditForm.Mode.EditUser);
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            // Check if any person is selected, then proceed
            if (listBox_person.SelectedIndex >= 0)
            {
                string deleteTitle = "Удаление";
                string deleteMessage = "Вы действительно хотите удалить запись?";
                
                DialogResult deleteResult = MessageBox.Show(this, deleteMessage, deleteTitle, MessageBoxButtons.YesNo);
                if (deleteResult == DialogResult.Yes)
                {
                    int indexToDelete = listBox_person.SelectedIndex;
                    listBox_person.Items.RemoveAt(indexToDelete);
                    personList.RemoveAt(indexToDelete);
                }
            }
        }
    }
}
