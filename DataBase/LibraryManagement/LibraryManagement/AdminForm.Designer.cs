namespace LibraryManagement
{
    partial class AdminForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAddStu = new System.Windows.Forms.Button();
            this.btnAddBook = new System.Windows.Forms.Button();
            this.btnChangePwd = new System.Windows.Forms.Button();
            this.btnBorrow = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button3 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.btnAddStu);
            this.panel1.Controls.Add(this.btnAddBook);
            this.panel1.Controls.Add(this.btnChangePwd);
            this.panel1.Controls.Add(this.btnBorrow);
            this.panel1.Controls.Add(this.btnReturn);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.btnUpdate);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(230, 553);
            this.panel1.TabIndex = 0;
            // 
            // btnAddStu
            // 
            this.btnAddStu.Location = new System.Drawing.Point(17, 14);
            this.btnAddStu.Margin = new System.Windows.Forms.Padding(20, 5, 20, 5);
            this.btnAddStu.Name = "btnAddStu";
            this.btnAddStu.Size = new System.Drawing.Size(190, 39);
            this.btnAddStu.TabIndex = 9;
            this.btnAddStu.Text = "增加学生";
            this.btnAddStu.UseVisualStyleBackColor = true;
            this.btnAddStu.Click += new System.EventHandler(this.btnAddStu_Click);
            // 
            // btnAddBook
            // 
            this.btnAddBook.Location = new System.Drawing.Point(17, 63);
            this.btnAddBook.Margin = new System.Windows.Forms.Padding(20, 5, 20, 5);
            this.btnAddBook.Name = "btnAddBook";
            this.btnAddBook.Size = new System.Drawing.Size(190, 39);
            this.btnAddBook.TabIndex = 8;
            this.btnAddBook.Text = "增加图书";
            this.btnAddBook.UseVisualStyleBackColor = true;
            this.btnAddBook.Click += new System.EventHandler(this.btnAddBook_Click);
            // 
            // btnChangePwd
            // 
            this.btnChangePwd.Enabled = false;
            this.btnChangePwd.Location = new System.Drawing.Point(20, 455);
            this.btnChangePwd.Margin = new System.Windows.Forms.Padding(20, 5, 20, 5);
            this.btnChangePwd.Name = "btnChangePwd";
            this.btnChangePwd.Size = new System.Drawing.Size(190, 39);
            this.btnChangePwd.TabIndex = 7;
            this.btnChangePwd.Text = "修改密码";
            this.btnChangePwd.UseVisualStyleBackColor = true;
            this.btnChangePwd.Click += new System.EventHandler(this.btnChangePwd_Click);
            // 
            // btnBorrow
            // 
            this.btnBorrow.Enabled = false;
            this.btnBorrow.Location = new System.Drawing.Point(20, 357);
            this.btnBorrow.Margin = new System.Windows.Forms.Padding(20, 5, 20, 5);
            this.btnBorrow.Name = "btnBorrow";
            this.btnBorrow.Size = new System.Drawing.Size(190, 39);
            this.btnBorrow.TabIndex = 6;
            this.btnBorrow.Text = "借书";
            this.btnBorrow.UseVisualStyleBackColor = true;
            this.btnBorrow.Click += new System.EventHandler(this.btnBorrow_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.Enabled = false;
            this.btnReturn.Location = new System.Drawing.Point(20, 406);
            this.btnReturn.Margin = new System.Windows.Forms.Padding(20, 5, 20, 5);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(190, 39);
            this.btnReturn.TabIndex = 5;
            this.btnReturn.Text = "还书";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(20, 210);
            this.button5.Margin = new System.Windows.Forms.Padding(20, 5, 20, 5);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(190, 39);
            this.button5.TabIndex = 4;
            this.button5.Text = "借书查询";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Enabled = false;
            this.btnUpdate.Location = new System.Drawing.Point(20, 308);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(20, 5, 20, 5);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(190, 39);
            this.btnUpdate.TabIndex = 3;
            this.btnUpdate.Text = "修改";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(20, 259);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(20, 5, 20, 5);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(190, 39);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(17, 161);
            this.button2.Margin = new System.Windows.Forms.Padding(20, 5, 20, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(190, 39);
            this.button2.TabIndex = 1;
            this.button2.Text = "查询图书";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(17, 112);
            this.button1.Margin = new System.Windows.Forms.Padding(20, 5, 20, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(190, 39);
            this.button1.TabIndex = 0;
            this.button1.Text = "查询学生";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(230, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(782, 553);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(17, 504);
            this.button3.Margin = new System.Windows.Forms.Padding(20, 5, 20, 5);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(190, 39);
            this.button3.TabIndex = 10;
            this.button3.Text = "导出Excel";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 553);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AdminForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "河北大学图书馆";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AdminForm_FormClosing);
            this.Load += new System.EventHandler(this.AdminForm_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Button btnBorrow;
        private System.Windows.Forms.Button btnChangePwd;
        private System.Windows.Forms.Button btnAddStu;
        private System.Windows.Forms.Button btnAddBook;
        private System.Windows.Forms.Button button3;
    }
}