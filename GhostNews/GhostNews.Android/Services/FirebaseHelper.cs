using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase;
using Firebase.Auth;
using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GhostNews.Droid.Services
{
    public class FirebaseHelper
    {
        private static FirebaseApp app = FirebaseApp.InitializeApp(Application.Context);

        private static FirebaseApp FirebaseApp
        {
            get
            {
                if (app == null)
                {
                    var option = new FirebaseOptions.Builder()
                        .SetApplicationId("ghost-news-66e53")
                        .SetApiKey("AIzaSyAIscae0ArCtzY2tOb-Ofn3maEeX3kYY1c")
                        .SetDatabaseUrl("https://ghost-news-66e53-default-rtdb.firebaseio.com/")
                        .SetStorageBucket("ghost-news-66e53.appspot.com")
                        .Build();

                    app = FirebaseApp.InitializeApp(Application.Context, option);
                }

                return app;
            }
        }

        public static FirebaseDatabase GetDatabase()
        {
            return FirebaseDatabase.GetInstance(FirebaseApp);
        }

        public static FirebaseAuth GetAuth()
        {
            return FirebaseAuth.GetInstance(FirebaseApp);
        }
    }
}