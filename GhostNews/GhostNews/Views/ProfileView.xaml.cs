using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using GhostNews.Models;
using GhostNews.Pages;

namespace GhostNews.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfileView : ContentView
    {
        public User User { get; set; }
        public ProfileView()
        {
            InitializeComponent();
            User = ((App)Application.Current).CurrentUser;
            BindingContext = User;
            fromYou.ItemsSource = GetPopularArticles();
            recent.ItemsSource = GetArticles();
        }

        private IEnumerable<Article> GetPopularArticles()
        {
            return ((App)Application.Current).DataSource.Articles.Where((article) => article.AuthorID == User.UID);
        }

        private IEnumerable<Article> GetArticles()
        {
            return ((App)Application.Current).DataSource.Articles.Where((article) => article.AuthorID == User.UID);
        }

        private void OnSelectArticle(object sender, SelectionChangedEventArgs e)
        {

            if (e.CurrentSelection.FirstOrDefault() == null) return;
            var article = (Article)e.CurrentSelection.First();
            if (article != null) Navigation.PushModalAsync(new ArticleDetailPage(article), false);
            ((CollectionView)sender).SelectedItem = null;
        }
    }
}