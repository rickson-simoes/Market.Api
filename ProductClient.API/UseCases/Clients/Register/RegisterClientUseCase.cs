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
                throw new ArgumentException("Error on received data.");
            }

            return new ResponseClientJson { Id = Guid.NewGuid(), Name = request.Name };
        }
    }
}
