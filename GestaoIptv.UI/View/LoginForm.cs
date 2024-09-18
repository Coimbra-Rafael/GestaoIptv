using GestaoIptv.UI.Persistence;

namespace GestaoIptv.UI;

public partial class LoginForm : Form
{
    public LoginForm()
    {
        InitializeComponent();
    }

    private void LoginForm_Load(object sender, EventArgs e)
    {
        try
        {
            using (var dbInitializer = new DatabaseInitializer())
            {
                dbInitializer.InitializeDatabase();
            }
        }
        catch (Exception ex) 
        {
            throw new Exception(ex.Message);
        }
    }

    private void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {
            using (var userRepository = new UsuariosRepository()) 
            {
                var userExists = userRepository.GetUsersByNomeUsuarioAndPassword(txtUsername.Text, txtPassword.Text).GetAwaiter().GetResult();

                if (userExists is not null)
                {

                }
                else 
                {
                    MessageBox.Show("Usuário ou Senha incorretos!");
                }
            }
        }
        catch (Exception)
        {

            throw;
        }

        
    }

    private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == (char)Keys.Enter)
        {
            btnLogin_Click(sender, e);  
        }
    }
}
