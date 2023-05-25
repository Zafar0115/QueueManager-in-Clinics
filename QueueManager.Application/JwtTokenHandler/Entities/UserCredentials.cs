namespace QueueManager.Application.JwtTokenHandler.Entities
{
    public class UserCredentials
    {
        public required string UserName { get; set; }
        public required string Password { get; set; }
        public required string PhoneNumber { get; set; }
    }
}
