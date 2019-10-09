using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Microsoft.Toolkit.Uwp.UI.Controls;
using Windows.UI.Xaml.Media.Imaging;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace LRMS.UWP
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class LoginPage : Page
    {
        public bool IsLoading = false;

        public LoginPage()
        {
            this.InitializeComponent();
        }

        private void PasswordBox_OnChanged(object sender, RoutedEventArgs e)
        {

        }

        private void Ellipse_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Debug.WriteLine("Oh");
            //LoadingControl.IsLoading = true;
            LoginProgressRing.IsActive = true;
            this.Frame.Navigate(typeof(AppShell));
        }

        private void Page_Loading(FrameworkElement sender, object args)
        {
            ImageBrush imageBrush = new ImageBrush();
            imageBrush.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/background-pic1.jpg", UriKind.Absolute));
            BackgroundPic.Background = imageBrush;
        }
    }
}
