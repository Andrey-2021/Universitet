using System.Text.Json;
using System;
namespace HelpAndAboutProgrammLibrary;

public class HelpRepositiry
{
	const string helpFileName = "Help.json";
	const string aboutProgrammFileName = "AboutProgramm.json";

	/// <summary>
	/// Получить помощь
	/// </summary>
	/// <returns></returns>
	public static async Task<Help?> GetHelpAsync()
	{
		try
		{
			using (FileStream fs = new FileStream(helpFileName, FileMode.OpenOrCreate))
			{
				var s = fs;
				var help = await JsonSerializer.DeserializeAsync<Help>(fs);
				return help;
			}
		}
		catch (Exception)
		{
			return new Help() { Part1 = "Помощь отсутствует" };
		}
	}

	/// <summary>
	/// Получить информацию о программе
	/// </summary>
	/// <returns></returns>
	public static async Task<AboutProgramm?> GetAboutProgrammAsync()
	{
		try
		{
			//var path = Directory.GetCurrentDirectory();
			//string directory = Environment.CurrentDirectory;
			string appDirectory = AppDomain.CurrentDomain.BaseDirectory;
			var result = Path.Combine(appDirectory, aboutProgrammFileName);

			using (FileStream fs = new FileStream(result, FileMode.OpenOrCreate))
			{
				var about = await JsonSerializer.DeserializeAsync<AboutProgramm>(fs);
				return about;
			}
		}
		catch (Exception)
		{
			return new AboutProgramm() { Text = "Информация о программе отсутствует" };
		}
	}
}
