using DevBlog.API.Data;

namespace DevBlog.API.UseCases
{
    public class UseCaseBase
    {
        protected readonly AppDbContext _context;
        public UseCaseBase(AppDbContext context)
        {
            _context = context;
        }
    }
}
