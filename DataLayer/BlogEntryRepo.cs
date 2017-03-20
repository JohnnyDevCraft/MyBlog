using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MyBlog.Abstractions.DataLayer;
using MyBlog.Models;

namespace MyBlog.DataLayer
{
    public class BlogEntryRepo : IBlogEntryRepo
    {
        //Fields
        AppDbContext db;

        
        //Constructors
        public BlogEntryRepo(AppDbContext context)
        {
            db = context;
        }


        //Public Methods
        public BlogEntry CreateEntry(BlogEntry entry)
        {
            db.BlogEntries.Attach(entry);
            db.Entry(entry).State = EntityState.Added;
            db.SaveChanges();
            return entry;
        }

        public bool DeleteEntry(int id)
        {
            var entry = db.BlogEntries.Find(id);
            db.BlogEntries.Attach(entry);
            db.Entry(entry).State = EntityState.Deleted;
            db.SaveChanges();
            return true;
        }

        public List<BlogEntry> GetAllBlogEntries()
        {
            return db.BlogEntries.ToList();
        }

        public List<BlogEntry> GetBlogEntriesForCategory(int categoryId)
        {
            return db.BlogEntries.Where(b=>b.CategoryId == categoryId).ToList();
        }

        public BlogEntry GetBlogEntry(int id)
        {
            return db.BlogEntries.Find(id);
        }

        public List<BlogEntry> SearchBlogEntries()
        {
            throw new NotImplementedException();
        }

        public BlogEntry UpdateEntry(BlogEntry entry)
        {
            db.BlogEntries.Attach(entry);
            db.Entry<BlogEntry>(entry).State = EntityState.Modified;
            db.SaveChanges();
            return entry;
        }
    }
}