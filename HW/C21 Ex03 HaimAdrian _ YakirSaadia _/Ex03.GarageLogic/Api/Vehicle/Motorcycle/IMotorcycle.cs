namespace Ex03.GarageLogic.Api.Vehicle.Motorcycle
{
	public interface IMotorcycle : IVehicle
	{
		eLicenseType LicenseType { get; set; }

		int EngineCapacityCubicCentimeter { get; set; }
	}
}
