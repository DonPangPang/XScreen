using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace XScreen.WpfApp.Components
{
    /// <summary>
    /// ScreenItem.xaml 的交互逻辑
    /// </summary>
    public partial class ScreenItem : UserControl
    {
        public ScreenItem()
        {
            InitializeComponent();
        }

        private void Btn_MouseMoveIn(object sender, MouseEventArgs e)
        {
            if (e.Source == BtnSetting)
            {
                ((Border)e.Source).Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#f6bd60"));
                return;
            }

            if (e.Source == BtnDrop)
            {
                ((Border)e.Source).Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#f28482"));
                return;
            }

            ((Border)e.Source).Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#A0EEE1"));
        }

        private void Btn_MouseMoveOut(object sender, MouseEventArgs e)
        {
            if (Equals(e.Source, BtnSetting))
            {
                ((Border)e.Source).Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF9900"));
                return;
            }

            if (Equals(e.Source, BtnDrop))
            {
                ((Border)e.Source).Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F4606C"));
                return;
            }

            ((Border)e.Source).Background = new SolidColorBrush(Colors.Transparent);
        }

        private void BtnDrop_OnClick(object sender, MouseButtonEventArgs e)
        {
            GlobalLoader.HomePage.SPScreenItems.Children.Remove(this);
        }
    }
}