using PostsAPI.Domain.Entities;
using PostsAPI.Domain.Interfaces.Repos;
using PostsAPI.Infrastructure.Persistence;
using System.Collections.Generic;
using System.Linq;

namespace PostsAPI.Infrastructure.Repos
{
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        public PostRepository(ApplicationDbContext context)
            : base(context)
        { }

        public IEnumerable<Post> ListUserPosts(string userId)
        {
            return _context.Posts.Where(p => p.CreatedBy == userId).ToList();
        }
    }
}
