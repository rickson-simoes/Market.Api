using ProductClient.API.Infrastructure;
using ProductClient.Communication.Requests;
using ProductClient.Communication.Responses;
using ProductClient.Exceptions.ExceptionsBase;
using ProductClient.API.Entities;

namespace ProductClient.API.UseCases.Clients.Register
{
    public class RegisterClientUseCase
    {
        public ResponseClientJson Execute(RequestClientJson request)
        {
            Validate(request);

            var dbContext = new ProductClientHubDbContext();

            Client client = new Client
            {
                Name = request.Name,
                Email = request.Email,
            };

            dbContext.Clients.Add(client);
            dbContext.SaveChanges();

            return new ResponseClientJson { Id = client.Id, Name = client.Name };
        }

        private static void Validate(RequestClientJson request)
        {
            var register = new RegisterClientValidator();
            var result = register.Validate(request);

            if (!result.IsValid)
            {
                List<string> errors = result.Errors.Select(er => er.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errors);
            }
        }
    }
}
