using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PostsAPI.Application.DTOs;
using PostsAPI.Application.Interfaces;
using PostsAPI.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PostsAPI.Web.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostsController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public IEnumerable<Post> GetUserPosts()
        {
            return _postService.ListUserPosts();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetPost(int id)
        {
            var post = await _postService.GetAsync(id);
            if (post == null)
                return NotFound(null);
            return Ok(post);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PostDto postDto)
        {
            var id = await _postService.CreateAsync(postDto);
            return CreatedAtAction(nameof(GetPost), new { id }, null);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Post>> Update([FromBody] PostDto postDto, int id)
        {
            if (id != postDto.Id)
                return BadRequest();

            var post = await _postService.UpdateAsync(id, postDto);
            return Ok(post);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _postService.DeleteAsync(id);
            return NoContent();
        }
    }
}
