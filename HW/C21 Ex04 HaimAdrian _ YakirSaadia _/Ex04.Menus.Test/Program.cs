using System;

namespace Ex04.Menus.Test
{
	public class Program
	{
		public static void Main()
		{
			demonstrate(new InterfacesDemo());
			demonstrate(new DelegatesDemo());

			Console.WriteLine("{0}Press Enter to exit...", Environment.NewLine);
			Console.ReadLine();
		}

		private static void demonstrate(IDemo i_Demo)
		{
			i_Demo.Init();
			i_Demo.Show();
		}
	}
}
