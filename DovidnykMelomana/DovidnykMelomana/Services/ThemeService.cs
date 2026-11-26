using System.Windows;

namespace DovidnykMelomana.Services;

/// Перемикає кольорову тему, замінюючи словник ресурсів із кольорами.

public static class ThemeService
{
    public static readonly string[] Themes = { "Світла", "Темна" };

    public static string CurrentTheme { get; private set; } = "Світла";

    public static void Apply(string theme)
    {
        var file = theme == "Темна" ? "Themes/DarkTheme.xaml" : "Themes/LightTheme.xaml";
        var dictionaries = Application.Current.Resources.MergedDictionaries;

        var old = dictionaries.FirstOrDefault(d => d.Source != null && d.Source.OriginalString.Contains("Theme.xaml"));
        var fresh = new ResourceDictionary { Source = new Uri(file, UriKind.Relative) };

        if (old != null)
        {
            dictionaries[dictionaries.IndexOf(old)] = fresh;
        }
        else
        {
            dictionaries.Insert(0, fresh);
        }

        CurrentTheme = theme == "Темна" ? "Темна" : "Світла";
    }
}
