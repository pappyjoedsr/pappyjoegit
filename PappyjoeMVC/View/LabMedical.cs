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
    public partial class LabMedical : Form,LabMedical_interface
    {
        LabMedical_controller cntrl;
        public string doctor_id;
        int check = 0;
        int flag;
        string id;
        int grid_data_id = 0;
        int grid_id = 1;
        int indexRow;

        //public DataTable dt_for_grid = new DataTable();
        public LabMedical()
        {
            InitializeComponent();
        }
        public void setcontroller(LabMedical_controller controller)
        {
            cntrl = controller;
        }
        public string Main_Test
        {
            get { return this.txtMainTest.Text; }
            set { this.txtMainTest.Text = value; }
        }
        public string Test_type
        {
            get { return this.txtTestType.Text; }
            set { this.txtTestType.Text = value; }
        }
        public string Units
        {
            get { return this.txtUnitadd.Text; }
            set { this.txtUnitadd.Text = value; }
        }
        public string TestName
        {
            get { return this.txtName.Text; }
            set { this.txtName.Text = value; }
        }
        public string txtNVmale
        {
            get { return this.txtNVMale.Text; }
            set { this.txtNVMale.Text = value; }
        }
        public string txtNVfemale
        {
            get { return this.txtNVFemale.Text; }
            set { this.txtNVFemale.Text = value; }
        }
        public int Cmbtesttype
        {
            get { return Convert.ToInt32( this.cmbTesttype.SelectedValue); }
            set { this.cmbTesttype.SelectedValue = value; }
        }
        public int CmbUnit
        {
            get { return Convert.ToInt32(this.cmbUnit.SelectedValue); }
            set { this.cmbUnit.SelectedValue = value; }
        }
        public string TempName
        {
            get { return this.txttemp.Text; }
            set { this.txttemp.Text = value; }
        }
        //public int Temp_id
        //{
        //    get { return Convert.ToInt32(this.id.Rows[0][Id].ToString()); }
        //    set { this.id.Rows[0][Id] = value; }
        //}
        //public int TempItem
        //{
        //    get { return Convert.ToInt32(this.cmbmaintesttemp.SelectedValue); }
        //    set { this.cmbmaintesttemp.SelectedValue = value; }
        //}
        //public int cmbMainTemp
        //{
        //    get { return Convert.ToInt32(this.cmbTesttemp.SelectedValue); }
        //    set { this.cmbTesttemp.SelectedValue = value; }
        //}
        //public string cmbUnitname
        //{
        //    get { return this.Unitname.Rows[0][Units].ToString()); }
        //    set { this.Unitname.Rows[0][Units] = value; }
        //}
        //public string Normal
        //{
        //    get { return this.Normavalue.Rows[0][0].ToString(); }
        //    set { this.Normavalue.Rows[0][0].ToString() = value; }
        //}

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
            //cmbUnit.Items.Insert(0, "<select>");
            cmbUnit.DataSource = dtb;
            cmbUnit.DisplayMember = "Name";
            cmbUnit.ValueMember = "id";
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
            //cmbtesttypetmp.DataSource = dtb;
            //cmbtesttypetmp.DisplayMember = "Name";
            //cmbtesttypetmp.ValueMember = "id";
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
                this.cntrl.Main_test_Dgv();
                this.dgvLabMaster.Columns[1].Visible = false;

                DataTable tbTesttype = this.cntrl.fill_TestType();
                cmbTesttype.DataSource = tbTesttype;
                cmbTesttype.DisplayMember = "Name";
                cmbTesttype.ValueMember = "id";

                DataTable tbUnit = this.cntrl.fill_Unit();
                cmbUnit.Items.Insert(0, "<select>");
                cmbUnit.DataSource = tbUnit;
                cmbUnit.DisplayMember = "Name";
                cmbUnit.ValueMember = "id";

                DataTable tbMaintesttemp = this.cntrl.fill_Test();
                cmbmaintesttemp.DataSource = tbMaintesttemp;
                cmbmaintesttemp.DisplayMember = "Main_test";
                cmbmaintesttemp.ValueMember = "id";

                DataTable tbtesttypetemp = this.cntrl.fill_TestType();
                cmbtesttypetmp.DataSource = tbtesttypetemp;
                cmbtesttypetmp.DisplayMember = "Name";
                cmbtesttypetmp.ValueMember = "id";

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
                        //db.execute("insert into tbl_Lab_Medi_MainTest (Main_test) values('" + txtMainTest.Text + "')");
                        this.cntrl.Maintest_save(txtMainTest.Text);
                        MessageBox.Show("Successfully Saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        //db.execute("Update tbl_Lab_Medi_MainTest set Main_test= '" + txtMainTest.Text + "' where id ='" + Convert.ToInt32(txtMtid.Text) + "'");
                        this.cntrl.Update_Main_test(txtMtid.Text);
                    }
                    //DataTable MAIN_TEST = db.table("select id, Main_test  from tbl_Lab_Medi_MainTest");
                    //fill_MainTest(MAIN_TEST);
                    this.cntrl.Main_test_Dgv();
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
                //DataTable TEST_TYPE = db.table("select id, Name as'Test Type' from tbl_Lab_Medi_TestType");
                //fill_TestType(TEST_TYPE);
                ////dtgTestType.DataSource = TEST_TYPE;
                this.cntrl.tpMain_testtype();
                this.dtgTestType.Columns[0].Visible = false;


                //DataTable Unit = db.table("select id,Name as'Unit' from Lab_Medi_Unit");
                //fill_Unit(Unit);
                ////dgvUnit.DataSource = Unit;
                this.cntrl.tpMain_unit();
                this.dgvUnit.Columns[0].Visible = false;

                //DataTable Test = db.table("SELECT Lab_Medi_Test.id, Lab_Medi_Test.Name as test,tbl_Lab_Medi_TestType.Name as Test_Type,Lab_Medi_Test.NormalValueM,Lab_Medi_Test.NormalValueF, Lab_Medi_Unit.Name as Unit FROM Lab_Medi_Unit INNER JOIN Lab_Medi_Test ON Lab_Medi_Unit.id=Lab_Medi_Test.UnitId Inner join tbl_Lab_Medi_TestType on tbl_Lab_Medi_TestType.id=Lab_Medi_Test.TestTypeID");
                ////dgvTest.DataSource = Test;
                //fill_Test(Test);
                this.cntrl.tpMain_test();
                this.dgvTest.Columns[0].Visible = false;

                //DataTable TEMPLATE = db.table("select id,TemplateName from Lab_Medi_TemplateMain ");
                //fill_Template(TEMPLATE);
                ////dgvtemplateadd.DataSource = TEMPLATE;
                this.cntrl.tpMain_template();
                this.dgvtemplateadd.Columns[0].Visible = false;

                //   DataTable TEMPLATE_View = db.table("select Lab_Medi_Template.Id  as id,ROW_NUMBER() over (order by Lab_Medi_Template.id) as SlNo ,Lab_Medi_TemplateMain.id as templatemain_id,tbl_Lab_Medi_MainTest.Main_test ,tbl_Lab_Medi_TestType.Name as Test_types,Lab_Medi_Test.Name as test,Lab_Medi_Unit.Name as Unit,Lab_Medi_Test.NormalValueM,Lab_Medi_Test.NormalValueF from Lab_Medi_Template inner join tbl_Lab_Medi_MainTest on Lab_Medi_Template.MainTestId = tbl_Lab_Medi_MainTest.id inner join Lab_Medi_TemplateMain on Lab_Medi_Template.id=Lab_Medi_TemplateMain.id inner join Lab_Medi_Test on Lab_Medi_Test.id= TestId inner join  tbl_Lab_Medi_TestType  on Lab_Medi_Test.TestTypeID= tbl_Lab_Medi_TestType.id inner join Lab_Medi_Unit on Lab_Medi_Unit.id=Lab_Medi_Test.UnitId");

                //set @row_number = 0;
                //DataTable TEMPLATE_View = db.table("select Lab_Medi_Template.Id  as id,Lab_Medi_Template.Id AS  SlNo , Lab_Medi_TemplateMain.id as templatemain_id, tbl_Lab_Medi_MainTest.Main_test , tbl_Lab_Medi_TestType.Name as Test_types,Lab_Medi_Test.Name as test,Lab_Medi_Unit.Name as Unit,Lab_Medi_Test.NormalValueM,Lab_Medi_Test.NormalValueF from Lab_Medi_Template inner join tbl_Lab_Medi_MainTest on Lab_Medi_Template.MainTestId = tbl_Lab_Medi_MainTest.id inner join Lab_Medi_TemplateMain on Lab_Medi_Template.id=Lab_Medi_TemplateMain.id inner join Lab_Medi_Test on Lab_Medi_Test.id= TestId inner join  tbl_Lab_Medi_TestType  on Lab_Medi_Test.TestTypeID= tbl_Lab_Medi_TestType.id inner join Lab_Medi_Unit on Lab_Medi_Unit.id=Lab_Medi_Test.UnitId");
                DataTable TEMPLATE_View = this.cntrl.Template_view();
                dgvTesttemplate.DataSource = TEMPLATE_View;
                this.dgvTesttemplate.Columns[2].Visible = false;

                //strt cmb boxes

                System.Data.DataTable tbTesttype = this.cntrl.fill_TestType();
                cmbTesttype.DataSource = tbTesttype;
                cmbTesttype.DisplayMember = "Name";
                cmbTesttype.ValueMember = "id";


                System.Data.DataTable tbUnit = this.cntrl.fill_Unit();
                cmbUnit.DataSource = tbUnit;
                cmbUnit.DisplayMember = "Name";
                cmbUnit.ValueMember = "id";


                System.Data.DataTable tbMaintesttemp = this.cntrl.fill_Test();
                cmbmaintesttemp.DataSource = tbMaintesttemp;
                cmbmaintesttemp.DisplayMember = "Main_test";
                cmbmaintesttemp.ValueMember = "id";

                System.Data.DataTable tbtesttypetemp = this.cntrl.fill_TestType();
                cmbtesttypetmp.DataSource = tbtesttypetemp;
                cmbtesttypetmp.DisplayMember = "Name";
                cmbtesttypetmp.ValueMember = "id";


                //System.Data.DataTable tbtesttemp = db.table("select id,Name from Lab_Medi_Test");
                DataTable tbtesttemp = this.cntrl.tbtesttemp();
                cmbTesttemp.DataSource = tbtesttemp;
                cmbTesttemp.DisplayMember = "Name";
                cmbTesttemp.ValueMember = "id";

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
                        //db.execute("insert into tbl_Lab_Medi_TestType (Name) values('" + txtTestType.Text + "') ");
                        this.cntrl.Save_Testtype();
                        MessageBox.Show("Successfully Saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        //db.execute("Update tbl_Lab_Medi_TestType set Name= '" + txtTestType.Text + "' where id ='" + Convert.ToInt32(txtTtypeid.Text) + "'");
                        this.cntrl.Update_testtype(txtTtypeid.Text);
                        MessageBox.Show("Data updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    //DataTable TEST_TYPE = db.table("select id, Name as'Test Type' from tbl_Lab_Medi_TestType");
                    ////dtgTestType.DataSource = TEST_TYPE;
                    //fill_TestType(TEST_TYPE);
                    this.cntrl.tpMain_testtype();
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
                        //db.execute("insert into Lab_Medi_Unit (Name) values('" + txtUnitadd.Text + "') ");
                        this.cntrl.SaveUnit();
                        MessageBox.Show("Successfully Saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        //db.execute("Update Lab_Medi_Unit set Name= '" + txtUnitadd.Text + "' where id ='" + Convert.ToInt32(txtunitid.Text) + "'");
                        this.cntrl.UpdateUnit(Convert.ToInt32(txtunitid.Text));
                        MessageBox.Show("Data updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    //DataTable Unit = db.table("select id,Name as'Unit' from Lab_Medi_Unit");
                    //dgvUnit.DataSource = Unit;
                    //fill_Unit(Unit);
                    this.cntrl.tpMain_unit();
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
                        //db.execute("INSERT INTO Lab_Medi_Test (Name,NormalValueM,NormalValueF,TestTypeID,UnitId)VALUES('" + txtName.Text + "','" + txtNVMale.Text + "','" + txtNVFemale.Text + "','" + Convert.ToInt32(cmbTesttype.SelectedValue) + "','" + Convert.ToInt32(cmbUnit.SelectedValue) + "')");
                        this.cntrl.SaveTest();
                        MessageBox.Show("Successfully Saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        //db.execute("Update Lab_Medi_Test set Name= '" + txtName.Text + "' ,TestTypeID='" + Convert.ToInt32(cmbTesttype.SelectedValue) + "',NormalValueM = '" + txtNVMale.Text + "', NormalValueF= '" + txtNVFemale.Text + "',UnitId ='" + Convert.ToInt32(cmbUnit.SelectedValue) + "'  where id ='" + Convert.ToInt32(txttestid.Text) + "'");
                        this.cntrl.Update_test(Convert.ToInt32(txttestid.Text));
                        MessageBox.Show("Data updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                //DataTable Test = db.table("SELECT Lab_Medi_Test.id, Lab_Medi_Test.Name as test,tbl_Lab_Medi_TestType.Name as Test_Type,Lab_Medi_Test.NormalValueM,Lab_Medi_Test.NormalValueF, Lab_Medi_Unit.Name as Unit FROM Lab_Medi_Unit INNER JOIN Lab_Medi_Test ON Lab_Medi_Unit.id=Lab_Medi_Test.UnitId Inner join tbl_Lab_Medi_TestType on tbl_Lab_Medi_TestType.id=Lab_Medi_Test.TestTypeID");
                ////dgvTest.DataSource = Test;
                //fill_Test(Test);
                this.cntrl.tpMain_test();
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
                        //db.execute("insert into Lab_Medi_TemplateMain (TemplateName) values('" + txttemp.Text + "') ");
                        this.cntrl.Tempname_save();
                        //DataTable id = db.table("select MAX(id) from Lab_Medi_TemplateMain");
                        DataTable id = this.cntrl.Get_Maxid();
                        //DataTable test = db.table("select id , Name from Lab_Medi_Test where id ='" + Convert.ToInt32(cmbTesttemp.SelectedValue) + "' ");
                        DataTable test = this.cntrl.Get_test_byId(Convert.ToInt32(cmbTesttemp.SelectedValue));
                        //DataTable Normavalue = db.table("select (NormalValueM +',' + NormalValueF ) as Normalvalue from Lab_Medi_Test  where id = '" + Convert.ToInt32(test.Rows[0][0].ToString()) + "' ");
                        DataTable Normavalue = this.cntrl.Normavalue(Convert.ToInt32(test.Rows[0][0].ToString()));
                        //db.execute("insert into Lab_Medi_Template (Id,MainTestId,TestId,Units,NormalValue) values('" + Convert.ToInt32(id.Rows[0][0].ToString()) + "','" + Convert.ToInt32(cmbmaintesttemp.SelectedValue) + "','" + Convert.ToInt32(cmbTesttemp.SelectedValue) + "','" + Unitname.Rows[0][0].ToString() + "','" + Normavalue.Rows[0][0].ToString() + "')");
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
                            //db.execute("insert into Lab_Medi_Template (Id,MainTestId,TestId,Units,NormalValue)values('" + Convert.ToInt32(id.Rows[0][0].ToString()) + "', '" + Convert.ToInt32(dgvtempitem.Rows[r].Cells[7].Value.ToString()) + "','" + Convert.ToInt32(dgvtempitem.Rows[r].Cells[8].Value.ToString()) + "','" + dgvtempitem.Rows[r].Cells[4].Value + "','" + norm + "')");
                            this.cntrl.Insert_mediTemplate(Convert.ToInt32(id.Rows[0][0].ToString()), Convert.ToInt32(dgvtempitem.Rows[r].Cells[7].Value.ToString()), Convert.ToInt32(dgvtempitem.Rows[r].Cells[8].Value.ToString()), dgvtempitem.Rows[r].Cells[4].Value, norm);
                        }
                        MessageBox.Show("Successfully Saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // dgvtempitem.DataSource = ""; 
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
                        //db.execute("Update Lab_Medi_TemplateMain set TemplateName= '" + txttemp.Text + "' where id ='" + Convert.ToInt32(txtId.Text) + "'");
                        this.cntrl.Update_temp_name(Convert.ToInt32(txtId.Text));
                    }
                    else
                    {
                        //db.execute("Update Lab_Medi_Template set  MainTestId='" + Convert.ToInt32(cmbmaintesttemp.SelectedValue) + "',TestId='" + Convert.ToInt32(cmbTesttemp.SelectedValue) + "' where id ='" + Convert.ToInt32(txtId.Text) + "'");
                        this.cntrl.Update_temp_Ids(Convert.ToInt32(cmbmaintesttemp.SelectedValue), Convert.ToInt32(cmbTesttemp.SelectedValue), Convert.ToInt32(txtId.Text));
                    }
                    MessageBox.Show(" Data updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                //DataTable TEMPLATE = db.table("select id,TemplateName from Lab_Medi_TemplateMain ");
                //fill_Template(TEMPLATE);
                this.cntrl.tpMain_template();
                // DataTable TEMPLATE_View = db.table("select Lab_Medi_Template.Id  as id,ROW_NUMBER() over (order by Lab_Medi_Template.id)as SlNo ,Lab_Medi_TemplateMain.id as templatemain_id,tbl_Lab_Medi_MainTest.Main_test ,tbl_Lab_Medi_TestType.Name as Test_types,Lab_Medi_Test.Name as test,Lab_Medi_Unit.Name as Unit,Lab_Medi_Test.NormalValueM,Lab_Medi_Test.NormalValueF from Lab_Medi_Template inner join tbl_Lab_Medi_MainTest on Lab_Medi_Template.MainTestId = tbl_Lab_Medi_MainTest.id inner join Lab_Medi_TemplateMain on Lab_Medi_Template.id=Lab_Medi_TemplateMain.id inner join Lab_Medi_Test on Lab_Medi_Test.id= TestId inner join  tbl_Lab_Medi_TestType  on Lab_Medi_Test.TestTypeID= tbl_Lab_Medi_TestType.id inner join Lab_Medi_Unit on Lab_Medi_Unit.id=Lab_Medi_Test.UnitId");
                //DataTable TEMPLATE_View = db.table("select Lab_Medi_Template.Id  as id,Lab_Medi_Template.Id as SlNo ,Lab_Medi_TemplateMain.id as templatemain_id,tbl_Lab_Medi_MainTest.Main_test ,tbl_Lab_Medi_TestType.Name as Test_types,Lab_Medi_Test.Name as test,Lab_Medi_Unit.Name as Unit,Lab_Medi_Test.NormalValueM,Lab_Medi_Test.NormalValueF from Lab_Medi_Template inner join tbl_Lab_Medi_MainTest on Lab_Medi_Template.MainTestId = tbl_Lab_Medi_MainTest.id inner join Lab_Medi_TemplateMain on Lab_Medi_Template.id=Lab_Medi_TemplateMain.id inner join Lab_Medi_Test on Lab_Medi_Test.id= TestId inner join  tbl_Lab_Medi_TestType  on Lab_Medi_Test.TestTypeID= tbl_Lab_Medi_TestType.id inner join Lab_Medi_Unit on Lab_Medi_Unit.id=Lab_Medi_Test.UnitId");
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
                //DataTable Maintest = db.table("select id,Main_test from tbl_Lab_Medi_MainTest where id= '" + cmbmaintesttemp.SelectedValue.ToString() + "' ");
                DataTable Maintest = this.cntrl.TempAddItem_mainTest(cmbmaintesttemp.SelectedValue.ToString());
                //DataTable testtype = db.table("select id, Name from tbl_Lab_Medi_TestType where id = '" + cmbtesttypetmp.SelectedValue.ToString() + "' ");
                DataTable testtype = this.cntrl.TempAddItem_testtype(cmbtesttypetmp.SelectedValue.ToString());
                //DataTable testname = db.table("select id,Name from Lab_Medi_Test where id ='" + cmbTesttemp.SelectedValue.ToString() + "'");
                DataTable testname = this.cntrl.TempAddItem_testname(cmbTesttemp.SelectedValue.ToString());
                //DataTable Unitname = db.table("select A.Name from   Lab_Medi_Unit A inner join Lab_Medi_Test B on A.id=B.UnitId where B.id ='" + cmbTesttemp.SelectedValue.ToString() + "'");
                DataTable Unitname = this.cntrl.TempAddItem_unitname(cmbTesttemp.SelectedValue.ToString());
                //DataTable test = db.table("select id , Name from Lab_Medi_Test where id ='" + Convert.ToInt32(cmbTesttemp.SelectedValue) + "' ");
                DataTable test = this.cntrl.TempAddItem_test(Convert.ToInt32(cmbTesttemp.SelectedValue));
                //DataTable NormavalueM = db.table("select NormalValueM  from Lab_Medi_Test  where id = '" + Convert.ToInt32(test.Rows[0][0].ToString()) + "' ");
                DataTable NormavalueM = this.cntrl.TempAddItem_normM(Convert.ToInt32(test.Rows[0][0].ToString()));
                //DataTable NormavalueF = db.table("select NormalValueF  from Lab_Medi_Test  where id = '" + Convert.ToInt32(test.Rows[0][0].ToString()) + "' ");
                DataTable NormavalueF = this.cntrl.TempAddItem_normF(Convert.ToInt32(test.Rows[0][0].ToString()));
                //DataTable Normavalue = db.table("select (NormalValueM +',' + NormalValueF ) as Normalvalue from Lab_Medi_Test  where id = '" + Convert.ToInt32(test.Rows[0][0].ToString()) + "' ");
                DataTable Normavalue = this.cntrl.TempAddItem_normal(Convert.ToInt32(test.Rows[0][0].ToString()));

                if (grid_data_id != 0)
                {
                    for (int Ro = 0; Ro < dgvtempitem.Rows.Count; Ro++)
                    {
                        if (Convert.ToInt16(dgvtempitem.Rows[Ro].Cells[13].Value.ToString()) == grid_data_id)
                        {
                            dgvtempitem.Rows[Ro].Cells[0].Value = "";
                            dgvtempitem.Rows[Ro].Cells[1].Value = Maintest.Rows[0][1].ToString();
                            dgvtempitem.Rows[Ro].Cells[2].Value = testname.Rows[0][1].ToString();
                            dgvtempitem.Rows[Ro].Cells[3].Value = testtype.Rows[0][1].ToString();
                            dgvtempitem.Rows[Ro].Cells[4].Value = Unitname.Rows[0][0].ToString();
                            dgvtempitem.Rows[Ro].Cells[5].Value = NormavalueM.Rows[0][0].ToString();
                            dgvtempitem.Rows[Ro].Cells[6].Value = NormavalueF.Rows[0][0].ToString();
                            dgvtempitem.Rows[Ro].Cells[7].Value = Maintest.Rows[0][0].ToString();
                            dgvtempitem.Rows[Ro].Cells[8].Value = testname.Rows[0][0].ToString();
                            dgvtempitem.Rows[Ro].Cells[9].Value = testtype.Rows[0][0].ToString();
                            dgvtempitem.Rows[Ro].Cells[10].Value = Normavalue.Rows[0][0].ToString();
                        }
                    }
                }
                else
                {
                    dgvtempitem.Rows.Add("", Maintest.Rows[0][1].ToString(), testname.Rows[0][1].ToString(), testtype.Rows[0][1].ToString(), Unitname.Rows.Count > 0 ? Unitname.Rows[0][0].ToString() : "", NormavalueM.Rows[0][0].ToString(), NormavalueF.Rows[0][0].ToString(), Maintest.Rows[0][0].ToString(), testname.Rows[0][0].ToString(), testtype.Rows[0][0].ToString(), Normavalue.Rows[0][0].ToString());
                    grid_id = grid_id + 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvtempitem_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvtempitem.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
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
                        //DataTable MAIN_TEST = db.table("select * from tbl_Lab_Medi_MainTest where id='" + Convert.ToInt32(txtMtid.Text) + "' ");
                        DataTable MAIN_TEST = this.cntrl.MainTest_byId(Convert.ToInt32(txtMtid.Text));
                        txtMtid.Text = MAIN_TEST.Rows[0][0].ToString();
                        txtMainTest.Text = MAIN_TEST.Rows[0][1].ToString();
                        btnsave.Text = "UPDATE";
                        btnCancl.Show();
                    }
                    else if (e.ColumnIndex == 4)
                    {
                        //DataTable MAIN_TEST = db.table("select count(*) from Lab_Medi_Template where MainTestId ='" + Convert.ToInt32(txtMtid.Text) + "'");
                        DataTable MAIN_TEST = this.cntrl.MainTest_countById(Convert.ToInt32(txtMtid.Text));
                        DialogResult res = MessageBox.Show("Are you sure you want to delete?", "Delete confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                        txtId.Clear();
                        txtMainTest.Clear();
                        if (res == DialogResult.No)
                        {
                        }
                        else
                        {
                            if (Convert.ToInt32(MAIN_TEST.Rows[0][0].ToString()) > 0)
                            {
                                MessageBox.Show("Cannot Delete", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtId.Clear();
                                txtMainTest.Clear();
                            }
                            else
                            {
                                //int d = db.execute("delete from tbl_Lab_Medi_MainTest where id='" + id + "'");
                                this.cntrl.delete_Maintest(id);
                                //DataTable dt = db.table("select id,Main_test  from tbl_Lab_Medi_MainTest ");
                                //fill_MainTest(dt);
                                this.cntrl.Main_test_Dgv();
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
                        //row.Cells[0].Value.ToString();
                        //DataTable TEST_TYPE = db.table("select * from tbl_Lab_Medi_TestType where id='" + Convert.ToInt32(txtTtypeid.Text) + "' ");
                        DataTable TEST_TYPE = this.cntrl.Testtype_byID(Convert.ToInt32(txtTtypeid.Text));
                        txtTtypeid.Text = TEST_TYPE.Rows[0][0].ToString();
                        txtTestType.Text = TEST_TYPE.Rows[0][1].ToString();
                        btnTesttype_save.Text = "UPDATE";
                        btncaclty.Show();
                    }
                    else if (e.ColumnIndex == 4)
                    {
                        //DataTable MAIN_TEST = db.table("select count(*) from Lab_Medi_Test where TestTypeID ='" + Convert.ToInt32(txtTtypeid.Text) + "'");
                        DataTable MAIN_TEST = this.cntrl.testtype_countById(Convert.ToInt32(txtTtypeid.Text));
                        DialogResult res = MessageBox.Show("Are you sure you want to delete?", "Delete confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                        txtTestType.Text = "";
                        txtTtypeid.Text = "";
                        if (res == DialogResult.No)
                        {
                        }
                        else
                        {
                            if (Convert.ToInt32(MAIN_TEST.Rows[0][0].ToString()) > 0)
                            {
                                MessageBox.Show("Cannot Delete", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtTestType.Text = "";
                                txtTtypeid.Text = "";
                            }
                            else
                            {
                                //int d = db.execute("delete from tbl_Lab_Medi_TestType where id='" + id + "'");
                                this.cntrl.delete_testtype(id);
                                //DataTable TEST_TYPE = db.table("select id,Name as'Test Type' from tbl_Lab_Medi_TestType ");
                                //fill_TestType(TEST_TYPE);
                                this.cntrl.tpMain_testtype();
                                //////dtgTestType.DataSource = dtb;
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
                        //DataTable Unit = db.table("select * from Lab_Medi_Unit where id='" + Convert.ToInt32(txtunitid.Text) + "' ");
                        DataTable Unit = this.cntrl.Unit_byID(Convert.ToInt32(txtunitid.Text));
                        txtunitid.Text = Unit.Rows[0][0].ToString();
                        txtUnitadd.Text = Unit.Rows[0][1].ToString();
                        btnSaveunit.Text = "UPDATE";
                        btncanclunit.Show();
                    }
                    else if (e.ColumnIndex == 4)
                    {
                        //DataTable Unitcheck = db.table("select count(*) from Lab_Medi_Test where UnitId ='" + Convert.ToInt32(txtunitid.Text) + "'");
                        DataTable Unitcheck = this.cntrl.UnitCount_byID(Convert.ToInt32(txtunitid.Text));
                        DialogResult res = MessageBox.Show("Are you sure you want to delete?", "Delete confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                        txtunitid.Text = "";
                        txtUnitadd.Text = "";
                        if (res == DialogResult.No)
                        {
                        }
                        else
                        {
                            if (Convert.ToInt32(Unitcheck.Rows[0][0].ToString()) > 0)
                            {
                                MessageBox.Show("Cannot Delete", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtunitid.Text = "";
                                txtUnitadd.Text = "";
                            }
                            else
                            {
                                //int d = db.execute("delete from Lab_Medi_Unit where id='" + id + "'");
                                this.cntrl.del_unit(id);
                                //DataTable Unit = db.table("select id,Name as'Unit' from Lab_Medi_Unit ");
                                ////dgvUnit.DataSource = Unit;
                                //fill_Unit(Unit);
                                this.cntrl.tpMain_unit();
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

                    //row.Cells[0].Value.ToString();
                    if (e.ColumnIndex == 7)
                    {
                        //try
                        //{
                        //DataTable Test = db.table("select * from Lab_Medi_Test where id='" + Convert.ToInt32(txttestid.Text) + "' ");
                        DataTable Test = this.cntrl.test_ByID(Convert.ToInt32(txttestid.Text));
                        txttestid.Text = Test.Rows[0][0].ToString();
                        txtName.Text = Test.Rows[0][1].ToString();
                        //cmbTesttype.SelectedItem = Test.Rows[0][2].ToString();
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
                        //}
                        //catch
                        //{
                        //}
                    }
                    else if (e.ColumnIndex == 8)
                    {
                        //DataTable Testcheck = db.table("select count(*) from Lab_Medi_Template where TestId ='" + Convert.ToInt32(txttestid.Text) + "' ");
                        DataTable Testcheck = this.cntrl.testCount_byId(Convert.ToInt32(txttestid.Text));
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
                            if (Convert.ToInt32(Testcheck.Rows[0][0].ToString()) > 0)
                            {
                                MessageBox.Show("Cannot Delete", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txttestid.Text = "";
                                txtName.Text = "";
                                txtNVMale.Text = "";
                                txtNVFemale.Text = "";
                            }
                            else
                            {
                                //int d = db.execute("delete from Lab_Medi_Test where id='" + id + "'");
                                this.cntrl.test_delete(id);
                                //DataTable Test = db.table("SELECT Lab_Medi_Test.id, Lab_Medi_Test.Name as test, Lab_Medi_Unit.Name as Unit,tbl_Lab_Medi_TestType.Name as Test_Type,Lab_Medi_Test.NormalValueM,Lab_Medi_Test.NormalValueF FROM Lab_Medi_Unit INNER JOIN Lab_Medi_Test ON Lab_Medi_Unit.id=Lab_Medi_Test.UnitId Inner join tbl_Lab_Medi_TestType on tbl_Lab_Medi_TestType.id=Lab_Medi_Test.TestTypeID ");
                                this.cntrl.tpMain_test();
                                ////dgvTest.DataSource = Test;
                                //fill_Test(Test);
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
                    //btnadditems.Hide();
                    btnsavetmp.Hide();
                    // btnCancel.Show();
                    btnedit.Show();
                    btnclose.Location = new Point(875, 24);
                    indexRow = e.RowIndex; // get the selected Row Index
                    DataGridViewRow row = dgvtemplateadd.Rows[indexRow];
                    row.Cells[0].Value.ToString();
                    txtId.Text = dgvtemplateadd.Rows[indexRow].Cells[0].Value.ToString();
                    txttemp.Text = dgvtemplateadd.Rows[indexRow].Cells[2].Value.ToString();
                    try
                    {
                        pnl2.Show();
                        pnl2.Location = new Point(3, 13);
                        //DataTable TEMPLATE = db.table("select * from Lab_Medi_TemplateMain where id='" + Convert.ToInt32(txtId.Text) + "' ");
                        DataTable TEMPLATE = this.cntrl.temp_byId(Convert.ToInt32(txtId.Text));
                        txtId.Text = TEMPLATE.Rows[0][0].ToString();
                        txttemp.Text = TEMPLATE.Rows[0][1].ToString();

                        //System.Data.DataTable tbshade = db.table("SELECT D.Main_test as 'Test Name',C.Name as 'SampleType',B.Name as 'Speciality',B.NormalValueM,B.NormalValueF,E.name as 'Units',A.NormalValue as'Normal Value',B.id as 'Test_id',D.id as'Main Id' FROM Lab_Medi_Template A INNER JOIN  Lab_Medi_Test B ON A.TestId=B.id INNER JOIN tbl_Lab_Medi_TestType C ON C.id=B.TestTypeID INNER JOIN tbl_Lab_Medi_MainTest D ON D.id=A.MainTestId INNER JOIN Lab_Medi_Unit E ON E.name=A.Units inner join Lab_Medi_TemplateMain F on F.id=A.Id where A.id='" + Convert.ToInt32(txtId.Text) + "'");
                        System.Data.DataTable tbshade = this.cntrl.tb_mainShade(Convert.ToInt32(txtId.Text));
                        ////Lab_Medi_Template A
                        ////Lab_Medi_Test B
                        ////tbl_Lab_Medi_TestType C
                        ////tbl_Lab_Medi_MainTest D
                        ////Lab_Medi_Unit E
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
                        //int d = db.execute("delete from Lab_Medi_TemplateMain where id='" + id + "'");
                        this.cntrl.dele_temp(id);
                        //DataTable TEMPLATE = db.table("select id,TemplateName from Lab_Medi_TemplateMain");
                        //fill_Template(TEMPLATE);
                        this.cntrl.tpMain_template();
                        ////dgvtemplateadd.DataSource = TEMPLATE;
                        ////DataTable TEMPLATE_View = db.table("select Lab_Medi_Template.Id  as id,ROW_NUMBER() over (order by Lab_Medi_Template.id)as SlNo ,Lab_Medi_TemplateMain.id as templatemain_id,tbl_Lab_Medi_MainTest.Main_test ,tbl_Lab_Medi_TestType.Name as Test_types,Lab_Medi_Test.Name as test,Lab_Medi_Unit.Name as Unit,Lab_Medi_Test.NormalValueM,Lab_Medi_Test.NormalValueF from Lab_Medi_Template inner join tbl_Lab_Medi_MainTest on Lab_Medi_Template.MainTestId = tbl_Lab_Medi_MainTest.id inner join Lab_Medi_TemplateMain on Lab_Medi_Template.id=Lab_Medi_TemplateMain.id inner join Lab_Medi_Test on Lab_Medi_Test.id= TestId inner join  tbl_Lab_Medi_TestType  on Lab_Medi_Test.TestTypeID= tbl_Lab_Medi_TestType.id inner join Lab_Medi_Unit on Lab_Medi_Unit.id=Lab_Medi_Test.UnitId");
                        //DataTable TEMPLATE_View = db.table("select Lab_Medi_Template.Id  as id,Lab_Medi_Template.Id as SlNo ,Lab_Medi_TemplateMain.id as templatemain_id,tbl_Lab_Medi_MainTest.Main_test ,tbl_Lab_Medi_TestType.Name as Test_types,Lab_Medi_Test.Name as test,Lab_Medi_Unit.Name as Unit,Lab_Medi_Test.NormalValueM,Lab_Medi_Test.NormalValueF from Lab_Medi_Template inner join tbl_Lab_Medi_MainTest on Lab_Medi_Template.MainTestId = tbl_Lab_Medi_MainTest.id inner join Lab_Medi_TemplateMain on Lab_Medi_Template.id=Lab_Medi_TemplateMain.id inner join Lab_Medi_Test on Lab_Medi_Test.id= TestId inner join  tbl_Lab_Medi_TestType  on Lab_Medi_Test.TestTypeID= tbl_Lab_Medi_TestType.id inner join Lab_Medi_Unit on Lab_Medi_Unit.id=Lab_Medi_Test.UnitId");
                        DataTable TEMPLATE_View = this.cntrl.Template_view();
                        dgvTesttemplate.DataSource = TEMPLATE_View;
                    }
                }
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
                    //System.Data.DataTable tbMaintesttemp = db.table("select id,Main_test from tbl_Lab_Medi_MainTest");
                    System.Data.DataTable tbMaintesttemp = this.cntrl.fill_Test();
                    cmbmaintesttemp.DataSource = tbMaintesttemp;
                    cmbmaintesttemp.DisplayMember = "Main_test";
                    cmbmaintesttemp.ValueMember = "id";
                    //System.Data.DataTable tbtesttypetemp = db.table("SELECT id, Name from tbl_Lab_Medi_TestType");
                    System.Data.DataTable tbtesttypetemp = this.cntrl.fill_TestType();
                    cmbtesttypetmp.DataSource = tbtesttypetemp;
                    cmbtesttypetmp.DisplayMember = "Name";
                    cmbtesttypetmp.ValueMember = "id";
                    //System.Data.DataTable tbtesttemp = db.table("select id,Name from Lab_Medi_Test");
                    System.Data.DataTable tbtesttemp = this.cntrl.tbtesttemp();
                    cmbTesttemp.DataSource = tbtesttemp;
                    cmbTesttemp.DisplayMember = "Name";
                    cmbTesttemp.ValueMember = "id";


                }
                else
                {
                }
                this.cntrl.tpMain_template();
                //DataTable TEMPLATE = db.table("select id,TemplateName from Lab_Medi_TemplateMain ");
                //fill_Template(TEMPLATE);
                ////dgvtemplateadd.DataSource = TEMPLATE;
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
                //db.execute("Update Lab_Medi_TemplateMain set TemplateName= '" + txttemp.Text + "' where id ='" + Convert.ToInt32(txtId.Text) + "'");
                this.cntrl.Update_temp_name(Convert.ToInt32(txtId.Text));
                //db.execute("Delete  from Lab_Medi_Template where Id='" + Convert.ToInt32(txtId.Text) + "'");
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
                    //db.execute("insert into Lab_Medi_Template (Id,MainTestId,TestId,Units,NormalValue)values('" + Convert.ToInt32(Convert.ToInt32(txtId.Text)) + "', '" + Convert.ToInt32(dgvtempitem.Rows[r].Cells[7].Value.ToString()) + "','" + Convert.ToInt32(dgvtempitem.Rows[r].Cells[8].Value.ToString()) + "','" + dgvtempitem.Rows[r].Cells[4].Value + "','" + norm + "')");
                    this.cntrl.Insert_mediTemplate(Convert.ToInt32(Convert.ToInt32(txtId.Text)), Convert.ToInt32(dgvtempitem.Rows[r].Cells[7].Value.ToString()), Convert.ToInt32(dgvtempitem.Rows[r].Cells[8].Value.ToString()), dgvtempitem.Rows[r].Cells[4].Value, norm);
                }
                txtId.Clear();
                txttemp.Clear();
                //DataTable TEMPLATE = db.table("select id,TemplateName from Lab_Medi_TemplateMain");
                //fill_Template(TEMPLATE);
                ////dgvtemplateadd.DataSource = TEMPLATE; dgvtemplateadd
                this.cntrl.tpMain_template();
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
                    //System.Data.DataTable tbtesttemp = db.table("select id,Name from Lab_Medi_Test where TestTypeID ='" + cmbtesttypetmp.SelectedValue + "' ");
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
    }
}
