using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Windows.Controls;
using XScreen.WpfApp.Components;

namespace XScreen.WpfApp.Pages
{
    /// <summary>
    /// HomePage.xaml 的交互逻辑
    /// </summary>
    public partial class HomePage : Page
    {
        public ConcurrentDictionary<Guid, ScreenItem> PageItems { get; set; } = new();

        public HomePage()
        {
            InitializeComponent();
        }

        public void AddScreenItem(ScreenItem item)
        {
            PageItems.TryAdd(item.Id, item);
            SPScreenItems.Children.Add(item);
        }

        public void RemoveScreenItem(ScreenItem item)
        {
            PageItems.TryRemove(item.Id, out var _);
            SPScreenItems.Children.Remove(item);
        }

        public void Sort()
        {
            var res = PageItems.Values.ToList().OrderByDescending(x => x.IsPin).ThenByDescending(x => x.CreateTime);

            SPScreenItems.Children.Clear();
            foreach (var item in res)
            {
                SPScreenItems.Children.Add(item);
            }
        }
    }
}