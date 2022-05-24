using GhostNews.Interfaces;
using GhostNews.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GhostNews.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AuthorizationPage : ContentPage
    {
        public AuthorizationPage()
        {
            InitializeComponent();

            signView.IsEnabled = false;
            signView.InputTransparent = true;
            signView.Opacity = 0;
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }

        public void ShowPage(string data)
        {
            switch (data)
            {
                case nameof(SignInView):
                    DisplayLogin();
                    break;
                case nameof(LogInView):
                    DisplaySignIn();
                    break;
                default:
                    return;

            }
        }
        public async void DisplaySignIn()
        {
            logView.IsEnabled = false;
            await logView.FadeTo(0, 200, Easing.CubicOut);

            signView.IsEnabled = true;
            await signView.FadeTo(1, 200, Easing.CubicInOut);
            signView.InputTransparent = false;
        }
        public async void DisplayLogin()
        {
            signView.IsEnabled = false;
            signView.InputTransparent = true;
            await signView.FadeTo(0, 200, Easing.CubicOut);

            logView.IsEnabled = true;
            await logView.FadeTo(1, 200, Easing.CubicInOut);
        }
    }
}