using Microsoft.EntityFrameworkCore;
using MyBlog.Abstractions.DataLayer;
using MySQL.Data.EntityFrameworkCore.Extensions;
using Microsoft.EntityFrameworkCore.Extensions;

namespace MyBlog.DataLayer
{
    class RepoFactory : IRepoFactory
    {
        static IBlogEntryRepo blogEntryRepo;
        static ICategoryRepo categoryRepo;
        AppDbContext db;

        public static string Conn{get; set;}

        public RepoFactory()
        {     
            var builder = new DbContextOptionsBuilder<AppDbContext>();
            builder.UseSqlite(Conn);       
            db = new AppDbContext(builder.Options);
        }
        public IBlogEntryRepo GetBlogEntryRepo()
        {
            if(blogEntryRepo == null){
                blogEntryRepo = new BlogEntryRepo(db);
            }
            return blogEntryRepo;
        }

        public ICategoryRepo GetCategoryRepo()
        {
            if(categoryRepo == null){
                categoryRepo = new CategoryRepo(db);
            }
            return categoryRepo;
        }
    }
}