using PostsAPI.Domain.Entities;
using System.Collections.Generic;

namespace PostsAPI.Domain.Interfaces.Repos
{
    public interface IPostRepository : IBaseRepository<Post>
    {
        IEnumerable<Post> ListUserPosts(string userId);
    }
}
