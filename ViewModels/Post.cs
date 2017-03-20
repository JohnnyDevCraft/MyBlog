using System;
using System.ComponentModel.DataAnnotations;

namespace MyBlog.ViewModels
{
    public class Post
    {
        
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Title { get; set; }

        [DataTypeAttribute(DataType.MultilineText)]
        [MaxLengthAttribute(500)]
        public string Description { get; set; }

        [DataTypeAttribute(DataType.MultilineText)]
        [RequiredAttribute]
        public string Text { get; set; }

        public string Category { get; set; }

        [DataTypeAttribute(DataType.Text)]
        public string Author { get; set; }
        public DateTime DateCreated { get; set; }
    }
}