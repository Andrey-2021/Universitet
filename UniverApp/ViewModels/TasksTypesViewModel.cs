namespace ViewModels;

public class TasksTypesViewModel : BaseAllEntitiesViewModel<TaskType, IAddTaskTypeView>
{
	public TasksTypesViewModel(IServiceProvider serviceProvider) : base(serviceProvider)
	{
	}
}
