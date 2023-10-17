using System;
using System.Windows;

namespace WebBrowser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            web.GoBack();
        }

        private void forward_Click(object sender, RoutedEventArgs e)
        {
            web.GoForward();
        }

        private void refresh_Click(object sender, RoutedEventArgs e)
        {
            web.Reload();
        }

        private void home_Click(object sender, RoutedEventArgs e)
        {
            string hmp = "https://google.com";
            Uri hm = new Uri(hmp);
            web.Source = hm;
        }

        private void go_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(ab.Text))
            {
                Console.WriteLine("String = empty/null");
            } else
            {
                Uri value = new UriBuilder(ab.Text).Uri;
                web.Source = value;
            }
        }
    }
}
