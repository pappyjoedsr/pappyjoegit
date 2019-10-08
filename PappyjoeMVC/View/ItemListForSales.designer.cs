namespace PappyjoeMVC.View
{
    partial class ItemListForSales
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemListForSales));
            this.panel2 = new System.Windows.Forms.Panel();
            this.Lab_Msg = new System.Windows.Forms.Label();
            this.btn_ok = new System.Windows.Forms.Button();
            this.txt_ItemCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgv_item = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColItemCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPrize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCost2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_Batches = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_item)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.Lab_Msg);
            this.panel2.Controls.Add(this.btn_ok);
            this.panel2.Controls.Add(this.txt_ItemCode);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(1, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(614, 54);
            this.panel2.TabIndex = 2;
            // 
            // Lab_Msg
            // 
            this.Lab_Msg.AutoSize = true;
            this.Lab_Msg.ForeColor = System.Drawing.Color.Red;
            this.Lab_Msg.Location = new System.Drawing.Point(94, 39);
            this.Lab_Msg.Name = "Lab_Msg";
            this.Lab_Msg.Size = new System.Drawing.Size(82, 13);
            this.Lab_Msg.TabIndex = 5;
            this.Lab_Msg.Text = "No Items Found";
            this.Lab_Msg.Visible = false;
            // 
            // btn_ok
            // 
            this.btn_ok.BackColor = System.Drawing.Color.LimeGreen;
            this.btn_ok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ok.ForeColor = System.Drawing.Color.White;
            this.btn_ok.Location = new System.Drawing.Point(529, 14);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(83, 30);
            this.btn_ok.TabIndex = 2;
            this.btn_ok.Text = "OK";
            this.btn_ok.UseVisualStyleBackColor = false;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // txt_ItemCode
            // 
            this.txt_ItemCode.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ItemCode.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.txt_ItemCode.Location = new System.Drawing.Point(90, 16);
            this.txt_ItemCode.Name = "txt_ItemCode";
            this.txt_ItemCode.Size = new System.Drawing.Size(295, 23);
            this.txt_ItemCode.TabIndex = 4;
            this.txt_ItemCode.Text = "Search by Item Code,Item Name,Category";
            this.txt_ItemCode.Click += new System.EventHandler(this.txt_ItemCode_Click);
            this.txt_ItemCode.TextChanged += new System.EventHandler(this.txt_ItemCode_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label1.Location = new System.Drawing.Point(16, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Item Code";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.dgv_item);
            this.panel1.Location = new System.Drawing.Point(2, 58);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(613, 323);
            this.panel1.TabIndex = 3;
            // 
            // dgv_item
            // 
            this.dgv_item.AllowUserToAddRows = false;
            this.dgv_item.AllowUserToDeleteRows = false;
            this.dgv_item.AllowUserToOrderColumns = true;
            this.dgv_item.AllowUserToResizeColumns = false;
            this.dgv_item.AllowUserToResizeRows = false;
            this.dgv_item.BackgroundColor = System.Drawing.Color.White;
            this.dgv_item.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgv_item.ColumnHeadersHeight = 27;
            this.dgv_item.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_item.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.ColItemCode,
            this.colItemName,
            this.colCategory,
            this.colStock,
            this.ColPrize,
            this.colCost2});
            this.dgv_item.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_item.Location = new System.Drawing.Point(0, 0);
            this.dgv_item.Name = "dgv_item";
            this.dgv_item.ReadOnly = true;
            this.dgv_item.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_item.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_item.RowHeadersVisible = false;
            this.dgv_item.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv_item.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgv_item.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_item.Size = new System.Drawing.Size(613, 323);
            this.dgv_item.TabIndex = 0;
            this.dgv_item.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_item_CellClick);
            this.dgv_item.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_item_CellDoubleClick);
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // ColItemCode
            // 
            this.ColItemCode.HeaderText = "Item Code";
            this.ColItemCode.Name = "ColItemCode";
            this.ColItemCode.ReadOnly = true;
            // 
            // colItemName
            // 
            this.colItemName.HeaderText = "Item Name";
            this.colItemName.Name = "colItemName";
            this.colItemName.ReadOnly = true;
            this.colItemName.Width = 143;
            // 
            // colCategory
            // 
            this.colCategory.HeaderText = "Category Name";
            this.colCategory.Name = "colCategory";
            this.colCategory.ReadOnly = true;
            // 
            // colStock
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colStock.DefaultCellStyle = dataGridViewCellStyle1;
            this.colStock.HeaderText = "Stock";
            this.colStock.Name = "colStock";
            this.colStock.ReadOnly = true;
            this.colStock.Width = 80;
            // 
            // ColPrize
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColPrize.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColPrize.HeaderText = "Cost (Unit 1)";
            this.ColPrize.Name = "ColPrize";
            this.ColPrize.ReadOnly = true;
            this.ColPrize.Width = 85;
            // 
            // colCost2
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colCost2.DefaultCellStyle = dataGridViewCellStyle3;
            this.colCost2.HeaderText = "Cost (Unit 2)";
            this.colCost2.Name = "colCost2";
            this.colCost2.ReadOnly = true;
            this.colCost2.Width = 85;
            // 
            // btn_Batches
            // 
            this.btn_Batches.BackColor = System.Drawing.Color.LimeGreen;
            this.btn_Batches.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Batches.ForeColor = System.Drawing.Color.White;
            this.btn_Batches.Location = new System.Drawing.Point(531, 387);
            this.btn_Batches.Name = "btn_Batches";
            this.btn_Batches.Size = new System.Drawing.Size(83, 30);
            this.btn_Batches.TabIndex = 4;
            this.btn_Batches.Text = "Batches";
            this.btn_Batches.UseVisualStyleBackColor = false;
            this.btn_Batches.Click += new System.EventHandler(this.btn_Batches_Click);
            // 
            // ItemListForSales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 419);
            this.Controls.Add(this.btn_Batches);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ItemListForSales";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Item List";
            this.Load += new System.EventHandler(this.ItemListForSales_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_item)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label Lab_Msg;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.TextBox txt_ItemCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgv_item;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColItemCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPrize;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCost2;
        private System.Windows.Forms.Button btn_Batches;
    }
}