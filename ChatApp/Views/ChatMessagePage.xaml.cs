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
}