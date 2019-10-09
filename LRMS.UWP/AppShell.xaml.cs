using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Controls;
using System.Diagnostics;
using LRMS.UWP.Views;
using Windows.UI.Xaml.Media.Animation;
using Windows.System;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace LRMS.UWP
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class AppShell : Page
    {
        public AppShell()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Gets the navigation frame instance.
        /// </summary>
        //public Frame AppFrame => ContentFrame;

        private void ContentFrame_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        // List of ValueTuple holding the Navigation Tag and the relative Navigation Page
        private readonly List<(string Tag, Type Page)> _pages = new List<(string Tag, Type Page)>
        {
            ("welcome", typeof(WelcomePage)),
            ("analysis", typeof(AnalysisPage)),
            ("monitor", typeof(MonitorPage)),
            ("workpane", typeof(WorkPanePage)),
            ("profile", typeof(ProfilePage)),
            ("account", typeof(AccountPage))
        };

        private void NavView_Loading(FrameworkElement sender, object args)
        {
            // You can also add items in code.
            NavView.MenuItems.Add(new NavigationViewItem
            {
                Content = "Welcome",
                Icon = new SymbolIcon((Symbol)0xE10F),
                Tag = "welcome",
            });

            NavView.MenuItems.Add(new NavigationViewItemSeparator());

            NavView.MenuItems.Add(new NavigationViewItemHeader
            {
                Content = "DashBoard"
            });

            NavView.MenuItems.Add(new NavigationViewItem
            {
                Content = "Analysis",
                Icon = new SymbolIcon((Symbol)0xE1E9),
                Tag = "analysis"
            });

            NavView.MenuItems.Add(new NavigationViewItem
            {
                Content = "Monitor",
                Icon = new SymbolIcon((Symbol)0xEB3C),
                Tag = "monitor"
            });

            NavView.MenuItems.Add(new NavigationViewItem
            {
                Content = "WorkPane",
                Icon = new SymbolIcon((Symbol)0xE138),
                Tag = "workpane"
            });

            NavView.MenuItems.Add(new NavigationViewItem
            {
                Content = "Profile",
                Icon = new SymbolIcon((Symbol)0xE12F),
                Tag = "profile"
            });

            NavView.MenuItems.Add(new NavigationViewItem
            {
                Content = "Account",
                Icon = new SymbolIcon((Symbol)0xE13D),
                Tag = "account"
            });
        }

        private void NavView_Loaded(object sender, RoutedEventArgs e)
        {

            var resourceLoader = Windows.ApplicationModel.Resources.ResourceLoader.GetForCurrentView();

            //var nvmi = VisualTreeHelper.GetChild(NavView, 0) as NavigationViewItem;
            //nvmi.Content = resourceLoader.GetString("NavItemWelcome");



            //_pages.Add(("content", typeof(MyContentPage)));

            // Add handler for ContentFrame navigation.
            ContentFrame.Navigated += On_Navigated;
            // NavView doesn't load any page by default, so load home page.
            NavView.SelectedItem = NavView.MenuItems[0];
            // If navigation occurs on SelectionChanged, this isn't needed.
            // Because we use ItemInvoked to navigate, we need to call Navigate
            // here to load the home page.
            NavView_Navigate("welcome", new EntranceNavigationTransitionInfo());
        }

        private void NavView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            var label = args.InvokedItem as string;
            if (args.IsSettingsInvoked)
            {
                Debug.WriteLine("SettingsInvoked.");
            }
            Debug.WriteLine(label);

            if (args.IsSettingsInvoked == true)
            {
                NavView_Navigate("settings", args.RecommendedNavigationTransitionInfo);
            }
            else if (args.InvokedItemContainer != null)
            {
                var navItemTag = args.InvokedItemContainer.Tag.ToString();
                //NavView_Navigate(navItemTag, args.RecommendedNavigationTransitionInfo);
                NavView_Navigate(navItemTag, new DrillInNavigationTransitionInfo());
            }
            //var pageType =
            //    args.IsSettingsInvoked ? typeof(SettingsPage) :
            //    label == CustomerListLabel ? typeof(CustomerListPage) :
            //    label == OrderListLabel ? typeof(OrderListPage) : null;
            //if (pageType != null && pageType != AppFrame.CurrentSourcePageType)
            //{
            //    AppFrame.Navigate(pageType);
            //}
        }

        private void NavView_Navigate(string navItemTag, NavigationTransitionInfo transitionInfo)
        {
            Type _page = null;
            if (navItemTag == "settings")
            {
                _page = typeof(SettingsPage);
            }
            else
            {
                var item = _pages.FirstOrDefault(p => p.Tag.Equals(navItemTag));
                _page = item.Page;
            }
            // Get the page type before navigation so you can prevent duplicate
            // entries in the backstack.
            var preNavPageType = ContentFrame.CurrentSourcePageType;

            // Only navigate if the selected page isn't currently loaded.
            if (!(_page is null) && !Type.Equals(preNavPageType, _page))
            {
                ContentFrame.Navigate(_page, null, transitionInfo);
            }
        }

        private void NavView_BackRequested(NavigationView sender, NavigationViewBackRequestedEventArgs args)
        {
            On_BackRequested();
        }
        private void On_Navigated(object sender, NavigationEventArgs e)
        {
            NavView.IsBackEnabled = ContentFrame.CanGoBack;

            if (ContentFrame.SourcePageType == typeof(SettingsPage))
            {
                // SettingsItem is not part of NavView.MenuItems, and doesn't have a Tag.
                NavView.SelectedItem = (NavigationViewItem)NavView.SettingsItem;
                NavView.Header = "Settings";
            }
            else if (ContentFrame.SourcePageType != null)
            {
                var item = _pages.FirstOrDefault(p => p.Page == e.SourcePageType);

                NavView.SelectedItem = NavView.MenuItems
                    .OfType<NavigationViewItem>()
                    .First(n => n.Tag.Equals(item.Tag));

                NavView.Header =
                    ((NavigationViewItem)NavView.SelectedItem)?.Content?.ToString();
            }
        }

        private bool On_BackRequested()
        {
            if (!ContentFrame.CanGoBack)
                return false;

            // Don't go back if the nav pane is overlayed.
            if (NavView.IsPaneOpen &&
                (NavView.DisplayMode == NavigationViewDisplayMode.Compact ||
                 NavView.DisplayMode == NavigationViewDisplayMode.Minimal))
                return false;

            ContentFrame.GoBack();
            return true;
        }

        private void AppShell_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            FocusNavigationDirection direction = FocusNavigationDirection.None;
            switch (e.Key)
            {
                case VirtualKey.Left:
                case VirtualKey.GamepadDPadLeft:
                case VirtualKey.GamepadLeftThumbstickLeft:
                case VirtualKey.NavigationLeft:
                    direction = FocusNavigationDirection.Left;
                    break;
                case VirtualKey.Right:
                case VirtualKey.GamepadDPadRight:
                case VirtualKey.GamepadLeftThumbstickRight:
                case VirtualKey.NavigationRight:
                    direction = FocusNavigationDirection.Right;
                    break;

                case VirtualKey.Up:
                case VirtualKey.GamepadDPadUp:
                case VirtualKey.GamepadLeftThumbstickUp:
                case VirtualKey.NavigationUp:
                    direction = FocusNavigationDirection.Up;
                    break;

                case VirtualKey.Down:
                case VirtualKey.GamepadDPadDown:
                case VirtualKey.GamepadLeftThumbstickDown:
                case VirtualKey.NavigationDown:
                    direction = FocusNavigationDirection.Down;
                    break;
            }

            if (direction != FocusNavigationDirection.None &&
                FocusManager.FindNextFocusableElement(direction) is Control control)
            {
                control.Focus(FocusState.Keyboard);
                e.Handled = true;
            }
        }

    }
}
