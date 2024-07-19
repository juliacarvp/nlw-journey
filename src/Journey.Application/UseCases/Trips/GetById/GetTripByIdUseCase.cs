using Journey.Communication.Responses;
using Journey.Exception;
using Journey.Exception.ExceptionsBase;
using Journey.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Journey.Application.UseCases.Trips.GetById
{
    public class GetTripByIdUseCase
    {
        public ResponseTripJson Execute(Guid id)
        {
            var dbContext = new JourneyDbContext();

            var trip = dbContext
                .Trips
                .Include(trip => trip.Activities)
                .FirstOrDefault(trip => trip.Id == id);

            // Verificando se o Id corresponde a alguma viagem no banco de dados
            if (trip is null) 
            {
                throw new NotFoundException(ResourceErrorMessages.TRIP_NOT_FOUND);
            }

            return new ResponseTripJson
            {
               Id = trip.Id,
               Name = trip.Name,
               StartDate = trip.StartDate,
               Activities = trip.Activities.Select(Activity => new ResponseActivityJson
               {
                   Id = Activity.Id,
                   Name = Activity.Name,
                   Date = Activity.Date,
                   Status = (Communication.Enums.ActivityStatus)Activity.Status
               }).ToList(),
            };
        }
    }
}
