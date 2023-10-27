namespace ViewModels;

public class SubjectScoresViewModel : BaseAllEntitiesViewModel<SubjectScore, IAddSubjectScoreView>
{
	public SubjectScoresViewModel(IServiceProvider serviceProvider) : base(serviceProvider)
	{
	}
}
