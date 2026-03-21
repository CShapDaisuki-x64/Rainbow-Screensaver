using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace スクリーンセーバー
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer MyDispatcherTimer;
        private Point? _lastMousePosition;
        public MainWindow()
        {
            InitializeComponent();
            // タイトルバーと境界線を非表示にします。
            WindowStyle = WindowStyle.None;

            // 最大化表示します。
            WindowState = WindowState.Maximized;
            MyDispatcherTimer = new DispatcherTimer();
            MyDispatcherTimer.Tick += Timer_Tick;
            MyDispatcherTimer.Interval = TimeSpan.FromSeconds(0.5);
            MyDispatcherTimer.Start();
        }
        Random R = new Random();
        private void Timer_Tick(object sender, EventArgs e)
        {
            int RR = R.Next(9);
            if(RR == 0)
            {
                a.Background = new SolidColorBrush(Colors.Red);
            }
            else if(RR==1)
            {
                a.Background = new SolidColorBrush(Colors.Orange);
            }
            else if (RR==2)
            {
                a.Background = new SolidColorBrush(Colors.Yellow);
            }
            else if(RR == 3)
            {
                a.Background = new SolidColorBrush(Colors.LightGreen);
            }
            else if(RR==4)
            {
                a.Background = new SolidColorBrush(Colors.Green);
            }
            else if(RR==5)
            {
                a.Background = new SolidColorBrush(Colors.LightBlue);
            }
            else if(RR==6)
            {
                a.Background = new SolidColorBrush(Colors.Blue);
            }
            else if(RR==7)
            {
                a.Background = new SolidColorBrush(Colors.Purple);
            }
            else if(RR==8)
            {
                a.Background = new SolidColorBrush(Colors.Pink);
            }
        }

        private void mouse(object sender, MouseButtonEventArgs e)
        {
            ExitFullScreen();
        }

        private void Grid_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            ExitFullScreen();
        }

        private void Grid_MouseEnter(object sender, MouseEventArgs e)
        {
            Point currentPosition = e.GetPosition(this);

            if (_lastMousePosition == null)
            {
                // 起動時の位置を記録するだけ
                _lastMousePosition = currentPosition;
                return;
            }

            // 以前の位置から一定距離（例: 5ピクセル以上）動いたかチェック
            // わずかな振動で解除されないようにするため
            if (Math.Abs(_lastMousePosition.Value.X - currentPosition.X) > 5 ||
                Math.Abs(_lastMousePosition.Value.Y - currentPosition.Y) > 5)
            {
                ExitFullScreen();
            }
        }
        private void ExitFullScreen()
        {
            WindowStyle = WindowStyle.SingleBorderWindow;
            WindowState = WindowState.Normal;
            Close();
        }
    }
}