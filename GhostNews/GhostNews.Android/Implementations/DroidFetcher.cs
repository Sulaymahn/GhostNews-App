using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase.Database;
using GhostNews.CustomEvents;
using GhostNews.Droid.Implementations;
using GhostNews.Droid.Services;
using GhostNews.Interfaces;
using GhostNews.Models;
using Java.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

[assembly: Dependency(typeof(DroidFetcher))]
namespace GhostNews.Droid.Implementations
{
    public class DroidFetcher : IFetcher
    {
        private DatabaseReference Reference;

        public event EventHandler<FetcherEventArgs> DataChanged;
        public void ConnectToUserDatabase(string uid)
        {
            Reference = FirebaseHelper.GetDatabase().GetReference(uid);
            Reference.AddValueEventListener(new DataListener(this));
        }

        public async void PostUserInfo(User user)
        {
            string content = JsonConvert.SerializeObject(user);
            HashMap usermap = new HashMap();
            usermap.Put("json", content);
            await Reference.SetValueAsync(usermap);
        }

        public class DataListener : Java.Lang.Object, IValueEventListener
        {
            DroidFetcher droidFirebase;

            public DataListener(DroidFetcher database)
            {
                droidFirebase = database;
            }

            public void OnCancelled(DatabaseError error)
            {
            }

            public void OnDataChange(DataSnapshot snapshot)
            {
                if (snapshot.Value != null)
                {
                    User user = JsonConvert.DeserializeObject<User>(snapshot.Child("json").Value.ToString());
                    droidFirebase.DataChanged?.Invoke(this, new FetcherEventArgs() { User = user });
                }
            }
        }

    }
}