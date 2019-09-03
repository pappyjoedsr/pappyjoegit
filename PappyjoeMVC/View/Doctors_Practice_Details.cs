using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PappyjoeMVC.Controller;
namespace PappyjoeMVC.View
{
    public partial class Doctors_Practice_Details : Form
    {
        public string frameid = "0";
        Doctor_Practice_controller cntrl=new Doctor_Practice_controller();
        string serviceid = "0";
        string Specializationid = "0";
        string degreeid = "0";
        string collegeid = "0";
        string membershipid = "0";
        string councilid = "0";
        string cityid = "0";
        public Doctors_Practice_Details()
        {
            InitializeComponent();
        }
      
        private void doctorsPracticedetails_Load(object sender, EventArgs e)
        {
            if (button_services.Text == "Save")
            {
                cancel.Text = "Close";
            }
            else if (button_services.Text == "Update")
            {
                cancel.Text = "Cancel";
            }
            if (frameid == "1")
            {
                panel1.Location = new Point(3, 2);
                panel1.Visible = true;
                panel2.Visible = false;
                panel3.Visible = false;
                panel4.Visible = false;
                panel7.Visible = false;
                panel6.Visible = false;
                Load_servise();
            }
            else if (frameid == "2")
            {
                panel2.Location = new Point(3, 2);
                panel2.Visible = true;
                panel1.Visible = false;
                panel3.Visible = false;
                panel4.Visible = false;
                panel7.Visible = false;
                panel6.Visible = false;
                Load_degree();
            }
            else if (frameid == "3")
            {
                panel3.Location = new Point(3, 2);
                panel3.Visible = true;
                panel1.Visible = false;
                panel2.Visible = false;
                panel4.Visible = false;
                panel7.Visible = false;
                panel6.Visible = false;
                Load_collage();
            }
            else if (frameid == "4")
            {
                panel4.Location = new Point(3, 2);
                panel4.Visible = true;
                panel1.Visible = false;
                panel2.Visible = false;
                panel3.Visible = false;
                panel7.Visible = false;
                panel6.Visible = false;
                Load_Membership();
            }
            else if (frameid == "5")
            {
                panel7.Location = new Point(3, 2);
                panel7.Visible = true;
                panel1.Visible = false;
                panel2.Visible = false;
                panel3.Visible = false;
                panel4.Visible = false;
                panel6.Visible = false;
                Load_RegCouncle();
            }
            else if (frameid == "6")
            {
                panel6.Location = new Point(3, 2);
                panel6.Visible = true;
                panel1.Visible = false;
                panel2.Visible = false;
                panel3.Visible = false;
                panel4.Visible = false;
                panel7.Visible = false;
                Load_Specializations();
            }
        }

