using Ex03.GarageLogic.Api.Vehicle;
using Ex03.GarageLogic.Api.Vehicle.Truck;

namespace Ex03.GarageLogic.Core.Vehicle.Truck
{
	internal class FuelTruck : AFuelVehicle, IFuelTruck
	{
		private readonly TruckSpecific r_TruckSpecific;

		public FuelTruck(string i_Brand, string i_LicenseNumber) : base(i_Brand, i_LicenseNumber)
		{
			r_TruckSpecific = new TruckSpecific();
		}

		public float CargoVolume
		{
			get
			{
				return r_TruckSpecific.CargoVolume;
			}

			set
			{
				r_TruckSpecific.CargoVolume = value;
			}
		}

		public bool HavingDangerousSubstances
		{
			get
			{
				return r_TruckSpecific.HavingDangerousSubstances;
			}

			set
			{
				r_TruckSpecific.HavingDangerousSubstances = value;
			}
		}

		protected override int NumberOfTires
		{
			get
			{
				return TruckDefaults.NumberOfTires;
			}
		}

		protected override float MaxTireAirPressure
		{
			get
			{
				return TruckDefaults.MaxTireAirPressure;
			}
		}

		public override TResult Accept<TResult>(IVehicleVisitor<TResult> i_Visitor)
		{
			return i_Visitor.Visit(this);
		}

		protected override void InitDefaults()
		{
			base.InitDefaults();

			FuelMaxLiters = TruckDefaults.MaxFuelLiters;
			FuelType = TruckDefaults.FuelType;
		}

		public override string ToString()
		{
			return string.Format("{0}, CargoVolume={1}, HavingDangerousSubstances={2}", base.ToString(), CargoVolume, HavingDangerousSubstances);
		}
	}
}