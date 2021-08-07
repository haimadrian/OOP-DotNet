using System.Collections.Generic;
using Ex03.GarageLogic.Api.Vehicle;
using Ex03.GarageLogic.Api.Utils;
using Ex03.GarageLogic.Core.Vehicle.Energy;

namespace Ex03.GarageLogic.Core.Vehicle
{
	internal abstract class AVehicle<TEngineType> : IVehicle
		where TEngineType : Engine
	{
		private readonly string r_Brand;

		private readonly string r_LicenseNumber;

		private readonly ICollection<Tire> r_Tires;

		private readonly TEngineType r_Engine;

		protected AVehicle(string i_Brand, string i_LicenseNumber, TEngineType i_Engine)
		{
			FormatValidations.ValidateAlphaNumericFormat(i_Brand, "Brand");
			FormatValidations.ValidateAlphaNumericFormat(i_LicenseNumber, "License Number");
			
			r_Brand = i_Brand.Trim();
			r_LicenseNumber = i_LicenseNumber.Trim();
			r_Engine = i_Engine;
			r_Tires = new LinkedList<Tire>();

			// ReSharper disable once VirtualMemberCallInConstructor
			InitDefaults();
		}

		public static bool operator ==(AVehicle<TEngineType> i_Vehicle1, IVehicle i_Vehicle2)
		{
			return (ReferenceEquals(i_Vehicle1, null) && ReferenceEquals(i_Vehicle2, null)) ||
				   (!ReferenceEquals(i_Vehicle1, null) && i_Vehicle1.Equals(i_Vehicle2));
		}

		public static bool operator !=(AVehicle<TEngineType> i_Vehicle1, IVehicle i_Vehicle2)
		{
			return !(i_Vehicle1 == i_Vehicle2);
		}

		public string Brand
		{
			get
			{
				return r_Brand;
			}
		}

		public string LicenseNumber
		{
			get
			{
				return r_LicenseNumber;
			}
		}

		public float EnergyLeftPercentage
		{
			get
			{
				return Engine.EnergyLeft / Engine.EnergyMax;
			}
		}

		public ICollection<Tire> Tires
		{
			get
			{
				return r_Tires;
			}
		}

		protected TEngineType Engine
		{
			get
			{
				return r_Engine;
			}
		}

		public void SetTiresManufacturerName(string i_ManufacturerName)
		{
			foreach (Tire currentTire in Tires)
			{
				currentTire.ManufacturerName = i_ManufacturerName;
			}
		}

		public abstract TResult Accept<TResult>(IVehicleVisitor<TResult> i_Visitor);

		/// <summary>
		/// Implementors should override this method and set their own specific defaults.<br/>
		/// It is safe to access #Tires, getting the #Brand and #LicenseNumber, in this method.<br/>
		/// But be aware that this method is invoked by AVehicle's constructor, before your concrete type finished its
		/// construction, hence you should not rely on your own constructor in this method implementation.<br/>
		/// Call base.InitDefaults() to create tires. Otherwise you can manage the creation of tires on your own.
		/// </summary>
		protected virtual void InitDefaults()
		{
			for (int i = 0; i < NumberOfTires; i++)
			{
				Tires.Add(new Tire(MaxTireAirPressure, MaxTireAirPressure));
			}
		}

		protected abstract int NumberOfTires { get; }

		protected abstract float MaxTireAirPressure { get; }

		public override bool Equals(object i_Another)
		{
			bool equals = false;

			IVehicle anotherVehicle = i_Another as IVehicle;
			if (!ReferenceEquals(anotherVehicle, null))
			{
				equals = string.Equals(Brand, anotherVehicle.Brand) && string.Equals(LicenseNumber, anotherVehicle.LicenseNumber);
			}

			return equals;
		}

		public override int GetHashCode()
		{
			// HashCode.Combine....
			int hash = 17;
			hash = (hash * 31) + Brand.GetHashCode();
			hash = (hash * 31) + LicenseNumber.GetHashCode();

			return hash;
		}

		public override string ToString()
		{
			return string.Format(
				"{0}: Brand={1}, LicenseNumber={2}, EnergyLeft={3}, Tires=({4})",
				GetType().Name,
				Brand,
				LicenseNumber,
				EnergyLeftPercentage,
				Tires.Count);
		}
	}
}