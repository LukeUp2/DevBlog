namespace DevBlog.API.Communication.Responses
{
    public class UserResponseJson
    {
        public Guid Id { get; set; } = new Guid();
        public string Name { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
    }
}
