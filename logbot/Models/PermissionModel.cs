using System.ComponentModel.DataAnnotations;

namespace logbot.Models
{
    public class PermissionModel
    {
        [Key]
        public Guid Id { get; set; } 
        public string Name { get; set; }
        public string Description { get; set; } 
    }
}
