using Ex03.GarageLogic.Api.Vehicle.Car;
using Ex03.GarageLogic.Api.Vehicle.Motorcycle;
using Ex03.GarageLogic.Api.Vehicle.Truck;

namespace Ex03.GarageLogic.Api.Vehicle
{
	/// <summary>
	/// A visitor that each vehicle can accept, thus letting clients of the logic layer to respond
	/// to each vehicle type specifically.<br/>
	/// This is especially useful for UI and Console, when they need to run special formatting or
	/// analysis on vehicles.
	/// </summary>
	/// <typeparam name="TResult">The result of the visitor. May be null when the action is Void.</typeparam>
	public interface IVehicleVisitor<TResult>
	{
		TResult Visit(IElectricCar i_Vehicle);

		TResult Visit(IFuelCar i_Vehicle);

		TResult Visit(IElectricMotorcycle i_Vehicle);

		TResult Visit(IFuelMotorcycle i_Vehicle);

		TResult Visit(IFuelTruck i_Vehicle);

		// Topmost type, to be as default implementation for new future types.
		TResult Visit(IVehicle i_Vehicle);
	}
}
