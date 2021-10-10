using System;
using System.Text;
using System.Text.RegularExpressions;

namespace C21_Ex01_1
{
	public class Program
	{
		private const int k_AmountOfBinaryNumbers = 3;
		private const int k_BinaryBase = 2;
		private const int k_BinaryInputLength = 9;
		private const char k_BinaryInputZero = '0';
		private const char k_BinaryInputOne = '1';

		// Binary number must contain one or more 0 / 1 digits only, begin (^) and end ($)
		private static readonly Regex sr_BinaryInputRegex = new Regex("^[0-1]+$", RegexOptions.Compiled);

		public static void Main()
		{
			RunBinaryInput();
			Console.WriteLine("Please press 'Enter' to exit...");
			Console.ReadLine();
		}

		public static void RunBinaryInput()
		{
			StringBuilder numbersOutput = new StringBuilder();
			int amountOfZeroesInAllInputs = 0;
			int amountOfOnesInAllInputs = 0;
			int powersOfTwoCount = 0;
			int monotonicallyAscendingSeriesCount = 0;
			int maximumNumber = int.MinValue;
			int minimumNumber = int.MaxValue;

			Console.WriteLine("Please enter {0} binary numbers, with {1} digits each:", k_AmountOfBinaryNumbers, k_BinaryInputLength);
			for (int currentInputIndex = 0; currentInputIndex < k_AmountOfBinaryNumbers; currentInputIndex++)
			{
				string binaryInputString = readUserInputWithValidation();
				int inputNumber = parseBinaryStringToInt(binaryInputString);

				if (numbersOutput.Length > 0)
				{
					numbersOutput.Append(", ");
				}

				numbersOutput.Append(inputNumber);

				int amountOfZeroes, amountOfOnes;
				countZeroAndOneOccurrencesInString(binaryInputString, out amountOfZeroes, out amountOfOnes);
				amountOfZeroesInAllInputs += amountOfZeroes;
				amountOfOnesInAllInputs += amountOfOnes;
				powersOfTwoCount += isPowerOfTwo(inputNumber) ? 1 : 0;
				monotonicallyAscendingSeriesCount += isMonotonicallyAscendingSeries(inputNumber) ? 1 : 0;
				maximumNumber = Math.Max(maximumNumber, inputNumber);
				minimumNumber = Math.Min(minimumNumber, inputNumber);
			}

			printDetailedOutput(
				numbersOutput.ToString(),
				amountOfZeroesInAllInputs / (double)k_AmountOfBinaryNumbers,
				amountOfOnesInAllInputs / (double)k_AmountOfBinaryNumbers,
				powersOfTwoCount,
				monotonicallyAscendingSeriesCount,
				maximumNumber,
				minimumNumber);
		}

		private static void printDetailedOutput(
			string i_NumbersOutput,
			double i_AverageOfZeroesInAllInputs,
			double i_AverageOfOnesInAllInputs,
			int i_PowersOfTwoCount,
			int i_MonotonicallyAscendingSeriesCount,
			int i_MaximumNumber,
			int i_MinimumNumber)
		{
			Console.WriteLine(
@"
The numbers are: {0}

   Statistics
-----------------
Average number of 0 digits: {1}
Average number of 1 digits: {2}
Amount of powers of 2: {3}
Amount of monotonically ascending series (decimal digits): {4}
Maximum number is: {5}
Minimum number is: {6}",
				i_NumbersOutput,
				i_AverageOfZeroesInAllInputs,
				i_AverageOfOnesInAllInputs,
				i_PowersOfTwoCount,
				i_MonotonicallyAscendingSeriesCount,
				i_MaximumNumber,
				i_MinimumNumber);
		}

		private static string readUserInputWithValidation()
		{
			string userInput;

			while ((userInput = Console.ReadLine()) == null || !isValidBinaryString(userInput))
			{
				Console.Write("Illegal input. Try again: ");
			}

			return userInput;
		}

		private static bool isValidBinaryString(string i_BinaryUserInput)
		{
			string trimmedBinaryUserInput = i_BinaryUserInput.Trim();

			return (trimmedBinaryUserInput.Length == k_BinaryInputLength) && sr_BinaryInputRegex.IsMatch(trimmedBinaryUserInput);
		}

		private static int parseBinaryStringToInt(string i_BinaryString)
		{
			int number = 0;
			int currentPowerOfTwo = 1;
			
			for (int currentDigitPower = 0; currentDigitPower < i_BinaryString.Length; currentDigitPower++, currentPowerOfTwo *= k_BinaryBase)
			{
				char currentDigitInRightToLeftOrder = i_BinaryString[i_BinaryString.Length - 1 - currentDigitPower];
				if (k_BinaryInputOne == currentDigitInRightToLeftOrder)
				{
					number += currentPowerOfTwo;
				}
			}

			return number;
		}

		private static void countZeroAndOneOccurrencesInString(string i_StringToScan, out int o_ZeroesCount, out int o_OnesCount)
		{
			o_ZeroesCount = 0;
			o_OnesCount = 0;

			foreach (char currentChar in i_StringToScan)
			{
				switch (currentChar)
				{
					case k_BinaryInputZero:
						o_ZeroesCount++;
						break;
					case k_BinaryInputOne:
						o_OnesCount++;
						break;
				}
			}
		}

		private static bool isPowerOfTwo(int i_NumberToTest)
		{
			double log = Math.Log(i_NumberToTest, k_BinaryBase);
			return (log - Math.Floor(log)) == 0;
		}

		private static bool isMonotonicallyAscendingSeries(int i_NumberToTest)
		{
			bool isMonotonicallyIncreasingSeries = true;

			while (isMonotonicallyIncreasingSeries && (i_NumberToTest > 9))
			{
				int currentRightmostDigit = i_NumberToTest % 10;
				i_NumberToTest /= 10;

				// Once the rightmost digit is lower or equal to the digit left to it, we get false here and loop stops.
				isMonotonicallyIncreasingSeries = currentRightmostDigit > (i_NumberToTest % 10);
			}

			return isMonotonicallyIncreasingSeries;
		}
	}
}