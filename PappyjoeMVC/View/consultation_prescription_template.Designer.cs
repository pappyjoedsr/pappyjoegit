namespace Pappyjoe
{
    partial class consultation_prescription_template
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(consultation_prescription_template));
            this.txt_tempName = new System.Windows.Forms.TextBox();
            this.LAb_Drugname = new System.Windows.Forms.Label();
            this.dataGridView_templatenew = new System.Windows.Forms.DataGridView();
            this.drgname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.strength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.strengthgr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.duration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PERIOD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.morning = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.noon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.neight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.food = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.instruction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_templatenew)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_tempName
            // 
            this.txt_tempName.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_tempName.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.txt_tempName.Location = new System.Drawing.Point(108, 6);
            this.txt_tempName.Name = "txt_tempName";
            this.txt_tempName.Size = new System.Drawing.Size(212, 22);
            this.txt_tempName.TabIndex = 329;
            // 
            // LAb_Drugname
            // 
            this.LAb_Drugname.AutoSize = true;
            this.LAb_Drugname.BackColor = System.Drawing.SystemColors.Control;
            this.LAb_Drugname.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LAb_Drugname.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.LAb_Drugname.Location = new System.Drawing.Point(12, 9);
            this.LAb_Drugname.Name = "LAb_Drugname";
            this.LAb_Drugname.Size = new System.Drawing.Size(92, 15);
            this.LAb_Drugname.TabIndex = 328;
            this.LAb_Drugname.Text = "Template Name";
            // 
            // dataGridView_templatenew
            // 
            this.dataGridView_templatenew.AllowUserToAddRows = false;
            this.dataGridView_templatenew.AllowUserToDeleteRows = false;
            this.dataGridView_templatenew.AllowUserToResizeRows = false;
            this.dataGridView_templatenew.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView_templatenew.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView_templatenew.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView_templatenew.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_templatenew.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_templatenew.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_templatenew.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.drgname,
            this.strength,
            this.strengthgr,
            this.duration,
            this.PERIOD,
            this.morning,
            this.noon,
            this.neight,
            this.food,
            this.instruction,
            this.id,
            this.type,
            this.status1});
            this.dataGridView_templatenew.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView_templatenew.Location = new System.Drawing.Point(0, 48);
            this.dataGridView_templatenew.Name = "dataGridView_templatenew";
            this.dataGridView_templatenew.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_templatenew.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView_templatenew.RowHeadersVisible = false;
            this.dataGridView_templatenew.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView_templatenew.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_templatenew.Size = new System.Drawing.Size(932, 176);
            this.dataGridView_templatenew.TabIndex = 330;
            // 
            // drgname
            // 
            this.drgname.HeaderText = "DRUG NAME";
            this.drgname.Name = "drgname";
            this.drgname.ReadOnly = true;
            this.drgname.Width = 180;
            // 
            // strength
            // 
            this.strength.HeaderText = "STRENGTH";
            this.strength.Name = "strength";
            this.strength.ReadOnly = true;
            // 
            // strengthgr
            // 
            this.strengthgr.HeaderText = "STRENGTH GR";
            this.strengthgr.Name = "strengthgr";
            this.strengthgr.ReadOnly = true;
            this.strengthgr.Visible = false;
            this.strengthgr.Width = 30;
            // 
            // duration
            // 
            this.duration.HeaderText = "DURATION";
            this.duration.Name = "duration";
            this.duration.ReadOnly = true;
            // 
            // PERIOD
            // 
            this.PERIOD.HeaderText = "PERIOD";
            this.PERIOD.Name = "PERIOD";
            this.PERIOD.ReadOnly = true;
            this.PERIOD.Visible = false;
            this.PERIOD.Width = 50;
            // 
            // morning
            // 
            this.morning.HeaderText = "MORNING";
            this.morning.Name = "morning";
            this.morning.ReadOnly = true;
            // 
            // noon
            // 
            this.noon.HeaderText = "NOON";
            this.noon.Name = "noon";
            this.noon.ReadOnly = true;
            // 
            // neight
            // 
            this.neight.HeaderText = "NIGHT";
            this.neight.Name = "neight";
            this.neight.ReadOnly = true;
            // 
            // food
            // 
            this.food.HeaderText = "FOOD";
            this.food.Name = "food";
            this.food.ReadOnly = true;
            // 
            // instruction
            // 
            this.instruction.HeaderText = "INSTRUCTIONS";
            this.instruction.Name = "instruction";
            this.instruction.ReadOnly = true;
            this.instruction.Width = 150;
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // type
            // 
            this.type.HeaderText = "type";
            this.type.Name = "type";
            this.type.ReadOnly = true;
            this.type.Visible = false;
            // 
            // status1
            // 
            this.status1.HeaderText = "status1";
            this.status1.Name = "status1";
            this.status1.ReadOnly = true;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.Color.Tomato;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(859, 6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(73, 27);
            this.button2.TabIndex = 331;
            this.button2.Text = "CLOSE";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // consultation_prescription_template
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(932, 224);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dataGridView_templatenew);
            this.Controls.Add(this.txt_tempName);
            this.Controls.Add(this.LAb_Drugname);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "consultation_prescription_template";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Prescription Template";
            this.Load += new System.EventHandler(this.consultation_prescription_template_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_templatenew)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_tempName;
        private System.Windows.Forms.Label LAb_Drugname;
        private System.Windows.Forms.DataGridView dataGridView_templatenew;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewTextBoxColumn drgname;
        private System.Windows.Forms.DataGridViewTextBoxColumn strength;
        private System.Windows.Forms.DataGridViewTextBoxColumn strengthgr;
        private System.Windows.Forms.DataGridViewTextBoxColumn duration;
        private System.Windows.Forms.DataGridViewTextBoxColumn PERIOD;
        private System.Windows.Forms.DataGridViewTextBoxColumn morning;
        private System.Windows.Forms.DataGridViewTextBoxColumn noon;
        private System.Windows.Forms.DataGridViewTextBoxColumn neight;
        private System.Windows.Forms.DataGridViewTextBoxColumn food;
        private System.Windows.Forms.DataGridViewTextBoxColumn instruction;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn type;
        private System.Windows.Forms.DataGridViewTextBoxColumn status1;
    }
}