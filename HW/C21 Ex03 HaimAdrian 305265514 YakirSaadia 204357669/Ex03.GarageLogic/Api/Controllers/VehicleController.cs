using Ex03.GarageLogic.Api.Vehicle;
using Ex03.GarageLogic.Core.Vehicle;

namespace Ex03.GarageLogic.Api.Controllers
{
	public sealed class VehicleController
	{
		private static readonly VehicleController sr_Instance = new VehicleController();

		private VehicleController()
		{
		}

		public static VehicleController Instance
		{
			get
			{
				return sr_Instance;
			}
		}

		public T NewVehicle<T>(VehicleType i_VehicleType, string i_Brand, string i_LicenseNumber)
			where T : IVehicle
		{
			return VehicleFactory.NewVehicle<T>(i_VehicleType, i_Brand, i_LicenseNumber);
		}
	}
}