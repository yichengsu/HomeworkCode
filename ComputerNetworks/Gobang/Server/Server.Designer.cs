namespace Server
{
    partial class Server
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gbInformation = new System.Windows.Forms.GroupBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.labPort = new System.Windows.Forms.Label();
            this.tbPeopleCount = new System.Windows.Forms.TextBox();
            this.labPeopleCount = new System.Windows.Forms.Label();
            this.tbIP = new System.Windows.Forms.TextBox();
            this.labIP = new System.Windows.Forms.Label();
            this.tbStatus = new System.Windows.Forms.TextBox();
            this.labStatus = new System.Windows.Forms.Label();
            this.gbLog = new System.Windows.Forms.GroupBox();
            this.tbLog = new System.Windows.Forms.TextBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.tmLog = new System.Windows.Forms.Timer(this.components);
            this.gbInformation.SuspendLayout();
            this.gbLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbInformation
            // 
            this.gbInformation.Controls.Add(this.btnStop);
            this.gbInformation.Controls.Add(this.btnStart);
            this.gbInformation.Controls.Add(this.tbPort);
            this.gbInformation.Controls.Add(this.labPort);
            this.gbInformation.Controls.Add(this.tbPeopleCount);
            this.gbInformation.Controls.Add(this.labPeopleCount);
            this.gbInformation.Controls.Add(this.tbIP);
            this.gbInformation.Controls.Add(this.labIP);
            this.gbInformation.Controls.Add(this.tbStatus);
            this.gbInformation.Controls.Add(this.labStatus);
            this.gbInformation.Location = new System.Drawing.Point(12, 12);
            this.gbInformation.Name = "gbInformation";
            this.gbInformation.Size = new System.Drawing.Size(174, 304);
            this.gbInformation.TabIndex = 0;
            this.gbInformation.TabStop = false;
            this.gbInformation.Text = "Server Information";
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(31, 269);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(101, 23);
            this.btnStop.TabIndex = 11;
            this.btnStop.Text = "Server Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(31, 240);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(101, 23);
            this.btnStart.TabIndex = 10;
            this.btnStart.Text = "Server Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // tbPort
            // 
            this.tbPort.Location = new System.Drawing.Point(8, 151);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(160, 21);
            this.tbPort.TabIndex = 9;
            // 
            // labPort
            // 
            this.labPort.AutoSize = true;
            this.labPort.Location = new System.Drawing.Point(6, 135);
            this.labPort.Name = "labPort";
            this.labPort.Size = new System.Drawing.Size(77, 12);
            this.labPort.TabIndex = 8;
            this.labPort.Text = "Server Port:";
            // 
            // tbPeopleCount
            // 
            this.tbPeopleCount.Location = new System.Drawing.Point(8, 202);
            this.tbPeopleCount.Name = "tbPeopleCount";
            this.tbPeopleCount.Size = new System.Drawing.Size(160, 21);
            this.tbPeopleCount.TabIndex = 5;
            // 
            // labPeopleCount
            // 
            this.labPeopleCount.AutoSize = true;
            this.labPeopleCount.Location = new System.Drawing.Point(6, 186);
            this.labPeopleCount.Name = "labPeopleCount";
            this.labPeopleCount.Size = new System.Drawing.Size(89, 12);
            this.labPeopleCount.TabIndex = 4;
            this.labPeopleCount.Text = "Server People:";
            // 
            // tbIP
            // 
            this.tbIP.Location = new System.Drawing.Point(8, 97);
            this.tbIP.Name = "tbIP";
            this.tbIP.Size = new System.Drawing.Size(160, 21);
            this.tbIP.TabIndex = 3;
            // 
            // labIP
            // 
            this.labIP.AutoSize = true;
            this.labIP.Location = new System.Drawing.Point(6, 81);
            this.labIP.Name = "labIP";
            this.labIP.Size = new System.Drawing.Size(65, 12);
            this.labIP.TabIndex = 2;
            this.labIP.Text = "Server IP:";
            // 
            // tbStatus
            // 
            this.tbStatus.Location = new System.Drawing.Point(8, 45);
            this.tbStatus.Name = "tbStatus";
            this.tbStatus.Size = new System.Drawing.Size(160, 21);
            this.tbStatus.TabIndex = 1;
            // 
            // labStatus
            // 
            this.labStatus.AutoSize = true;
            this.labStatus.Location = new System.Drawing.Point(6, 29);
            this.labStatus.Name = "labStatus";
            this.labStatus.Size = new System.Drawing.Size(89, 12);
            this.labStatus.TabIndex = 0;
            this.labStatus.Text = "Server Status:";
            // 
            // gbLog
            // 
            this.gbLog.Controls.Add(this.tbLog);
            this.gbLog.Location = new System.Drawing.Point(193, 13);
            this.gbLog.Name = "gbLog";
            this.gbLog.Size = new System.Drawing.Size(410, 303);
            this.gbLog.TabIndex = 1;
            this.gbLog.TabStop = false;
            this.gbLog.Text = "Server Log";
            // 
            // tbLog
            // 
            this.tbLog.Location = new System.Drawing.Point(7, 18);
            this.tbLog.Multiline = true;
            this.tbLog.Name = "tbLog";
            this.tbLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbLog.Size = new System.Drawing.Size(397, 279);
            this.tbLog.TabIndex = 0;
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // tmLog
            // 
            this.tmLog.Enabled = true;
            this.tmLog.Interval = 1000;
            this.tmLog.Tick += new System.EventHandler(this.tmLog_Tick);
            // 
            // Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 327);
            this.Controls.Add(this.gbLog);
            this.Controls.Add(this.gbInformation);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Server";
            this.Text = "Chat Server";
            this.Load += new System.EventHandler(this.Server_Load);
            this.gbInformation.ResumeLayout(false);
            this.gbInformation.PerformLayout();
            this.gbLog.ResumeLayout(false);
            this.gbLog.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbInformation;
        private System.Windows.Forms.GroupBox gbLog;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.Label labPort;
        private System.Windows.Forms.TextBox tbPeopleCount;
        private System.Windows.Forms.Label labPeopleCount;
        private System.Windows.Forms.TextBox tbIP;
        private System.Windows.Forms.Label labIP;
        private System.Windows.Forms.TextBox tbStatus;
        private System.Windows.Forms.Label labStatus;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox tbLog;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Timer tmLog;
    }
}

