using DevBlog.API.Data;
using Microsoft.AspNetCore.Http.HttpResults;

namespace DevBlog.API.UseCases.Posts.DeletePost
{
    public class DeletePostUseCase : UseCaseBase
    {
        public DeletePostUseCase(AppDbContext context) : base(context)
        {
        }

        public int Execute(int postId)
        {
            //Colocar verif para saber se esse post ja n foi deletado
            var post = _context.posts.FirstOrDefault(p => p.Id == postId);

            if (post == null)
            {
                throw new Exception("Not Found");
            }

            post.Deleted_At = DateTime.Now;
            _context.SaveChanges();

            return postId;
        }
    }
}
