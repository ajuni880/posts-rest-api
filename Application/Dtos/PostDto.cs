using System.ComponentModel.DataAnnotations;

namespace PostsAPI.Application.DTOs
{
    public class PostDto
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Body { get; set; }
    }
}
