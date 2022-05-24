using GhostNews.Interfaces;
using GhostNews.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;

namespace GhostNews.Pages
{
    public partial class GettingStartedPage : ContentPage
    {
        public GettingStartedPage()
        {
            InitializeComponent();

            var Menus = new ObservableCollection<CarouselItem>();
            Menus.Add(new CarouselItem
            {
                Title = "News wherever you are in realtime",
                ButtonText = "Swipe left",
                Ring = 80,
                Paragraph = "Get started with wareva this is just to populate this text with small write up",
                Image = @"https://images.unsplash.com/photo-1584931423298-c576fda54bd2?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1170&q=80"
            });
            Menus.Add(new CarouselItem
            {
                Title = "Read your favorite articles",
                ButtonText = "Swipe left again, son",
                Ring = 130,
                Paragraph = "Get started with wareva this is just to populate this text with small write up",
                Image = @"https://images.unsplash.com/photo-1557428894-56bcc97113fe?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=736&q=80"
            });
            Menus.Add(new CarouselItem
            {
                Title = "Stay updated",
                ButtonText = "press skip below",
                Ring = 130,
                Paragraph = "Get started with wareva this is just to populate this text with small write up",
                Image = @"https://images.unsplash.com/photo-1503428593586-e225b39bddfe?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1170&q=80"
            });
            car.ItemsSource = Menus;
        }


        private void OnSkip(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new AuthorizationPage(), false);
        }
    }
}
