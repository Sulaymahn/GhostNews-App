using GhostNews.Constants;
using GhostNews.Interfaces;
using GhostNews.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GhostNews.Extensions;
using Xamarin.Forms;
using Xamarin.Essentials;
using Xamarin.Forms.Xaml;
using GhostNews.Pages;

namespace GhostNews.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignInView : ContentView
    {
        IAuthentication auth;
        double _alertDefaultPosition;
        public SignInView()
        {
            InitializeComponent();
            auth = DependencyService.Get<IAuthentication>();
            _alertDefaultPosition = alert.TranslationX;
        }

        private async void OnProfileClicked(object sender, EventArgs e)
        {
            await profileFrame.ScaleTo(0.9, 100, Easing.CubicOut);

            FileResult image;
            try
            {
                image = await FilePicker.PickAsync(PickOptions.Images);

            }
            catch (Exception)
            {
                await profileFrame.ScaleTo(1, 100, Easing.CubicInOut);
                return;
            }
            await profileFrame.ScaleTo(1, 100, Easing.CubicInOut);
            profilePictureImage.Source = image.FullPath;
        }
        

        private async void OnSignIn(object sender, EventArgs e)
        {
            var checkresponse = GetValidity();
            if (!checkresponse.Item1)
            {
                ShowAlert(checkresponse.Item2, checkresponse.Item3, checkresponse.Item4);
                return;
            }

            var response = await auth.RegisterUser(emailEntry.Text, passwordEntry.Text);


            switch (response)
            {
                case SignupQueryResponse.Created:
                    DependencyService.Get<IFetcher>().ConnectToUserDatabase(auth.GetUID());
                    DependencyService.Get<IFetcher>().PostUserInfo(InitializeUser());
                    ShowAlert("User Created", "You will be returned to log in", AlertType.Progress);
                    ((AuthorizationPage)Parent.Parent).DisplayLogin();
                    break;
                case SignupQueryResponse.AlreadyExists:
                    ShowAlert("Already used Email", "This email is linked to another account", AlertType.Warning);
                    break;
                case SignupQueryResponse.InvalidEmail:
                    ShowAlert("Invalid Email", "Please type in a valid email", AlertType.Error);
                    break;
                case SignupQueryResponse.WeakPassword:
                    ShowAlert("Weak password", "password too weak", AlertType.Warning);
                    break;
            }

        }

        User InitializeUser()
        {
            return new User
            {
                FirstName = fullnameEntry.Text,
                Surname = fullnameEntry.Text,
                Email = emailEntry.Text,
                Followers = new List<string>(),
                Following = new List<string>(),
                Posts = new List<string>(),
                BookmarkedPosts = new List<string>(),
                Image = profilePictureImage.Source.ToString(),
                Username = usernameEntry.Text,
                UID = auth.GetUID(),
                Gender = Gender.Unspecified
            };
        }

        private Tuple<bool, string, string, AlertType> GetValidity()
        {
            //CHeck if all the entries are populated
            if (string.IsNullOrWhiteSpace(usernameEntry.Text) ||
                string.IsNullOrWhiteSpace(passwordEntry.Text) ||
                string.IsNullOrWhiteSpace(fullnameEntry.Text) ||
                string.IsNullOrWhiteSpace(emailEntry.Text) ||
                profilePictureImage.Source.IsEmpty)
            {
                return new Tuple<bool, string, string, AlertType>(false, "Incomplete form", "Please fill in all the forms", AlertType.Error);
            }


            //Make sure full name has enough lenght
            var names = fullnameEntry.Text.Trim().Split(' ');
            foreach (var name in names)
            {
                if (name.Length < 3) return new Tuple<bool, string, string, AlertType>(false, "Full Name Format", "Each name must be at least 3 characters", AlertType.Warning);
            }


            //Make sure full name has two seperate strings
            if (fullnameEntry.Text.Trim().Split(' ').Length != 2) return new Tuple<bool, string, string, AlertType>(false, "Full Name Format", "Please include your first and last name only", AlertType.Error);
            

            //Check if username is long enough
            if (usernameEntry.Text.Trim().Length < 4)
            {
                return new Tuple<bool, string, string, AlertType>(false, "Username too short", "Username should be at least 4 characters", AlertType.Error);
            }

            //Check if passsword obeys rules
            var obeyPasswordRules = ObeysPasswordRules();
            if (!obeyPasswordRules.Item1) return new Tuple<bool, string, string, AlertType>(false, "Password too short", "Password should be at least 8 characters", AlertType.Warning);
            if (!obeyPasswordRules.Item2) return new Tuple<bool, string, string, AlertType>(false, "Weak Password", "Please include at least 1 symbol", AlertType.Warning);
            if (!obeyPasswordRules.Item3) return new Tuple<bool, string, string, AlertType>(false, "Weak Password", "Please include at least 1 number", AlertType.Warning);
            if (!obeyPasswordRules.Item4) return new Tuple<bool, string, string, AlertType>(false, "Weak Password", "Add at least 1 uppercase", AlertType.Warning);
            if (!obeyPasswordRules.Item5) return new Tuple<bool, string, string, AlertType>(false, "Weak Password", "Come on! you need a lower case too haha", AlertType.Warning);
            

            return new Tuple<bool, string, string, AlertType>(true, "Great", "yihaaa", AlertType.Normal);
        }

        private Tuple<bool, bool, bool, bool, bool> ObeysPasswordRules()
        {
            string allowedSymbols = "!@#$%^&*()-=+=~/[]{}";

            return new Tuple<bool, bool, bool, bool, bool>(
                passwordEntry.Text.Length >= 8,
                passwordEntry.Text.Trim().ContainsAny(allowedSymbols),
                passwordEntry.Text.Trim().ContainsNumber(),
                passwordEntry.Text.Trim().ContainsUpper(),
                passwordEntry.Text.Trim().ContainsLower()
                );
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
            (Parent.Parent as AuthorizationPage).ShowPage(nameof(SignInView));
        }

        private void ChangeTheme(object sender, EventArgs e)
        {
            ((App)Application.Current).ChangeTheme();
        }
    }
}