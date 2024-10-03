namespace Hadrian.CodingAssignment.Infrastructure.Model;

public class Organization
{
    public Guid Id { get; }

    public string Name { get; set; }

    public ICollection<User>? Users { get; }

    public ICollection<Risk>? Risks { get; }

    public Organization(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
    }
}