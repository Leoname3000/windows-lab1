namespace WindowsLab1
{
    partial class LoginForm
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
            this.comboBox_login = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.text_password = new System.Windows.Forms.TextBox();
            this.btn_login_apply = new System.Windows.Forms.Button();
            this.btn_login_cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBox_login
            // 
            this.comboBox_login.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_login.FormattingEnabled = true;
            this.comboBox_login.Items.AddRange(new object[] {
            "user",
            "admin"});
            this.comboBox_login.Location = new System.Drawing.Point(100, 24);
            this.comboBox_login.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBox_login.Name = "comboBox_login";
            this.comboBox_login.Size = new System.Drawing.Size(115, 21);
            this.comboBox_login.TabIndex = 0;
            this.comboBox_login.SelectedIndexChanged += new System.EventHandler(this.comboBox_login_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Войти как";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 76);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Пароль";
            // 
            // text_password
            // 
            this.text_password.Location = new System.Drawing.Point(100, 73);
            this.text_password.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.text_password.Name = "text_password";
            this.text_password.Size = new System.Drawing.Size(115, 20);
            this.text_password.TabIndex = 3;
            this.text_password.UseSystemPasswordChar = true;
            // 
            // btn_login_apply
            // 
            this.btn_login_apply.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_login_apply.Location = new System.Drawing.Point(37, 124);
            this.btn_login_apply.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_login_apply.Name = "btn_login_apply";
            this.btn_login_apply.Size = new System.Drawing.Size(80, 35);
            this.btn_login_apply.TabIndex = 8;
            this.btn_login_apply.Text = "Ок";
            this.btn_login_apply.UseVisualStyleBackColor = true;
            this.btn_login_apply.Click += new System.EventHandler(this.btn_login_apply_Click);
            // 
            // btn_login_cancel
            // 
            this.btn_login_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_login_cancel.Location = new System.Drawing.Point(134, 124);
            this.btn_login_cancel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_login_cancel.Name = "btn_login_cancel";
            this.btn_login_cancel.Size = new System.Drawing.Size(80, 35);
            this.btn_login_cancel.TabIndex = 9;
            this.btn_login_cancel.Text = "Отменить";
            this.btn_login_cancel.UseVisualStyleBackColor = true;
            this.btn_login_cancel.Click += new System.EventHandler(this.btn_login_cancel_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(250, 184);
            this.Controls.Add(this.btn_login_cancel);
            this.Controls.Add(this.btn_login_apply);
            this.Controls.Add(this.text_password);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_login);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "LoginForm";
            this.Text = "Вход";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_login;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox text_password;
        private System.Windows.Forms.Button btn_login_apply;
        private System.Windows.Forms.Button btn_login_cancel;
    }
}