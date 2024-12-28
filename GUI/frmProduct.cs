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
    public partial class frmProduct : Form
    {
        private readonly CategoryService categoryService = new CategoryService();
        private readonly ProductService productService = new ProductService();

        public frmProduct()
        {
            InitializeComponent();
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            try
            {
                if (!TypeInputCheck()) { return; }

                string id = txt_ProductID.Text.Trim();
                Product product = productService.FindByID(id);
                if (product != null)
                {
                    product.ProductID = txt_ProductID.Text.Trim();
                    product.ProductName = txt_ProductName.Text;
                    product.Price = int.Parse(txt_Price.Text);
                    product.Description = txt_Description.Text;
                    product.CategoryID = combo_category.SelectedValue.ToString();
                }

                MessageBox.Show($"Đã thêm {ProductName} thành công!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadProductData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            try
            {
                
                var productName = productService.FindByName(txt_ProductName.Text);
                var productID = productService.FindByID(txt_ProductID.Text);
                if (productID != null)
                {
                    productService.DeleteUpdate(productName);
                    MessageBox.Show($"Đã xóa sản phẩm thành công {productName} thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadProductData();
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

        private void btn_sua_Click(object sender, EventArgs e)
        {
            try
            {
                if (!TypeInputCheck()) { return; }

                string id = txt_ProductID.Text.Trim();
                Product existingProduct = productService.FindByID(id);

                if (existingProduct != null)
                {
                    existingProduct.ProductName = txt_ProductName.Text.Trim();
                    existingProduct.Price = int.Parse(txt_Price.Text);
                    existingProduct.Description = txt_Description.Text.Trim();
                    existingProduct.CategoryID = combo_category.SelectedValue.ToString();

                    productService.InsertUpdate(existingProduct);

                    MessageBox.Show("Cập nhật sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadProductData();
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

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            LoadProductData();  
        }

        private void btn_search_Click(object sender, EventArgs e)
        {

            var result = productService.GetAll()
                .Where(p => p.ProductID.Contains(txt_ProductID.Text) || p.ProductName.Contains(txt_ProductName.Text))
                .ToList();

            dgv_frmProduct.DataSource = result;
        }

        private void btn_openCatefrm_Click(object sender, EventArgs e)
        {
            frmCategory frmCategory = new frmCategory();    
            frmCategory.ShowDialog();
        }

        private void frmProduct_Load(object sender, EventArgs e)
        {
            try
            {
                var listProducts = productService.GetAll();
                var listCategories = categoryService.GetAll();
                BindGrid(listProducts);
                FillCategory(listCategories);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void BindGrid(List<Product> categories)
        {
            dgv_frmProduct.Rows.Clear();
            foreach (Product prod in categories)
            {
                int index = dgv_frmProduct.Rows.Add();
                dgv_frmProduct.Rows[index].Cells[0].Value = prod.ProductID;
                dgv_frmProduct.Rows[index].Cells[1].Value = prod.ProductName;
                dgv_frmProduct.Rows[index].Cells[2].Value = prod.Price.ToString();
                if (prod.Category != null)
                {
                    dgv_frmProduct.Rows[index].Cells[3].Value = prod.Category.CategoryName;
                }
                dgv_frmProduct.Rows[index].Cells[4].Value = prod.Description;
                dgv_frmProduct.Rows[index].Cells[5].Value = prod.Images;
            }
        }

        private void FillCategory(List<Category> categories)
        {
            this.combo_category.DataSource = categories;
            this.combo_category.DisplayMember = "Category Name";
            this.combo_category.ValueMember = "CategoryID";
        }

        private void refresh()
        {
            txt_ProductID.Text = "";
            txt_ProductName.Text = "";
            combo_category.SelectedIndex = 0;
            txt_Price.Text = "";
            txt_Description.Text = "";
            txt_image.Text = "";
        }

        private bool TypeInputCheck()
        {
            if (string.IsNullOrWhiteSpace(txt_ProductID.Text))
            {
                MessageBox.Show("Mã số không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txt_ProductName.Text))
            {
                MessageBox.Show("Vui lòng điên tên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txt_Price.Text) || txt_Price.Text.Length <= 0)
            {
                MessageBox.Show("Vui lòng nhập đúng mức giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (combo_category.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn danh mục.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }


        private void LoadProductData()
        {
            try
            {
                var newList = productService.GetAll();

                dgv_frmProduct.DataSource = newList;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải về dữ liệu: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgv_frmProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           if (e.RowIndex == -1)
           {
                return;
           }
            DataGridViewRow row = dgv_frmProduct.Rows[e.RowIndex];
            txt_ProductID.Text = row.Cells[0].FormattedValue.ToString();
            txt_ProductName.Text = row.Cells[1].FormattedValue.ToString();
            txt_Price.Text = row.Cells[2].Value.ToString();
            combo_category.SelectedIndex = combo_category.FindString(dgv_frmProduct.Rows[e.RowIndex].Cells[3].FormattedValue.ToString());
            txt_Description.Text = row.Cells[4].Value.ToString();
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn có muốn thoát", "Thông báo", MessageBoxButtons.YesNo);
            if (rs == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
