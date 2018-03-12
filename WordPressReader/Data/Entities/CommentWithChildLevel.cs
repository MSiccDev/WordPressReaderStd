using System;
using System.Collections.Generic;
using System.Text;

namespace WordPressReader.Data.Entities
{
    public class CommentWithChildLevel : Comment
    {
        public CommentWithChildLevel(Comment comment)
        {
            this.Parent = comment.Parent;
            this.Author = comment.Author;
            this.AuthorName = comment.AuthorName;
            this.AuthorUrl = comment.AuthorUrl;
            this.Content = comment.Content;
            this.Date = comment.Date;
            this.DateGmt = comment.DateGmt;
            this.Id = comment.Id;
            this.Link = comment.Link;
            this.Links = comment.Links;
            this.Meta = comment.Meta;
            this.Post = comment.Post;
            this.Status = comment.Status;
            this.Type = comment.Type;
            this.UserAvatarUrls = comment.UserAvatarUrls;
        }

        public int ChildLevel { get; set; } = 0;
    }
}
