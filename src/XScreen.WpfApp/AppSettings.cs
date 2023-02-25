using System.Collections.Generic;
using System.Configuration;
using XScreen.WpfApp.Enums;
using XScreen.WpfApp.Extensions;

namespace XScreen.WpfApp;

using static System.Configuration.ConfigurationManager;

public static class AppSettings
{
    private static string Get(string key)
    {
        return ConfigurationManager.AppSettings[key] ?? "";
    }

    public static bool IsMinimize
    {
        get => (bool)"T".Equals(Get(nameof(IsMinimize)));
        set
        {
            var coc = OpenExeConfiguration(ConfigurationUserLevel.None);
            coc.AppSettings.Settings[nameof(IsMinimize)].Value = value ? "T" : "F";
            coc.Save();
        }
    }

    public static bool IsMinimizeQ
    {
        get => (bool)"T".Equals(Get(nameof(IsMinimizeQ)));
        set
        {
            var coc = OpenExeConfiguration(ConfigurationUserLevel.None);
            coc.AppSettings.Settings[nameof(IsMinimizeQ)].Value = value ? "T" : "F";
            coc.Save();
        }
    }

    public static Dictionary<Operate, string> ShortCutKeys
    {
        get => Get(nameof(ShortCutKeys)).ToObject<Dictionary<Operate, string>>() ?? new Dictionary<Operate, string>();
        set
        {
            var coc = OpenExeConfiguration(ConfigurationUserLevel.None);
            coc.AppSettings.Settings[nameof(ShortCutKeys)].Value = value.ToJson();
            coc.Save();
        }
    }

    public static bool IsCopyToClipboard
    {
        get => (bool)"T".Equals(Get(nameof(IsCopyToClipboard)));
        set
        {
            var coc = OpenExeConfiguration(ConfigurationUserLevel.None);
            coc.AppSettings.Settings[nameof(IsCopyToClipboard)].Value = value ? "T" : "F";
            coc.Save();
        }
    }
}