        public void Load_servise()
        {
            dataGridView_services.RowHeadersVisible = false;
            dataGridView_services.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
            dataGridView_services.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView_services.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView_services.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView_services.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView_services.EnableHeadersVisualStyles = false;
            dataGridView_services.RowCount = 0;
            DataTable dt_maintest = this.cntrl.load_services();
            int i = 0;
            while (i < dt_maintest.Rows.Count)
            {
                try
                {
                    dataGridView_services.Rows.Add(dt_maintest.Rows[i]["id"].ToString(), i, dt_maintest.Rows[i]["service"].ToString());
                    i++;
                    dataGridView_services.Rows[dataGridView_services.Rows.Count - 1].Cells[1].Value = i;
                    dataGridView_services.Rows[dataGridView_services.Rows.Count - 1].Cells[3].Value = PappyjoeMVC.Properties.Resources.editicon;
                    dataGridView_services.Rows[dataGridView_services.Rows.Count - 1].Cells[4].Value = PappyjoeMVC.Properties.Resources.deleteicon;
                    dataGridView_services.Rows[i - 1].Height = 25;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button_services_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrWhiteSpace(textBox_services.Text))
                {
                    DataTable checkdatacc = this.cntrl.ifexists_services(textBox_services.Text);
                    if (checkdatacc.Rows.Count > 0)
                    {
                        MessageBox.Show("Service  " + textBox_services.Text + " already exist");
                    }
                    else
                    {
                        if (button_services.Text == "Save")
                        {
                            this.cntrl.save_service(textBox_services.Text);
                            string services = "0";
                            string dt = this.cntrl.max_serviceId();
                            if (dt!="")
                            {
                                services = dt;
                            }
                            dataGridView_services.Rows.Add(services.ToString(), 1, textBox_services.Text);
                            dataGridView_services.Rows[dataGridView_services.Rows.Count - 1].Cells[1].Value = dataGridView_services.Rows.Count;
                            dataGridView_services.Rows[dataGridView_services.Rows.Count - 1].Cells[3].Value = PappyjoeMVC.Properties.Resources.editicon;
                            dataGridView_services.Rows[dataGridView_services.Rows.Count - 1].Cells[4].Value = PappyjoeMVC.Properties.Resources.deleteicon;
                            dataGridView_services.Rows[dataGridView_services.Rows.Count - 1].Height = 30;
                            textBox_services.Text = "";
                            button_services.Text = "Save";
                            serviceid = "0";
                        }
                        else
                        {
                            if (serviceid != "0" && button_services.Text == "Update")
                            {
                                this.cntrl.update_service(textBox_services.Text, serviceid);
                                textBox_services.Text = "";
                                button_services.Text = "Save";
                                cancel.Text = "Close";
                                Load_servise();
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Enter the Services..", "empty field", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView_services_MouseClick(object sender, MouseEventArgs e)
        {
            int currentMouseOverRow = dataGridView_services.HitTest(e.X, e.Y).RowIndex;
            int currentMouseOverColumn = dataGridView_services.HitTest(e.X, e.Y).ColumnIndex;
            serviceid = "0";
            try
            {
                if (currentMouseOverRow >= 0)
                {
                    if (currentMouseOverColumn == 3)
                    {
                        serviceid = dataGridView_services.Rows[currentMouseOverRow].Cells[0].Value.ToString();
                        button_services.Text = "Update";
                        cancel.Text = "Cancel";
                        textBox_services.Text = dataGridView_services.Rows[currentMouseOverRow].Cells[2].Value.ToString();
                    }
                    else if (currentMouseOverColumn == 4)
                    {
                        serviceid = dataGridView_services.Rows[currentMouseOverRow].Cells[0].Value.ToString();
                        DialogResult res = MessageBox.Show("Are you sure you want to delete?", "Delete confirmation",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (res == DialogResult.No)
                        {
                        }
                        else
                        {
                            int a = this.cntrl.delete_service(serviceid);
                            if (a > 0)
                            {
                                dataGridView_services.Rows.RemoveAt(dataGridView_services.CurrentRow.Index);
                            }
                            button_services.Text = "Save";
                            textBox_services.Text = "";
                            serviceid = "0";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //degree
        private void dataGridView_degree_MouseClick(object sender, MouseEventArgs e)
        {
            int currentMouseOverRow = dataGridView_degree.HitTest(e.X, e.Y).RowIndex;
            int currentMouseOverColumn = dataGridView_degree.HitTest(e.X, e.Y).ColumnIndex;
            degreeid = "0";
            try
            {
                if (currentMouseOverRow >= 0)
                {
                    if (currentMouseOverColumn == 3)
                    {
                        degreeid = dataGridView_degree.Rows[currentMouseOverRow].Cells[0].Value.ToString();
                        button_degree.Text = "Update";
                        cancel.Text = "Cancel";
                        textBox_degree.Text = dataGridView_degree.Rows[currentMouseOverRow].Cells[2].Value.ToString();
                    }
                    else if (currentMouseOverColumn == 4)
                    {
                        degreeid = dataGridView_degree.Rows[currentMouseOverRow].Cells[0].Value.ToString();
                        DialogResult res = MessageBox.Show("Are you sure you want to delete?", "Delete confirmation",
                          MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (res == DialogResult.No)
                        {
                        }
                        else
                        {
                            this.cntrl.delete_degree(degreeid);
                            button_degree.Text = "Save";
                            textBox_degree.Text = "";
                            degreeid = "0";
                            Load_degree();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_degree_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrWhiteSpace(textBox_degree.Text))
                {
                    DataTable checkdatacc = this.cntrl.ifexists_degree(textBox_degree.Text);
                    if (checkdatacc.Rows.Count > 0)
                    {
                        MessageBox.Show("Degree" + textBox_degree.Text + " already exist", "Duplication encountered", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (button_degree.Text == "Save")
                        {
                            this.cntrl.save_degree(textBox_degree.Text);
                            string degree = "0";
                            string id = this.cntrl.max_degreeid();
                            if (id != "")
                            {
                                degree = id;
                            }
                            dataGridView_degree.Rows.Add(degree.ToString(), 1, textBox_degree.Text);
                            dataGridView_degree.Rows[dataGridView_degree.Rows.Count - 1].Cells[1].Value = dataGridView_degree.Rows.Count;
                            dataGridView_degree.Rows[dataGridView_degree.Rows.Count - 1].Cells[3].Value = PappyjoeMVC.Properties.Resources.editicon;
                            dataGridView_degree.Rows[dataGridView_degree.Rows.Count - 1].Cells[4].Value = PappyjoeMVC.Properties.Resources.deleteicon;
                            dataGridView_degree.Rows[dataGridView_degree.Rows.Count - 1].Height = 30;
                            textBox_degree.Text = "";
                            button_degree.Text = "Save";
                            degreeid = "0";
                        }
                        else
                        {
                            if (degreeid != "0" && button_degree.Text == "Update")
                            {
                                cancel.Text = "Cancel";
                                this.cntrl.update_degree(textBox_degree.Text, degreeid);
                                textBox_degree.Text = "";
                                button_degree.Text = "Save";
                                Load_degree();
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Enter the Degree..", "empty fields", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void Load_degree()
        {
            dataGridView_degree.RowHeadersVisible = false;
            dataGridView_degree.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
            dataGridView_degree.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView_degree.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView_degree.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView_degree.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView_degree.EnableHeadersVisualStyles = false;
            dataGridView_degree.RowCount = 0;
            DataTable dt_degree = this.cntrl.load_degree();
            int ii = 0;
            while (ii < dt_degree.Rows.Count)
            {
                try
                {
                    dataGridView_degree.Rows.Add(dt_degree.Rows[ii]["id"].ToString(), ii, dt_degree.Rows[ii]["degree"].ToString());
                    ii++;
                    dataGridView_degree.Rows[dataGridView_degree.Rows.Count - 1].Cells[1].Value = ii;
                    dataGridView_degree.Rows[dataGridView_degree.Rows.Count - 1].Cells[3].Value = PappyjoeMVC.Properties.Resources.editicon;
                    dataGridView_degree.Rows[dataGridView_degree.Rows.Count - 1].Cells[4].Value = PappyjoeMVC.Properties.Resources.deleteicon;
                    dataGridView_degree.Rows[ii - 1].Height = 25;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        //registration
        public void Load_RegCouncle()
        {
            dataGridView_council.RowHeadersVisible = false;
            dataGridView_council.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
            dataGridView_council.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView_council.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView_council.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView_council.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView_council.EnableHeadersVisualStyles = false;
            dataGridView_council.RowCount = 0;
            DataTable dt_council = this.cntrl.load_regcouncil();
            int iiiii = 0;
            while (iiiii < dt_council.Rows.Count)
            {
                try
                {
                    dataGridView_council.Rows.Add(dt_council.Rows[iiiii]["id"].ToString(), iiiii, dt_council.Rows[iiiii]["name"].ToString());
                    iiiii++;
                    dataGridView_council.Rows[dataGridView_council.Rows.Count - 1].Cells[1].Value = iiiii;
                    dataGridView_council.Rows[dataGridView_council.Rows.Count - 1].Cells[3].Value = PappyjoeMVC.Properties.Resources.editicon;
                    dataGridView_council.Rows[dataGridView_council.Rows.Count - 1].Cells[4].Value = PappyjoeMVC.Properties.Resources.deleteicon;
                    dataGridView_council.Rows[iiiii - 1].Height = 25;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridView_council_MouseClick(object sender, MouseEventArgs e)
        {
            int currentMouseOverRow = dataGridView_council.HitTest(e.X, e.Y).RowIndex;
            int currentMouseOverColumn = dataGridView_council.HitTest(e.X, e.Y).ColumnIndex;
            councilid = "0"; 
            try
            {
                if (currentMouseOverRow >= 0)
                {
                    if (currentMouseOverColumn == 3)
                    {
                        councilid = dataGridView_council.Rows[currentMouseOverRow].Cells[0].Value.ToString();
                        button_council.Text = "Update";
                        cancel.Text = "Cancel";
                        textBox_council.Text = dataGridView_council.Rows[currentMouseOverRow].Cells[2].Value.ToString();
                    }
                    else if (currentMouseOverColumn == 4)
                    {
                        councilid = dataGridView_council.Rows[currentMouseOverRow].Cells[0].Value.ToString();
                        DialogResult res = MessageBox.Show("Are you sure you want to delete?", "Delete confirmation",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (res == DialogResult.No)
                        {
                        }
                        else
                        {
                            this.cntrl.delete_registration(councilid);
                            button_council.Text = "Save";
                            textBox_council.Text = "";
                            councilid = "0";
                            Load_RegCouncle();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_council_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrWhiteSpace(textBox_council.Text))
                {
                    DataTable checkdatacc = this.cntrl.ifexists_council(textBox_council.Text);
                    if (checkdatacc.Rows.Count > 0)
                    {
                        MessageBox.Show("Registor Council " + textBox_council.Text + " already existed", "Duplication Encountered", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (button_council.Text == "Save")
                        {
                            this.cntrl.save_council(textBox_council.Text);
                            string council = "0";
                            string dt = this.cntrl.max_councilid();
                            if (dt!="")
                            {
                                council = dt;
                            }
                            dataGridView_council.Rows.Add(council.ToString(), 1, textBox_council.Text);
                            dataGridView_council.Rows[dataGridView_council.Rows.Count - 1].Cells[1].Value = dataGridView_council.Rows.Count;
                            dataGridView_council.Rows[dataGridView_council.Rows.Count - 1].Cells[3].Value = PappyjoeMVC.Properties.Resources.editicon;
                            dataGridView_council.Rows[dataGridView_council.Rows.Count - 1].Cells[4].Value = PappyjoeMVC.Properties.Resources.deleteicon;
                            dataGridView_council.Rows[dataGridView_council.Rows.Count - 1].Height = 30;
                            textBox_council.Text = "";
                            button_council.Text = "Save";
                            councilid = "0";
                        }
                        else
                        {
                            if (councilid != "0" && button_council.Text == "Update")
                            {
                                this.cntrl.update_council(textBox_council.Text, councilid);
                                textBox_council.Text = "";
                                button_council.Text = "Save";
                                cancel.Text = "Close";
                                Load_RegCouncle();
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Enter the Registration Council..!", "empty field", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView_membership_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                int currentMouseOverRow = dataGridView_membership.HitTest(e.X, e.Y).RowIndex;
                int currentMouseOverColumn = dataGridView_membership.HitTest(e.X, e.Y).ColumnIndex;
                membershipid = "0";
                if (currentMouseOverRow >= 0)
                {
                    if (currentMouseOverColumn == 3)
                    {
                        membershipid = dataGridView_membership.Rows[currentMouseOverRow].Cells[0].Value.ToString();
                        button_membership.Text = "Update";
                        cancel.Text = "Cancel";
                        textBox_membership.Text = dataGridView_membership.Rows[currentMouseOverRow].Cells[2].Value.ToString();
                    }
                    else if (currentMouseOverColumn == 4)
                    {
                        membershipid = dataGridView_membership.Rows[currentMouseOverRow].Cells[0].Value.ToString();
                        DialogResult res = MessageBox.Show("Are you sure you want to delete?", "Delete confirmation",
                       MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (res == DialogResult.No)
                        {
                        }
                        else
                        {
                            this.cntrl.delete_member(membershipid);
                            button_membership.Text = "Save";
                            textBox_membership.Text = "";
                            membershipid = "0";
                            Load_Membership();
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void Load_Membership()
        {
            dataGridView_membership.RowHeadersVisible = false;
            dataGridView_membership.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
            dataGridView_membership.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView_membership.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView_membership.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView_membership.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView_membership.EnableHeadersVisualStyles = false;
            dataGridView_membership.RowCount = 0;
            DataTable dt_membership = this.cntrl.load_member();
            int iiii = 0;
            while (iiii < dt_membership.Rows.Count)
            {
                try
                {
                    dataGridView_membership.Rows.Add(dt_membership.Rows[iiii]["id"].ToString(),iiii, dt_membership.Rows[iiii]["name"].ToString());
                    iiii++;
                    dataGridView_membership.Rows[dataGridView_membership.Rows.Count - 1].Cells[1].Value = iiii;
                    dataGridView_membership.Rows[dataGridView_membership.Rows.Count - 1].Cells[3].Value = PappyjoeMVC.Properties.Resources.editicon;
                    dataGridView_membership.Rows[dataGridView_membership.Rows.Count - 1].Cells[4].Value = PappyjoeMVC.Properties.Resources.deleteicon;
                    dataGridView_membership.Rows[iiii - 1].Height = 25;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button_membership_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrWhiteSpace(textBox_membership.Text))
                {
                    DataTable checkdatacc = this.cntrl.ifexists_member(textBox_membership.Text);
                    if (checkdatacc.Rows.Count > 0)
                    {
                        MessageBox.Show("Membership " + textBox_membership.Text + " already existed", "Duplication encountered", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (button_membership.Text == "Save")
                        {
                            this.cntrl.save_member(textBox_membership.Text);
                            string membership = "0";
                            string dt = this.cntrl.max_memberid();
                            if (dt!="")
                            {
                                membership = dt;
                            }
                            dataGridView_membership.Rows.Add(membership.ToString(), 1, textBox_membership.Text);
                            dataGridView_membership.Rows[dataGridView_membership.Rows.Count - 1].Cells[1].Value = dataGridView_membership.Rows.Count;
                            dataGridView_membership.Rows[dataGridView_membership.Rows.Count - 1].Cells[3].Value = PappyjoeMVC.Properties.Resources.editicon;
                            dataGridView_membership.Rows[dataGridView_membership.Rows.Count - 1].Cells[4].Value = PappyjoeMVC.Properties.Resources.deleteicon;
                            dataGridView_membership.Rows[dataGridView_membership.Rows.Count - 1].Height = 30;
                            textBox_membership.Text = "";
                            button_membership.Text = "Save";
                            membershipid = "0";
                        }
                        else
                        {
                            if (membershipid != "0" && button_membership.Text == "Update")
                            {
                                this.cntrl.update_member(textBox_membership.Text, membershipid);
                                textBox_membership.Text = "";
                                button_membership.Text = "Save";
                                cancel.Text = "Close";
                                Load_Membership();
                            }
                        }
                    }
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView_college_MouseClick(object sender, MouseEventArgs e)
        {
            int currentMouseOverRow = dataGridView_college.HitTest(e.X, e.Y).RowIndex;
            int currentMouseOverColumn = dataGridView_college.HitTest(e.X, e.Y).ColumnIndex;
            collegeid = "0";
            try
            {
                if (currentMouseOverRow >= 0)
                {
                    if (currentMouseOverColumn == 3)
                    {
                        collegeid = dataGridView_college.Rows[currentMouseOverRow].Cells[0].Value.ToString();
                        button_college.Text = "Update";
                        cancel.Text = "Cancel";
                        textBox_college.Text = dataGridView_college.Rows[currentMouseOverRow].Cells[2].Value.ToString();
                    }
                    else if (currentMouseOverColumn == 4)
                    {
                        collegeid = dataGridView_college.Rows[currentMouseOverRow].Cells[0].Value.ToString();
                        DialogResult res = MessageBox.Show("Are you sure you want to delete?", "Delete confirmation",
                         MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (res == DialogResult.No)
                        {
                        }
                        else
                        {
                            this.cntrl.delete_college(collegeid);
                            button_college.Text = "Save";
                            textBox_college.Text = "";
                            collegeid = "0";
                            Load_collage();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void Load_collage()
        {
            dataGridView_college.RowHeadersVisible = false;
            dataGridView_college.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
            dataGridView_college.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView_college.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView_college.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView_college.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView_college.EnableHeadersVisualStyles = false;
            dataGridView_college.RowCount = 0;
           DataTable dt_college= this.cntrl.load_college();
            int iii = 0;
            while (iii < dt_college.Rows.Count)
            {
                try
                {
                    dataGridView_college.Rows.Add(dt_college.Rows[iii]["id"].ToString(), iii, dt_college.Rows[iii]["college"].ToString());
                    iii++;
                    dataGridView_college.Rows[dataGridView_college.Rows.Count - 1].Cells[1].Value = iii;
                    dataGridView_college.Rows[dataGridView_college.Rows.Count - 1].Cells[3].Value = PappyjoeMVC.Properties.Resources.editicon;
                    dataGridView_college.Rows[dataGridView_college.Rows.Count - 1].Cells[4].Value = PappyjoeMVC.Properties.Resources.deleteicon;
                    dataGridView_college.Rows[iii - 1].Height = 25;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button_college_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrWhiteSpace(textBox_college.Text))
                {
                    DataTable checkdatacc = this.cntrl.ifexists_college(textBox_college.Text);
                    if (checkdatacc.Rows.Count > 0)
                    {
                        MessageBox.Show("Collage " + textBox_college.Text + " already exist");
                    }
                    else
                    {
                        if (button_college.Text == "Save")
                        {
                            this.cntrl.save_college(textBox_college.Text);
                            string college = "0";
                            string dt = this.cntrl.max_collegeid();
                            if (dt!="")
                            {
                                college = dt;
                            }
                            dataGridView_college.Rows.Add(college.ToString(), 1, textBox_college.Text);
                            dataGridView_college.Rows[dataGridView_college.Rows.Count - 1].Cells[1].Value = dataGridView_college.Rows.Count;
                            dataGridView_college.Rows[dataGridView_college.Rows.Count - 1].Cells[3].Value = PappyjoeMVC.Properties.Resources.editicon;
                            dataGridView_college.Rows[dataGridView_college.Rows.Count - 1].Cells[4].Value = PappyjoeMVC.Properties.Resources.deleteicon;
                            dataGridView_college.Rows[dataGridView_college.Rows.Count - 1].Height = 30;
                            textBox_college.Text = "";
                            button_college.Text = "Save";
                            collegeid = "0";
                        }
                        else
                        {
                            if (collegeid != "0" && button_college.Text == "Update")
                            {
                                cancel.Text = "Cancel";
                                this.cntrl.update_college(textBox_college.Text, collegeid);
                                textBox_college.Text = "";
                                button_college.Text = "Save";
                                cancel.Text = "Close";
                                Load_collage();
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Enter the college..!", "empty fields", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnsavespecialization_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable checkdatacc = this.cntrl.ifexists_specilization(specializationtextbox.Text);
                if (checkdatacc.Rows.Count > 0)
                {
                    MessageBox.Show("Specialization  " + specializationtextbox.Text + " already exist");
                }
                else
                {
                    if (!String.IsNullOrWhiteSpace(specializationtextbox.Text))
                    {
                        if (btnsavespecialization.Text == "Save")
                        {
                            this.cntrl.save_specilization(specializationtextbox.Text);
                            string specialization = "0";
                           string dt = this.cntrl.max_specilizationid();
                            if (dt!="")
                            {
                                specialization = dt;
                            }
                            dataGridView_Specialization.Rows.Add(specialization.ToString(), 1, specializationtextbox.Text);
                            dataGridView_Specialization.Rows[dataGridView_Specialization.Rows.Count - 1].Cells[1].Value = dataGridView_Specialization.Rows.Count;
                            dataGridView_Specialization.Rows[dataGridView_Specialization.Rows.Count - 1].Cells[3].Value = PappyjoeMVC.Properties.Resources.editicon;
                            dataGridView_Specialization.Rows[dataGridView_Specialization.Rows.Count - 1].Cells[4].Value = PappyjoeMVC.Properties.Resources.deleteicon;
                            dataGridView_Specialization.Rows[dataGridView_Specialization.Rows.Count - 1].Height = 30;
                            specializationtextbox.Text = "";
                            btnsavespecialization.Text = "Save";
                            Specializationid = "0";
                        }
                        else
                        {
                            if (Specializationid != "0" && btnsavespecialization.Text == "Update")
                            {
                                this.cntrl.update_sspecilization(specializationtextbox.Text, Specializationid);
                                specializationtextbox.Text = "";
                                btnsavespecialization.Text = "Save";
                                cancel.Text = "Close";
                                Load_Specializations();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Enter the specialization..!", "empty field", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView_Specialization_MouseClick(object sender, MouseEventArgs e)
        {
            int currentMouseOverRow = dataGridView_Specialization.HitTest(e.X, e.Y).RowIndex;
            int currentMouseOverColumn = dataGridView_Specialization.HitTest(e.X, e.Y).ColumnIndex;
            Specializationid = "0";
            try
            {
                if (currentMouseOverRow >= 0)
                {
                    if (currentMouseOverColumn == 3)
                    {
                        Specializationid = dataGridView_Specialization.Rows[currentMouseOverRow].Cells[0].Value.ToString();
                        btnsavespecialization.Text = "Update";
                        specializationtextbox.Text = dataGridView_Specialization.Rows[currentMouseOverRow].Cells[2].Value.ToString();
                        cancel.Text = "Cancel";
                    }
                    else if (currentMouseOverColumn == 4)
                    {
                        Specializationid = dataGridView_Specialization.Rows[currentMouseOverRow].Cells[0].Value.ToString();
                        DialogResult res = MessageBox.Show("Are you sure you want to delete?", "Delete confirmation",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (res == DialogResult.No)
                        {
                        }
                        else
                        {
                            this.cntrl.delete_specilization(Specializationid);
                            btnsavespecialization.Text = "Save";
                            specializationtextbox.Text = "";
                            Specializationid = "0";
                            Load_Specializations();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        public void Load_Specializations()
        {
            dataGridView_Specialization.RowHeadersVisible = false;
            dataGridView_Specialization.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
            dataGridView_Specialization.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView_Specialization.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView_Specialization.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView_Specialization.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView_Specialization.EnableHeadersVisualStyles = false;
            dataGridView_Specialization.RowCount = 0;
            DataTable dt_maintest = this.cntrl.load_specilization();
            int i = 0;
            while (i < dt_maintest.Rows.Count)
            {
                try
                {
                    dataGridView_Specialization.Rows.Add(dt_maintest.Rows[i]["id"].ToString(), i, dt_maintest.Rows[i]["name"].ToString());
                    i++;
                    dataGridView_Specialization.Rows[dataGridView_Specialization.Rows.Count - 1].Cells[1].Value = i;
                    dataGridView_Specialization.Rows[dataGridView_Specialization.Rows.Count - 1].Cells[3].Value = PappyjoeMVC.Properties.Resources.editicon;
                    dataGridView_Specialization.Rows[dataGridView_Specialization.Rows.Count - 1].Cells[4].Value = PappyjoeMVC.Properties.Resources.deleteicon;
                    dataGridView_Specialization.Rows[i - 1].Height = 25;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            if (cancel.Text == "Close")
                this.Close();
            else if (cancel.Text == "Cancel")
            {
                if (frameid == "1")
                {
                    textBox_services.Clear();
                    button_services.Text = "Save";
                    cancel.Text = "Close";
                }
                if (frameid == "2")
                {
                    textBox_degree.Clear();
                    button_degree.Text = "Save";
                    cancel.Text = "Close";
                }
                if (frameid == "3")
                {
                    textBox_college.Clear();
                    button_college.Text = "Save";
                    cancel.Text = "Close";
                }
                if (frameid == "4")
                {
                    textBox_membership.Clear();
                    button_membership.Text = "Save";
                    cancel.Text = "Close";
                }
                if (frameid == "5")
                {
                    textBox_council.Clear();
                    button_council.Text = "Save";
                    cancel.Text = "Close";
                }
                if (frameid == "6")
                {
                    specializationtextbox.Clear();
                    btnsavespecialization.Text = "Save";
                    cancel.Text = "Close";
                }
            }
        }
    }
}
