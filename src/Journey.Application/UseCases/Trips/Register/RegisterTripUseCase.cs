using Journey.Communication.Requests;
using Journey.Communication.Responses;
using Journey.Exception;
using Journey.Exception.ExceptionsBase;
using Journey.Infrastructure;
using Journey.Infrastructure.Entities;

namespace Journey.Application.UseCases.Trips.Register
{
    public class RegisterTripUseCase
    {
        public ResponseShortTripJson Execute(RequestRegisterTripJson request) 
        {
            Validate(request);

            var dbContext = new JourneyDbContext();

            // Criando uma entidade Viagem
            var entidy = new Trip
            {
                Name = request.Name,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
            };

            // Prepara o banco de dados para inserir a entidade
            dbContext.Trips.Add(entidy);

            dbContext.SaveChanges();

            return new ResponseShortTripJson
            {
                EndDate = entidy.EndDate,
                StartDate = entidy.StartDate,
                Name = entidy.Name,
                Id = entidy.Id
            };
        }

        // Função
        private void Validate(RequestRegisterTripJson request)
        {
            var validator = new RegisterTripValidator();

            var result = validator.Validate(request);

            if (result.IsValid == false) 
            {
                // Definindo que a mensagem de erro que ira aparecer vai ser a que escolhi
                var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList();

                // O "ErrorOnValidationException" recebe uma mensagem, mas agora temos uma lista
                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
