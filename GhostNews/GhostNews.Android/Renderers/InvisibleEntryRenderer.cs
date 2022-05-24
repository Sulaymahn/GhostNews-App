using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Content;
using GhostNews.Droid.Renderers;
using GhostNews.Controls;
using Color = Android.Graphics.Color;

[assembly: ExportRenderer(typeof(InvisibleEntry), typeof(InvisibleEntryRenderer))]
namespace GhostNews.Droid.Renderers
{
    public class InvisibleEntryRenderer : EntryRenderer
    {
        public InvisibleEntryRenderer(Context context) : base(context)
        {
                
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control == null) return;

            Control.SetBackgroundColor(Color.Transparent);
            Control.SetTextCursorDrawable(Resource.Drawable.Cursor);
        }
    }
}