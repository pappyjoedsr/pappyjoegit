using PappyjoeMVC.Controller;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PappyjoeMVC.View
{
    public partial class frmeditpracticedetails : Form
    {
        public frmeditpracticedetails()
        {
            InitializeComponent();
        }

        public frmeditpracticedetails(int selectedValue, string cmb)
        {
            InitializeComponent();
            selectedValue1 = selectedValue;
            combobox = cmb;
        }

        editpracticedetails_controller contrl=new editpracticedetails_controller();
        public string frameid = "0";
        public string Country_id = "", State_id = "", City_id = "", Speci_id = "";
        public int state_index = 0, country_index = 0, city_index = 0, sepci_index = 0;
        public static int selectedValue1;
        public static string combobox;
        private void btn_CountrySave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(Txt_Country.Text))
                {
                    if (btn_CountrySave.Text == "Save")
                    {
                        string country = this.contrl.check_country(Txt_Country.Text);
                        if (Convert.ToInt32(country) == 1)
                        {
                            MessageBox.Show("This Country " + Txt_Country.Text + "  already exists", "Duplication encountered ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        else
                        {
                            this.contrl.save(Txt_Country.Text);
                        }
                    }
                    else
                    {
                        this.contrl.Country_update(Country_id, Txt_Country.Text);
                        btn_CountrySave.Text = "Save";
                        btn_Cancel.Text = "Close";
                    }
                    DataTable dtb = this.contrl.Load_Country();
                    AddUsertoGrid(dtb);
                    this.Txt_Country.Text = "";
                }
                else
                {
                    MessageBox.Show("Enter the country..", "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void AddUsertoGrid(DataTable dtb)
        {
            DGV_Country.Rows.Clear();
            if (dtb.Rows.Count > 0)
            {
                int i = 0, row = 1;
                foreach (DataRow dr in dtb.Rows)
                {
                    DGV_Country.Rows.Add();
                    DGV_Country.Rows[i].Cells["colid"].Value = dr["id"].ToString();
                    DGV_Country.Rows[i].Cells["slno"].Value = row;
                    DGV_Country.Rows[i].Cells["COUNTRY"].Value = dr["country"].ToString();
                    i = i + 1;
                    row++;
                }
            }
        }
        private void frmeditpracticedetails_Load(object sender, EventArgs e)
        {
            if (frameid == "2")
            {
                panl_country.Visible = true;
                panl_country.Location = new Point(3, 4);
                Panel_state.Visible = false;
                panl_specilization.Visible = false;
                panel_city.Visible = false;
                btn_CountrySave.Location = new Point(455, 6);
                btn_Cancel.Location = new Point(540, 11);
                DGV_Country.Location = new Point(5, 65);
                DGV_Country.RowHeadersVisible = false;
                DGV_Country.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
                DGV_Country.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                DGV_Country.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                DGV_Country.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                DGV_Country.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                DGV_Country.EnableHeadersVisualStyles = false;
                DataTable dtb = this.contrl.Load_Country();
                AddUsertoGrid(dtb);
            }
            else if (frameid == "3")
            {
                Panel_state.Visible = true;
                Panel_state.Location = new Point(3, 4);
                panl_country.Visible = false;
                panel_city.Visible = false;
                panl_specilization.Visible = false;
                DataTable dt_fillcountry= this.contrl.FillCountryCombo();
                Country_ComboFill(dt_fillcountry);
                DataTable dt_state = this.contrl.LoadState_wit_Country(selectedValue1.ToString());
                AddStatetoGrid(dt_state);
                Dgv_State.RowHeadersVisible = false;
                Dgv_State.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
                Dgv_State.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                Dgv_State.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                Dgv_State.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Dgv_State.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Dgv_State.EnableHeadersVisualStyles = false;
            }
            else if (frameid == "4")
            {
                panel_city.Visible = true;
                panel_city.Location = new Point(3, 4);
                Panel_state.Visible = false;
                panl_country.Visible = false;
                panl_specilization.Visible = false;
               DataTable dtb_country = this.contrl.FillStateCombo();
                State_ComboFill(dtb_country);
                DataTable dt= this.contrl.Fill_City_Grid(selectedValue1.ToString());
                AddCitytoGrid(dt);
                DGV_city.RowHeadersVisible = false;
                DGV_city.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
                DGV_city.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                DGV_city.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                DGV_city.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                DGV_city.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                DGV_city.EnableHeadersVisualStyles = false;
            }
            else if (frameid == "1")
            {
                panl_specilization.Visible = true;
                panl_specilization.Location = new Point(3, 4);
                panel_city.Visible = false;
                Panel_state.Visible = false;
                panl_country.Visible = false;
                DataTable dtb= this.contrl.Fill_Specilization_Grid();
                AddSpecilizationtoGrid(dtb);
                dataGridView_Specialization.RowHeadersVisible = false;
                dataGridView_Specialization.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
                dataGridView_Specialization.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dataGridView_Specialization.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dataGridView_Specialization.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView_Specialization.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView_Specialization.EnableHeadersVisualStyles = false;
            }
        }
        public void State_ComboFill(DataTable dtb)
        {
            if (dtb.Rows.Count > 0)
            {
                cmbstate.DataSource = dtb;
                cmbstate.DisplayMember = "state";
                cmbstate.ValueMember = "id";
                cmbstate.SelectedValue = selectedValue1;
            }

        }
        public void Country_ComboFill(DataTable dtb_country)
        {
            if (dtb_country.Rows.Count > 0)
            {
                Cmb_Country.DataSource = dtb_country;
                Cmb_Country.DisplayMember = "country";
                Cmb_Country.ValueMember = "id";
                Cmb_Country.SelectedValue = selectedValue1;
            }
        }
        private void DGV_Country_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    Country_id = DGV_Country.CurrentRow.Cells["colid"].Value.ToString();
                    if (DGV_Country.CurrentCell.OwningColumn.Name == "edit")
                    {
                        Txt_Country.Text = DGV_Country.CurrentRow.Cells["COUNTRY"].Value.ToString();
                        btn_CountrySave.Text = "Update";
                        btn_Cancel.Text = "Cancel";
                    }
                    else if (DGV_Country.CurrentCell.OwningColumn.Name == "delete")
                    {
                        DialogResult res = MessageBox.Show("Are you sure you want to delete..?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (res == DialogResult.Yes)
                        {
                            country_index = DGV_Country.CurrentRow.Index;
                            DataTable dtb = this.contrl.Use_country(Country_id);
                            check_Country_use(dtb);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error!....", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public void check_Country_use(DataTable dtb)
        {
            try
            {
                if (dtb.Rows.Count > 0)
                {
                    MessageBox.Show("Country Used in State.", "Can't Delete..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    int i = this.contrl.Delete_Country(Country_id);
                    if (i > 0)
                    {
                        DGV_Country.Rows.RemoveAt(country_index);
                        DataTable dt = this.contrl.Load_Country();
                        AddUsertoGrid(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            if (btn_Cancel.Text == "Close")
            {
                this.Close();
            }
            else if (btn_Cancel.Text == "Cancel")
            {
                if (frameid == "1")
                {
                    txt_speciliztn.Text = "";
                    btnsavespecialization.Text = "Save";
                    btn_Cancel.Text = "Close";
                }
                else if (frameid == "2")
                {
                    Txt_Country.Text = "";
                    btn_CountrySave.Text = "Save";
                    btn_Cancel.Text = "Close";
                }
                else if (frameid == "3")
                {
                    txt_State.Text = "";
                    btn_StateSave.Text = "Save";
                    btn_Cancel.Text = "Close";
                }
                else if (frameid == "4")
                {
                    txt_city.Text = "";
                    btn_city.Text = "Save";
                    btn_Cancel.Text = "Close";
                }
            }
        }
        public void AddStatetoGrid(DataTable dtb)
        {
            Dgv_State.Rows.Clear();
            if (dtb.Rows.Count > 0)
            {
                int i = 0, row = 1;
                foreach (DataRow dr in dtb.Rows)
                {
                    Dgv_State.Rows.Add();
                    Dgv_State.Rows[i].Cells["sId"].Value = dr["id"].ToString();
                    Dgv_State.Rows[i].Cells["S_slno"].Value = row;
                    Dgv_State.Rows[i].Cells["s_country"].Value = dr["country_id"].ToString();
                    Dgv_State.Rows[i].Cells["state"].Value = dr["state"].ToString();
                    i = i + 1;
                    row++;
                }
            }
        }

        private void btn_StateSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txt_State.Text))
                {
                    if (btn_StateSave.Text == "Save")
                    {
                        string state = this.contrl.check_state(txt_State.Text);
                        if(Convert.ToInt32(state)==1)
                        {
                            MessageBox.Show("This State " + txt_State.Text + "  already exists", "Duplication encountered ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        else
                        {
                            this.contrl.Save_State(Cmb_Country.SelectedValue.ToString(), txt_State.Text);
                        }
                    }
                    else
                    {
                        this.contrl.State_update(State_id, txt_State.Text, Cmb_Country.SelectedValue.ToString());
                        btn_StateSave.Text = "Save";
                        btn_Cancel.Text = "Close";
                    }
                    DataTable dtb = this.contrl.Fill_State_Grid(Cmb_Country.SelectedValue.ToString());
                    AddStatetoGrid(dtb);
                    this.txt_State.Text = "";
                }
                else
                {
                    MessageBox.Show("Enter the state..", "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void Dgv_State_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    State_id = Dgv_State.CurrentRow.Cells["sId"].Value.ToString();
                    if (Dgv_State.CurrentCell.OwningColumn.Name == "sedit")
                    {

                        string C_id = Dgv_State.CurrentRow.Cells["s_country"].Value.ToString();
                        DataTable dtb=  this.contrl.Get_Country_Name(C_id);
                        if (dtb.Rows.Count > 0)
                        {
                            Cmb_Country.Text = dtb.Rows[0]["country"].ToString();
                        }
                        txt_State.Text = Dgv_State.CurrentRow.Cells["state"].Value.ToString();
                        btn_StateSave.Text = "Update";
                        btn_Cancel.Text = "Cancel";
                    }
                    else if (Dgv_State.CurrentCell.OwningColumn.Name == "sdelete")
                    {
                        DialogResult res = MessageBox.Show("Are you sure you want to delete..?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (res == DialogResult.Yes)
                        {
                            state_index = Dgv_State.CurrentRow.Index;
                            this.contrl.Delete_State(State_id);
                            DataTable dtb_state = this.contrl.Fill_State_Grid(Cmb_Country.SelectedValue.ToString());
                            AddStatetoGrid(dtb_state);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error!....", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public void CheckStateUse(DataTable dtb)
        {
            try
            {
                if (dtb.Rows.Count > 0)
                {
                    MessageBox.Show("State Used in City.", "Can't Delete..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    int i = this.contrl.Delete_State(State_id);
                    if (i > 0)
                    {
                        Dgv_State.Rows.RemoveAt(state_index);
                        DataTable dtb_state = this.contrl.Fill_State_Grid(Cmb_Country.SelectedValue.ToString());
                        AddStatetoGrid(dtb_state);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!....", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //City
        public void AddCitytoGrid(DataTable dtb)
        {
            DGV_city.Rows.Clear();
            if (dtb.Rows.Count > 0)
            {
                int i = 0, row = 1;
                foreach (DataRow dr in dtb.Rows)
                {
                    DGV_city.Rows.Add();
                    DGV_city.Rows[i].Cells["c_id"].Value = dr["id"].ToString();
                    DGV_city.Rows[i].Cells["c_slno"].Value = row;
                    DGV_city.Rows[i].Cells["city"].Value = dr["city"].ToString();
                    DGV_city.Rows[i].Cells["c_state"].Value = dr["state_id"].ToString();
                    i = i + 1;
                    row++;
                }
            }
        }

        private void DGV_city_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    City_id = DGV_city.CurrentRow.Cells["c_id"].Value.ToString();
                    if (DGV_city.CurrentCell.OwningColumn.Name == "c_edit")
                    {
                        string C_id = DGV_city.CurrentRow.Cells["c_state"].Value.ToString();
                        DataTable dtb= this.contrl.Get_state_Name(C_id);
                        GetStateName(dtb);
                        txt_city.Text = DGV_city.CurrentRow.Cells["city"].Value.ToString();
                        btn_city.Text = "Update";
                        btn_Cancel.Text = "Cancel";
                    }
                    else if (DGV_city.CurrentCell.OwningColumn.Name == "c_delete")
                    {
                        DialogResult res = MessageBox.Show("Are you sure you want to delete..?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (res == DialogResult.Yes)
                        {
                            city_index = DGV_city.CurrentRow.Index;
                            DataTable dtb= this.contrl.Use_City(City_id);
                            CheckCityUse(dtb);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error!....", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_city_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txt_city.Text))
                {
                    if (btn_city.Text == "Save")
                    {
                        string city = this.contrl.check_city(txt_city.Text);
                        if (Convert.ToInt32(city) == 1)
                        {
                            MessageBox.Show("This City " + txt_city.Text + "  already exists", "Duplication encountered ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        else
                        {
                            this.contrl.Save_City(txt_city.Text, cmbstate.SelectedValue.ToString());
                        }
                        //checkValueCity(city);
                    }
                    else 
                    {
                        this.contrl.City_update(City_id, txt_city.Text, cmbstate.SelectedValue.ToString());
                        //this.contrl.Fill_City_Grid(State_Id);
                        btn_city.Text = "Save";
                        btn_Cancel.Text = "Close";
                    }
                    DataTable dt = this.contrl.Fill_City_Grid(cmbstate.SelectedValue.ToString());
                    AddCitytoGrid(dt);
                    this.txt_city.Text = "";
                }
                else
                {
                    MessageBox.Show("Enter the city..", "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void GetStateName(DataTable dtb)
        {
            if (dtb.Rows.Count > 0)
            {
                cmbstate.Text = dtb.Rows[0]["state"].ToString();
            }
        }
        private void Cmb_Country_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cmb_Country.Items.Count > 0)
            {
                Dgv_State.Rows.Clear();
                int selectedValue;
                bool parseOK = Int32.TryParse(Cmb_Country.SelectedValue.ToString(), out selectedValue);
                DataTable dtb = this.contrl.LoadState_wit_Country(selectedValue.ToString());
                AddStatetoGrid(dtb);
            }
        }

        private void cmbstate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbstate.Items.Count > 0)
            {
                int selectedValue;
                bool parseOK = Int32.TryParse(cmbstate.SelectedValue.ToString(), out selectedValue);
                this.contrl.Fill_City_Grid(selectedValue.ToString());
            }
        }

        public void CheckCityUse(DataTable dtb)
        {
            try
            {
                if (dtb.Rows.Count > 0)
                {
                    MessageBox.Show("City Used in Clinic Details.", "Can't Delete..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    int i = this.contrl.Delete_City(City_id);
                    if (i > 0)
                    {
                        DGV_city.Rows.RemoveAt(city_index);
                        this.contrl.Fill_City_Grid(cmbstate.SelectedValue.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!....", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void AddSpecilizationtoGrid(DataTable dtb)
        {
            dataGridView_Specialization.Rows.Clear();
            if (dtb.Rows.Count > 0)
            {
                int i = 0, row = 1;
                foreach (DataRow dr in dtb.Rows)
                {
                    dataGridView_Specialization.Rows.Add();
                    dataGridView_Specialization.Rows[i].Cells["id"].Value = dr["id"].ToString();
                    dataGridView_Specialization.Rows[i].Cells["Spslno"].Value = row;
                    dataGridView_Specialization.Rows[i].Cells["specialization"].Value = dr["name"].ToString();
                    i = i + 1;
                    row++;
                }
            }
        }
        private void btnsavespecialization_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txt_speciliztn.Text))
                {
                    if (btnsavespecialization.Text == "Save")
                    {
                      string spe=this.contrl.check_specialization(txt_speciliztn.Text);
                        if (Convert.ToInt32(spe)==1)
                        {
                            MessageBox.Show("This Specialization " + txt_speciliztn.Text + "  already exists", "Duplication encountered ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        else
                        {
                            this.contrl.Save_Specialization(txt_speciliztn.Text);
                        }
                    }
                    else
                    {
                        this.contrl.Specialization_update(Speci_id, txt_speciliztn.Text);
                        btnsavespecialization.Text = "Save";
                        btn_Cancel.Text = "Close";
                    }
                    DataTable dtb = this.contrl.Fill_Specilization_Grid();
                    AddSpecilizationtoGrid(dtb);
                    this.txt_speciliztn.Text = "";
                }
                else
                {
                    MessageBox.Show("Enter the city..", "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView_Specialization_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    Speci_id = dataGridView_Specialization.CurrentRow.Cells["id"].Value.ToString();
                    if (dataGridView_Specialization.CurrentCell.OwningColumn.Name == "spedit")
                    {
                        txt_speciliztn.Text = dataGridView_Specialization.CurrentRow.Cells["specialization"].Value.ToString();
                        btnsavespecialization.Text = "Update";
                        btn_Cancel.Text = "Cancel";
                    }
                    else if (dataGridView_Specialization.CurrentCell.OwningColumn.Name == "spdelete")
                    {
                        DialogResult res = MessageBox.Show("Are you sure you want to delete..?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (res == DialogResult.Yes)
                        {
                            int i = this.contrl.Delete_Specialization(Speci_id);
                            if (i > 0)
                            {
                                dataGridView_Specialization.Rows.RemoveAt(dataGridView_Specialization.CurrentRow.Index);
                               DataTable dtb= this.contrl.Fill_Specilization_Grid();
                                AddSpecilizationtoGrid(dtb);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error!....", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
