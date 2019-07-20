namespace PappyjoeMVC.View
{
    partial class Calender_Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Calender_Settings));
            this.label2 = new System.Windows.Forms.Label();
            this.combo_slot = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.button_savetimings = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(295, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 76;
            this.label2.Text = "Can\'t be empty";
            // 
            // combo_slot
            // 
            this.combo_slot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_slot.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.combo_slot.FormattingEnabled = true;
            this.combo_slot.Items.AddRange(new object[] {
            "5 minutes",
            "10 minutes",
            "15 minutes",
            "30 minutes",
            "60 minutes"});
            this.combo_slot.Location = new System.Drawing.Point(165, 85);
            this.combo_slot.Name = "combo_slot";
            this.combo_slot.Size = new System.Drawing.Size(121, 21);
            this.combo_slot.TabIndex = 75;
            this.combo_slot.SelectedIndexChanged += new System.EventHandler(this.combo_slot_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label1.Location = new System.Drawing.Point(32, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 13);
            this.label1.TabIndex = 74;
            this.label1.Text = "Show Calendar Slots of  ";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label17.Location = new System.Drawing.Point(8, 17);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(88, 25);
            this.label17.TabIndex = 77;
            this.label17.Text = "Calendar";
            // 
            // button_savetimings
            // 
            this.button_savetimings.BackColor = System.Drawing.Color.LimeGreen;
            this.button_savetimings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_savetimings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_savetimings.ForeColor = System.Drawing.Color.White;
            this.button_savetimings.Location = new System.Drawing.Point(560, 79);
            this.button_savetimings.Name = "button_savetimings";
            this.button_savetimings.Size = new System.Drawing.Size(99, 33);
            this.button_savetimings.TabIndex = 78;
            this.button_savetimings.Text = "Save";
            this.button_savetimings.UseVisualStyleBackColor = false;
            this.button_savetimings.Click += new System.EventHandler(this.button_savetimings_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Calender_Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1214, 750);
            this.Controls.Add(this.button_savetimings);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.combo_slot);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Calender_Settings";
            this.Text = "Calender Settings";
            this.Load += new System.EventHandler(this.Calender_Settings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox combo_slot;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button button_savetimings;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}