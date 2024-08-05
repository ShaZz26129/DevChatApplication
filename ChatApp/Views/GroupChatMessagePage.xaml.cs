namespace ChatApp.Views;

public partial class GroupChatMessagePage : ContentPage
{
    private GroupChatMessageViewModel viewModel;
    public GroupChatMessagePage(CommonChatModel chatModel)
	{
		InitializeComponent();
        BindingContext = viewModel = new GroupChatMessageViewModel(chatModel);
    }

    private async void entry_TextChanged(object sender, TextChangedEventArgs e)
    {
       await viewModel.Typing();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await viewModel.SendMessageToGroupChat();
    }
}