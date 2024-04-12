using DevBlog.API.Communication.Responses;
using DevBlog.API.Data;

namespace DevBlog.API.UseCases.Posts.GetAllUserPosts
{
    public class GetAllUserPostsUseCase : UseCaseBase
    {
        public GetAllUserPostsUseCase(AppDbContext context) : base(context)
        {
        }

        public AllUserPostsResponseJson Execute(Guid userId)
        {
            var posts = _context.posts
                .Where(p => p.AuthorId == userId && p.Deleted_At == null)
                .Select(p => new PostResponseJson 
                { 
                    Id = p.Id, 
                    Content = p.Content, 
                    Description = p.Description, 
                    Title = p.Title,
                    Posted_At = p.Posted_At,
                    Updated_At = p.Updated_At
                })
                .ToList();

            return new AllUserPostsResponseJson
            {
                AllPosts = posts
            };
        }
    }
}
