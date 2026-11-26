namespace DovidnykMelomana.Models;

/// Виконавець: гурт або сольний музикант.

public class Artist : ObservableObject
{
    private string _name = string.Empty;
    private string _country = string.Empty;
    private int? _careerStartYear;
    private string _description = string.Empty;

    public Guid Id { get; set; } = Guid.NewGuid();

    public string Name
    {
        get => _name;
        set => SetProperty(ref _name, value);
    }

    public string Country
    {
        get => _country;
        set => SetProperty(ref _country, value);
    }

    /// Рік заснування гурту або початку кар'єри.
    public int? CareerStartYear
    {
        get => _careerStartYear;
        set => SetProperty(ref _careerStartYear, value);
    }

    public string Description
    {
        get => _description;
        set => SetProperty(ref _description, value);
    }

    public override string ToString() => Name;
}
