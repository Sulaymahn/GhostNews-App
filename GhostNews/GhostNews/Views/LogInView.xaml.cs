using GhostNews.Constants;
using GhostNews.Extensions;
using GhostNews.Interfaces;
using GhostNews.Models;
using GhostNews.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GhostNews.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LogInView : ContentView
    {
        IAuthentication auth;
        IFetcher fetcher;
        double _alertDefaultPosition;
        public User RegisteredUser { get; private set; }

        public LogInView()
        {
            InitializeComponent();
            fetcher = DependencyService.Get<IFetcher>();
            fetcher.DataChanged += LogInView_DataChanged;
            auth = DependencyService.Get<IAuthentication>();
            _alertDefaultPosition = alert.TranslationX;
        }

        private void LogInView_DataChanged(object sender, CustomEvents.FetcherEventArgs e)
        {
            e.User = RegisteredUser;
        }

        private async void OnSignIn(object sender, EventArgs e)
        {
            var checkresponse = GetValidity();
            if (!checkresponse.Item1)
            {
                ShowAlert(checkresponse.Item2, checkresponse.Item3, checkresponse.Item4);
                return;
            }

            var response = await auth.LoginWithEmailAndPassword(emailEntry.Text, passwordEntry.Text);


            switch (response)
            {
                case LoginQueryResponse.LoggedIn:
                    ShowAlert("Log in success", "Welcome back", AlertType.Progress);
                    //fetcher.ConnectToUserDatabase(auth.GetUID());
                    //((App)App.Current).CurrentUser = RegisteredUser;
                    await Navigation.PushModalAsync(new HomePage(), false);
                    break;
                case LoginQueryResponse.InvalidEmail:
                    ShowAlert("Email not found", "This email is not linked to an account", AlertType.Warning);
                    break;
                case LoginQueryResponse.WrongPassword:
                    ShowAlert("Invalid Email or Password", "Please recheck the inputs", AlertType.Error);
                    break;
            }

        }

        void InitializeUser()
        {
            User user = new User
            {
                FirstName = "",
                Surname = "",
                Email = emailEntry.Text,
                Followers = new List<string> (),
                Following = new List<string>(),
                Posts = new List<string>(),
                BookmarkedPosts = new List<string>(),
                Image = "",
                Username = "",
                UID = auth.GetUID(),
                Gender = Gender.Unspecified
            };
        }

        private Tuple<bool, string, string, AlertType> GetValidity()
        {
            //CHeck if all the entries are populated
            if (string.IsNullOrWhiteSpace(emailEntry.Text) ||
                string.IsNullOrWhiteSpace(passwordEntry.Text))
            {
                return new Tuple<bool, string, string, AlertType>(false, "Incomplete form", "Please fill in all the forms", AlertType.Error);
            }

            //Check if passsword obeys rules
            if (passwordEntry.Text.Length < 8) return new Tuple<bool, string, string, AlertType>(false, "Password too short", "Password should be at least 8 characters", AlertType.Warning);

            return new Tuple<bool, string, string, AlertType>(true, "Great", "yihaaa", AlertType.Normal);
        }

        private async void ShowAlert(string title, string message, AlertType alerttype)
        {
            if (alert.TranslationX != _alertDefaultPosition) return;

            alertTitle.Text = title;

            switch (alerttype)
            {
                case AlertType.Progress:
                    alert.BackgroundColor = Color.ForestGreen;
                    break;
                case AlertType.Warning:
                    alert.BackgroundColor = Color.Orange;
                    break;
                case AlertType.Error:
                    alert.BackgroundColor = Color.Crimson;
                    break;
                case AlertType.Normal:
                default:
                    alert.BackgroundColor = Color.Accent;
                    break;
            }

            alertMessage.Text = message;
            await alert.TranslateTo(0, 0, 250, Easing.CubicOut);
            await Task.Delay(1500);

            await alert.TranslateTo(_alertDefaultPosition, 0, 250, Easing.CubicInOut);
        }

        private void OnBack(object sender, EventArgs e)
        {
            (Parent.Parent as AuthorizationPage).ShowPage(nameof(LogInView));
        }

        private void ChangeTheme(object sender, EventArgs e)
        {
            ((App)Application.Current).ChangeTheme();
        }
    }
}