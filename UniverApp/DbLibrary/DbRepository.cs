using EntitiesLibrary;
using EntitiesLibrary.DTO;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace DbLibrary;

public class DbRepository
{
	private readonly IDbContextFactory<SqlDbContext> contextFactory;

	public DbRepository(IDbContextFactory<SqlDbContext> contextFactory)
	{
		this.contextFactory = contextFactory;
	}

	/// <summary>
	/// Проверка доступности БД
	/// </summary>
	/// <returns></returns>
	public async Task<Exception?> CanConnectAsync()
	{
		try
		{
			using var db = contextFactory.CreateDbContext();
			var isCanConnect = await db.CheckCanConnectAsync();
			if (isCanConnect == false)
				throw new Exception("Не удалось подключиться к БД");
			return null;
		}
		catch (Exception ex)
		{
			return ex;
		}
	}


	/// <summary>
	/// Создать новую БД
	/// </summary>
	/// <returns></returns>
	public async Task<(bool operationResult, string? message)> CreateNewDbAsync()
	{
		try
		{
			using var db = contextFactory.CreateDbContext();
			await db.CreateClearDbAsync();
			await InitDb(db);
			return (true, null);
		}
		catch (Exception ex)
		{
			return (false, ex.Message + Environment.NewLine + ex.InnerException?.Message);
		}
	}


	public async Task InitDb(SqlDbContext db)
	{

		RegisteredUser admin = new() { Login = "admin", Password = "admin", Role = RoleEnum.admin };
		RegisteredUser manager = new() { Login = "user", Password = "1234", Role = RoleEnum.manager };
		await db.AddRangeAsync(admin, manager);


		Subject math = new() { Name = "Высшая математика", Description = "Для 1го и 2го курса" };
		Subject dis = new() { Name = "Дискретная математика" };
		Subject fiz = new() { Name = "Физика", Description = "Экзамен по окончанию курса" };
		Subject istor = new() { Name = "История России XVII век." };
		await db.AddRangeAsync(math, dis, fiz, istor);

		TaskType type1 = new() { Name = "Опрос" };
		TaskType type2 = new() { Name = "Практическая работа" };
		TaskType type3 = new() { Name = "Самостоятельная работа" };
		await db.AddRangeAsync(type1, type2, type3);

		UniversitetGroup group1 = new()
		{
			Name = "Группа ПМ-002",
			Description = "Прикладная математика",
			Subjects = new() { math, dis, fiz }
		};
		UniversitetGroup group2 = new()
		{
			Name = "Группа ПР-33",
			Description = "Программирование",
			Subjects = new() { math, dis }
		};
		UniversitetGroup group3 = new()
		{
			Name = "Группа ИС-21",
			Description = "Историки",
			Subjects = new() { math, istor }
		};
		UniversitetGroup group4 = new()
		{
			Name = "Группа ФЗ-17",
			Description = "Физики",
			Subjects = new() { fiz, istor }
		};
		await db.AddRangeAsync(group1, group2, group3, group4);

		
		
		
		
		Student st1 = new()
		{
			Surname = "Петров",
			Name = "Сергей",
			MiddleName = "Васильевич",
			Birthday = new DateTime(2010, 1, 4),
			UniversitetGroup = group1
		};

		Student st2 = new()
		{
			Surname = "Иванов",
			Name = "Пётр",
			MiddleName = "Иванович",
			Birthday = new DateTime(2011, 4, 4),
			UniversitetGroup = group2
		};

		Student st3 = new()
		{
			Surname = "Смирнов",
			Name = "Валерий",
			MiddleName = "Васильевич",
			Birthday = new DateTime(2012, 7, 2),
			UniversitetGroup = group1
		};

		Student st4 = new()
		{
			Surname = "Конев",
			Name = "Генадий",
			MiddleName = "Аркадьевич",
			Birthday = new DateTime(2013, 3, 9),
			UniversitetGroup = group2
		};

		Student st5 = new()
		{
			Surname = "Орлов",
			Name = "Алексей",
			MiddleName = "Васильевич",
			Birthday = new DateTime(2015, 7, 20),
			UniversitetGroup = group3
		};


		Student st6 = new()
		{
			Surname = "Круглов",
			Name = "Сергей",
			MiddleName = "Сергеевич",
			Birthday = new DateTime(2014, 6, 2),
			UniversitetGroup = group4
		};

		Student st7 = new()
		{
			Surname = "Барабанов",
			Name = "Пётр",
			MiddleName = "Петрович",
			Birthday = new DateTime(2016, 12, 3),
			UniversitetGroup = group4
		};

		Student st8 = new()
		{
			Surname = "Камелотов",
			Name = "Михаил",
			MiddleName = "Васильевич",
			Birthday = new DateTime(2014, 3, 4),
			UniversitetGroup = group4
		};

		Student st9 = new()
		{
			Surname = "Бубликов",
			Name = "Стас",
			MiddleName = "Петрович",
			Birthday = new DateTime(2018, 1, 2),
			UniversitetGroup = group4
		};

		Student st10 = new()
		{
			Surname = "Крмаров",
			Name = "Иван",
			MiddleName = "Иванович",
			Birthday = new DateTime(2012, 11, 23),
			UniversitetGroup = group4
		};

		await db.AddRangeAsync(st1, st2, st3, st4, st5, st6, st7,st8,st9,st10);

		await db.SaveChangesAsync();
	}



