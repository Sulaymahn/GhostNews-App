using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using GhostNews.Droid.Implementations;
using GhostNews.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Application = Android.App.Application;

[assembly: Dependency(typeof(DeviceConfig))]
namespace GhostNews.Droid.Implementations
{
    public class DeviceConfig : IDeviceConfig
    {
        public void SetStatusBarColor(Color color)
        {
            Window window = Xamarin.Essentials.Platform.CurrentActivity.Window;
            window.SetStatusBarColor(Android.Graphics.Color.ParseColor(color.ToHex()));
        }
    }
}