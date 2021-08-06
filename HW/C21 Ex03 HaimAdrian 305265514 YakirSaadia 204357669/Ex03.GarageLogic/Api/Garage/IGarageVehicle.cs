using Ex03.GarageLogic.Api.Vehicle;

namespace Ex03.GarageLogic.Api.Garage
{
	public interface IGarageVehicle
	{
		IVehicle Vehicle { get; }

		string OwnerName { get; }

		string OwnerPhone { get; }

		eVehicleState VehicleState { get; }
	}
}
