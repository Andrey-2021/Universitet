namespace ViewModels;

public class AddTaskTypeViewModel : BaseAddEntityViewModel<TaskType>
{
	public AddTaskTypeViewModel(IServiceProvider serviceProvider) : base(serviceProvider)
	{
	}
}
