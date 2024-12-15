using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Xaml;

namespace WebBrowser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        public Microsoft.Web.WebView2.Wpf.WebView2 tabItem = new Microsoft.Web.WebView2.Wpf.WebView2();
        private int _tabCount = 1;
        public string URLHP;
        public MainWindow()
        {
            InitializeComponent();
            if (!File.Exists(@"C:\Users\Public\Public Documents\WebBrowser\usersettings\URLHP.txt"))
            {
                URLHP = "https://www.google.com/";
            }
            else
if (File.Exists(@"C:\Users\Public\Public Documents\WebBrowser\usersettings\URLHP.txt"))
            {
                using (StreamReader sr = new StreamReader(@"C:\Users\Public\Public Documents\WebBrowser\usersettings\URLHP.txt"))
                {
                    URLHP = sr.ReadToEnd();
                    if (sr == null || URLHP == null || URLHP == string.Empty)
                    {
                        URLHP = "https://www.google.com/";
                        web.Source = new Uri("https://www.google.com/");
                    }
                    else
                    {
                        if (sr == null || URLHP == null || URLHP == string.Empty)
                        {
                            URLHP = "https://www.google.com/";
                            web.Source = new Uri("https://www.google.com/");
                        }
                        web.Source = new Uri(URLHP);
                        URLHP = sr.ReadLine();
                        sr.Close();
                    }



                }
            }
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
            if (!File.Exists(@"C:\Users\Public\Public Documents\WebBrowser\usersettings\URLHP.txt"))
            {
                URLHP = "https://www.google.com/";
            }
            else
            if (File.Exists(@"C:\Users\Public\Public Documents\WebBrowser\usersettings\URLHP.txt"))
            {
                using (StreamReader sr = new StreamReader(@"C:\Users\Public\Public Documents\WebBrowser\usersettings\URLHP.txt"))
                {
                    URLHP = sr.ReadToEnd();
                    if (sr == null || URLHP == null)
                    {
                        URLHP = "https://www.google.com/";
                    }
                    else
                    {
                        sr.Close();
                    }
                }
            }
            if (URLHP == null || URLHP == string.Empty)
            {
                webView.Source = new Uri("https://www.google.com/");

            }
            else
            {
                webView.Source = new Uri(URLHP);
            }
            Dispatcher.Invoke(() =>
            {
                TabItem newTab = new TabItem
                {
                    Header = $"Karta {_tabCount}",
                    Content = webView
                };
                tc.Items.Add(newTab);
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
            if (!File.Exists(@"C:\Users\Public\Public Documents\WebBrowser\usersettings\URLHP.txt"))
            {
                URLHP = "https://www.google.com/";
            }
            else
if (File.Exists(@"C:\Users\Public\Public Documents\WebBrowser\usersettings\URLHP.txt"))
            {
                using (StreamReader sr = new StreamReader(@"C:\Users\Public\Public Documents\WebBrowser\usersettings\URLHP.txt"))
                {
                    URLHP = sr.ReadToEnd();
                    if (sr == null || URLHP == null || URLHP == string.Empty)
                    {
                        if (tc.SelectedItem is TabItem selectedTab && selectedTab.Content is Microsoft.Web.WebView2.Wpf.WebView2 webView)
                        {
                            webView.Source = new Uri("https://www.google.com/");
                        }
                            
                    }
                    else
                    {
                        if (tc.SelectedItem is TabItem selectedTab && selectedTab.Content is Microsoft.Web.WebView2.Wpf.WebView2 webView)
                        {
                            webView.Source = new Uri(URLHP);
                            URLHP = sr.ReadLine();
                            sr.Close();
                        }
                            
                    }

                }
            }
        }

        private void remtab_Click(object sender, RoutedEventArgs e)
        {
            if (tc.Items.Count > 0)
            {
                tc.Items.Remove(tc.SelectedItem);
            }
        }

        private void back_Kopírovat_Click(object sender, RoutedEventArgs e)
        {
            Window2 bookmark = new Window2();
            bookmark.Show();
        }

        private void web_NavigationCompleted(object sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs e)
        {
            ab.Text = web.Source.ToString();
        }

        private void back_Kopírovat1_Click(object sender, RoutedEventArgs e)
        {
            Window3 w3 = new Window3();
            w3.Show();
        }
    }
}