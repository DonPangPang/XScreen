using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace XScreen.WpfApp.Components
{
    /// <summary>
    /// ExitMessageBox.xaml 的交互逻辑
    /// </summary>
    public partial class ExitMessageBox : Window
    {
        public ExitMessageBox()
        {
            InitializeComponent();

            RbMinimize.IsChecked = AppSettings.IsMinimize;
            CbMinimizeQ.IsChecked = AppSettings.IsMinimizeQ;
        }

        private void RbMinimize_OnChecked(object sender, RoutedEventArgs e)
        {
            AppSettings.IsMinimize = RbMinimize.IsChecked ?? false;
        }

        private void CbMinimizeQ_OnChecked(object sender, RoutedEventArgs e)
        {
            AppSettings.IsMinimizeQ = CbMinimizeQ.IsChecked ?? false;
        }

        private void Btn_MouseMoveIn(object sender, MouseEventArgs e)
        {
            ((Border)e.Source).Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#48cae4"));
        }

        private void Btn_MouseMoveOut(object sender, MouseEventArgs e)
        {
            ((Border)e.Source).Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#00b4d8"));
        }

        private void BtnEnsure_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            AppSettings.IsMinimize = RbMinimize.IsChecked ?? false;
            AppSettings.IsMinimizeQ = CbMinimizeQ.IsChecked ?? false;

            Close();

            if (RbMinimize.IsChecked ?? false)
            {
                Visibility = Visibility.Collapsed;
            }
            else
            {
                GlobalLoader.MainWindow.Close();
            }
        }
    }
}