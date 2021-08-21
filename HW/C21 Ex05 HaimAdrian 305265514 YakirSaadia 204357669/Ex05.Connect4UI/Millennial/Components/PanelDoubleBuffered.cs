using System.Windows.Forms;

namespace Ex05.Connect4UI.Millennial.Components
{
	internal class PanelDoubleBuffered : Panel
	{
		public PanelDoubleBuffered()
		{
			// Set double buffered so there will be no flickers while painting
			// ReSharper disable once VirtualMemberCallInConstructor
			DoubleBuffered = true;
		}
	}
}
