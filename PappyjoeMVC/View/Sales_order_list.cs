﻿using System;
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
    public partial class Sales_order_list : Form
    {
        Sales_order_list_controller cntrl = new Sales_order_list_controller();
        public string Form_Name;
        string date_From;
        string date_To;
        bool flag_from_inventory = false;
        public Sales_order_list()
        {
            InitializeComponent();
        }
        public Sales_order_list(string FormName)
        {
            InitializeComponent();
            Form_Name = FormName;
        }
        public Sales_order_list(string date1, string date2)
        {
            InitializeComponent();
            date_From = date1;
            date_To = date2;
            flag_from_inventory = true;
        }
        private void Sales_order_list_Load(object sender, EventArgs e)
        {
            try
            {
                Lab_Msg.Visible = false;
                if (flag_from_inventory == true)
                {
                    DataTable dt = this.cntrl.SalesOrderdetls(date_From, date_To);
                    if (dt.Rows.Count > 0)
                    {
                        Fill_dgvSale(dt);
                    }
                }
                else
                {
                    string date = DateTime.Now.ToString("yyyy-MM-dd");
                    DataTable dtb = this.cntrl.getSales(date);
                    if (dtb.Rows.Count > 0)
                    {
                        Fill_dgvSale(dtb);
                    }
                    else
                    {
                        int x = (panel2.Size.Width - Lab_Msg.Size.Width) / 2;
                        Lab_Msg.Location = new Point(x, Lab_Msg.Location.Y);
                        Lab_Msg.Visible = true;
                    }
                }
                dgv_sales.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
                dgv_sales.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgv_sales.EnableHeadersVisualStyles = false;
                dgv_sales.ColumnHeadersDefaultCellStyle.Font = new Font("Sego UI", 9, FontStyle.Regular);
                dgv_sales.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgv_sales.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgv_sales.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgv_sales.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgv_sales.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgv_sales.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgv_sales.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgv_sales.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                foreach (DataGridViewColumn cl in dgv_sales.Columns)
                {
                    cl.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                PappyjoeMVC.Model.Connection.MyGlobals.Date_From = DTP_From.Value.ToString("yyyy-MM-dd");
                PappyjoeMVC.Model.Connection.MyGlobals.Date_To = DTP_To.Value.ToString("yyyy-MM-dd");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void Fill_dgvSale(DataTable dtb)
        {
            if (dtb.Rows.Count > 0)
            {
                dgv_sales.Rows.Clear();
                int num = 1;
                for (int i = 0; i < dtb.Rows.Count; i++)
                {
                    dgv_sales.Rows.Add();
                    dgv_sales.Rows[i].Cells["colslNo"].Value = num;
                    dgv_sales.Rows[i].Cells["colInvNum"].Value = dtb.Rows[i]["DocNumber"].ToString();
                    dgv_sales.Rows[i].Cells["colinvDate"].Value = Convert.ToDateTime(dtb.Rows[i]["DocDate"].ToString()).ToString("MM/dd/yyyy"); ;
                    dgv_sales.Rows[i].Cells["colcustNo"].Value = dtb.Rows[i]["Cus_Id"].ToString();
                    dgv_sales.Rows[i].Cells["colName"].Value = dtb.Rows[i]["CustomerName"].ToString();
                    dgv_sales.Rows[i].Cells["colPhone"].Value = dtb.Rows[i]["Phone"].ToString();
                    dgv_sales.Rows[i].Cells["colItems"].Value = dtb.Rows[i]["qty"].ToString();
                    dgv_sales.Rows[i].Cells["ColAmount"].Value = Convert.ToDecimal(dtb.Rows[i]["amount"].ToString()).ToString("##.00");
                    dgv_sales.Rows[i].Cells["colEdit"].Value = PappyjoeMVC.Properties.Resources.editicon;
                    dgv_sales.Rows[i].Cells["delete"].Value = PappyjoeMVC.Properties.Resources.deleteicon;
                    num = num + 1;
                }
            }
        }

        private void dgv_sales_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            {
                if (e.RowIndex >= 0)
                {
                    int invnum = Convert.ToInt32(dgv_sales.CurrentRow.Cells["colInvNum"].Value.ToString());
                    int rowindex = dgv_sales.CurrentRow.Index;
                    if (dgv_sales.CurrentCell.OwningColumn.Name == "colEdit")
                    {
                        var form2 = new PappyjoeMVC.View.SalesOrder(invnum);
                        form2.ShowDialog();
                    }
                    else if (dgv_sales.CurrentCell.OwningColumn.Name == "delete")
                    {
                        int i = 0, j = 0;
                        if (invnum >0)
                        {
                            DialogResult res = MessageBox.Show("Are you sure you want to delete?", "Delete confirmation",
                                  MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (res == DialogResult.No)
                            {
                            }
                            else
                            {
                                i = this.cntrl.update_salesOrder(invnum);
                                if (i > 0)
                                {
                                    dgv_sales.Rows.RemoveAt(rowindex);
                                }
                                else
                                {
                                    MessageBox.Show("Error occured while deleting the data", "Failed !..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                }
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btn_Sales_Click(object sender, EventArgs e)
        {
            if (dgv_sales.Rows.Count > 0)
            {
                PappyjoeMVC.Model.Connection.MyGlobals.global_Flag = true;
                string invNumOrder = dgv_sales.CurrentRow.Cells["colInvNum"].Value.ToString();
                if (invNumOrder != "")
                {
                    var form2 = new PappyjoeMVC.View.Sales(invNumOrder, "Sales Order");
                    form2.ShowDialog();
                    form2.Dispose();
                }
            }
        }
        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            Lab_Msg.Visible = false;
            string date = DateTime.Now.ToString("MM/dd/yyyy");
            DataTable dtb = this.cntrl.get_dataRefresh(date);
            if (dtb.Rows.Count > 0)
            {
                Fill_dgvSale(dtb);
            }
            else
            {
                int x = (panel2.Size.Width - Lab_Msg.Size.Width) / 2;
                Lab_Msg.Location = new Point(x, Lab_Msg.Location.Y);
                Lab_Msg.Visible = true;
            }
        }
        private void Btn_Show_Click(object sender, EventArgs e)
        {
            try
            {
                string from = DTP_From.Value.ToString("yyyy-MM-dd");
                string to = DTP_To.Value.ToString("yyyy-MM-dd");
                PappyjoeMVC.Model.Connection.MyGlobals.Date_From = DTP_From.Value.ToString("yyyy-MM-dd");
                PappyjoeMVC.Model.Connection.MyGlobals.Date_To = DTP_To.Value.ToString("yyyy-MM-dd");
                Lab_Msg.Visible = false;
                if (Convert.ToDateTime(from).Date > Convert.ToDateTime(to).Date)
                {
                    MessageBox.Show("From date should be less than To date", "From Date is grater ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DTP_From.Value = DateTime.Today;
                }
                else
                {
                    DataTable dt = this.cntrl.showdata(from, to);
                    if (dt.Rows.Count > 0)
                    {
                        Fill_dgvSale(dt);
                    }
                    else
                    {
                        int x = (panel2.Size.Width - Lab_Msg.Size.Width) / 2;
                        Lab_Msg.Location = new Point(x, Lab_Msg.Location.Y);
                        Lab_Msg.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
