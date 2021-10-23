﻿using System;
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

        // Calls EditForm to create new person (Create Mode) or edit existing person (EditUser or EditAdmin Mode)
        void callEditForm(EditForm.Mode mode)
        {
            EditForm editForm = new EditForm();

            editForm.setMode(mode);
            int indexToEdit = -1;

            // If form is called to edit (not create), set fields to selected person's values
            if (mode != EditForm.Mode.Create)
            {
                indexToEdit = listBox_person.SelectedIndex;
                editForm.text_name.Text = personList[indexToEdit].Name;
                editForm.text_card.Text = Convert.ToString(personList[indexToEdit].CardNumber);
                editForm.date_picker.Value = personList[indexToEdit].Birthday;
            }

            DialogResult result = editForm.ShowDialog(); // Call modal form
            Person personToAdd = editForm.getPerson(); // Get values from EditForm

            // If EditForm returned OK, apply values (values are always correct, otherwise editForm wouldn't return OK)
            if (result == DialogResult.OK && personToAdd.CardNumber > -1 && personToAdd.Name != "")
            {
                // Add new person if EditForm is called to create
                if (mode == EditForm.Mode.Create)
                {
                    personList.Add(personToAdd);
                    updateListBox();
                }
                // Edit existing person, if EditForm is called to edit
                else
                {
                    personList[indexToEdit] = personToAdd;
                    updateListBox();
                } 
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            callEditForm(EditForm.Mode.Create);
        }

        private void btn_change_Click(object sender, EventArgs e)
        {
            // Check if any person is selected, then call EditForm to edit as 'user'
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

        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }
    }
}
