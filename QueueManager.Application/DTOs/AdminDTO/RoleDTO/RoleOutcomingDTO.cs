namespace QueueManager.Application.DTOs.AdminDTO.RoleDTO
{
    public class RoleOutcomingDTO
    {
        public Guid Id { get; set; }
        public string? RoleName { get; set; }
        public List<Guid>? PermissionIds { get; set; }
    }
}
