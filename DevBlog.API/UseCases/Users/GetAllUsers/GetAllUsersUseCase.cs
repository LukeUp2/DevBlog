using DevBlog.API.Communication.Responses;
using DevBlog.API.Data;
using DevBlog.API.Models;

namespace DevBlog.API.UseCases.Users.GetAllUsers
{
    public class GetAllUsersUseCase : UseCaseBase
    {
        public GetAllUsersUseCase(AppDbContext context) : base(context)
        {
        }

        public UsersGetAllResponseJson Execute()
        {
            var users = this._context.users.Select(u => new UserResponseJson() { Id = u.Id, Name = u.Name, Email = u.Email }).ToList();

            return new UsersGetAllResponseJson
            {
                Users = users
            };
        }
    }
}
