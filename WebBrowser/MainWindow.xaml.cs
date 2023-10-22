using System;
using System.Security.Principal;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Microsoft.Web.WebView2.WinForms;
using Microsoft.Web.WebView2.Wpf;

namespace WebBrowser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Microsoft.Web.WebView2.Wpf.WebView2 tabItem = new Microsoft.Web.WebView2.Wpf.WebView2();
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

                if (tc.SelectedItem is TabItem selectedTab && selectedTab.Content is Microsoft.Web.WebView2.Wpf.WebView2 webView)
                {
                    webView.Source = value;
                }
            }
        }

        private void newtab_Click(object sender, RoutedEventArgs e)
        {
            _tabCount++;
            Microsoft.Web.WebView2.Wpf.WebView2 webView = new Microsoft.Web.WebView2.Wpf.WebView2();
            webView.Source = new Uri("https://google.com");
            webView.EnsureCoreWebView2Async(null).ContinueWith((task) =>
            {
                if (task.IsCompleted)
                {
                    TabItem newTab = new TabItem
                    {
                        Header = $"Tab {_tabCount}",
                        Content = webView
                    };

                    tc.Items.Add(newTab);
                }
            });
        }
        private void back_Click(object sender, RoutedEventArgs e)
        {
            if (tc.SelectedItem is TabItem selectedTab)
            {
                if (selectedTab.Content is Microsoft.Web.WebView2.Wpf.WebView2 webView)
                {
                    if (webView.CoreWebView2.CanGoBack)
                    {
                        webView.CoreWebView2.GoBack();
                    }
                }
            }
        }

        private void forward_Click(object sender, RoutedEventArgs e)
        {
            if (tc.SelectedItem is TabItem selectedTab)
            {
                if (selectedTab.Content is Microsoft.Web.WebView2.Wpf.WebView2 webView)
                {
                    if (webView.CoreWebView2.CanGoForward)
                    {
                        webView.CoreWebView2.GoForward();
                    }
                }
            }
        }

        private void refresh_Click(object sender, RoutedEventArgs e)
        {
            if (tc.SelectedItem is TabItem selectedTab)
            {
                if (selectedTab.Content is Microsoft.Web.WebView2.Wpf.WebView2 webView)
                {
                    webView.EnsureCoreWebView2Async(null).ContinueWith((task) =>
                    {
                        if (task.IsCompleted)
                        {
                            Dispatcher.Invoke(() =>
                            {
                                webView.CoreWebView2.Reload();
                            });
                        }
                    });
                }
            }
        }

        private void home_Click(object sender, RoutedEventArgs e)
        {
            string hmp = "https://google.com";
            Uri hm = new Uri(hmp);
            web.Source = hm;
        }
    }
}
