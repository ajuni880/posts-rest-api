using PostsAPI.Application.DTOs;
using PostsAPI.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PostsAPI.Application.Interfaces
{
    public interface IPostService
    {
        Task<Post> GetAsync(int id);
        Task<IEnumerable<Post>> ListAsync();
        IEnumerable<Post> ListUserPosts(string userId);
        Task<int> CreateAsync(PostDto post);
        Task<Post> UpdateAsync(int id, PostDto post);
        Task DeleteAsync(int id);
    }
}
