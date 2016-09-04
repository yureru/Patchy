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
using System.IO;
using System.Net;

/// <summary>
/// Version that downloads favicons in a asunchronous way, but they're added in the WrapPanel
/// in the same order they were requested (declared in the s_Domains list.)
/// Exercise from page 17 of Async in C# 5.0 book from O'Reilly.
/// </summary>
namespace DownloadFaviconAsync
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly List<string> s_Domains = new List<string>
        {
            "google.com",
            "bing.com",
            "oreilly.com",
            //"simple-talk.com", // Gives an .EndInit() exception
            "microsoft.com",
            "facebook.com",
            "4chan.org",
            "baidu.com",
            "bbc.co.uk",
            "twitter.com"
        };

        private static List<Favicon> _unorderedFavicons = new List<Favicon>(s_Domains.Count);

        public MainWindow()
        {
            InitializeComponent();
        }

        private void GetButton_Click(object sender, RoutedEventArgs e)
        {
            int id = 0;
            foreach (string domain in s_Domains)
            {
                AddAFavicon(domain, id);
                ++id;
            }
        }

        private void AddAFavicon(string domain, int id)
        {
            WebClient webClient = new WebClient();
            webClient.DownloadDataCompleted += OnWebClientOnDownloadDataCompleted;
            webClient.DownloadDataAsync(new System.Uri("http://" + domain + "/favicon.ico"), id);
        }

        private static Image MakeImageControl(byte[] bytes)
        {
            Image imageControl = new Image();
            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.StreamSource = new MemoryStream(bytes);
            bitmapImage.EndInit();
            imageControl.Source = bitmapImage;
            imageControl.Width = 16;
            imageControl.Height = 16;
            return imageControl;
        }

        private void OnWebClientOnDownloadDataCompleted(object sender, DownloadDataCompletedEventArgs args)
        {
            Image imageControl = MakeImageControl(args.Result);
            Favicon item = new Favicon() { Image = imageControl, ID = (int)args.UserState };
            _unorderedFavicons.Add(item);
            if (_unorderedFavicons.Count == s_Domains.Count)
            {
                PopulateWrapPanel();
            }
        }

        private void PopulateWrapPanel()
        {
            var ordered = _unorderedFavicons.OrderBy(o => o.ID);
            foreach (var favicon in ordered)
            {
                m_WrapPanel.Children.Add(favicon.Image);
            }
            _unorderedFavicons = new List<Favicon>(s_Domains.Count);
        }

    }
}
