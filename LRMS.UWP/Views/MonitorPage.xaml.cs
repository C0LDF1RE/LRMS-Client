using LRMS.UWP.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace LRMS.UWP.Views
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MonitorPage : Page
    {

        ObservableCollection<MonitorPageViewModel> metadatas = new ObservableCollection<MonitorPageViewModel>();
        DispatcherTimer timer;

        public MonitorPage()
        {
            this.InitializeComponent();

            radChart.DataContext = metadatas;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += Timer_Tick;//每秒触发这个事件，以刷新指针
            timer.Start();
        }

        private void Timer_Tick(object sender, object e)
        {
            Random rand = new Random();
            MonitorPageViewModel nextElement = new MonitorPageViewModel() { Timing = DateTime.Now.ToLongTimeString().ToString(), Value = rand.Next(1, 100) };
            metadatas.Add(nextElement);
        }
    }
}
