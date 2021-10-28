namespace WindowsLab1
{
    partial class EditForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label_name = new System.Windows.Forms.Label();
            this.text_name = new System.Windows.Forms.TextBox();
            this.text_card = new System.Windows.Forms.TextBox();
            this.label_card = new System.Windows.Forms.Label();
            this.label_date = new System.Windows.Forms.Label();
            this.date_picker = new System.Windows.Forms.DateTimePicker();
            this.btn_edit_apply = new System.Windows.Forms.Button();
            this.btn_edit_cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_name
            // 
            this.label_name.AutoSize = true;
            this.label_name.Location = new System.Drawing.Point(24, 28);
            this.label_name.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_name.Name = "label_name";
            this.label_name.Size = new System.Drawing.Size(29, 13);
            this.label_name.TabIndex = 0;
            this.label_name.Text = "Имя";
            // 
            // text_name
            // 
            this.text_name.Location = new System.Drawing.Point(122, 26);
            this.text_name.Margin = new System.Windows.Forms.Padding(2);
            this.text_name.Name = "text_name";
            this.text_name.Size = new System.Drawing.Size(151, 20);
            this.text_name.TabIndex = 1;
            // 
            // text_card
            // 
            this.text_card.BackColor = System.Drawing.SystemColors.Window;
            this.text_card.ForeColor = System.Drawing.SystemColors.WindowText;
            this.text_card.Location = new System.Drawing.Point(122, 61);
            this.text_card.Margin = new System.Windows.Forms.Padding(2);
            this.text_card.Name = "text_card";
            this.text_card.Size = new System.Drawing.Size(151, 20);
            this.text_card.TabIndex = 3;
            // 
            // label_card
            // 
            this.label_card.AutoSize = true;
            this.label_card.Location = new System.Drawing.Point(24, 63);
            this.label_card.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_card.Name = "label_card";
            this.label_card.Size = new System.Drawing.Size(75, 13);
            this.label_card.TabIndex = 2;
            this.label_card.Text = "Номер карты";
            // 
            // label_date
            // 
            this.label_date.AutoSize = true;
            this.label_date.Location = new System.Drawing.Point(24, 98);
            this.label_date.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_date.Name = "label_date";
            this.label_date.Size = new System.Drawing.Size(87, 13);
            this.label_date.TabIndex = 4;
            this.label_date.Text = "Дата Рождения";
            // 
            // date_picker
            // 
            this.date_picker.Location = new System.Drawing.Point(122, 98);
            this.date_picker.Margin = new System.Windows.Forms.Padding(2);
            this.date_picker.Name = "date_picker";
            this.date_picker.Size = new System.Drawing.Size(151, 20);
            this.date_picker.TabIndex = 5;
            // 
            // btn_edit_apply
            // 
            this.btn_edit_apply.Location = new System.Drawing.Point(26, 158);
            this.btn_edit_apply.Margin = new System.Windows.Forms.Padding(2);
            this.btn_edit_apply.Name = "btn_edit_apply";
            this.btn_edit_apply.Size = new System.Drawing.Size(109, 35);
            this.btn_edit_apply.TabIndex = 6;
            this.btn_edit_apply.Text = "Принять";
            this.btn_edit_apply.UseVisualStyleBackColor = true;
            this.btn_edit_apply.Click += new System.EventHandler(this.btn_edit_apply_Click);
            this.btn_edit_apply.MouseEnter += new System.EventHandler(this.btn_edit_apply_mouseEnter);
            // 
            // btn_edit_cancel
            // 
            this.btn_edit_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_edit_cancel.Location = new System.Drawing.Point(164, 158);
            this.btn_edit_cancel.Margin = new System.Windows.Forms.Padding(2);
            this.btn_edit_cancel.Name = "btn_edit_cancel";
            this.btn_edit_cancel.Size = new System.Drawing.Size(109, 35);
            this.btn_edit_cancel.TabIndex = 7;
            this.btn_edit_cancel.Text = "Отменить";
            this.btn_edit_cancel.UseVisualStyleBackColor = true;
            this.btn_edit_cancel.Click += new System.EventHandler(this.btn_edit_cancel_Click);
            // 
            // EditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 218);
            this.Controls.Add(this.btn_edit_cancel);
            this.Controls.Add(this.btn_edit_apply);
            this.Controls.Add(this.date_picker);
            this.Controls.Add(this.label_date);
            this.Controls.Add(this.text_card);
            this.Controls.Add(this.label_card);
            this.Controls.Add(this.text_name);
            this.Controls.Add(this.label_name);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "EditForm";
            this.Text = "Запись";
            this.Load += new System.EventHandler(this.EditForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDown_OpenLogin);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_name;
        public System.Windows.Forms.TextBox text_name;
        public System.Windows.Forms.TextBox text_card;
        private System.Windows.Forms.Label label_card;
        private System.Windows.Forms.Label label_date;
        public System.Windows.Forms.DateTimePicker date_picker;
        private System.Windows.Forms.Button btn_edit_apply;
        private System.Windows.Forms.Button btn_edit_cancel;
    }
}