using BackendTask.Commons;

namespace BackendTask.Entities
{
    public class Customer:BaseEntity
    {
        public required string CustomerName { get; set; }
        public string? CompanyName { get; set; }
        public required string PhoneNumber { get; set; }
    }
}
