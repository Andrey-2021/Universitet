namespace ViewModels;

public class SubjectsViewModel : BaseAllEntitiesViewModel<Subject, IAddSubjectView>
{
	public SubjectsViewModel(IServiceProvider serviceProvider) : base(serviceProvider)
	{
	}
}
