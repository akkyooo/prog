using DovidnykMelomana.Models;
using DovidnykMelomana.Services;

namespace DovidnykMelomana.ViewModels;

/// Вікно додавання та редагування жанру.

public class GenreEditViewModel : EditViewModelBase
{
    private readonly CatalogService _catalog;
    private readonly Genre? _original;
    private string _name = string.Empty;
    private string _description = string.Empty;

    public GenreEditViewModel(CatalogService catalog, Genre? genre)
    {
        _catalog = catalog;
        _original = genre;
        if (genre != null)
        {
            _name = genre.Name;
            _description = genre.Description;
        }
    }

    public override string WindowTitle => _original == null ? "Новий жанр" : $"Редагування жанру: {_original.Name}";

    public string Name
    {
        get => _name;
        set
        {
            SetProperty(ref _name, value);
            Validate();
        }
    }

    public string Description
    {
        get => _description;
        set => SetProperty(ref _description, value);
    }

    protected override IEnumerable<string> ValidatedProperties => new[] { nameof(Name) };

    protected override string? ValidateProperty(string propertyName)
    {
        if (propertyName != nameof(Name))
        {
            return null;
        }

        if (string.IsNullOrWhiteSpace(Name))
        {
            return "Вкажіть назву жанру.";
        }

        return _catalog.IsGenreNameTaken(Name, _original?.Id ?? Guid.Empty) ? "Такий жанр уже є." : null;
    }

    protected override void Apply()
    {
        if (_original == null)
        {
            _catalog.AddGenre(new Genre { Name = Name.Trim(), Description = Description.Trim() });
            return;
        }

        _original.Name = Name.Trim();
        _original.Description = Description.Trim();
        _catalog.Save();
    }
}
