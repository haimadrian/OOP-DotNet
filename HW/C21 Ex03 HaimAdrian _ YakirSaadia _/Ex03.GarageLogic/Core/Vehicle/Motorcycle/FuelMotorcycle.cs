using Ex03.GarageLogic.Api.Vehicle;
using Ex03.GarageLogic.Api.Vehicle.Motorcycle;

namespace Ex03.GarageLogic.Core.Vehicle.Motorcycle
{
	internal class FuelMotorcycle : AFuelVehicle, IFuelMotorcycle
	{
		private readonly MotorcycleSpecific r_MotorcycleSpecific;

		public FuelMotorcycle(string i_Brand, string i_LicenseNumber) : base(i_Brand, i_LicenseNumber)
		{
			r_MotorcycleSpecific = new MotorcycleSpecific();
		}

		public eLicenseType LicenseType
		{
			get
			{
				return r_MotorcycleSpecific.LicenseType;
			}

			set
			{
				r_MotorcycleSpecific.LicenseType = value;
			}
		}

		public int EngineCapacityCubicCentimeter
		{
			get
			{
				return r_MotorcycleSpecific.EngineCapacityCubicCentimeter;
			}

			set
			{
				r_MotorcycleSpecific.EngineCapacityCubicCentimeter = value;
			}
		}

		protected override int NumberOfTires
		{
			get
			{
				return MotorcycleDefaults.NumberOfTires;
			}
		}

		protected override float MaxTireAirPressure
		{
			get
			{
				return MotorcycleDefaults.MaxTireAirPressure;
			}
		}

		public override TResult Accept<TResult>(IVehicleVisitor<TResult> i_Visitor)
		{
			return i_Visitor.Visit(this);
		}

		protected override void InitDefaults()
		{
			base.InitDefaults();

			FuelMaxLiters = MotorcycleDefaults.MaxFuelLiters;
			FuelType = MotorcycleDefaults.FuelType;
		}

		public override string ToString()
		{
			return string.Format("{0}, LicenseType={1}, EngineCapacity={2}", base.ToString(), LicenseType.ToString(), EngineCapacityCubicCentimeter);
		}
	}
}
