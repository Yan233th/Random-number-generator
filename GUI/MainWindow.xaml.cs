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

namespace GUI
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow ()
        {
            InitializeComponent ();
        }

        private void Window_MouseDown (object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove ();
            }
        }

        private void CloseButton_Click (object sender, RoutedEventArgs e)
        {
            Close ();
        }

        private void MinimizeButton_Click (object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private int isInteger (string input)
        {
            if (int.TryParse (input, out int value))
            {
                if (value >= -1145141919 && value <= 1145141919)
                {
                    return 0;
                }
                else
                {
                    return 1; //超出范围
                }
            }
            else
            {
                return -1; //不合法
            }
        }

        private async void Start_Button_Click (object sender, RoutedEventArgs e)
        {
            Start_Button.IsEnabled = false;
            if (isInteger (Start_TextBox.Text) != 0 || isInteger (End_TextBox.Text) != 0)
            {
                MessageBox.Show ("输入不是有效的整数值！");
                Start_Button.IsEnabled = true;
                return;
            }
            int Start = int.Parse (Start_TextBox.Text);
            int End = int.Parse (End_TextBox.Text);
            if (Start > End)
            {
                MessageBox.Show ("最小值大于最大值！");
                Start_Button.IsEnabled = true;
                return;
            }
            if (Start < -99 || End > 999)
            {
                MessageBox.Show ("数值超出范围！\n范围: -99 ~ 999");
                Start_Button.IsEnabled = true;
                return;
            }
            double gap = 1;
            Random random = new Random ();
            Result_TextBlock.Foreground = Brushes.Black;
            while (gap < 1250)
            {
                await Task.Delay ((int) gap);
                Result_TextBlock.Text = (random.Next (Start, End + 1)).ToString ();
                gap *= 1.25;
            }
            Result_TextBlock.Foreground = Brushes.Red;
            Start_Button.IsEnabled = true;
        }
    }
}
