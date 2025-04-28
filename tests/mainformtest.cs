using System.Windows.Forms;
using Xunit;

public class MainFormTests
{
    [Fact]
    public void MainForm_Load_ShowsAverageActivity()
    {
        var authService = new AuthService();
        authService.Register("testuser", "password");
        
        var tracker = new UserActivityTracker("testuser");
        tracker.AddActivity(DateTime.Today, "testapp");
        
        var form = new MainForm("testuser", tracker);
        form.Show();
        
        Assert.Contains("Среднемесячная активность", form.AverageActivityLabel.Text);
        form.Close();
    }

    [Fact]
    public void AddActivityButton_Click_AddsNewActivity()
    {
        var tracker = new UserActivityTracker("testuser");
        var form = new MainForm("testuser", tracker);
        
        form.ApplicationNameText = "newapp";
        form.SimulateAddButtonClick();
        
        var activities = tracker.GetActivitiesByDate(DateTime.Today);
        Assert.Contains("newapp", activities);
    }
}
