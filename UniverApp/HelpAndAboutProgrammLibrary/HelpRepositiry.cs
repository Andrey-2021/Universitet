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
			using (FileStream fs = new FileStream(aboutProgrammFileName, FileMode.OpenOrCreate))
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
