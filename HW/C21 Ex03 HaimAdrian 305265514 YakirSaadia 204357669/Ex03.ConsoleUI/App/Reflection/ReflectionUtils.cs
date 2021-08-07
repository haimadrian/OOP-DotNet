using System;
using System.Reflection;
using System.Text;
using Ex03.UserInputUtils;

namespace Ex03.ConsoleUI.App.Reflection
{
	internal static class ReflectionUtils
	{
		public static void FillInPublicInstancePropertiesFromConsole(object i_Object)
		{
			PropertyInfo[] vehicleTypes = i_Object.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

			foreach (PropertyInfo currentProperty in vehicleTypes)
			{
				if (currentProperty.CanWrite)
				{
					bool tryAgain;
					do
					{
						try
						{
							object value = ReadInputForProperty(currentProperty);
							currentProperty.SetValue(i_Object, value, null);
							tryAgain = false;
						}
						catch (Exception e)
						{
							tryAgain = true;
							Console.WriteLine("Wrong input. Reason: {0}", e.InnerException != null ? e.InnerException.Message : e.Message);
						}
					}
					while (tryAgain);
				}
			}
		}

		public static object ReadInputForProperty(PropertyInfo i_Property)
		{
			object value;
			string propertyName = splitStringByCapitalLetters(i_Property.Name);
			string inputMessage = string.Format("Please enter {0}: ", propertyName);

			do
			{
				string userInput;
				Type propertyType = i_Property.PropertyType;

				if (propertyType == typeof(int))
				{
					userInput = ConsoleReader.ReadUserInputWithValidation(inputMessage, isInteger);
					value = int.Parse(userInput);
				}
				else if (propertyType == typeof(float))
				{
					userInput = ConsoleReader.ReadUserInputWithValidation(inputMessage, isFloat);
					value = float.Parse(userInput);
				}
				else if (propertyType == typeof(bool))
				{
					userInput = ConsoleReader.ReadUserInputWithValidation(inputMessage, isBoolean);
					value = bool.Parse(userInput);
				}
				else if (propertyType == typeof(double))
				{
					userInput = ConsoleReader.ReadUserInputWithValidation(inputMessage, isDouble);
					value = double.Parse(userInput);
				}
				else if (propertyType == typeof(byte))
				{
					userInput = ConsoleReader.ReadUserInputWithValidation(inputMessage, isByte);
					value = byte.Parse(userInput);
				}
				else if (propertyType == typeof(short))
				{
					userInput = ConsoleReader.ReadUserInputWithValidation(inputMessage, isShort);
					value = short.Parse(userInput);
				}
				else if (propertyType == typeof(char))
				{
					userInput = ConsoleReader.ReadUserInputWithValidation(inputMessage, isChar);
					value = char.Parse(userInput);
				}
				else if (propertyType.IsEnum)
				{
					value = ConsoleReader.ReadEnumInputWithValidation(string.Format("Please select {0}:", propertyName), propertyType);
				}
				else if (propertyType.IsValueType)
				{
					// Currently we set default value to structs.
					value = Activator.CreateInstance(propertyType);
				}
				else
				{
					Console.WriteLine(inputMessage);
					value = Console.ReadLine();
				}
			}
			while (value == null);

			return value;
		}

		private static string splitStringByCapitalLetters(string i_String)
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

		private static bool isInteger(string i_UserInput)
		{
			int ignore;
			return !string.IsNullOrEmpty(i_UserInput) && int.TryParse(i_UserInput, out ignore);
		}

		private static bool isFloat(string i_UserInput)
		{
			float ignore;
			return !string.IsNullOrEmpty(i_UserInput) && float.TryParse(i_UserInput, out ignore);
		}

		private static bool isDouble(string i_UserInput)
		{
			double ignore;
			return !string.IsNullOrEmpty(i_UserInput) && double.TryParse(i_UserInput, out ignore);
		}

		private static bool isBoolean(string i_UserInput)
		{
			bool ignore;
			return !string.IsNullOrEmpty(i_UserInput) && bool.TryParse(i_UserInput, out ignore);
		}

		private static bool isByte(string i_UserInput)
		{
			byte ignore;
			return !string.IsNullOrEmpty(i_UserInput) && byte.TryParse(i_UserInput, out ignore);
		}

		private static bool isShort(string i_UserInput)
		{
			short ignore;
			return !string.IsNullOrEmpty(i_UserInput) && short.TryParse(i_UserInput, out ignore);
		}

		private static bool isChar(string i_UserInput)
		{
			char ignore;
			return !string.IsNullOrEmpty(i_UserInput) && char.TryParse(i_UserInput, out ignore);
		}
	}
}
