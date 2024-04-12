using DevBlog.API.Data;
using DevBlog.API.Models;

namespace DevBlog.API.UseCases.Users.CreateUser
{
    public class CreateUserUseCase : UseCaseBase
    {
        public CreateUserUseCase(AppDbContext context) : base(context)
        {
        }

        public Guid? Execute(User user)
        {
            try
            {
                if (user == null) return null;

                if (string.IsNullOrEmpty(user.Name)) return null;

                this._context.users.Add(user);
                this._context.SaveChanges();

                return Guid.NewGuid();
            }
            
            catch
            {
                throw new Exception();

            }

            
        }
    }
}
