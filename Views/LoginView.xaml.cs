namespace Password_Manager.Views;

public partial class LoginView : ContentPage
{
    public LoginView()
    {
        InitializeComponent();
    }

    private async void btnLoginClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(UsernameEntry.Text) || string.IsNullOrEmpty(PasswordEntry.Text))
        {
            ErrorMessage.Text = "Username and password are required";
            ErrorMessage.IsVisible = true;
        }
        else
        {
            ErrorMessage.IsVisible = false;
            await Navigation.PushAsync(new PasswordListView());
        }
    }
}