using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using XScreen.WpfApp.Components;
using XScreen.WpfApp.Pages;

namespace XScreen.WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            GlobalLoader.MainWindow = this;
            GMoreMenu.Visibility = Visibility.Collapsed;

            GlobalLoader.HomePage = new HomePage();
            GlobalLoader.SettingPage = new SettingPage();
            FrameBox.Content = new Frame() { Content = GlobalLoader.HomePage };

            GlobalLoader.HomePage.AddScreenItem(new ScreenItem());
            GlobalLoader.HomePage.AddScreenItem(new ScreenItem());
            GlobalLoader.HomePage.AddScreenItem(new ScreenItem());
            GlobalLoader.HomePage.AddScreenItem(new ScreenItem());
            GlobalLoader.HomePage.AddScreenItem(new ScreenItem());
            GlobalLoader.HomePage.AddScreenItem(new ScreenItem());
            GlobalLoader.HomePage.AddScreenItem(new ScreenItem());
            GlobalLoader.HomePage.AddScreenItem(new ScreenItem());
            GlobalLoader.HomePage.AddScreenItem(new ScreenItem());
            GlobalLoader.HomePage.AddScreenItem(new ScreenItem());
        }

        private void Btn_MouseMoveIn(object sender, MouseEventArgs e)
        {
            if (e.Source == BtnSetting)
            {
                ((Border)e.Source).Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#f6bd60"));
                return;
            }

            if (e.Source == BtnExit)
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

            if (Equals(e.Source, BtnExit))
            {
                ((Border)e.Source).Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F4606C"));
                return;
            }

            ((Border)e.Source).Background = new SolidColorBrush(Colors.Transparent);
        }

        private void MainWindow_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                this.DragMove();
            }
            catch
            {
                // ignored
            }
        }

        private void BtnExit_OnClick(object sender, MouseButtonEventArgs e)
        {
            if (AppSettings.IsMinimizeQ)
            {
                ExitMessageBox box = new ExitMessageBox();
                box.ShowDialog();
            }

            if (AppSettings.IsMinimize)
            {
                this.Visibility = Visibility.Collapsed;
            }
            else
            {
                Close();
            }
        }

        private void BtnToMin_OnClick(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Btn_Page_Select_Home(object sender, MouseButtonEventArgs e)
        {
            FrameBox.Content = new { Content = GlobalLoader.HomePage };
            //LbTitle.Content = "主页";
        }

        private void Btn_Page_Select_Setting(object sender, MouseButtonEventArgs e)
        {
            FrameBox.Content = new { Content = GlobalLoader.SettingPage };
            //LbTitle.Content = "设置";
        }

        private async void BtnSetting_OnClick(object sender, MouseButtonEventArgs e)
        {
            if (Width >= 810)
            {
                while (Width > 310)
                {
                    Width -= 10;
                }

                var newImg = new BitmapImage(new Uri("../Images/left.png", UriKind.Relative));
                BtnSettingPanel.Source = newImg;
            }
            else
            {
                while (Width < 810)
                {
                    Width += 10;
                }

                var newImg = new BitmapImage(new Uri("../Images/right.png", UriKind.Relative));
                BtnSettingPanel.Source = newImg;
            }
        }
    }
}