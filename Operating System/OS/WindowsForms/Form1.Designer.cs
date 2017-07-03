namespace WindowsForms
{
    partial class Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form));
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.lvReday = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labCommand = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labResult = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnProcess0 = new System.Windows.Forms.Button();
            this.btnProcess9 = new System.Windows.Forms.Button();
            this.btnProcess8 = new System.Windows.Forms.Button();
            this.btnProcess7 = new System.Windows.Forms.Button();
            this.btnProcess6 = new System.Windows.Forms.Button();
            this.btnProcess5 = new System.Windows.Forms.Button();
            this.btnProcess4 = new System.Windows.Forms.Button();
            this.btnProcess3 = new System.Windows.Forms.Button();
            this.btnProcess2 = new System.Windows.Forms.Button();
            this.btnProcess1 = new System.Windows.Forms.Button();
            this.btnCreatProcess = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.lvBlock = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.labRunning = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.labTimer = new System.Windows.Forms.Label();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.labEndResult = new System.Windows.Forms.Label();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.labNumber = new System.Windows.Forms.Label();
            this.btnNewForm = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(570, 41);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 0;
            this.btnStop.Text = "关机";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(570, 12);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "开机";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lvReday
            // 
            this.lvReday.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvReday.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvReday.FullRowSelect = true;
            this.lvReday.Location = new System.Drawing.Point(3, 17);
            this.lvReday.MultiSelect = false;
            this.lvReday.Name = "lvReday";
            this.lvReday.Size = new System.Drawing.Size(194, 155);
            this.lvReday.TabIndex = 2;
            this.lvReday.UseCompatibleStateImageBehavior = false;
            this.lvReday.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "进程名称";
            this.columnHeader1.Width = 90;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "进程编号";
            this.columnHeader2.Width = 90;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labCommand);
            this.groupBox1.Location = new System.Drawing.Point(12, 150);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(190, 50);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "正在执行的指令";
            // 
            // labCommand
            // 
            this.labCommand.AutoSize = true;
            this.labCommand.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labCommand.Location = new System.Drawing.Point(25, 25);
            this.labCommand.Name = "labCommand";
            this.labCommand.Size = new System.Drawing.Size(24, 16);
            this.labCommand.TabIndex = 0;
            this.labCommand.Text = "无";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labResult);
            this.groupBox2.Location = new System.Drawing.Point(238, 150);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(190, 50);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "执行进程的中间结果";
            // 
            // labResult
            // 
            this.labResult.AutoSize = true;
            this.labResult.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labResult.Location = new System.Drawing.Point(25, 25);
            this.labResult.Name = "labResult";
            this.labResult.Size = new System.Drawing.Size(24, 16);
            this.labResult.TabIndex = 1;
            this.labResult.Text = "无";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnProcess0);
            this.groupBox3.Controls.Add(this.btnProcess9);
            this.groupBox3.Controls.Add(this.btnProcess8);
            this.groupBox3.Controls.Add(this.btnProcess7);
            this.groupBox3.Controls.Add(this.btnProcess6);
            this.groupBox3.Controls.Add(this.btnProcess5);
            this.groupBox3.Controls.Add(this.btnProcess4);
            this.groupBox3.Controls.Add(this.btnProcess3);
            this.groupBox3.Controls.Add(this.btnProcess2);
            this.groupBox3.Controls.Add(this.btnProcess1);
            this.groupBox3.Controls.Add(this.btnCreatProcess);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(416, 61);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "进程";
            // 
            // btnProcess0
            // 
            this.btnProcess0.Location = new System.Drawing.Point(111, 21);
            this.btnProcess0.Name = "btnProcess0";
            this.btnProcess0.Size = new System.Drawing.Size(23, 23);
            this.btnProcess0.TabIndex = 15;
            this.btnProcess0.Text = "0";
            this.btnProcess0.UseVisualStyleBackColor = true;
            this.btnProcess0.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnProcess9
            // 
            this.btnProcess9.Location = new System.Drawing.Point(372, 20);
            this.btnProcess9.Name = "btnProcess9";
            this.btnProcess9.Size = new System.Drawing.Size(23, 23);
            this.btnProcess9.TabIndex = 14;
            this.btnProcess9.Text = "9";
            this.btnProcess9.UseVisualStyleBackColor = true;
            this.btnProcess9.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnProcess8
            // 
            this.btnProcess8.Location = new System.Drawing.Point(343, 20);
            this.btnProcess8.Name = "btnProcess8";
            this.btnProcess8.Size = new System.Drawing.Size(23, 23);
            this.btnProcess8.TabIndex = 13;
            this.btnProcess8.Text = "8";
            this.btnProcess8.UseVisualStyleBackColor = true;
            this.btnProcess8.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnProcess7
            // 
            this.btnProcess7.Location = new System.Drawing.Point(314, 20);
            this.btnProcess7.Name = "btnProcess7";
            this.btnProcess7.Size = new System.Drawing.Size(23, 23);
            this.btnProcess7.TabIndex = 12;
            this.btnProcess7.Text = "7";
            this.btnProcess7.UseVisualStyleBackColor = true;
            this.btnProcess7.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnProcess6
            // 
            this.btnProcess6.Location = new System.Drawing.Point(285, 20);
            this.btnProcess6.Name = "btnProcess6";
            this.btnProcess6.Size = new System.Drawing.Size(23, 23);
            this.btnProcess6.TabIndex = 11;
            this.btnProcess6.Text = "6";
            this.btnProcess6.UseVisualStyleBackColor = true;
            this.btnProcess6.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnProcess5
            // 
            this.btnProcess5.Location = new System.Drawing.Point(256, 20);
            this.btnProcess5.Name = "btnProcess5";
            this.btnProcess5.Size = new System.Drawing.Size(23, 23);
            this.btnProcess5.TabIndex = 10;
            this.btnProcess5.Text = "5";
            this.btnProcess5.UseVisualStyleBackColor = true;
            this.btnProcess5.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnProcess4
            // 
            this.btnProcess4.Location = new System.Drawing.Point(227, 21);
            this.btnProcess4.Name = "btnProcess4";
            this.btnProcess4.Size = new System.Drawing.Size(23, 23);
            this.btnProcess4.TabIndex = 9;
            this.btnProcess4.Text = "4";
            this.btnProcess4.UseVisualStyleBackColor = true;
            this.btnProcess4.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnProcess3
            // 
            this.btnProcess3.Location = new System.Drawing.Point(198, 20);
            this.btnProcess3.Name = "btnProcess3";
            this.btnProcess3.Size = new System.Drawing.Size(23, 23);
            this.btnProcess3.TabIndex = 8;
            this.btnProcess3.Text = "3";
            this.btnProcess3.UseVisualStyleBackColor = true;
            this.btnProcess3.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnProcess2
            // 
            this.btnProcess2.Location = new System.Drawing.Point(169, 21);
            this.btnProcess2.Name = "btnProcess2";
            this.btnProcess2.Size = new System.Drawing.Size(23, 23);
            this.btnProcess2.TabIndex = 2;
            this.btnProcess2.Text = "2";
            this.btnProcess2.UseVisualStyleBackColor = true;
            this.btnProcess2.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnProcess1
            // 
            this.btnProcess1.Location = new System.Drawing.Point(140, 21);
            this.btnProcess1.Name = "btnProcess1";
            this.btnProcess1.Size = new System.Drawing.Size(23, 23);
            this.btnProcess1.TabIndex = 1;
            this.btnProcess1.Text = "1";
            this.btnProcess1.UseVisualStyleBackColor = true;
            this.btnProcess1.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnCreatProcess
            // 
            this.btnCreatProcess.Location = new System.Drawing.Point(6, 20);
            this.btnCreatProcess.Name = "btnCreatProcess";
            this.btnCreatProcess.Size = new System.Drawing.Size(88, 23);
            this.btnCreatProcess.TabIndex = 0;
            this.btnCreatProcess.Text = "重新生成文件";
            this.btnCreatProcess.UseVisualStyleBackColor = true;
            this.btnCreatProcess.Click += new System.EventHandler(this.btnCreatProcess_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lvReday);
            this.groupBox4.Location = new System.Drawing.Point(12, 206);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(200, 175);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "就绪队列";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.lvBlock);
            this.groupBox5.Location = new System.Drawing.Point(244, 206);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(401, 175);
            this.groupBox5.TabIndex = 7;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "阻塞队列";
            // 
            // lvBlock
            // 
            this.lvBlock.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.lvBlock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvBlock.FullRowSelect = true;
            this.lvBlock.Location = new System.Drawing.Point(3, 17);
            this.lvBlock.MultiSelect = false;
            this.lvBlock.Name = "lvBlock";
            this.lvBlock.Size = new System.Drawing.Size(395, 155);
            this.lvBlock.TabIndex = 2;
            this.lvBlock.UseCompatibleStateImageBehavior = false;
            this.lvBlock.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "进程名称";
            this.columnHeader3.Width = 95;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "进程编号";
            this.columnHeader4.Width = 95;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "阻塞原因";
            this.columnHeader5.Width = 95;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "剩余时间";
            this.columnHeader6.Width = 95;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.labRunning);
            this.groupBox6.Location = new System.Drawing.Point(12, 79);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(190, 50);
            this.groupBox6.TabIndex = 8;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "正在运行的进程";
            // 
            // labRunning
            // 
            this.labRunning.AutoSize = true;
            this.labRunning.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labRunning.Location = new System.Drawing.Point(25, 25);
            this.labRunning.Name = "labRunning";
            this.labRunning.Size = new System.Drawing.Size(24, 16);
            this.labRunning.TabIndex = 1;
            this.labRunning.Text = "无";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.labTimer);
            this.groupBox7.Location = new System.Drawing.Point(238, 79);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(190, 50);
            this.groupBox7.TabIndex = 9;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "时间片";
            // 
            // labTimer
            // 
            this.labTimer.AutoSize = true;
            this.labTimer.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labTimer.Location = new System.Drawing.Point(25, 25);
            this.labTimer.Name = "labTimer";
            this.labTimer.Size = new System.Drawing.Size(24, 16);
            this.labTimer.TabIndex = 2;
            this.labTimer.Text = "无";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.labEndResult);
            this.groupBox8.Location = new System.Drawing.Point(455, 150);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(190, 50);
            this.groupBox8.TabIndex = 10;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "上一进程结果";
            // 
            // labEndResult
            // 
            this.labEndResult.AutoSize = true;
            this.labEndResult.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labEndResult.Location = new System.Drawing.Point(25, 25);
            this.labEndResult.Name = "labEndResult";
            this.labEndResult.Size = new System.Drawing.Size(24, 16);
            this.labEndResult.TabIndex = 1;
            this.labEndResult.Text = "无";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.labNumber);
            this.groupBox9.Location = new System.Drawing.Point(455, 79);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(190, 50);
            this.groupBox9.TabIndex = 11;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "进程编号";
            // 
            // labNumber
            // 
            this.labNumber.AutoSize = true;
            this.labNumber.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labNumber.Location = new System.Drawing.Point(25, 25);
            this.labNumber.Name = "labNumber";
            this.labNumber.Size = new System.Drawing.Size(24, 16);
            this.labNumber.TabIndex = 2;
            this.labNumber.Text = "无";
            // 
            // btnNewForm
            // 
            this.btnNewForm.Location = new System.Drawing.Point(455, 12);
            this.btnNewForm.Name = "btnNewForm";
            this.btnNewForm.Size = new System.Drawing.Size(109, 52);
            this.btnNewForm.TabIndex = 12;
            this.btnNewForm.Text = "查看结果";
            this.btnNewForm.UseVisualStyleBackColor = true;
            this.btnNewForm.Click += new System.EventHandler(this.btnNewForm_Click);
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 486);
            this.Controls.Add(this.btnNewForm);
            this.Controls.Add(this.groupBox9);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnStop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "苏OS";
            this.Load += new System.EventHandler(this.Form_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ListView lvReday;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnCreatProcess;
        private System.Windows.Forms.Button btnProcess0;
        private System.Windows.Forms.Button btnProcess9;
        private System.Windows.Forms.Button btnProcess8;
        private System.Windows.Forms.Button btnProcess7;
        private System.Windows.Forms.Button btnProcess6;
        private System.Windows.Forms.Button btnProcess5;
        private System.Windows.Forms.Button btnProcess4;
        private System.Windows.Forms.Button btnProcess3;
        private System.Windows.Forms.Button btnProcess2;
        private System.Windows.Forms.Button btnProcess1;
        private System.Windows.Forms.Label labCommand;
        private System.Windows.Forms.Label labResult;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ListView lvBlock;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label labRunning;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label labTimer;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Label labEndResult;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Label labNumber;
        private System.Windows.Forms.Button btnNewForm;
    }
}

