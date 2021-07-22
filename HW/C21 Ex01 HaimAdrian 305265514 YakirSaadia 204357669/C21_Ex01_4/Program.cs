using System;
using System.Text;
using System.Text.RegularExpressions;

namespace C21_Ex01_4
{
	public class Program
	{
		private const int k_InputLength = 8;
		private const int k_NumericDividedBy = 4;
		private static readonly Regex sr_AlphabeticRegex = new Regex("^[a-zA-Z]+$", RegexOptions.Compiled);

		public static void Main()
		{
			RunStringAnalysis();
			Console.WriteLine("Please press 'Enter' to exit...");
			Console.ReadLine();
		}

		public static void RunStringAnalysis()
		{
			string userInput = readUserInputSafe();

			string isOrIsNotString = isPalindrome(userInput) ? string.Empty : "not ";
			StringBuilder analysisString = new StringBuilder(string.Format("Input is {0}a palindrome.", isOrIsNotString)).AppendLine();
			int inputNumber;
			if (int.TryParse(userInput, out inputNumber))
			{
				numericInputHandler(analysisString, userInput, inputNumber);
			}
			else
			{
				alphabeticInputHandler(analysisString, userInput);
			}

			Console.WriteLine(
@"
    Analysis
-----------------
{0}",
				analysisString);
		}

		private static void numericInputHandler(StringBuilder i_AnalysisString, string i_UserInput, int i_InputNumber)
		{
			i_AnalysisString.Append(
				string.Format(
@"{0} is numeric.
Input number is {1}divided by {2}",
					i_UserInput,
					isNumericDividedBy(i_InputNumber) ? string.Empty : "not ",
					k_NumericDividedBy));
		}

		private static void alphabeticInputHandler(StringBuilder i_AnalysisString, string i_UserInput)
		{
			i_AnalysisString.Append(
				string.Format(
@"{0} is alphabetic.
Amount of uppercase characters: {1}",
					i_UserInput,
					countUpperCaseCharacters(i_UserInput)));
		}

		private static bool isPalindrome(string i_StringToTest)
		{
			bool isPalindrome = true;

			if (i_StringToTest.Length >= 2)
			{
				isPalindrome = (i_StringToTest[0] == i_StringToTest[i_StringToTest.Length - 1]) &&
							   Program.isPalindrome(i_StringToTest.Substring(1, i_StringToTest.Length - 2));
			}

			return isPalindrome;
		}

		private static bool isNumericDividedBy(int i_NumberToTest)
		{
			return i_NumberToTest % k_NumericDividedBy == 0;
		}

		private static int countUpperCaseCharacters(string i_StringToScan)
		{
			int upperCaseCount = 0;

			foreach (char currentCharacter in i_StringToScan)
			{
				if (char.IsUpper(currentCharacter))
				{
					upperCaseCount++;
				}
			}

			return upperCaseCount;
		}

		private static string readUserInputSafe()
		{
			string userInput;
			Console.Write("Please Enter {0}-characters string, consists of alphabetic characters only, or digits only: ", k_InputLength);

			while ((userInput = Console.ReadLine()) == null || !isValidUserInput(userInput))
			{
				Console.Write("Illegal input. Try again: ");
			}

			return userInput;
		}

		private static bool isValidUserInput(string i_UserInput)
		{
			int ignored;
			return (i_UserInput.Length == k_InputLength) && (int.TryParse(i_UserInput, out ignored) || sr_AlphabeticRegex.IsMatch(i_UserInput));
		}
	}
}