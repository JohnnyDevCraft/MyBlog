using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBlog.Models
{
    public class BlogEntry
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        public string Text { get; set; }

        
        //ForeignKeys
        public int CategoryId { get; set; }
        
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        //Who Fields
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime DateLastmodified { get; set; }

    }
}