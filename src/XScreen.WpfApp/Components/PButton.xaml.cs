using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace XScreen.WpfApp.Components
{
    /// <summary>
    /// PButton.xaml 的交互逻辑
    /// </summary>
    public partial class PButton : UserControl
    {
        public string Text { get; set; } = string.Empty;
        public CornerRadius CornerRadius { get; set; } = new CornerRadius(0);

        public Color MoveInBackGround { get; set; } = Colors.Transparent;
        //new SolidColorBrush((Color)ColorConverter.ConvertFromString(""));

        public Color MoveOutBackGround { get; set; } = Colors.Transparent;

        public PButton()
        {
            InitializeComponent();

            PBtn.CornerRadius = CornerRadius;
            PText.FontSize = FontSize;
            PText.Foreground = Foreground;
            PText.Content = Text;
        }

        private void Btn_MouseMoveIn(object sender, MouseEventArgs e)
        {
            ((Border)e.Source).Background = new SolidColorBrush(MoveInBackGround);
            PText.Content = Text;
        }

        private void Btn_MouseMoveOut(object sender, MouseEventArgs e)
        {
            ((Border)e.Source).Background = new SolidColorBrush(MoveOutBackGround);
        }
    }
}