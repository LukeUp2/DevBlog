using DevBlog.API.Communication.Requests;
using DevBlog.API.Data;
using DevBlog.API.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace DevBlog.API.UseCases.Posts.UpdatePost
{
    public class UpdatePostUseCase : UseCaseBase
    {
        public UpdatePostUseCase(AppDbContext context) : base(context)
        {
        }

        public void Execute(int postId, JsonPatchDocument postData)
        {
            var post = _context.posts.FirstOrDefault(p => p.Id == postId && p.Deleted_At == null);

            if (post == null)
            {
                throw new Exception("Not Found");
            }

            post.Updated_At = DateTime.Now;
            postData.ApplyTo(post);
            _context.SaveChanges();
        }
    }
}
