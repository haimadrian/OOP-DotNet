using System;
using Ex03.GarageLogic.Api.Exceptions;

namespace Ex03.GarageLogic.Core.Vehicle.Energy
{
	internal class Engine
	{
		// Assumption: When replacing engine (max capacity modification) the engine is half full.
		private const float k_PartOfMaxEngine = 2;

		private const float k_MinEnergy = 0;

		private const string k_EnergyOutOfRangeMessage = "Input is out of range. Range: [{0}, {1}], Was: {2}";

		private float m_EnergyLeft;

		private float m_EnergyMax;

		public float EnergyLeft
		{
			get
			{
				return m_EnergyLeft;
			}

			set
			{
				if ((value > EnergyMax) || (value < k_MinEnergy))
				{
					throw new ValueOutOfRangeException(string.Format(k_EnergyOutOfRangeMessage, k_MinEnergy, EnergyMax, value), k_MinEnergy, EnergyMax);
				}

				m_EnergyLeft = value;
			}
		}

		public float EnergyMax
		{
			get
			{
				return m_EnergyMax;
			}

			set
			{
				if (value <= 0)
				{
					throw new ArgumentException(string.Format("Maximum energy cannot be less than or equal to {0}", k_MinEnergy));
				}

				m_EnergyMax = value;

				// See k_PartOfMaxEngine
				EnergyLeft = value / k_PartOfMaxEngine;
			}
		}
	}
}