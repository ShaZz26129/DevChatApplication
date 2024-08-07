﻿
using ChatApp.ViewModels;
using ChatApp.Views;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Syncfusion.Maui.Core.Hosting;

namespace ChatApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .ConfigureSyncfusionCore()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

        builder.Services.AddSingleton<LoginViewModel>();
        builder.Services.AddSingleton<LoginPage>();

        builder.Services.AddSingleton<RegisterViewModel>();
        builder.Services.AddSingleton<RegisterPage>();

        builder.Services.AddSingleton<ChatListViewModel>();
        builder.Services.AddSingleton<ChatListPage>();

        builder.Services.AddSingleton<ChatMessageViewModel>();
        builder.Services.AddSingleton<ChatMessagePage>();
        
        builder.Services.AddSingleton<GroupChatMessageViewModel>();
        builder.Services.AddSingleton<GroupChatMessagePage>();

        builder.Services.AddSingleton<GroupChatViewModel>();
        builder.Services.AddSingleton<GroupChatPage>();

        
        return builder.Build();
	}
}