	/// <summary>
	/// Поиск сущност в БД
	/// </summary>
	/// <typeparam name="TEntity"></typeparam>
	/// <param name="predicat">Условие поиска</param>
	/// <returns>Возвращаем (найденная сущность, Exception)</returns>
	public async Task<(TEntity? entity, Exception? ex)> FindEntityAsync<TEntity>(System.Linq.Expressions.Expression<Func<TEntity, bool>>? predicat)
	where TEntity : class
	{
		try
		{
			using var db = contextFactory.CreateDbContext();
			var result = await db.Set<TEntity>().FirstOrDefaultAsync(predicat);
			
			return (result, null);
		}
		catch (Exception ex)
		{
			return (null,ex);
		}
	}


	public async Task<List<TEntity>?> GetEntitiesAsync<TEntity>(System.Linq.Expressions.Expression<Func<TEntity, bool>>? predicat = null)
		where TEntity : class
	{
		try
		{
			using var db = contextFactory.CreateDbContext();
			var allEntities = db.Set<TEntity>().AsSplitQuery();
			if (predicat != null) allEntities = allEntities.Where(predicat);
			var result= await allEntities.ToListAsync();
			return result;
		}
		catch (Exception ex)
		{
			return null;
		}
	}

	/// <summary>
	/// Обновить сущность в БД
	/// </summary>
	/// <typeparam name="TEntity"></typeparam>
	/// <param name="entity"></param>
	/// <returns></returns>
	public async Task<Exception?> UpdateEntityAsync<TEntity>(TEntity entity)
	where TEntity : class
	{
		try
		{
			using var db = contextFactory.CreateDbContext();
			var result = db.Update<TEntity>(entity);
			var n = await db.SaveChangesAsync();
			return null;
		}
		catch (Exception ex)
		{
			return ex;
		}
	}

