using System;
using System.Drawing;
using System.Media;
using System.Reflection;
using System.Windows.Forms;
using PomodoroTimer.Core;

namespace PomodoroTimer
{
    public partial class MainForm : Form
    {
        private enum Phase
        {
            Focus,
            ShortBreak,
            LongBreak
        }

        private enum RunState
        {
            Idle,
            Running,
            Paused
        }

        private Phase _phase = Phase.Focus;
        private RunState _state = RunState.Idle;
        private TimeSpan _remaining;
        private TimeSpan _phaseTotal;
        private DateTime _endAt;
        private DateTime _lastBreakEnd = DateTime.Now;
        private int _completedCycles;
        private int _todayCount;
        private int _todayMinutes;
        private bool _loaded;
        private bool _exiting;
        private bool _trayHintShown;

        public MainForm()
        {
            InitializeComponent();
            LoadAppIcon();
            LoadSettings();
            LoadStats();
            _remaining = DurationOf(Phase.Focus);
            _phaseTotal = _remaining;
            _loaded = true;
            UpdateDisplay();
        }

        private void LoadAppIcon()
        {
            try
            {
                using (var stream = Assembly.GetExecutingAssembly()
                    .GetManifestResourceStream("PomodoroTimer.Assets.app.ico"))
                {
                    if (stream == null) return;
                    var icon = new Icon(stream);
                    Icon = icon;
                    notifyIcon.Icon = icon;
                }
            }
            catch
            {
            }
        }

        private void LoadSettings()
        {
            numFocus.Value = Clamp(AppSettings.GetInt("pomo.focus", 25), numFocus);
            numShort.Value = Clamp(AppSettings.GetInt("pomo.short", 5), numShort);
            numLong.Value = Clamp(AppSettings.GetInt("pomo.long", 15), numLong);
            numInterval.Value = Clamp(AppSettings.GetInt("pomo.interval", 4), numInterval);
            numSedentary.Value = Clamp(AppSettings.GetInt("pomo.sedentary", 60), numSedentary);
            chkAutoNext.Checked = AppSettings.GetBool("pomo.autoNext", true);
            chkSound.Checked = AppSettings.GetBool("pomo.sound", true);
        }

        private static decimal Clamp(int value, NumericUpDown control)
        {
            return Math.Max(control.Minimum, Math.Min(control.Maximum, value));
        }

        private void LoadStats()
        {
            string today = DateTime.Today.ToString("yyyy-MM-dd");
            if (AppSettings.GetString("pomo.statsDate", string.Empty) == today)
            {
                _todayCount = AppSettings.GetInt("pomo.statsCount", 0);
                _todayMinutes = AppSettings.GetInt("pomo.statsMinutes", 0);
            }
            else
            {
                _todayCount = 0;
                _todayMinutes = 0;
                SaveStats();
            }
        }

        private void SaveStats()
        {
            AppSettings.Set("pomo.statsDate", DateTime.Today.ToString("yyyy-MM-dd"));
            AppSettings.Set("pomo.statsCount", _todayCount);
            AppSettings.Set("pomo.statsMinutes", _todayMinutes);
        }

        private TimeSpan DurationOf(Phase phase)
        {
            if (phase == Phase.Focus) return TimeSpan.FromMinutes((double)numFocus.Value);
            if (phase == Phase.ShortBreak) return TimeSpan.FromMinutes((double)numShort.Value);
            return TimeSpan.FromMinutes((double)numLong.Value);
        }

        private void StartPhase(bool manual)
        {
            _remaining = DurationOf(_phase);
            _phaseTotal = _remaining;
            _endAt = DateTime.Now + _remaining;
            _state = RunState.Running;
            if (manual && _phase == Phase.Focus) _lastBreakEnd = DateTime.Now;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (AppSettings.GetString("pomo.statsDate", string.Empty) !=
                DateTime.Today.ToString("yyyy-MM-dd"))
            {
                LoadStats();
            }

            if (_state == RunState.Running)
            {
                _remaining = _endAt - DateTime.Now;
                if (_remaining <= TimeSpan.Zero)
                    OnPhaseEnd(true);
                else
                    CheckSedentary();
            }
            UpdateDisplay();
        }

        private void OnPhaseEnd(bool countStats)
        {
            Phase next;
            if (_phase == Phase.Focus)
            {
                if (countStats)
                {
                    _completedCycles++;
                    _todayCount++;
                    _todayMinutes += (int)numFocus.Value;
                    SaveStats();
                    Notify("番茄完成", string.Format("今天第 {0} 个番茄完成，休息一下吧～", _todayCount));
                }
                int interval = Math.Max(1, (int)numInterval.Value);
                next = (_completedCycles > 0 && _completedCycles % interval == 0)
                    ? Phase.LongBreak
                    : Phase.ShortBreak;
            }
            else
            {
                next = Phase.Focus;
                if (countStats) Notify("休息结束", "开始新的专注吧");
            }

            _lastBreakEnd = DateTime.Now;
            if (countStats && chkSound.Checked) SystemSounds.Asterisk.Play();

            _phase = next;
            if (!countStats || chkAutoNext.Checked)
            {
                StartPhase(false);
            }
            else
            {
                _state = RunState.Idle;
                _remaining = DurationOf(_phase);
                _phaseTotal = _remaining;
            }
        }

