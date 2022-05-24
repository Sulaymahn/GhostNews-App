using GhostNews.Constants;
using GhostNews.Interfaces;
using GhostNews.MockData;
using GhostNews.Models;
using GhostNews.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GhostNews.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExploreView : ContentView
    {
        IDatabase db;

        public List<Article> HotTopics
        {
            get => db.Articles.Where((article) => article.Category == PostCategory.HotIssue).ToList();
        }

        public List<Article> ForYou
        {
            get => db.Articles.Where((article) => article.Category == PostCategory.Healthy).ToList();
    }

        public List<string> Categories
        {
            get => Enum.GetNames(typeof(PostCategory)).ToList();
        }

        public ExploreView()
        {
            db = new MockDataSource();
            BindingContext = this;
            InitializeComponent();
            hottopiclabel.Text = HotTopics[htcarouselView.Position].Title;
            htcarouselView.PositionChanged += HtcarouselView_PositionChanged;
        }

        private void HtcarouselView_PositionChanged(object sender, PositionChangedEventArgs e)
        {
            hottopiclabel.Text = HotTopics[e.CurrentPosition].Title;
        }

        private void OnArticleSelected(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.FirstOrDefault() == null) return;
            var article = (Article)e.CurrentSelection.First();
            if (article != null) Navigation.PushModalAsync(new ArticleDetailPage(article), false);
            ((CollectionView)sender).SelectedItem = null;
        }
    }
}