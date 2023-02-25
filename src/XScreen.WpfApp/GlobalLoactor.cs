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

    public static HomePage HomePage { get; set; } = null!;
    public static SettingPage SettingPage { get; set; } = null!;

    public static void Instance(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public static T GetService<T>()
    {
        return _serviceProvider.GetService<T>()!;
    }
}