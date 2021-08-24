using System;
using System.Windows.Forms;
using Ex05.Connect4UI.Boomer.Forms;
using Ex05.Connect4UI.Normal.Forms;

namespace Ex05.Connect4UI
{
	public class Program
	{
		public static void Main()
		{
			try
			{
				// Register global exception handler to catch any unhandled exception. (Where's Application.ThreadException ?!?)
				AppDomain.CurrentDomain.UnhandledException += appDomain_UnhandledException;

				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				Application.Run(new FormGameSettings());
			}
			catch (Exception e)
			{
				showError(e);
			}
		}

		private static void appDomain_UnhandledException(object i_Sender, UnhandledExceptionEventArgs i_Args)
		{
			showError(i_Args.ExceptionObject as Exception);
		}

		private static void showError(Exception i_Exception)
		{
			string text = string.Format("Unexpected error: {0}", i_Exception == null ? "null" : i_Exception.Message);

			try
			{
				FormMessageBox.Show(text, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			catch (Exception)
			{
				Console.WriteLine(text);
			}
		}
	}
}