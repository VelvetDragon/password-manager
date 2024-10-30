namespace Password_Manager.Views;

public partial class NewUserView : ContentPage
{
	public NewUserView()
	{
		InitializeComponent();
	}

    private async void btnClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(FirstNameEntry.Text) ||
                string.IsNullOrEmpty(LastNameEntry.Text) ||
                string.IsNullOrEmpty(UsernameEntry.Text) ||
                string.IsNullOrEmpty(PasswordEntry.Text) ||
                string.IsNullOrEmpty(ReEnterPasswordEntry.Text))
        {
            ErrorMessage.IsVisible = true;
        }
        else if (PasswordEntry.Text != ReEnterPasswordEntry.Text)
        {
            ErrorMessage.Text = "Passwords do not match";
            ErrorMessage.IsVisible = true;
        }
        else
        {
            ErrorMessage.IsVisible = false;
            await Navigation.PushAsync(new PasswordListView());
        }
    }

    private async void OnGoToLoginClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new LoginView());
    }
}