using System.Text;

namespace Ex03.GarageLogic.Api.Utils
{
	public static class StringUtils
	{
		public static string SpreadStringByCapitalLetters(string i_String)
		{
			StringBuilder result = new StringBuilder();

			foreach (char currentChar in i_String)
			{
				if (char.IsUpper(currentChar) && (result.Length > 0))
				{
					result.Append(' ');
				}

				result.Append(currentChar);
			}

			return result.ToString();
		}

		public static string SpreadStringByCapitalLettersOrNumber(string i_String)
		{
			StringBuilder result = new StringBuilder();
			bool isDigit = false;

			foreach (char currentChar in i_String)
			{
				if (result.Length > 0)
				{
					if (char.IsDigit(currentChar))
					{
						if (!isDigit)
						{
							isDigit = true;
							result.Append(' ');
						}
					}
					else
					{
						isDigit = false;
						if (char.IsUpper(currentChar))
						{
							result.Append(' ');
						}
					}
				}

				result.Append(currentChar);
			}

			return result.ToString();
		}
	}
}