	/// <summary>
	/// Удалить сущность в БД
	/// </summary>
	/// <typeparam name="TEntity"></typeparam>
	/// <param name="entity"></param>
	/// <returns></returns>
	public async Task DelEntityAsync<TEntity>(TEntity entity)
	where TEntity : class, IHaveId
	{
		try
		{
			using var db = contextFactory.CreateDbContext();
			var find = await db.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == entity.Id);

			if (find != null)
			{
				db.Remove(find);
				await db.SaveChangesAsync();
			}
		}
		catch (Exception ex)
		{
		}
	}

	/// <summary>
	/// Сохранит для Группы добавляемый Предмет
	/// </summary>
	/// <param name="group">Группа</param>
	/// <param name="addedSubject">Добавляемый Предмет в группу</param>
	/// <returns></returns>
	public async Task<Exception?> SaveGroupAsync(UniversitetGroup group, Subject addedSubject)
	{
		try
		{
			using var db = contextFactory.CreateDbContext();

			//Ищем предмет в БД
			var subject = await db.Subjects.FirstOrDefaultAsync(x => x.Id == addedSubject.Id);
			if (subject == null) //если предмета нет в БД
				throw new Exception("Предмета нет в БД. Возможно он уже был кем-то удалён из БД");

			//ищем Группу в БД
			var findGroup = await db.UniversitetGroups.Include(x => x.Subjects)
									.FirstOrDefaultAsync(x => x.Id == group.Id);
			if (subject == null) //если Группы нет в БД
				throw new Exception("Группы нет в БД. Возможно она уже кем-то удалёна из БД");

			findGroup!.Subjects!.Add(subject);
			db.Update(findGroup);
			await db.SaveChangesAsync();
			return null;
		}
		catch (Exception ex)
		{
			return ex;
		}
	}

	/// <summary>
	/// Удалить Предмет из Группы
	/// </summary>
	/// <param name="group">Группа</param>
	/// <param name="addedSubject">Удаляемый Предмет из группу</param>
	/// <returns></returns>
	public async Task<Exception?> DelSubjectFromGroupAsync(UniversitetGroup group, Subject addedSubject)
	{
		try
		{
			using var db = contextFactory.CreateDbContext();

			//Ищем предмет в БД
			var subject = await db.Subjects.FirstOrDefaultAsync(x => x.Id == addedSubject.Id);
			if (subject == null) //если предмета нет в БД
				throw new Exception("Предмета нет в БД. Возможно он уже был кем-то удалён из БД");

			//ищем Группу в БД
			var findGroup = await db.UniversitetGroups.Include(x => x.Subjects)
									.FirstOrDefaultAsync(x => x.Id == group.Id);
			if (subject == null) //если Группы нет в БД
				throw new Exception("Группы нет в БД. Возможно она уже кем-то удалёна из БД");

			findGroup!.Subjects!.Remove(subject);
			db.Update(findGroup);
			await db.SaveChangesAsync();
			return null;
		}
		catch (Exception ex)
		{
			return ex;
		}
	}


	/// <summary>
	/// Выборка посещаемости студентами из выбранной Группы на выбранную Дату
	/// </summary>
	/// <param name="selectedGroup">Группа выборки</param>
	/// <param name="selectedLearningDate">Дата выборки</param>
	/// <returns></returns>
	public async Task<List<Attendance>?> GetAttendanceAsync(UniversitetGroup selectedGroup, LearningDate selectedLearningDate)
	{
		try
		{
			using var db = contextFactory.CreateDbContext();

			var students = await db.Students.Where(x => x.UniversitetGroupId == selectedGroup.Id)
				.Include(x => x.Attendances.Where(a => a.LearningDateId == selectedLearningDate.Id))
				.ToListAsync();

			List<Attendance> attendances = new();
			foreach (var student in students)
			{
				if (student.Attendances?.Count > 0)
				{
					var att = student.Attendances.FirstOrDefault(x => x.LearningDateId == selectedLearningDate.Id);
					attendances.Add(att!);
				}
				else
				{
					Attendance newAtt = new() 
					{ 
						StudentId= student.Id,
						Student = student, 
						LearningDate = selectedLearningDate,
						LearningDateId= selectedLearningDate.Id
					};
					attendances.Add(newAtt);
				}
			}
			return attendances;
		}
		catch (Exception ex)
		{
			return null;
		}
	}


	public async Task<Exception?> SaveAttendancesAsync(List<Attendance>? attendances )
	{
		if (attendances == null) return null;
		try
		{
			using var db = contextFactory.CreateDbContext();
			foreach (var item in attendances)
			{
				item.Student = null;
				item.LearningDate = null;
				db.Update(item);
			}
			//var result = db.Update(attendances);
			await db.SaveChangesAsync();
			return null;
		}
		catch (Exception ex)
		{
			return ex;
		}
	}


	/// <summary>
	/// Загружаем Студентов обущающихся в выбранной группе
	/// </summary>
	/// <param name="groupId"></param>
	/// <returns></returns>
	public async Task<List<Student>?> GetStudentsInGroupAsync(int groupId)
	{
		try
		{
			using var db = contextFactory.CreateDbContext();
			return  await db.Students .Where(x => x.UniversitetGroupId == groupId)
										.Include(x => x.Attendances)
										.ThenInclude(at => at.LearningDate)
										.ToListAsync();
		}
		catch (Exception ex)
		{
			return null;
		}
	}

	public async Task<List<SubjectScore>?> GetDatesAsync(SelectedDatasDTO dTO)
	{
		try
		{
			using var db = contextFactory.CreateDbContext();

			var sscore = db.SubjectScores
				.Include(x=>x.Student)
				.Include(x => x.Subject)
				.Include(x => x.LearningDate)
				.Include(x => x.TaskType)
				.AsSplitQuery();

			if (dTO.StartDate != null && dTO.EndDate != null)
				sscore = sscore.Where(x => x.LearningDate.Date >= dTO.StartDate && x.LearningDate.Date <= dTO.EndDate);

			if (dTO.SelectedGroup != null && dTO.SelectedStudent == null)
			{ // оценки всех студентов из группы
				sscore = sscore.Where(x => x.Student.UniversitetGroupId == dTO.SelectedGroup.Id);
			}

			if (dTO.SelectedStudent != null)
				sscore = sscore.Where(x => x.StudentId== dTO.SelectedStudent.Id);

			if (dTO.SelectedTaskType != null)
				sscore = sscore.Where(x => x.TaskTypeId == dTO.SelectedTaskType.Id);



			//return await db.Students.Where(x => x.UniversitetGroupId == groupId)
			//							.Include(x => x.Attendances)
			//							.ThenInclude(at => at.LearningDate)
			//							.ToListAsync();

			var result = await sscore.ToListAsync();
			return result;

		}
		catch (Exception ex)
		{
			return null;
		}
	}


	public async Task<List<UniversitetGroup>?> GetGroupsAsync()
	{
		try
		{
			using var db = contextFactory.CreateDbContext();
			var allEntities = db.UniversitetGroups
				.Include(x=>x.Students)
				.Include(x=>x.Subjects)
				.AsSplitQuery();

			var result = await allEntities.ToListAsync();
			return result;
		}
		catch (Exception ex)
		{
			return null;
		}
	}
}
