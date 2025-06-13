using ProductClient.Communication.Requests;
using ProductClient.Communication.Responses;

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
                throw new ArgumentException(string.Join(" ", result.Errors.Select(msg => msg.ErrorMessage)));
            }

            return new ResponseClientJson { Id = Guid.NewGuid(), Name = request.Name };
        }
    }
}
