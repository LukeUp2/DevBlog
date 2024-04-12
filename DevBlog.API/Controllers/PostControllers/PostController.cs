using DevBlog.API.Communication.Requests;
using DevBlog.API.Data;
using DevBlog.API.Models;
using DevBlog.API.UseCases.Posts.CreatePost;
using DevBlog.API.UseCases.Posts.DeletePost;
using DevBlog.API.UseCases.Posts.GetAllPosts;
using DevBlog.API.UseCases.Posts.UpdatePost;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace DevBlog.API.Controllers.PostControllers
{
    [Route("api/posts")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PostController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var useCase = new GetAllPostsUseCase(_context);
            var posts = useCase.Execute();

            return Ok(posts);
        }

        [HttpGet]
        [Route("{userId}")]
        public IActionResult GetUserPosts([FromRoute]Guid userId)
        {
            var useCase = new GetAllPostsUseCase(_context);
            var posts = useCase.Execute();

            return Ok(posts);
        }

        [HttpPost]
        [Route("{userId}")]
        public IActionResult Post([FromRoute] Guid userId,[FromBody] PostCreateRequestJson post)
        { 
            var useCase = new CreatePostUseCase(_context);

            var response = useCase.Execute(userId,post);

            return Created(string.Empty, response);
        }

        [HttpPatch]
        [Route("{postId}")]
        public IActionResult Update([FromRoute] int postId, JsonPatchDocument patchDocument)
        {
            var useCase = new UpdatePostUseCase(_context);
            useCase.Execute(postId, patchDocument);  

            return Ok();
        }

        [HttpDelete]
        [Route("{postId}")]
        public IActionResult Delete([FromRoute] int postId)
        {
            var useCase = new DeletePostUseCase(_context);
            var postDeleted = useCase.Execute(postId);
            return Ok(postDeleted);
        }

    }
}
