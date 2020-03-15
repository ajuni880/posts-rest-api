using PostsAPI.Application.DTOs;
using PostsAPI.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PostsAPI.Application.Interfaces
{
    public interface IPostService
    {
        Task<Post> GetAsync(int id);
        IEnumerable<Post> ListUserPosts();
        Task<int> CreateAsync(PostDto post);
        Task<Post> UpdateAsync(int id, PostDto post);
        Task DeleteAsync(int id);
    }
}
