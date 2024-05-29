using System;
using System.IO;
using System.Windows;
using System.Threading;

namespace WebBrowser
{
    /// <summary>
    /// Interakční logika pro Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        public Window3()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (!File.Exists(@"C:\Users\Public\Public Documents\WebBrowser\usersettings\URLHP.txt"))
            {
                Directory.CreateDirectory(@"C:\Users\Public\Public Documents\WebBrowser\");
                Directory.CreateDirectory(@"C:\Users\Public\Public Documents\WebBrowser\usersettings\");
                using (FileStream fs = File.Create(@"C:\Users\Public\Public Documents\WebBrowser\usersettings\URLHP.txt"))
                {
                    fs.Close();
                } 

                using (StreamWriter sw = new StreamWriter(@"C:\Users\Public\Public Documents\WebBrowser\usersettings\URLHP.txt"))
                {
                    sw.Write(urlb.Text);
                    sw.Close();
                }
            }

            else if (File.Exists(@"C:\Users\Public\Public Documents\WebBrowser\usersettings\URLHP.txt"))
                using (StreamWriter outputFile = new StreamWriter(@"C:\Users\Public\Public Documents\WebBrowser\usersettings\URLHP.txt"))
                {
                    if (Uri.IsWellFormedUriString(urlb.Text.ToString(), UriKind.Absolute))
                    {
                        outputFile.Write(urlb.Text);
                        outputFile.Close();
                    }
                    else
                    {
                        MessageBox.Show("Nemáš správně zadanou URL; takto má být (ukázka): http(s)://<hledaciengine>.<cz,com apod>/");
                        outputFile.Close();
                    }

                }
        }
    }
}
