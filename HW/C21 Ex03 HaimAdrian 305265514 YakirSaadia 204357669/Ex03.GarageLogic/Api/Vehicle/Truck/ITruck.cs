namespace Ex03.GarageLogic.Api.Vehicle.Truck
{
	public interface ITruck : IVehicle
	{
		bool HavingDangerousSubstances { get; set; }

		float CargoVolume { get; set; }
	}
}
