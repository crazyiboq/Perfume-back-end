using back_end.DTOs.ContactDTOs;
using FluentValidation;
using Microsoft.Identity.Client;

namespace back_end.DTOs.Validation.ContactValidation;

public class CreateContactValidation : AbstractValidator<ContactCreateDto>
{
    public CreateContactValidation()
    {
        RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name cannot be empty.")
                .MinimumLength(2).WithMessage("Name must be at least 2 characters.")
                .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Please provide a valid email address.");

        RuleFor(x => x.Subject)
            .MaximumLength(150).WithMessage("Subject cannot exceed 150 characters.");

        RuleFor(x => x.Message)
            .NotEmpty().WithMessage("Message cannot be empty.")
            .MinimumLength(10).WithMessage("Message must be at least 10 characters long.")
            .MaximumLength(1000).WithMessage("Message cannot exceed 1000 characters.");

        RuleFor(x => x.Phone)
            .Matches(@"^\+?[0-9\s\-]{7,15}$")
            .When(x => !string.IsNullOrEmpty(x.Phone))
            .WithMessage("Please enter a valid phone number.");
    }

}
