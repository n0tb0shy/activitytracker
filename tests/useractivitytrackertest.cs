using System;
using System.IO;
using Xunit;

public class UserActivityTrackerTests : IDisposable
{
    private const string TestActivitiesFile = "test_activities.json";
    private readonly UserActivityTracker _tracker;

    public UserActivityTrackerTests()
    {
        _tracker = new UserActivityTracker("testuser", TestActivitiesFile);
    }

    public void Dispose()
    {
        if (File.Exists(TestActivitiesFile))
        {
            File.Delete(TestActivitiesFile);
        }
    }

    [Fact]
    public void AddActivity_NewActivity_StoresCorrectly()
    {
        var testDate = new DateTime(2023, 1, 1);
        _tracker.AddActivity(testDate, "testapp");
        
        var activities = _tracker.GetActivitiesByDate(testDate);
        Assert.Contains("testapp", activities);
    }

    [Fact]
    public void RemoveActivity_ExistingActivity_RemovesCorrectly()
    {
        var testDate = new DateTime(2023, 1, 1);
        _tracker.AddActivity(testDate, "testapp");
        _tracker.RemoveActivity(testDate, "testapp");
        
        var activities = _tracker.GetActivitiesByDate(testDate);
        Assert.DoesNotContain("testapp", activities);
    }

    [Fact]
    public void CalculateAverageMonthlyActivity_WithData_ReturnsCorrectValue()
    {
        var today = DateTime.Today;
        _tracker.AddActivity(today, "app1");
        _tracker.AddActivity(today, "app2");
        _tracker.AddActivity(today.AddDays(-1), "app1");
        
        double expected = 3.0 / DateTime.DaysInMonth(today.Year, today.Month);
        double actual = _tracker.CalculateAverageMonthlyActivity();
        
        Assert.Equal(expected, actual, 2);
    }

    [Fact]
    public void GetAllApplications_ReturnsUniqueApps()
    {
        _tracker.AddActivity(DateTime.Today, "app1");
        _tracker.AddActivity(DateTime.Today, "app2");
        _tracker.AddActivity(DateTime.Today.AddDays(-1), "app1");
        
        var apps = _tracker.GetAllApplications();
        Assert.Equal(2, apps.Count);
        Assert.Contains("app1", apps);
        Assert.Contains("app2", apps);
    }
}
