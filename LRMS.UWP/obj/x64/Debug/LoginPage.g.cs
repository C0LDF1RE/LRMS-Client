﻿#pragma checksum "C:\Users\COLDFIRE\source\repos\LRMS.UWP\LoginPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "9BB74CA11688378EFBAB11F146124147"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LRMS.UWP
{
    partial class LoginPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1: // LoginPage.xaml line 1
                {
                    global::Windows.UI.Xaml.Controls.Page element1 = (global::Windows.UI.Xaml.Controls.Page)(target);
                    ((global::Windows.UI.Xaml.Controls.Page)element1).Loading += this.Page_Loading;
                }
                break;
            case 2: // LoginPage.xaml line 13
                {
                    this.BackgroundPic = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 3: // LoginPage.xaml line 67
                {
                    this.LoginProgressRing = (global::Windows.UI.Xaml.Controls.ProgressRing)(target);
                }
                break;
            case 4: // LoginPage.xaml line 57
                {
                    global::Windows.UI.Xaml.Shapes.Ellipse element4 = (global::Windows.UI.Xaml.Shapes.Ellipse)(target);
                    ((global::Windows.UI.Xaml.Shapes.Ellipse)element4).Tapped += this.Ellipse_Tapped;
                }
                break;
            case 5: // LoginPage.xaml line 35
                {
                    this.UsernameBox = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 6: // LoginPage.xaml line 41
                {
                    this.PasswordBox = (global::Windows.UI.Xaml.Controls.PasswordBox)(target);
                    ((global::Windows.UI.Xaml.Controls.PasswordBox)this.PasswordBox).PasswordChanged += this.PasswordBox_OnChanged;
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

