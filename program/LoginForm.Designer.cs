partial class LoginForm
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
        this.lblUsername = new System.Windows.Forms.Label();
        this.txtUsername = new System.Windows.Forms.TextBox();
        this.lblPassword = new System.Windows.Forms.Label();
        this.txtPassword = new System.Windows.Forms.TextBox();
        this.chkRememberMe = new System.Windows.Forms.CheckBox();
        this.btnLogin = new System.Windows.Forms.Button();
        this.btnRegister = new System.Windows.Forms.Button();
        this.SuspendLayout();

        // lblUsername
        this.lblUsername.AutoSize = true;
        this.lblUsername.Location = new System.Drawing.Point(12, 15);
        this.lblUsername.Name = "lblUsername";
        this.lblUsername.Size = new System.Drawing.Size(41, 13);
        this.lblUsername.TabIndex = 0;
        this.lblUsername.Text = "Логин:";

        // txtUsername
        this.txtUsername.Location = new System.Drawing.Point(80, 12);
        this.txtUsername.Name = "txtUsername";
        this.txtUsername.Size = new System.Drawing.Size(200, 20);
        this.txtUsername.TabIndex = 1;

        // lblPassword
        this.lblPassword.AutoSize = true;
        this.lblPassword.Location = new System.Drawing.Point(12, 41);
        this.lblPassword.Name = "lblPassword";
        this.lblPassword.Size = new System.Drawing.Size(48, 13);
        this.lblPassword.TabIndex = 2;
        this.lblPassword.Text = "Пароль:";

        // txtPassword
        this.txtPassword.Location = new System.Drawing.Point(80, 38);
        this.txtPassword.Name = "txtPassword";
        this.txtPassword.PasswordChar = '*';
        this.txtPassword.Size = new System.Drawing.Size(200, 20);
        this.txtPassword.TabIndex = 3;
        this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);

        // chkRememberMe
        this.chkRememberMe.AutoSize = true;
        this.chkRememberMe.Location = new System.Drawing.Point(80, 64);
        this.chkRememberMe.Name = "chkRememberMe";
        this.chkRememberMe.Size = new System.Drawing.Size(104, 17);
        this.chkRememberMe.TabIndex = 4;
        this.chkRememberMe.Text = "Запомнить меня";
        this.chkRememberMe.UseVisualStyleBackColor = true;

        // btnLogin
        this.btnLogin.Location = new System.Drawing.Point(80, 87);
        this.btnLogin.Name = "btnLogin";
        this.btnLogin.Size = new System.Drawing.Size(90, 30);
        this.btnLogin.TabIndex = 5;
        this.btnLogin.Text = "Войти";
        this.btnLogin.UseVisualStyleBackColor = true;
        this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);

        // btnRegister
        this.btnRegister.Location = new System.Drawing.Point(190, 87);
        this.btnRegister.Name = "btnRegister";
        this.btnRegister.Size = new System.Drawing.Size(90, 30);
        this.btnRegister.TabIndex = 6;
        this.btnRegister.Text = "Регистрация";
        this.btnRegister.UseVisualStyleBackColor = true;
        this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);

        // LoginForm
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(294, 131);
        this.Controls.Add(this.btnRegister);
        this.Controls.Add(this.btnLogin);
        this.Controls.Add(this.chkRememberMe);
        this.Controls.Add(this.txtPassword);
        this.Controls.Add(this.lblPassword);
        this.Controls.Add(this.txtUsername);
        this.Controls.Add(this.lblUsername);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "LoginForm";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "Авторизация";
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    private System.Windows.Forms.Label lblUsername;
    private System.Windows.Forms.TextBox txtUsername;
    private System.Windows.Forms.Label lblPassword;
    private System.Windows.Forms.TextBox txtPassword;
    private System.Windows.Forms.CheckBox chkRememberMe;
    private System.Windows.Forms.Button btnLogin;
    private System.Windows.Forms.Button btnRegister;
}
