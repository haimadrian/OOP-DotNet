using System;
using System.Text.RegularExpressions;

namespace Ex03.GarageLogic.Api.Utils
{
	public static class FormatValidations
	{
		private const int k_MinPhoneNumberLength = 4;

		private const int k_MaxPhoneNumberLength = 13;

		private static readonly Regex sr_AlphabeticRegex = new Regex("^[A-Za-z- ]+$", RegexOptions.Compiled);

		private static readonly Regex sr_AlphaNumericRegex = new Regex("^[\\w\\d-]+$", RegexOptions.Compiled);

		private static readonly Regex sr_PhoneNumberRegex = new Regex("^\\+?(\\d[\\d- ]+)?(\\([\\d- ]+\\))?[\\d- ]+\\d$", RegexOptions.Compiled);

		public static void ValidateAlphabeticFormat(string i_TextToValidate, string i_ParameterName)
		{
			if (string.IsNullOrEmpty(i_TextToValidate) || !sr_AlphabeticRegex.IsMatch(i_TextToValidate))
			{
				string attributeDetails = string.Empty;

				if (!string.IsNullOrEmpty(i_ParameterName))
				{
					attributeDetails = string.Format(" Attribute: {0},", i_ParameterName);
				}

				throw new FormatException(string.Format("Input was not a legal Alphabetic format.{0}  Was: {1}", attributeDetails, i_TextToValidate));
			}
		}

		public static void ValidateAlphaNumericFormat(string i_TextToValidate, string i_ParameterName)
		{
			if (string.IsNullOrEmpty(i_TextToValidate) || !sr_AlphaNumericRegex.IsMatch(i_TextToValidate))
			{
				string attributeDetails = string.Empty;

				if (!string.IsNullOrEmpty(i_ParameterName))
				{
					attributeDetails = string.Format(" Attribute: {0},", i_ParameterName);
				}

				throw new FormatException(string.Format("Input was not a legal AlphaNumeric format.{0}  Was: {1}", attributeDetails, i_TextToValidate));
			}
		}

		public static void ValidatePhoneNumberFormat(string i_TextToValidate, string i_ParameterName)
		{
			if (!IsValidPhoneNumber(i_TextToValidate))
			{
				string attributeDetails = string.Empty;

				if (!string.IsNullOrEmpty(i_ParameterName))
				{
					attributeDetails = string.Format(" Attribute: {0},", i_ParameterName);
				}

				throw new FormatException(
					string.Format(
						"Input was not a legal Phone format.{0}  Was: {1}. (Minimum Digits={2}, Maximum Digits={3})",
						attributeDetails,
						i_TextToValidate,
						k_MinPhoneNumberLength,
						k_MaxPhoneNumberLength));
			}
		}

		public static bool IsAlphabetic(string i_TextToValidate)
		{
			return !string.IsNullOrEmpty(i_TextToValidate) && sr_AlphabeticRegex.IsMatch(i_TextToValidate);
		}

		public static bool IsAlphaNumeric(string i_TextToValidate)
		{
			return !string.IsNullOrEmpty(i_TextToValidate) && sr_AlphaNumericRegex.IsMatch(i_TextToValidate);
		}

		public static bool IsValidPhoneNumber(string i_TextToValidate)
		{
			int digitsCount = countDigitsInString(i_TextToValidate);

			return !string.IsNullOrEmpty(i_TextToValidate) &&
				   sr_PhoneNumberRegex.IsMatch(i_TextToValidate) &&
				   (digitsCount >= k_MinPhoneNumberLength) &&
				   (digitsCount <= k_MaxPhoneNumberLength);
		}

		private static int countDigitsInString(string i_String)
		{
			int count = 0;

			if (!string.IsNullOrEmpty(i_String))
			{
				foreach (char currentChar in i_String)
				{
					if (char.IsDigit(currentChar))
					{
						count++;
					}
				}
			}

			return count;
		}
	}
}
