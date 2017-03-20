using MyBlog.Models;
using System.Collections.Generic;
namespace MyBlog.Abstractions.DataLayer
{
    public interface IBlogEntryRepo
    {
        BlogEntry GetBlogEntry(int id);
        List<BlogEntry> GetAllBlogEntries();
        List<BlogEntry> SearchBlogEntries();
        List<BlogEntry> GetBlogEntriesForCategory(int categoryId);

        BlogEntry CreateEntry(BlogEntry entry);
        BlogEntry UpdateEntry(BlogEntry entry);
        bool DeleteEntry(int id);
    }
}