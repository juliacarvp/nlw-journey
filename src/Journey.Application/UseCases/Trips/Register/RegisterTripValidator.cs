using FluentValidation;
using Journey.Communication.Requests;
using Journey.Exception;

namespace Journey.Application.UseCases.Trips.Register
{
    // Validador de "RequestRegisterTripJson"
    public class RegisterTripValidator : AbstractValidator<RequestRegisterTripJson>
    {
        // Construtor
        public RegisterTripValidator()
        {
            // Criando uma regra para o Request
            RuleFor(request => request.Name).NotEmpty().WithMessage(ResourceErrorMessages.NAME_EMPTY);
            // UtcNow - Data e a hora base para calcular as datas e horas de todos os paises
            RuleFor(request => request.StartDate.Date)
                .GreaterThanOrEqualTo(DateTime.UtcNow.Date)
                .WithMessage(ResourceErrorMessages.DATE_TRIP_MUST_BE_LATER_THAN_TODAY);

            // Must sempre deve ter uma condição sendo True
            RuleFor(request => request)
                .Must(request => request.EndDate.Date >= request.StartDate.Date)
                .WithMessage(ResourceErrorMessages.END_DATE_TRIP_MUST_BE_LATER_START_DATE);
        }
    }
}
