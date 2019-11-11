namespace PappyjoeMVC.View
{
    partial class PurchaseOrder
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PurchaseOrder));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvItemData = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Item_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unit_Cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemEdit = new System.Windows.Forms.DataGridViewImageColumn();
            this.Del = new System.Windows.Forms.DataGridViewImageColumn();
            this.label22 = new System.Windows.Forms.Label();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.txtTotal_item = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_clear = new System.Windows.Forms.Button();
            this.dtpPurchDate = new System.Windows.Forms.DateTimePicker();
            this.txtPurchOrderNo = new System.Windows.Forms.TextBox();
            this.lblDocumentNumber = new System.Windows.Forms.Label();
            this.lstbox_Supplier = new System.Windows.Forms.ListBox();
            this.lblDocumentDate = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblSupplierCode = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txtSupplierName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_SupplierId = new System.Windows.Forms.TextBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.Btn_Add = new System.Windows.Forms.Button();
            this.txt_Itemcode = new System.Windows.Forms.TextBox();
            this.Btn_itemCode = new System.Windows.Forms.Button();
            this.txtUnitCost = new System.Windows.Forms.TextBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.txt_qty = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemData)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1054, 600);
            this.panel1.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.dgvItemData);
            this.panel3.Controls.Add(this.label22);
            this.panel3.Controls.Add(this.txtTotalAmount);
            this.panel3.Controls.Add(this.label24);
            this.panel3.Controls.Add(this.txtTotal_item);
            this.panel3.Location = new System.Drawing.Point(4, 239);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1047, 358);
            this.panel3.TabIndex = 280;
            // 
            // dgvItemData
            // 
            this.dgvItemData.AllowUserToAddRows = false;
            this.dgvItemData.AllowUserToDeleteRows = false;
            this.dgvItemData.AllowUserToResizeColumns = false;
            this.dgvItemData.AllowUserToResizeRows = false;
            this.dgvItemData.BackgroundColor = System.Drawing.Color.White;
            this.dgvItemData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvItemData.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvItemData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvItemData.ColumnHeadersHeight = 25;
            this.dgvItemData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvItemData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Item_Id,
            this.description,
            this.col_qty,
            this.Unit_Cost,
            this.Amount,
            this.ItemEdit,
            this.Del});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvItemData.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvItemData.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvItemData.Location = new System.Drawing.Point(0, 0);
            this.dgvItemData.Name = "dgvItemData";
            this.dgvItemData.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvItemData.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvItemData.RowHeadersVisible = false;
            this.dgvItemData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvItemData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvItemData.Size = new System.Drawing.Size(1047, 259);
            this.dgvItemData.TabIndex = 270;
            this.dgvItemData.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItemData_CellClick);
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // Item_Id
            // 
            this.Item_Id.HeaderText = "Item Id";
            this.Item_Id.Name = "Item_Id";
            this.Item_Id.ReadOnly = true;
            this.Item_Id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // description
            // 
            this.description.HeaderText = "Description";
            this.description.Name = "description";
            this.description.ReadOnly = true;
            this.description.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.description.Width = 300;
            // 
            // col_qty
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.col_qty.DefaultCellStyle = dataGridViewCellStyle2;
            this.col_qty.HeaderText = "Qty";
            this.col_qty.Name = "col_qty";
            this.col_qty.ReadOnly = true;
            this.col_qty.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col_qty.Width = 150;
            // 
            // Unit_Cost
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Unit_Cost.DefaultCellStyle = dataGridViewCellStyle3;
            this.Unit_Cost.HeaderText = "Unit Cost";
            this.Unit_Cost.Name = "Unit_Cost";
            this.Unit_Cost.ReadOnly = true;
            this.Unit_Cost.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Unit_Cost.Width = 150;
            // 
            // Amount
            // 
            this.Amount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Amount.DefaultCellStyle = dataGridViewCellStyle4;
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            this.Amount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ItemEdit
            // 
            this.ItemEdit.HeaderText = "Edit";
            this.ItemEdit.Image = global::PappyjoeMVC.Properties.Resources.editicon;
            this.ItemEdit.Name = "ItemEdit";
            this.ItemEdit.ReadOnly = true;
            this.ItemEdit.Width = 50;
            // 
            // Del
            // 
            this.Del.HeaderText = "Del";
            this.Del.Image = global::PappyjoeMVC.Properties.Resources.deleteicon;
            this.Del.Name = "Del";
            this.Del.ReadOnly = true;
            this.Del.Width = 50;
            // 
            // label22
            // 
            this.label22.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label22.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label22.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label22.Location = new System.Drawing.Point(795, 303);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(132, 22);
            this.label22.TabIndex = 272;
            this.label22.Text = "Total Amount";
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalAmount.BackColor = System.Drawing.Color.White;
            this.txtTotalAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalAmount.Enabled = false;
            this.txtTotalAmount.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.txtTotalAmount.Location = new System.Drawing.Point(936, 302);
            this.txtTotalAmount.MaxLength = 8;
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.ReadOnly = true;
            this.txtTotalAmount.Size = new System.Drawing.Size(111, 20);
            this.txtTotalAmount.TabIndex = 275;
            this.txtTotalAmount.Text = "0.00";
            this.txtTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotalAmount.TextChanged += new System.EventHandler(this.txtTotalAmount_TextChanged);
            // 
            // label24
            // 
            this.label24.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label24.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label24.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label24.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label24.Location = new System.Drawing.Point(795, 277);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(132, 22);
            this.label24.TabIndex = 273;
            this.label24.Text = "Total Items";
            // 
            // txtTotal_item
            // 
            this.txtTotal_item.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotal_item.BackColor = System.Drawing.Color.White;
            this.txtTotal_item.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotal_item.Enabled = false;
            this.txtTotal_item.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.txtTotal_item.Location = new System.Drawing.Point(936, 276);
            this.txtTotal_item.MaxLength = 8;
            this.txtTotal_item.Name = "txtTotal_item";
            this.txtTotal_item.ReadOnly = true;
            this.txtTotal_item.Size = new System.Drawing.Size(111, 20);
            this.txtTotal_item.TabIndex = 274;
            this.txtTotal_item.Text = "0";
            this.txtTotal_item.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btn_clear);
            this.panel2.Controls.Add(this.dtpPurchDate);
            this.panel2.Controls.Add(this.txtPurchOrderNo);
            this.panel2.Controls.Add(this.lblDocumentNumber);
            this.panel2.Controls.Add(this.lstbox_Supplier);
            this.panel2.Controls.Add(this.lblDocumentDate);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.lblSupplierCode);
            this.panel2.Controls.Add(this.label18);
            this.panel2.Controls.Add(this.txtSupplierName);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txt_SupplierId);
            this.panel2.Controls.Add(this.btnPrint);
            this.panel2.Controls.Add(this.BtnSave);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Location = new System.Drawing.Point(2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1048, 234);
            this.panel2.TabIndex = 279;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(815, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 18);
            this.label1.TabIndex = 308;
            this.label1.Text = "*";
            // 
            // btn_clear
            // 
            this.btn_clear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_clear.BackColor = System.Drawing.Color.Tomato;
            this.btn_clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_clear.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_clear.ForeColor = System.Drawing.Color.White;
            this.btn_clear.Location = new System.Drawing.Point(884, 5);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(77, 30);
            this.btn_clear.TabIndex = 295;
            this.btn_clear.Text = "CLEAR";
            this.btn_clear.UseVisualStyleBackColor = false;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // dtpPurchDate
            // 
            this.dtpPurchDate.CalendarFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpPurchDate.CalendarForeColor = System.Drawing.Color.DarkSlateGray;
            this.dtpPurchDate.CalendarTitleForeColor = System.Drawing.Color.DarkSlateGray;
            this.dtpPurchDate.CustomFormat = "dd-MM-yyyy";
            this.dtpPurchDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPurchDate.Location = new System.Drawing.Point(141, 97);
            this.dtpPurchDate.Name = "dtpPurchDate";
            this.dtpPurchDate.Size = new System.Drawing.Size(196, 20);
            this.dtpPurchDate.TabIndex = 97;
            // 
            // txtPurchOrderNo
            // 
            this.txtPurchOrderNo.BackColor = System.Drawing.Color.White;
            this.txtPurchOrderNo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPurchOrderNo.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPurchOrderNo.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.txtPurchOrderNo.Location = new System.Drawing.Point(140, 60);
            this.txtPurchOrderNo.MaxLength = 48;
            this.txtPurchOrderNo.Name = "txtPurchOrderNo";
            this.txtPurchOrderNo.ReadOnly = true;
            this.txtPurchOrderNo.Size = new System.Drawing.Size(154, 26);
            this.txtPurchOrderNo.TabIndex = 71;
            this.txtPurchOrderNo.Text = "12045";
            // 
            // lblDocumentNumber
            // 
            this.lblDocumentNumber.AutoSize = true;
            this.lblDocumentNumber.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDocumentNumber.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblDocumentNumber.Location = new System.Drawing.Point(10, 64);
            this.lblDocumentNumber.Name = "lblDocumentNumber";
            this.lblDocumentNumber.Size = new System.Drawing.Size(125, 17);
            this.lblDocumentNumber.TabIndex = 68;
            this.lblDocumentNumber.Text = "Purchase Order No ";
            this.lblDocumentNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lstbox_Supplier
            // 
            this.lstbox_Supplier.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lstbox_Supplier.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstbox_Supplier.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lstbox_Supplier.FormattingEnabled = true;
            this.lstbox_Supplier.Location = new System.Drawing.Point(851, 87);
            this.lstbox_Supplier.Name = "lstbox_Supplier";
            this.lstbox_Supplier.Size = new System.Drawing.Size(196, 82);
            this.lstbox_Supplier.TabIndex = 208;
            this.lstbox_Supplier.Visible = false;
            this.lstbox_Supplier.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lstbox_Supplier_MouseClick);
            // 
            // lblDocumentDate
            // 
            this.lblDocumentDate.AutoSize = true;
            this.lblDocumentDate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDocumentDate.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblDocumentDate.Location = new System.Drawing.Point(92, 97);
            this.lblDocumentDate.Name = "lblDocumentDate";
            this.lblDocumentDate.Size = new System.Drawing.Size(43, 17);
            this.lblDocumentDate.TabIndex = 69;
            this.lblDocumentDate.Text = " Date ";
            this.lblDocumentDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.DarkGray;
            this.panel4.Location = new System.Drawing.Point(-16, 43);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1063, 1);
            this.panel4.TabIndex = 294;
            // 
            // lblSupplierCode
            // 
            this.lblSupplierCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSupplierCode.AutoSize = true;
            this.lblSupplierCode.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSupplierCode.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblSupplierCode.Location = new System.Drawing.Point(744, 93);
            this.lblSupplierCode.Name = "lblSupplierCode";
            this.lblSupplierCode.Size = new System.Drawing.Size(71, 17);
            this.lblSupplierCode.TabIndex = 201;
            this.lblSupplierCode.Text = "Supplier Id";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label18.Location = new System.Drawing.Point(9, 8);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(145, 21);
            this.label18.TabIndex = 293;
            this.label18.Text = "PURCHASE ORDER";
            // 
            // txtSupplierName
            // 
            this.txtSupplierName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSupplierName.BackColor = System.Drawing.Color.White;
            this.txtSupplierName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSupplierName.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSupplierName.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.txtSupplierName.Location = new System.Drawing.Point(851, 63);
            this.txtSupplierName.Name = "txtSupplierName";
            this.txtSupplierName.Size = new System.Drawing.Size(196, 22);
            this.txtSupplierName.TabIndex = 0;
            this.txtSupplierName.Click += new System.EventHandler(this.txtSupplierName_Click);
            this.txtSupplierName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSupplierName_KeyUp);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label3.Location = new System.Drawing.Point(720, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 17);
            this.label3.TabIndex = 206;
            this.label3.Text = "Supplier Name";
            // 
            // txt_SupplierId
            // 
            this.txt_SupplierId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_SupplierId.BackColor = System.Drawing.Color.White;
            this.txt_SupplierId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_SupplierId.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_SupplierId.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.txt_SupplierId.Location = new System.Drawing.Point(851, 93);
            this.txt_SupplierId.Name = "txt_SupplierId";
            this.txt_SupplierId.ReadOnly = true;
            this.txt_SupplierId.Size = new System.Drawing.Size(196, 22);
            this.txt_SupplierId.TabIndex = 207;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.BackColor = System.Drawing.Color.LimeGreen;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Location = new System.Drawing.Point(800, 5);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(85, 30);
            this.btnPrint.TabIndex = 276;
            this.btnPrint.Text = "PRINT";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Visible = false;
            // 
            // BtnSave
            // 
            this.BtnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSave.BackColor = System.Drawing.Color.LimeGreen;
            this.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSave.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSave.ForeColor = System.Drawing.Color.White;
            this.BtnSave.Location = new System.Drawing.Point(962, 5);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(85, 30);
            this.BtnSave.TabIndex = 271;
            this.BtnSave.Text = "SAVE";
            this.BtnSave.UseVisualStyleBackColor = false;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label51);
            this.groupBox1.Controls.Add(this.Btn_Add);
            this.groupBox1.Controls.Add(this.txt_Itemcode);
            this.groupBox1.Controls.Add(this.Btn_itemCode);
            this.groupBox1.Controls.Add(this.txtUnitCost);
            this.groupBox1.Controls.Add(this.txtAmount);
            this.groupBox1.Controls.Add(this.txt_qty);
            this.groupBox1.Controls.Add(this.txtDescription);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Location = new System.Drawing.Point(5, 149);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1041, 75);
            this.groupBox1.TabIndex = 267;
            this.groupBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label4.Location = new System.Drawing.Point(9, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Item Code";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(432, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 18);
            this.label6.TabIndex = 309;
            this.label6.Text = "*";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(68, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 18);
            this.label2.TabIndex = 308;
            this.label2.Text = "*";
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label51.ForeColor = System.Drawing.Color.Red;
            this.label51.Location = new System.Drawing.Point(220, 16);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(14, 18);
            this.label51.TabIndex = 307;
            this.label51.Text = "*";
            // 
            // Btn_Add
            // 
            this.Btn_Add.BackColor = System.Drawing.Color.LimeGreen;
            this.Btn_Add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Add.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Add.ForeColor = System.Drawing.Color.White;
            this.Btn_Add.Location = new System.Drawing.Point(716, 40);
            this.Btn_Add.Name = "Btn_Add";
            this.Btn_Add.Size = new System.Drawing.Size(69, 23);
            this.Btn_Add.TabIndex = 18;
            this.Btn_Add.Text = "Add";
            this.Btn_Add.UseVisualStyleBackColor = false;
            this.Btn_Add.Click += new System.EventHandler(this.Btn_Add_Click);
            // 
            // txt_Itemcode
            // 
            this.txt_Itemcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Itemcode.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Itemcode.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.txt_Itemcode.Location = new System.Drawing.Point(9, 40);
            this.txt_Itemcode.Name = "txt_Itemcode";
            this.txt_Itemcode.Size = new System.Drawing.Size(92, 22);
            this.txt_Itemcode.TabIndex = 17;
            this.txt_Itemcode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_Itemcode_KeyUp);
            // 
            // Btn_itemCode
            // 
            this.Btn_itemCode.BackColor = System.Drawing.Color.LimeGreen;
            this.Btn_itemCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_itemCode.ForeColor = System.Drawing.Color.White;
            this.Btn_itemCode.Location = new System.Drawing.Point(106, 40);
            this.Btn_itemCode.Name = "Btn_itemCode";
            this.Btn_itemCode.Size = new System.Drawing.Size(19, 19);
            this.Btn_itemCode.TabIndex = 16;
            this.Btn_itemCode.UseVisualStyleBackColor = false;
            this.Btn_itemCode.Click += new System.EventHandler(this.Btn_itemCode_Click);
            // 
            // txtUnitCost
            // 
            this.txtUnitCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUnitCost.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUnitCost.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.txtUnitCost.Location = new System.Drawing.Point(494, 40);
            this.txtUnitCost.Name = "txtUnitCost";
            this.txtUnitCost.Size = new System.Drawing.Size(92, 22);
            this.txtUnitCost.TabIndex = 15;
            this.txtUnitCost.Text = "0.0";
            this.txtUnitCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtUnitCost.Click += new System.EventHandler(this.txtUnitCost_Click);
            this.txtUnitCost.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUnitCost_KeyPress);
            this.txtUnitCost.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtUnitCost_KeyUp);
            this.txtUnitCost.Leave += new System.EventHandler(this.txtUnitCost_Leave);
            // 
            // txtAmount
            // 
            this.txtAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAmount.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmount.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.txtAmount.Location = new System.Drawing.Point(605, 40);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.ReadOnly = true;
            this.txtAmount.Size = new System.Drawing.Size(92, 22);
            this.txtAmount.TabIndex = 13;
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_qty
            // 
            this.txt_qty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_qty.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_qty.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.txt_qty.Location = new System.Drawing.Point(383, 40);
            this.txt_qty.Name = "txt_qty";
            this.txt_qty.Size = new System.Drawing.Size(92, 22);
            this.txt_qty.TabIndex = 12;
            this.txt_qty.Text = "0";
            this.txt_qty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_qty.Click += new System.EventHandler(this.txt_qty_Click);
            this.txt_qty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_qty_KeyPress);
            this.txt_qty.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_qty_KeyUp);
            this.txt_qty.Leave += new System.EventHandler(this.txt_qty_Leave);
            // 
            // txtDescription
            // 
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.txtDescription.Location = new System.Drawing.Point(157, 40);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Size = new System.Drawing.Size(207, 22);
            this.txtDescription.TabIndex = 9;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label21.Location = new System.Drawing.Point(605, 17);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(51, 15);
            this.label21.TabIndex = 7;
            this.label21.Text = "Amount";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label11.Location = new System.Drawing.Point(157, 17);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(67, 15);
            this.label11.TabIndex = 5;
            this.label11.Text = "Description";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label8.Location = new System.Drawing.Point(494, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 15);
            this.label8.TabIndex = 3;
            this.label8.Text = "Unit Cost";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label5.Location = new System.Drawing.Point(383, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 15);
            this.label5.TabIndex = 1;
            this.label5.Text = "Quantity";
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Tomato;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(784, 40);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(60, 23);
            this.btnClear.TabIndex = 214;
            this.btnClear.Text = "Cancel";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Visible = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // PurchaseOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1054, 600);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PurchaseOrder";
            this.Text = "Purchase Order";
            this.Load += new System.EventHandler(this.frmPurchaseOrder_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemData)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvItemData;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtTotalAmount;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox txtTotal_item;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.DateTimePicker dtpPurchDate;
        private System.Windows.Forms.TextBox txtPurchOrderNo;
        private System.Windows.Forms.Label lblDocumentNumber;
        private System.Windows.Forms.ListBox lstbox_Supplier;
        private System.Windows.Forms.Label lblDocumentDate;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblSupplierCode;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtSupplierName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_SupplierId;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.Button Btn_Add;
        private System.Windows.Forms.TextBox txt_Itemcode;
        private System.Windows.Forms.Button Btn_itemCode;
        private System.Windows.Forms.TextBox txtUnitCost;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.TextBox txt_qty;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn description;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unit_Cost;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewImageColumn ItemEdit;
        private System.Windows.Forms.DataGridViewImageColumn Del;
    }
}