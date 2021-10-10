namespace Ex03.GarageLogic.Api.Vehicle.Car
{
	public interface ICar : IVehicle
	{
		eColor Color { get; set; }

		eDoorsAmount DoorsAmount { get; set; }
	}
}
