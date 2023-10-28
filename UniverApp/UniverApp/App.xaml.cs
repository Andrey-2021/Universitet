using EntitiesLibrary.Services;
using Microsoft.Extensions.DependencyInjection;
using UniverApp.Views;
namespace UniverApp;

public partial class App : Application
{
	private ServiceProvider serviceProvider;

	public App()
	{
		ServiceCollection services = new ServiceCollection();
		ConfigureServices(services);
		serviceProvider = services.BuildServiceProvider();
	}

	private void OnStartup(object sender, StartupEventArgs e)
	{
		//Disable shutdown when the dialog closes
		Current.ShutdownMode = ShutdownMode.OnExplicitShutdown;

		var checkPasswordWindow = serviceProvider.GetRequiredService<ICheckLoginView>();
		checkPasswordWindow.ShowDialog();

		var loginUserService = serviceProvider.GetService<LiginUserService>();
		if (loginUserService!.RegisteredUser == null)
		{ //нет вошедшего пользователя, выходим из программы
			Current.Shutdown(-1);
			return;
		}


		var mainWindow = serviceProvider.GetRequiredService<IMainWindowView>();
		mainWindow.ShowDialog();
		Current.Shutdown(0);
	}

	private void ConfigureServices(ServiceCollection services)
	{
		DbConteinerConfiguration.AddToServiceCollection(services);
		services.AddTransient<DbRepository>();
		services.AddSingleton<LiginUserService>();

		services.AddTransient<IStatisticsView, StatisticsWindow>();
		services.AddTransient<ICheckLoginView, CheckLoginWindow>();
		services.AddTransient<IMessageWindowView, MessageWindow>();
		services.AddTransient<IAboutProgrammView, AboutProgrammWindow>();
		services.AddTransient<IHelpView, HelpWindow>();
		services.AddTransient<IMainWindowView, MainWindow>();
		services.AddTransient<IGroupsView, GroupsWindow>();
		services.AddTransient<ISubjectsView, SubjectsWindow>();
		services.AddTransient<ITasksTypesView, TasksTypesWindow>();
		services.AddTransient<IUsersView, UsersWindow>();
		services.AddTransient<IStudentsView, StudentsWindow>();
		services.AddTransient<ILearningsDatesView, LearningsDatesWindow>();
		services.AddTransient<IAttendancesView, AttendancesWindow>();
		services.AddTransient<ISubjectScoreView, SubjectScoreWindow>();

		services.AddTransient<IAddGroupView, AddGroupWindow>();
		services.AddTransient<IAddSubjectView, AddSubjectWindow>();
		services.AddTransient<IAddTaskTypeView, AddTaskTypeWindow>();
		services.AddTransient<IAddUserView, AddUserWindow>();
		services.AddTransient<IAddStudentView, AddStudentWindow>();
		services.AddTransient<IAddLearningDateView, AddLearningDateWindow>();
		services.AddTransient<IAddAttendanceView, AddAttendanceWindow>();
		services.AddTransient<IAddSubjectScoreView, AddSubjectScoreWindow>();

		services.AddTransient<IAddAddSubjectForGroupView, AddSubjectForGroupWindow>();


		services.AddTransient<StatisticsViewModel>();
		services.AddTransient<CheckLoginViewModel>();
		services.AddTransient<MessageViewModel>();
		services.AddTransient<AboutProgrammViewModel>();
		services.AddTransient<HelpViewModel>();
		services.AddTransient<MainWindowViewModel>();
		services.AddTransient<GroupsViewModel>();
		services.AddTransient<SubjectsViewModel>();
		services.AddTransient<TasksTypesViewModel>();
		services.AddTransient<UsersViewModel>();
		services.AddTransient<StudentsViewModel>();
		services.AddTransient<LearningsDatesViewModel>();
		services.AddTransient<AttendancesViewModel>();
		services.AddTransient<SubjectScoresViewModel>();

		services.AddTransient<AddGroupViewModel>();
		services.AddTransient<AddSubjectViewModel>();
		services.AddTransient<AddTaskTypeViewModel>();
		services.AddTransient<AddUserViewModel>();
		services.AddTransient<AddStudentViewModel>();
		services.AddTransient<AddLearningDateViewModel>();
		services.AddTransient<AddAttendanceViewModel>();
		services.AddTransient<AddSubjectScoreViewModel>();

		services.AddTransient<AddSubjectForGroupViewModel>();

	}
}
