using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;

namespace WebBrowser
{
    /// <summary>
    /// Interakční logika pro Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public event Action<Uri> SignalSent;
        public Window2()
        {
            InitializeComponent();
            Loaded += CreateBookmarks;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window1 w = new Window1();
            w.Show();
        }
        public void CreateBookmarks(object sender, RoutedEventArgs e)
        {
            string bookmarksFilePath = @"C:\Users\Public\Public Documents\WebBrowser\usersettings\bookmarks.txt";

            if (File.Exists(bookmarksFilePath))
            {
                using (StreamReader sr = new StreamReader(bookmarksFilePath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        BookmarkList.Items.Add(line);
                    }
                    sr.Close();
                }
            }
            if (!File.Exists(@"C:\Users\Public\Public Documents\WebBrowser\usersettings\bookmarks.txt"))
            {
                Directory.CreateDirectory(@"C:\Users\Public\Public Documents\WebBrowser\");
                Directory.CreateDirectory(@"C:\Users\Public\Public Documents\WebBrowser\usersettings\");
                File.Create(@"C:\Users\Public\Public Documents\WebBrowser\usersettings\bookmarks.txt");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string bookmarksFilePath = @"C:\Users\Public\Public Documents\WebBrowser\usersettings\bookmarks.txt";

            if (File.Exists(bookmarksFilePath))
            {
                using (StreamReader sr = new StreamReader(bookmarksFilePath))
                {
                    string line;
                    BookmarkList.Items.Clear();
                    while ((line = sr.ReadLine()) != null)
                    {
                        BookmarkList.Items.Add(line);
                    }
                    sr.Close();
                }
            }
            if (!File.Exists(@"C:\Users\Public\Public Documents\WebBrowser\usersettings\bookmarks.txt"))
            {
                Directory.CreateDirectory(@"C:\Users\Public\Public Documents\WebBrowser\");
                Directory.CreateDirectory(@"C:\Users\Public\Public Documents\WebBrowser\usersettings\");
                File.Create(@"C:\Users\Public\Public Documents\WebBrowser\usersettings\bookmarks.txt");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (Uri.IsWellFormedUriString(BookmarkList.SelectedItem.ToString(), UriKind.Absolute))
            {
                var window1 = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
                if (window1 != null)
                {
                    string text = BookmarkList.SelectedItem.ToString();
                    window1.web.Source = new Uri(text);
                }
                
            } else
            {
                MessageBox.Show("Nemáš zadanou správnou URL adresu ve formátu http(s)://<adresaurl>.<com/cz apod> !!");
            }
        }
    }
}
