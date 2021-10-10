using System;
using NUnit.Framework;
using Ex03.GarageLogic.Api.Controllers;

namespace Ex03.UnitTests
{
	[TestFixture]
	public class FormatExceptionTest
	{
		[Test]
		public void TestCustomerNameValidation_UseNonAlphabeticName_FormatException()
		{
			// Act
			Exception e = null;
			try
			{
				GarageController.Instance.GetOrCreateCustomer("Haim2", "050-1234321");
			}
			catch (FormatException exception)
			{
				e = exception;
			}

			// Assert
			Assert.NotNull(e, "We are supposed to receive FormatException when name is not alphabetic only");
		}

		[Test]
		public void TestCustomerNameValidation_UseEmptyName_FormatException()
		{
			// Act
			Exception e = null;
			try
			{
				GarageController.Instance.GetOrCreateCustomer(string.Empty, "050-1234321");
			}
			catch (FormatException exception)
			{
				e = exception;
			}

			// Assert
			Assert.NotNull(e, "We are supposed to receive FormatException when name is empty");
		}

		[Test]
		public void TestCustomerNameValidation_UseAlphabeticNameWithScore_Success()
		{
			// Act
			Exception e = null;
			try
			{
				GarageController.Instance.GetOrCreateCustomer("Haim-Adrian", "050-1234321");
			}
			catch (FormatException exception)
			{
				e = exception;
			}

			// Assert
			Assert.Null(e, "We are not supposed to receive FormatException when name is alphabetic only, with '-'");
		}

		[Test]
		public void TestCustomerPhoneValidation_UseTooShortNumber_FormatException()
		{
			// Act
			Exception e = null;
			try
			{
				GarageController.Instance.GetOrCreateCustomer("Haim", "0-13");
			}
			catch (FormatException exception)
			{
				e = exception;
			}

			// Assert
			Assert.NotNull(e, "We are supposed to receive FormatException when phone number is too short");
		}

		[Test]
		public void TestCustomerPhoneValidation_UseTooLongNumber_FormatException()
		{
			// Act
			Exception e = null;
			try
			{
				GarageController.Instance.GetOrCreateCustomer("Haim", "055-1234567891011");
			}
			catch (FormatException exception)
			{
				e = exception;
			}

			// Assert
			Assert.NotNull(e, "We are supposed to receive FormatException when phone number is too long");
		}

		[Test]
		public void TestCustomerPhoneValidation_UseIllegalNumber_FormatException()
		{
			// Act
			Exception e = null;
			try
			{
				GarageController.Instance.GetOrCreateCustomer("Haim", "055-123f1011");
			}
			catch (FormatException exception)
			{
				e = exception;
			}

			// Assert
			Assert.NotNull(e, "We are supposed to receive FormatException when phone number contains alphabetic characters");
		}

		[Test]
		public void TestCustomerPhoneValidation_UseLegalNumbers_Success()
		{
			// Act
			Exception e = null;
			try
			{
				GarageController.Instance.GetOrCreateCustomer("Haim", "055-1234567");
				GarageController.Instance.GetOrCreateCustomer("Haim", "+972-055-123-4567");
				GarageController.Instance.GetOrCreateCustomer("Haim", "+972 055 123 4567");
				GarageController.Instance.GetOrCreateCustomer("Haim", "(972) 055 123 4567");
				GarageController.Instance.GetOrCreateCustomer("Haim", "(972) 55 123 4567");
				GarageController.Instance.GetOrCreateCustomer("Haim", "(972) 551234567");
				GarageController.Instance.GetOrCreateCustomer("Haim", "(972) 55-1234567");
				GarageController.Instance.GetOrCreateCustomer("Haim", "972 (055) 1234567");
			}
			catch (FormatException exception)
			{
				e = exception;
			}

			// Assert
			Assert.Null(e, "We are not supposed to receive FormatException when phone number is valid");
		}

		[Test]
		public void TestLicenseNumberValidation_UseIllegalNumber_FormatException()
		{
			// Act
			Exception e = null;
			try
			{
				TestUtils.CreateElectricMotorcycle("111-1&1-111");
			}
			catch (FormatException exception)
			{
				e = exception;
			}

			// Assert
			Assert.NotNull(e, "We are supposed to receive FormatException when license number is invalid");
		}

		[Test]
		public void TestBrandNameValidation_UseIllegalBrand_FormatException()
		{
			// Act
			Exception e = null;
			try
			{
				TestUtils.CreateElectricMotorcycle("Illegal #Brand name", "111-111-111");
			}
			catch (FormatException exception)
			{
				e = exception;
			}

			// Assert
			Assert.NotNull(e, "We are supposed to receive FormatException when license number is invalid");
		}
	}
}
