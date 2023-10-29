using MauiUniverApp.Views;
using Microsoft.Extensions.Logging;
//using VideoSubscriberAccount;
using ViewModels.ConfigServices;

namespace MauiUniverApp
{
	public static class MauiProgram
	{
		public static MauiApp CreateMauiApp()
		{
			var builder = MauiApp.CreateBuilder();
			builder
				.UseMauiApp<App>()
				.ConfigureFonts(fonts =>
				{
					fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
					fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				});


#if DEBUG
		builder.Logging.AddDebug();
#endif

			ConfigMyClasses(builder);
			return builder.Build();
		}

		/// <summary>
		/// Добавляю свои классы в контейнер
		/// </summary>
		/// <param name="builder"></param>
		private static void ConfigMyClasses(MauiAppBuilder builder)
		{
			builder.Services.AddTransient<IMainWindowView, MainPage>();
			builder.Services.AddTransient<IAboutProgrammView, AboutProgramPage>();
			builder.Services.AddTransient<IHelpView, HelpPage>();
			builder.Services.AddSingleton<LiginUserService>();

			AddCommonViewModels.AddViewModels(builder.Services);
		}
	}


	
}