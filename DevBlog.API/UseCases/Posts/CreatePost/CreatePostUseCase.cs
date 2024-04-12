using DevBlog.API.Communication.Requests;
using DevBlog.API.Communication.Responses;
using DevBlog.API.Data;
using DevBlog.API.Models;

namespace DevBlog.API.UseCases.Posts.CreatePost
{
    public class CreatePostUseCase : UseCaseBase
    {
        public CreatePostUseCase(AppDbContext context) : base(context)
        {
        }

        public PostCreatedResponseJson Execute(Guid userId, PostCreateRequestJson post)
        {

            var entity = new Post
            {
                Title = post.Title,
                Description = post.Description,
                Content = post.Content,
                AuthorId = userId,
            };

            _context.posts.Add(entity);
            _context.SaveChanges();

            return new PostCreatedResponseJson
            {
                Id = entity.Id
            };
        }
    }
}
