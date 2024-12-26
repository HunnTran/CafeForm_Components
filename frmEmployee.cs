using BLL;
using DAL;
using DAL.Entities;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace GUI
{
    public partial class frmEmployee : Form
    {
        

        private UserService employeeService = new UserService();
        private RoleService roleService = new RoleService();


        public frmEmployee()
        {
            InitializeComponent();
        }

        private void frmEmployee_Load(object sender, EventArgs e)
        {
            try
            {
                
                var listEmployees = employeeService.GetAll();
                var listRoles = roleService.GetAll();
                BindGrid(listEmployees);
                FillRole(listRoles);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void LoadEmployeeData()
        {
            try
            {
                var employeeService = new UserService();
                var employees = employeeService.GetAll();


                dgv_displayemployee.DataSource = employees;


                dgv_displayemployee.Columns["Role"].Visible = false;
                dgv_displayemployee.Columns["UserPassword"].Visible = false;

                dgv_displayemployee.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải về dữ liệu: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

            private void FillRole(List<Role> roles)
            {
            
            this.cmb_01.DataSource = roles;
            this.cmb_01.DisplayMember = "RoleName";
            this.cmb_01.ValueMember = "RoleID";
            }

        private void BindGrid(List<User> employees)
        {
            dgv_displayemployee.Rows.Clear();
            foreach (User employee in employees)
            {
                int index = dgv_displayemployee.Rows.Add();
                dgv_displayemployee.Rows[index].Cells[0].Value = employee.UserName;
                dgv_displayemployee.Rows[index].Cells[1].Value = employee.Userpassword;
                
                if(employee.Role != null)
                {
                    dgv_displayemployee.Rows[index].Cells[2].Value = employee.Role.RoleName;
                }
                dgv_displayemployee.Rows [index].Cells[3].Value = employee.FullName;
                dgv_displayemployee.Rows[index].Cells[4].Value = employee.Phone;
            }
        }

        private bool TypeInputCheck()
        {
            if (string.IsNullOrWhiteSpace(txt_username.Text))
            {
                MessageBox.Show("Mã số không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txt_hoten.Text))
            {
                MessageBox.Show("Vui lòng điên tên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txt_sdt.Text) || txt_sdt.Text.Length < 10)
            {
                MessageBox.Show("Vui lòng nhập đúng số điện thoại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txt_displaypassword.Text) || txt_displaypassword.Text.Length < 6)
            {
                MessageBox.Show("Mật khẩu phải ít nhất 6 kí tự.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cmb_01.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn chức vụ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                if(!TypeInputCheck()) { return; }

                var employeeService = new UserService();
                var newEmployee = new User
                {
                    UserName = txt_username.Text,
                    Userpassword = txt_displaypassword.Text,
                    FullName = txt_hoten.Text,
                    RoleID = cmb_01.SelectedValue.ToString(),
                    IdentityCard = txt_idcard.Text
                };
                employeeService.InsertUpdate(newEmployee);

                MessageBox.Show($"Đã thêm nhân viên {newEmployee.FullName} thành công!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadEmployeeData();
            }
            catch (Exception ex)
            {
               MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }

        }     

        private void btn_search_Click(object sender, EventArgs e)
        {
            var employeeService = new UserService();
            var keyword = txt_search.Text;

            var result = employeeService.GetAll()
                .Where(p => p.IdentityCard.Contains(keyword) || p.FullName.Contains(keyword))
                .ToList();

            dgv_displayemployee.DataSource = result;
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            LoadEmployeeData();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                var employeeService = new UserService();
                var selectedID = txt_username.Text;
                var selectedName = txt_hoten.Text;
                var employeeName = employeeService.FindByName(selectedName);
                var employeeID = employeeService.FindByID(selectedID);
                if (employeeID != null)
                {
                    employeeService.DeleteUpdate(employeeName);
                    MessageBox.Show($"Đã xóa nhân viên {employeeName} thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadEmployeeData();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy nhân viên!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi phát sinh: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grp_employeeinfo_Enter(object sender, EventArgs e)
        {

        }
    }
}
