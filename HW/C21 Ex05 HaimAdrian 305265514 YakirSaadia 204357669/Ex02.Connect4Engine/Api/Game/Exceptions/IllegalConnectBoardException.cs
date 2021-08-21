using System;
using System.Runtime.Serialization;

namespace Ex02.Connect4Engine.Api.Game.Exceptions
{
	public class IllegalConnectBoardException : Exception
	{
		public IllegalConnectBoardException()
		{
		}

		public IllegalConnectBoardException(string i_Message) : base(i_Message)
		{
		}

		public IllegalConnectBoardException(string i_Message, Exception i_InnerException) : base(i_Message, i_InnerException)
		{
		}

		protected IllegalConnectBoardException(SerializationInfo i_Info, StreamingContext i_Context) : base(i_Info, i_Context)
		{
		}
	}
}