using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace WebBrowser
{
    /// <summary>
    /// Interakční logika pro Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public MainWindow MainWindow { get; set; }
        public

            Window1()
        {
            InitializeComponent();
            this.MainWindow = MainWindow;
        }
        private void AddBookmarkButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window2 w = new Window2();
            List<string> bookmarks = new List<string>();
            // Načtení záložek z souboru
            if (File.Exists(@"C:\Users\Public\Public Documents\WebBrowser\usersettings\bookmarks.txt"))
            {
                using (StreamWriter sw = new StreamWriter(@"C:\Users\Public\Public Documents\WebBrowser\usersettings\bookmarks.txt", true))
                {
                    sw.WriteLine(BookmarkURL.Text);
                    sw.Close();
                    w.BookmarkList.Items.Add(BookmarkURL.Text);
                    w.BookmarkList.Items.Refresh();
                    this.Close();
                }
            }
            if (!File.Exists(@"C:\Users\Public\Public Documents\WebBrowser\usersettings\bookmarks.txt"))
            {
                Directory.CreateDirectory(@"C:\Users\Public\Public Documents\WebBrowser\");
                Directory.CreateDirectory(@"C:\Users\Public\Public Documents\WebBrowser\usersettings\");
                File.Create(@"C:\Users\Public\Public Documents\WebBrowser\usersettings\bookmarks.txt");
            }
        }
    }
}
