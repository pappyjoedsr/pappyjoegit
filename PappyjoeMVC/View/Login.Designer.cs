namespace PappyjoeMVC.View
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.PB_Image = new System.Windows.Forms.PictureBox();
            this.Btn_Close = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Lab_version = new System.Windows.Forms.Label();
            this.Lab_InvalidLogin = new System.Windows.Forms.Label();
            this.Lab_InvaldActivation = new System.Windows.Forms.Label();
            this.txt_userName = new System.Windows.Forms.TextBox();
            this.Btn_Login = new System.Windows.Forms.Button();
            this.PB_Username = new System.Windows.Forms.PictureBox();
            this.PB_Password = new System.Windows.Forms.PictureBox();
            this.txt_password = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_daycode = new System.Windows.Forms.TextBox();
            this.btn_Activation = new System.Windows.Forms.Button();
            this.txt_activation = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_getCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Image)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Username)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Password)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PB_Image
            // 
            this.PB_Image.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.PB_Image.Image = ((System.Drawing.Image)(resources.GetObject("PB_Image.Image")));
            this.PB_Image.Location = new System.Drawing.Point(67, 5);
            this.PB_Image.Name = "PB_Image";
            this.PB_Image.Size = new System.Drawing.Size(227, 32);
            this.PB_Image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PB_Image.TabIndex = 14;
            this.PB_Image.TabStop = false;
            // 
            // Btn_Close
            // 
            this.Btn_Close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Close.ForeColor = System.Drawing.Color.Gray;
            this.Btn_Close.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Close.Image")));
            this.Btn_Close.Location = new System.Drawing.Point(370, 4);
            this.Btn_Close.Name = "Btn_Close";
            this.Btn_Close.Size = new System.Drawing.Size(40, 32);
            this.Btn_Close.TabIndex = 15;
            this.Btn_Close.UseVisualStyleBackColor = true;
            this.Btn_Close.Click += new System.EventHandler(this.Btn_Close_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.Lab_version);
            this.panel2.Controls.Add(this.Lab_InvalidLogin);
            this.panel2.Controls.Add(this.Lab_InvaldActivation);
            this.panel2.Controls.Add(this.txt_userName);
            this.panel2.Controls.Add(this.Btn_Login);
            this.panel2.Controls.Add(this.PB_Username);
            this.panel2.Controls.Add(this.PB_Password);
            this.panel2.Controls.Add(this.txt_password);
            this.panel2.Location = new System.Drawing.Point(18, 39);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(392, 141);
            this.panel2.TabIndex = 16;
            // 
            // Lab_version
            // 
            this.Lab_version.AutoSize = true;
            this.Lab_version.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Lab_version.Location = new System.Drawing.Point(311, 104);
            this.Lab_version.Name = "Lab_version";
            this.Lab_version.Size = new System.Drawing.Size(76, 13);
            this.Lab_version.TabIndex = 11;
            this.Lab_version.Text = "Version 20.04";
            // 
            // Lab_InvalidLogin
            // 
            this.Lab_InvalidLogin.AutoSize = true;
            this.Lab_InvalidLogin.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Lab_InvalidLogin.Location = new System.Drawing.Point(23, 89);
            this.Lab_InvalidLogin.Name = "Lab_InvalidLogin";
            this.Lab_InvalidLogin.Size = new System.Drawing.Size(79, 13);
            this.Lab_InvalidLogin.TabIndex = 10;
            this.Lab_InvalidLogin.Text = "* Invalid login";
            // 
            // Lab_InvaldActivation
            // 
            this.Lab_InvaldActivation.AutoSize = true;
            this.Lab_InvaldActivation.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Lab_InvaldActivation.Location = new System.Drawing.Point(212, 189);
            this.Lab_InvaldActivation.Name = "Lab_InvaldActivation";
            this.Lab_InvaldActivation.Size = new System.Drawing.Size(130, 13);
            this.Lab_InvaldActivation.TabIndex = 11;
            this.Lab_InvaldActivation.Text = "* Invalid activation code";
            // 
            // txt_userName
            // 
            this.txt_userName.BackColor = System.Drawing.Color.White;
            this.txt_userName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_userName.ForeColor = System.Drawing.Color.Gray;
            this.txt_userName.Location = new System.Drawing.Point(50, 19);
            this.txt_userName.Name = "txt_userName";
            this.txt_userName.Size = new System.Drawing.Size(229, 25);
            this.txt_userName.TabIndex = 3;
            this.txt_userName.Text = "UserName";
            this.txt_userName.Click += new System.EventHandler(this.txt_userName_Click);
            this.txt_userName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_userName_KeyDown);
            // 
            // Btn_Login
            // 
            this.Btn_Login.BackColor = System.Drawing.Color.DodgerBlue;
            this.Btn_Login.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Login.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Btn_Login.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Login.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Login.ForeColor = System.Drawing.Color.White;
            this.Btn_Login.Location = new System.Drawing.Point(301, 53);
            this.Btn_Login.Name = "Btn_Login";
            this.Btn_Login.Size = new System.Drawing.Size(71, 27);
            this.Btn_Login.TabIndex = 5;
            this.Btn_Login.Text = "LOGIN";
            this.Btn_Login.UseVisualStyleBackColor = false;
            this.Btn_Login.Click += new System.EventHandler(this.Btn_Login_Click);
            // 
            // PB_Username
            // 
            this.PB_Username.BackColor = System.Drawing.Color.Gray;
            this.PB_Username.Image = ((System.Drawing.Image)(resources.GetObject("PB_Username.Image")));
            this.PB_Username.Location = new System.Drawing.Point(21, 19);
            this.PB_Username.Name = "PB_Username";
            this.PB_Username.Size = new System.Drawing.Size(28, 25);
            this.PB_Username.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PB_Username.TabIndex = 7;
            this.PB_Username.TabStop = false;
            // 
            // PB_Password
            // 
            this.PB_Password.BackColor = System.Drawing.Color.Gray;
            this.PB_Password.Image = ((System.Drawing.Image)(resources.GetObject("PB_Password.Image")));
            this.PB_Password.Location = new System.Drawing.Point(21, 55);
            this.PB_Password.Name = "PB_Password";
            this.PB_Password.Size = new System.Drawing.Size(28, 25);
            this.PB_Password.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PB_Password.TabIndex = 7;
            this.PB_Password.TabStop = false;
            // 
            // txt_password
            // 
            this.txt_password.BackColor = System.Drawing.Color.White;
            this.txt_password.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_password.ForeColor = System.Drawing.Color.Gray;
            this.txt_password.Location = new System.Drawing.Point(50, 55);
            this.txt_password.Name = "txt_password";
            this.txt_password.PasswordChar = '*';
            this.txt_password.Size = new System.Drawing.Size(229, 25);
            this.txt_password.TabIndex = 4;
            this.txt_password.Text = "************";
            this.txt_password.Click += new System.EventHandler(this.txt_password_Click);
            this.txt_password.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_password_KeyDown);
            this.txt_password.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_password_KeyUp);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txt_daycode);
            this.panel1.Controls.Add(this.btn_Activation);
            this.panel1.Controls.Add(this.txt_activation);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txt_getCode);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(14, 190);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(392, 141);
            this.panel1.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label7.Location = new System.Drawing.Point(12, 89);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Day Code";
            // 
            // txt_daycode
            // 
            this.txt_daycode.Location = new System.Drawing.Point(119, 84);
            this.txt_daycode.Name = "txt_daycode";
            this.txt_daycode.Size = new System.Drawing.Size(259, 22);
            this.txt_daycode.TabIndex = 14;
            this.txt_daycode.Click += new System.EventHandler(this.txt_daycode_Click);
            this.txt_daycode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_daycode_KeyPress);
            // 
            // btn_Activation
            // 
            this.btn_Activation.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_Activation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Activation.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Activation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Activation.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Activation.ForeColor = System.Drawing.Color.White;
            this.btn_Activation.Location = new System.Drawing.Point(271, 111);
            this.btn_Activation.Name = "btn_Activation";
            this.btn_Activation.Size = new System.Drawing.Size(71, 27);
            this.btn_Activation.TabIndex = 6;
            this.btn_Activation.Text = "Activate";
            this.btn_Activation.UseVisualStyleBackColor = false;
            this.btn_Activation.Click += new System.EventHandler(this.btn_Activation_Click);
            // 
            // txt_activation
            // 
            this.txt_activation.Location = new System.Drawing.Point(119, 56);
            this.txt_activation.Name = "txt_activation";
            this.txt_activation.Size = new System.Drawing.Size(259, 22);
            this.txt_activation.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(12, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Activation";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(138, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "Activation";
            // 
            // txt_getCode
            // 
            this.txt_getCode.Location = new System.Drawing.Point(119, 28);
            this.txt_getCode.Name = "txt_getCode";
            this.txt_getCode.Size = new System.Drawing.Size(258, 22);
            this.txt_getCode.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(12, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Get Code";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(420, 190);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.Btn_Close);
            this.Controls.Add(this.PB_Image);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Login_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.PB_Image)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Username)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Password)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PB_Image;
        private System.Windows.Forms.Button Btn_Close;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label Lab_version;
        private System.Windows.Forms.Label Lab_InvalidLogin;
        private System.Windows.Forms.Label Lab_InvaldActivation;
        private System.Windows.Forms.TextBox txt_userName;
        private System.Windows.Forms.Button Btn_Login;
        private System.Windows.Forms.PictureBox PB_Username;
        private System.Windows.Forms.PictureBox PB_Password;
        private System.Windows.Forms.TextBox txt_password;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_daycode;
        private System.Windows.Forms.Button btn_Activation;
        private System.Windows.Forms.TextBox txt_activation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_getCode;
        private System.Windows.Forms.Label label2;
    }
}