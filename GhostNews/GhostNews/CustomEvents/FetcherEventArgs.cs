using GhostNews.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GhostNews.CustomEvents
{
    public class FetcherEventArgs : EventArgs
    {
        public User User { get; set; }
    }
}
