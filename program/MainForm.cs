using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

public partial class MainForm : Form
{
    private readonly UserActivityTracker _tracker;
    private readonly string _currentUser;

    public MainForm(string username)
    {
        InitializeComponent();
        _currentUser = username;
        _tracker = new UserActivityTracker(username);
        LoadActivities();
        LoadFilterOptions();
        this.Text = $"Трекер активности - {username}";
    }

    private void LoadActivities()
    {
        dataGridViewActivities.Rows.Clear();
        var dates = _tracker.GetAllDates();
        foreach (var date in dates)
        {
            var apps = _tracker.GetActivitiesByDate(date);
            foreach (var app in apps)
            {
                dataGridViewActivities.Rows.Add(date.ToShortDateString(), app);
            }
        }
        lblAverageActivity.Text = $"Среднемесячная активность: {_tracker.CalculateAverageMonthlyActivity():F2}";
    }

    private void LoadFilterOptions()
    {
        comboBoxFilterByDate.Items.Clear();
        comboBoxFilterByApp.Items.Clear();

        comboBoxFilterByDate.Items.Add("Все даты");
        comboBoxFilterByDate.Items.AddRange(_tracker.GetAllDates()
            .OrderBy(d => d)
            .Select(d => d.ToShortDateString())
            .ToArray());
        comboBoxFilterByDate.SelectedIndex = 0;

        comboBoxFilterByApp.Items.Add("Все приложения");
        comboBoxFilterByApp.Items.AddRange(_tracker.GetAllApplications()
            .OrderBy(a => a)
            .ToArray());
        comboBoxFilterByApp.SelectedIndex = 0;
    }

    private void btnAddActivity_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(txtAppName.Text))
        {
            _tracker.AddActivity(dateTimePicker.Value, txtAppName.Text);
            LoadActivities();
            LoadFilterOptions();
            txtAppName.Clear();
        }
        else
        {
            MessageBox.Show("Введите название приложения", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void btnRemoveActivity_Click(object sender, EventArgs e)
    {
        if (dataGridViewActivities.SelectedRows.Count > 0)
        {
            var selectedRow = dataGridViewActivities.SelectedRows[0];
            var date = DateTime.Parse(selectedRow.Cells[0].Value.ToString());
            var appName = selectedRow.Cells[1].Value.ToString();

            _tracker.RemoveActivity(date, appName);
            LoadActivities();
            LoadFilterOptions();
        }
        else
        {
            MessageBox.Show("Выберите запись для удаления", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void btnApplyFilter_Click(object sender, EventArgs e)
    {
        var filteredData = new List<(string Date, string App)>();

        var allDates = _tracker.GetAllDates();
        foreach (var date in allDates)
        {
            var apps = _tracker.GetActivitiesByDate(date);
            foreach (var app in apps)
            {
                bool dateMatch = comboBoxFilterByDate.SelectedIndex == 0 ||
                               date.ToShortDateString() == comboBoxFilterByDate.SelectedItem.ToString();
                bool appMatch = comboBoxFilterByApp.SelectedIndex == 0 ||
                              app == comboBoxFilterByApp.SelectedItem.ToString();

                if (dateMatch && appMatch)
                    filteredData.Add((date.ToShortDateString(), app));
            }
        }

        dataGridViewActivities.Rows.Clear();
        foreach (var item in filteredData.OrderBy(i => i.Date))
            dataGridViewActivities.Rows.Add(item.Date, item.App);
    }

    private void btnResetFilter_Click(object sender, EventArgs e)
    {
        comboBoxFilterByDate.SelectedIndex = 0;
        comboBoxFilterByApp.SelectedIndex = 0;
        LoadActivities();
    }
}
