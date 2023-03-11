using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace XScreen.WpfApp.Components
{
    /// <summary>
    /// ScreenItem.xaml 的交互逻辑
    /// </summary>
    public partial class ScreenItem : UserControl
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public bool IsPin { get; set; } = false;
        public DateTime CreateTime { get; set; } = DateTime.Now;

        public ScreenItem()
        {
            InitializeComponent();

            Label.Content = GlobalLoader.Index++;

            InitPin();
        }

        private void Btn_MouseMoveIn(object sender, MouseEventArgs e)
        {
            ((Border)e.Source).Background = new SolidColorBrush(Colors.WhiteSmoke);
        }

        private void Btn_MouseMoveOut(object sender, MouseEventArgs e)
        {
            ((Border)e.Source).Background = new SolidColorBrush(Colors.White);
        }

        private void BtnDrop_OnClick(object sender, MouseButtonEventArgs e)
        {
            GlobalLoader.HomePage.SPScreenItems.Children.Remove(this);
        }

        private void BtnPin_OnClick(object sender, MouseButtonEventArgs e)
        {
            IsPin = !IsPin;

            InitPin();

            GlobalLoader.HomePage.Sort();
        }

        private void InitPin()
        {
            if (IsPin)
            {
                var newImg = new BitmapImage(new Uri("../Images/pin.png", UriKind.Relative));
                BtnPinImage.Source = newImg;
            }
            else
            {
                var newImg = new BitmapImage(new Uri("../Images/unpin.png", UriKind.Relative));
                BtnPinImage.Source = newImg;
            }
        }

        private void ScreenItemOnClick(object sender, MouseButtonEventArgs e)
        {
            new ImageViewer().ShowDialog();
        }
    }
}