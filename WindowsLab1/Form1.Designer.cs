namespace WindowsLab1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBox_person = new System.Windows.Forms.ListBox();
            this.btn_change = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox_person
            // 
            this.listBox_person.FormattingEnabled = true;
            this.listBox_person.ItemHeight = 16;
            this.listBox_person.Location = new System.Drawing.Point(12, 12);
            this.listBox_person.Name = "listBox_person";
            this.listBox_person.Size = new System.Drawing.Size(776, 340);
            this.listBox_person.TabIndex = 0;
            // 
            // btn_change
            // 
            this.btn_change.Location = new System.Drawing.Point(331, 376);
            this.btn_change.Name = "btn_change";
            this.btn_change.Size = new System.Drawing.Size(135, 46);
            this.btn_change.TabIndex = 1;
            this.btn_change.Text = "Изменить выбранную";
            this.btn_change.UseVisualStyleBackColor = true;
            this.btn_change.Click += new System.EventHandler(this.btn_change_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.Location = new System.Drawing.Point(565, 376);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(135, 46);
            this.btn_delete.TabIndex = 2;
            this.btn_delete.Text = "Удалить выбранную";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_add
            // 
            this.btn_add.Location = new System.Drawing.Point(96, 376);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(135, 46);
            this.btn_add.TabIndex = 3;
            this.btn_add.Text = "Создать новую запись";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.btn_change);
            this.Controls.Add(this.listBox_person);
            this.Name = "Form1";
            this.Text = "Киндер пингви я люблю";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox_person;
        private System.Windows.Forms.Button btn_change;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button btn_add;
    }
}

