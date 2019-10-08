namespace PappyjoeMVC.View
{
    partial class Sales_Return_Itemlist
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sales_Return_Itemlist));
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txt_Search = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgv_Item = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colitem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBatch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lab_Msg = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Item)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 25);
            this.label1.TabIndex = 217;
            this.label1.Text = "Item List";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.Tomato;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(252, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 30);
            this.btnCancel.TabIndex = 216;
            this.btnCancel.Text = "CLOSE";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // btn_OK
            // 
            this.btn_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_OK.BackColor = System.Drawing.Color.LimeGreen;
            this.btn_OK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_OK.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btn_OK.ForeColor = System.Drawing.Color.White;
            this.btn_OK.Location = new System.Drawing.Point(173, 2);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(80, 30);
            this.btn_OK.TabIndex = 215;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = false;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.DarkGray;
            this.panel2.Location = new System.Drawing.Point(-2, 35);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(347, 1);
            this.panel2.TabIndex = 218;
            // 
            // txt_Search
            // 
            this.txt_Search.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Search.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.txt_Search.Location = new System.Drawing.Point(56, 39);
            this.txt_Search.Name = "txt_Search";
            this.txt_Search.Size = new System.Drawing.Size(282, 23);
            this.txt_Search.TabIndex = 291;
            this.txt_Search.Text = "Search by Item Code and Item Name ";
            this.txt_Search.Visible = false;
            this.txt_Search.Click += new System.EventHandler(this.txt_Search_Click);
            this.txt_Search.TextChanged += new System.EventHandler(this.txt_Search_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label2.Location = new System.Drawing.Point(4, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 17);
            this.label2.TabIndex = 290;
            this.label2.Text = "Search";
            this.label2.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.dgv_Item);
            this.panel1.Location = new System.Drawing.Point(0, 68);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(338, 435);
            this.panel1.TabIndex = 289;
            // 
            // dgv_Item
            // 
            this.dgv_Item.AllowUserToAddRows = false;
            this.dgv_Item.AllowUserToDeleteRows = false;
            this.dgv_Item.AllowUserToResizeColumns = false;
            this.dgv_Item.AllowUserToResizeRows = false;
            this.dgv_Item.BackgroundColor = System.Drawing.Color.White;
            this.dgv_Item.ColumnHeadersHeight = 25;
            this.dgv_Item.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_Item.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.colitem,
            this.colBatch});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Item.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Item.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Item.Location = new System.Drawing.Point(0, 0);
            this.dgv_Item.Name = "dgv_Item";
            this.dgv_Item.ReadOnly = true;
            this.dgv_Item.RowHeadersVisible = false;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.dgv_Item.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_Item.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgv_Item.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Item.Size = new System.Drawing.Size(338, 435);
            this.dgv_Item.TabIndex = 0;
            this.dgv_Item.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Item_CellDoubleClick);
            // 
            // id
            // 
            this.id.HeaderText = "Id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // colitem
            // 
            this.colitem.HeaderText = "Item Code";
            this.colitem.Name = "colitem";
            this.colitem.ReadOnly = true;
            this.colitem.Width = 165;
            // 
            // colBatch
            // 
            this.colBatch.HeaderText = "ItemName";
            this.colBatch.Name = "colBatch";
            this.colBatch.ReadOnly = true;
            this.colBatch.Width = 170;
            // 
            // Lab_Msg
            // 
            this.Lab_Msg.AutoSize = true;
            this.Lab_Msg.ForeColor = System.Drawing.Color.Red;
            this.Lab_Msg.Location = new System.Drawing.Point(249, 44);
            this.Lab_Msg.Name = "Lab_Msg";
            this.Lab_Msg.Size = new System.Drawing.Size(82, 13);
            this.Lab_Msg.TabIndex = 292;
            this.Lab_Msg.Text = "No Items Found";
            this.Lab_Msg.Visible = false;
            // 
            // Sales_Return_Itemlist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(339, 505);
            this.Controls.Add(this.Lab_Msg);
            this.Controls.Add(this.txt_Search);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btn_OK);
            this.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Sales_Return_Itemlist";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Item List";
            this.Load += new System.EventHandler(this.Sales_Return_Itemlist_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Item)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txt_Search;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgv_Item;
        private System.Windows.Forms.Label Lab_Msg;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn colitem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBatch;
    }
}