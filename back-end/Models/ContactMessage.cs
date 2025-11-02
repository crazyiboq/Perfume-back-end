using back_end.Models.Entity;

namespace back_end.Models
{
    public class ContactMessage:BaseEntity
    {
        public string FullName { get; set; } = default!;
        public string? Email { get; set; }

        public string? Phone { get; set; }

        public string Subject { get; set; }
        public string Message { get; set; }
    }
}
