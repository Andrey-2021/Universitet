namespace ViewModels;

public class UsersViewModel : BaseAllEntitiesViewModel<RegisteredUser, IAddUserView>
{
	public UsersViewModel(IServiceProvider serviceProvider) : base(serviceProvider)
	{
	}
}
