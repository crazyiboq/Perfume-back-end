using System.ComponentModel.DataAnnotations;

namespace back_end.DTOs.ContactDTOs;

public class ContactCreateDto
{
    [Required(ErrorMessage = "Name is required.")]
    public string Name { get; set;}
    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Please enter a valid email address")]
    public string Email { get; set;}
    [Required(ErrorMessage = "Please enter a valid phone number")]
    public string Phone { get; set; }

    public string Subject { get; set;}
    [Required(ErrorMessage = "Message is required.")]
    public string Message { get; set;}
}
