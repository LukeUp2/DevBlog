using DevBlog.API.Communication.Responses;
using DevBlog.API.Data;
using DevBlog.API.Models;

namespace DevBlog.API.UseCases.Posts.GetAllPosts
{
    public class GetAllPostsUseCase : UseCaseBase
    {
        public GetAllPostsUseCase(AppDbContext context) : base(context)
        {
        }
        public AllPostsResponse Execute()
        {
            var posts = this._context.posts
                .Where(p => p.Deleted_At == null)
                .Select(p => new PostResponseJson
                {
                    Updated_At = p.Updated_At,
                    Content = p.Content,
                    Description = p.Description,
                    Id = p.Id,
                    Posted_At = p.Posted_At,
                    Title = p.Title
                })
                .ToList();

            var response = new AllPostsResponse
            {
                AllPosts = posts
            };

            return response;
        }
    }
}
