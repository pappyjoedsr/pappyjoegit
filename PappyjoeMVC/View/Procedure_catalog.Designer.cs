﻿namespace PappyjoeMVC.View
{
    partial class Procedure_Catalog
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Procedure_Catalog));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_import = new System.Windows.Forms.Button();
            this.Dgv_Procedure = new System.Windows.Forms.DataGridView();
            this.proid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.procedurename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.notes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_edit = new System.Windows.Forms.DataGridViewImageColumn();
            this.delete = new System.Windows.Forms.DataGridViewImageColumn();
            this.textsearch = new System.Windows.Forms.TextBox();
            this.buttonrefresh = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonclear = new System.Windows.Forms.Button();
            this.buttonsave = new System.Windows.Forms.Button();
            this.buttonSaveCategory = new System.Windows.Forms.Button();
            this.btnAddNewCategory = new System.Windows.Forms.Button();
            this.txt_AddCategory = new System.Windows.Forms.TextBox();
            this.comboaddunder = new System.Windows.Forms.ComboBox();
            this.checkaddunder = new System.Windows.Forms.CheckBox();
            this.chk_gst = new System.Windows.Forms.CheckBox();
            this.chk_igst = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_procedurename = new System.Windows.Forms.TextBox();
            this.txt_procedurecost = new System.Windows.Forms.TextBox();
            this.lab_ProCost = new System.Windows.Forms.Label();
            this.richnotes = new System.Windows.Forms.RichTextBox();
            this.lab_Pro_nameError = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Procedure)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_import);
            this.panel1.Controls.Add(this.Dgv_Procedure);
            this.panel1.Controls.Add(this.textsearch);
            this.panel1.Controls.Add(this.buttonrefresh);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.buttonclear);
            this.panel1.Controls.Add(this.buttonsave);
            this.panel1.Controls.Add(this.buttonSaveCategory);
            this.panel1.Controls.Add(this.btnAddNewCategory);
            this.panel1.Controls.Add(this.txt_AddCategory);
            this.panel1.Controls.Add(this.comboaddunder);
            this.panel1.Controls.Add(this.checkaddunder);
            this.panel1.Controls.Add(this.chk_gst);
            this.panel1.Controls.Add(this.chk_igst);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txt_procedurename);
            this.panel1.Controls.Add(this.txt_procedurecost);
            this.panel1.Controls.Add(this.lab_ProCost);
            this.panel1.Controls.Add(this.richnotes);
            this.panel1.Controls.Add(this.lab_Pro_nameError);
            this.panel1.Controls.Add(this.label19);
            this.panel1.Location = new System.Drawing.Point(2, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1335, 652);
            this.panel1.TabIndex = 0;
            // 
            // btn_import
            // 
            this.btn_import.BackColor = System.Drawing.Color.DimGray;
            this.btn_import.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_import.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_import.ForeColor = System.Drawing.Color.White;
            this.btn_import.Location = new System.Drawing.Point(941, 11);
            this.btn_import.Name = "btn_import";
            this.btn_import.Size = new System.Drawing.Size(115, 25);
            this.btn_import.TabIndex = 150;
            this.btn_import.Text = "Import from Excel";
            this.btn_import.UseVisualStyleBackColor = false;
            this.btn_import.Click += new System.EventHandler(this.btn_import_Click);
            // 
            // Dgv_Procedure
            // 
            this.Dgv_Procedure.AllowUserToAddRows = false;
            this.Dgv_Procedure.AllowUserToResizeColumns = false;
            this.Dgv_Procedure.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.Dgv_Procedure.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.Dgv_Procedure.BackgroundColor = System.Drawing.Color.White;
            this.Dgv_Procedure.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Dgv_Procedure.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.Dgv_Procedure.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Dgv_Procedure.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.Dgv_Procedure.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.Dgv_Procedure.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.proid,
            this.procedurename,
            this.cost,
            this.tax,
            this.notes,
            this.category,
            this.col_edit,
            this.delete});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle4.NullValue = null;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Dgv_Procedure.DefaultCellStyle = dataGridViewCellStyle4;
            this.Dgv_Procedure.Location = new System.Drawing.Point(27, 360);
            this.Dgv_Procedure.MultiSelect = false;
            this.Dgv_Procedure.Name = "Dgv_Procedure";
            this.Dgv_Procedure.ReadOnly = true;
            this.Dgv_Procedure.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Dgv_Procedure.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.Dgv_Procedure.RowHeadersVisible = false;
            this.Dgv_Procedure.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            this.Dgv_Procedure.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.Dgv_Procedure.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Dgv_Procedure.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv_Procedure.Size = new System.Drawing.Size(822, 279);
            this.Dgv_Procedure.TabIndex = 149;
            this.Dgv_Procedure.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_Procedure_CellClick);
            // 
            // proid
            // 
            this.proid.DataPropertyName = "id";
            this.proid.HeaderText = "Procedureid";
            this.proid.Name = "proid";
            this.proid.ReadOnly = true;
            this.proid.Visible = false;
            // 
            // procedurename
            // 
            this.procedurename.DataPropertyName = "category";
            this.procedurename.HeaderText = "Procedure Name";
            this.procedurename.Name = "procedurename";
            this.procedurename.ReadOnly = true;
            this.procedurename.Width = 219;
            // 
            // cost
            // 
            this.cost.DataPropertyName = "cost";
            this.cost.HeaderText = "Procedure Cost";
            this.cost.Name = "cost";
            this.cost.ReadOnly = true;
            this.cost.Width = 150;
            // 
            // tax
            // 
            this.tax.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.tax.DataPropertyName = "name";
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            this.tax.DefaultCellStyle = dataGridViewCellStyle3;
            this.tax.HeaderText = "Tax";
            this.tax.Name = "tax";
            this.tax.ReadOnly = true;
            // 
            // notes
            // 
            this.notes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.notes.DataPropertyName = "notes";
            this.notes.HeaderText = "Notes";
            this.notes.Name = "notes";
            this.notes.ReadOnly = true;
            this.notes.Width = 150;
            // 
            // category
            // 
            this.category.DataPropertyName = "tax_name";
            this.category.HeaderText = "Category";
            this.category.Name = "category";
            this.category.ReadOnly = true;
            this.category.Width = 150;
            // 
            // col_edit
            // 
            this.col_edit.HeaderText = "";
            this.col_edit.Image = global::PappyjoeMVC.Properties.Resources.editicon;
            this.col_edit.Name = "col_edit";
            this.col_edit.ReadOnly = true;
            this.col_edit.Width = 30;
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
            // textsearch
            // 
            this.textsearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textsearch.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.textsearch.Location = new System.Drawing.Point(116, 323);
            this.textsearch.Name = "textsearch";
            this.textsearch.Size = new System.Drawing.Size(287, 20);
            this.textsearch.TabIndex = 148;
            this.textsearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textsearch_KeyPress);
            this.textsearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textsearch_KeyUp);
            // 
            // buttonrefresh
            // 
            this.buttonrefresh.BackColor = System.Drawing.Color.LimeGreen;
            this.buttonrefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonrefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonrefresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonrefresh.ForeColor = System.Drawing.Color.White;
            this.buttonrefresh.Location = new System.Drawing.Point(409, 322);
            this.buttonrefresh.Name = "buttonrefresh";
            this.buttonrefresh.Size = new System.Drawing.Size(75, 22);
            this.buttonrefresh.TabIndex = 147;
            this.buttonrefresh.Text = "Refresh";
            this.buttonrefresh.UseVisualStyleBackColor = false;
            this.buttonrefresh.Click += new System.EventHandler(this.buttonrefresh_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label8.Location = new System.Drawing.Point(22, 326);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 15);
            this.label8.TabIndex = 146;
            this.label8.Text = "Search by Name";
            // 
            // buttonclear
            // 
            this.buttonclear.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.buttonclear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonclear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonclear.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonclear.ForeColor = System.Drawing.Color.White;
            this.buttonclear.Location = new System.Drawing.Point(381, 247);
            this.buttonclear.Name = "buttonclear";
            this.buttonclear.Size = new System.Drawing.Size(99, 33);
            this.buttonclear.TabIndex = 144;
            this.buttonclear.Text = "Clear All";
            this.buttonclear.UseVisualStyleBackColor = false;
            this.buttonclear.Click += new System.EventHandler(this.buttonclear_Click);
            // 
            // buttonsave
            // 
            this.buttonsave.BackColor = System.Drawing.Color.LimeGreen;
            this.buttonsave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonsave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonsave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonsave.ForeColor = System.Drawing.Color.White;
            this.buttonsave.Location = new System.Drawing.Point(245, 247);
            this.buttonsave.Name = "buttonsave";
            this.buttonsave.Size = new System.Drawing.Size(130, 33);
            this.buttonsave.TabIndex = 145;
            this.buttonsave.Text = "Save New Procedure";
            this.buttonsave.UseVisualStyleBackColor = false;
            this.buttonsave.Click += new System.EventHandler(this.buttonsave_Click);
            // 
            // buttonSaveCategory
            // 
            this.buttonSaveCategory.BackColor = System.Drawing.Color.LimeGreen;
            this.buttonSaveCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSaveCategory.ForeColor = System.Drawing.Color.White;
            this.buttonSaveCategory.Location = new System.Drawing.Point(981, 186);
            this.buttonSaveCategory.Name = "buttonSaveCategory";
            this.buttonSaveCategory.Size = new System.Drawing.Size(75, 24);
            this.buttonSaveCategory.TabIndex = 142;
            this.buttonSaveCategory.Text = "Save";
            this.buttonSaveCategory.UseVisualStyleBackColor = false;
            this.buttonSaveCategory.Click += new System.EventHandler(this.buttonSaveCategory_Click);
            // 
            // btnAddNewCategory
            // 
            this.btnAddNewCategory.BackColor = System.Drawing.Color.LimeGreen;
            this.btnAddNewCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNewCategory.ForeColor = System.Drawing.Color.White;
            this.btnAddNewCategory.Location = new System.Drawing.Point(726, 186);
            this.btnAddNewCategory.Name = "btnAddNewCategory";
            this.btnAddNewCategory.Size = new System.Drawing.Size(75, 24);
            this.btnAddNewCategory.TabIndex = 143;
            this.btnAddNewCategory.Text = "Add New";
            this.btnAddNewCategory.UseVisualStyleBackColor = false;
            this.btnAddNewCategory.Click += new System.EventHandler(this.btnAddNewCategory_Click);
            // 
            // txt_AddCategory
            // 
            this.txt_AddCategory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_AddCategory.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_AddCategory.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.txt_AddCategory.Location = new System.Drawing.Point(816, 187);
            this.txt_AddCategory.Name = "txt_AddCategory";
            this.txt_AddCategory.Size = new System.Drawing.Size(159, 23);
            this.txt_AddCategory.TabIndex = 141;
            // 
            // comboaddunder
            // 
            this.comboaddunder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboaddunder.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboaddunder.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.comboaddunder.FormattingEnabled = true;
            this.comboaddunder.Location = new System.Drawing.Point(540, 187);
            this.comboaddunder.Name = "comboaddunder";
            this.comboaddunder.Size = new System.Drawing.Size(173, 23);
            this.comboaddunder.TabIndex = 140;
            this.comboaddunder.Click += new System.EventHandler(this.comboaddunder_Click);
            // 
            // checkaddunder
            // 
            this.checkaddunder.AutoSize = true;
            this.checkaddunder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkaddunder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkaddunder.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkaddunder.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.checkaddunder.Location = new System.Drawing.Point(429, 188);
            this.checkaddunder.Name = "checkaddunder";
            this.checkaddunder.Size = new System.Drawing.Size(105, 21);
            this.checkaddunder.TabIndex = 137;
            this.checkaddunder.Text = "Add Category";
            this.checkaddunder.UseVisualStyleBackColor = true;
            this.checkaddunder.CheckedChanged += new System.EventHandler(this.checkaddunder_CheckedChanged);
            // 
            // chk_gst
            // 
            this.chk_gst.AutoSize = true;
            this.chk_gst.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chk_gst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_gst.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_gst.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.chk_gst.Location = new System.Drawing.Point(246, 188);
            this.chk_gst.Name = "chk_gst";
            this.chk_gst.Size = new System.Drawing.Size(47, 21);
            this.chk_gst.TabIndex = 138;
            this.chk_gst.Text = "GST";
            this.chk_gst.UseVisualStyleBackColor = true;
            // 
            // chk_igst
            // 
            this.chk_igst.AutoSize = true;
            this.chk_igst.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chk_igst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_igst.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_igst.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.chk_igst.Location = new System.Drawing.Point(246, 218);
            this.chk_igst.Name = "chk_igst";
            this.chk_igst.Size = new System.Drawing.Size(50, 21);
            this.chk_igst.TabIndex = 139;
            this.chk_igst.Text = "IGST";
            this.chk_igst.UseVisualStyleBackColor = true;
            this.chk_igst.CheckedChanged += new System.EventHandler(this.chk_igst_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label1.Location = new System.Drawing.Point(114, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 17);
            this.label1.TabIndex = 127;
            this.label1.Text = "Procedure Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label2.Location = new System.Drawing.Point(123, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 17);
            this.label2.TabIndex = 128;
            this.label2.Text = "Procedure Cost";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label3.Location = new System.Drawing.Point(133, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 17);
            this.label3.TabIndex = 129;
            this.label3.Text = "Default Notes";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(219, 100);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(11, 13);
            this.label10.TabIndex = 135;
            this.label10.Text = "*";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(218, 68);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(11, 13);
            this.label9.TabIndex = 136;
            this.label9.Text = "*";
            // 
            // txt_procedurename
            // 
            this.txt_procedurename.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_procedurename.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.txt_procedurename.Location = new System.Drawing.Point(246, 62);
            this.txt_procedurename.Name = "txt_procedurename";
            this.txt_procedurename.Size = new System.Drawing.Size(257, 20);
            this.txt_procedurename.TabIndex = 130;
            this.txt_procedurename.TextChanged += new System.EventHandler(this.txt_procedurename_TextChanged);
            // 
            // txt_procedurecost
            // 
            this.txt_procedurecost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_procedurecost.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.txt_procedurecost.Location = new System.Drawing.Point(246, 94);
            this.txt_procedurecost.Name = "txt_procedurecost";
            this.txt_procedurecost.Size = new System.Drawing.Size(257, 20);
            this.txt_procedurecost.TabIndex = 131;
            this.txt_procedurecost.Text = " ";
            this.txt_procedurecost.TextChanged += new System.EventHandler(this.txt_procedurecost_TextChanged);
            // 
            // lab_ProCost
            // 
            this.lab_ProCost.AutoSize = true;
            this.lab_ProCost.ForeColor = System.Drawing.Color.Red;
            this.lab_ProCost.Location = new System.Drawing.Point(508, 98);
            this.lab_ProCost.Name = "lab_ProCost";
            this.lab_ProCost.Size = new System.Drawing.Size(77, 13);
            this.lab_ProCost.TabIndex = 133;
            this.lab_ProCost.Text = "Can\'t be empty";
            this.lab_ProCost.Visible = false;
            // 
            // richnotes
            // 
            this.richnotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richnotes.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.richnotes.Location = new System.Drawing.Point(246, 127);
            this.richnotes.Name = "richnotes";
            this.richnotes.Size = new System.Drawing.Size(257, 46);
            this.richnotes.TabIndex = 132;
            this.richnotes.Text = "";
            // 
            // lab_Pro_nameError
            // 
            this.lab_Pro_nameError.AutoSize = true;
            this.lab_Pro_nameError.ForeColor = System.Drawing.Color.Red;
            this.lab_Pro_nameError.Location = new System.Drawing.Point(508, 66);
            this.lab_Pro_nameError.Name = "lab_Pro_nameError";
            this.lab_Pro_nameError.Size = new System.Drawing.Size(77, 13);
            this.lab_Pro_nameError.TabIndex = 134;
            this.lab_Pro_nameError.Text = "Can\'t be empty";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label19.Location = new System.Drawing.Point(15, 7);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(169, 25);
            this.label19.TabIndex = 126;
            this.label19.Text = "Procedure Catalog";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Procedure_Catalog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1350, 657);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Procedure_Catalog";
            this.Text = "Procedure Catalog";
            this.Load += new System.EventHandler(this.Procedure_catalog_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Procedure)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView Dgv_Procedure;
        private System.Windows.Forms.TextBox textsearch;
        private System.Windows.Forms.Button buttonrefresh;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button buttonclear;
        private System.Windows.Forms.Button buttonsave;
        private System.Windows.Forms.Button buttonSaveCategory;
        private System.Windows.Forms.Button btnAddNewCategory;
        private System.Windows.Forms.TextBox txt_AddCategory;
        private System.Windows.Forms.ComboBox comboaddunder;
        private System.Windows.Forms.CheckBox checkaddunder;
        private System.Windows.Forms.CheckBox chk_gst;
        private System.Windows.Forms.CheckBox chk_igst;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_procedurename;
        private System.Windows.Forms.TextBox txt_procedurecost;
        private System.Windows.Forms.Label lab_ProCost;
        private System.Windows.Forms.RichTextBox richnotes;
        private System.Windows.Forms.Label lab_Pro_nameError;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.DataGridViewTextBoxColumn proid;
        private System.Windows.Forms.DataGridViewTextBoxColumn procedurename;
        private System.Windows.Forms.DataGridViewTextBoxColumn cost;
        private System.Windows.Forms.DataGridViewTextBoxColumn tax;
        private System.Windows.Forms.DataGridViewTextBoxColumn notes;
        private System.Windows.Forms.DataGridViewTextBoxColumn category;
        private System.Windows.Forms.DataGridViewImageColumn col_edit;
        private System.Windows.Forms.DataGridViewImageColumn delete;
        private System.Windows.Forms.Button btn_import;
    }
}