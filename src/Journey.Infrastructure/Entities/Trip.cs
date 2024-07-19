namespace Journey.Infrastructure.Entities;
public class Trip
{
    public Guid Id { get; set; } = Guid.NewGuid(); // Garante que o ID vai ser prenchido
    public string Name { get; set; } = string.Empty; // Faz com que o nome não seja nulo, mas vazio
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public IList<Activity> Activities { get; set; } = []; // A lista não vai ser nula, vai ser vazia
}
