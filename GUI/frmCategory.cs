using BLL;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmCategory : Form
    {
        private readonly CategoryService categoryService = new CategoryService();
        private readonly ProductService productService = new ProductService();

        public frmCategory()
        {
            InitializeComponent();
        }


        private void frmCategory_Load(object sender, EventArgs e)
        {
            try
            {
                
                var listCategories = categoryService.GetAll();
                BindGrid(listCategories);          
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void LoadCateData()
        {
            try
            {
                var newList = categoryService.GetAll();

                dgv_frmCategory.DataSource = newList;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải về dữ liệu: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void refresh()
        {
            txt_cateid.Text = "";
            txt_catename.Text = "";
            txt_description.Text = "";
        }

        private void BindGrid(List<Category> categories)
        {
            dgv_frmCategory.Rows.Clear();
            foreach (Category cate in categories)
            {
                int index = dgv_frmCategory.Rows.Add();
                dgv_frmCategory.Rows[index].Cells[0].Value = cate.CategoryID;
                dgv_frmCategory.Rows[index].Cells[1].Value = cate.CategoryName;
                dgv_frmCategory.Rows[index].Cells[2].Value = cate.Description;
            }
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txt_cateid.Text) || string.IsNullOrWhiteSpace(txt_catename.Text))
                {
                    string id = txt_cateid.Text.Trim();
                    Category category = categoryService.FindByID(id);
                    if (category != null)
                    {
                        category.CategoryID = txt_cateid.Text.Trim();
                        category.CategoryName = txt_catename.Text;
                        category.Description = txt_description.Text;
                    }

                    MessageBox.Show($"Đã thêm {ProductName} thành công!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadCateData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgv_frmCategory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            DataGridViewRow row = dgv_frmCategory.Rows[e.RowIndex];
            txt_cateid.Text = row.Cells[0].FormattedValue.ToString();
            txt_catename.Text = row.Cells[1].FormattedValue.ToString();
            txt_description.Text = row.Cells[2].FormattedValue.ToString();  
        }

        private void btn_out_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn có muốn thoát", "Thông báo", MessageBoxButtons.YesNo);
            if (rs == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txt_cateid.Text) || string.IsNullOrEmpty(txt_catename.Text))
                {
                    string id = txt_cateid.Text.Trim();
                    Category existingCate = categoryService.FindByID(id);

                    if (existingCate != null)
                    {
                        existingCate.CategoryName = txt_catename.Text;
                        existingCate.Description = txt_description.Text;

                        categoryService.InsertUpdate(existingCate);

                        MessageBox.Show("Cập nhật sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadCateData();
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sản phẩm để cập nhật!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi phát sinh: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            try
            {

                var cateName = categoryService.FindByName(txt_catename.Text);
                var cateID = categoryService.FindByID(txt_cateid.Text);
                if (cateID != null)
                {
                    categoryService.DeleteUpdate(cateName);
                    MessageBox.Show($"Đã xóa sản phẩm thành công {cateName} thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadCateData();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sản phẩm!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi phát sinh: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
