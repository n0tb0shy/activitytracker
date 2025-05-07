using System;
using System.Windows.Forms;

/// Форма для входа и регистрации пользователей
public partial class LoginForm : Form
{
    // Сервис аутентификации для работы с пользователями
    private readonly AuthService _authService;

    /// Имя авторизованного пользователя (доступно только для чтения)
    public string Username { get; private set; }

    /// Конструктор формы авторизации
    /// Сервис аутентификации (если null - создается новый)
    public LoginForm(AuthService authService = null)
    {
        InitializeComponent(); // Инициализация компонентов формы
        _authService = authService ?? new AuthService(); // Используем переданный сервис или создаем новый
        LoadRememberedUser(); // Загружаем данные запомненного пользователя
    }

    /// <summary>
    /// Загружает данные пользователя с флагом "Запомнить меня"
    /// </summary>
    private void LoadRememberedUser()
    {
        var user = _authService.GetRememberedUser();
        if (user != null)
        {
            txtUsername.Text = user.Value.Username; // Заполняем поле логина
            txtPassword.Text = user.Value.Password;  // Заполняем поле пароля
            chkRememberMe.Checked = true;           // Активируем чекбокс
        }
    }

    /// Обработчик нажатия клавиш в поле пароля
    private void txtPassword_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            btnLogin_Click(sender, e); // При нажатии Enter вызываем обработчик кнопки входа
        }
    }

    /// Обработчик клика по кнопке "Войти"
    private void btnLogin_Click(object sender, EventArgs e)
    {
        string username = txtUsername.Text.Trim();
        string password = txtPassword.Text;

        // Проверка на пустые поля
        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
        {
            MessageBox.Show("Введите логин и пароль", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        // Попытка аутентификации
        if (_authService.Login(username, password, chkRememberMe.Checked))
        {
            Username = username; // Сохраняем имя пользователя
            DialogResult = DialogResult.OK; // Устанавливаем результат диалога
            Close(); // Закрываем форму
        }
        else
        {
            MessageBox.Show("Неверный логин или пароль", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    /// Обработчик клика по кнопке "Регистрация"
    private void btnRegister_Click(object sender, EventArgs e)
    {
        string username = txtUsername.Text.Trim();
        string password = txtPassword.Text;

        // Попытка регистрации нового пользователя
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
