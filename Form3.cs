using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;

namespace BaiThi
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        private int k;
        private void Form3_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource =
                DataAccess.getTable("select * from NhanVien");
            k = dataGridView1.SelectedRows.Count-1;
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string maNhanVien = txtMa.Text;
            string sqlCheck = "select count(*) from NhanVien where MaNV = '" + maNhanVien + "'";

            // Kiểm tra nếu mã nhân viên đã tồn tại
            int count = (int)DataAccess.executeScalar(sqlCheck);
            if (count > 0)
            {
                // Hiển thị thông báo nếu mã nhân viên đã tồn tại
                MessageBox.Show("Mã nhân viên đã tồn tại. Vui lòng nhập mã khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string sql = "insert into NhanVien values ('" +
                    txtMa.Text + "', N'" +
                    txtTen.Text + "', '" +
                    txtNS.Text + "', '" + txtMaLuong.Text + "', '" + txtLuongTN.Text + "')";

                DataAccess.insertUpdateDelete(sql);
                // cập nhật lại datagridview
                dataGridView1.DataSource =
                    DataAccess.getTable("select * from NhanVien");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql = "update NhanVien set TenNV=N'" +
                txtTen.Text + "', NS ='" +
                txtNS.Text + "', MucLuong ='" + 
                txtMaLuong.Text+ "', LuongTN ='" +
                txtLuongTN.Text + " '  where MaNV ='" +
                txtMa.Text + "'";
            DataAccess.insertUpdateDelete(sql);
            // cập nhật lại datagridview
            dataGridView1.DataSource =
                DataAccess.getTable("select * from NhanVien");
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridView1.CurrentRow != null)
            {
                txtMa.Text =
                     dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtTen.Text =
                    dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtNS.Text =
                    dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txtMaLuong.Text =
                    dataGridView1.CurrentRow.Cells[3].Value.ToString();
                txtLuongTN.Text =
                    dataGridView1.CurrentRow.Cells[4].Value.ToString();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql = "delete from NhanVien where MaNV = '" +
                txtMa.Text + "'";
            DataAccess.insertUpdateDelete(sql);
            // cập nhật lại datagridview
            dataGridView1.DataSource =
                DataAccess.getTable("select * from NhanVien");
        }

        private void btnLui_Click(object sender, EventArgs e)
        {
           
            if(k  > 0)
            {
                k = k - 1;
                txtMa.Text = dataGridView1.SelectedRows[k].Cells[0].Value.ToString();
               txtTen.Text = dataGridView1.SelectedRows[k].Cells[1].Value.ToString();
                txtNS.Text = dataGridView1.SelectedRows[k].Cells[2].Value.ToString();
                txtMaLuong.Text = dataGridView1.SelectedRows[k].Cells[3].Value.ToString();
                txtLuongTN.Text = dataGridView1.SelectedRows[k].Cells[4].Value.ToString();
            }
        }

        private void btnTien_Click(object sender, EventArgs e)
        {   

            if (k<dataGridView1.SelectedRows.Count -1)
            {
                txtMa.Text = dataGridView1.SelectedRows[k].Cells[0].Value.ToString();
                txtTen.Text = dataGridView1.SelectedRows[k].Cells[1].Value.ToString();
                txtNS.Text = dataGridView1.SelectedRows[k].Cells[2].Value.ToString();
                txtMaLuong.Text = dataGridView1.SelectedRows[k].Cells[3].Value.ToString();
                txtLuongTN.Text = dataGridView1.SelectedRows[k].Cells[4].Value.ToString();
                /*if (k < dt.Rows.Count - 1)
                {
                    k = k + 1;
                    HienThi(k);
                }*/
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
