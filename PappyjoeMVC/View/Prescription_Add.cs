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
    public partial class Prescription_Add : Form,Prescription_Add_interface
    {
        Prescription_Add_controller cntrl;
        public string patient_id = "", prescription_id = "";
        public string doctor_id = "";
        string buttoncaption = "";
        int presid;
        string Patient_mobile = "99999999";
        string Prescription_bill_status = "No";
        string id1, idtemp, food = "", drug_type = "";
        public Prescription_Add()
        {
            InitializeComponent();
        }
        public void SetController(Prescription_Add_controller controller)
        {
            cntrl = controller;
        }

        private void drugbutton_Click(object sender, EventArgs e)
        {
            richTxtInsrtuction.Visible = false;
            drugspanel.Show();
            dataGridView2.Hide();
            templatepanel1.Hide();
            presdruggrid.Show();
            panel_adddrug.Show();
            panel_addtemplate.Hide();
            dataGridView_drugnew.Show();
            dataGridView_templatenew.Hide();
            drugbutton.BackColor = Color.FromArgb(224, 224, 224);
            templatebutton.BackColor = Color.White;
            label34.Visible = false;
            label33.Visible = false;
            drugnametextbox.Visible = false;
            drugtypecombo.Visible = false;
            strengthnot.Visible = false;
            strengthgrcombo.Visible = false;
            BtnSaveDrug.Visible = false;
            labelinstructions.Visible = false;
            textinstructions.Visible = false;
            BtnAddDrug.Text = "Add Drug";
            BtnAddDrug.BackColor = Color.LimeGreen;
            savebut.Text = "SAVE PRESCRIPTION";
        }

        private void templatebutton_Click(object sender, EventArgs e)
        {
            panel9.Visible = true;
            presdruggrid.Hide();
            panel_adddrug.Hide();
            dataGridView_templatenew.Hide();
            templatepanel1.Hide();
            dataGridView_drugnew.Show();
            panel_addtemplate.Show();
            dataGridView2.Show();
            drugspanel.Show();
            DataTable dt2 = this.cntrl.load_template();
            dataGridView2.DataSource = dt2;
            drugbutton.BackColor = Color.White;
            templatebutton.BackColor = Color.FromArgb(224, 224, 224);
        }

        private void BtnAddDrug_Click(object sender, EventArgs e)
        {
            if (BtnAddDrug.Text == "Add Drug")
            {
                label34.Visible = true;
                label33.Visible = true;
                drugnametextbox.Visible = true;
                drugtypecombo.Visible = true;
                strengthnot.Visible = true;
                strengthgrcombo.Visible = true;
                BtnSaveDrug.Visible = true;
                labelinstructions.Visible = true;
                textinstructions.Visible = true;
                BtnAddDrug.Text = "Cancel";
                BtnAddDrug.BackColor = Color.Tomato;
                panel_adddrug.Height = 101;
                searchtext1.Hide();
                presdruggrid.Anchor = (AnchorStyles.Top | AnchorStyles.Left);
            }
            else
            {
                label34.Visible = false;
                label33.Visible = false;
                drugnametextbox.Visible = false;
                drugtypecombo.Visible = false;
                strengthnot.Visible = false;
                strengthgrcombo.Visible = false;
                labelinstructions.Visible = false;
                textinstructions.Visible = false;
                BtnSaveDrug.Visible = false;
                BtnAddDrug.Text = "Add Drug";
                BtnAddDrug.BackColor = Color.LimeGreen;
                panel_adddrug.Height = 101;
                searchtext1.Show();
                presdruggrid.Anchor = (AnchorStyles.Top | AnchorStyles.Left);
            }
        }

        private void BtnSaveDrug_Click(object sender, EventArgs e)
        {
            insertdrug();
        }
        public void insertdrug()
        {
            try
            {
                string checkdataname = this.cntrl.check_drugname(drugnametextbox.Text);
                if (checkdataname!="")
                {
                    MessageBox.Show("Drug " + drugnametextbox.Text + "' already exist", "Duplication Encountered", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (drugnametextbox.Text != "")
                    {
                        this.cntrl.Save_Drug(drugnametextbox.Text, drugtypecombo.Text, strengthgrcombo.Text, strengthnot.Text, textinstructions.Text);
                        DataTable dt4 = this.cntrl.drug_load();
                        string strstock = "";
                        presdruggrid.ColumnCount = 3;
                        presdruggrid.Rows.Clear();
                        presdruggrid.Columns[0].Name = "ID";
                        presdruggrid.Columns[1].Name = "DRUG";
                        presdruggrid.Columns[2].Name = "STOCK";
                        for (int j = 0; j < dt4.Rows.Count; j++)
                        {
                            if (dt4.Rows[j]["inventory_id"].ToString() == "0")
                            {
                                strstock = "(Not sold)";
                            }
                            else
                            {
                                strstock = "(Not sold)";
                                DataTable dtstock = this.cntrl.Get_Stock(dt4.Rows[j]["inventory_id"].ToString());
                                if (dtstock.Rows.Count > 0)
                                {
                                    if (Convert.ToInt16(dtstock.Rows[0]["stock"].ToString()) > 0)
                                    {
                                        strstock = "(In stock)";
                                    }
                                    else
                                    {
                                        strstock = "(Out-of-stock)";
                                    }
                                }
                            }
                            presdruggrid.Rows.Add(dt4.Rows[j]["id"].ToString(), dt4.Rows[j]["name"].ToString(), dt4.Rows[j]["type"].ToString() + "  " + strstock);
                            if (strstock == "(Not sold)")
                            { presdruggrid.Rows[j].Cells[2].Style.ForeColor = Color.Red; }
                            else if (strstock == "(Out-of-stock)")
                            { presdruggrid.Rows[j].Cells[2].Style.ForeColor = Color.Blue; }
                            presdruggrid.Rows[j].Cells[2].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                        }
                        // End
                        panel9.Visible = true;
                        label34.Visible = false;
                        label33.Visible = false;
                        drugnametextbox.Visible = false;
                        drugtypecombo.Visible = false;
                        strengthnot.Visible = false;
                        strengthgrcombo.Visible = false;
                        labelinstructions.Visible = false;
                        textinstructions.Visible = false;
                        BtnSaveDrug.Visible = false;
                        BtnAddDrug.Text = "Add Drug";
                        BtnAddDrug.BackColor = Color.LimeGreen;
                        panel_adddrug.Height = 101;
                        searchtext1.Text = "Search";
                        searchtext1.Show();
                        presdruggrid.Height = 437;
                        presdruggrid.Visible = true;
                        drugnametextbox.Text = "";
                        drugtypecombo.Text = "";
                        strengthnot.Text = "";
                        strengthgrcombo.Text = "";
                        textinstructions.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Enter the drug name and strength...", "Data Required..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void searchtext1_Click(object sender, EventArgs e)
        {
            searchtext1.Clear();
        }

        private void searchtext1_KeyUp(object sender, KeyEventArgs e)
        {
            DataTable dt4 = this.cntrl.drug_search(searchtext1.Text);
            string strstock = "";
            presdruggrid.ColumnCount = 3;
            presdruggrid.Rows.Clear();
            presdruggrid.Columns[0].Name = "ID";
            presdruggrid.Columns[1].Name = "DRUG";
            presdruggrid.Columns[2].Name = "STOCK";
            presdruggrid.Columns[0].Visible = false;
            presdruggrid.Columns[1].Width = 200;
            presdruggrid.Columns[2].Width = 150;
            for (int j = 0; j < dt4.Rows.Count; j++)
            {
                if (dt4.Rows[j]["inventory_id"].ToString() == "0")
                {
                    strstock = "(Not sold)";
                }
                else
                {
                    strstock = "(Not sold)";
                    DataTable dtstock = this.cntrl.drug_instock(dt4.Rows[j]["inventory_id"].ToString());
                    if (dtstock.Rows.Count > 0)
                    {
                        string dou_stock = dtstock.Rows[0]["Stock"].ToString();
                        if (dou_stock != "")
                        {
                            strstock = "(In stock)";
                        }
                        else
                        {
                            strstock = "(Out-of-stock)";
                        }
                    }
                }
                presdruggrid.Rows.Add(dt4.Rows[j]["id"].ToString(), dt4.Rows[j]["name"].ToString(), dt4.Rows[j]["type"].ToString() + "  " + strstock);
                if (strstock == "(Not sold)")
                { presdruggrid.Rows[j].Cells[2].Style.ForeColor = Color.Red; }
                else if (strstock == "(Out-of-stock)")
                { presdruggrid.Rows[j].Cells[2].Style.ForeColor = Color.Blue; }
                presdruggrid.Rows[j].Cells[2].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dataGridView_drugnew.Show();
                dataGridView_templatenew.Hide();
                int r = e.RowIndex;
                idtemp = dataGridView2.Rows[r].Cells[0].Value.ToString();
                DataTable dt = this.cntrl.get_template(idtemp);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    try
                    {
                        dataGridView_drugnew.Rows.Add(dt.Rows[i]["drug_name"].ToString(), dt.Rows[i]["strength"].ToString(), dt.Rows[i]["strength_gr"].ToString(), dt.Rows[i]["duration"].ToString(), dt.Rows[i]["duration_period"].ToString(), dt.Rows[i]["morning"].ToString(), dt.Rows[i]["noon"].ToString(), dt.Rows[i]["night"].ToString(), dt.Rows[i]["food"].ToString(), dt.Rows[i]["add_instruction"].ToString(), dt.Rows[i]["drug_id"].ToString(), dt.Rows[i]["drug_type"].ToString());
                        dataGridView_drugnew.Rows[dataGridView_drugnew.Rows.Count - 1].Cells[12].Value = PappyjoeMVC.Properties.Resources.deleteicon;
                        dataGridView_drugnew.Rows[dataGridView_drugnew.Rows.Count - 1].Height = 30;
                        img.ImageLayout = DataGridViewImageCellLayout.Normal;
                        dataGridView_drugnew.Rows[dataGridView_drugnew.Rows.Count - 1].Cells[13].Value = dt.Rows[i]["status"].ToString();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addtemplatebut_Click(object sender, EventArgs e)
        {
            richTxtTempInstruction.Visible = false;
            dataGridView_drugnew.Hide();
            dataGridView_templatenew.Show();
            drugspanel.Hide();
            templatepanel1.Show();
            dataGridView2.Hide();
            presdruggrid.Show();
            savebut.Text = "SAVE TEMPLATE";
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (drugnametext.Text != "")
                {
                    string dur = "";
                    food = "";
                    if (radioButtonBfrFood.Checked)
                    {
                        food = radioButtonBfrFood.Text.ToString();
                    }
                    else if (radioButtonAftrFood.Checked)
                    {
                        food = radioButtonAftrFood.Text.ToString();
                    }
                    if (cmbDuration.Text == "")
                    {
                        dur = "Period Not mentioned";
                    }
                    else
                    {
                        dur = cmbDuration.Text;
                    }
                    string strstatus = "1";
                    if (checkBoxShowTime.Checked == true)
                    {
                        strstatus = "1";
                    }
                    else
                    {
                        strstatus = "0";
                    }
                    string Note = "";
                    string NoteData = "";
                    NoteData = richTxtInsrtuction.Text;
                    Note = NoteData.Replace("'", " ");
                    dataGridView_drugnew.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView_drugnew.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView_drugnew.Rows.Add(drugnametext.Text, txtStrengthno.Text, strengthcombo.Text, numericUpDownDuration.Value, dur, numericUpDownMorning.Value, numericUpDownNoon.Value, numericUpDownNight.Value, food, Note, id1, drug_type);
                    dataGridView_drugnew.Rows[dataGridView_drugnew.Rows.Count - 1].Cells[12].Value = PappyjoeMVC.Properties.Resources.deleteicon;
                    dataGridView_drugnew.Rows[dataGridView_drugnew.Rows.Count - 1].Height = 30;
                    img.ImageLayout = DataGridViewImageCellLayout.Normal;
                    dataGridView_drugnew.Rows[dataGridView_drugnew.Rows.Count - 1].Cells[13].Value = strstatus;
                    richTxtInsrtuction.Text = "";
                    radioButtonAftrFood.Checked = false;
                    radioButtonBfrFood.Checked = false;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAddToList_Click(object sender, EventArgs e)
        {
            try
            {
                food = "";
                if (radioButtonTempBfrFood.Checked)
                {
                    food = radioButtonTempBfrFood.Text.ToString();
                }
                else if (radioButtonTempAftrFood.Checked)
                {
                    food = radioButtonTempAftrFood.Text.ToString();
                }
                string strstatus = "1";
                string Note = "";
                string NoteData = "";
                NoteData = richTxtTempInstruction.Text;
                Note = NoteData.Replace("'", " ");
                dataGridView_templatenew.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView_templatenew.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView_templatenew.Rows.Add(txtDrugName.Text, txttemplteStrugthNo.Text, cmbStrungthTemp.Text, numericUpDownTempDuration.Value, cmbTempDuration.Text, numericUpDownTempMorning.Value, numericUpDownTempNoon.Value, numericUpDownTempNight.Value, food, Note, id1, drug_type);
                dataGridView_templatenew.Rows[dataGridView_templatenew.Rows.Count - 1].Cells[12].Value = PappyjoeMVC.Properties.Resources.deleteicon;
                dataGridView_templatenew.Rows[dataGridView_templatenew.Rows.Count - 1].Height = 30;
                img1.ImageLayout = DataGridViewImageCellLayout.Normal;
                dataGridView_templatenew.Rows[dataGridView_templatenew.Rows.Count - 1].Cells[13].Value = strstatus;
                radioButtonTempBfrFood.Checked = false;
                radioButtonTempAftrFood.Checked = false;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView_drugnew_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView_drugnew.Rows.Count > 0)
                {
                    if (e.ColumnIndex == 12)
                    {
                        DialogResult res = MessageBox.Show("Are you sure you want to delete..?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (res == DialogResult.Yes)
                        {
                            dataGridView_drugnew.Rows.RemoveAt(this.dataGridView_drugnew.SelectedRows[0].Index);
                        }
                    }
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void BtnAddInstruction_Click(object sender, EventArgs e)
        {
            richTxtTempInstruction.Visible = true;
        }

        private void addinsbut_Click(object sender, EventArgs e)
        {
            richTxtInsrtuction.Visible = true;
        }

        private void dataGridView_templatenew_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView_templatenew.Rows.Count > 0)
                {
                    if (e.ColumnIndex == 12)
                    {
                        DialogResult res = MessageBox.Show("Are you sure you want to delete..?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (res == DialogResult.Yes)
                        {
                            dataGridView_templatenew.Rows.RemoveAt(this.dataGridView_templatenew.SelectedRows[0].Index);
                        }
                    }
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void savebut_Click(object sender, EventArgs e)
        {
            try
            {
                String d_id = "0";
                string dr_tb = this.cntrl.Get_DoctorId(cmbDoctor.Text);
                if (dr_tb!="")
                {
                    d_id = dr_tb.ToString();
                }
                else
                {
                    d_id = "0";
                }
                string strstatus = "1";
                if (savebut.Text == "SAVE PRESCRIPTION")
                {

                    if (dataGridView_drugnew.Rows.Count > 0)
                    {
                        prescription_check();
                        this.cntrl.save_prescriptionmain(patient_id, d_id, dateTimePicker1.Value.ToString("yyyy-MM-dd"), Prescription_bill_status, Txtnote.Text);
                        DataTable dt = this.cntrl.Maxid();
                        if (dt.Rows.Count > 0)
                        {
                            presid = Int32.Parse(dt.Rows[0][0].ToString());
                        }
                        else
                        {
                            presid = 1;
                        }
                        int count = dataGridView_drugnew.Rows.Count;
                        for (int i = 0; i < count; i++)
                        {
                            if (dataGridView_drugnew[13, i].Value.ToString() != "")
                            { strstatus = dataGridView_drugnew[13, i].Value.ToString(); }
                            this.cntrl.save_prescription(presid,patient_id, cmbDoctor.Text, d_id, dateTimePicker1.Value.ToString("yyyy-MM-dd"), dataGridView_drugnew[0, i].Value.ToString(), dataGridView_drugnew[1, i].Value.ToString(), dataGridView_drugnew[2, i].Value.ToString(), dataGridView_drugnew[3, i].Value.ToString(), dataGridView_drugnew[4, i].Value.ToString(), dataGridView_drugnew[5, i].Value.ToString(), dataGridView_drugnew[6, i].Value.ToString(), dataGridView_drugnew[7, i].Value.ToString(), dataGridView_drugnew[8, i].Value.ToString(), dataGridView_drugnew[9, i].Value.ToString(), dataGridView_drugnew[11, i].Value.ToString(), strstatus, dataGridView_drugnew[10, i].Value.ToString());
                        }
                        // Review
                        if (checkBoxReview.Checked == true)
                        {
                            this.cntrl.update_prescription_review(dateTimeReview.Value.ToString("yyyy-MM-dd HH:mm"), presid);
                            DataTable dt_review = this.cntrl.get_reviewId(patient_id, dateTimeReview.Value.ToString("yyyy-MM-dd HH:mm"));
                            if (dt_review.Rows.Count == 0)
                            {
                                this.cntrl.save_review(dateTimeReview.Value.ToString("yyyy-MM-dd HH:mm"), patient_id);
                                this.cntrl.save_appointment(dateTimeReview.Value.ToString("yyyy-MM-dd HH:mm"), patient_id, linkLabel_Name.Text, cmbDoctor.SelectedValue.ToString(), Patient_mobile, cmbDoctor.Text.ToString());
                            }
                        }
                        else
                        {
                            this.cntrl.update_prescription_review_NO(dateTimeReview.Value.ToString("yyyy-MM-dd HH:mm"), presid);
                        }
                        var form2 = new Prescription_Show();
                        form2.doctor_id = doctor_id;
                        form2.patient_id = patient_id;
                        Prescription_Show_controller controller = new Prescription_Show_controller(form2);
                        form2.Closed += (sender1, args) => this.Close();
                        this.Hide();
                        form2.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Select a Drugs...., Click 'Add' Button . and try again..", "Prescription Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BtnAdd.Focus();
                        timer1.Start();
                        timer1.Enabled = true;
                    }
                }
                else if (savebut.Text == "UPDATE PRESCRIPTION")
                {
                    if (dataGridView_drugnew.Rows.Count > 0)
                    {
                        prescription_check();
                        string dt0 = this.cntrl.Get_DoctorId(cmbDoctor.Text);
                        if (dt0!="")
                        {
                            this.cntrl.update_prescription_main(Txtnote.Text, Prescription_bill_status, prescription_id);
                            this.cntrl.delete_prescription(prescription_id);
                            int count = dataGridView_drugnew.Rows.Count;
                            for (int i = 0; i < count; i++)
                            {
                                if (dataGridView_drugnew[13, i].Value.ToString() != "")
                                { strstatus = dataGridView_drugnew[13, i].Value.ToString(); }
                                this.cntrl.save_prescription(Convert.ToInt32( prescription_id), patient_id, cmbDoctor.Text, dt0.ToString(), dateTimePicker1.Value.ToString("yyyy-MM-dd"), dataGridView_drugnew[0, i].Value.ToString(), dataGridView_drugnew[1, i].Value.ToString(), dataGridView_drugnew[2, i].Value.ToString(), dataGridView_drugnew[3, i].Value.ToString(), dataGridView_drugnew[4, i].Value.ToString(), dataGridView_drugnew[5, i].Value.ToString(), dataGridView_drugnew[6, i].Value.ToString(), dataGridView_drugnew[7, i].Value.ToString(), dataGridView_drugnew[8, i].Value.ToString(), dataGridView_drugnew[9, i].Value.ToString(), dataGridView_drugnew[11, i].Value.ToString(), strstatus, dataGridView_drugnew[10, i].Value.ToString());
                            }
                            savebut.Text = "SAVE PRESCRIPTION";
                            var form2 = new Prescription_Show();
                            form2.doctor_id = doctor_id;
                            form2.patient_id = patient_id;
                            Prescription_Show_controller controller = new Prescription_Show_controller(form2);
                            form2.Closed += (sender1, args) => this.Close();
                            this.Hide();
                            form2.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Choose a Doctor First...!!", "Empty Field", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Click on 'Add' Button (Below SAVE PRESCRIPTION) And Try Again..", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BtnAdd.Focus();
                        timer1.Start();
                        timer1.Enabled = true;
                    }
                }
                else if (savebut.Text == "SAVE TEMPLATE")
                {
                    int count = dataGridView_templatenew.Rows.Count;
                    if (tempnametext.Text != "" && count >= 1)
                    {
                        this.cntrl.save_template(tempnametext.Text);
                        string tempid = this.cntrl.get_templateid(tempnametext.Text);
                        for (int i = 0; i < count; i++)
                        {
                            this.cntrl.save_template(tempid, patient_id, linkLabel_Name.Text.ToString(), cmbDoctor.SelectedValue.ToString(), cmbDoctor.Text, dateTimePicker1.Value.ToString("yyyy-MM-dd"), dataGridView_templatenew[0, i].Value.ToString(), dataGridView_templatenew[1, i].Value.ToString(), dataGridView_templatenew[2, i].Value.ToString(), dataGridView_templatenew[3, i].Value.ToString(), dataGridView_templatenew[5, i].Value.ToString(), dataGridView_templatenew[6, i].Value.ToString(), dataGridView_templatenew[7, i].Value.ToString(), dataGridView_templatenew[8, i].Value.ToString(), dataGridView_templatenew[9, i].Value.ToString(), dataGridView_templatenew[11, i].Value.ToString(), dataGridView_templatenew[10, i].Value.ToString(), prescription_id, dataGridView_templatenew[4, i].Value.ToString(), dataGridView_templatenew[13, i].Value.ToString());
                        }
                        savebut.Text = buttoncaption;
                        templatebutton_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Please Enter the Template name and Drug(s)..!", "Empty field", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void prescription_check()
        {
            try
            {
                if (dataGridView_drugnew.Rows.Count > 0)
                {
                    int count = dataGridView_drugnew.Rows.Count;
                    for (int i = 0; i < count; i++)
                    {
                        DataTable dt4 = this.cntrl.get_inventoryid(dataGridView_drugnew[10, i].Value.ToString());
                        if (dt4.Rows.Count > 0)
                        {
                            Prescription_bill_status = "Yes";
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            var form2 = new Prescription_Show();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            Prescription_Show_controller controller = new Prescription_Show_controller(form2);
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            var form2 = new Patients();
            form2.doctor_id = doctor_id;
            Patients_controller controllr = new Patients_controller(form2);
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void toolStripButton13_Click(object sender, EventArgs e)
        {
            var form2 = new Communication();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void toolStripButton15_Click(object sender, EventArgs e)
        {
            var form2 = new Reports();
            form2.doctor_id = doctor_id;
            //Reports_controller controller = new Reports_controller(form2);
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void toolStripButton16_Click(object sender, EventArgs e)
        {
            var form2 = new Expense();
            form2.doctor_id = doctor_id;
            //expense_controller controller = new expense_controller(form2);
            form2.ShowDialog();
        }

        private void toolStripButton17_Click(object sender, EventArgs e)
        {
            if (PappyjoeMVC.Model.Connection.MyGlobals.loginType != "staff")
            {
                var form2 = new Doctor_Profile();
                form2.doctor_id = doctor_id;
                //doctor_controller controlr = new doctor_controller(form2);
                form2.Closed += (sender1, args) => this.Close();
                this.Hide();
                form2.ShowDialog();
            }
        }

        private void toolStripTextBox2_Click(object sender, EventArgs e)
        {
            toolStripTextBox2.Clear();
        }

        private void toolStripTextBox2_TextChanged(object sender, EventArgs e)
        {
            if (toolStripTextBox2.Text != "")
            {
                DataTable dtdr = this.cntrl.Patient_search(toolStripTextBox2.Text);
                listpatientsearch.DataSource = dtdr;
                listpatientsearch.DisplayMember = "patient";
                listpatientsearch.ValueMember = "id";
                if (listpatientsearch.Items.Count == 0)
                {
                    listpatientsearch.Visible = false;
                }
                else
                {
                    listpatientsearch.Visible = true;
                }
                listpatientsearch.Location = new Point(toolStrip2.Width - 352, 39);
            }
            else
            {
                listpatientsearch.Visible = false;
            }
        }

        private void listpatientsearch_MouseClick(object sender, MouseEventArgs e)
        {
            var form2 = new Patient_Profile_Details();
            form2.doctor_id = doctor_id;
            form2.patient_id = listpatientsearch.SelectedValue.ToString();
            listpatientsearch.Visible = false;
            Profile_Details_controller controller = new Profile_Details_controller(form2);
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (doctor_id != "1")
            {
                string id;
                id = this.cntrl.permission_for_settings(doctor_id);
                if (int.Parse(id) > 0)
                {
                    var form2 = new Practice_Details();
                    form2.doctor_id = doctor_id;
                    form2.Closed += (sender1, args) => this.Close();
                    this.Hide();
                    form2.ShowDialog();
                }
                else
                {
                    MessageBox.Show("There is No Privilege to Clinic Settings", "Security Role", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            else
            {
                var form2 = new Practice_Details();
                form2.doctor_id = doctor_id;
                form2.Closed += (sender1, args) => this.Close();
                this.Hide();
                form2.ShowDialog();
            }
        }

        private void toolStripButton19_Click(object sender, EventArgs e)
        {
            if (doctor_id != "1")
            {
                string id;
                id = this.cntrl.doctr_privillage_for_addnewPatient(doctor_id);
                if (int.Parse(id) > 0)
                {
                    MessageBox.Show("There is No Privilege to Add Patient", "Security Role", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    var form2 = new Add_New_Patients();
                    form2.doctor_id = doctor_id;
                    //Add_New_patient_controller controller = new Add_New_patient_controller(form2);
                    form2.Closed += (sender1, args) => this.Close();
                    this.Hide();
                    form2.ShowDialog();
                }
            }
            else
            {
                var form2 = new Add_New_Patients();
                form2.doctor_id = doctor_id;
                //Add_New_patient_controller controller = new Add_New_patient_controller(form2);
                form2.Closed += (sender1, args) => this.Close();
                this.Hide();
                form2.ShowDialog();
            }
        }

        private void linkLabel_Name_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var form2 = new PappyjoeMVC.View.Patient_Profile_Details();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            Profile_Details_controller ctr = new Profile_Details_controller(form2);
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void linkLabel_id_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var form2 = new PappyjoeMVC.View.Patient_Profile_Details();
            form2.doctor_id = doctor_id;
            form2.patient_id = linkLabel_id.Text;
            Profile_Details_controller ctr = new Profile_Details_controller(form2);
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            BtnAdd.BackColor = Color.ForestGreen;
        }

        private void searchtext2_Click(object sender, EventArgs e)
        {
            searchtext2.Clear();
        }

        private void searchtext2_KeyUp(object sender, KeyEventArgs e)
        {
            DataTable dt2 = this.cntrl.search_template(searchtext2.Text);
            dataGridView2.DataSource = dt2;
        }

        private void presdruggrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (panel_addtemplate.Visible != true)
                {
                    dataGridView_drugnew.Show();
                    dataGridView_templatenew.Hide();
                    drugspanel.Visible = true;
                    richTxtInsrtuction.Visible = false;
                    drugspanel.Show();
                    int r = e.RowIndex;
                    id1 = presdruggrid.Rows[r].Cells[0].Value.ToString();
                    DataTable dt = this.cntrl.ge_drug(id1);
                    if (dt.Rows.Count > 0)
                    {
                        drugnametext.Text = dt.Rows[0]["name"].ToString();
                        txtStrengthno.Text = dt.Rows[0]["strength_gr"].ToString();
                        strengthcombo.Text = dt.Rows[0]["strength"].ToString();
                        drug_type = dt.Rows[0][3].ToString();
                        richTxtInsrtuction.Hide();
                        richTxtInsrtuction.Text = "";
                        richTxtInsrtuction.Text = dt.Rows[0]["instructions"].ToString();
                    }
                }
                else
                {
                    dataGridView_drugnew.Hide();
                    dataGridView_templatenew.Show();
                    drugspanel.Hide();
                    templatepanel1.Show();
                    int r = e.RowIndex;
                    id1 = presdruggrid.Rows[r].Cells[0].Value.ToString();
                    DataTable dt = this.cntrl.ge_drug(id1);
                    if (dt.Rows.Count > 0)
                    {
                        txtDrugName.Text = dt.Rows[0][0].ToString();
                        txttemplteStrugthNo.Text = dt.Rows[0][2].ToString();
                        cmbStrungthTemp.Text = dt.Rows[0][1].ToString();
                        drug_type = dt.Rows[0][3].ToString();
                    }
                    richTxtInsrtuction.Hide();
                    richTxtInsrtuction.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PrescriptionAdd_Load(object sender, EventArgs e)
        {
            try
            {
                toolStripButton18.ToolTipText = PappyjoeMVC.Model.Global_Variables.Version;
                DataTable clinicname = this.cntrl.Get_CompanyNAme();
                if (clinicname.Rows.Count > 0)
                {
                    string clinicn = "";
                    clinicn = clinicname.Rows[0]["name"].ToString();
                    toolStripButton10.Text = clinicn.Replace("¤", "'");
                }
                listpatientsearch.Hide();
                dataGridView_drugnew.Show();
                dataGridView_templatenew.Hide();
                drugspanel.Show();
                drugnametext.Text = ""; 
                txtDrugName.Text = "";
                DataTable patient = this.cntrl.Get_patient_id_name_gender(patient_id);
                if (patient.Rows.Count > 0)
                {
                    linkLabel_Name.Text = patient.Rows[0][0].ToString();
                    linkLabel_id.Text = patient.Rows[0][1].ToString();
                    Patient_mobile = patient.Rows[0][4].ToString();
                }
                string docnam = this.cntrl.Get_DoctorName(doctor_id);
                if (docnam != "")
                {
                    toolStripTextDoctor.Text = "Logged In As : " + docnam;
                }
                DataTable dt3 = this.cntrl.get_all_doctorname();
                cmbDoctor.DataSource = dt3;
                cmbDoctor.DisplayMember = "doctor_name";
                cmbDoctor.ValueMember = "id";
                if (cmbDoctor.Items.Count > 1)
                {
                    cmbDoctor.SelectedIndex = 0;
                }
                DataTable dt = this.cntrl.Fill_unit_combo();
                strengthcombo.DataSource = dt;
                strengthcombo.DisplayMember = "name";
                strengthcombo.ValueMember = "id";
                if (strengthcombo.Items.Count > 1)
                {
                    strengthcombo.SelectedIndex = 0;
                }
                cmbStrungthTemp.DataSource = dt;
                cmbStrungthTemp.DisplayMember = "name";
                cmbStrungthTemp.ValueMember = "id";
                if (cmbStrungthTemp.Items.Count > 1)
                {
                    cmbStrungthTemp.SelectedIndex = 0;
                }
                DataTable RsDrugType = this.cntrl.fill_type_combo();  
                drugtypecombo.DataSource = RsDrugType;
                drugtypecombo.DisplayMember = "dr_type";
                drugtypecombo.ValueMember = "id";
                if (drugtypecombo.Items.Count > 1)
                {
                    drugtypecombo.SelectedIndex = 0;
                }
                cmbTempDuration.SelectedIndex = 0;
                cmbDuration.SelectedIndex = 0;
                if (prescription_id != "")
                {
                    drugspanel.Show();
                    savebut.Text = "UPDATE PRESCRIPTION";
                    buttoncaption = "UPDATE PRESCRIPTION";
                    DataTable dt_prescription_main = this.cntrl.getPrescriptionMain(prescription_id, patient_id);
                    if (dt_prescription_main.Rows.Count > 0)
                    {
                        dateTimePicker1.Value = Convert.ToDateTime(dt_prescription_main.Rows[0]["date"].ToString());
                        int index = cmbDoctor.FindString(Convert.ToString(dt_prescription_main.Rows[0]["doctor_name"].ToString()));
                        if (index >= 0)
                        {
                            cmbDoctor.SelectedIndex = index;
                        }
                        else
                        {
                            cmbDoctor.SelectedIndex = 0;
                        }
                        Txtnote.Text = Convert.ToString(dt_prescription_main.Rows[0]["notes"].ToString());
                    }
                    DataTable dt1 = this.cntrl.get_prescription_Data(prescription_id, patient_id);
                    int i = 0;
                    while (i < dt1.Rows.Count)
                    {
                        try
                        {
                            dataGridView_drugnew.Rows.Add(dt1.Rows[i][6].ToString(), dt1.Rows[i][7].ToString(), dt1.Rows[i][16].ToString(), dt1.Rows[i][8].ToString(), dt1.Rows[i][9].ToString(), dt1.Rows[i][10].ToString(), dt1.Rows[i][11].ToString(), dt1.Rows[i][12].ToString(), dt1.Rows[i][13].ToString(), dt1.Rows[i][14].ToString(), dt1.Rows[i][18].ToString(), dt1.Rows[i][15].ToString(), "", dt1.Rows[i]["status"].ToString());
                            i++;
                            dataGridView_drugnew.Rows[dataGridView_drugnew.Rows.Count - 1].Cells[12].Value = PappyjoeMVC.Properties.Resources.deleteicon;
                            dataGridView_drugnew.Rows[dataGridView_drugnew.Rows.Count - 1].Height = 30;
                            img.ImageLayout = DataGridViewImageCellLayout.Normal;
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    buttoncaption = "SAVE PRESCRIPTION";
                }
                templatepanel1.Visible = false;
                label34.Visible = false;
                label33.Visible = false;
                drugnametextbox.Visible = false;
                drugtypecombo.Visible = false;
                strengthnot.Visible = false;
                strengthgrcombo.Visible = false;
                BtnSaveDrug.Visible = false;
                panel_addtemplate.Hide();
                DataTable dt4 = this.cntrl.drug_load();
                string strstock = "";
                presdruggrid.Columns.Add("id", "xt");
                presdruggrid.Columns.Add("drug", "xt");
                presdruggrid.Columns.Add("stock", "xt");
                presdruggrid.Columns[0].Visible = false;
                presdruggrid.Columns[1].Width = 200;
                presdruggrid.Columns[2].Width = 150;
                presdruggrid.Columns[3].Visible = false;
                for (int j = 0; j < dt4.Rows.Count; j++)
                    presdruggrid.Columns[4].Visible = false;
                for (int j = 0; j < dt4.Rows.Count; j++)
                {
                    if (dt4.Rows[j]["inventory_id"].ToString() == "0")
                    {
                        strstock = "(Not sold)";
                    }
                    else
                    {
                        strstock = "(Not sold)";
                        DataTable dtstock = this.cntrl.drug_instock(dt4.Rows[j]["inventory_id"].ToString());
                        if (dtstock.Rows.Count > 0)
                        {
                            string dou_stock = dtstock.Rows[0]["Stock"].ToString();
                            if (dou_stock != "")
                            {
                                strstock = "(In stock)";
                            }
                            else
                            {
                                strstock = "(Out-of-stock)";
                            }
                        }
                    }
                    presdruggrid.Rows.Add(dt4.Rows[j]["id"].ToString(), dt4.Rows[j]["name"].ToString(), dt4.Rows[j]["type"].ToString() + "  " + strstock);
                    if (strstock == "(Not sold)")
                    { presdruggrid.Rows[j].Cells[2].Style.ForeColor = Color.Red; }
                    else if (strstock == "(Out-of-stock)")
                    { presdruggrid.Rows[j].Cells[2].Style.ForeColor = Color.Blue; }
                    presdruggrid.Rows[j].Cells[2].Style.Alignment = DataGridViewContentAlignment.MiddleRight; 
                }
                DataTable dt2 = this.cntrl.load_template();
                dataGridView2.DataSource = dt2;
                if (doctor_id != "")
                {
                    int dr_index = 0;
                    DataTable dt1 = this.cntrl.get_all_doctorname();
                    if (dt.Rows.Count > 0)
                    {
                        cmbDoctor.DataSource = dt1;
                        cmbDoctor.DisplayMember = "doctor_name";
                        cmbDoctor.ValueMember = "id";
                        for (int j = 0; j < dt1.Rows.Count; j++)
                        {
                            if (dt1.Rows[j]["id"].ToString() == doctor_id)
                            {
                                dr_index = j;
                            }
                        }
                        cmbDoctor.SelectedIndex = dr_index;
                    }
                }
                else
                {
                    DataTable dt1 = this.cntrl.get_all_doctorname();
                    if (dt1.Rows.Count > 0)
                    {
                        cmbDoctor.DataSource = dt1;
                        cmbDoctor.DisplayMember = "doctor_name";
                        cmbDoctor.ValueMember = "id";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
