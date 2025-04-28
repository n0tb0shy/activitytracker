using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

public class AuthService : IDisposable
{
    private readonly string _usersFile;
    private List<User> _users;

    private class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }

    public AuthService(string usersFile = "users.json")
    {
        _usersFile = usersFile;
        LoadUsers();
    }

    private void LoadUsers()
    {
        try
        {
            if (File.Exists(_usersFile))
            {
                string json = File.ReadAllText(_usersFile);
                _users = JsonConvert.DeserializeObject<List<User>>(json) ?? new List<User>();
            }
            else
            {
                _users = new List<User>();
            }
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Failed to load users data", ex);
        }
    }

    private void SaveUsers()
    {
        try
        {
            string json = JsonConvert.SerializeObject(_users, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(_usersFile, json);
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Failed to save users data", ex);
        }
    }

    public bool Register(string username, string password)
    {
        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            return false;

        if (_users.Exists(u => u.Username == username))
            return false;

        _users.Add(new User
        {
            Username = username,
            Password = password,
            RememberMe = false
        });

        SaveUsers();
        return true;
    }

    public bool Login(string username, string password, bool rememberMe = false)
    {
        var user = _users.Find(u => u.Username == username && u.Password == password);
        if (user == null)
            return false;

        if (rememberMe)
        {
            _users.ForEach(u => u.RememberMe = false);
            user.RememberMe = true;
            SaveUsers();
        }

        return true;
    }

    public (string Username, string Password)? GetRememberedUser()
    {
        var user = _users.Find(u => u.RememberMe);
        return user != null ? (user.Username, user.Password) : null;
    }

    public void Dispose()
    {
        SaveUsers();
    }
}
