using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBlog.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        
        
        [InverseProperty("Category")]
        public List<BlogEntry> Entries { get; set; }
        
    }
}