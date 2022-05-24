using GhostNews.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GhostNews.Interfaces
{
    public interface IDatabase
    {
        List<User> Users{ get; }
        List<Article> Articles{ get; }
        void DeleteArticle(string articleID);
        void PostNewArticle(Article article);
        void UpdateArticle(Article article);
        void AddUser(User user);
        void UpdateUserData(User user);
        User GetUser(string Id);
        void DeleteUser(string user);
        void FollowUser(User caller, string targetID);
        void UnfollowUser(User caller, string targetID);
        void BookmarkPost(User caller, string articleID);
        void RemoveBookmarkPost(User caller, string articleID);
    }
}
