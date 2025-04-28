using System;
using System.IO;
using Xunit;

public class AuthServiceTests : IDisposable
{
    private const string TestUsersFile = "test_users.json";
    private readonly AuthService _authService;

    public AuthServiceTests()
    {
        _authService = new AuthService(TestUsersFile);
    }

    public void Dispose()
    {
        if (File.Exists(TestUsersFile))
        {
            File.Delete(TestUsersFile);
        }
    }

    [Fact]
    public void Register_NewUser_ReturnsTrue()
    {
        var result = _authService.Register("testuser", "password");
        Assert.True(result);
    }

    [Fact]
    public void Register_DuplicateUser_ReturnsFalse()
    {
        _authService.Register("testuser", "password");
        var result = _authService.Register("testuser", "newpassword");
        Assert.False(result);
    }

    [Fact]
    public void Login_ValidCredentials_ReturnsTrue()
    {
        _authService.Register("testuser", "password");
        var result = _authService.Login("testuser", "password");
        Assert.True(result);
    }

    [Fact]
    public void Login_InvalidCredentials_ReturnsFalse()
    {
        _authService.Register("testuser", "password");
        var result = _authService.Login("testuser", "wrongpassword");
        Assert.False(result);
    }

    [Fact]
    public void RememberUser_AfterLogin_ReturnsCredentials()
    {
        _authService.Register("testuser", "password");
        _authService.Login("testuser", "password", rememberMe: true);
        
        var remembered = _authService.GetRememberedUser();
        Assert.Equal("testuser", remembered?.Username);
        Assert.Equal("password", remembered?.Password);
    }
}
