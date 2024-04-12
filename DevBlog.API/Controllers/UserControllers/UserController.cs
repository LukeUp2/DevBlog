using DevBlog.API.Data;
using DevBlog.API.Models;
using DevBlog.API.UseCases.Users.CreateUser;
using DevBlog.API.UseCases.Users.GetAllUsers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevBlog.API.Controllers.UserControllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;
        public UserController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var useCase = new GetAllUsersUseCase(_context);

            var users = useCase.Execute();
            return Ok(users.Users);
        }

        [HttpPost]
        public IActionResult Post(User user)
        {
            var useCase = new CreateUserUseCase(_context);

            var idCreated = useCase.Execute(user);

            return Created();
        }
    }
}
