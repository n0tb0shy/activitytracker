partial class MainForm
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        this.dataGridViewActivities = new System.Windows.Forms.DataGridView();
        this.DateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.AppColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.lblAppName = new System.Windows.Forms.Label();
        this.txtAppName = new System.Windows.Forms.TextBox();
        this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
        this.btnAddActivity = new System.Windows.Forms.Button();
        this.btnRemoveActivity = new System.Windows.Forms.Button();
        this.lblFilterByDate = new System.Windows.Forms.Label();
        this.comboBoxFilterByDate = new System.Windows.Forms.ComboBox();
        this.lblFilterByApp = new System.Windows.Forms.Label();
        this.comboBoxFilterByApp = new System.Windows.Forms.ComboBox();
        this.btnApplyFilter = new System.Windows.Forms.Button();
        this.btnResetFilter = new System.Windows.Forms.Button();
        this.lblAverageActivity = new System.Windows.Forms.Label();
        ((System.ComponentModel.ISupportInitialize)(this.dataGridViewActivities)).BeginInit();
        this.SuspendLayout();

        // dataGridViewActivities
        this.dataGridViewActivities.AllowUserToAddRows = false;
        this.dataGridViewActivities.AllowUserToDeleteRows = false;
        this.dataGridViewActivities.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this.dataGridViewActivities.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DateColumn,
            this.AppColumn});
        this.dataGridViewActivities.Location = new System.Drawing.Point(12, 12);
        this.dataGridViewActivities.MultiSelect = false;
        this.dataGridViewActivities.Name = "dataGridViewActivities";
        this.dataGridViewActivities.ReadOnly = true;
        this.dataGridViewActivities.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        this.dataGridViewActivities.Size = new System.Drawing.Size(400, 300);
        this.dataGridViewActivities.TabIndex = 0;

        // DateColumn
        this.DateColumn.HeaderText = "Дата";
        this.DateColumn.Name = "DateColumn";
        this.DateColumn.ReadOnly = true;
        this.DateColumn.Width = 120;

        // AppColumn
        this.AppColumn.HeaderText = "Приложение";
        this.AppColumn.Name = "AppColumn";
        this.AppColumn.ReadOnly = true;
        this.AppColumn.Width = 200;

        // lblAppName
        this.lblAppName.AutoSize = true;
        this.lblAppName.Location = new System.Drawing.Point(418, 15);
        this.lblAppName.Name = "lblAppName";
        this.lblAppName.Size = new System.Drawing.Size(75, 13);
        this.lblAppName.TabIndex = 1;
        this.lblAppName.Text = "Приложение:";

        // txtAppName
        this.txtAppName.Location = new System.Drawing.Point(421, 31);
        this.txtAppName.Name = "txtAppName";
        this.txtAppName.Size = new System.Drawing.Size(200, 20);
        this.txtAppName.TabIndex = 2;

        // dateTimePicker
        this.dateTimePicker.Location = new System.Drawing.Point(421, 70);
        this.dateTimePicker.Name = "dateTimePicker";
        this.dateTimePicker.Size = new System.Drawing.Size(200, 20);
        this.dateTimePicker.TabIndex = 3;

        // btnAddActivity
        this.btnAddActivity.Location = new System.Drawing.Point(421, 96);
        this.btnAddActivity.Name = "btnAddActivity";
        this.btnAddActivity.Size = new System.Drawing.Size(95, 30);
        this.btnAddActivity.TabIndex = 4;
        this.btnAddActivity.Text = "Добавить";
        this.btnAddActivity.UseVisualStyleBackColor = true;
        this.btnAddActivity.Click += new System.EventHandler(this.btnAddActivity_Click);

        // btnRemoveActivity
        this.btnRemoveActivity.Location = new System.Drawing.Point(526, 96);
        this.btnRemoveActivity.Name = "btnRemoveActivity";
        this.btnRemoveActivity.Size = new System.Drawing.Size(95, 30);
        this.btnRemoveActivity.TabIndex = 5;
        this.btnRemoveActivity.Text = "Удалить";
        this.btnRemoveActivity.UseVisualStyleBackColor = true;
        this.btnRemoveActivity.Click += new System.EventHandler(this.btnRemoveActivity_Click);

        // lblFilterByDate
        this.lblFilterByDate.AutoSize = true;
        this.lblFilterByDate.Location = new System.Drawing.Point(418, 139);
        this.lblFilterByDate.Name = "lblFilterByDate";
        this.lblFilterByDate.Size = new System.Drawing.Size(36, 13);
        this.lblFilterByDate.TabIndex = 6;
        this.lblFilterByDate.Text = "Дата:";

        // comboBoxFilterByDate
        this.comboBoxFilterByDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.comboBoxFilterByDate.FormattingEnabled = true;
        this.comboBoxFilterByDate.Location = new System.Drawing.Point(421, 155);
        this.comboBoxFilterByDate.Name = "comboBoxFilterByDate";
        this.comboBoxFilterByDate.Size = new System.Drawing.Size(200, 21);
        this.comboBoxFilterByDate.TabIndex = 7;

        // lblFilterByApp
        this.lblFilterByApp.AutoSize = true;
        this.lblFilterByApp.Location = new System.Drawing.Point(418, 179);
        this.lblFilterByApp.Name = "lblFilterByApp";
        this.lblFilterByApp.Size = new System.Drawing.Size(75, 13);
        this.lblFilterByApp.TabIndex = 8;
        this.lblFilterByApp.Text = "Приложение:";

        // comboBoxFilterByApp
        this.comboBoxFilterByApp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.comboBoxFilterByApp.FormattingEnabled = true;
        this.comboBoxFilterByApp.Location = new System.Drawing.Point(421, 195);
        this.comboBoxFilterByApp.Name = "comboBoxFilterByApp";
        this.comboBoxFilterByApp.Size = new System.Drawing.Size(200, 21);
        this.comboBoxFilterByApp.TabIndex = 9;

        // btnApplyFilter
        this.btnApplyFilter.Location = new System.Drawing.Point(421, 222);
        this.btnApplyFilter.Name = "btnApplyFilter";
        this.btnApplyFilter.Size = new System.Drawing.Size(95, 30);
        this.btnApplyFilter.TabIndex = 10;
        this.btnApplyFilter.Text = "Применить";
        this.btnApplyFilter.UseVisualStyleBackColor = true;
        this.btnApplyFilter.Click += new System.EventHandler(this.btnApplyFilter_Click);

        // btnResetFilter
        this.btnResetFilter.Location = new System.Drawing.Point(526, 222);
        this.btnResetFilter.Name = "btnResetFilter";
        this.btnResetFilter.Size = new System.Drawing.Size(95, 30);
        this.btnResetFilter.TabIndex = 11;
        this.btnResetFilter.Text = "Сбросить";
        this.btnResetFilter.UseVisualStyleBackColor = true;
        this.btnResetFilter.Click += new System.EventHandler(this.btnResetFilter_Click);

        // lblAverageActivity
        this.lblAverageActivity.AutoSize = true;
        this.lblAverageActivity.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        this.lblAverageActivity.Location = new System.Drawing.Point(418, 270);
        this.lblAverageActivity.Name = "lblAverageActivity";
        this.lblAverageActivity.Size = new System.Drawing.Size(203, 15);
        this.lblAverageActivity.TabIndex = 12;
        this.lblAverageActivity.Text = "Среднемесячная активность:";

        // MainForm
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(634, 324);
        this.Controls.Add(this.lblAverageActivity);
        this.Controls.Add(this.btnResetFilter);
        this.Controls.Add(this.btnApplyFilter);
        this.Controls.Add(this.comboBoxFilterByApp);
        this.Controls.Add(this.lblFilterByApp);
        this.Controls.Add(this.comboBoxFilterByDate);
        this.Controls.Add(this.lblFilterByDate);
        this.Controls.Add(this.btnRemoveActivity);
        this.Controls.Add(this.btnAddActivity);
        this.Controls.Add(this.dateTimePicker);
        this.Controls.Add(this.txtAppName);
        this.Controls.Add(this.lblAppName);
        this.Controls.Add(this.dataGridViewActivities);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.MaximizeBox = false;
        this.MinimumSize = new System.Drawing.Size(650, 363);
        this.Name = "MainForm";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "Трекер активности";
        ((System.ComponentModel.ISupportInitialize)(this.dataGridViewActivities)).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    private System.Windows.Forms.DataGridView dataGridViewActivities;
    private System.Windows.Forms.DataGridViewTextBoxColumn DateColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn AppColumn;
    private System.Windows.Forms.Label lblAppName;
    private System.Windows.Forms.TextBox txtAppName;
    private System.Windows.Forms.DateTimePicker dateTimePicker;
    private System.Windows.Forms.Button btnAddActivity;
    private System.Windows.Forms.Button btnRemoveActivity;
    private System.Windows.Forms.Label lblFilterByDate;
    private System.Windows.Forms.ComboBox comboBoxFilterByDate;
    private System.Windows.Forms.Label lblFilterByApp;
    private System.Windows.Forms.ComboBox comboBoxFilterByApp;
    private System.Windows.Forms.Button btnApplyFilter;
    private System.Windows.Forms.Button btnResetFilter;
    private System.Windows.Forms.Label lblAverageActivity;
}