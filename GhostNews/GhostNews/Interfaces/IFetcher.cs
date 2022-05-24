using GhostNews.CustomEvents;
using GhostNews.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GhostNews.Interfaces
{
    public interface IFetcher
    {
        event EventHandler<FetcherEventArgs> DataChanged;
        void ConnectToUserDatabase(string uid);
        void PostUserInfo(User user);
    }
}
