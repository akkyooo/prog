namespace DovidnykMelomana.Models;

/// Обліковий запис користувача довідника.

public class User
{
    public string Login { get; set; } = string.Empty;
    public string DisplayName { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string Salt { get; set; } = string.Empty;
    public DateTime RegisteredAt { get; set; } = DateTime.Now;
    public string Theme { get; set; } = "Світла";
}
