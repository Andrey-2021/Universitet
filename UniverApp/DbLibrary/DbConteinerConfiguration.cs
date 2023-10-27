namespace DbLibrary;

/// <summary>
/// Добавляем БД в контейнер
/// </summary>
public class DbConteinerConfiguration
{
	/// <summary>
	/// Добавляем контекст MsSQL или MySQL в качестве сервиса в приложение
	/// </summary>
	/// <param name="services"></param>
	/// <returns></returns>
	/// <exception cref="Exception"></exception>
	public static void AddToServiceCollection(IServiceCollection services)
	{
		var connectionConfig = JSonConnectionString.GetConnectionSetting();

		switch (connectionConfig.server.ToUpper())
		{
			case "MSSQL":
				services.AddDbContextFactory<SqlDbContext>
				(
					options => options.UseSqlServer(connectionConfig.connectionString
													// описание  EnableRetryOnFailure -  https://makolyte.com/how-to-do-retries-in-ef-core/
													, options => { options.EnableRetryOnFailure(); }
													)
					);
				break;
			case "MYSQL":
				
				services.AddDbContextFactory<SqlDbContext>
				// (options => options.UseMySQL(connectionConfig.connectionString));
				(options => options.UseMySql(connectionConfig.connectionString,
												new MySqlServerVersion(new Version(8, 0, 34))
											 //,
											 //options => options.EnableRetryOnFailure(
											 //    maxRetryCount: 5,
											 //    maxRetryDelay: System.TimeSpan.FromSeconds(30),
											 //    errorNumbersToAdd: null
											 //    )
											 )
				);
				break;
			default:
				throw new Exception("Нет настроенной БД");
		}
		//return services;
	}
}
