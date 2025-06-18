using FluentValidation;
using ProductClient.Communication.Requests;
using ProductClient.Exceptions.ExceptionsBase;

namespace ProductClient.API.UseCases.Clients.Shared
{
    public class RequestClientValidator : AbstractValidator<RequestClientJson>
    {
        public RequestClientValidator()
        {
            RuleFor(client => client.Name).NotEmpty().WithMessage("Name can't be null.");
            RuleFor(client => client.Email).EmailAddress().WithMessage("Email is not valid.");
        }

        public void ValidateClientData(RequestClientJson request)
        {
            var result = Validate(request);

            if (!result.IsValid)
            {
                List<string> errors = result.Errors.Select(er => er.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errors);
            }
        }
    }
}
