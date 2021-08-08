using System;
using System.Text;

namespace Ex03.UserInputUtils
{
	public delegate bool UserInputValidationDelegate(string i_InputString);

	public class ConsoleReader
	{
		public static string ReadUserInputWithValidation(string i_UserInputRequestMessage, UserInputValidationDelegate i_IsInputValidFunc)
		{
			string userInput;

			if (!string.IsNullOrEmpty(i_UserInputRequestMessage))
			{
				Console.Write(i_UserInputRequestMessage);
			}

			while (!i_IsInputValidFunc(userInput = Console.ReadLine()))
			{
				Console.Write("Illegal input. Try again: ");
			}

			return userInput;
		}

		public static object ReadEnumInputWithValidation(string i_UserInputRequestMessage, Type i_EnumType)
		{
			string userInput;

			StringBuilder inputMessage = new StringBuilder();

			if (!string.IsNullOrEmpty(i_UserInputRequestMessage))
			{
				inputMessage.AppendLine(i_UserInputRequestMessage);
			}
			else
			{
				inputMessage.AppendLine("Please select one of the choices below:");
			}
			
			foreach (int currentItem in Enum.GetValues(i_EnumType))
			{
				inputMessage.Append(currentItem).Append(". ").AppendLine(Enum.ToObject(i_EnumType, currentItem).ToString());
			}

			Console.Write(inputMessage.ToString());

			while (!isEnumInputValid(i_EnumType, userInput = Console.ReadLine()))
			{
				Console.Write("Illegal input. Try again: ");
			}

			return Enum.ToObject(i_EnumType, int.Parse(userInput));
		}

		private static bool isEnumInputValid(Type i_EnumType, string i_UserInput)
		{
			int choice = 0;
			bool isValid = !string.IsNullOrEmpty(i_UserInput) && int.TryParse(i_UserInput, out choice);

			if (isValid)
			{
				try
				{
					isValid = Enum.IsDefined(i_EnumType, choice);
				}
				catch (Exception)
				{
					isValid = false;
				}
			}

			return isValid;
		}
	}
}