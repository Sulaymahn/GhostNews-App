using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GhostNews.Themes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DarkTheme : ResourceDictionary
    {
        public DarkTheme()
        {
            InitializeComponent();
            Add("BG", @"https://images.unsplash.com/photo-1637946175559-22c4fe13fc54?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=627&q=80");
        }
    }
}