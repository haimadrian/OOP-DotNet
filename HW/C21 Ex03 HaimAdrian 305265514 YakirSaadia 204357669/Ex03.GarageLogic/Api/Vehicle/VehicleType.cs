using System;
using Ex03.GarageLogic.Core.Vehicle.Car;
using Ex03.GarageLogic.Core.Vehicle.Motorcycle;
using Ex03.GarageLogic.Core.Vehicle.Truck;

namespace Ex03.GarageLogic.Api.Vehicle
{
	public struct VehicleType
	{
		private static readonly VehicleType sr_ElectricMotorcycle = new VehicleType(typeof(ElectricMotorcycle));
		private static readonly VehicleType sr_FuelMotorcycle = new VehicleType(typeof(FuelMotorcycle));
		private static readonly VehicleType sr_ElectricCar = new VehicleType(typeof(ElectricCar));
		private static readonly VehicleType sr_FuelCar = new VehicleType(typeof(FuelCar));
		private static readonly VehicleType sr_FuelTruck = new VehicleType(typeof(FuelTruck));

		private readonly Type r_Type;

		public VehicleType(Type i_Type)
		{
			r_Type = i_Type;
		}

		public static VehicleType ElectricMotorcycle
		{
			get
			{
				return sr_ElectricMotorcycle;
			}
		}

		public static VehicleType FuelMotorcycle
		{
			get
			{
				return sr_FuelMotorcycle;
			}
		}

		public static VehicleType ElectricCar
		{
			get
			{
				return sr_ElectricCar;
			}
		}

		public static VehicleType FuelCar
		{
			get
			{
				return sr_FuelCar;
			}
		}

		public static VehicleType FuelTruck
		{
			get
			{
				return sr_FuelTruck;
			}
		}

		public Type Type
		{
			get
			{
				return r_Type;
			}
		}
	}
}