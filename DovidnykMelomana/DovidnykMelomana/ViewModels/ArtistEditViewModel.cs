using DovidnykMelomana.Models;
using DovidnykMelomana.Services;

namespace DovidnykMelomana.ViewModels;

/// Вікно додавання та редагування виконавця.

public class ArtistEditViewModel : EditViewModelBase
{
    private readonly CatalogService _catalog;
    private readonly Artist? _original;
    private string _name = string.Empty;
    private string _country = string.Empty;
    private string _yearText = string.Empty;
    private string _description = string.Empty;

    public ArtistEditViewModel(CatalogService catalog, Artist? artist)
    {
        _catalog = catalog;
        _original = artist;

        if (artist != null)
        {
            _name = artist.Name;
            _country = artist.Country;
            _yearText = artist.CareerStartYear?.ToString() ?? string.Empty;
            _description = artist.Description;
        }
    }

    public override string WindowTitle => _original == null ? "Новий виконавець" : $"Редагування: {_original.Name}";

    public Artist? Result { get; private set; }

    public string Name
    {
        get => _name;
        set
        {
            SetProperty(ref _name, value);
            Validate();
        }
    }

    public string Country
    {
        get => _country;
        set
        {
            SetProperty(ref _country, value);
            Validate();
        }
    }

    public string YearText
    {
        get => _yearText;
        set
        {
            SetProperty(ref _yearText, value);
            Validate();
        }
    }

    public string Description
    {
        get => _description;
        set => SetProperty(ref _description, value);
    }

    protected override IEnumerable<string> ValidatedProperties => new[] { nameof(Name), nameof(Country), nameof(YearText) };

    protected override string? ValidateProperty(string propertyName)
    {
        switch (propertyName)
        {
            case nameof(Name):
                if (string.IsNullOrWhiteSpace(Name))
                {
                    return "Вкажіть назву гурту або ім'я виконавця.";
                }

                return _catalog.IsArtistNameTaken(Name, _original?.Id ?? Guid.Empty)
                    ? "Такий виконавець уже є в довіднику."
                    : null;

            case nameof(Country):
                return Country.Any(char.IsDigit) ? "Назва країни не може містити цифр." : null;

            case nameof(YearText):
                if (string.IsNullOrWhiteSpace(YearText))
                {
                    return null; // рік необов'язковий
                }

                if (!int.TryParse(YearText, out var year))
                {
                    return "Рік має бути цілим числом.";
                }

                return year < 1900 || year > DateTime.Now.Year ? $"Рік має бути в межах 1900–{DateTime.Now.Year}." : null;
        }

        return null;
    }

    protected override void Apply()
    {
        var artist = _original ?? new Artist();
        artist.Name = Name.Trim();
        artist.Country = Country.Trim();
        artist.CareerStartYear = string.IsNullOrWhiteSpace(YearText) ? null : int.Parse(YearText);
        artist.Description = Description.Trim();

        if (_original == null)
        {
            _catalog.AddArtist(artist);
        }
        else
        {
            _catalog.Save();
        }

        Result = artist;
    }
}
