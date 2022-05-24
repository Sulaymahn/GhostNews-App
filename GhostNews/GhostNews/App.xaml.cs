using GhostNews.Interfaces;
using GhostNews.MockData;
using GhostNews.Models;
using GhostNews.Pages;
using GhostNews.Themes;
using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GhostNews
{
    public partial class App : Application
    {
        public MockDataSource DataSource { get; set; } = new MockDataSource();
        public User CurrentUser { get; set; }

        public App()
        {
            DependencyService.Get<IDeviceConfig>().SetStatusBarColor(Color.FromHex("#1C5D50"));
            InitializeComponent();
            CurrentUser = DataSource.Users[new Random().Next(0, DataSource.Users.Count)];

            Resources.MergedDictionaries.Add(new DarkTheme());

            //MainPage = new HomePage();
            //MainPage = new AuthorizationPage();
            MainPage = new GettingStartedPage();
        }

        public void ChangeTheme()
        {
            var mergedDictionaries = Current.Resources.MergedDictionaries;
            bool isDark = mergedDictionaries.First().GetType().Name.Contains("Dark");


            if (mergedDictionaries != null)
            {
                mergedDictionaries.Clear();

                if (isDark) { 
                    mergedDictionaries.Add(new LightTheme());
                    DependencyService.Get<IDeviceConfig>().SetStatusBarColor(Color.FromHex("#1C5D50"));
                }
                else { 
                    mergedDictionaries.Add(new DarkTheme());
                    DependencyService.Get<IDeviceConfig>().SetStatusBarColor(Color.FromHex("#111"));
                }
            }

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
