using Ex03.GarageLogic.Api.Vehicle;

namespace Ex03.GarageLogic.Api.Garage
{
	public interface IGarageVehicle
	{
		IVehicle Vehicle { get; }

		ICustomer Owner { get; }

		eVehicleState VehicleState { get; }
	}
}
