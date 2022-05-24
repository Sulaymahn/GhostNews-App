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
    public partial class ArticleDetailPage : ContentPage
    {
        public Article Article { get; set; }
        public ArticleDetailPage(Article article)
        {
            InitializeComponent();
            Article = article;
            BindingContext = Article;
        }

        protected override bool OnBackButtonPressed()
        {
            Navigation.PopModalAsync(false);
            return true;
        }
    }
}