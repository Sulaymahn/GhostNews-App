using GhostNews.Interfaces;
using GhostNews.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using GhostNews.Constants;
using GhostNews.Utilities;

namespace GhostNews.MockData
{
    public class MockDataSource : IDatabase
    {
        public List<User> Users { get; set; }
        public List<Article> Articles { get; set; }
        private List<string> ImagePool { get; set; }

        public MockDataSource()
        {
            InitializeImagePool();
            InitializeUsers(20);
            GenerateRandomPosts(50);
        }
        private void InitializeImagePool()
        {
            ImagePool = new List<string>();

            ImagePool.Add(@"https://images.unsplash.com/photo-1534528741775-53994a69daeb?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=764&q=80");
            ImagePool.Add(@"https://images.unsplash.com/photo-1522196772883-393d879eb14d?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=985&q=80");
            ImagePool.Add(@"https://images.unsplash.com/photo-1542685295-b280fd4d2c59?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=687&q=80");
            ImagePool.Add(@"https://images.unsplash.com/photo-1520974735194-9e0ce82759fc?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=687&q=80");
            ImagePool.Add(@"https://images.unsplash.com/photo-1618979251882-0b40ef3617f0?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=687&q=80");
            ImagePool.Add(@"https://images.unsplash.com/photo-1603415526960-f7e0328c63b1?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1170&q=80");
            ImagePool.Add(@"https://images.unsplash.com/photo-1535713875002-d1d0cf377fde?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=880&q=80");
            ImagePool.Add(@"https://images.unsplash.com/photo-1527203561188-dae1bc1a417f?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=715&q=80");
            ImagePool.Add(@"https://images.unsplash.com/photo-1592520113018-180c8bc831c9?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=687&q=80");
            ImagePool.Add(@"https://images.unsplash.com/photo-1459245330819-1b6d75fbaa35?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1170&q=80");
        }
        private void GenerateRandomPosts(int count)
        {
            Articles = new List<Article>();

            var rnd = new Random();

            for (int i = 0; i < count; i++)
            {
                var article = new Article
                {
                    Category = GetRandomCategory(),
                    DatePosted = new DateTime(rnd.Next(2000, 2023), rnd.Next(1, 13), rnd.Next(1, 29)),
                    EstimatedReadTime = rnd.Next(1, 30),
                    ID = StringMaker.GenerateID(),
                    Image = SelectRandomImage(),
                    ImageCaption = StringMaker.GenerateID(),
                    Paragraphs = GetParagraph(),
                    ReadCount = rnd.Next(0, 2000),
                    Title = StringMaker.RandomTitle()
                };

                var user = Users[rnd.Next(0, Users.Count)];
                article.AuthorID = user.UID;
                user.Posts.Add(article.ID);

                Articles.Add(article);
            }

        }
        private string GetRandomUserId()
        {
            var rnd = new Random();
            return Users[rnd.Next(0, Users.Count())].UID;
        }
        private List<string> GetParagraph()
        {
            return new List<string>
            {
                "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like)."
            };
        }
        private void InitializeUsers(int count)
        {
            Users = new List<User>();

            for (int i = 0; i < count; i++)
            {
                var user = new User
                {
                    FirstName = StringMaker.RandomName(),
                    Surname = StringMaker.RandomMaleName(),
                    Email = "",
                    Followers = new List<string>(),
                    Following = new List<string>(),
                    Posts = new List<string>(),
                    BookmarkedPosts = new List<string>(),
                    Image = SelectRandomImage(),
                    UID = StringMaker.GenerateID()
                };

                user.Gender = StringMaker.ParseName(user.FirstName);
                user.Username = StringMaker.MakeUsername(user.FirstName, user.Surname);

                Users.Add(user);
            }
        }
        private string SelectRandomImage()
        {
            Random rnd = new Random();
            return ImagePool[rnd.Next(0, ImagePool.Count)];
        }
        private PostCategory GetRandomCategory()
        {
            var rnd = new Random();

            int result = rnd.Next(0, Enum.GetNames(typeof(PostCategory)).Length);
            string name = Enum.GetNames(typeof(PostCategory))[result];

            return (PostCategory)Enum.Parse(typeof(PostCategory), name);
        }

        #region Interface Implementation
        public void AddUser(User user)
        {
            if (!Users.Contains(user)) Users.Add(user);
        }
        public void BookmarkPost(User caller, string articleID)
        {
            Users.Where((x) => x.UID == caller.UID).FirstOrDefault().BookmarkedPosts.Add(articleID);
        }
        public void DeleteArticle(string articleID)
        {
            Articles.Remove(Articles.Where((x) => x.ID == articleID).FirstOrDefault());
        }
        public void DeleteUser(string user)
        {
            Users.Remove(Users.Where((x) => x.UID == user).FirstOrDefault());
        }
        public void FollowUser(User caller, string targetID)
        {
            Users.Where((x) => x.UID == caller.UID).FirstOrDefault().Following.Add(targetID);
        }
        public User GetUser(string Id)
        {
            return Users.Where((x) => x.UID == Id).FirstOrDefault();
        }
        public void PostNewArticle(Article article)
        {
            Articles.Add(article);
        }
        public void UnfollowUser(User caller, string targetID)
        {
            Users.Where((x) => x.UID == caller.UID).FirstOrDefault().Followers.Remove(targetID);
        }
        public void UpdateArticle(Article article)
        {
            Articles.Remove(Articles.Where((x) => x.ID == article.ID).FirstOrDefault());
            Articles.Add(article);
        }
        public void UpdateUserData(User user)
        {
            Users.Remove(Users.Where((x) => x.UID == user.UID).FirstOrDefault());
            Users.Add(user);
        }
        public void RemoveBookmarkPost(User caller, string articleID)
        {
            Users.Where((x) => x.UID == caller.UID).FirstOrDefault().BookmarkedPosts.Remove(articleID);
        }
        #endregion
    }
}
