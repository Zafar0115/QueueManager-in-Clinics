namespace QueueManager.Application.DTOs.AdminDTO.UserDTO
{
    public class UserCreateDTO
    {
        public required string UserName { get; set; }
        public required string Password { get; set; }
        public required string EmailAddress { get; set; }
        public required string PhoneNumber { get; set; }
        public string? FullName { get; set; }
        public  Guid ClinicId { get; set; }
        public Guid[]? RoleIds { get; set; }


    }
}
