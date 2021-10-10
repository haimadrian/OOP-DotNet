using System.Collections.Generic;

namespace Ex03.GarageLogic.Api.Vehicle
{
	public interface IVehicle
	{
		/// <summary>
		/// Brand name of this vehicle
		/// </summary>
		string Brand { get; }

		/// <summary>
		/// License number of this vehicle
		/// </summary>
		string LicenseNumber { get; }

		/// <summary>
		/// How much energy is left, in percents between 0 to 1, for this vehicle
		/// </summary>
		float EnergyLeftPercentage { get; }

		/// <summary>
		/// A collection of tires that this vehicle has
		/// </summary>
		ICollection<Tire> Tires { get; }

		/// <summary>
		/// Apply tires manufacturer name to all tires at once.
		/// </summary>
		string TiresManufacturerName { set; }

		/// <summary>
		/// Each implementor should send itself to the Visit method of the specified visitor.<br/>
		/// This design pattern lets us to perform some specific action for each vehicle type.
		/// </summary>
		/// <typeparam name="TResult">Result type of the visitor</typeparam>
		/// <param name="i_Visitor">The visitor to be used by this vehicle</param>
		/// <returns>Result of the Visit method of the specified visitor</returns>
		TResult Accept<TResult>(IVehicleVisitor<TResult> i_Visitor);
	}
}