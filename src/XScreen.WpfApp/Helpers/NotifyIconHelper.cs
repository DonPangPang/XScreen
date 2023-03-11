using System;
using System.Windows;
using ReactiveUI;
using XScreen.WpfApp.Properties;

namespace XScreen.WpfApp.Helpers;

public static class NotifyIconHelper
{
    private static readonly Random random = new();
    private static readonly ToolTipIcon[] toolTipIcons = (ToolTipIcon[])Enum.GetValues(typeof(ToolTipIcon));

    private static object Icon => OperatingSystem2.IsMacOS ? Resource.Icon : Resource.Icon;

    /// <summary>
    /// </summary>
    /// <param name="notifyIcon"> </param>
    /// <param name="exit">       </param>
    public static void Init(NotifyIcon notifyIcon, Action? exit)
    {
        notifyIcon.Text = "XScreen";
        notifyIcon.Icon = Icon;
        var typeUNUserNotificationCenter = Type.GetType("UserNotifications.UNUserNotificationCenter, Xamarin.Mac");

        notifyIcon.ContextMenuStrip.Items.Add(new()
        {
            Text = "打开",
            Command = ReactiveCommand.Create(() =>
            {
                GlobalLoader.MainWindow.Visibility = Visibility.Visible;
            }),
        });

        notifyIcon.ContextMenuStrip.Items.Add(new()
        {
            Text = "退出",
            Command = ReactiveCommand.Create(() => exit?.Invoke()),
        });

        notifyIcon.DoubleClick += NotifyIconOnDoubleClick;
    }

    private static void NotifyIconOnDoubleClick(object? sender, EventArgs e)
    {
        GlobalLoader.MainWindow.Visibility = Visibility.Visible;
    }
}