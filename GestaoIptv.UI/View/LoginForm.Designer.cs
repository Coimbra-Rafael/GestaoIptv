

namespace GestaoIptv.UI;

partial class LoginForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        lblUsername = new Label();
        lblPassword = new Label();
        txtUsername = new TextBox();
        txtPassword = new TextBox();
        btnLogin = new Button();
        chkRememberMe = new CheckBox();
        SuspendLayout();
        // 
        // lblUsername
        // 
        lblUsername.Location = new Point(12, 12);
        lblUsername.Name = "lblUsername";
        lblUsername.Size = new Size(90, 24);
        lblUsername.TabIndex = 0;
        lblUsername.Text = "Username:";
        // 
        // lblPassword
        // 
        lblPassword.Location = new Point(12, 45);
        lblPassword.Name = "lblPassword";
        lblPassword.Size = new Size(90, 24);
        lblPassword.TabIndex = 1;
        lblPassword.Text = "Password:";
        // 
        // txtUsername
        // 
        txtUsername.Location = new Point(108, 12);
        txtUsername.Name = "txtUsername";
        txtUsername.PlaceholderText = "Enter your username";
        txtUsername.Size = new Size(200, 27);
        txtUsername.TabIndex = 0;
        // 
        // txtPassword
        // 
        txtPassword.BackColor = SystemColors.InactiveBorder;
        txtPassword.Location = new Point(108, 45);
        txtPassword.Name = "txtPassword";
        txtPassword.PasswordChar = '*';
        txtPassword.PlaceholderText = "Enter your password";
        txtPassword.Size = new Size(200, 27);
        txtPassword.TabIndex = 1;
        txtPassword.KeyPress += txtPassword_KeyPress;
        // 
        // btnLogin
        // 
        btnLogin.BackColor = SystemColors.Control;
        btnLogin.Location = new Point(12, 85);
        btnLogin.Name = "btnLogin";
        btnLogin.Size = new Size(90, 34);
        btnLogin.TabIndex = 2;
        btnLogin.Text = "Logar";
        btnLogin.UseVisualStyleBackColor = false;
        btnLogin.Click += btnLogin_Click;
        // 
        // chkRememberMe
        // 
        chkRememberMe.Location = new Point(158, 91);
        chkRememberMe.Name = "chkRememberMe";
        chkRememberMe.Size = new Size(150, 24);
        chkRememberMe.TabIndex = 3;
        chkRememberMe.Text = "Remember me";
        // 
        // LoginForm
        // 
        BackColor = Color.DarkSlateBlue;
        ClientSize = new Size(337, 150);
        Controls.Add(lblUsername);
        Controls.Add(txtUsername);
        Controls.Add(lblPassword);
        Controls.Add(txtPassword);
        Controls.Add(btnLogin);
        Controls.Add(chkRememberMe);
        Font = new Font("Arial", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
        ForeColor = SystemColors.ControlText;
        Name = "LoginForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Login Form";
        Load += LoginForm_Load;
        ResumeLayout(false);
        PerformLayout();
    }


    #endregion

    private TextBox txtUsername;
    private TextBox txtPassword;
    private Button btnLogin;
    private CheckBox chkRememberMe;
    private Label lblUsername;
    private Label lblPassword;
}
