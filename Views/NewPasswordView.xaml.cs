namespace Password_Manager.Views;

public partial class NewPasswordView : ContentPage
{
	public NewPasswordView()
	{
		InitializeComponent();
	}

    private async void OnCancelClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PasswordListView());
    }

    private async void OnExistingPasswordSubmitClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PasswordListView());
    }

    private void OnGeneratePasswordClicked(object sender, EventArgs e)
    {

    }

    private  async void OnGeneratedPasswordSubmitClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PasswordListView());
    }
}