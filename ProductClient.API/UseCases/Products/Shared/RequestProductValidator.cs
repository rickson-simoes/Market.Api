using FluentValidation;
using ProductClient.Communication.Requests;
using ProductClient.Exceptions.ExceptionsBase;

namespace ProductClient.API.UseCases.Products.Shared
{
    public class RequestProductValidator : AbstractValidator<RequestProductJson>
    {
        public RequestProductValidator() 
        {
            RuleFor(product => product.Name)
                .NotEmpty().WithMessage("Name can't be null.")
                .Length(1, 30).WithMessage("Name must have only 30 characters max.");
            RuleFor(product => product.Brand)
                .NotEmpty().WithMessage("Brand can't be null.")
                .Length(1, 20).WithMessage("Brand must have only 20 characters max.");
            RuleFor(product => product.Price)
                .NotEmpty().WithMessage("Price can't be free or empty.");
            RuleFor(product => product.ClientId)
                .NotEmpty().WithMessage("Client ID not specified.");
        }

        public void ValidateProductData(RequestProductJson request)
        {
            var validation = Validate(request);

            if (!validation.IsValid)
            {
                var errors = validation.Errors.Select( err => err.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errors);
            }
        }
    }
}
