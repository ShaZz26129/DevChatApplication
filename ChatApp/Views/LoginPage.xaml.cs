namespace ChatApp;

public partial class LoginPage : ContentPage
{
	public LoginPage(LoginViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

    private void ImageButton_Clicked(object sender, EventArgs e)
    {
		if (password.IsPassword == true)
		{
			password.IsPassword = false;
			hidepass.Source ="show.png";
		}
		else
		{
			password.IsPassword = true;
			hidepass.Source = "hide.png";
		}
    }
}