namespace back_end.DTOs.Contact;

public class ContactResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; }

    public string  Email { get; set; }
    public string Phone { get; set; }
    public string Subject { get; set; }

    public string Message { get; set; }

    public bool IsRead { get; set; }

    public DateTime CreatedAt { get; set;}
}
