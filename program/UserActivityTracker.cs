using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

public class UserActivityTracker : IDisposable
{
    private readonly string _activitiesFile;
    private List<ActivityRecord> _activities;
    private readonly string _currentUser;

    private class ActivityRecord
    {
        public string UserId { get; set; }
        public DateTime Date { get; set; }
        public string ApplicationName { get; set; }
    }

    public UserActivityTracker(string username, string activitiesFile = "activities.json")
    {
        _currentUser = username;
        _activitiesFile = activitiesFile;
        _activities = LoadActivities();
    }

    private List<ActivityRecord> LoadActivities()
    {
        try
        {
            if (File.Exists(_activitiesFile))
            {
                string json = File.ReadAllText(_activitiesFile);
                return JsonConvert.DeserializeObject<List<ActivityRecord>>(json)
                    ?? new List<ActivityRecord>();
            }
            return new List<ActivityRecord>();
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Failed to load activities data", ex);
        }
    }

    private void SaveActivities()
    {
        try
        {
            string json = JsonConvert.SerializeObject(_activities, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(_activitiesFile, json);
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Failed to save activities data", ex);
        }
    }

    public void AddActivity(DateTime date, string applicationName)
    {
        if (string.IsNullOrWhiteSpace(applicationName))
            throw new ArgumentException("Application name cannot be empty");

        _activities.Add(new ActivityRecord
        {
            UserId = _currentUser,
            Date = date.Date,
            ApplicationName = applicationName
        });

        SaveActivities();
    }

    public void RemoveActivity(DateTime date, string applicationName)
    {
        int removed = _activities.RemoveAll(a =>
            a.UserId == _currentUser &&
            a.Date == date.Date &&
            a.ApplicationName == applicationName);

        if (removed > 0)
            SaveActivities();
    }

    public List<string> GetActivitiesByDate(DateTime date)
    {
        return _activities
            .Where(a => a.UserId == _currentUser && a.Date == date.Date)
            .Select(a => a.ApplicationName)
            .ToList();
    }

    public List<DateTime> GetAllDates()
    {
        return _activities
            .Where(a => a.UserId == _currentUser)
            .Select(a => a.Date)
            .Distinct()
            .OrderBy(d => d)
            .ToList();
    }

    public List<string> GetAllApplications()
    {
        return _activities
            .Where(a => a.UserId == _currentUser)
            .Select(a => a.ApplicationName)
            .Distinct()
            .OrderBy(a => a)
            .ToList();
    }

    public double CalculateAverageMonthlyActivity()
    {
        var currentMonth = DateTime.Now.Month;
        var currentYear = DateTime.Now.Year;

        var activitiesThisMonth = _activities
            .Count(a => a.UserId == _currentUser &&
                       a.Date.Month == currentMonth &&
                       a.Date.Year == currentYear);

        var daysInMonth = DateTime.DaysInMonth(currentYear, currentMonth);
        return daysInMonth > 0 ? (double)activitiesThisMonth / daysInMonth : 0;
    }

    public void Dispose()
    {
        SaveActivities();
    }
}