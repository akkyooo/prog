using System.Windows.Input;
using DovidnykMelomana.Models;
using DovidnykMelomana.Services;

namespace DovidnykMelomana.ViewModels;

/// Вкладка «Жанри»: перелік жанрів із кількістю альбомів кожного жанру.

public class GenresViewModel : ViewModelBase
{
    private readonly CatalogService _catalog;
    private readonly IDialogService _dialogs;
    private GenreRow? _selectedRow;

    public GenresViewModel(CatalogService catalog, IDialogService dialogs)
    {
        _catalog = catalog;
        _dialogs = dialogs;

        AddCommand = new RelayCommand(Add);
        EditCommand = new RelayCommand(Edit, () => SelectedRow != null);
        DeleteCommand = new RelayCommand(Delete, () => SelectedRow != null);

        _catalog.CatalogChanged += (_, _) => OnPropertyChanged(nameof(Rows));
    }

    public IEnumerable<GenreRow> Rows =>
        _catalog.Genres
            .OrderBy(g => g.Name)
            .Select(g => new GenreRow(g, _catalog.Albums.Count(a => a.GenreId == g.Id)))
            .ToList();

    public GenreRow? SelectedRow
    {
        get => _selectedRow;
        set => SetProperty(ref _selectedRow, value);
    }

    public ICommand AddCommand { get; }
    public ICommand EditCommand { get; }
    public ICommand DeleteCommand { get; }

    private void Add() => _dialogs.ShowGenreEditor(new GenreEditViewModel(_catalog, null));

    private void Edit()
    {
        if (SelectedRow != null)
        {
            _dialogs.ShowGenreEditor(new GenreEditViewModel(_catalog, SelectedRow.Genre));
        }
    }

    private void Delete()
    {
        if (SelectedRow == null || !_dialogs.Confirm($"Видалити жанр «{SelectedRow.Genre.Name}»?"))
        {
            return;
        }

        var error = _catalog.DeleteGenre(SelectedRow.Genre);
        if (error != null)
        {
            _dialogs.ShowError(error);
        }
    }
}

/// Рядок таблиці жанрів.
public record GenreRow(Genre Genre, int AlbumCount)
{
    public string Name => Genre.Name;
    public string Description => Genre.Description;
}
