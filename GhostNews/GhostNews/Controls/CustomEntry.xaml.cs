using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GhostNews.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomEntry : Frame
    {
        public static readonly BindableProperty TextProperty = BindableProperty.Create("Text", typeof(string), typeof(CustomEntry));
        public static readonly BindableProperty IconProperty = BindableProperty.Create("Icon", typeof(string), typeof(CustomEntry));
        public static readonly BindableProperty PlaceholderTextProperty = BindableProperty.Create("PlaceholderText", typeof(string), typeof(CustomEntry));
        public static readonly BindableProperty IsPasswordProperty = BindableProperty.Create("IsPassword", typeof(bool), typeof(CustomEntry));
        public static readonly BindableProperty KeyboardProperty = BindableProperty.Create("Keyboard", typeof(Keyboard), typeof(CustomEntry));
        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }
        public string Icon
        {
            get => (string)GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }
        public string PlaceholderText
        {
            get => (string)GetValue(PlaceholderTextProperty);
            set => SetValue(PlaceholderTextProperty, value);
        }
        public bool IsPassword
        {
            get => (bool)GetValue(IsPasswordProperty);
            set => SetValue(IsPasswordProperty, value);
        }
        public Keyboard Keyboard
        {
            get => (Keyboard)GetValue(KeyboardProperty);
            set => SetValue(KeyboardProperty, value);
        }

        public CustomEntry()
        {
            InitializeComponent();
            BindingContext = this;
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {

        }
    }
}