using GhostNews.Models;
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
    public partial class ArticlePreview : ContentView
    {
        public static readonly BindableProperty ArticleProperty = BindableProperty.Create("Article", typeof(Article), typeof(ArticlePreview));
        public Article Article
        {
            get => (Article)GetValue(ArticleProperty);
            set => SetValue(ArticleProperty, value);
        }

        public ArticlePreview()
        {
            InitializeComponent();
            BindingContext = Article;
        }
    }
}