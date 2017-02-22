namespace Calculator
{
    partial class LeftMenu
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
            this.spc1 = new System.Windows.Forms.SplitContainer();
            this.panelSetting = new System.Windows.Forms.Panel();
            this.labSettings = new System.Windows.Forms.Label();
            this.scp1T = new System.Windows.Forms.SplitContainer();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.labSetting = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.spc1)).BeginInit();
            this.spc1.Panel1.SuspendLayout();
            this.spc1.Panel2.SuspendLayout();
            this.spc1.SuspendLayout();
            this.panelSetting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scp1T)).BeginInit();
            this.scp1T.Panel1.SuspendLayout();
            this.scp1T.Panel2.SuspendLayout();
            this.scp1T.SuspendLayout();
            this.panelMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // spc1
            // 
            this.spc1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spc1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.spc1.IsSplitterFixed = true;
            this.spc1.Location = new System.Drawing.Point(0, 0);
            this.spc1.Margin = new System.Windows.Forms.Padding(0);
            this.spc1.Name = "spc1";
            this.spc1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spc1.Panel1
            // 
            this.spc1.Panel1.Controls.Add(this.scp1T);
            // 
            // spc1.Panel2
            // 
            this.spc1.Panel2.Controls.Add(this.panelSetting);
            this.spc1.Size = new System.Drawing.Size(250, 1050);
            this.spc1.SplitterDistance = 991;
            this.spc1.TabIndex = 0;
            // 
            // panelSetting
            // 
            this.panelSetting.BackColor = System.Drawing.Color.Transparent;
            this.panelSetting.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panelSetting.Controls.Add(this.labSettings);
            this.panelSetting.Controls.Add(this.labSetting);
            this.panelSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSetting.Location = new System.Drawing.Point(0, 0);
            this.panelSetting.Margin = new System.Windows.Forms.Padding(0);
            this.panelSetting.Name = "panelSetting";
            this.panelSetting.Size = new System.Drawing.Size(250, 55);
            this.panelSetting.TabIndex = 0;
            this.panelSetting.Click += new System.EventHandler(this.labSetting_Click);
            this.panelSetting.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Setting_MouseDown);
            this.panelSetting.MouseEnter += new System.EventHandler(this.Setting_MouseEnter);
            this.panelSetting.MouseLeave += new System.EventHandler(this.Setting_MouseLeave);
            this.panelSetting.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Setting_MouseUp);
            // 
            // labSettings
            // 
            this.labSettings.Dock = System.Windows.Forms.DockStyle.Right;
            this.labSettings.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labSettings.Location = new System.Drawing.Point(64, 0);
            this.labSettings.Name = "labSettings";
            this.labSettings.Size = new System.Drawing.Size(186, 55);
            this.labSettings.TabIndex = 1;
            this.labSettings.Text = "Settings";
            this.labSettings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labSettings.Click += new System.EventHandler(this.labSetting_Click);
            this.labSettings.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Setting_MouseDown);
            this.labSettings.MouseEnter += new System.EventHandler(this.Setting_MouseEnter);
            this.labSettings.MouseLeave += new System.EventHandler(this.Setting_MouseLeave);
            this.labSettings.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Setting_MouseUp);
            // 
            // scp1T
            // 
            this.scp1T.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scp1T.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.scp1T.IsSplitterFixed = true;
            this.scp1T.Location = new System.Drawing.Point(0, 0);
            this.scp1T.Margin = new System.Windows.Forms.Padding(0);
            this.scp1T.Name = "scp1T";
            // 
            // scp1T.Panel1
            // 
            this.scp1T.Panel1.Controls.Add(this.button1);
            // 
            // scp1T.Panel2
            // 
            this.scp1T.Panel2.Controls.Add(this.panelMenu);
            this.scp1T.Size = new System.Drawing.Size(250, 991);
            this.scp1T.SplitterDistance = 55;
            this.scp1T.TabIndex = 0;
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.Transparent;
            this.panelMenu.Controls.Add(this.label18);
            this.panelMenu.Controls.Add(this.label17);
            this.panelMenu.Controls.Add(this.label16);
            this.panelMenu.Controls.Add(this.label15);
            this.panelMenu.Controls.Add(this.label14);
            this.panelMenu.Controls.Add(this.label13);
            this.panelMenu.Controls.Add(this.label12);
            this.panelMenu.Controls.Add(this.label11);
            this.panelMenu.Controls.Add(this.label10);
            this.panelMenu.Controls.Add(this.label9);
            this.panelMenu.Controls.Add(this.label8);
            this.panelMenu.Controls.Add(this.label7);
            this.panelMenu.Controls.Add(this.label6);
            this.panelMenu.Controls.Add(this.label5);
            this.panelMenu.Controls.Add(this.label4);
            this.panelMenu.Controls.Add(this.label3);
            this.panelMenu.Controls.Add(this.label2);
            this.panelMenu.Controls.Add(this.label1);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(191, 991);
            this.panelMenu.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("微软雅黑", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 54);
            this.label1.TabIndex = 0;
            this.label1.Text = "CALCULATOR";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(0, 54);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(192, 54);
            this.label2.TabIndex = 1;
            this.label2.Text = "Standard";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Menu_MouseDown);
            this.label2.MouseEnter += new System.EventHandler(this.Menu_MouseEnter);
            this.label2.MouseLeave += new System.EventHandler(this.Menu_MouseLeave);
            this.label2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Menu_MouseUp);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(0, 108);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(192, 54);
            this.label3.TabIndex = 2;
            this.label3.Text = "Scientific";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Menu_MouseDown);
            this.label3.MouseEnter += new System.EventHandler(this.Menu_MouseEnter);
            this.label3.MouseLeave += new System.EventHandler(this.Menu_MouseLeave);
            this.label3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Menu_MouseUp);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(0, 162);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(192, 54);
            this.label4.TabIndex = 3;
            this.label4.Text = "Programmer";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Menu_MouseDown);
            this.label4.MouseEnter += new System.EventHandler(this.Menu_MouseEnter);
            this.label4.MouseLeave += new System.EventHandler(this.Menu_MouseLeave);
            this.label4.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Menu_MouseUp);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(0, 216);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(192, 54);
            this.label5.TabIndex = 4;
            this.label5.Text = "Date calculation";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label5.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Menu_MouseDown);
            this.label5.MouseEnter += new System.EventHandler(this.Menu_MouseEnter);
            this.label5.MouseLeave += new System.EventHandler(this.Menu_MouseLeave);
            this.label5.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Menu_MouseUp);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("微软雅黑", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(0, 270);
            this.label6.Margin = new System.Windows.Forms.Padding(0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(192, 54);
            this.label6.TabIndex = 5;
            this.label6.Text = "CONVERTER";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(0, 324);
            this.label7.Margin = new System.Windows.Forms.Padding(0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(192, 54);
            this.label7.TabIndex = 6;
            this.label7.Text = "Volume";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label7.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Menu_MouseDown);
            this.label7.MouseEnter += new System.EventHandler(this.Menu_MouseEnter);
            this.label7.MouseLeave += new System.EventHandler(this.Menu_MouseLeave);
            this.label7.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Menu_MouseUp);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(0, 378);
            this.label8.Margin = new System.Windows.Forms.Padding(0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(192, 54);
            this.label8.TabIndex = 7;
            this.label8.Text = "Length";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label8.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Menu_MouseDown);
            this.label8.MouseEnter += new System.EventHandler(this.Menu_MouseEnter);
            this.label8.MouseLeave += new System.EventHandler(this.Menu_MouseLeave);
            this.label8.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Menu_MouseUp);
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(0, 432);
            this.label9.Margin = new System.Windows.Forms.Padding(0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(192, 54);
            this.label9.TabIndex = 8;
            this.label9.Text = "Weight and Mass";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label9.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Menu_MouseDown);
            this.label9.MouseEnter += new System.EventHandler(this.Menu_MouseEnter);
            this.label9.MouseLeave += new System.EventHandler(this.Menu_MouseLeave);
            this.label9.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Menu_MouseUp);
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(0, 486);
            this.label10.Margin = new System.Windows.Forms.Padding(0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(192, 54);
            this.label10.TabIndex = 9;
            this.label10.Text = "Temperature";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label10.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Menu_MouseDown);
            this.label10.MouseEnter += new System.EventHandler(this.Menu_MouseEnter);
            this.label10.MouseLeave += new System.EventHandler(this.Menu_MouseLeave);
            this.label10.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Menu_MouseUp);
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(0, 541);
            this.label11.Margin = new System.Windows.Forms.Padding(0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(192, 54);
            this.label11.TabIndex = 10;
            this.label11.Text = "Energy";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label11.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Menu_MouseDown);
            this.label11.MouseEnter += new System.EventHandler(this.Menu_MouseEnter);
            this.label11.MouseLeave += new System.EventHandler(this.Menu_MouseLeave);
            this.label11.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Menu_MouseUp);
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(0, 594);
            this.label12.Margin = new System.Windows.Forms.Padding(0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(192, 54);
            this.label12.TabIndex = 11;
            this.label12.Text = "Area";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label12.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Menu_MouseDown);
            this.label12.MouseEnter += new System.EventHandler(this.Menu_MouseEnter);
            this.label12.MouseLeave += new System.EventHandler(this.Menu_MouseLeave);
            this.label12.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Menu_MouseUp);
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(0, 648);
            this.label13.Margin = new System.Windows.Forms.Padding(0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(192, 54);
            this.label13.TabIndex = 12;
            this.label13.Text = "Speed";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label13.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Menu_MouseDown);
            this.label13.MouseEnter += new System.EventHandler(this.Menu_MouseEnter);
            this.label13.MouseLeave += new System.EventHandler(this.Menu_MouseLeave);
            this.label13.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Menu_MouseUp);
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(0, 702);
            this.label14.Margin = new System.Windows.Forms.Padding(0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(192, 54);
            this.label14.TabIndex = 13;
            this.label14.Text = "Time";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label14.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Menu_MouseDown);
            this.label14.MouseEnter += new System.EventHandler(this.Menu_MouseEnter);
            this.label14.MouseLeave += new System.EventHandler(this.Menu_MouseLeave);
            this.label14.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Menu_MouseUp);
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(0, 756);
            this.label15.Margin = new System.Windows.Forms.Padding(0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(192, 54);
            this.label15.TabIndex = 14;
            this.label15.Text = "Power";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label15.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Menu_MouseDown);
            this.label15.MouseEnter += new System.EventHandler(this.Menu_MouseEnter);
            this.label15.MouseLeave += new System.EventHandler(this.Menu_MouseLeave);
            this.label15.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Menu_MouseUp);
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.Location = new System.Drawing.Point(0, 810);
            this.label16.Margin = new System.Windows.Forms.Padding(0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(192, 54);
            this.label16.TabIndex = 15;
            this.label16.Text = "Date";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label16.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Menu_MouseDown);
            this.label16.MouseEnter += new System.EventHandler(this.Menu_MouseEnter);
            this.label16.MouseLeave += new System.EventHandler(this.Menu_MouseLeave);
            this.label16.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Menu_MouseUp);
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label17.Location = new System.Drawing.Point(0, 864);
            this.label17.Margin = new System.Windows.Forms.Padding(0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(192, 54);
            this.label17.TabIndex = 16;
            this.label17.Text = "Pressure";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label17.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Menu_MouseDown);
            this.label17.MouseEnter += new System.EventHandler(this.Menu_MouseEnter);
            this.label17.MouseLeave += new System.EventHandler(this.Menu_MouseLeave);
            this.label17.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Menu_MouseUp);
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label18.Location = new System.Drawing.Point(0, 918);
            this.label18.Margin = new System.Windows.Forms.Padding(0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(192, 54);
            this.label18.TabIndex = 17;
            this.label18.Text = "Angle";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label18.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Menu_MouseDown);
            this.label18.MouseEnter += new System.EventHandler(this.Menu_MouseEnter);
            this.label18.MouseLeave += new System.EventHandler(this.Menu_MouseLeave);
            this.label18.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Menu_MouseUp);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = global::Calculator.Properties.Resources.menu;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(55, 55);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // labSetting
            // 
            this.labSetting.Dock = System.Windows.Forms.DockStyle.Left;
            this.labSetting.Image = global::Calculator.Properties.Resources.setting;
            this.labSetting.Location = new System.Drawing.Point(0, 0);
            this.labSetting.Margin = new System.Windows.Forms.Padding(0);
            this.labSetting.Name = "labSetting";
            this.labSetting.Size = new System.Drawing.Size(55, 55);
            this.labSetting.TabIndex = 0;
            this.labSetting.Click += new System.EventHandler(this.labSetting_Click);
            this.labSetting.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Setting_MouseDown);
            this.labSetting.MouseEnter += new System.EventHandler(this.Setting_MouseEnter);
            this.labSetting.MouseLeave += new System.EventHandler(this.Setting_MouseLeave);
            this.labSetting.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Setting_MouseUp);
            // 
            // LeftMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(237)))), ((int)(((byte)(237)))));
            this.Controls.Add(this.spc1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "LeftMenu";
            this.Size = new System.Drawing.Size(250, 1050);
            this.spc1.Panel1.ResumeLayout(false);
            this.spc1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spc1)).EndInit();
            this.spc1.ResumeLayout(false);
            this.panelSetting.ResumeLayout(false);
            this.scp1T.Panel1.ResumeLayout(false);
            this.scp1T.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scp1T)).EndInit();
            this.scp1T.ResumeLayout(false);
            this.panelMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer spc1;
        private System.Windows.Forms.Panel panelSetting;
        private System.Windows.Forms.Label labSetting;
        private System.Windows.Forms.Label labSettings;
        private System.Windows.Forms.SplitContainer scp1T;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label18;
    }
}
