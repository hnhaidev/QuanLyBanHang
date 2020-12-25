using QuanLyBanHang.DAO;
using QuanLyBanHang.GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    public partial class UserBill : UserControl
    {
        public static int idBill;
        public static string ClientName;
        public static string StaffName;
        public static double SumMoney;
        public UserBill()
        {
            InitializeComponent();
            LoadBIll();
        }
        void LoadBIll()
        {
            dtgrBill.DataSource = BillDAO.Instance.GetListBill();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(BillDAO.Instance.SearchBill(txtSearch.Text).Rows.Count > 0)
            {
                dtgrBill.DataSource = BillDAO.Instance.SearchBill(txtSearch.Text);
            }
            else
            {
                MessageBox.Show("Không tìm thấy !");
            }
        }

        private void dtpSearch_ValueChanged(object sender, EventArgs e)
        {
            if (BillDAO.Instance.SearchBillByDay(dtpSearch.Value).Rows.Count > 0)
            {
                dtgrBill.DataSource = BillDAO.Instance.SearchBillByDay(dtpSearch.Value);
            }
            else
            {
                MessageBox.Show("Không có hóa đơn ngày này!");
            }
        }

        private void btnRefesh_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            LoadBIll();
        }

        private void btnPrintToExcel_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ToExcel(dtgrBill, saveFileDialog1.FileName);
            }
        }
        private void ToExcel(DataGridView dataGridView1, string fileName)
        {
            Microsoft.Office.Interop.Excel.Application excel;
            Microsoft.Office.Interop.Excel.Workbook workbook;
            Microsoft.Office.Interop.Excel.Worksheet worksheet;

            try
            {
                excel = new Microsoft.Office.Interop.Excel.Application();
                excel.Visible = false;
                excel.DisplayAlerts = false;

                workbook = excel.Workbooks.Add(Type.Missing);

                worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets["Sheet1"];
                worksheet.Name = "Bill - Admin Ngọc Hải";

                // export header
                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                {
                    worksheet.Cells[1, i + 1] = dataGridView1.Columns[i].HeaderText;
                }

                // export content
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                    }
                }

                // save workbook
                workbook.SaveAs(fileName);
                workbook.Close();
                excel.Quit();
                MessageBox.Show("Export successful.!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                workbook = null;
                worksheet = null;
            }
        }

        private void dtgrBill_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row < 0) return;
            dtgrBill.Rows[row].Selected = true;
            idBill = (int)dtgrBill.Rows[row].Cells["Bill ID"].Value;
            ClientName = dtgrBill.Rows[row].Cells["Client Name"].Value.ToString();
            StaffName = dtgrBill.Rows[row].Cells["Staff Name"].Value.ToString();
            SumMoney = (double)dtgrBill.Rows[row].Cells["Sum Money"].Value;

            fBillInfo f = new fBillInfo();
            f.Show();
        }
    }
}
