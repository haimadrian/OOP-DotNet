using System;
using System.Runtime.Serialization;

namespace Ex02.Connect4Engine.Api.Game.Exceptions
{
	public class GameEngineException : Exception
	{
		public GameEngineException()
		{
		}

		public GameEngineException(string i_Message) : base(i_Message)
		{
		}

		public GameEngineException(string i_Message, Exception i_InnerException) : base(i_Message, i_InnerException)
		{
		}

		protected GameEngineException(SerializationInfo i_Info, StreamingContext i_Context) : base(i_Info, i_Context)
		{
		}
	}
}