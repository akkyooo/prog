using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using lb7.Models;

namespace lb7.Services
{
    public static class UserService
    {
        private static readonly string FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "users.json");

        public static List<User> LoadUsers()
        {
            if (!File.Exists(FilePath))
            {
                return new List<User>();
            }

            try
            {
                string json = File.ReadAllText(FilePath);
                return JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();
            }
            catch (JsonException)
            {
                return new List<User>();
            }
            catch (IOException)
            {
                return new List<User>();
            }
        }

        private static bool SaveUsers(List<User> users)
        {
            try
            {
                string json = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });

                File.WriteAllText(FilePath, json);
                return true;
            }
            catch (IOException)
            {
                return false;
            }
            catch (UnauthorizedAccessException)
            {
                return false;
            }
        }

        public static bool Register(User newUser, out string errorMessage)
        {
            List<User> users = LoadUsers();

            bool loginExists = users.Any(user => user.Login.Equals(newUser.Login, StringComparison.OrdinalIgnoreCase));

            if (loginExists)
            {
                errorMessage = "Користувач із таким логіном уже існує!";
                return false;
            }

            bool emailExists = users.Any(user => user.Email.Equals(newUser.Email, StringComparison.OrdinalIgnoreCase));

            if (emailExists)
            {
                errorMessage = "Користувач із такою електронною поштою вже існує!";
                return false;
            }

            users.Add(newUser);

            if (!SaveUsers(users))
            {
                errorMessage = "Не вдалося зберегти дані у файл!";
                return false;
            }

            errorMessage = "";
            return true;
        }

        public static User? Authorize(string login, string password)
        {
            List<User> users = LoadUsers();

            return users.FirstOrDefault(user =>
            (user.Login.Equals(login, StringComparison.OrdinalIgnoreCase) || 
            user.Email.Equals(login, StringComparison.OrdinalIgnoreCase)) && user.Password == password);
        }
    }
}