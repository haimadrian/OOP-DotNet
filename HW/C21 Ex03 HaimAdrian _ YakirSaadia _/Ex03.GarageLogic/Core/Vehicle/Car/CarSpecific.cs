using Ex03.GarageLogic.Api.Vehicle;

namespace Ex03.GarageLogic.Core.Vehicle.Car
{
	internal class CarSpecific
	{
		private eDoorsAmount m_DoorsAmount;
		private eColor m_Color;

		public eColor Color
		{
			get
			{
				return m_Color;
			}

			set
			{
				m_Color = value;
			}
		}

		public eDoorsAmount DoorsAmount
		{
			get
			{
				return m_DoorsAmount;
			}

			set
			{
				m_DoorsAmount = value;
			}
		}
	}
}
