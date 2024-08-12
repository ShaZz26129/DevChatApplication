namespace ChatApp;

public partial class ChatMessagePage : ContentPage
{
    ChatMessageViewModel viewModel;
    //ChatMessagePage(CommonChatModel chatModel
    public ChatMessagePage()
    {
        InitializeComponent();
        BindingContext = viewModel = new ChatMessageViewModel();
    }

    private async void entry_TextChanged(object sender, TextChangedEventArgs e)
    {
        await viewModel.Typing();
    }
}