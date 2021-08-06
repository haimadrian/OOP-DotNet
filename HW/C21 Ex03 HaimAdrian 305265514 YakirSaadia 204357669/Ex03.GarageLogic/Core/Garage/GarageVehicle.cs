using System;
using Ex03.GarageLogic.Api.Garage;
using Ex03.GarageLogic.Api.Vehicle;

namespace Ex03.GarageLogic.Core.Garage
{
	internal class GarageVehicle : IGarageVehicle
	{
		private readonly string r_OwnerName;
		private readonly string r_OwnerPhone;
		private readonly IVehicle r_Vehicle;
		private eVehicleState m_VehicleState;

		public GarageVehicle(string i_OwnerName, string i_OwnerPhone, IVehicle i_Vehicle)
		{
			r_Vehicle = i_Vehicle;
			r_OwnerName = i_OwnerName;
			r_OwnerPhone = i_OwnerPhone;
			VehicleState = eVehicleState.Repairing;
		}

		public IVehicle Vehicle
		{
			get
			{
				return r_Vehicle;
			}
		}

		public string OwnerName
		{
			get
			{
				return r_OwnerName;
			}
		}

		public string OwnerPhone
		{
			get
			{
				return r_OwnerPhone;
			}
		}

		public eVehicleState VehicleState
		{
			get
			{
				return m_VehicleState;
			}

			set
			{
				m_VehicleState = value;
			}
		}

		public static bool operator ==(GarageVehicle i_Vehicle1, GarageVehicle i_Vehicle2)
		{
			return (ReferenceEquals(i_Vehicle1, null) && ReferenceEquals(i_Vehicle2, null)) ||
				   (!ReferenceEquals(i_Vehicle1, null) && i_Vehicle1.Equals(i_Vehicle2));
		}

		public static bool operator !=(GarageVehicle i_Vehicle1, GarageVehicle i_Vehicle2)
		{
			return !(i_Vehicle1 == i_Vehicle2);
		}

		public override bool Equals(object i_Another)
		{
			bool equals = false;

			GarageVehicle anotherGarageVehicle = i_Another as GarageVehicle;
			if (!ReferenceEquals(anotherGarageVehicle, null))
			{
				// Compare by vehicle
				equals = Vehicle == anotherGarageVehicle.Vehicle;
			}

			return equals;
		}

		public override int GetHashCode()
		{
			// HashCode.Combine....
			int hash = 17;
			hash = (hash * 31) + Vehicle.GetHashCode();

			return hash;
		}

		public override string ToString()
		{
			return string.Format("VehicleStatus={0}, OwnerName={1}, OwnerPhone={2}, Vehicle={3}", VehicleState.ToString(), OwnerName, OwnerPhone, Vehicle);
		}
	}
}