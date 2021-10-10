using Ex03.GarageLogic.Api.Exceptions;
using Ex03.GarageLogic.Api.Utils;

namespace Ex03.GarageLogic.Api.Vehicle
{
	// Use a class and not struct cause we would like to support updating air pressure without being immutable.
	// Otherwise we would have to expose an ITire interface which would then box the struct type.. so just use a class.
	public class Tire
	{
		private readonly float r_MaxAirPressure;

		private string m_ManufacturerName;

		private float m_AirPressure;

		public Tire(float i_MaxAirPressure, float i_AirPressure)
		{
			r_MaxAirPressure = i_MaxAirPressure;
			m_AirPressure = i_AirPressure;
		}

		public string ManufacturerName
		{
			get
			{
				return m_ManufacturerName;
			}

			set
			{
				FormatValidations.ValidateAlphaNumericFormat(value, "Manufacturer Name");
				m_ManufacturerName = value;
			}
		}

		public float MaxAirPressure
		{
			get
			{
				return r_MaxAirPressure;
			}
		}

		public float AirPressure
		{
			get
			{
				return m_AirPressure;
			}

			private set
			{
				const float k_MinAirPressure = 0;
				const string k_AirPressureOutOfRangeMessage = "Air pressure is out of range. Range: [{0}, {1}], Was: {2}";

				if ((value > MaxAirPressure) || (value < k_MinAirPressure))
				{
					throw new ValueOutOfRangeException(
						string.Format(k_AirPressureOutOfRangeMessage, k_MinAirPressure, MaxAirPressure, value),
						k_MinAirPressure,
						MaxAirPressure);
				}

				m_AirPressure = value;
			}
		}

		public void Inflate(float i_AirPressureToFill)
		{
			AirPressure += i_AirPressureToFill;
		}

		public void Deflate(float i_AirPressureToRemove)
		{
			Inflate(-i_AirPressureToRemove);
		}

		public override string ToString()
		{
			return string.Format("Manufacturer: {0}, Air Pressure (Actual / Max): {1} / {2}", ManufacturerName, AirPressure, MaxAirPressure);
		}
	}
}