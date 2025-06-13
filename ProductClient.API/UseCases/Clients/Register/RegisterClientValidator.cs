using FluentValidation;
using ProductClient.Communication.Requests;

namespace ProductClient.API.UseCases.Clients.Register
{
    public class RegisterClientValidator : AbstractValidator<RequestClientJson>
    {
        public RegisterClientValidator()
        {
            RuleFor(client => client.Name).NotEmpty().WithMessage("Name can't be null.");
            RuleFor(client => client.Email).EmailAddress().WithMessage("Email is not valid.");
        }
    }
}
