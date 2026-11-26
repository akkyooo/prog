using System.Text.Json.Serialization;

namespace DovidnykMelomana.Models;

/// Трек альбому.

public class Track : ObservableObject
{
    private int _number;
    private string _title = string.Empty;
    private int _durationSeconds;
    private bool _isFavorite;

    public Guid Id { get; set; } = Guid.NewGuid();

    public int Number
    {
        get => _number;
        set => SetProperty(ref _number, value);
    }

    public string Title
    {
        get => _title;
        set => SetProperty(ref _title, value);
    }

    /// Тривалість у секундах; 0 означає, що тривалість невідома.
    public int DurationSeconds
    {
        get => _durationSeconds;
        set
        {
            if (SetProperty(ref _durationSeconds, value))
            {
                OnPropertyChanged(nameof(DurationText));
            }
        }
    }

    public bool IsFavorite
    {
        get => _isFavorite;
        set => SetProperty(ref _isFavorite, value);
    }

    [JsonIgnore]
    public string DurationText => FormatDuration(DurationSeconds);

    public static string FormatDuration(int seconds)
    {
        if (seconds <= 0)
        {
            return "–";
        }

        var time = TimeSpan.FromSeconds(seconds);
        return time.TotalHours >= 1
            ? $"{(int)time.TotalHours}:{time.Minutes:00}:{time.Seconds:00}"
            : $"{time.Minutes}:{time.Seconds:00}";
    }

   
    /// Розбирає рядок формату «хв:сс» або «год:хв:сс». Порожній рядок повертає 0 (тривалість невідома).
    
    public static bool TryParseDuration(string? text, out int seconds)
    {
        seconds = 0;
        if (string.IsNullOrWhiteSpace(text) || text.Trim() == "–")
        {
            return true;
        }

        var parts = text.Trim().Split(':');
        if (parts.Length is < 2 or > 3)
        {
            return false;
        }

        var numbers = new int[parts.Length];
        for (var i = 0; i < parts.Length; i++)
        {
            if (!int.TryParse(parts[i], out numbers[i]) || numbers[i] < 0)
            {
                return false;
            }
        }

        if (numbers[^1] > 59 || (parts.Length == 3 && numbers[1] > 59))
        {
            return false;
        }

        seconds = parts.Length == 2
            ? numbers[0] * 60 + numbers[1]
            : numbers[0] * 3600 + numbers[1] * 60 + numbers[2];
        return seconds > 0;
    }
}
