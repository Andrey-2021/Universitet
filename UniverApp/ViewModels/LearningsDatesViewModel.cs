namespace ViewModels;

public class LearningsDatesViewModel : BaseAllEntitiesViewModel<LearningDate, IAddLearningDateView>
{
	public LearningsDatesViewModel(IServiceProvider serviceProvider) : base(serviceProvider)
	{
	}
}
