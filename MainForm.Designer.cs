namespace PomodoroTimer
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblPhase = new System.Windows.Forms.Label();
            this.prgPhase = new System.Windows.Forms.ProgressBar();
            this.btnStartPause = new System.Windows.Forms.Button();
            this.btnSkip = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.grpSettings = new System.Windows.Forms.GroupBox();
            this.lblFocus = new System.Windows.Forms.Label();
            this.numFocus = new System.Windows.Forms.NumericUpDown();
            this.lblShort = new System.Windows.Forms.Label();
            this.numShort = new System.Windows.Forms.NumericUpDown();
            this.lblLong = new System.Windows.Forms.Label();
            this.numLong = new System.Windows.Forms.NumericUpDown();
            this.lblInterval = new System.Windows.Forms.Label();
            this.numInterval = new System.Windows.Forms.NumericUpDown();
            this.lblSedentary = new System.Windows.Forms.Label();
            this.numSedentary = new System.Windows.Forms.NumericUpDown();
            this.chkAutoNext = new System.Windows.Forms.CheckBox();
            this.chkSound = new System.Windows.Forms.CheckBox();
            this.grpToday = new System.Windows.Forms.GroupBox();
            this.lblTodayCount = new System.Windows.Forms.Label();
            this.lblTodayMinutes = new System.Windows.Forms.Label();
            this.lblSedentaryState = new System.Windows.Forms.Label();
            this.lblHint = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.trayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.miExit = new System.Windows.Forms.ToolStripMenuItem();
            this.grpSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFocus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numShort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSedentary)).BeginInit();
            this.grpToday.SuspendLayout();
            this.trayMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTime
            // 
            this.lblTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTime.Font = new System.Drawing.Font("Segoe UI", 46F, System.Drawing.FontStyle.Bold);
            this.lblTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTime.Location = new System.Drawing.Point(12, 18);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(536, 92);
            this.lblTime.TabIndex = 0;
            this.lblTime.Text = "25:00";
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPhase
            // 
            this.lblPhase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPhase.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblPhase.ForeColor = System.Drawing.Color.Gray;
            this.lblPhase.Location = new System.Drawing.Point(12, 110);
            this.lblPhase.Name = "lblPhase";
            this.lblPhase.Size = new System.Drawing.Size(536, 26);
            this.lblPhase.TabIndex = 1;
            this.lblPhase.Text = "准备开始 · 专注";
            this.lblPhase.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // prgPhase
            // 
            this.prgPhase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.prgPhase.Location = new System.Drawing.Point(28, 142);
            this.prgPhase.Maximum = 1000;
            this.prgPhase.Name = "prgPhase";
            this.prgPhase.Size = new System.Drawing.Size(504, 10);
            this.prgPhase.TabIndex = 2;
            // 
            // btnStartPause
            // 
            this.btnStartPause.Location = new System.Drawing.Point(116, 162);
            this.btnStartPause.Name = "btnStartPause";
            this.btnStartPause.Size = new System.Drawing.Size(130, 38);
            this.btnStartPause.TabIndex = 3;
            this.btnStartPause.Text = "开始";
            this.btnStartPause.UseVisualStyleBackColor = true;
            this.btnStartPause.Click += new System.EventHandler(this.btnStartPause_Click);
            // 
            // btnSkip
            // 
            this.btnSkip.Enabled = false;
            this.btnSkip.Location = new System.Drawing.Point(254, 165);
            this.btnSkip.Name = "btnSkip";
            this.btnSkip.Size = new System.Drawing.Size(96, 32);
            this.btnSkip.TabIndex = 4;
            this.btnSkip.Text = "跳过";
            this.btnSkip.UseVisualStyleBackColor = true;
            this.btnSkip.Click += new System.EventHandler(this.btnSkip_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(358, 165);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(96, 32);
            this.btnReset.TabIndex = 5;
            this.btnReset.Text = "重置";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // grpSettings
            // 
            this.grpSettings.Controls.Add(this.lblFocus);
            this.grpSettings.Controls.Add(this.numFocus);
            this.grpSettings.Controls.Add(this.lblShort);
            this.grpSettings.Controls.Add(this.numShort);
            this.grpSettings.Controls.Add(this.lblLong);
            this.grpSettings.Controls.Add(this.numLong);
            this.grpSettings.Controls.Add(this.lblInterval);
            this.grpSettings.Controls.Add(this.numInterval);
            this.grpSettings.Controls.Add(this.lblSedentary);
            this.grpSettings.Controls.Add(this.numSedentary);
            this.grpSettings.Controls.Add(this.chkAutoNext);
            this.grpSettings.Controls.Add(this.chkSound);
            this.grpSettings.Location = new System.Drawing.Point(12, 216);
            this.grpSettings.Name = "grpSettings";
            this.grpSettings.Size = new System.Drawing.Size(264, 244);
            this.grpSettings.TabIndex = 6;
            this.grpSettings.TabStop = false;
            this.grpSettings.Text = "设置";
            // 
            // lblFocus
            // 
            this.lblFocus.AutoSize = true;
            this.lblFocus.Location = new System.Drawing.Point(14, 26);
            this.lblFocus.Name = "lblFocus";
            this.lblFocus.Size = new System.Drawing.Size(80, 15);
            this.lblFocus.TabIndex = 0;
            this.lblFocus.Text = "专注（分钟）";
            // 
            // numFocus
            // 
            this.numFocus.Location = new System.Drawing.Point(176, 22);
            this.numFocus.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.numFocus.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numFocus.Name = "numFocus";
            this.numFocus.Size = new System.Drawing.Size(72, 23);
            this.numFocus.TabIndex = 1;
            this.numFocus.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.numFocus.ValueChanged += new System.EventHandler(this.Setting_Changed);
            // 
            // lblShort
            // 
            this.lblShort.AutoSize = true;
            this.lblShort.Location = new System.Drawing.Point(14, 56);
            this.lblShort.Name = "lblShort";
            this.lblShort.Size = new System.Drawing.Size(80, 15);
            this.lblShort.TabIndex = 2;
            this.lblShort.Text = "短休息（分钟）";
            // 
            // numShort
            // 
            this.numShort.Location = new System.Drawing.Point(176, 52);
            this.numShort.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numShort.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numShort.Name = "numShort";
            this.numShort.Size = new System.Drawing.Size(72, 23);
            this.numShort.TabIndex = 3;
            this.numShort.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numShort.ValueChanged += new System.EventHandler(this.Setting_Changed);
            // 
            // lblLong
            // 
            this.lblLong.AutoSize = true;
            this.lblLong.Location = new System.Drawing.Point(14, 86);
            this.lblLong.Name = "lblLong";
            this.lblLong.Size = new System.Drawing.Size(80, 15);
            this.lblLong.TabIndex = 4;
            this.lblLong.Text = "长休息（分钟）";
            // 
            // numLong
            // 
            this.numLong.Location = new System.Drawing.Point(176, 82);
            this.numLong.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.numLong.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numLong.Name = "numLong";
            this.numLong.Size = new System.Drawing.Size(72, 23);
            this.numLong.TabIndex = 5;
            this.numLong.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numLong.ValueChanged += new System.EventHandler(this.Setting_Changed);
            // 
            // lblInterval
            // 
            this.lblInterval.AutoSize = true;
            this.lblInterval.Location = new System.Drawing.Point(14, 116);
            this.lblInterval.Name = "lblInterval";
            this.lblInterval.Size = new System.Drawing.Size(80, 15);
            this.lblInterval.TabIndex = 6;
            this.lblInterval.Text = "长休息间隔";
            // 
            // numInterval
            // 
            this.numInterval.Location = new System.Drawing.Point(176, 112);
            this.numInterval.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numInterval.Name = "numInterval";
            this.numInterval.Size = new System.Drawing.Size(72, 23);
            this.numInterval.TabIndex = 7;
            this.numInterval.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numInterval.ValueChanged += new System.EventHandler(this.Setting_Changed);
            // 
            // lblSedentary
            // 
            this.lblSedentary.AutoSize = true;
            this.lblSedentary.Location = new System.Drawing.Point(14, 146);
            this.lblSedentary.Name = "lblSedentary";
            this.lblSedentary.Size = new System.Drawing.Size(110, 15);
            this.lblSedentary.TabIndex = 8;
            this.lblSedentary.Text = "久坐提醒（0=关）";
            // 
            // numSedentary
            // 
            this.numSedentary.Location = new System.Drawing.Point(176, 142);
            this.numSedentary.Maximum = new decimal(new int[] {
            240,
            0,
            0,
            0});
            this.numSedentary.Name = "numSedentary";
            this.numSedentary.Size = new System.Drawing.Size(72, 23);
            this.numSedentary.TabIndex = 9;
            this.numSedentary.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numSedentary.ValueChanged += new System.EventHandler(this.Setting_Changed);
            // 
            // chkAutoNext
            // 
            this.chkAutoNext.AutoSize = true;
            this.chkAutoNext.Checked = true;
            this.chkAutoNext.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAutoNext.Location = new System.Drawing.Point(14, 178);
            this.chkAutoNext.Name = "chkAutoNext";
            this.chkAutoNext.Size = new System.Drawing.Size(111, 19);
            this.chkAutoNext.TabIndex = 10;
            this.chkAutoNext.Text = "自动下一阶段";
            this.chkAutoNext.UseVisualStyleBackColor = true;
            this.chkAutoNext.CheckedChanged += new System.EventHandler(this.Setting_Changed);
            // 
            // chkSound
            // 
            this.chkSound.AutoSize = true;
            this.chkSound.Checked = true;
            this.chkSound.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSound.Location = new System.Drawing.Point(14, 200);
            this.chkSound.Name = "chkSound";
            this.chkSound.Size = new System.Drawing.Size(75, 19);
            this.chkSound.TabIndex = 11;
            this.chkSound.Text = "提示音";
            this.chkSound.UseVisualStyleBackColor = true;
            this.chkSound.CheckedChanged += new System.EventHandler(this.Setting_Changed);
            // 
            // grpToday
            // 
            this.grpToday.Controls.Add(this.lblTodayCount);
            this.grpToday.Controls.Add(this.lblTodayMinutes);
            this.grpToday.Controls.Add(this.lblSedentaryState);
            this.grpToday.Location = new System.Drawing.Point(284, 216);
            this.grpToday.Name = "grpToday";
            this.grpToday.Size = new System.Drawing.Size(264, 244);
            this.grpToday.TabIndex = 7;
            this.grpToday.TabStop = false;
            this.grpToday.Text = "今日";
            // 
            // lblTodayCount
            // 
            this.lblTodayCount.AutoSize = true;
            this.lblTodayCount.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.lblTodayCount.Location = new System.Drawing.Point(16, 30);
            this.lblTodayCount.Name = "lblTodayCount";
            this.lblTodayCount.Size = new System.Drawing.Size(110, 19);
            this.lblTodayCount.TabIndex = 0;
            this.lblTodayCount.Text = "完成番茄：0 个";
            // 
            // lblTodayMinutes
            // 
            this.lblTodayMinutes.AutoSize = true;
            this.lblTodayMinutes.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.lblTodayMinutes.Location = new System.Drawing.Point(16, 62);
            this.lblTodayMinutes.Name = "lblTodayMinutes";
            this.lblTodayMinutes.Size = new System.Drawing.Size(130, 19);
            this.lblTodayMinutes.TabIndex = 1;
            this.lblTodayMinutes.Text = "专注时长：0 分钟";
            // 
            // lblSedentaryState
            // 
            this.lblSedentaryState.ForeColor = System.Drawing.Color.Gray;
            this.lblSedentaryState.Location = new System.Drawing.Point(16, 100);
            this.lblSedentaryState.Name = "lblSedentaryState";
            this.lblSedentaryState.Size = new System.Drawing.Size(232, 120);
            this.lblSedentaryState.TabIndex = 2;
            this.lblSedentaryState.Text = "久坐提醒：每专注 60 分钟";
            // 
            // lblHint
            // 
            this.lblHint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblHint.AutoSize = true;
            this.lblHint.ForeColor = System.Drawing.Color.Gray;
            this.lblHint.Location = new System.Drawing.Point(12, 470);
            this.lblHint.Name = "lblHint";
            this.lblHint.Size = new System.Drawing.Size(260, 15);
            this.lblHint.TabIndex = 8;
            this.lblHint.Text = "关闭窗口最小化到托盘，计时不中断";
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.trayMenu;
            this.notifyIcon.Text = "番茄钟";
            this.notifyIcon.Visible = true;
            this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);
            // 
            // trayMenu
            // 
            this.trayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miOpen,
            this.miExit});
            this.trayMenu.Name = "trayMenu";
            this.trayMenu.Size = new System.Drawing.Size(140, 48);
            // 
            // miOpen
            // 
            this.miOpen.Name = "miOpen";
            this.miOpen.Size = new System.Drawing.Size(139, 22);
            this.miOpen.Text = "打开";
            this.miOpen.Click += new System.EventHandler(this.miOpen_Click);
            // 
            // miExit
            // 
            this.miExit.Name = "miExit";
            this.miExit.Size = new System.Drawing.Size(139, 22);
            this.miExit.Text = "退出";
            this.miExit.Click += new System.EventHandler(this.miExit_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 500);
            this.Controls.Add(this.lblHint);
            this.Controls.Add(this.grpToday);
            this.Controls.Add(this.grpSettings);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSkip);
            this.Controls.Add(this.btnStartPause);
            this.Controls.Add(this.prgPhase);
            this.Controls.Add(this.lblPhase);
            this.Controls.Add(this.lblTime);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(520, 480);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "番茄钟";
            this.grpSettings.ResumeLayout(false);
            this.grpSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFocus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numShort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSedentary)).EndInit();
            this.grpToday.ResumeLayout(false);
            this.grpToday.PerformLayout();
            this.trayMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblPhase;
        private System.Windows.Forms.ProgressBar prgPhase;
        private System.Windows.Forms.Button btnStartPause;
        private System.Windows.Forms.Button btnSkip;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.GroupBox grpSettings;
        private System.Windows.Forms.Label lblFocus;
        private System.Windows.Forms.NumericUpDown numFocus;
        private System.Windows.Forms.Label lblShort;
        private System.Windows.Forms.NumericUpDown numShort;
        private System.Windows.Forms.Label lblLong;
        private System.Windows.Forms.NumericUpDown numLong;
        private System.Windows.Forms.Label lblInterval;
        private System.Windows.Forms.NumericUpDown numInterval;
        private System.Windows.Forms.Label lblSedentary;
        private System.Windows.Forms.NumericUpDown numSedentary;
        private System.Windows.Forms.CheckBox chkAutoNext;
        private System.Windows.Forms.CheckBox chkSound;
        private System.Windows.Forms.GroupBox grpToday;
        private System.Windows.Forms.Label lblTodayCount;
        private System.Windows.Forms.Label lblTodayMinutes;
        private System.Windows.Forms.Label lblSedentaryState;
        private System.Windows.Forms.Label lblHint;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip trayMenu;
        private System.Windows.Forms.ToolStripMenuItem miOpen;
        private System.Windows.Forms.ToolStripMenuItem miExit;
    }
}