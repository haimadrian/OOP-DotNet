namespace Ex03.GarageLogic.Core.Vehicle.Truck
{
	internal class TruckSpecific
	{
		private float m_CargoVolume;
		private bool m_HavingDangerousSubstances;

		public float CargoVolume
		{
			get
			{
				return m_CargoVolume;
			}

			set
			{
				m_CargoVolume = value;
			}
		}

		public bool HavingDangerousSubstances
		{
			get
			{
				return m_HavingDangerousSubstances;
			}

			set
			{
				m_HavingDangerousSubstances = value;
			}
		}
	}
}