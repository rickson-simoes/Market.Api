using FluentValidation;
using ProductClient.Communication.Requests;
using ProductClient.Exceptions.ExceptionsBase;

namespace ProductClient.API.UseCases.Clients.Shared
{
    public class RequestClientValidator : AbstractValidator<RequestClientJson>
    {
        public RequestClientValidator()
        {
            RuleFor(client => client.Name)
                .NotEmpty().WithMessage("Name can't be null.")
                .Length(1, 30).WithMessage("Name must have only 30 characters max.");
            RuleFor(client => client.Email)
                .EmailAddress().WithMessage("Email is not valid.")
                .Length(1, 50).WithMessage("Please choose a smaller email account, max: 50 characters."); ;
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