        private void CheckSedentary()
        {
            int interval = (int)numSedentary.Value;
            if (interval <= 0) return;
            if (_state == RunState.Running && _phase == Phase.Focus &&
                (DateTime.Now - _lastBreakEnd).TotalMinutes >= interval)
            {
                Notify("久坐提醒", string.Format("已连续专注约 {0} 分钟，起来活动一下、喝口水吧～", interval));
                if (chkSound.Checked) SystemSounds.Asterisk.Play();
                _lastBreakEnd = DateTime.Now;
            }
        }

        private void Notify(string title, string text)
        {
            notifyIcon.BalloonTipTitle = title;
            notifyIcon.BalloonTipText = text;
            notifyIcon.BalloonTipIcon = ToolTipIcon.Info;
            notifyIcon.ShowBalloonTip(4000);
        }

        private void UpdateDisplay()
        {
            TimeSpan remain = _state == RunState.Running ? _endAt - DateTime.Now : _remaining;
            if (remain < TimeSpan.Zero) remain = TimeSpan.Zero;
            int totalSeconds = (int)Math.Ceiling(remain.TotalSeconds);
            lblTime.Text = string.Format("{0:D2}:{1:D2}", totalSeconds / 60, totalSeconds % 60);

            string phaseName = _phase == Phase.Focus ? "专注" : _phase == Phase.ShortBreak ? "短休息" : "长休息";
            Color phaseColor = _phase == Phase.Focus
                ? Color.FromArgb(79, 124, 255)
                : Color.FromArgb(47, 163, 107);

            if (_state == RunState.Idle)
            {
                lblPhase.Text = "准备开始 · " + phaseName;
                lblPhase.ForeColor = Color.Gray;
            }
            else if (_state == RunState.Paused)
            {
                lblPhase.Text = phaseName + " · 已暂停";
                lblPhase.ForeColor = Color.Gray;
            }
            else
            {
                lblPhase.Text = phaseName + "中";
                lblPhase.ForeColor = phaseColor;
            }
            lblTime.ForeColor = _state == RunState.Running ? phaseColor : Color.FromArgb(64, 64, 64);

            btnStartPause.Text = _state == RunState.Running ? "暂停" : _state == RunState.Paused ? "继续" : "开始";
            btnSkip.Enabled = _state != RunState.Idle;

            double total = _phaseTotal.TotalSeconds;
            int progress = 0;
            if (_state != RunState.Idle && total > 0)
            {
                double elapsed = total - remain.TotalSeconds;
                progress = (int)Math.Max(0, Math.Min(1000, elapsed / total * 1000));
            }
            prgPhase.Value = progress;

            lblTodayCount.Text = string.Format("完成番茄：{0} 个", _todayCount);
            lblTodayMinutes.Text = string.Format("专注时长：{0} 分钟", _todayMinutes);

            int sedentary = (int)numSedentary.Value;
            if (sedentary <= 0)
            {
                lblSedentaryState.Text = "久坐提醒：已关闭";
            }
            else if (_state == RunState.Running && _phase == Phase.Focus)
            {
                double left = sedentary - (DateTime.Now - _lastBreakEnd).TotalMinutes;
                lblSedentaryState.Text = string.Format("距下次久坐提醒：约 {0} 分钟",
                    Math.Max(0, (int)Math.Ceiling(left)));
            }
            else
            {
                lblSedentaryState.Text = string.Format("久坐提醒：每专注 {0} 分钟", sedentary);
            }
        }

        private void btnStartPause_Click(object sender, EventArgs e)
        {
            if (_state == RunState.Idle)
            {
                StartPhase(true);
            }
            else if (_state == RunState.Running)
            {
                _remaining = _endAt - DateTime.Now;
                if (_remaining < TimeSpan.Zero) _remaining = TimeSpan.Zero;
                _state = RunState.Paused;
            }
            else
            {
                _endAt = DateTime.Now + _remaining;
                _state = RunState.Running;
            }
            UpdateDisplay();
        }

        private void btnSkip_Click(object sender, EventArgs e)
        {
            if (_state == RunState.Idle) return;
            OnPhaseEnd(false);
            UpdateDisplay();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            _state = RunState.Idle;
            _phase = Phase.Focus;
            _completedCycles = 0;
            _remaining = DurationOf(Phase.Focus);
            _phaseTotal = _remaining;
            UpdateDisplay();
        }

        private void Setting_Changed(object sender, EventArgs e)
        {
            if (!_loaded) return;
            AppSettings.Set("pomo.focus", (int)numFocus.Value);
            AppSettings.Set("pomo.short", (int)numShort.Value);
            AppSettings.Set("pomo.long", (int)numLong.Value);
            AppSettings.Set("pomo.interval", (int)numInterval.Value);
            AppSettings.Set("pomo.sedentary", (int)numSedentary.Value);
            AppSettings.Set("pomo.autoNext", chkAutoNext.Checked);
            AppSettings.Set("pomo.sound", chkSound.Checked);
            if (_state == RunState.Idle)
            {
                _remaining = DurationOf(_phase);
                _phaseTotal = _remaining;
            }
            UpdateDisplay();
        }

        private void miOpen_Click(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            Activate();
        }

        private void miExit_Click(object sender, EventArgs e)
        {
            _exiting = true;
            Close();
        }

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            miOpen_Click(sender, e);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (!_exiting && e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
                if (!_trayHintShown)
                {
                    _trayHintShown = true;
                    Notify("仍在计时", "已最小化到托盘，计时不中断；双击图标可重新打开。");
                }
            }
            base.OnFormClosing(e);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            notifyIcon.Visible = false;
            base.OnFormClosed(e);
        }
    }
}