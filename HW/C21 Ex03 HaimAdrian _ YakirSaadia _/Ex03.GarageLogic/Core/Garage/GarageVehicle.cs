using Ex03.GarageLogic.Api.Garage;
using Ex03.GarageLogic.Api.Vehicle;

namespace Ex03.GarageLogic.Core.Garage
{
	internal class GarageVehicle : IGarageVehicle
	{
		private readonly ICustomer r_Owner;
		private readonly IVehicle r_Vehicle;
		private eVehicleState m_VehicleState;

		public GarageVehicle(ICustomer i_Owner, IVehicle i_Vehicle)
		{
			r_Vehicle = i_Vehicle;
			r_Owner = i_Owner;
			VehicleState = eVehicleState.Repairing;
		}

		public IVehicle Vehicle
		{
			get
			{
				return r_Vehicle;
			}
		}

		public ICustomer Owner
		{
			get
			{
				return r_Owner;
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

		public static bool operator ==(GarageVehicle i_Vehicle1, IGarageVehicle i_Vehicle2)
		{
			return (ReferenceEquals(i_Vehicle1, null) && ReferenceEquals(i_Vehicle2, null)) ||
				   (!ReferenceEquals(i_Vehicle1, null) && i_Vehicle1.Equals(i_Vehicle2));
		}

		public static bool operator !=(GarageVehicle i_Vehicle1, IGarageVehicle i_Vehicle2)
		{
			return !(i_Vehicle1 == i_Vehicle2);
		}

		public override bool Equals(object i_Another)
		{
			bool equals = false;

			IGarageVehicle anotherGarageVehicle = i_Another as IGarageVehicle;
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
			return string.Format("VehicleStatus={0}, Owner=({1}), Vehicle={2}", VehicleState.ToString(), Owner, Vehicle);
		}
	}
}
