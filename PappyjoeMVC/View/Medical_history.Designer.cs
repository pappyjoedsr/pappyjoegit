namespace PappyjoeMVC.View
{
    partial class Medical_History
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Medical_History));
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.Dgv_medhist = new System.Windows.Forms.DataGridView();
            this.mid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.medicl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.edit = new System.Windows.Forms.DataGridViewImageColumn();
            this.delete = new System.Windows.Forms.DataGridViewImageColumn();
            this.label8 = new System.Windows.Forms.Label();
            this.button_add = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.text_medhist = new System.Windows.Forms.TextBox();
            this.text_search = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btn_Cancelgroup = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_group = new System.Windows.Forms.TextBox();
            this.button_group = new System.Windows.Forms.Button();
            this.dataGridView_group = new System.Windows.Forms.DataGridView();
            this.gid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gsl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Medgroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gedit = new System.Windows.Forms.DataGridViewImageColumn();
            this.gdelete = new System.Windows.Forms.DataGridViewImageColumn();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn3 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn4 = new System.Windows.Forms.DataGridViewImageColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_medhist)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_group)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Underline);
            this.label2.Location = new System.Drawing.Point(16, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Medical History";
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(12, 72);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1029, 542);
            this.tabControl1.TabIndex = 280;
            this.tabControl1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControl1_DrawItem);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.btn_Cancel);
            this.tabPage1.Controls.Add(this.Dgv_medhist);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.button_add);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.text_medhist);
            this.tabPage1.Controls.Add(this.text_search);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1021, 513);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Add Medical History";
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btn_Cancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Cancel.ForeColor = System.Drawing.Color.White;
            this.btn_Cancel.Location = new System.Drawing.Point(199, 53);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 28);
            this.btn_Cancel.TabIndex = 279;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = false;
            this.btn_Cancel.Visible = false;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // Dgv_medhist
            // 
            this.Dgv_medhist.AllowUserToAddRows = false;
            this.Dgv_medhist.AllowUserToDeleteRows = false;
            this.Dgv_medhist.AllowUserToResizeColumns = false;
            this.Dgv_medhist.AllowUserToResizeRows = false;
            this.Dgv_medhist.BackgroundColor = System.Drawing.Color.White;
            this.Dgv_medhist.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Dgv_medhist.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.Dgv_medhist.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Dgv_medhist.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.Dgv_medhist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.Dgv_medhist.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.mid,
            this.medicl,
            this.edit,
            this.delete});
            this.Dgv_medhist.Location = new System.Drawing.Point(103, 142);
            this.Dgv_medhist.Name = "Dgv_medhist";
            this.Dgv_medhist.ReadOnly = true;
            this.Dgv_medhist.RowHeadersVisible = false;
            this.Dgv_medhist.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv_medhist.Size = new System.Drawing.Size(386, 346);
            this.Dgv_medhist.TabIndex = 4;
            this.Dgv_medhist.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_medhist_CellClick);
            // 
            // mid
            // 
            this.mid.DataPropertyName = "id";
            this.mid.HeaderText = "Id";
            this.mid.Name = "mid";
            this.mid.ReadOnly = true;
            this.mid.Visible = false;
            // 
            // medicl
            // 
            this.medicl.DataPropertyName = "name";
            this.medicl.HeaderText = "Medical History";
            this.medicl.Name = "medicl";
            this.medicl.ReadOnly = true;
            this.medicl.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.medicl.Width = 313;
            // 
            // edit
            // 
            this.edit.HeaderText = "";
            this.edit.Image = global::PappyjoeMVC.Properties.Resources.editicon;
            this.edit.Name = "edit";
            this.edit.ReadOnly = true;
            this.edit.Width = 19;
            // 
            // delete
            // 
            this.delete.HeaderText = "";
            this.delete.Image = global::PappyjoeMVC.Properties.Resources.deleteicon;
            this.delete.Name = "delete";
            this.delete.ReadOnly = true;
            this.delete.Width = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Wheat;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(150, 537);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(451, 25);
            this.label8.TabIndex = 278;
            this.label8.Text = "To edit details \"double click\" on the respective value.";
            // 
            // button_add
            // 
            this.button_add.BackColor = System.Drawing.Color.LimeGreen;
            this.button_add.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_add.ForeColor = System.Drawing.Color.White;
            this.button_add.Location = new System.Drawing.Point(116, 53);
            this.button_add.Name = "button_add";
            this.button_add.Size = new System.Drawing.Size(75, 28);
            this.button_add.TabIndex = 0;
            this.button_add.Text = "Add";
            this.button_add.UseVisualStyleBackColor = false;
            this.button_add.Click += new System.EventHandler(this.button_add_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(60, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "Search";
            // 
            // text_medhist
            // 
            this.text_medhist.Location = new System.Drawing.Point(117, 22);
            this.text_medhist.Name = "text_medhist";
            this.text_medhist.Size = new System.Drawing.Size(329, 22);
            this.text_medhist.TabIndex = 1;
            this.text_medhist.TextChanged += new System.EventHandler(this.text_medhist_TextChanged);
            // 
            // text_search
            // 
            this.text_search.Location = new System.Drawing.Point(116, 102);
            this.text_search.Name = "text_search";
            this.text_search.Size = new System.Drawing.Size(329, 22);
            this.text_search.TabIndex = 1;
            this.text_search.KeyUp += new System.Windows.Forms.KeyEventHandler(this.text_search_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Medical History";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(450, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Can\'t Be Empty";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.White;
            this.tabPage2.Controls.Add(this.btn_Cancelgroup);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.textBox_group);
            this.tabPage2.Controls.Add(this.button_group);
            this.tabPage2.Controls.Add(this.dataGridView_group);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1021, 513);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Add Group";
            // 
            // btn_Cancelgroup
            // 
            this.btn_Cancelgroup.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btn_Cancelgroup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Cancelgroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Cancelgroup.ForeColor = System.Drawing.Color.White;
            this.btn_Cancelgroup.Location = new System.Drawing.Point(199, 53);
            this.btn_Cancelgroup.Name = "btn_Cancelgroup";
            this.btn_Cancelgroup.Size = new System.Drawing.Size(75, 28);
            this.btn_Cancelgroup.TabIndex = 280;
            this.btn_Cancelgroup.Text = "Cancel";
            this.btn_Cancelgroup.UseVisualStyleBackColor = false;
            this.btn_Cancelgroup.Visible = false;
            this.btn_Cancelgroup.Click += new System.EventHandler(this.btn_Cancelgroup_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label5.Location = new System.Drawing.Point(51, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 17);
            this.label5.TabIndex = 276;
            this.label5.Text = "Group";
            // 
            // textBox_group
            // 
            this.textBox_group.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.textBox_group.Location = new System.Drawing.Point(116, 22);
            this.textBox_group.Name = "textBox_group";
            this.textBox_group.Size = new System.Drawing.Size(329, 22);
            this.textBox_group.TabIndex = 275;
            // 
            // button_group
            // 
            this.button_group.BackColor = System.Drawing.Color.LimeGreen;
            this.button_group.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_group.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_group.ForeColor = System.Drawing.Color.White;
            this.button_group.Location = new System.Drawing.Point(116, 53);
            this.button_group.Name = "button_group";
            this.button_group.Size = new System.Drawing.Size(75, 28);
            this.button_group.TabIndex = 80;
            this.button_group.Text = "Save";
            this.button_group.UseVisualStyleBackColor = false;
            this.button_group.Click += new System.EventHandler(this.button_group_Click);
            // 
            // dataGridView_group
            // 
            this.dataGridView_group.AllowUserToAddRows = false;
            this.dataGridView_group.AllowUserToDeleteRows = false;
            this.dataGridView_group.AllowUserToResizeRows = false;
            this.dataGridView_group.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridView_group.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView_group.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView_group.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView_group.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_group.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView_group.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView_group.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gid,
            this.gsl,
            this.Medgroup,
            this.gedit,
            this.gdelete});
            this.dataGridView_group.Location = new System.Drawing.Point(116, 128);
            this.dataGridView_group.Name = "dataGridView_group";
            this.dataGridView_group.ReadOnly = true;
            this.dataGridView_group.RowHeadersVisible = false;
            this.dataGridView_group.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView_group.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_group.Size = new System.Drawing.Size(298, 294);
            this.dataGridView_group.TabIndex = 271;
            this.dataGridView_group.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_group_CellClick);
            // 
            // gid
            // 
            this.gid.HeaderText = "ID";
            this.gid.Name = "gid";
            this.gid.ReadOnly = true;
            this.gid.Visible = false;
            // 
            // gsl
            // 
            this.gsl.HeaderText = "SL.";
            this.gsl.Name = "gsl";
            this.gsl.ReadOnly = true;
            this.gsl.Visible = false;
            this.gsl.Width = 50;
            // 
            // Medgroup
            // 
            this.Medgroup.HeaderText = "Group Name";
            this.Medgroup.Name = "Medgroup";
            this.Medgroup.ReadOnly = true;
            this.Medgroup.Width = 200;
            // 
            // gedit
            // 
            this.gedit.HeaderText = "";
            this.gedit.Image = global::PappyjoeMVC.Properties.Resources.editicon;
            this.gedit.Name = "gedit";
            this.gedit.ReadOnly = true;
            this.gedit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.gedit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.gedit.Width = 19;
            // 
            // gdelete
            // 
            this.gdelete.HeaderText = "";
            this.gdelete.Image = global::PappyjoeMVC.Properties.Resources.deleteicon;
            this.gdelete.Name = "gdelete";
            this.gdelete.ReadOnly = true;
            this.gdelete.Width = 19;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Image = global::PappyjoeMVC.Properties.Resources.editicon;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Width = 23;
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.HeaderText = "";
            this.dataGridViewImageColumn2.Image = global::PappyjoeMVC.Properties.Resources.deleteicon;
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.Width = 27;
            // 
            // dataGridViewImageColumn3
            // 
            this.dataGridViewImageColumn3.HeaderText = "";
            this.dataGridViewImageColumn3.Image = global::PappyjoeMVC.Properties.Resources.editicon;
            this.dataGridViewImageColumn3.Name = "dataGridViewImageColumn3";
            this.dataGridViewImageColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewImageColumn3.Width = 35;
            // 
            // dataGridViewImageColumn4
            // 
            this.dataGridViewImageColumn4.HeaderText = "";
            this.dataGridViewImageColumn4.Image = global::PappyjoeMVC.Properties.Resources.deleteicon;
            this.dataGridViewImageColumn4.Name = "dataGridViewImageColumn4";
            this.dataGridViewImageColumn4.Width = 35;
            // 
            // Medical_History
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1053, 612);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label2);
            this.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Medical_History";
            this.Text = "Medical History";
            this.Load += new System.EventHandler(this.Medical_history_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_medhist)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_group)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.DataGridView Dgv_medhist;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button_add;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox text_medhist;
        private System.Windows.Forms.TextBox text_search;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btn_Cancelgroup;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_group;
        private System.Windows.Forms.Button button_group;
        private System.Windows.Forms.DataGridView dataGridView_group;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn3;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn mid;
        private System.Windows.Forms.DataGridViewTextBoxColumn medicl;
        private System.Windows.Forms.DataGridViewImageColumn edit;
        private System.Windows.Forms.DataGridViewImageColumn delete;
        private System.Windows.Forms.DataGridViewTextBoxColumn gid;
        private System.Windows.Forms.DataGridViewTextBoxColumn gsl;
        private System.Windows.Forms.DataGridViewTextBoxColumn Medgroup;
        private System.Windows.Forms.DataGridViewImageColumn gedit;
        private System.Windows.Forms.DataGridViewImageColumn gdelete;
    }
}