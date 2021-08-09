using Ex03.GarageLogic.Api.Vehicle;
using Ex03.GarageLogic.Core.Vehicle.Energy;

namespace Ex03.GarageLogic.Core.Vehicle
{
	internal abstract class AElectricVehicle : AVehicle<Engine>, IElectricVehicle
	{
		protected AElectricVehicle(string i_Brand, string i_LicenseNumber) : base(i_Brand, i_LicenseNumber, new Engine())
		{
		}

		public float BatteryTimeMaxHours
		{
			get
			{
				return Engine.EnergyMax;
			}

			protected set
			{
				Engine.EnergyMax = value;
			}
		}

		public float BatteryTimeLeftHours
		{
			get
			{
				return Engine.EnergyLeft;
			}

			private set
			{
				Engine.EnergyLeft = value;
			}
		}

		public void Charge(float i_BatteryTimeToFillHours)
		{
			BatteryTimeLeftHours += i_BatteryTimeToFillHours;
		}

		public void Discharge(float i_BatteryTimeToRemove)
		{
			Charge(-i_BatteryTimeToRemove);
		}

		public override string ToString()
		{
			return string.Format("{0}, BatteryTimeLeft={1}, BatteryTimeMax={2}", base.ToString(), BatteryTimeLeftHours, BatteryTimeMaxHours);
		}
	}
}