using System;

namespace Ex03.GarageLogic.Api.Exceptions
{
	public class ValueOutOfRangeException : Exception
	{
		private readonly float r_MinValue;

		private readonly float r_MaxValue;

		public ValueOutOfRangeException() : this(string.Empty, 0, 0, null)
		{
		}

		public ValueOutOfRangeException(string i_Message, float i_MinValue, float i_MaxValue) : this(i_Message, i_MinValue, i_MaxValue, null)
		{
		}

		public ValueOutOfRangeException(string i_Message, float i_MinValue, float i_MaxValue, Exception i_InnerException) : base(i_Message, i_InnerException)
		{
			r_MinValue = i_MinValue;
			r_MaxValue = i_MaxValue;
		}

		public float MinValue
		{
			get
			{
				return r_MinValue;
			}
		}

		public float MaxValue
		{
			get
			{
				return r_MaxValue;
			}
		}
	}
}
