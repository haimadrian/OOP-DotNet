using System;

namespace C21_Ex01_6
{
	public class Program
	{
		private const int k_InputLength = 9;
		private const byte k_DigitDividedBy = 3;

		public static void Main()
		{
			RunNumberStatistics();
			Console.WriteLine("Please press 'Enter' to exit...");
			Console.ReadLine();
		}

		public static void RunNumberStatistics()
		{
			string userInput = readUserInputWithValidation();
			collectAndPrintNumberStatistics(userInput);
		}

		private static void collectAndPrintNumberStatistics(string i_UserInput)
		{
			byte maximumDigit = 0;
			int digitsSum = 0;
			int amountOfDigitsDividedBy = 0;
			int amountOfDigitsBelowRightmostDigit = 0;
			byte rightmostDigit = characterToByte(i_UserInput[i_UserInput.Length - 1]);

			for (int currentDigitIndex = 0; currentDigitIndex < i_UserInput.Length; currentDigitIndex++)
			{
				byte currentDigit = characterToByte(i_UserInput[currentDigitIndex]);
				maximumDigit = Math.Max(maximumDigit, currentDigit);
				digitsSum += currentDigit;
				amountOfDigitsDividedBy += isDigitDividedBy(currentDigit) ? 1 : 0;
				amountOfDigitsBelowRightmostDigit += currentDigit < rightmostDigit ? 1 : 0;
			}

			printDetailedOutput(maximumDigit, digitsSum / (double)i_UserInput.Length, amountOfDigitsDividedBy, amountOfDigitsBelowRightmostDigit);
		}

		private static void printDetailedOutput(
			byte i_MaximumDigit,
			double i_AverageOfDigits,
			int i_AmountOfDigitsDividedBy,
			int i_AmountOfDigitsLessThanRightmostDigit)
		{
			Console.WriteLine(
@"
   Statistics
-----------------
Maximum digit is: {0}
Average of digits is: {1}
Amount of digits divided by {2} is: {3}
Amount of digits less than rightmost digit is: {4}",
				i_MaximumDigit,
				i_AverageOfDigits,
				k_DigitDividedBy,
				i_AmountOfDigitsDividedBy,
				i_AmountOfDigitsLessThanRightmostDigit);
		}

		private static bool isDigitDividedBy(byte i_NumberToTest)
		{
			return i_NumberToTest % k_DigitDividedBy == 0;
		}

		private static string readUserInputWithValidation()
		{
			string userInput;
			Console.Write("Please Enter {0}-digits natural number: ", k_InputLength);

			while ((userInput = Console.ReadLine()) == null || !isNaturalNumber(userInput))
			{
				Console.Write("Illegal input. Try again: ");
			}

			return userInput;
		}

		private static bool isNaturalNumber(string i_UserInput)
		{
			int inputNumber;
			return (i_UserInput.Length == k_InputLength) && int.TryParse(i_UserInput, out inputNumber) && (inputNumber >= 0);
		}

		private static byte characterToByte(char i_Character)
		{
			return (byte)char.GetNumericValue(i_Character);
		}
	}
}