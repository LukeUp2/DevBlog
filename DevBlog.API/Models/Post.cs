using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DevBlog.API.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime Posted_At { get; set; } = DateTime.Now;
        public DateTime Updated_At { get; set; } = DateTime.Now;
        public DateTime? Deleted_At { get; set; } = null;
        public Guid AuthorId { get; set; }
        public User? Author { get; set; }
    }
}
