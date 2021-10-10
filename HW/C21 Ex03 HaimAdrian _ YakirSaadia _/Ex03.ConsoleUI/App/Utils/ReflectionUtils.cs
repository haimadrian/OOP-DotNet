using System;
using System.Reflection;
using Ex03.GarageLogic.Api.Utils;
using Ex03.UserInputUtils;

namespace Ex03.ConsoleUI.App.Utils
{
	internal static class ReflectionUtils
	{
		public static void FillInPublicInstancePropertiesFromConsole(object i_Object)
		{
			const bool v_IsPublicSetterOnly = true;
			const bool v_ShowExistingValue = true;

			FillInInstancePropertiesFromConsole(i_Object, v_IsPublicSetterOnly, !v_ShowExistingValue);
		}

		public static void FillInInstancePropertiesFromConsole(object i_Object, bool i_IsPublicSetterOnly, bool i_ShowExistingValue)
		{
			PropertyInfo[] vehicleProperties = i_Object.GetType().GetProperties();

			foreach (PropertyInfo currentProperty in vehicleProperties)
			{
				MethodInfo setter = currentProperty.GetSetMethod(!i_IsPublicSetterOnly);
				if ((setter != null) && !setter.IsStatic && (!i_IsPublicSetterOnly || setter.IsPublic))
				{
					bool tryAgain;
					do
					{
						try
						{
							object value = ReadInputForProperty(i_Object, currentProperty, i_ShowExistingValue);
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

		public static object ReadInputForProperty(object i_Object, PropertyInfo i_Property, bool i_ShowExistingValue)
		{
			object value;
			string propertyName = GetMemberDisplayName(i_Property);
			string existingValue = i_ShowExistingValue ? getPropertyValueAsString(i_Object, i_Property) : string.Empty;
			string inputMessage = string.Format("Please enter {0}: {1}", propertyName, existingValue);

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
					userInput = ConsoleReader.ReadUserInputWithValidation(
						string.Format("{0}({1}/{2}) ", inputMessage, bool.TrueString, bool.FalseString),
						isBoolean);
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
					value = ConsoleReader.ReadEnumInputWithValidation(string.Format("Please select {0}: {1}", propertyName, existingValue), propertyType);
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

		public static string GetMemberDisplayName(MemberInfo i_MemberInfo)
		{
			return StringUtils.SpreadStringByCapitalLetters(i_MemberInfo.Name);
		}

		private static string getPropertyValueAsString(object i_Object, PropertyInfo i_Property)
		{
			string existingValue;
			try
			{
				object currentValue = i_Property.GetValue(i_Object, null);
				currentValue = currentValue == null ? "null" : currentValue.ToString();

				existingValue = string.Format("(Current value: {0}) ", currentValue);
			}
			catch (Exception)
			{
				existingValue = "(Current value: Unable to read value...) ";
			}

			return existingValue;
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