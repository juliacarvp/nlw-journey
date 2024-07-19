namespace Journey.Communication.Responses
{
    public class ResponseErrorsJson
    {
        // Falando para lista inicializar com valor vazio, e não nulo
        // [] - Simplificação de "new List<string>()"
        public IList<string> Errors { get; set; } = [];

        public ResponseErrorsJson(IList<string> errors)
        {
            Errors = errors;
        }
    }
}
