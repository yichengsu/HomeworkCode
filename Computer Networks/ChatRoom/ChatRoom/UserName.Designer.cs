namespace ChatRoom
{
    partial class UserName
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
            this.label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label
            // 
            this.label.BackColor = System.Drawing.Color.Transparent;
            this.label.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label.Location = new System.Drawing.Point(0, 0);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(146, 20);
            this.label.TabIndex = 2;
            this.label.Text = "1234567890";
            this.label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label.MouseDown += new System.Windows.Forms.MouseEventHandler(this.History_MouseDown);
            this.label.MouseEnter += new System.EventHandler(this.History_MouseEnter);
            this.label.MouseLeave += new System.EventHandler(this.History_MouseLeave);
            this.label.MouseUp += new System.Windows.Forms.MouseEventHandler(this.History_MouseUp);
            // 
            // UserName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label);
            this.Name = "UserName";
            this.Size = new System.Drawing.Size(146, 20);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label;
    }
}
