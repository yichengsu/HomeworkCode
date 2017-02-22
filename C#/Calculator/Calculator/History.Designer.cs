namespace Calculator
{
    partial class History
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(30, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(30, 10, 25, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "123456789";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.History_MouseDown);
            this.label1.MouseEnter += new System.EventHandler(this.History_MouseEnter);
            this.label1.MouseLeave += new System.EventHandler(this.History_MouseLeave);
            this.label1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.History_MouseUp);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(30, 34);
            this.label2.Margin = new System.Windows.Forms.Padding(30, 0, 25, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(196, 36);
            this.label2.TabIndex = 0;
            this.label2.Text = "123456789";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.History_MouseDown);
            this.label2.MouseEnter += new System.EventHandler(this.History_MouseEnter);
            this.label2.MouseLeave += new System.EventHandler(this.History_MouseLeave);
            this.label2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.History_MouseUp);
            // 
            // History
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "History";
            this.Size = new System.Drawing.Size(266, 80);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.History_MouseDown);
            this.MouseEnter += new System.EventHandler(this.History_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.History_MouseLeave);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.History_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label2;
    }
}
