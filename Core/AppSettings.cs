using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PomodoroTimer.Core
{
    /// <summary>极简设置存储：%AppData%\PomodoroTimer\settings.ini。</summary>
    public static class AppSettings
    {
        private static readonly Dictionary<string, string> Values =
            new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        public static string DataDir
        {
            get
            {
                string dir = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "PomodoroTimer");
                Directory.CreateDirectory(dir);
                return dir;
            }
        }

        private static string SettingsPath
        {
            get { return Path.Combine(DataDir, "settings.ini"); }
        }

        static AppSettings()
        {
            Load();
        }

        public static void Load()
        {
            Values.Clear();
            try
            {
                if (!File.Exists(SettingsPath)) return;
                foreach (string line in File.ReadAllLines(SettingsPath, Encoding.UTF8))
                {
                    int idx = line.IndexOf('=');
                    if (idx <= 0) continue;
                    Values[line.Substring(0, idx).Trim()] = line.Substring(idx + 1);
                }
            }
            catch
            {
            }
        }

        public static void Save()
        {
            try
            {
                var sb = new StringBuilder();
                foreach (var kv in Values) sb.Append(kv.Key).Append('=').AppendLine(kv.Value);
                File.WriteAllText(SettingsPath, sb.ToString(), Encoding.UTF8);
            }
            catch
            {
            }
        }

        public static string GetString(string key, string fallback)
        {
            string v;
            return Values.TryGetValue(key, out v) ? v : fallback;
        }

        public static int GetInt(string key, int fallback)
        {
            int v;
            return int.TryParse(GetString(key, null), out v) ? v : fallback;
        }

        public static bool GetBool(string key, bool fallback)
        {
            string v = GetString(key, null);
            if (v == null) return fallback;
            return v == "1" || string.Equals(v, "true", StringComparison.OrdinalIgnoreCase);
        }

        public static void Set(string key, string value)
        {
            Values[key] = value ?? string.Empty;
            Save();
        }

        public static void Set(string key, int value)
        {
            Set(key, value.ToString());
        }

        public static void Set(string key, bool value)
        {
            Set(key, value ? "1" : "0");
        }
    }
}