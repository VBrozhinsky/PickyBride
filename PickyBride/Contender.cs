namespace PickyBride;

public class Contender
{
    public string Surname { get; }
    public string Name { get; }

    protected Contender(string surname, string name)
    {
        Surname = surname ?? throw new ArgumentNullException(nameof(surname));
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }

    public string GetFullName()
    {
        return $"{Surname} {Name}";
    }
}
