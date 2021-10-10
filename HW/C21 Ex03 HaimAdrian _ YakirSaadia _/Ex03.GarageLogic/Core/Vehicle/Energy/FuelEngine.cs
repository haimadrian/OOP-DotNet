using Ex03.GarageLogic.Api.Vehicle;

namespace Ex03.GarageLogic.Core.Vehicle.Energy
{
	internal class FuelEngine : Engine
	{
		private eFuelType m_FuelType;

		public eFuelType FuelType
		{
			get
			{
				return m_FuelType;
			}

			set
			{
				m_FuelType = value;
			}
		}
	}
}
