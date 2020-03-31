namespace PappyjoeMVC.View
{
    partial class AutomaticId_generation
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AutomaticId_generation));
            this.label19 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.chk_ip_patient = new System.Windows.Forms.CheckBox();
            this.button_save = new System.Windows.Forms.Button();
            this.check_patient = new System.Windows.Forms.CheckBox();
            this.text_prefix = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.text_number = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label17 = new System.Windows.Forms.Label();
            this.button_invoice_save = new System.Windows.Forms.Button();
            this.check_invoice = new System.Windows.Forms.CheckBox();
            this.text_invoice_prefix = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.text_invoice_number = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label18 = new System.Windows.Forms.Label();
            this.button_receipt_save = new System.Windows.Forms.Button();
            this.check_receipt = new System.Windows.Forms.CheckBox();
            this.text_receipt_prefix = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.text_receipt_number = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Underline);
            this.label19.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label19.Location = new System.Drawing.Point(16, 8);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(220, 25);
            this.label19.TabIndex = 125;
            this.label19.Text = "Automatic ID Generation";
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(11, 60);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1012, 511);
            this.tabControl1.TabIndex = 126;
            this.tabControl1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControl1_DrawItem);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.chk_ip_patient);
            this.tabPage1.Controls.Add(this.button_save);
            this.tabPage1.Controls.Add(this.check_patient);
            this.tabPage1.Controls.Add(this.text_prefix);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label16);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.text_number);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1004, 482);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Patient ";
            // 
            // chk_ip_patient
            // 
            this.chk_ip_patient.AutoSize = true;
            this.chk_ip_patient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_ip_patient.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_ip_patient.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.chk_ip_patient.Location = new System.Drawing.Point(11, 88);
            this.chk_ip_patient.Name = "chk_ip_patient";
            this.chk_ip_patient.Size = new System.Drawing.Size(77, 21);
            this.chk_ip_patient.TabIndex = 5;
            this.chk_ip_patient.Text = "IP Patient";
            this.chk_ip_patient.UseVisualStyleBackColor = true;
            this.chk_ip_patient.Click += new System.EventHandler(this.chk_ip_patient_Click);
            // 
            // button_save
            // 
            this.button_save.BackColor = System.Drawing.Color.LimeGreen;
            this.button_save.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_save.ForeColor = System.Drawing.Color.White;
            this.button_save.Location = new System.Drawing.Point(165, 184);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(75, 28);
            this.button_save.TabIndex = 4;
            this.button_save.Text = "Save";
            this.button_save.UseVisualStyleBackColor = false;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // check_patient
            // 
            this.check_patient.AutoSize = true;
            this.check_patient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.check_patient.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.check_patient.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.check_patient.Location = new System.Drawing.Point(495, 154);
            this.check_patient.Name = "check_patient";
            this.check_patient.Size = new System.Drawing.Size(212, 21);
            this.check_patient.TabIndex = 3;
            this.check_patient.Text = "Generate Patient number for me";
            this.check_patient.UseVisualStyleBackColor = true;
            // 
            // text_prefix
            // 
            this.text_prefix.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.text_prefix.Location = new System.Drawing.Point(165, 152);
            this.text_prefix.Name = "text_prefix";
            this.text_prefix.Size = new System.Drawing.Size(165, 22);
            this.text_prefix.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label3.Location = new System.Drawing.Point(162, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(191, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Patient Number Prefix(optional)";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.Red;
            this.label16.Location = new System.Drawing.Point(459, 126);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(12, 13);
            this.label16.TabIndex = 1;
            this.label16.Text = "*";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(361, 177);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Can\'t be null";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label4.Location = new System.Drawing.Point(369, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "Numeric Only";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label2.Location = new System.Drawing.Point(15, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Initial Patient Number";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label1.Location = new System.Drawing.Point(15, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(592, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "You need to select an Initial Value. You can choose an alphanumeric prefix (will " +
    "not be incremented), \r\nand a numeric part which will be automatically incremente" +
    "d for every new Bill.";
            // 
            // text_number
            // 
            this.text_number.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.text_number.Location = new System.Drawing.Point(364, 152);
            this.text_number.Name = "text_number";
            this.text_number.Size = new System.Drawing.Size(102, 22);
            this.text_number.TabIndex = 2;
            this.text_number.TextChanged += new System.EventHandler(this.text_number_TextChanged);
            this.text_number.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.text_number_KeyPress);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.White;
            this.tabPage2.Controls.Add(this.label17);
            this.tabPage2.Controls.Add(this.button_invoice_save);
            this.tabPage2.Controls.Add(this.check_invoice);
            this.tabPage2.Controls.Add(this.text_invoice_prefix);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.text_invoice_number);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1004, 482);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Invoice ";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.Color.Red;
            this.label17.Location = new System.Drawing.Point(449, 84);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(12, 13);
            this.label17.TabIndex = 14;
            this.label17.Text = "*";
            // 
            // button_invoice_save
            // 
            this.button_invoice_save.BackColor = System.Drawing.Color.LimeGreen;
            this.button_invoice_save.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_invoice_save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_invoice_save.ForeColor = System.Drawing.Color.White;
            this.button_invoice_save.Location = new System.Drawing.Point(165, 138);
            this.button_invoice_save.Name = "button_invoice_save";
            this.button_invoice_save.Size = new System.Drawing.Size(75, 28);
            this.button_invoice_save.TabIndex = 13;
            this.button_invoice_save.Text = "Save";
            this.button_invoice_save.UseVisualStyleBackColor = false;
            this.button_invoice_save.Click += new System.EventHandler(this.button_invoice_save_Click);
            // 
            // check_invoice
            // 
            this.check_invoice.AutoSize = true;
            this.check_invoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.check_invoice.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.check_invoice.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.check_invoice.Location = new System.Drawing.Point(495, 113);
            this.check_invoice.Name = "check_invoice";
            this.check_invoice.Size = new System.Drawing.Size(213, 21);
            this.check_invoice.TabIndex = 12;
            this.check_invoice.Text = "Generate Invoice number for me";
            this.check_invoice.UseVisualStyleBackColor = true;
            // 
            // text_invoice_prefix
            // 
            this.text_invoice_prefix.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.text_invoice_prefix.Location = new System.Drawing.Point(165, 108);
            this.text_invoice_prefix.Name = "text_invoice_prefix";
            this.text_invoice_prefix.Size = new System.Drawing.Size(165, 22);
            this.text_invoice_prefix.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label6.Location = new System.Drawing.Point(162, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(192, 17);
            this.label6.TabIndex = 6;
            this.label6.Text = "Invoice Number Prefix(optional)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(361, 133);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Can\'t be null";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label8.Location = new System.Drawing.Point(361, 80);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 17);
            this.label8.TabIndex = 7;
            this.label8.Text = "Numeric Only";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label9.Location = new System.Drawing.Point(15, 111);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(134, 17);
            this.label9.TabIndex = 9;
            this.label9.Text = "Initial Invoice Number";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label10.Location = new System.Drawing.Point(15, 25);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(592, 34);
            this.label10.TabIndex = 5;
            this.label10.Text = "You need to select an Initial Value. You can choose an alphanumeric prefix (will " +
    "not be incremented), \r\nand a numeric part which will be automatically incremente" +
    "d for every new Bill.";
            // 
            // text_invoice_number
            // 
            this.text_invoice_number.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.text_invoice_number.Location = new System.Drawing.Point(364, 108);
            this.text_invoice_number.Name = "text_invoice_number";
            this.text_invoice_number.Size = new System.Drawing.Size(102, 22);
            this.text_invoice_number.TabIndex = 11;
            this.text_invoice_number.TextChanged += new System.EventHandler(this.text_invoice_number_TextChanged);
            this.text_invoice_number.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.text_invoice_number_KeyPress);
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.White;
            this.tabPage3.Controls.Add(this.label18);
            this.tabPage3.Controls.Add(this.button_receipt_save);
            this.tabPage3.Controls.Add(this.check_receipt);
            this.tabPage3.Controls.Add(this.text_receipt_prefix);
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Controls.Add(this.label12);
            this.tabPage3.Controls.Add(this.label13);
            this.tabPage3.Controls.Add(this.label14);
            this.tabPage3.Controls.Add(this.label15);
            this.tabPage3.Controls.Add(this.text_receipt_number);
            this.tabPage3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1004, 482);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Receipt";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.Color.Red;
            this.label18.Location = new System.Drawing.Point(448, 83);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(12, 13);
            this.label18.TabIndex = 23;
            this.label18.Text = "*";
            // 
            // button_receipt_save
            // 
            this.button_receipt_save.BackColor = System.Drawing.Color.LimeGreen;
            this.button_receipt_save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_receipt_save.ForeColor = System.Drawing.Color.White;
            this.button_receipt_save.Location = new System.Drawing.Point(165, 146);
            this.button_receipt_save.Name = "button_receipt_save";
            this.button_receipt_save.Size = new System.Drawing.Size(75, 28);
            this.button_receipt_save.TabIndex = 22;
            this.button_receipt_save.Text = "Save";
            this.button_receipt_save.UseVisualStyleBackColor = false;
            this.button_receipt_save.Click += new System.EventHandler(this.button_receipt_save_Click);
            // 
            // check_receipt
            // 
            this.check_receipt.AutoSize = true;
            this.check_receipt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.check_receipt.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.check_receipt.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.check_receipt.Location = new System.Drawing.Point(484, 109);
            this.check_receipt.Name = "check_receipt";
            this.check_receipt.Size = new System.Drawing.Size(216, 21);
            this.check_receipt.TabIndex = 21;
            this.check_receipt.Text = "Generate Receipt number for me";
            this.check_receipt.UseVisualStyleBackColor = true;
            // 
            // text_receipt_prefix
            // 
            this.text_receipt_prefix.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.text_receipt_prefix.Location = new System.Drawing.Point(165, 108);
            this.text_receipt_prefix.Name = "text_receipt_prefix";
            this.text_receipt_prefix.Size = new System.Drawing.Size(165, 22);
            this.text_receipt_prefix.TabIndex = 19;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label11.Location = new System.Drawing.Point(162, 80);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(195, 17);
            this.label11.TabIndex = 15;
            this.label11.Text = "Receipt Number Prefix(optional)";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(361, 133);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(73, 13);
            this.label12.TabIndex = 17;
            this.label12.Text = "Can\'t be null";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label13.Location = new System.Drawing.Point(361, 80);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(87, 17);
            this.label13.TabIndex = 16;
            this.label13.Text = "Numeric Only";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label14.Location = new System.Drawing.Point(15, 111);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(137, 17);
            this.label14.TabIndex = 18;
            this.label14.Text = "Initial Receipt Number";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label15.Location = new System.Drawing.Point(15, 25);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(592, 34);
            this.label15.TabIndex = 14;
            this.label15.Text = "You need to select an Initial Value. You can choose an alphanumeric prefix (will " +
    "not be incremented), \r\nand a numeric part which will be automatically incremente" +
    "d for every new Bill.";
            // 
            // text_receipt_number
            // 
            this.text_receipt_number.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.text_receipt_number.Location = new System.Drawing.Point(364, 108);
            this.text_receipt_number.Name = "text_receipt_number";
            this.text_receipt_number.Size = new System.Drawing.Size(102, 22);
            this.text_receipt_number.TabIndex = 20;
            this.text_receipt_number.TextChanged += new System.EventHandler(this.text_receipt_number_TextChanged);
            this.text_receipt_number.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.text_receipt_number_KeyPress);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // AutomaticId_generation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1092, 583);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label19);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AutomaticId_generation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Automatic Id Generation";
            this.Load += new System.EventHandler(this.AutomaticId_generation_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.CheckBox check_patient;
        private System.Windows.Forms.TextBox text_prefix;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox text_number;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button button_invoice_save;
        private System.Windows.Forms.CheckBox check_invoice;
        private System.Windows.Forms.TextBox text_invoice_prefix;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox text_invoice_number;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button button_receipt_save;
        private System.Windows.Forms.CheckBox check_receipt;
        private System.Windows.Forms.TextBox text_receipt_prefix;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox text_receipt_number;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.CheckBox chk_ip_patient;
    }
}