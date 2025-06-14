using ProductClient.Communication.Requests;
using ProductClient.Communication.Responses;
using ProductClient.Exceptions.ExceptionsBase;

namespace ProductClient.API.UseCases.Clients.Register
{
    public class RegisterClientUseCase
    {
        public ResponseClientJson Execute(RequestClientJson request)
        {
            var register = new RegisterClientValidator();
            var result = register.Validate(request);

            if (!result.IsValid)
            {
                List<string> teste = result.Errors.Select(er => er.ErrorMessage).ToList();

                throw new ErrorOnValidationException(teste);
            }

            return new ResponseClientJson { Id = Guid.NewGuid(), Name = request.Name };
        }
    }
}
