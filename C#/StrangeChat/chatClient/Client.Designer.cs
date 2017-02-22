namespace chatClient
{
    partial class Client
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
            this.tbMsgAll = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button = new System.Windows.Forms.Button();
            this.tbMsg = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbMsgAll
            // 
            this.tbMsgAll.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbMsgAll.Cursor = System.Windows.Forms.Cursors.Default;
            this.tbMsgAll.Location = new System.Drawing.Point(0, 0);
            this.tbMsgAll.Margin = new System.Windows.Forms.Padding(0);
            this.tbMsgAll.Multiline = true;
            this.tbMsgAll.Name = "tbMsgAll";
            this.tbMsgAll.ReadOnly = true;
            this.tbMsgAll.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbMsgAll.Size = new System.Drawing.Size(283, 370);
            this.tbMsgAll.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.button);
            this.panel1.Controls.Add(this.tbMsg);
            this.panel1.Location = new System.Drawing.Point(0, 370);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(283, 40);
            this.panel1.TabIndex = 1;
            // 
            // button
            // 
            this.button.Location = new System.Drawing.Point(224, 8);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(48, 21);
            this.button.TabIndex = 1;
            this.button.Text = "send";
            this.button.UseVisualStyleBackColor = true;
            this.button.Click += new System.EventHandler(this.button_Click);
            // 
            // tbMsg
            // 
            this.tbMsg.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbMsg.Location = new System.Drawing.Point(12, 8);
            this.tbMsg.Name = "tbMsg";
            this.tbMsg.Size = new System.Drawing.Size(207, 21);
            this.tbMsg.TabIndex = 0;
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 411);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tbMsgAll);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Client";
            this.Text = "Client";
            this.Load += new System.EventHandler(this.Client_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbMsgAll;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbMsg;
        private System.Windows.Forms.Button button;
    }
}

