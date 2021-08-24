namespace Ex05.Connect4UI.Normal.Components
{
	internal sealed partial class FrameGameSettingsMultiPlayer
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}

			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		// This must be with Capital letter, even though it is private, cause this is how VS designer generated it and it doesn't work with lower cased i.
		private void InitializeComponent()
		{
            this.m_TableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.m_LabelBoardSize = new System.Windows.Forms.Label();
            this.m_LabelPlayer2 = new System.Windows.Forms.Label();
            this.m_LabelPlayer1 = new System.Windows.Forms.Label();
            this.m_PanelBoardSize = new System.Windows.Forms.Panel();
            this.m_ComboBoxBoardSize = new System.Windows.Forms.ComboBox();
            this.m_LabelBoardSizeExplanation = new System.Windows.Forms.Label();
            this.m_TextBoxPlayer1 = new System.Windows.Forms.TextBox();
            this.m_TextBoxPlayer2 = new System.Windows.Forms.TextBox();
            this.m_TableLayoutPanel.SuspendLayout();
            this.m_PanelBoardSize.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_TableLayoutPanel
            // 
            this.m_TableLayoutPanel.ColumnCount = 2;
            this.m_TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.66667F));
            this.m_TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64.33334F));
            this.m_TableLayoutPanel.Controls.Add(this.m_LabelBoardSize, 0, 2);
            this.m_TableLayoutPanel.Controls.Add(this.m_LabelPlayer2, 0, 1);
            this.m_TableLayoutPanel.Controls.Add(this.m_LabelPlayer1, 0, 0);
            this.m_TableLayoutPanel.Controls.Add(this.m_PanelBoardSize, 1, 2);
            this.m_TableLayoutPanel.Controls.Add(this.m_TextBoxPlayer1, 1, 0);
            this.m_TableLayoutPanel.Controls.Add(this.m_TextBoxPlayer2, 1, 1);
            this.m_TableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_TableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.m_TableLayoutPanel.Name = "m_TableLayoutPanel";
            this.m_TableLayoutPanel.RowCount = 3;
            this.m_TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.36709F));
            this.m_TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.63291F));
            this.m_TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 178F));
            this.m_TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.m_TableLayoutPanel.Size = new System.Drawing.Size(300, 282);
            this.m_TableLayoutPanel.TabIndex = 0;
            // 
            // m_LabelBoardSize
            // 
            this.m_LabelBoardSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_LabelBoardSize.Font = new System.Drawing.Font("Lucida Calligraphy", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_LabelBoardSize.Location = new System.Drawing.Point(3, 103);
            this.m_LabelBoardSize.Name = "m_LabelBoardSize";
            this.m_LabelBoardSize.Size = new System.Drawing.Size(100, 179);
            this.m_LabelBoardSize.TabIndex = 5;
            this.m_LabelBoardSize.Text = "Board Size";
            this.m_LabelBoardSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_LabelPlayer2
            // 
            this.m_LabelPlayer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_LabelPlayer2.Font = new System.Drawing.Font("Lucida Calligraphy", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_LabelPlayer2.Location = new System.Drawing.Point(3, 51);
            this.m_LabelPlayer2.Name = "m_LabelPlayer2";
            this.m_LabelPlayer2.Size = new System.Drawing.Size(100, 52);
            this.m_LabelPlayer2.TabIndex = 4;
            this.m_LabelPlayer2.Text = "Player2";
            this.m_LabelPlayer2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_LabelPlayer1
            // 
            this.m_LabelPlayer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_LabelPlayer1.Font = new System.Drawing.Font("Lucida Calligraphy", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_LabelPlayer1.Location = new System.Drawing.Point(3, 0);
            this.m_LabelPlayer1.Name = "m_LabelPlayer1";
            this.m_LabelPlayer1.Size = new System.Drawing.Size(100, 51);
            this.m_LabelPlayer1.TabIndex = 3;
            this.m_LabelPlayer1.Text = "Player1";
            this.m_LabelPlayer1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_PanelBoardSize
            // 
            this.m_PanelBoardSize.Controls.Add(this.m_ComboBoxBoardSize);
            this.m_PanelBoardSize.Controls.Add(this.m_LabelBoardSizeExplanation);
            this.m_PanelBoardSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_PanelBoardSize.Location = new System.Drawing.Point(109, 106);
            this.m_PanelBoardSize.Name = "m_PanelBoardSize";
            this.m_PanelBoardSize.Size = new System.Drawing.Size(188, 173);
            this.m_PanelBoardSize.TabIndex = 4;
            // 
            // m_ComboBoxBoardSize
            // 
            this.m_ComboBoxBoardSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.m_ComboBoxBoardSize.BackColor = System.Drawing.Color.MidnightBlue;
            this.m_ComboBoxBoardSize.DropDownHeight = 200;
            this.m_ComboBoxBoardSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_ComboBoxBoardSize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_ComboBoxBoardSize.Font = new System.Drawing.Font("Lucida Calligraphy", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_ComboBoxBoardSize.ForeColor = System.Drawing.Color.White;
            this.m_ComboBoxBoardSize.FormattingEnabled = true;
            this.m_ComboBoxBoardSize.IntegralHeight = false;
            this.m_ComboBoxBoardSize.Location = new System.Drawing.Point(0, 76);
            this.m_ComboBoxBoardSize.MaxDropDownItems = 12;
            this.m_ComboBoxBoardSize.Name = "m_ComboBoxBoardSize";
            this.m_ComboBoxBoardSize.Size = new System.Drawing.Size(188, 24);
            this.m_ComboBoxBoardSize.TabIndex = 2;
            // 
            // m_LabelBoardSizeExplanation
            // 
            this.m_LabelBoardSizeExplanation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.m_LabelBoardSizeExplanation.Font = new System.Drawing.Font("Lucida Calligraphy", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_LabelBoardSizeExplanation.Location = new System.Drawing.Point(0, 42);
            this.m_LabelBoardSizeExplanation.Name = "m_LabelBoardSizeExplanation";
            this.m_LabelBoardSizeExplanation.Size = new System.Drawing.Size(188, 30);
            this.m_LabelBoardSizeExplanation.TabIndex = 6;
            this.m_LabelBoardSizeExplanation.Text = "Rows x Columns";
            this.m_LabelBoardSizeExplanation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_TextBoxPlayer1
            // 
            this.m_TextBoxPlayer1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.m_TextBoxPlayer1.BackColor = System.Drawing.Color.MidnightBlue;
            this.m_TextBoxPlayer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_TextBoxPlayer1.Font = new System.Drawing.Font("Lucida Calligraphy", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_TextBoxPlayer1.ForeColor = System.Drawing.Color.White;
            this.m_TextBoxPlayer1.Location = new System.Drawing.Point(109, 13);
            this.m_TextBoxPlayer1.MaxLength = 30;
            this.m_TextBoxPlayer1.Name = "m_TextBoxPlayer1";
            this.m_TextBoxPlayer1.Size = new System.Drawing.Size(188, 24);
            this.m_TextBoxPlayer1.TabIndex = 0;
            this.m_TextBoxPlayer1.WordWrap = false;
            // 
            // m_TextBoxPlayer2
            // 
            this.m_TextBoxPlayer2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.m_TextBoxPlayer2.BackColor = System.Drawing.Color.MidnightBlue;
            this.m_TextBoxPlayer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_TextBoxPlayer2.Font = new System.Drawing.Font("Lucida Calligraphy", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_TextBoxPlayer2.ForeColor = System.Drawing.Color.White;
            this.m_TextBoxPlayer2.Location = new System.Drawing.Point(109, 65);
            this.m_TextBoxPlayer2.MaxLength = 30;
            this.m_TextBoxPlayer2.Name = "m_TextBoxPlayer2";
            this.m_TextBoxPlayer2.Size = new System.Drawing.Size(188, 24);
            this.m_TextBoxPlayer2.TabIndex = 1;
            this.m_TextBoxPlayer2.WordWrap = false;
            // 
            // FrameGameSettingsMultiPlayer
            // 
            this.BackColor = System.Drawing.Color.SlateGray;
            this.Controls.Add(this.m_TableLayoutPanel);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "FrameGameSettingsMultiPlayer";
            this.Size = new System.Drawing.Size(300, 282);
            this.m_TableLayoutPanel.ResumeLayout(false);
            this.m_TableLayoutPanel.PerformLayout();
            this.m_PanelBoardSize.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel m_TableLayoutPanel;
		private System.Windows.Forms.Label m_LabelPlayer1;
		private System.Windows.Forms.TextBox m_TextBoxPlayer1;
		private System.Windows.Forms.TextBox m_TextBoxPlayer2;
		private System.Windows.Forms.Label m_LabelPlayer2;
		private System.Windows.Forms.Label m_LabelBoardSize;
		private System.Windows.Forms.Panel m_PanelBoardSize;
		private System.Windows.Forms.ComboBox m_ComboBoxBoardSize;
		private System.Windows.Forms.Label m_LabelBoardSizeExplanation;
	}
}
