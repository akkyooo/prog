namespace DovidnykMelomana.Models;

/// Музичний жанр.

public class Genre : ObservableObject
{
    private string _name = string.Empty;
    private string _description = string.Empty;

    public Guid Id { get; set; } = Guid.NewGuid();

    public string Name
    {
        get => _name;
        set => SetProperty(ref _name, value);
    }

    public string Description
    {
        get => _description;
        set => SetProperty(ref _description, value);
    }

    public override string ToString() => Name;
}
