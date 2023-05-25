namespace QueueManager.Application.DTOs.AdminDTO.UserRefreshTokenDTO
{
    public class UserRefreshTokenCreateDTO
    {
        public Guid UserId { get; set; }
        public string? RefreshToken { get; set; }
        public bool IsActive { get; set; }
        public DateTimeOffset ExpiryDate { get; set; }
    }
}
