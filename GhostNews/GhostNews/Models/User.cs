using GhostNews.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace GhostNews.Models
{
    public class User
    {
        public string Image { get; set; }
        public Gender Gender { get; set; }
        public string UID { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public List<string> Followers { get; set; }
        public List<string> Following { get; set; }
        public List<string> Posts { get; set; }
        public List<string> BookmarkedPosts { get; set; }
    }
}
