using EntitiesLibrary.DTO;
using System.Collections.ObjectModel;
namespace EntitiesLibrary.Auxiliaries;

/// <summary>
/// Статистика по данным из оценок учащихся
/// </summary>
public class StudentStatistic : BaseNotifyPropertyChanged
{
    public SelectedDatasDTO? DTO { get; set; }

    /// <summary>
    /// Список оценок
    /// </summary>
    public ObservableCollection<SubjectScore>? SubjectScores { get => subjectScores; set { subjectScores = value; OnPropertyChanged(); } }
    public ObservableCollection<SubjectScore>? subjectScores;

    /// <summary>
    /// Средняя оценка
    /// </summary>
    public decimal AverageScore { get => averageScore; set { averageScore = value; OnPropertyChanged(); } }
    public decimal averageScore;

    /// <summary>
    /// Средние оценки по каждому студенту
    /// </summary>
	public ObservableCollection<StudentAverageScore>? StudentAverageScores{ get => studentAverageScores; set { studentAverageScores = value; OnPropertyChanged(); } }
	public ObservableCollection<StudentAverageScore>? studentAverageScores;

	public decimal AverageScoreForStudentAverageScores { get => averageScoreForStudentAverageScores; set { averageScoreForStudentAverageScores = value; OnPropertyChanged(); } }
	public decimal averageScoreForStudentAverageScores;

	public decimal MaxAverageScoreForAverageScores { get => maxAverageScoreForAverageScores; set { maxAverageScoreForAverageScores = value; OnPropertyChanged(); } }
	public decimal maxAverageScoreForAverageScores;

	public decimal MinAverageScoreForAverageScores { get => minAverageScore; set { minAverageScore = value; OnPropertyChanged(); } }
	public decimal minAverageScore;


    /// <summary>
    /// Ввод исходных данных
    /// </summary>
    /// <param name="subjectScores"></param>
    /// <param name="dTO"></param>
	public void SetDatas(List<SubjectScore>? subjectScores, SelectedDatasDTO? dTO)
    {
        DTO = dTO;
        if (subjectScores == null) SubjectScores = null;
        else SubjectScores = new(subjectScores);
        Calculate();
    }

    /// <summary>
    /// Вычисления
    /// </summary>
    private void Calculate()
    {
        if (SubjectScores == null)
        {
            AverageScore = 0;
            StudentAverageScores = null;

			return;
        }

        //средняя оценка
        if (SubjectScores==null || SubjectScores.Count == 0)
            AverageScore = 0;
        else
            AverageScore = SubjectScores.Sum(x => x.Score) / SubjectScores.Count;


        //Среднии оценки для студентов
        List<StudentAverageScore> averageScores = new();
        foreach (var student in SubjectScores.GroupBy(x => x.Student))
        {
            if(student.Count()==0)
				averageScores.Add(new StudentAverageScore(student.Key, 0));
            else
			averageScores.Add(new StudentAverageScore(student.Key, student.Sum(x => x.Score) / student.Count()));
        }
        StudentAverageScores = new(averageScores);

        //Средняя оценка для средних оценок
        if (StudentAverageScores == null || StudentAverageScores.Count == 0)
        {
            AverageScoreForStudentAverageScores = 0;
            MaxAverageScoreForAverageScores = 0;
            MinAverageScoreForAverageScores = 0;
		}
        else
        {
            AverageScoreForStudentAverageScores = StudentAverageScores.Sum(x => x.AverageScore) / StudentAverageScores.Count;
            MaxAverageScoreForAverageScores = StudentAverageScores.Max(x => x.AverageScore);
            MinAverageScoreForAverageScores = StudentAverageScores.Min(x => x.AverageScore);
        }
	}
}
