using System;
using System.Threading;
using System.Windows.Forms;

namespace PomodoroTimer
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            bool createdNew;
            using (var mutex = new Mutex(true, @"Local\PomodoroTimer.SingleInstance.Mutex", out createdNew))
            {
                if (!createdNew)
                {
                    MessageBox.Show("番茄钟已经在运行，请查看任务栏托盘图标。", "番茄钟",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.ThreadException += (s, e) =>
                    MessageBox.Show("发生未处理错误：\n" + e.Exception.Message, "番茄钟",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                Application.Run(new MainForm());
                GC.KeepAlive(mutex);
            }
        }
    }
}