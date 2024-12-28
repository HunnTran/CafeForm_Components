namespace GUI
{
    partial class frmCategory
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgv_frmCategory = new System.Windows.Forms.DataGridView();
            this.btn_them = new System.Windows.Forms.Button();
            this.btn_edit = new System.Windows.Forms.Button();
            this.btn_xoa = new System.Windows.Forms.Button();
            this.btn_out = new System.Windows.Forms.Button();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_cateid = new System.Windows.Forms.TextBox();
            this.txt_catename = new System.Windows.Forms.TextBox();
            this.txt_description = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_frmCategory)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_frmCategory
            // 
            this.dgv_frmCategory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_frmCategory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.D});
            this.dgv_frmCategory.Location = new System.Drawing.Point(26, 37);
            this.dgv_frmCategory.Name = "dgv_frmCategory";
            this.dgv_frmCategory.RowHeadersWidth = 51;
            this.dgv_frmCategory.RowTemplate.Height = 24;
            this.dgv_frmCategory.Size = new System.Drawing.Size(430, 385);
            this.dgv_frmCategory.TabIndex = 0;
            this.dgv_frmCategory.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_frmCategory_CellClick);
            // 
            // btn_them
            // 
            this.btn_them.Location = new System.Drawing.Point(516, 222);
            this.btn_them.Name = "btn_them";
            this.btn_them.Size = new System.Drawing.Size(139, 31);
            this.btn_them.TabIndex = 1;
            this.btn_them.Text = "Thêm";
            this.btn_them.UseVisualStyleBackColor = true;
            this.btn_them.Click += new System.EventHandler(this.btn_them_Click);
            // 
            // btn_edit
            // 
            this.btn_edit.Location = new System.Drawing.Point(681, 222);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(139, 31);
            this.btn_edit.TabIndex = 2;
            this.btn_edit.Text = "Sửa";
            this.btn_edit.UseVisualStyleBackColor = true;
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click);
            // 
            // btn_xoa
            // 
            this.btn_xoa.Location = new System.Drawing.Point(516, 270);
            this.btn_xoa.Name = "btn_xoa";
            this.btn_xoa.Size = new System.Drawing.Size(139, 31);
            this.btn_xoa.TabIndex = 3;
            this.btn_xoa.Text = "Xóa";
            this.btn_xoa.UseVisualStyleBackColor = true;
            this.btn_xoa.Click += new System.EventHandler(this.btn_xoa_Click);
            // 
            // btn_out
            // 
            this.btn_out.Location = new System.Drawing.Point(681, 270);
            this.btn_out.Name = "btn_out";
            this.btn_out.Size = new System.Drawing.Size(139, 31);
            this.btn_out.TabIndex = 4;
            this.btn_out.Text = "Thoát";
            this.btn_out.UseVisualStyleBackColor = true;
            this.btn_out.Click += new System.EventHandler(this.btn_out_Click);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Category ID";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 125;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Category Name";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 125;
            // 
            // D
            // 
            this.D.HeaderText = "Description";
            this.D.MinimumWidth = 6;
            this.D.Name = "D";
            this.D.Width = 125;
            // 
            // txt_cateid
            // 
            this.txt_cateid.Location = new System.Drawing.Point(516, 82);
            this.txt_cateid.Name = "txt_cateid";
            this.txt_cateid.Size = new System.Drawing.Size(304, 22);
            this.txt_cateid.TabIndex = 5;
            // 
            // txt_catename
            // 
            this.txt_catename.Location = new System.Drawing.Point(516, 136);
            this.txt_catename.Name = "txt_catename";
            this.txt_catename.Size = new System.Drawing.Size(304, 22);
            this.txt_catename.TabIndex = 6;
            // 
            // txt_description
            // 
            this.txt_description.Location = new System.Drawing.Point(516, 182);
            this.txt_description.Name = "txt_description";
            this.txt_description.Size = new System.Drawing.Size(304, 22);
            this.txt_description.TabIndex = 7;
            // 
            // frmCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 450);
            this.Controls.Add(this.txt_description);
            this.Controls.Add(this.txt_catename);
            this.Controls.Add(this.txt_cateid);
            this.Controls.Add(this.btn_out);
            this.Controls.Add(this.btn_xoa);
            this.Controls.Add(this.btn_edit);
            this.Controls.Add(this.btn_them);
            this.Controls.Add(this.dgv_frmCategory);
            this.Name = "frmCategory";
            this.Text = "CATEGORY";
            this.Load += new System.EventHandler(this.frmCategory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_frmCategory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_frmCategory;
        private System.Windows.Forms.Button btn_them;
        private System.Windows.Forms.Button btn_edit;
        private System.Windows.Forms.Button btn_xoa;
        private System.Windows.Forms.Button btn_out;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn D;
        private System.Windows.Forms.TextBox txt_cateid;
        private System.Windows.Forms.TextBox txt_catename;
        private System.Windows.Forms.TextBox txt_description;
    }
}

