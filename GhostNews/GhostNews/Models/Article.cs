using GhostNews.Constants;
using System;
using System.Collections.Generic;

namespace GhostNews.Models
{
    public class Article
    {
        public string ID { get; set; }
        public string Image { get; set; }
        public string ImageCaption { get; set; }
        public int EstimatedReadTime { get; set; }
        public int ReadCount { get; set; }
        public string Title { get; set; }
        public string AuthorID { get; set; }
        public List<string> Paragraphs { get; set; }
        public PostCategory Category { get; set; }
        public DateTime DatePosted { get; set; }
    }
}
