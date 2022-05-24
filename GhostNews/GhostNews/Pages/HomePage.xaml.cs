using GhostNews.Models;
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
    public partial class HomePage : ContentPage
    {
        double _defaultPositionX = 0;
        double _defaultPositionY = 300;
        double _hiddenPositionY = 320;
        double _hiddenPositionX = 20;

        public HomePage()
        {
            InitializeComponent();

            BindingContext = ((App)Application.Current).CurrentUser;
            var pages = new List<PageDisplay>()
            {
                new PageDisplay() { Icon = Icons.IconFont.Home, Title = "Home" },
                new PageDisplay() { Icon = Icons.IconFont.Nut, Title = "Settings" },
                new PageDisplay() { Icon = Icons.IconFont.Account, Title = "Profile" }
            };
            collection.ItemsSource = pages;
            collection.SelectedItem = pages[0];
        }

        void DisplayActive()
        {
            if (profilePage.IsEnabled)
            {
                profilePage.TranslateTo(0, 0, 100, Easing.CubicInOut);
                profilePage.ScaleTo(1, 100, Easing.CubicOut);
            }
            else
            {
                explorePage.TranslateTo(0, 0, 100, Easing.CubicInOut);
                explorePage.ScaleTo(1, 100, Easing.CubicOut);
            }

            hamburger.IsEnabled = true;
            touchDetector.InputTransparent = true;
        }

        void DisplayExplore()
        {
            profilePage.IsEnabled = false;
            profilePage.TranslateTo(_hiddenPositionX, _hiddenPositionY, 100, Easing.CubicInOut);
            profilePage.FadeTo(0, 200, Easing.CubicOut);

            explorePage.IsEnabled = true;
            explorePage.TranslateTo(_defaultPositionX, _defaultPositionY, 100, Easing.CubicInOut);
            explorePage.FadeTo(1, 200, Easing.CubicInOut);

            profilePage.InputTransparent = true;
        }
        void DisplayProfile()
        {
            explorePage.IsEnabled = false;
            explorePage.TranslateTo(_hiddenPositionX, _hiddenPositionY, 100, Easing.CubicInOut);
            explorePage.FadeTo(0, 200, Easing.CubicOut);

            profilePage.IsEnabled = true;
            profilePage.TranslateTo(_defaultPositionX, _defaultPositionY, 100, Easing.CubicInOut);
            profilePage.FadeTo(1, 200, Easing.CubicInOut);

            profilePage.InputTransparent = false;
        }

        private void collection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var option = ((PageDisplay)collection.SelectedItem).Title;
            switch (option)
            {
                case "Home":
                    DisplayExplore();
                    break;
                case "Settings":
                    ((App)App.Current).ChangeTheme();
                    break;
                case "Profile":
                default:
                    DisplayProfile();
                    break;
            }
        }

        private void ExpandView(object sender, EventArgs e)
        {
            DisplayActive();
        }

        protected override bool OnBackButtonPressed()
        {
            Hide();
            return true;
        }

        private void Hide()
        {
            if (profilePage.IsEnabled)
            {
                profilePage.TranslateTo(_defaultPositionX, _defaultPositionY, 100, Easing.CubicInOut);
                profilePage.ScaleTo(0.8, 100, Easing.CubicOut);
            }
            else
            {
                explorePage.TranslateTo(_defaultPositionX, _defaultPositionY, 100, Easing.CubicInOut);
                explorePage.ScaleTo(0.8, 100, Easing.CubicOut);
            }

            hamburger.IsEnabled = false;
            touchDetector.InputTransparent = false;
        }

        private void HideView(object sender, EventArgs e)
        {
            Hide();
        }
    }
}