using Ex03.GarageLogic.Api.Vehicle;

namespace Ex03.GarageLogic.Core.Vehicle.Motorcycle
{
	internal class MotorcycleSpecific
	{
		private eLicenseType m_LicenseType;
		private int m_EngineCapacityCubicCentimeter;

		public eLicenseType LicenseType
		{
			get
			{
				return m_LicenseType;
			}

			set
			{
				m_LicenseType = value;
			}
		}

		public int EngineCapacityCubicCentimeter
		{
			get
			{
				return m_EngineCapacityCubicCentimeter;
			}

			set
			{
				m_EngineCapacityCubicCentimeter = value;
			}
		}
	}
}
