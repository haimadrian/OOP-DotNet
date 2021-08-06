using Ex03.GarageLogic.Api.Vehicle;
using Ex03.GarageLogic.Api.Vehicle.Car;

namespace Ex03.GarageLogic.Core.Vehicle.Car
{
	internal class FuelCar : AFuelVehicle, IFuelCar
	{
		private readonly CarSpecific r_CarSpecific;

		public FuelCar(string i_Brand, string i_LicenseNumber) : base(i_Brand, i_LicenseNumber)
		{
			r_CarSpecific = new CarSpecific();
		}

		public eColor Color
		{
			get
			{
				return r_CarSpecific.Color;
			}

			set
			{
				r_CarSpecific.Color = value;
			}
		}

		public eDoorsAmount DoorsAmount
		{
			get
			{
				return r_CarSpecific.DoorsAmount;
			}

			set
			{
				r_CarSpecific.DoorsAmount = value;
			}
		}

		public override TResult Accept<TResult>(IVehicleVisitor<TResult> i_Visitor)
		{
			return i_Visitor.Visit(this);
		}

		protected override void InitDefaults()
		{
			base.InitDefaults();

			FuelType = CarDefaults.FuelType;
			FuelMaxLiters = CarDefaults.MaxFuelLiters;
		}

		protected override int NumberOfTires
		{
			get
			{
				return CarDefaults.NumberOfTires;
			}
		}

		protected override float MaxTireAirPressure
		{
			get
			{
				return CarDefaults.MaxTireAirPressure;
			}
		}

		public override string ToString()
		{
			return string.Format("{0}, Color={1}, AmountOfDoors={2}", base.ToString(), Color.ToString(), DoorsAmount.ToString());
		}
	}
}