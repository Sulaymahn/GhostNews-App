using GhostNews.Models;
using GhostNews.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace GhostNews.Behaviours
{
    public class CarouselViewParallaxBehavior : Behavior<CarouselView>
    {
        public static readonly BindableProperty ParallaxOffsetProperty =
          BindableProperty.Create(nameof(ParallaxOffset), typeof(double), typeof(CarouselViewParallaxBehavior), 200.0d,
              BindingMode.TwoWay, null);

        public double ParallaxOffset
        {
            get { return (double)GetValue(ParallaxOffsetProperty); }
            set { SetValue(ParallaxOffsetProperty, value); }
        }

        protected override void OnAttachedTo(CarouselView bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.Scrolled += new EventHandler<ItemsViewScrolledEventArgs>(OnScrolled);
        }

        protected override void OnDetachingFrom(CarouselView bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.Scrolled -= new EventHandler<ItemsViewScrolledEventArgs>(OnScrolled);
        }

        private void OnScrolled(object sender, ItemsViewScrolledEventArgs e)
        {
            var carousel = (CarouselView)sender;
            var carouselItems = carousel.ItemsSource.Cast<CarouselItem>().ToList();
            var layout = carousel.ItemsLayout;

            if (layout is LinearItemsLayout listItemsLayout)
            {
                if (listItemsLayout.Orientation == ItemsLayoutOrientation.Horizontal)
                {
                    foreach (CarouselItem item in carouselItems)
                    {
                        item.Position = Mathx.TranslateToNewRange(0, carousel.Width * (carouselItems.IndexOf(item) + 1), -item.Ring, item.Ring, e.HorizontalOffset);
                        //item.Position = Mathx.TranslateToNewRange(0, carousel.Width * (carouselItems.IndexOf(item) + 1), -ParallaxOffset, ParallaxOffset, e.HorizontalOffset);

                        var visibleAt = carouselItems.IndexOf(item) * carousel.Width;
                        var inviscibleAt = visibleAt + (carousel.Width / 2);
                        var inviscibleAt2 = visibleAt - (carousel.Width / 2);

                        item.XOpacity = 1 - Math.Abs(Mathx.TranslateToNewRange(inviscibleAt2, inviscibleAt, -1, 1, e.HorizontalOffset));
                    }
                }

                if (listItemsLayout.Orientation == ItemsLayoutOrientation.Vertical)
                {
                    foreach (CarouselItem item in carouselItems)
                    {
                        //item.Position = Mathx.TranslateToNewRange(0, carousel.Height * (carouselItems.IndexOf(item) + 1), -item.Ring, item.Ring, e.VerticalOffset);
                        item.Position = Mathx.TranslateToNewRange(0, carousel.Height * (carouselItems.IndexOf(item) + 1), -ParallaxOffset, ParallaxOffset, e.VerticalOffset);
                        item.XOpacity = Mathx.TranslateToNewRange(0, carousel.Height * (carouselItems.IndexOf(item) + 1), 0, 1, e.VerticalOffset);
                    }
                }
            }
        }
    }
}
