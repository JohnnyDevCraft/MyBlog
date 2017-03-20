namespace MyBlog.Abstractions.DataLayer
{
    public interface IRepoFactory
    {
        IBlogEntryRepo GetBlogEntryRepo();
        ICategoryRepo  GetCategoryRepo();
    }
}