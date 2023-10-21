using System;
using System.Security.Principal;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Microsoft.Web.WebView2.Wpf;

namespace WebBrowser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public WebView2 tabItem = new WebView2();
        private int _tabCount = 1;
        public MainWindow()
        {
            InitializeComponent();
        }


        private void go_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(ab.Text))
            {
                Console.WriteLine("String = empty/null");
            }
            else
            {
                Uri value = new UriBuilder(ab.Text).Uri;

                if (tc.SelectedItem is TabItem selectedTab && selectedTab.Content is WebView2 webView)
                {
                    webView.Source = value;
                }
            }
        }

        private void newtab_Click(object sender, RoutedEventArgs e)
        {
            _tabCount++;

            WebView2 webView = new WebView2();
            webView.Source = new Uri("https://google.com");

            TabItem newTab = new TabItem
            {
                Header = $"Tab {_tabCount}",
                Content = webView
            };

            tc.Items.Add(newTab);
        }
        private void back_Click(object sender, RoutedEventArgs e)
        {
            tabItem.GoBack();
        }

        private void forward_Click(object sender, RoutedEventArgs e)
        {
            tabItem.GoForward();
        }

        private void refresh_Click(object sender, RoutedEventArgs e)
        {
            tabItem.Reload();
        }

        private void home_Click(object sender, RoutedEventArgs e)
        {
            string hmp = "https://google.com";
            Uri hm = new Uri(hmp);
            web.Source = hm;
        }
    }
}
