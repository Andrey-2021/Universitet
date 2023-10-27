namespace ViewModels;

public class StudentsViewModel : BaseAllEntitiesViewModel<Student, IAddStudentView>
{
	public StudentsViewModel(IServiceProvider serviceProvider) : base(serviceProvider)
	{
	}
}
