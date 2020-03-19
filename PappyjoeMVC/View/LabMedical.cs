using PappyjoeMVC.Controller;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PappyjoeMVC.View
{
    public partial class LabMedical : Form
    {
        LabMedical_controller cntrl = new LabMedical_controller();
        public string doctor_id;
        int check = 0;
        int flag;
        string id;
        int grid_data_id = 0;
        int grid_id = 1;
        int indexRow;

        public LabMedical()
        {
            InitializeComponent();
        }

        public void Fill_dgvMainTest(DataTable dtb)
        {
            dgvLabMaster.Rows.Clear();
            if (dtb.Rows.Count > 0)
            {
                int j = 1;
                for (int i = 0; i < dtb.Rows.Count; i++)
                {
                    dgvLabMaster.Rows.Add();
                    dgvLabMaster.Rows[i].Cells["mtid"].Value = dtb.Rows[i]["id"].ToString();
                    dgvLabMaster.Rows[i].Cells["Slno"].Value = j;
                    dgvLabMaster.Rows[i].Cells["maintest"].Value = dtb.Rows[i]["Main_test"].ToString();
                    dgvLabMaster.Rows[i].Cells["editmtest"].Value = PappyjoeMVC.Properties.Resources.editicon;
                    dgvLabMaster.Rows[i].Cells["cldelet"].Value = PappyjoeMVC.Properties.Resources.deleteicon;
                    j = j + 1;
                }
            }
        }
        public void fill_TestType(DataTable dtb)
        {
            dtgTestType.Rows.Clear();
            if (dtb.Rows.Count > 0)
            {
                int j = 1;
                for (int i = 0; i < dtb.Rows.Count; i++)
                {
                    dtgTestType.Rows.Add();
                    dtgTestType.Rows[i].Cells["testtypeId"].Value = dtb.Rows[i]["id"].ToString();
                    dtgTestType.Rows[i].Cells["tySlno"].Value = j;
                    dtgTestType.Rows[i].Cells["testtype"].Value = dtb.Rows[i]["Test Type"].ToString();
                    dtgTestType.Rows[i].Cells["tyedit"].Value = PappyjoeMVC.Properties.Resources.editicon;
                    dtgTestType.Rows[i].Cells["Delete"].Value = PappyjoeMVC.Properties.Resources.deleteicon;
                    j = j + 1;
                }
            }
        }
        public void fill_Unit(DataTable dtb)
        {
            dgvUnit.Rows.Clear();
            if (dtb.Rows.Count > 0)
            {
                int j = 1;
                for (int i = 0; i < dtb.Rows.Count; i++)
                {
                    dgvUnit.Rows.Add();
                    dgvUnit.Rows[i].Cells["unitid"].Value = dtb.Rows[i]["id"].ToString();
                    dgvUnit.Rows[i].Cells["Uslno"].Value = j;
                    dgvUnit.Rows[i].Cells["unitname"].Value = dtb.Rows[i]["Unit"].ToString();
                    dgvUnit.Rows[i].Cells["unitedit"].Value = PappyjoeMVC.Properties.Resources.editicon;
                    dgvUnit.Rows[i].Cells["dltunit"].Value = PappyjoeMVC.Properties.Resources.deleteicon;
                    j = j + 1;
                }
            }
        }
        public void fill_Test(DataTable dtb)
        {
            dgvTest.Rows.Clear();
            if (dtb.Rows.Count > 0)
            {
                int j = 1;
                for (int i = 0; i < dtb.Rows.Count; i++)
                {
                    dgvTest.Rows.Add();
                    dgvTest.Rows[i].Cells["testid"].Value = dtb.Rows[i]["id"].ToString();
                    dgvTest.Rows[i].Cells["testslno"].Value = j;
                    dgvTest.Rows[i].Cells["testName"].Value = dtb.Rows[i]["test"].ToString();
                    dgvTest.Rows[i].Cells["Type"].Value = dtb.Rows[i]["Test_Type"].ToString();
                    dgvTest.Rows[i].Cells["NVMale"].Value = dtb.Rows[i]["NormalValueM"].ToString();
                    dgvTest.Rows[i].Cells["NVFemale"].Value = dtb.Rows[i]["NormalValueF"].ToString();
                    dgvTest.Rows[i].Cells["Unit"].Value = dtb.Rows[i]["Unit"].ToString();
                    dgvTest.Rows[i].Cells["dlttest"].Value = PappyjoeMVC.Properties.Resources.editicon;
                    dgvTest.Rows[i].Cells["Deletetest"].Value = PappyjoeMVC.Properties.Resources.deleteicon;
                    j = j + 1;
                }
            }
        }
        public void fill_Template(DataTable dtb)
        {
            dgvtemplateadd.Rows.Clear();
            if (dtb.Rows.Count > 0)
            {
                int j = 1;
                for (int i = 0; i < dtb.Rows.Count; i++)
                {
                    dgvtemplateadd.Rows.Add();
                    dgvtemplateadd.Rows[i].Cells["idd"].Value = dtb.Rows[i]["id"].ToString();
                    dgvtemplateadd.Rows[i].Cells["ttpslno"].Value = j;
                    dgvtemplateadd.Rows[i].Cells["ttpName"].Value = dtb.Rows[i]["TemplateName"].ToString();
                    dgvtemplateadd.Rows[i].Cells["edittmp"].Value = PappyjoeMVC.Properties.Resources.editicon;
                    dgvtemplateadd.Rows[i].Cells["deletetmp"].Value = PappyjoeMVC.Properties.Resources.deleteicon;
                    j = j + 1;
                }
            }
        }

        private void LabMedical_Load(object sender, EventArgs e)
        {
            try
            {
                pnlAddtemplate.Location = new Point(3, 13);
                pnl2.Hide();
                btnCancl.Hide();
                btncaclty.Hide();
                btntestcancel.Hide();
                btncanclunit.Hide();
                btnCancel.Hide();
                DataTable dt= this.cntrl.Main_test_Dgv();
                Fill_dgvMainTest(dt);
                this.dgvLabMaster.Columns[1].Visible = false;

                DataTable tbTesttype = this.cntrl.fill_TestType();
                cmbTesttype.DisplayMember = "Name";
                cmbTesttype.ValueMember = "id";
                cmbTesttype.DataSource = tbTesttype;

                DataTable tbUnit = this.cntrl.fill_Unit();
                cmbUnit.Items.Insert(0, "<select>");
                cmbUnit.DisplayMember = "Name";
                cmbUnit.ValueMember = "id";
                cmbUnit.DataSource = tbUnit;

                DataTable tbMaintesttemp = this.cntrl.fill_Test();
                cmbmaintesttemp.DisplayMember = "Main_test";
                cmbmaintesttemp.ValueMember = "id";
                cmbmaintesttemp.DataSource = tbMaintesttemp;

                DataTable tbtesttypetemp = this.cntrl.fill_TestType();
                cmbtesttypetmp.DisplayMember = "Name";
                cmbtesttypetmp.ValueMember = "id";
                cmbtesttypetmp.DataSource = tbtesttypetemp;

                dgvLabMaster.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
                dgvLabMaster.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgvLabMaster.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9, FontStyle.Regular);
                dgvLabMaster.EnableHeadersVisualStyles = false;
                foreach (DataGridViewColumn cl in dgvLabMaster.Columns)
                {
                    cl.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                dtgTestType.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
                dtgTestType.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dtgTestType.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9, FontStyle.Regular);
                dtgTestType.EnableHeadersVisualStyles = false;
                foreach (DataGridViewColumn cl in dtgTestType.Columns)
                {
                    cl.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                dgvUnit.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
                dgvUnit.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgvUnit.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9, FontStyle.Regular);
                dgvUnit.EnableHeadersVisualStyles = false;
                foreach (DataGridViewColumn cl in dgvUnit.Columns)
                {
                    cl.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                dgvTest.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
                dgvTest.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgvTest.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9, FontStyle.Regular);
                dgvTest.EnableHeadersVisualStyles = false;
                foreach (DataGridViewColumn cl in dgvTest.Columns)
                {
                    cl.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                dgvtemplateadd.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
                dgvtemplateadd.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgvtemplateadd.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9, FontStyle.Regular);
                dgvtemplateadd.EnableHeadersVisualStyles = false;
                foreach (DataGridViewColumn cl in dgvtemplateadd.Columns)
                {
                    cl.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                dgvtempitem.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
                dgvtempitem.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgvtempitem.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9, FontStyle.Regular);
                dgvtempitem.EnableHeadersVisualStyles = false;
                foreach (DataGridViewColumn cl in dgvtempitem.Columns)
                {
                    cl.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                rdbNvyes.Checked = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtMainTest.Text))
                {
                    string mystring = txtMainTest.Text;
                    txtMainTest.Text = mystring.Replace("'", " ");
                    if (btnsave.Text == "SAVE")
                    {
                        this.cntrl.Maintest_save(txtMainTest.Text);
                        MessageBox.Show("Successfully Saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        this.cntrl.Update_Main_test(txtMtid.Text, txtMainTest.Text);
                    }
                    DataTable dt = this.cntrl.Main_test_Dgv();
                    Fill_dgvMainTest(dt);
                    this.dgvLabMaster.Columns[1].Visible = false;
                }
                else
                {
                    MessageBox.Show("Laboratory Test data required", "Data Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                txtMainTest.Clear();
                txtMtid.Clear();
                btnCancl.Hide();
                btnsave.Text = "SAVE";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TpMainTest_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt= this.cntrl.tpMain_testtype();
                fill_TestType(dt);
                this.dtgTestType.Columns[0].Visible = false;

                DataTable dt1= this.cntrl.tpMain_unit();
                fill_Unit(dt1);
                this.dgvUnit.Columns[0].Visible = false;

                DataTable dt2= this.cntrl.tpMain_test();
                fill_Test(dt2);
                this.dgvTest.Columns[0].Visible = false;

                DataTable dt3= this.cntrl.tpMain_template();
                fill_Template(dt3);
                this.dgvtemplateadd.Columns[0].Visible = false;

                DataTable TEMPLATE_View = this.cntrl.Template_view();
                dgvTesttemplate.DataSource = TEMPLATE_View;
                this.dgvTesttemplate.Columns[2].Visible = false;

                //strt cmb boxes

                System.Data.DataTable tbTesttype = this.cntrl.fill_TestType();
                cmbTesttype.DisplayMember = "Name";
                cmbTesttype.ValueMember = "id";
                cmbTesttype.DataSource = tbTesttype;


                System.Data.DataTable tbUnit = this.cntrl.fill_Unit();
                cmbUnit.DisplayMember = "Name";
                cmbUnit.ValueMember = "id";
                cmbUnit.DataSource = tbUnit;


                System.Data.DataTable tbMaintesttemp = this.cntrl.fill_Test();
                cmbmaintesttemp.DisplayMember = "Main_test";
                cmbmaintesttemp.ValueMember = "id";
                cmbmaintesttemp.DataSource = tbMaintesttemp;

                System.Data.DataTable tbtesttypetemp = this.cntrl.fill_TestType();
                cmbtesttypetmp.DisplayMember = "Name";
                cmbtesttypetmp.ValueMember = "id";
                cmbtesttypetmp.DataSource = tbtesttypetemp;


                DataTable tbtesttemp = this.cntrl.tbtesttemp();
                cmbTesttemp.DisplayMember = "Name";
                cmbTesttemp.ValueMember = "id";
                cmbTesttemp.DataSource = tbtesttemp;

                //end combo box
                if (this.tabLabMasters.SelectedTab.Text == "Template")
                {
                    check = 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTesttype_save_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtTestType.Text))
                {
                    string mystring = txtTestType.Text;
                    txtTestType.Text = mystring.Replace("'", " ");
                    if (btnTesttype_save.Text == "SAVE")
                    {
                        this.cntrl.Save_Testtype(txtTestType.Text);

                        MessageBox.Show("Successfully Saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        this.cntrl.Update_testtype(txtTtypeid.Text, txtTestType.Text);
                        MessageBox.Show("Data updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    DataTable dt= this.cntrl.tpMain_testtype();
                    fill_TestType(dt);
                }
                else
                {
                    MessageBox.Show("Laboratory Type data not found", "Data Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                txtTestType.Clear();
                txtTtypeid.Clear();
                btncaclty.Hide();
                btnTesttype_save.Text = "SAVE";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSaveunit_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtUnitadd.Text))
                {
                    string mystring = txtUnitadd.Text;
                    txtUnitadd.Text = mystring.Replace("'", " ");

                    if (btnSaveunit.Text == "SAVE")
                    {
                        this.cntrl.SaveUnit(txtUnitadd.Text);
                        MessageBox.Show("Successfully Saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        this.cntrl.UpdateUnit(Convert.ToInt32(txtunitid.Text),txtUnitadd.Text);
                        MessageBox.Show("Data updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    DataTable dt= this.cntrl.tpMain_unit();
                    fill_Unit(dt);
                }
                else
                {
                    MessageBox.Show("Laboratory units not found", "Data Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                txtUnitadd.Clear();
                btncanclunit.Hide();
                btnSaveunit.Text = "SAVE";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSavetest_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtName.Text))
                {
                    string mystring = txtName.Text;
                    txtName.Text = mystring.Replace("'", " ");
                    if (btnSavetest.Text == "SAVE")
                    {
                        this.cntrl.SaveTest(txtName.Text, txtNVMale.Text, txtNVFemale.Text, Convert.ToInt32(cmbTesttype.SelectedValue), Convert.ToInt32(cmbUnit.SelectedValue));
                        MessageBox.Show("Successfully Saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        this.cntrl.Update_test(txtName.Text, Convert.ToInt32(cmbTesttype.SelectedValue), txtNVMale.Text, txtNVFemale.Text, Convert.ToInt32(cmbUnit.SelectedValue), Convert.ToInt32(txttestid.Text));
                        MessageBox.Show("Data updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                DataTable dt= this.cntrl.tpMain_test();
                fill_Test(dt);
                txtName.Clear();
                txttestid.Clear();
                txtNVFemale.Clear();
                txtNVMale.Clear();
                btnSavetest.Text = "SAVE";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnsavetmp_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnsavetmp.Text == "SAVE")
                {
                    if (!string.IsNullOrWhiteSpace(txttemp.Text))
                    {
                        this.cntrl.Tempname_save(txttemp.Text);
                        string id = this.cntrl.Get_Maxid();
                        DataTable test = this.cntrl.Get_test_byId(Convert.ToInt32(cmbTesttemp.SelectedValue));
                        DataTable Normavalue = this.cntrl.Normavalue(Convert.ToInt32(test.Rows[0][0].ToString()));
                        for (int r = 0; r < dgvtempitem.Rows.Count; r++)
                        {
                            string norm = "";
                            if (dgvtempitem.Rows[r].Cells[10].Value.ToString() == ",")
                            {
                                norm = "";
                            }
                            else
                            {
                                norm = dgvtempitem.Rows[r].Cells[10].Value.ToString();
                            }
                            this.cntrl.Insert_mediTemplate(Convert.ToInt32(id), Convert.ToInt32(dgvtempitem.Rows[r].Cells[7].Value.ToString()),dgvtempitem.Rows[r].Cells[8].Value.ToString()/*tests*/, dgvtempitem.Rows[r].Cells[4].Value, norm);
                        }
                        MessageBox.Show("Successfully Saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvtempitem.Rows.Clear();
                        pnl2.Hide();
                        pnlAddtemplate.Show();
                    }
                    else
                    {
                        MessageBox.Show("please enter template name", "Data Missing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    if (flag == 1)
                    {
                        this.cntrl.Update_temp_name(Convert.ToInt32(txtId.Text),txttemp.Text);
                    }
                    else
                    {
                        this.cntrl.Update_temp_Ids(Convert.ToInt32(cmbmaintesttemp.SelectedValue), Convert.ToInt32(cmbTesttemp.SelectedValue), Convert.ToInt32(txtId.Text));
                    }
                    MessageBox.Show(" Data updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                DataTable dt= this.cntrl.tpMain_template();
                fill_Template(dt);
                DataTable TEMPLATE_View = this.cntrl.Template_view();
                dgvTesttemplate.DataSource = TEMPLATE_View;
                txtId.Clear();
                txttemp.Clear();
                btnsavetmp.Text = "SAVE";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnadditems_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbTesttemp.Text=="")
                {
                    MessageBox.Show("Please add TEST against selected TEST TYPE", "Empty Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    //string test_name = "";\ 
                    DataTable testname = new DataTable();
                    DataTable Unitname = new DataTable();
                    string NormavalueM = "";
                    string NormavalueF = "";
                    DataTable test = new DataTable();
                    DataTable Normavalue = new DataTable();
                    DataTable Maintest = this.cntrl.TempAddItem_mainTest(cmbmaintesttemp.SelectedValue.ToString());
                    DataTable testtype = this.cntrl.TempAddItem_testtype(cmbtesttypetmp.SelectedValue.ToString());
                    if (cmbTesttemp.Text.ToString() != "")
                    {
                        testname = this.cntrl.TempAddItem_testname(cmbTesttemp.SelectedValue.ToString());
                    }
                    if (cmbTesttemp.Text.ToString() != "")
                    {
                        Unitname = this.cntrl.TempAddItem_unitname(cmbTesttemp.SelectedValue.ToString());
                    }
                    if (cmbTesttemp.Text.ToString() != "")
                    {
                        test = this.cntrl.TempAddItem_test(Convert.ToInt32(cmbTesttemp.SelectedValue));
                    }

                    if (test.Rows.Count > 0)
                    {
                        NormavalueM = this.cntrl.TempAddItem_normM(Convert.ToInt32(test.Rows[0][0].ToString()));
                        NormavalueF = this.cntrl.TempAddItem_normF(Convert.ToInt32(test.Rows[0][0].ToString()));
                        Normavalue = this.cntrl.TempAddItem_normal(Convert.ToInt32(test.Rows[0][0].ToString()));
                    }
                    if (grid_data_id != 0)
                    {
                        for (int Ro = 0; Ro < dgvtempitem.Rows.Count; Ro++)
                        {
                            if (Convert.ToInt16(dgvtempitem.Rows[Ro].Cells[13].Value.ToString()) == grid_data_id)
                            {
                                dgvtempitem.Rows[Ro].Cells[0].Value = "";
                                dgvtempitem.Rows[Ro].Cells[1].Value = Maintest.Rows[0][1].ToString();
                                if (testname.Rows.Count > 0)
                                {
                                    dgvtempitem.Rows[Ro].Cells[2].Value = testname.Rows[0][1].ToString();
                                    dgvtempitem.Rows[Ro].Cells[8].Value = testname.Rows[0][0].ToString();
                                }
                                dgvtempitem.Rows[Ro].Cells[3].Value = testtype.Rows[0][1].ToString();

                                dgvtempitem.Rows[Ro].Cells[4].Value = Unitname.Rows[0][0].ToString();
                                dgvtempitem.Rows[Ro].Cells[5].Value = NormavalueM;
                                dgvtempitem.Rows[Ro].Cells[6].Value = NormavalueF;
                                dgvtempitem.Rows[Ro].Cells[7].Value = Maintest.Rows[0][0].ToString();
                                dgvtempitem.Rows[Ro].Cells[9].Value = testtype.Rows[0][0].ToString();
                                dgvtempitem.Rows[Ro].Cells[10].Value = Normavalue.Rows[0][0].ToString();
                            }
                        }
                    }
                    if (btnadditems.Text == "ADD NEW")
                    {
                        //else
                        {
                            dgvtempitem.Rows.Add("", Maintest.Rows[0][1].ToString(), testname.Rows.Count > 0 ? testname.Rows[0][1].ToString() : "", testtype.Rows[0][1].ToString(), Unitname.Rows.Count > 0 ? Unitname.Rows[0][0].ToString() : "", NormavalueM, NormavalueF, Maintest.Rows[0][0].ToString(), testname.Rows.Count > 0 ? testname.Rows[0][0].ToString() : "", testtype.Rows[0][0].ToString(), Normavalue.Rows.Count > 0 ? Normavalue.Rows[0][0].ToString() : "");
                            grid_id = grid_id + 1;
                        }
                    }
                    else
                    {
                        dgvtempitem.Rows[indexRow].Cells[0].Value = "";
                        dgvtempitem.Rows[indexRow].Cells[1].Value = cmbmaintesttemp.Text.ToString();

                        dgvtempitem.Rows[indexRow].Cells[2].Value = cmbTesttemp.Text.ToString();//testname.Rows[0][1].ToString();
                        if (cmbTesttemp.Text == "")
                        {
                            dgvtempitem.Rows[indexRow].Cells[8].Value = null;
                        }
                        else
                        {
                            dgvtempitem.Rows[indexRow].Cells[8].Value = testname.Rows[0][0].ToString();//cmbTesttemp.Text.ToString();
                        }
                        dgvtempitem.Rows[indexRow].Cells[3].Value = cmbtesttypetmp.Text.ToString();
                        if (Unitname.Rows.Count > 0)
                        {
                            dgvtempitem.Rows[indexRow].Cells[4].Value = Unitname.Rows[0][0].ToString();
                        }
                        dgvtempitem.Rows[indexRow].Cells[5].Value = NormavalueM;
                        dgvtempitem.Rows[indexRow].Cells[6].Value = NormavalueF;
                        dgvtempitem.Rows[indexRow].Cells[7].Value = Maintest.Rows[0][0].ToString();
                        dgvtempitem.Rows[indexRow].Cells[9].Value = testtype.Rows[0][0].ToString();
                        if (Normavalue.Rows.Count > 0)
                        {
                            dgvtempitem.Rows[indexRow].Cells[10].Value = Normavalue.Rows[0][0].ToString();
                        }
                        btnadditems.Text = "ADD NEW";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            pnlAddtemplate.Show();
            pnlAddtemplate.Location = new Point(3, 13);
            pnl2.Hide();
        }

        private void dgvLabMaster_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                indexRow = e.RowIndex;
                if (indexRow != -1)
                {
                    DataGridViewRow row = dgvLabMaster.Rows[indexRow];
                    txtMtid.Text = dgvLabMaster.Rows[indexRow].Cells[1].Value.ToString();
                    txtMainTest.Text = dgvLabMaster.Rows[indexRow].Cells[2].Value.ToString();
                    if (e.ColumnIndex == 3)
                    {
                        DataTable MAIN_TEST = this.cntrl.MainTest_byId(Convert.ToInt32(txtMtid.Text));
                        txtMtid.Text = MAIN_TEST.Rows[0][0].ToString();
                        txtMainTest.Text = MAIN_TEST.Rows[0][1].ToString();
                        btnsave.Text = "UPDATE";
                        btnCancl.Show();
                    }
                    else if (e.ColumnIndex == 4)
                    {
                        string MAIN_TEST = this.cntrl.MainTest_countById(Convert.ToInt32(txtMtid.Text));
                        DialogResult res = MessageBox.Show("Are you sure you want to delete?", "Delete confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                        txtId.Clear();
                        txtMainTest.Clear();
                        if (res == DialogResult.No)
                        {
                        }
                        else
                        {
                            if (Convert.ToInt32(MAIN_TEST) > 0)
                            {
                                MessageBox.Show("Cannot Delete, this LabType already used in another part", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtId.Clear();
                                txtMainTest.Clear();
                            }
                            else
                            {
                                this.cntrl.delete_Maintest(id);
                                DataTable dt = this.cntrl.Main_test_Dgv();
                                Fill_dgvMainTest(dt);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvLabMaster_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int r = e.RowIndex;
                id = dgvLabMaster.Rows[r].Cells[1].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtgTestType_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int r = e.RowIndex;
                id = dtgTestType.Rows[r].Cells[0].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtgTestType_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                indexRow = e.RowIndex; // get the selected Row Index
                if (indexRow != -1)
                {
                    DataGridViewRow row = dtgTestType.Rows[indexRow];
                    txtTtypeid.Text = dtgTestType.Rows[indexRow].Cells[0].Value.ToString();
                    txtTestType.Text = dtgTestType.Rows[indexRow].Cells[2].Value.ToString();
                    if (e.ColumnIndex == 3)
                    {
                        DataTable TEST_TYPE = this.cntrl.Testtype_byID(Convert.ToInt32(txtTtypeid.Text));
                        txtTtypeid.Text = TEST_TYPE.Rows[0][0].ToString();
                        txtTestType.Text = TEST_TYPE.Rows[0][1].ToString();
                        btnTesttype_save.Text = "UPDATE";
                        btncaclty.Show();
                    }
                    else if (e.ColumnIndex == 4)
                    {
                        string MAIN_TEST = this.cntrl.testtype_countById(Convert.ToInt32(txtTtypeid.Text));
                        DialogResult res = MessageBox.Show("Are you sure you want to delete?", "Delete confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                        txtTestType.Text = "";
                        txtTtypeid.Text = "";
                        if (res == DialogResult.No)
                        {
                        }
                        else
                        {
                            if (Convert.ToInt32(MAIN_TEST) > 0)
                            {
                                MessageBox.Show("Cannot Delete, this LabType already used in another part ", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtTestType.Text = "";
                                txtTtypeid.Text = "";
                            }
                            else
                            {
                                this.cntrl.delete_testtype(id);
                                DataTable dt= this.cntrl.tpMain_testtype();
                                fill_TestType(dt);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvUnit_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int r = e.RowIndex;
                id = dgvUnit.Rows[r].Cells[0].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvUnit_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                indexRow = e.RowIndex; // get the selected Row Index
                if (indexRow != -1)
                {
                    DataGridViewRow row = dgvUnit.Rows[indexRow];
                    txtunitid.Text = dgvUnit.Rows[indexRow].Cells[0].Value.ToString();
                    txtUnitadd.Text = dgvUnit.Rows[indexRow].Cells[2].Value.ToString();
                    row.Cells[0].Value.ToString();
                    if (e.ColumnIndex == 3)
                    {
                        DataTable Unit = this.cntrl.Unit_byID(Convert.ToInt32(txtunitid.Text));
                        txtunitid.Text = Unit.Rows[0][0].ToString();
                        txtUnitadd.Text = Unit.Rows[0][1].ToString();
                        btnSaveunit.Text = "UPDATE";
                        btncanclunit.Show();
                    }
                    else if (e.ColumnIndex == 4)
                    {
                        string Unitcheck = this.cntrl.UnitCount_byID(Convert.ToInt32(txtunitid.Text));
                        DialogResult res = MessageBox.Show("Are you sure you want to delete?", "Delete confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                        txtunitid.Text = "";
                        txtUnitadd.Text = "";
                        if (res == DialogResult.No)
                        {
                        }
                        else
                        {
                            if (Convert.ToInt32(Unitcheck) > 0)
                            {
                                MessageBox.Show("Cannot Delete, this unit is already used in another part", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtunitid.Text = "";
                                txtUnitadd.Text = "";
                            }
                            else
                            {
                                this.cntrl.del_unit(id);
                                DataTable dt= this.cntrl.tpMain_unit();
                                fill_Unit(dt);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvTest_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int r = e.RowIndex;
                id = dgvTest.Rows[r].Cells[0].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvTest_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                indexRow = e.RowIndex; // get the selected Row Index
                if (indexRow != -1)
                {
                    DataGridViewRow row = dgvTest.Rows[indexRow];
                    txttestid.Text = dgvTest.Rows[indexRow].Cells["testid"].Value.ToString();
                    txtName.Text = dgvTest.Rows[indexRow].Cells["testName"].Value.ToString();
                    cmbTesttype.SelectedItem = dgvTest.Rows[indexRow].Cells["Type"].Value.ToString();
                    txtNVMale.Text = dgvTest.Rows[indexRow].Cells["NVMale"].Value.ToString();
                    txtNVFemale.Text = dgvTest.Rows[indexRow].Cells["NVFemale"].Value.ToString();
                    cmbUnit.SelectedItem = dgvTest.Rows[indexRow].Cells["Unit"].Value.ToString();
                    if (e.ColumnIndex == 7)
                    {
                        DataTable Test = this.cntrl.test_ByID(Convert.ToInt32(txttestid.Text));
                        txttestid.Text = Test.Rows[0][0].ToString();
                        txtName.Text = Test.Rows[0][1].ToString();
                        if (dgvTest.Rows[indexRow].Cells["Type"].Value.ToString() != "")
                        {
                            int inttype = cmbTesttype.FindStringExact(dgvTest.Rows[indexRow].Cells["Type"].Value.ToString());
                            if (inttype != -1)
                            {
                                cmbTesttype.SelectedIndex = inttype;
                            }
                        }
                        txtNVMale.Text = Test.Rows[0][3].ToString();
                        txtNVFemale.Text = Test.Rows[0][4].ToString();
                        if (dgvTest.Rows[indexRow].Cells["Unit"].Value.ToString() != "")
                        {
                            int intunit = cmbUnit.FindString(dgvTest.Rows[indexRow].Cells["Unit"].Value.ToString());
                            if (intunit != -1)
                            {
                                cmbUnit.SelectedIndex = intunit;
                            }
                        }
                        btnSavetest.Text = "UPDATE";
                        btntestcancel.Show();
                    }
                    else if (e.ColumnIndex == 8)
                    {
                        int Testcheck = this.cntrl.testCount_byId(Convert.ToInt32(txttestid.Text));
                        DialogResult res = MessageBox.Show("Are you sure you want to delete?", "Delete confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                        txttestid.Text = "";
                        txtName.Text = "";
                        txtNVMale.Text = "";
                        txtNVFemale.Text = "";

                        if (res == DialogResult.No)
                        {
                        }
                        else
                        {
                            if (Convert.ToInt32(Testcheck) > 0)
                            {
                                MessageBox.Show("Cannot Delete, this LabType already used in another part", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txttestid.Text = "";
                                txtName.Text = "";
                                txtNVMale.Text = "";
                                txtNVFemale.Text = "";
                            }
                            else
                            {
                                this.cntrl.test_delete(id);
                                DataTable dt= this.cntrl.tpMain_test();
                                fill_Test(dt);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvtemplateadd_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            flag = 1;
            try
            {
                int r = e.RowIndex;
                id = dgvtemplateadd.Rows[r].Cells[0].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvtemplateadd_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 3)
                {
                    btnsavetmp.Hide();
                    btnedit.Show();
                    btnclose.Location = new Point(875, 24);
                    indexRow = e.RowIndex;
                    DataGridViewRow row = dgvtemplateadd.Rows[indexRow];
                    row.Cells[0].Value.ToString();
                    txtId.Text = dgvtemplateadd.Rows[indexRow].Cells[0].Value.ToString();
                    txttemp.Text = dgvtemplateadd.Rows[indexRow].Cells[2].Value.ToString();
                    try
                    {
                        pnl2.Show();
                        pnl2.Location = new Point(3, 13);
                        DataTable TEMPLATE = this.cntrl.temp_byId(Convert.ToInt32(txtId.Text));
                        txtId.Text = TEMPLATE.Rows[0][0].ToString();
                        txttemp.Text = TEMPLATE.Rows[0][1].ToString();
                        System.Data.DataTable tbshade = this.cntrl.tb_mainShade(Convert.ToInt32(txtId.Text));
                        dgvtempitem.Rows.Clear();
                        for (int r = 0; r < tbshade.Rows.Count; r++)
                        {
                            dgvtempitem.Rows.Add("", tbshade.Rows[r]["Test Name"].ToString(), tbshade.Rows[r]["Speciality"].ToString(), tbshade.Rows[r]["SampleType"].ToString(), tbshade.Rows[r]["Units"].ToString(), tbshade.Rows[r]["NormalValueM"].ToString(), tbshade.Rows[r]["NormalValueF"].ToString(), tbshade.Rows[r]["Main Id"].ToString(), tbshade.Rows[r]["Test_id"].ToString(), tbshade.Rows[r]["NormalValueM"].ToString(), tbshade.Rows[r]["NormalValueF"].ToString());
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (e.ColumnIndex == 4)
                {
                    DialogResult res = MessageBox.Show("Are you sure you want to delete?", "Delete confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    txtId.Text = "";
                    txttemp.Text = "";
                    if (res == DialogResult.No)
                    {
                    }
                    else
                    {
                        this.cntrl.dele_temp(id);
                        DataTable dt= this.cntrl.tpMain_template();
                        fill_Template(dt);
                        DataTable TEMPLATE_View = this.cntrl.Template_view();
                        dgvTesttemplate.DataSource = TEMPLATE_View;
                    }
                }
                btnadditems.Text = "ADD NEW";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNewtmp_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnNewtmp.Text == "ADD")
                {
                    pnlAddtemplate.Show();
                    pnl2.Show();
                    pnl2.Location = new Point(3, 13);
                    btnCancel.Hide();
                    btnedit.Hide();
                    btnsavetmp.Show();
                    btnclose.Location = new Point(974, 24);
                    btnadditems.Show();
                    dgvtempitem.Rows.Clear();
                    txttemp.Text = "";
                    System.Data.DataTable tbMaintesttemp = this.cntrl.fill_Test();
                    cmbmaintesttemp.DisplayMember = "Main_test";
                    cmbmaintesttemp.ValueMember = "id";
                    cmbmaintesttemp.DataSource = tbMaintesttemp;
                    System.Data.DataTable tbtesttypetemp = this.cntrl.fill_TestType();
                    cmbtesttypetmp.DisplayMember = "Name";
                    cmbtesttypetmp.ValueMember = "id";
                    cmbtesttypetmp.DataSource = tbtesttypetemp;
                    System.Data.DataTable tbtesttemp = this.cntrl.tbtesttemp();
                    cmbTesttemp.DisplayMember = "Name";
                    cmbTesttemp.ValueMember = "id";
                    cmbTesttemp.DataSource = tbtesttemp;
                }
                else
                {
                }
                DataTable dt= this.cntrl.tpMain_template();
                fill_Template(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rdbNvyes_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbNvyes.Checked == true)
            {
                this.dgvtempitem.Columns[5].Visible = true;
                this.dgvtempitem.Columns[6].Visible = true;
            }
            else
            {
                this.dgvtempitem.Columns[5].Visible = false;
                this.dgvtempitem.Columns[6].Visible = false;
            }
        }

        private void rdbNvno_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbNvyes.Checked == true)
            {
                this.dgvtempitem.Columns[5].Visible = true;
                this.dgvtempitem.Columns[6].Visible = true;
            }
            else
            {
                this.dgvtempitem.Columns[5].Visible = false;
                this.dgvtempitem.Columns[6].Visible = false;
            }
        }

        private void btnCancl_Click(object sender, EventArgs e)
        {
            txtMainTest.Clear();
            btnsave.Text = "SAVE";
            btnCancl.Hide();
        }

        private void btncaclty_Click(object sender, EventArgs e)
        {
            btncaclty.Hide();
            txtTestType.Clear();
            btnTesttype_save.Text = "SAVE";
        }

        private void btncanclunit_Click(object sender, EventArgs e)
        {
            btncanclunit.Hide();
            txtUnitadd.Clear();
            btnSaveunit.Text = "SAVE";
        }

        private void btntestcancel_Click(object sender, EventArgs e)
        {
            btnSavetest.Text = "SAVE";
            btntestcancel.Hide();
            txtName.Clear();
            txtNVMale.Clear();
            txtNVFemale.Clear();
            txttestid.Clear();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnCancel.Hide();
            btnadditems.Text = "ADD NEW";
            txttemp.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dgvtemplateadd.Refresh();
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            try
            {
                this.cntrl.Update_temp_name(Convert.ToInt32(txtId.Text), txttemp.Text);
                this.cntrl.delete_labTemp_main(Convert.ToInt32(txtId.Text));
                for (int r = 0; r < dgvtempitem.Rows.Count; r++)
                {
                    string norm = "";
                    if (dgvtempitem.Rows[r].Cells[10].Value.ToString() == ",")
                    {
                        norm = "";
                    }
                    else
                    {
                        norm = dgvtempitem.Rows[r].Cells[10].Value.ToString();
                    }
                     this.cntrl.Insert_mediTemplate(Convert.ToInt32(Convert.ToInt32(txtId.Text)), Convert.ToInt32(dgvtempitem.Rows[r].Cells[7].Value.ToString()), dgvtempitem.Rows[r].Cells[8].Value.ToString()/*test*/, dgvtempitem.Rows[r].Cells[4].Value,norm.ToString() );
                }
                txtId.Clear();
                txttemp.Clear();
                DataTable dt= this.cntrl.tpMain_template();
                fill_Template(dt);
                pnlAddtemplate.Show();
                pnl2.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbtesttypetmp_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (check == 1)
                {
                    System.Data.DataTable tbtesttemp = this.cntrl.id_name_meditest(cmbtesttypetmp.SelectedValue);
                    cmbTesttemp.DataSource = tbtesttemp;
                    cmbTesttemp.DisplayMember = "Name";
                    cmbTesttemp.ValueMember = "id";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvtempitem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            indexRow = e.RowIndex;
            if (indexRow!=-1)
            {
                cmbmaintesttemp.Text = dgvtempitem.Rows[indexRow].Cells[1].Value.ToString();
                cmbtesttypetmp.Text = dgvtempitem.Rows[indexRow].Cells[3].Value.ToString();
                cmbTesttemp.Text = dgvtempitem.Rows[indexRow].Cells[2].Value.ToString();
                btnadditems.Text = "Update";
            }
            if (e.ColumnIndex==12)
            {
                DialogResult res= MessageBox.Show("Are you sure you want to delete?", "Delete confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (res==DialogResult.No)
                {
                }
                else
                {
                    int row = dgvtempitem.CurrentCell.RowIndex;
                    dgvtempitem.Rows.RemoveAt(row);
                }
            }
        }
    }
}
