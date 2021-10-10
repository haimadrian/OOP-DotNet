using Ex03.GarageLogic.Api.Garage;
using Ex03.GarageLogic.Api.Utils;

namespace Ex03.GarageLogic.Core.Garage
{
	internal class Customer : ICustomer
	{
		private readonly string r_Name;
		private readonly string r_Phone;

		public Customer(string i_Name, string i_Phone)
		{
			FormatValidations.ValidateAlphabeticFormat(i_Name, "Name");
			FormatValidations.ValidatePhoneNumberFormat(i_Phone, "Phone");

			r_Name = i_Name;
			r_Phone = i_Phone;
		}

		public string Name
		{
			get
			{
				return r_Name;
			}
		}

		public string Phone
		{
			get
			{
				return r_Phone;
			}
		}

		public static bool operator ==(Customer i_Customer1, ICustomer i_Customer2)
		{
			return (ReferenceEquals(i_Customer1, null) && ReferenceEquals(i_Customer2, null)) ||
				   (!ReferenceEquals(i_Customer1, null) && i_Customer1.Equals(i_Customer2));
		}

		public static bool operator !=(Customer i_Customer1, ICustomer i_Customer2)
		{
			return !(i_Customer1 == i_Customer2);
		}

		public override bool Equals(object i_Another)
		{
			bool equals = false;

			ICustomer anotherCustomer = i_Another as ICustomer;
			if (!ReferenceEquals(anotherCustomer, null))
			{
				equals = (Name == anotherCustomer.Name) && (Phone == anotherCustomer.Phone);
			}

			return equals;
		}

		public override int GetHashCode()
		{
			// HashCode.Combine....
			int hash = 17;
			hash = (hash * 31) + Name.GetHashCode();
			hash = (hash * 31) + Phone.GetHashCode();

			return hash;
		}

		public override string ToString()
		{
			return string.Format("Name={0}, Phone={1}", Name, Phone);
		}
	}
}
