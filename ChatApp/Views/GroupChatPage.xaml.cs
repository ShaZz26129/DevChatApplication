using ChatApp.ViewModels;

namespace ChatApp.Views;

public partial class GroupChatPage : ContentPage
{
    public GroupChatViewModel newChat;
    public GroupChatPage()
	{
		InitializeComponent();
        newChat = new GroupChatViewModel();
        BindingContext = newChat;
    }

    private async void Text_Changed(object sender, TextChangedEventArgs e)
    {
        try
        {
            if (e.NewTextValue == "")
            {
                newChat.ParticipantVisible = false;
            }
            newChat.BusyIndicator = true;
            if (e.NewTextValue.LastOrDefault() == ' ' || e.NewTextValue.Contains(' '))
            {
                if (e.NewTextValue.LastOrDefault() == ' ')
                {
                    var testing = newChat.ParticipantsList;
                    if (testing != null)
                        newChat.ParticipantsList.Clear();
                    await newChat.CallparticipantApi();
                    var testing1 = newChat.ParticipantsList;
                    newChat.ParticipantVisible = true;
                    newChat.Oldtext = e.NewTextValue;
                }
                if (newChat.ParticipantVisible == true)
                {
                    var textofname = e.NewTextValue.Split(" ");
                    if (e.NewTextValue.Length >= 2)
                    {
                        var textlength = textofname.Length - 1;
                        if (textofname.LastOrDefault() != "")
                        {
                            var searchtext = textofname[textlength];
                            if (searchtext != "")
                            {
                                var getlist = newChat.ParticipantsList;
                                var Finduser = getlist.FindAll(x => x.DesignationShortName.ToLower().StartsWith(searchtext.ToLower()));
                                if (getlist != null)
                                    newChat.ParticipantsList.Clear();
                                newChat.ParticipantsList = Finduser;
                            }
                        }
                    }
                }

            }
            else if (e.NewTextValue != "" && !e.NewTextValue.Contains(' '))
            {
                var testing = newChat.ParticipantsList;
                if (testing != null)
                    newChat.ParticipantsList.Clear();
                
                await newChat.CallparticipantApi();
                var testing1 = newChat.ParticipantsList;
                newChat.ParticipantVisible = true;

                if (newChat.ParticipantVisible == true)
                {
                    var textofname = e.NewTextValue.Split(" ");
                    if (e.NewTextValue.Length >= 2)
                    {
                        var textlength = textofname.Length - 1;
                        if (textofname.LastOrDefault() != "")
                        {
                            var searchtext = textofname[textlength];
                            if (searchtext != "")
                            {
                                var getlist = newChat.ParticipantsList;
                                var Finduser = getlist.FindAll(x => x.DesignationShortName.ToLower().StartsWith(searchtext.ToLower()));
                                if (getlist != null)
                                    newChat.ParticipantsList.Clear();
                                newChat.ParticipantsList = Finduser;
                            }
                        }
                    }
                }

            }
        }
        finally
        {
            newChat.BusyIndicator = false;
        }
        
    }
}