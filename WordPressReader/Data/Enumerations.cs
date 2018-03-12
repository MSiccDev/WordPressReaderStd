using System;
using System.Collections.Generic;
using System.Text;

namespace WordPressReader.Data
{

        public enum Resource
        {
            Root = 0,
            Posts = 1,
            Pages = 2,
            Comments = 3,
            Media = 4,
            User = 5,
            Tags = 6,
            Categories = 7
        }

        public enum OrderBy
        {
            None = 0,
            Author = 1,
            Date = 2,
            Id = 3,
            Include = 4,
            Modified = 5,
            Parent = 6,
            Relevance = 7,
            Slug = 8,
            Title = 9,
            Name = 10
        }

        public enum Order
        {
            Asc = 0,
            Desc = 1
        }


        public enum MediaType
        {
            All = 0,
            Image = 1,
            Video = 2,
            Audio = 3,
            Application = 4,
        }

}
