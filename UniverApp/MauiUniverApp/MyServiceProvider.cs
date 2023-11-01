namespace MauiUniverApp;

//Статья
//https://putridparrot.com/blog/dependency-injection-using-shell-in-maui/
//https://stackoverflow.com/questions/69332982/how-to-share-serviceprovider-in-maui-blazor-for-maui-services-and-blazor-service

public class MyServiceProvider
{
	public static TService GetService<TService>()
	  => Current.GetService<TService>();

	public static IServiceProvider Current
	   =>
#if WINDOWS10_0_17763_0_OR_GREATER
    MauiWinUIApplication.Current.Services;
#elif ANDROID
        MauiApplication.Current.Services;
#elif IOS || MACCATALYST
	 MauiUIApplicationDelegate.Current.Services;
#else
    null;
#endif
}
