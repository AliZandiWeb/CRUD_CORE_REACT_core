using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace ASPNetServer.Data
{
    internal static class PostRepository
    {
        internal static async Task<List<Post>> GetPostsAsync()
        {
            using (var db = new AppDBContext())
            {
                return await db.Posts.ToListAsync();
            }
        }
        internal static async Task<Post> GetByIdAsync(int id)
        {
            using (var db = new AppDBContext())
            {
                return await db.Posts.FirstOrDefaultAsync(x => x.Id == id);
            }
        }
        internal static async Task<bool> CreatePostAsync(Post model)
        {
            using (var db = new AppDBContext())
            {
                try
                {
                    await db.Posts.AddAsync(model);
                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
        internal static async Task<bool> UpdatePostAsync(Post model)
        {
            using (var db = new AppDBContext())
            {
                try
                {
                    db.Posts.Update(model);
                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
        internal static async Task<bool> DeletePostAsync(int id)
        {
            using (var db = new AppDBContext())
            {
                try
                {
                    Post post = await GetByIdAsync(id);
                    db.Posts.Remove(post);
                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
    }
}
