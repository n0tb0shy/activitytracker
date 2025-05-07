using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

/// Класс для отслеживания активности пользователей
public class UserActivityTracker : IDisposable
{
    private readonly string _activitiesFile; // Путь к файлу хранения данных
    private List<ActivityRecord> _activities; // Список записей активности
    private readonly string _currentUser; // Текущий пользователь

    /// Внутренний класс для хранения записей активности
    private class ActivityRecord
    {
        public string UserId { get; set; } // Идентификатор пользователя
        public DateTime Date { get; set; } // Дата активности
        public string ApplicationName { get; set; } // Название приложения
    }

    /// Конструктор трекера активности
    public UserActivityTracker(string username, string activitiesFile = "activities.json")
    {
        _currentUser = username;
        _activitiesFile = activitiesFile;
        _activities = LoadActivities(); // Загружаем данные при инициализации
    }
    
    /// Загружает записи активности из файла
    /// Возвращает список записей активности
    private List<ActivityRecord> LoadActivities()
    {
        try
        {
            if (File.Exists(_activitiesFile))
            {
                string json = File.ReadAllText(_activitiesFile);
                // Десериализуем JSON или возвращаем пустой список при null
                return JsonConvert.DeserializeObject<List<ActivityRecord>>(json) 
                    ?? new List<ActivityRecord>();
            }
            return new List<ActivityRecord>(); // Файла нет - возвращаем пустой список
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Ошибка загрузки данных активности", ex);
        }
    }

    /// Сохраняет записи активности в файл
    private void SaveActivities()
    {
        try
        {
            string json = JsonConvert.SerializeObject(_activities, Formatting.Indented);
            File.WriteAllText(_activitiesFile, json);
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Ошибка сохранения данных активности", ex);
        }
    }

    /// Добавляет новую запись активности
    public void AddActivity(DateTime date, string applicationName)
    {
        if (string.IsNullOrWhiteSpace(applicationName))
            throw new ArgumentException("Название приложения не может быть пустым");

        _activities.Add(new ActivityRecord
        {
            UserId = _currentUser,
            Date = date.Date, // Сохраняем только дату без времени
            ApplicationName = applicationName
        });

        SaveActivities(); // Сохраняем изменения
    }

    /// Удаляет запись активности
    public void RemoveActivity(DateTime date, string applicationName)
    {
        // Удаляем все совпадающие записи
        int removed = _activities.RemoveAll(a =>
            a.UserId == _currentUser &&
            a.Date == date.Date &&
            a.ApplicationName == applicationName);

        if (removed > 0)
            SaveActivities(); // Сохраняем только если что-то удалили
    }

    /// Получает список приложений для указанной даты
    /// Возвращает список названий приложений
    public List<string> GetActivitiesByDate(DateTime date)
    {
        return _activities
            .Where(a => a.UserId == _currentUser && a.Date == date.Date)
            .Select(a => a.ApplicationName)
            .ToList();
    }

    /// Получает все уникальные даты с активностями
    /// Возвращает отсортированный список дат
    public List<DateTime> GetAllDates()
    {
        return _activities
            .Where(a => a.UserId == _currentUser)
            .Select(a => a.Date)
            .Distinct()
            .OrderBy(d => d)
            .ToList();
    }

    /// Получает все уникальные названия приложений
    /// Возвращает Отсортированный по алфавиту список приложений
    public List<string> GetAllApplications()
    {
        return _activities
            .Where(a => a.UserId == _currentUser)
            .Select(a => a.ApplicationName)
            .Distinct()
            .OrderBy(a => a)
            .ToList();
    }

    /// Вычисляет среднюю дневную активность за текущий месяц
    /// Возвращает Среднее количество активностей в день
    public double CalculateAverageMonthlyActivity()
    {
        var currentMonth = DateTime.Now.Month;
        var currentYear = DateTime.Now.Year;

        // Считаем активности за текущий месяц
        var activitiesThisMonth = _activities
            .Count(a => a.UserId == _currentUser &&
                       a.Date.Month == currentMonth &&
                       a.Date.Year == currentYear);

        var daysInMonth = DateTime.DaysInMonth(currentYear, currentMonth);
        return daysInMonth > 0 ? (double)activitiesThisMonth / daysInMonth : 0;
    }

    /// Реализация интерфейса IDisposable
    public void Dispose()
    {
        SaveActivities(); // При завершении работы сохраняем данные
    }
}
