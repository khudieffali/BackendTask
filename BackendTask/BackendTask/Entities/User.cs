using BackendTask.Commons;
using System.ComponentModel.DataAnnotations;

namespace BackendTask.Entities
{
    public class User:BaseEntity
    {
        public required string Name { get; set; }
        [EmailAddress]
        public required string Email { get; set; }
        public string? Role { get; set; }
    }
}
