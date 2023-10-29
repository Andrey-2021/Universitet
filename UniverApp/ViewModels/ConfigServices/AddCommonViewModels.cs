namespace ViewModels.ConfigServices;

public class AddCommonViewModels
{

	/// <summary>
	/// Добавляем ViewModel-и в контейнер
	/// </summary>
	/// <param name="services"></param>
	public static void AddViewModels(IServiceCollection services)
	{

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
