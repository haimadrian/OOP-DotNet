using System.Windows.Forms;
using Ex05.Connect4UI.Properties;

namespace Ex05.Connect4UI.Normal.Forms
{
	/// <summary>
	/// This class represents a MessageBox with custom style, because .Net's MessageBox does not support styles.<br/>
	/// It is not a complete copy of MessageBox though. There are always two buttons which are configurable - they can
	/// be YesNo or OkCancel. I've also added message box icons.<br/>
	/// <br/>
	/// Author: Haim Adrian<br/>
	/// Since: 13-Aug-2021
	/// </summary>
	internal sealed partial class FormMessageBox : Form
	{
		private FormMessageBox()
		{
			InitializeComponent();
			Text = Resources.TextConnectFour;
		}

		public static DialogResult Show(string i_Text, MessageBoxButtons i_Buttons, MessageBoxIcon i_Icon)
		{
			FormMessageBox messageBox = createMessageBox(i_Text, i_Buttons, i_Icon);
			return messageBox.ShowDialog();
		}

		public static DialogResult Show(IWin32Window i_Owner, string i_Text, MessageBoxButtons i_Buttons, MessageBoxIcon i_Icon)
		{
			FormMessageBox messageBox = createMessageBox(i_Text, i_Buttons, i_Icon);
			return messageBox.ShowDialog(i_Owner);
		}

		private static FormMessageBox createMessageBox(string i_Text, MessageBoxButtons i_Buttons, MessageBoxIcon i_Icon)
		{
			FormMessageBox messageBox = new FormMessageBox();
			messageBox.m_LabelMessage.Text = i_Text;

			if (i_Buttons == MessageBoxButtons.OK || i_Buttons == MessageBoxButtons.OKCancel)
			{
				messageBox.m_ButtonYes.Text = Resources.TextOk;
				messageBox.m_ButtonYes.DialogResult = DialogResult.OK;
				messageBox.m_ButtonNo.Text = Resources.TextCancel;
				messageBox.m_ButtonNo.DialogResult = DialogResult.Cancel;
			}
			else
			{
				messageBox.m_ButtonYes.Text = Resources.TextYes;
				messageBox.m_ButtonYes.DialogResult = DialogResult.Yes;
				messageBox.m_ButtonNo.Text = Resources.TextNo;
				messageBox.m_ButtonNo.DialogResult = DialogResult.No;
			}

			// ReSharper disable once SwitchStatementHandlesSomeKnownEnumValuesWithDefault
			switch (i_Icon)
			{
				case MessageBoxIcon.Information:
					messageBox.m_PictureBoxIcon.Image = Resources.Info;
					break;
				case MessageBoxIcon.Warning:
				case MessageBoxIcon.Question:
					messageBox.m_PictureBoxIcon.Image = Resources.Warning;
					break;
				default:
					messageBox.m_PictureBoxIcon.Image = Resources.Error;
					break;
			}

			return messageBox;
		}
	}
}
