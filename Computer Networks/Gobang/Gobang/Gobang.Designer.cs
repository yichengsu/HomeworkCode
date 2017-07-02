namespace Gobang
{
    partial class Gobang
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.Checkerboard = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtMsgAll = new System.Windows.Forms.TextBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.txtMsg = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.panInfo = new System.Windows.Forms.Panel();
            this.btnStart = new System.Windows.Forms.Button();
            this.labNow = new System.Windows.Forms.Label();
            this.labBlackorWhite = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.Checkerboard);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(884, 641);
            this.splitContainer1.SplitterDistance = 640;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 0;
            // 
            // Checkerboard
            // 
            this.Checkerboard.BackColor = System.Drawing.Color.Transparent;
            this.Checkerboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Checkerboard.Location = new System.Drawing.Point(0, 0);
            this.Checkerboard.Margin = new System.Windows.Forms.Padding(0);
            this.Checkerboard.Name = "Checkerboard";
            this.Checkerboard.Size = new System.Drawing.Size(640, 641);
            this.Checkerboard.TabIndex = 0;
            this.Checkerboard.Paint += new System.Windows.Forms.PaintEventHandler(this.Checkerboard_Paint);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.txtMsgAll, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.splitContainer2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panInfo, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(243, 641);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // txtMsgAll
            // 
            this.txtMsgAll.BackColor = System.Drawing.Color.White;
            this.txtMsgAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMsgAll.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtMsgAll.Location = new System.Drawing.Point(0, 303);
            this.txtMsgAll.Margin = new System.Windows.Forms.Padding(0);
            this.txtMsgAll.Multiline = true;
            this.txtMsgAll.Name = "txtMsgAll";
            this.txtMsgAll.ReadOnly = true;
            this.txtMsgAll.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMsgAll.Size = new System.Drawing.Size(243, 303);
            this.txtMsgAll.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 606);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.txtMsg);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.btnSend);
            this.splitContainer2.Size = new System.Drawing.Size(243, 35);
            this.splitContainer2.SplitterDistance = 193;
            this.splitContainer2.SplitterWidth = 1;
            this.splitContainer2.TabIndex = 1;
            // 
            // txtMsg
            // 
            this.txtMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMsg.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtMsg.Location = new System.Drawing.Point(0, 0);
            this.txtMsg.Margin = new System.Windows.Forms.Padding(0);
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.Size = new System.Drawing.Size(193, 35);
            this.txtMsg.TabIndex = 0;
            // 
            // btnSend
            // 
            this.btnSend.BackColor = System.Drawing.Color.Green;
            this.btnSend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSend.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSend.Location = new System.Drawing.Point(0, 0);
            this.btnSend.Margin = new System.Windows.Forms.Padding(0);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(49, 35);
            this.btnSend.TabIndex = 0;
            this.btnSend.Text = "SEND";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // panInfo
            // 
            this.panInfo.Controls.Add(this.btnStart);
            this.panInfo.Controls.Add(this.labNow);
            this.panInfo.Controls.Add(this.labBlackorWhite);
            this.panInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panInfo.Location = new System.Drawing.Point(0, 0);
            this.panInfo.Margin = new System.Windows.Forms.Padding(0);
            this.panInfo.Name = "panInfo";
            this.panInfo.Size = new System.Drawing.Size(243, 303);
            this.panInfo.TabIndex = 2;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(50, 237);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(121, 33);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "开始游戏";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // labNow
            // 
            this.labNow.AutoSize = true;
            this.labNow.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labNow.Location = new System.Drawing.Point(46, 105);
            this.labNow.Name = "labNow";
            this.labNow.Size = new System.Drawing.Size(39, 20);
            this.labNow.TabIndex = 2;
            this.labNow.Text = "...";
            // 
            // labBlackorWhite
            // 
            this.labBlackorWhite.AutoSize = true;
            this.labBlackorWhite.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labBlackorWhite.Location = new System.Drawing.Point(46, 43);
            this.labBlackorWhite.Name = "labBlackorWhite";
            this.labBlackorWhite.Size = new System.Drawing.Size(39, 20);
            this.labBlackorWhite.TabIndex = 1;
            this.labBlackorWhite.Text = "...";
            // 
            // Gobang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(884, 641);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Gobang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gobang";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Gobang_FormClosed);
            this.Load += new System.EventHandler(this.Gobang_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panInfo.ResumeLayout(false);
            this.panInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel Checkerboard;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox txtMsgAll;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TextBox txtMsg;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Panel panInfo;
        private System.Windows.Forms.Label labBlackorWhite;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label labNow;
    }
}

