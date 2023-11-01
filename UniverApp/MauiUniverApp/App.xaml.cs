namespace MauiUniverApp
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			//MainPage = new AppShell();
			MainPage = new NavigationPage(new MainPage());
			//Routing.RegisterRoute(nameof(AboutProgramPage), typeof(AboutProgramPage));
		}
	}
}