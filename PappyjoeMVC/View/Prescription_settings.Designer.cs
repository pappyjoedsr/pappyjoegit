namespace PappyjoeMVC.View
{
    partial class Prescription_Settings
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Prescription_Settings));
            this.button_addunit = new System.Windows.Forms.Button();
            this.label39 = new System.Windows.Forms.Label();
            this.txtitemname = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.text_strength = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.combo_unit = new System.Windows.Forms.ComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.rich_instruction = new System.Windows.Forms.RichTextBox();
            this.button_cancel = new System.Windows.Forms.Button();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.button_save = new System.Windows.Forms.Button();
            this.label30 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.combotype = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.text_unit = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_addtype = new System.Windows.Forms.Button();
            this.text_type = new System.Windows.Forms.TextBox();
            this.text_presc_search = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView_prescription = new System.Windows.Forms.DataGridView();
            this.pid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pgeneric = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ptype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pstrength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.punit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pinstruction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inventory_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.edit = new System.Windows.Forms.DataGridViewImageColumn();
            this.delete = new System.Windows.Forms.DataGridViewImageColumn();
            this.button_invetory = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label34 = new System.Windows.Forms.Label();
            this.btn_import = new System.Windows.Forms.Button();
            this.lb_generic = new System.Windows.Forms.Label();
            this.txt_generic = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_prescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // button_addunit
            // 
            this.button_addunit.AutoSize = true;
            this.button_addunit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_addunit.FlatAppearance.BorderSize = 0;
            this.button_addunit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_addunit.ForeColor = System.Drawing.Color.DodgerBlue;
            this.button_addunit.Location = new System.Drawing.Point(284, 148);
            this.button_addunit.Name = "button_addunit";
            this.button_addunit.Size = new System.Drawing.Size(83, 23);
            this.button_addunit.TabIndex = 127;
            this.button_addunit.Text = "Add New Unit";
            this.button_addunit.UseVisualStyleBackColor = false;
            this.button_addunit.Click += new System.EventHandler(this.button_addunit_Click);
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.ForeColor = System.Drawing.Color.Red;
            this.label39.Location = new System.Drawing.Point(286, 109);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(86, 13);
            this.label39.TabIndex = 136;
            this.label39.Text = "It can\'t be Empty";
            // 
            // txtitemname
            // 
            this.txtitemname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtitemname.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
            this.txtitemname.BackColor = System.Drawing.Color.White;
            this.txtitemname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtitemname.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtitemname.Location = new System.Drawing.Point(111, 50);
            this.txtitemname.Name = "txtitemname";
            this.txtitemname.Size = new System.Drawing.Size(164, 22);
            this.txtitemname.TabIndex = 1;
            this.txtitemname.TextChanged += new System.EventHandler(this.txtitemname_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label4.Location = new System.Drawing.Point(16, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 25);
            this.label4.TabIndex = 143;
            this.label4.Text = "Prescription";
            // 
            // text_strength
            // 
            this.text_strength.BackColor = System.Drawing.Color.White;
            this.text_strength.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.text_strength.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_strength.Location = new System.Drawing.Point(110, 148);
            this.text_strength.Name = "text_strength";
            this.text_strength.Size = new System.Drawing.Size(77, 22);
            this.text_strength.TabIndex = 12;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label19.Location = new System.Drawing.Point(60, 117);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(36, 17);
            this.label19.TabIndex = 132;
            this.label19.Text = "Type";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label22.Location = new System.Drawing.Point(38, 151);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(57, 17);
            this.label22.TabIndex = 133;
            this.label22.Text = "Strength";
            // 
            // combo_unit
            // 
            this.combo_unit.BackColor = System.Drawing.Color.White;
            this.combo_unit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.combo_unit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_unit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combo_unit.FormattingEnabled = true;
            this.combo_unit.Location = new System.Drawing.Point(194, 148);
            this.combo_unit.Name = "combo_unit";
            this.combo_unit.Size = new System.Drawing.Size(81, 23);
            this.combo_unit.TabIndex = 135;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label23.Location = new System.Drawing.Point(21, 188);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(74, 17);
            this.label23.TabIndex = 134;
            this.label23.Text = "Instructions";
            // 
            // rich_instruction
            // 
            this.rich_instruction.BackColor = System.Drawing.Color.White;
            this.rich_instruction.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rich_instruction.Location = new System.Drawing.Point(111, 181);
            this.rich_instruction.Name = "rich_instruction";
            this.rich_instruction.Size = new System.Drawing.Size(164, 28);
            this.rich_instruction.TabIndex = 128;
            this.rich_instruction.Text = "";
            // 
            // button_cancel
            // 
            this.button_cancel.BackColor = System.Drawing.Color.Tomato;
            this.button_cancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_cancel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button_cancel.Location = new System.Drawing.Point(212, 214);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(63, 25);
            this.button_cancel.TabIndex = 130;
            this.button_cancel.Text = " Cancel";
            this.button_cancel.UseVisualStyleBackColor = false;
            this.button_cancel.Visible = false;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.LinkColor = System.Drawing.Color.Red;
            this.linkLabel2.Location = new System.Drawing.Point(377, 121);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(33, 13);
            this.linkLabel2.TabIndex = 137;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Close";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // button_save
            // 
            this.button_save.BackColor = System.Drawing.Color.LimeGreen;
            this.button_save.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_save.ForeColor = System.Drawing.Color.White;
            this.button_save.Location = new System.Drawing.Point(151, 214);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(60, 25);
            this.button_save.TabIndex = 129;
            this.button_save.Text = "Save";
            this.button_save.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.button_save.UseVisualStyleBackColor = false;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.ForeColor = System.Drawing.Color.Red;
            this.label30.Location = new System.Drawing.Point(291, 55);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(121, 13);
            this.label30.TabIndex = 142;
            this.label30.Text = "Please Enter Item Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(92, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 18);
            this.label2.TabIndex = 140;
            this.label2.Text = "*";
            // 
            // combotype
            // 
            this.combotype.BackColor = System.Drawing.Color.White;
            this.combotype.Cursor = System.Windows.Forms.Cursors.Hand;
            this.combotype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combotype.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combotype.FormattingEnabled = true;
            this.combotype.Location = new System.Drawing.Point(111, 114);
            this.combotype.Name = "combotype";
            this.combotype.Size = new System.Drawing.Size(164, 23);
            this.combotype.TabIndex = 123;
            this.combotype.SelectedIndexChanged += new System.EventHandler(this.combotype_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(90, 55);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(14, 18);
            this.label12.TabIndex = 141;
            this.label12.Text = "*";
            // 
            // linkLabel3
            // 
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.LinkColor = System.Drawing.Color.Red;
            this.linkLabel3.Location = new System.Drawing.Point(377, 153);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(33, 13);
            this.linkLabel3.TabIndex = 138;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "Close";
            this.linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel3_LinkClicked);
            // 
            // text_unit
            // 
            this.text_unit.BackColor = System.Drawing.Color.White;
            this.text_unit.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_unit.Location = new System.Drawing.Point(196, 148);
            this.text_unit.Name = "text_unit";
            this.text_unit.Size = new System.Drawing.Size(79, 22);
            this.text_unit.TabIndex = 126;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label1.Location = new System.Drawing.Point(19, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 17);
            this.label1.TabIndex = 139;
            this.label1.Text = "Item Name ";
            // 
            // button_addtype
            // 
            this.button_addtype.AutoSize = true;
            this.button_addtype.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button_addtype.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_addtype.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.button_addtype.FlatAppearance.BorderSize = 0;
            this.button_addtype.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_addtype.ForeColor = System.Drawing.Color.DodgerBlue;
            this.button_addtype.Location = new System.Drawing.Point(284, 116);
            this.button_addtype.Name = "button_addtype";
            this.button_addtype.Size = new System.Drawing.Size(88, 23);
            this.button_addtype.TabIndex = 124;
            this.button_addtype.Text = "Add New Type";
            this.button_addtype.UseVisualStyleBackColor = false;
            this.button_addtype.Click += new System.EventHandler(this.button_addtype_Click);
            // 
            // text_type
            // 
            this.text_type.BackColor = System.Drawing.Color.White;
            this.text_type.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.text_type.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_type.Location = new System.Drawing.Point(111, 115);
            this.text_type.Name = "text_type";
            this.text_type.Size = new System.Drawing.Size(164, 20);
            this.text_type.TabIndex = 131;
            // 
            // text_presc_search
            // 
            this.text_presc_search.BackColor = System.Drawing.Color.White;
            this.text_presc_search.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.text_presc_search.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.text_presc_search.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_presc_search.Location = new System.Drawing.Point(111, 248);
            this.text_presc_search.Name = "text_presc_search";
            this.text_presc_search.Size = new System.Drawing.Size(338, 22);
            this.text_presc_search.TabIndex = 145;
            this.text_presc_search.KeyUp += new System.Windows.Forms.KeyEventHandler(this.text_presc_search_KeyUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label3.Location = new System.Drawing.Point(48, 251);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 17);
            this.label3.TabIndex = 148;
            this.label3.Text = "Search";
            // 
            // dataGridView_prescription
            // 
            this.dataGridView_prescription.AllowUserToAddRows = false;
            this.dataGridView_prescription.AllowUserToDeleteRows = false;
            this.dataGridView_prescription.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dataGridView_prescription.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_prescription.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView_prescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView_prescription.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView_prescription.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_prescription.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView_prescription.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView_prescription.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pid,
            this.pname,
            this.pgeneric,
            this.ptype,
            this.pstrength,
            this.punit,
            this.pinstruction,
            this.Column7,
            this.inventory_id,
            this.edit,
            this.delete});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_prescription.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView_prescription.Location = new System.Drawing.Point(51, 283);
            this.dataGridView_prescription.MultiSelect = false;
            this.dataGridView_prescription.Name = "dataGridView_prescription";
            this.dataGridView_prescription.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_prescription.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView_prescription.RowHeadersVisible = false;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView_prescription.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView_prescription.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_prescription.Size = new System.Drawing.Size(964, 371);
            this.dataGridView_prescription.TabIndex = 144;
            this.dataGridView_prescription.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_prescription_CellClick);
            // 
            // pid
            // 
            this.pid.DataPropertyName = "id";
            this.pid.HeaderText = "id";
            this.pid.Name = "pid";
            this.pid.ReadOnly = true;
            this.pid.Visible = false;
            // 
            // pname
            // 
            this.pname.DataPropertyName = "name";
            this.pname.FillWeight = 335.6079F;
            this.pname.HeaderText = "Name";
            this.pname.Name = "pname";
            this.pname.ReadOnly = true;
            this.pname.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.pname.Width = 203;
            // 
            // pgeneric
            // 
            this.pgeneric.DataPropertyName = "generic";
            this.pgeneric.HeaderText = "Generic";
            this.pgeneric.Name = "pgeneric";
            this.pgeneric.ReadOnly = true;
            this.pgeneric.Width = 150;
            // 
            // ptype
            // 
            this.ptype.DataPropertyName = "type";
            this.ptype.FillWeight = 34.71603F;
            this.ptype.HeaderText = "Type";
            this.ptype.Name = "ptype";
            this.ptype.ReadOnly = true;
            // 
            // pstrength
            // 
            this.pstrength.DataPropertyName = "strength";
            this.pstrength.FillWeight = 44.70412F;
            this.pstrength.HeaderText = "Strength";
            this.pstrength.Name = "pstrength";
            this.pstrength.ReadOnly = true;
            // 
            // punit
            // 
            this.punit.DataPropertyName = "strength_gr";
            this.punit.FillWeight = 31.64933F;
            this.punit.HeaderText = "Unit";
            this.punit.Name = "punit";
            this.punit.ReadOnly = true;
            // 
            // pinstruction
            // 
            this.pinstruction.DataPropertyName = "instructions";
            this.pinstruction.FillWeight = 53.32259F;
            this.pinstruction.HeaderText = "Instructions";
            this.pinstruction.Name = "pinstruction";
            this.pinstruction.ReadOnly = true;
            this.pinstruction.Width = 250;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "display_status";
            this.Column7.HeaderText = "Display Status";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Visible = false;
            // 
            // inventory_id
            // 
            this.inventory_id.DataPropertyName = "inventory_id";
            this.inventory_id.HeaderText = "inventory_id";
            this.inventory_id.Name = "inventory_id";
            this.inventory_id.ReadOnly = true;
            this.inventory_id.Visible = false;
            // 
            // edit
            // 
            this.edit.HeaderText = "";
            this.edit.Image = global::PappyjoeMVC.Properties.Resources.editicon;
            this.edit.Name = "edit";
            this.edit.ReadOnly = true;
            this.edit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.edit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.edit.Width = 19;
            // 
            // delete
            // 
            this.delete.HeaderText = "";
            this.delete.Image = global::PappyjoeMVC.Properties.Resources.deleteicon;
            this.delete.Name = "delete";
            this.delete.ReadOnly = true;
            this.delete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.delete.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.delete.Width = 19;
            // 
            // button_invetory
            // 
            this.button_invetory.AutoSize = true;
            this.button_invetory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button_invetory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_invetory.FlatAppearance.BorderSize = 0;
            this.button_invetory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_invetory.ForeColor = System.Drawing.Color.DodgerBlue;
            this.button_invetory.Location = new System.Drawing.Point(865, 23);
            this.button_invetory.Name = "button_invetory";
            this.button_invetory.Size = new System.Drawing.Size(244, 23);
            this.button_invetory.TabIndex = 150;
            this.button_invetory.Text = "Add same product in Inventory part..? Click here";
            this.button_invetory.UseVisualStyleBackColor = false;
            this.button_invetory.Visible = false;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.ForeColor = System.Drawing.Color.Red;
            this.label34.Location = new System.Drawing.Point(503, 55);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(86, 13);
            this.label34.TabIndex = 151;
            this.label34.Text = "It can\'t be Empty";
            // 
            // btn_import
            // 
            this.btn_import.BackColor = System.Drawing.Color.DimGray;
            this.btn_import.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_import.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_import.ForeColor = System.Drawing.Color.White;
            this.btn_import.Location = new System.Drawing.Point(744, 19);
            this.btn_import.Name = "btn_import";
            this.btn_import.Size = new System.Drawing.Size(115, 27);
            this.btn_import.TabIndex = 152;
            this.btn_import.Text = "Import from Excel";
            this.btn_import.UseVisualStyleBackColor = false;
            this.btn_import.Click += new System.EventHandler(this.btn_import_Click);
            // 
            // lb_generic
            // 
            this.lb_generic.AutoSize = true;
            this.lb_generic.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_generic.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lb_generic.Location = new System.Drawing.Point(4, 85);
            this.lb_generic.Name = "lb_generic";
            this.lb_generic.Size = new System.Drawing.Size(91, 17);
            this.lb_generic.TabIndex = 153;
            this.lb_generic.Text = "Generic Name";
            // 
            // txt_generic
            // 
            this.txt_generic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_generic.Location = new System.Drawing.Point(110, 83);
            this.txt_generic.Name = "txt_generic";
            this.txt_generic.Size = new System.Drawing.Size(164, 20);
            this.txt_generic.TabIndex = 154;
            // 
            // Prescription_Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1146, 698);
            this.Controls.Add(this.txt_generic);
            this.Controls.Add(this.lb_generic);
            this.Controls.Add(this.btn_import);
            this.Controls.Add(this.label34);
            this.Controls.Add(this.text_presc_search);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridView_prescription);
            this.Controls.Add(this.button_invetory);
            this.Controls.Add(this.button_addunit);
            this.Controls.Add(this.label39);
            this.Controls.Add(this.txtitemname);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.text_strength);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.combo_unit);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.rich_instruction);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.combotype);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.linkLabel3);
            this.Controls.Add(this.text_unit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_addtype);
            this.Controls.Add(this.text_type);
            this.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Prescription_Settings";
            this.Text = "Prescription Settings";
            this.Load += new System.EventHandler(this.Prescription_settings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_prescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_addunit;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.TextBox txtitemname;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox text_strength;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.ComboBox combo_unit;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.RichTextBox rich_instruction;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox combotype;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.LinkLabel linkLabel3;
        private System.Windows.Forms.TextBox text_unit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_addtype;
        private System.Windows.Forms.TextBox text_type;
        private System.Windows.Forms.TextBox text_presc_search;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView_prescription;
        private System.Windows.Forms.Button button_invetory;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Button btn_import;
        private System.Windows.Forms.DataGridViewTextBoxColumn pid;
        private System.Windows.Forms.DataGridViewTextBoxColumn pname;
        private System.Windows.Forms.DataGridViewTextBoxColumn pgeneric;
        private System.Windows.Forms.DataGridViewTextBoxColumn ptype;
        private System.Windows.Forms.DataGridViewTextBoxColumn pstrength;
        private System.Windows.Forms.DataGridViewTextBoxColumn punit;
        private System.Windows.Forms.DataGridViewTextBoxColumn pinstruction;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn inventory_id;
        private System.Windows.Forms.DataGridViewImageColumn edit;
        private System.Windows.Forms.DataGridViewImageColumn delete;
        private System.Windows.Forms.TextBox txt_generic;
        private System.Windows.Forms.Label lb_generic;
    }
}