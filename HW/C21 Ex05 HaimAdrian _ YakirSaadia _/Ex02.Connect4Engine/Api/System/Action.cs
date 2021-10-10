namespace Ex02.Connect4Engine.Api.System
{
	public delegate void Action();

	public delegate void Action<T1, T2>(T1 i_First, T2 i_Second);

	public delegate void Action<T1, T2, T3>(T1 i_First, T2 i_Second, T3 i_Third);
}
