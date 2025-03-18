using logbot.Enums;

namespace logbot.Models
{
    public class Employee
    {
        public Guid Id { get; set; } 
        public Company CompanyId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; } 
        public string Phone { get; set; } 
        public EmployeeRoleEnum Role { get; set; }
        public List<string> Permissions { get; set; } = new();
        public EmployeeStatusEnum Status { get; set; } 
        public DateTime CreatedAt { get; set; } 
        public DateTime UpdatedAt { get; set; } 
    }
}
