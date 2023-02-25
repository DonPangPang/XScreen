using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using XScreen.WpfApp.Pages;

namespace XScreen.WpfApp;

public static class GlobalLoader
{
    private static IServiceProvider _serviceProvider = null!;

    public static Window MainWindow { get; set; } = null!;

    public static Dictionary<string, Frame> Pages = new Dictionary<string, Frame>()
    {
        ["Home"] = new Frame() { Content = new HomePage() },
        ["Setting"] = new Frame() { Content = new SettingPage() }
    };

    public static void Instance(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public static T GetService<T>()
    {
        return _serviceProvider.GetService<T>()!;
    }
}