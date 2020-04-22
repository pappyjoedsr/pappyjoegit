using PappyjoeMVC.Controller;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
namespace PappyjoeMVC.View
{
    public partial class Export_Data : Form
    {
        Export_controller cntrl = new Export_controller();
        public Export_Data()
        {
            InitializeComponent();
        }
        private void exportdata_Load(object sender, EventArgs e)
        {
            dtpFrom.Format = DateTimePickerFormat.Short;
            dtpFrom.Value = DateTime.Today;
            dtpTo.Format = DateTimePickerFormat.Short;
            dtpTo.Value = DateTime.Today;
            DataTable dtb = this.cntrl.Get_AllDoctor();
            Fill_Combo(dtb);
        }
        public void Fill_Combo(DataTable dtb)
        {
            if (dtb.Rows.Count > 0)
            {
                cmbDoctor.DisplayMember = "doctor_name";
                cmbDoctor.ValueMember = "id";
                cmbDoctor.DataSource = dtb;
                DataRow dr = dtb.NewRow();
                dr["doctor_name"] = "Select";
                dr["id"] = 0;
                dtb.Rows.InsertAt(dr, 0);
                cmbDoctor.SelectedIndex = 0;
            }
        }

        private void button_export_Click(object sender, EventArgs e)
        {
            try
            {
                string checkStr = "0";
                if (check_procedure.Checked == true)
                {
                    DataTable procedure = this.cntrl.Get_addProcedure();
                    dataGridView_procedurecatalog.DataSource = procedure;
                    Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                    ExcelApp.Application.Workbooks.Add(Type.Missing);
                    ExcelApp.Columns.ColumnWidth = 20;
                    ExcelApp.Range[ExcelApp.Cells[1, 1], ExcelApp.Cells[1, 3]].Merge();
                    ExcelApp.Cells[1, 1] = "PROCEDURE CATALOGE";
                    ExcelApp.Cells[1, 1].HorizontalAlignment = HorizontalAlignment.Center;
                    ExcelApp.Cells[1, 1].Font.Size = 12;
                    ExcelApp.Cells[1, 1].Interior.Color = Color.FromArgb(153, 204, 255);
                    ExcelApp.Columns.ColumnWidth = 20;
                    ExcelApp.Cells[2, 1] = "Running Date";
                    ExcelApp.Cells[2, 1].Font.Size = 10;
                    ExcelApp.Cells[2, 2] = DateTime.Now.ToString("dd-MM-yyyy");
                    ExcelApp.Cells[2, 2].Font.Size = 10;
                    for (int i = 1; i < dataGridView_procedurecatalog.Columns.Count + 1; i++)
                    {
                        ExcelApp.Cells[3, i] = dataGridView_procedurecatalog.Columns[i - 1].HeaderText;
                        ExcelApp.Cells[3, i].ColumnWidth = 25;
                        ExcelApp.Cells[3, i].EntireRow.Font.Bold = true;
                        ExcelApp.Cells[3, i].Interior.Color = Color.FromArgb(0, 102, 204);
                        ExcelApp.Cells[3, i].Font.Size = 10;
                        ExcelApp.Cells[3, i].Font.Name = "Segoe UI";
                        ExcelApp.Cells[3, i].Font.Color = Color.FromArgb(255, 255, 255);
                        ExcelApp.Cells[3, i].Interior.Color = Color.FromArgb(0, 102, 204);
                    }
                    for (int i = 0; i < dataGridView_procedurecatalog.Rows.Count; i++)
                    {
                        try
                        {
                            for (int j = 0; j < dataGridView_procedurecatalog.Columns.Count; j++)
                            {
                                ExcelApp.Cells[i + 4, j + 1] = dataGridView_procedurecatalog.Rows[i].Cells[j].Value.ToString();
                                ExcelApp.Cells[i + 4, j + 1].BorderAround(true);
                                ExcelApp.Cells[i + 4, j + 1].Borders.Color = Color.FromArgb(0, 102, 204);
                                ExcelApp.Cells[i + 4, j + 1].Font.Size = 8;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    ExcelApp.ActiveWorkbook.SaveAs("Procedure Catalog(" + DateTime.Now.ToString("dd-MM-yyyy hh-mm-ss") + ").xls", Microsoft.Office.Interop.Excel.XlFileFormat.xlXMLSpreadsheet, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange);
                    ExcelApp.ActiveWorkbook.Saved = true;
                    ExcelApp.Quit();
                    checkStr = "1";
                }
                if (check_contact.Checked == true)
                {
                    DataTable contact = this.cntrl.patient_details( dtpFrom.Value, dtpTo.Value);
                    dataGridView_contact.DataSource = contact;
                    Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                    ExcelApp.Application.Workbooks.Add(Type.Missing);
                    ExcelApp.Columns.ColumnWidth = 20;
                    ExcelApp.Range[ExcelApp.Cells[1, 1], ExcelApp.Cells[1, 12]].Merge();
                    ExcelApp.Cells[1, 1] = "PATIENT DETAILS";
                    ExcelApp.Cells[1, 1].HorizontalAlignment = HorizontalAlignment.Center;
                    ExcelApp.Cells[1, 1].Font.Size = 12;
                    ExcelApp.Cells[1, 1].Interior.Color = Color.FromArgb(153, 204, 255);
                    ExcelApp.Columns.ColumnWidth = 20;
                    ExcelApp.Cells[2, 1] = "From Date";
                    ExcelApp.Cells[2, 1].Font.Size = 12;
                    ExcelApp.Cells[3, 1] = "To Date";
                    ExcelApp.Cells[3, 1].Font.Size = 12;
                    ExcelApp.Cells[2, 3] = "Running Date";
                    ExcelApp.Cells[2, 3].Font.Size = 12;
                    ExcelApp.Cells[2, 2] = dtpFrom.Value.ToString("dd-MM-yyyy");
                    ExcelApp.Cells[2, 2].Font.Size = 12;
                    ExcelApp.Cells[3, 2] = dtpTo.Value.ToString("dd-MM-yyyy");
                    ExcelApp.Cells[3, 2].Font.Size = 12;
                    ExcelApp.Cells[2, 4] = DateTime.Now.ToString("dd-MM-yyyy");
                    ExcelApp.Cells[2, 4].Font.Size = 12;
                    for (int i = 1; i < dataGridView_contact.Columns.Count + 1; i++)
                    {
                        ExcelApp.Cells[4, i] = dataGridView_contact.Columns[i - 1].HeaderText;
                        ExcelApp.Cells[4, i].ColumnWidth = 25;
                        ExcelApp.Cells[4, i].EntireRow.Font.Bold = true;
                        ExcelApp.Cells[4, i].Interior.Color = Color.FromArgb(0, 102, 204);
                        ExcelApp.Cells[4, i].Font.Size = 10;
                        ExcelApp.Cells[4, i].Font.Name = "Segoe UI";
                        ExcelApp.Cells[4, i].Font.Color = Color.FromArgb(255, 255, 255);
                        ExcelApp.Cells[4, i].Interior.Color = Color.FromArgb(0, 102, 204);
                    }
                    for (int i = 0; i < dataGridView_contact.Rows.Count; i++)
                    {
                        try
                        {
                            for (int j = 0; j < dataGridView_contact.Columns.Count; j++)
                            {
                                try
                                {
                                    ExcelApp.Cells[i + 5, j + 1] = dataGridView_contact.Rows[i].Cells[j].Value.ToString();
                                    ExcelApp.Cells[i + 5, j + 1].BorderAround(true);
                                    ExcelApp.Cells[i + 5, j + 1].Borders.Color = Color.FromArgb(0, 102, 204);
                                    ExcelApp.Cells[i + 5, j + 1].Font.Size = 11;
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
                    ExcelApp.ActiveWorkbook.SaveAs("Contacts(" + DateTime.Now.ToString("dd-MM-yyyy hh-mm-ss") + ").xls", Microsoft.Office.Interop.Excel.XlFileFormat.xlXMLSpreadsheet, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange);
                    ExcelApp.ActiveWorkbook.Saved = true;
                    ExcelApp.Quit();
                    checkStr = "1";
                }
                if (check_appointment.Checked == true)
                {
                    if (cmbDoctor.SelectedIndex > 0)
                    {
                        DataTable appt = this.cntrl.doctor_wise_appointment(cmbDoctor.Text, dtpFrom.Value, dtpTo.Value);
                        dataGridView_appt.DataSource = appt;
                        dataGridView_appt.Columns.RemoveAt(6);
                    }
                    else
                    {
                        DataTable appt = this.cntrl.get_all_appointments(dtpFrom.Value, dtpTo.Value);
                        dataGridView_appt.DataSource = appt;
                    }
                    Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                    ExcelApp.Application.Workbooks.Add(Type.Missing);

                    if (cmbDoctor.SelectedIndex > 0)
                    {
                        ExcelApp.Range[ExcelApp.Cells[1, 1], ExcelApp.Cells[1, 8]].Merge();
                    }
                    else
                    {
                        ExcelApp.Range[ExcelApp.Cells[1, 1], ExcelApp.Cells[1, 9]].Merge();
                    }
                    ExcelApp.Cells[1, 1] = "APPOINTMENTS";
                    ExcelApp.Cells[1, 1].HorizontalAlignment = HorizontalAlignment.Center;
                    ExcelApp.Cells[1, 1].Font.Size = 12;
                    ExcelApp.Cells[1, 1].Interior.Color = Color.FromArgb(153, 204, 255);
                    ExcelApp.Columns.ColumnWidth = 20;
                    ExcelApp.Cells[2, 1] = "From Date";
                    ExcelApp.Cells[2, 1].Font.Size = 12;
                    ExcelApp.Cells[3, 1] = "To Date";
                    ExcelApp.Cells[3, 1].Font.Size = 12;
                    ExcelApp.Cells[2, 6] = "Running Date";
                    ExcelApp.Cells[2, 6].Font.Size = 12;
                    if (cmbDoctor.SelectedIndex > 0)
                    {
                        ExcelApp.Cells[3, 6] = "Doctor";
                        ExcelApp.Cells[3, 6].Font.Size = 12;
                    }
                    ExcelApp.Cells[2, 2] = dtpFrom.Value.ToString("dd-MM-yyyy");
                    ExcelApp.Cells[2, 2].Font.Size = 12;
                    ExcelApp.Cells[3, 2] = dtpTo.Value.ToString("dd-MM-yyyy");
                    ExcelApp.Cells[3, 2].Font.Size = 12;
                    ExcelApp.Cells[2, 7] = DateTime.Now.ToString("dd-MM-yyyy");
                    ExcelApp.Cells[2, 7].Font.Size = 12;
                    if (cmbDoctor.SelectedIndex > 0)
                    {
                        ExcelApp.Cells[3, 7] = cmbDoctor.Text;
                        ExcelApp.Cells[3, 7].Font.Size = 12;
                    }
                    for (int i = 1; i < dataGridView_appt.Columns.Count + 1; i++)
                    {
                        ExcelApp.Cells[4, i] = dataGridView_appt.Columns[i - 1].HeaderText;
                        ExcelApp.Cells[4, i].ColumnWidth = 25;
                        ExcelApp.Cells[4, i].EntireRow.Font.Bold = true;
                        ExcelApp.Cells[4, i].Interior.Color = Color.FromArgb(0, 102, 204);
                        ExcelApp.Cells[4, i].Font.Size = 10;
                        ExcelApp.Cells[4, i].Font.Name = "Segoe UI";
                        ExcelApp.Cells[4, i].Font.Color = Color.FromArgb(255, 255, 255);
                        ExcelApp.Cells[4, i].Interior.Color = Color.FromArgb(0, 102, 204);
                    }
                    for (int i = 0; i < dataGridView_appt.Rows.Count; i++)
                    {
                        try
                        {
                            for (int j = 0; j < dataGridView_appt.Columns.Count; j++)
                            {
                                ExcelApp.Cells[i + 5, j + 1] = dataGridView_appt.Rows[i].Cells[j].Value.ToString();
                                ExcelApp.Cells[i + 5, j + 1].BorderAround(true);
                                ExcelApp.Cells[i + 5, j + 1].Borders.Color = Color.FromArgb(0, 102, 204);
                                ExcelApp.Cells[i + 5, j + 1].Font.Size = 11;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    ExcelApp.ActiveWorkbook.SaveAs("Appointment(" + DateTime.Now.ToString("dd-MM-yyyy hh-mm-ss") + ").xls", Microsoft.Office.Interop.Excel.XlFileFormat.xlXMLSpreadsheet, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange);
                    ExcelApp.ActiveWorkbook.Saved = true;
                    ExcelApp.Quit();
                    checkStr = "1";
                }
                if (check_treatment.Checked == true)
                {
                    if (cmbDoctor.SelectedIndex > 0)
                    {
                        DataTable treat = this.cntrl.doctor_wise_treatment(cmbDoctor.Text, dtpFrom.Value, dtpTo.Value);
                        dataGridView_treatment.DataSource = treat;
                        dataGridView_treatment.Columns.RemoveAt(3);
                    }
                    else
                    {
                        DataTable treat = this.cntrl.all_tratment(dtpFrom.Value, dtpTo.Value);
                        dataGridView_treatment.DataSource = treat;
                    }
                    Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                    ExcelApp.Application.Workbooks.Add(Type.Missing);
                    if (cmbDoctor.SelectedIndex > 0)
                    {
                        ExcelApp.Range[ExcelApp.Cells[1, 1], ExcelApp.Cells[1, 7]].Merge();
                    }
                    else
                    {
                        ExcelApp.Range[ExcelApp.Cells[1, 1], ExcelApp.Cells[1, 8]].Merge();
                    }
                    ExcelApp.Cells[1, 1] = "TREATMENTS";
                    ExcelApp.Cells[1, 1].HorizontalAlignment = HorizontalAlignment.Center;
                    ExcelApp.Cells[1, 1].Font.Size = 12;
                    ExcelApp.Cells[1, 1].Interior.Color = Color.FromArgb(153, 204, 255);
                    ExcelApp.Columns.ColumnWidth = 20;
                    ExcelApp.Cells[2, 1] = "From Date";
                    ExcelApp.Cells[2, 1].Font.Size = 12;
                    ExcelApp.Cells[3, 1] = "To Date";
                    ExcelApp.Cells[3, 1].Font.Size = 12;
                    ExcelApp.Cells[2, 6] = "Running Date";
                    ExcelApp.Cells[2, 6].Font.Size = 12;
                    if (cmbDoctor.SelectedIndex > 0)
                    {
                        ExcelApp.Cells[3, 6] = "Doctor";
                        ExcelApp.Cells[3, 6].Font.Size = 12;
                    }
                    ExcelApp.Cells[2, 2] = dtpFrom.Value.ToString("dd-MM-yyyy");
                    ExcelApp.Cells[2, 2].Font.Size = 12;
                    ExcelApp.Cells[3, 2] = dtpTo.Value.ToString("dd-MM-yyyy");
                    ExcelApp.Cells[3, 2].Font.Size = 12;
                    ExcelApp.Cells[2, 7] = DateTime.Now.ToString("dd-MM-yyyy");
                    ExcelApp.Cells[2, 7].Font.Size = 12;
                    if (cmbDoctor.SelectedIndex > 0)
                    {
                        ExcelApp.Cells[3, 7].HorizontalAlignment = HorizontalAlignment.Right;
                        ExcelApp.Cells[3, 7] = cmbDoctor.Text;
                        ExcelApp.Cells[3, 7].Font.Size = 12;
                    }
                    for (int i = 1; i < dataGridView_treatment.Columns.Count + 1; i++)
                    {
                        ExcelApp.Cells[4, i] = dataGridView_treatment.Columns[i - 1].HeaderText;
                        ExcelApp.Cells[4, i].ColumnWidth = 25;
                        ExcelApp.Cells[4, i].EntireRow.Font.Bold = true;
                        ExcelApp.Cells[4, i].Interior.Color = Color.FromArgb(0, 102, 204);
                        ExcelApp.Cells[4, i].Font.Size = 12;
                        ExcelApp.Cells[4, i].Font.Name = "Segoe UI";
                        ExcelApp.Cells[4, i].Font.Color = Color.FromArgb(255, 255, 255);
                        ExcelApp.Cells[4, i].Interior.Color = Color.FromArgb(0, 102, 204);
                    }
                    for (int i = 0; i < dataGridView_treatment.Rows.Count; i++)
                    {
                        try
                        {
                            for (int j = 0; j < dataGridView_treatment.Columns.Count; j++)
                            {
                                ExcelApp.Cells[i + 5, j + 1] = dataGridView_treatment.Rows[i].Cells[j].Value.ToString();
                                ExcelApp.Cells[i + 5, j + 1].BorderAround(true);
                                ExcelApp.Cells[i + 5, j + 1].Borders.Color = Color.FromArgb(0, 102, 204);
                                ExcelApp.Cells[i + 5, j + 1].Font.Size = 11;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    ExcelApp.ActiveWorkbook.SaveAs("Treatment(" + DateTime.Now.ToString("dd-MM-yyyy hh-mm-ss") + ").xls", Microsoft.Office.Interop.Excel.XlFileFormat.xlXMLSpreadsheet, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange);
                    ExcelApp.ActiveWorkbook.Saved = true;
                    ExcelApp.Quit();
                    DataTable dtb = this.cntrl.Get_AllDoctor();
                    Fill_Combo(dtb);
                    checkStr = "1";
                }
                if (check_expense.Checked == true)
                {
                    DataTable expense = this.cntrl.expense(dtpFrom.Value, dtpTo.Value);
                    dataGridView_expense.DataSource = expense;
                    Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                    ExcelApp.Application.Workbooks.Add(Type.Missing);
                    ExcelApp.Range[ExcelApp.Cells[1, 1], ExcelApp.Cells[1, 4]].Merge();
                    ExcelApp.Cells[1, 1] = "EXPENSE";
                    ExcelApp.Cells[1, 1].HorizontalAlignment = HorizontalAlignment.Center;
                    ExcelApp.Cells[1, 1].Font.Size = 12;
                    ExcelApp.Cells[1, 1].Interior.Color = Color.FromArgb(153, 204, 255);
                    ExcelApp.Columns.ColumnWidth = 20;
                    ExcelApp.Cells[2, 1] = "From Date";
                    ExcelApp.Cells[2, 1].Font.Size = 12;
                    ExcelApp.Cells[3, 1] = "To Date";
                    ExcelApp.Cells[3, 1].Font.Size = 12;
                    ExcelApp.Cells[2, 3] = "Running Date";
                    ExcelApp.Cells[2, 3].Font.Size = 12;
                    ExcelApp.Cells[2, 2] = dtpFrom.Value.ToString("dd-MM-yyyy");
                    ExcelApp.Cells[2, 2].Font.Size = 12;
                    ExcelApp.Cells[3, 2] = dtpTo.Value.ToString("dd-MM-yyyy");
                    ExcelApp.Cells[3, 2].Font.Size = 12;
                    ExcelApp.Cells[2, 4] = DateTime.Now.ToString("dd-MM-yyyy");
                    ExcelApp.Cells[2, 4].Font.Size = 12;
                    for (int i = 1; i < dataGridView_expense.Columns.Count + 1; i++)
                    {
                        ExcelApp.Cells[4, i] = dataGridView_expense.Columns[i - 1].HeaderText;
                        ExcelApp.Cells[4, i].ColumnWidth = 25;
                        ExcelApp.Cells[4, i].EntireRow.Font.Bold = true;
                        ExcelApp.Cells[4, i].Interior.Color = Color.FromArgb(0, 102, 204);
                        ExcelApp.Cells[4, i].Font.Size = 12;
                        ExcelApp.Cells[4, i].Font.Name = "Segoe UI";
                        ExcelApp.Cells[4, i].Font.Color = Color.FromArgb(255, 255, 255);
                        ExcelApp.Cells[4, i].Interior.Color = Color.FromArgb(0, 102, 204);
                    }
                    for (int i = 0; i < dataGridView_expense.Rows.Count; i++)
                    {
                        try
                        {
                            for (int j = 0; j < dataGridView_expense.Columns.Count; j++)
                            {
                                ExcelApp.Cells[i + 5, j + 1] = dataGridView_expense.Rows[i].Cells[j].Value.ToString();
                                ExcelApp.Cells[i + 5, j + 1].BorderAround(true);
                                ExcelApp.Cells[i + 5, j + 1].Borders.Color = Color.FromArgb(0, 102, 204);
                                ExcelApp.Cells[i + 5, j + 1].Font.Size = 11;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    ExcelApp.ActiveWorkbook.SaveAs("Expense(" + DateTime.Now.ToString("dd-MM-yyyy hh-mm-ss") + ").xls", Microsoft.Office.Interop.Excel.XlFileFormat.xlXMLSpreadsheet, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange);
                    ExcelApp.ActiveWorkbook.Saved = true;
                    ExcelApp.Quit();
                    checkStr = "1";
                }
                if (check_prescription.Checked)
                {
                    if (cmbDoctor.SelectedIndex > 0)
                    {
                        DataTable prescription = this.cntrl.doctor_wise_prescription(cmbDoctor.Text, dtpFrom.Value, dtpTo.Value);
                        dataGridView_prescription.DataSource = prescription;
                        dataGridView_prescription.Columns.RemoveAt(1);
                    }
                    else
                    {
                        DataTable prescription = this.cntrl.All_prescription(dtpFrom.Value, dtpTo.Value);
                        dataGridView_prescription.DataSource = prescription;
                    }
                    Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                    ExcelApp.Application.Workbooks.Add(Type.Missing);
                    if (cmbDoctor.SelectedIndex > 0)
                    {
                        ExcelApp.Range[ExcelApp.Cells[1, 1], ExcelApp.Cells[1, 13]].Merge();
                    }
                    else
                    {
                        ExcelApp.Range[ExcelApp.Cells[1, 1], ExcelApp.Cells[1, 14]].Merge();
                    }
                    ExcelApp.Cells[1, 1] = "PRESCRIPTION";
                    ExcelApp.Cells[1, 1].HorizontalAlignment = HorizontalAlignment.Center;
                    ExcelApp.Cells[1, 1].Font.Size = 12;
                    ExcelApp.Cells[1, 1].Interior.Color = Color.FromArgb(153, 204, 255);
                    ExcelApp.Columns.ColumnWidth = 20;
                    ExcelApp.Cells[2, 1] = "From Date";
                    ExcelApp.Cells[2, 1].Font.Size = 12;
                    ExcelApp.Cells[3, 1] = "To Date";
                    ExcelApp.Cells[3, 1].Font.Size = 12;
                    ExcelApp.Cells[2, 6] = "Running Date";
                    ExcelApp.Cells[2, 6].Font.Size = 12;
                    if (cmbDoctor.SelectedIndex > 0)
                    {
                        ExcelApp.Cells[3, 6] = "Doctor";
                        ExcelApp.Cells[3, 6].Font.Size = 12;
                    }
                    ExcelApp.Cells[2, 2] = dtpFrom.Value.ToString("dd-MM-yyyy");
                    ExcelApp.Cells[2, 2].Font.Size = 12;
                    ExcelApp.Cells[3, 2] = dtpTo.Value.ToString("dd-MM-yyyy");
                    ExcelApp.Cells[3, 2].Font.Size = 12;
                    ExcelApp.Cells[2, 7] = DateTime.Now.ToString("dd-MM-yyyy");
                    ExcelApp.Cells[2, 7].Font.Size = 12;
                    if (cmbDoctor.SelectedIndex > 0)
                    {
                        ExcelApp.Cells[3, 7] = cmbDoctor.Text;
                        ExcelApp.Cells[3, 7].Font.Size = 12;
                    }
                    for (int i = 1; i < dataGridView_prescription.Columns.Count + 1; i++)
                    {
                        ExcelApp.Cells[4, i] = dataGridView_prescription.Columns[i - 1].HeaderText;
                        ExcelApp.Cells[4, i].ColumnWidth = 25;
                        ExcelApp.Cells[4, i].EntireRow.Font.Bold = true;
                        ExcelApp.Cells[4, i].Interior.Color = Color.FromArgb(0, 102, 204);
                        ExcelApp.Cells[4, i].Font.Size = 12;
                        ExcelApp.Cells[4, i].Font.Name = "Segoe UI";
                        ExcelApp.Cells[4, i].Font.Color = Color.FromArgb(255, 255, 255);
                        ExcelApp.Cells[4, i].Interior.Color = Color.FromArgb(0, 102, 204);
                    }
                    for (int i = 0; i < dataGridView_prescription.Rows.Count - 1; i++)
                    {
                        try
                        {
                            for (int j = 0; j < dataGridView_prescription.Columns.Count; j++)
                            {
                                try
                                {
                                    ExcelApp.Cells[i + 5, j + 1] = dataGridView_prescription.Rows[i].Cells[j].Value.ToString();
                                    ExcelApp.Cells[i + 5, j + 1].BorderAround(true);
                                    ExcelApp.Cells[i + 5, j + 1].Borders.Color = Color.FromArgb(0, 102, 204);
                                    ExcelApp.Cells[i + 5, j + 1].Font.Size = 11;
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
                    ExcelApp.ActiveWorkbook.SaveAs("Prescription(" + DateTime.Now.ToString("dd-MM-yyyy hh-mm-ss") + ").xls", Microsoft.Office.Interop.Excel.XlFileFormat.xlXMLSpreadsheet, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange);
                    ExcelApp.ActiveWorkbook.Saved = true;
                    ExcelApp.Quit();
                    checkStr = "1";
                }
                if (checkStr == "0")
                {
                    MessageBox.Show("Please select options and try again.....", "Data Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    //string path = "C:\\Users\\";
                    string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    MessageBox.Show("Successfully Exported to " + path + " as Excel File", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please select options and try again..... ", "Data Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}