using System;
using System.Windows.Forms;

public partial class LoginForm : Form
{
    private readonly AuthService _authService;

    public string Username { get; private set; }

    public LoginForm(AuthService authService = null)
    {
        InitializeComponent();
        _authService = authService ?? new AuthService();
        LoadRememberedUser();
    }

    private void LoadRememberedUser()
    {
        var user = _authService.GetRememberedUser();
        if (user != null)
        {
            txtUsername.Text = user.Value.Username;
            txtPassword.Text = user.Value.Password;
            chkRememberMe.Checked = true;
        }
    }
    private void txtPassword_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            btnLogin_Click(sender, e); // Вызываем обработчик кнопки входа
        }
    }
    private void btnLogin_Click(object sender, EventArgs e)
    {
        string username = txtUsername.Text;
        string password = txtPassword.Text;

        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
        {
            MessageBox.Show("Введите логин и пароль", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        if (_authService.Login(username, password, chkRememberMe.Checked))
        {
            Username = username;
            DialogResult = DialogResult.OK;
            Close();
        }
        else
        {
            MessageBox.Show("Неверный логин или пароль", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnRegister_Click(object sender, EventArgs e)
    {
        string username = txtUsername.Text;
        string password = txtPassword.Text;

        if (_authService.Register(username, password))
        {
            MessageBox.Show("Регистрация успешна!", "Успех",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        else
        {
            MessageBox.Show("Пользователь уже существует", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
