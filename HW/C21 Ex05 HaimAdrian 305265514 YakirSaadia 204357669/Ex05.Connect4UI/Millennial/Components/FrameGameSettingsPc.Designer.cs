namespace Ex05.Connect4UI.Millennial.Components
{
	internal partial class FrameGameSettingsPc
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
		private void InitializeComponent()
		{
            this.m_TableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.m_LabelBoardSize = new System.Windows.Forms.Label();
            this.m_LabelDifficulty = new System.Windows.Forms.Label();
            this.m_LabelPlayer = new System.Windows.Forms.Label();
            this.m_TextBoxPlayer = new System.Windows.Forms.TextBox();
            this.m_PanelBoardSize = new System.Windows.Forms.Panel();
            this.m_ComboBoxBoardSize = new System.Windows.Forms.ComboBox();
            this.m_LabelBoardSizeExplanation = new System.Windows.Forms.Label();
            this.m_ComboBoxDifficulty = new System.Windows.Forms.ComboBox();
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
            this.m_TableLayoutPanel.Controls.Add(this.m_LabelDifficulty, 0, 1);
            this.m_TableLayoutPanel.Controls.Add(this.m_LabelPlayer, 0, 0);
            this.m_TableLayoutPanel.Controls.Add(this.m_TextBoxPlayer, 1, 0);
            this.m_TableLayoutPanel.Controls.Add(this.m_PanelBoardSize, 1, 2);
            this.m_TableLayoutPanel.Controls.Add(this.m_ComboBoxDifficulty, 1, 1);
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
            // m_LabelDifficulty
            // 
            this.m_LabelDifficulty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_LabelDifficulty.Font = new System.Drawing.Font("Lucida Calligraphy", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_LabelDifficulty.Location = new System.Drawing.Point(3, 51);
            this.m_LabelDifficulty.Name = "m_LabelDifficulty";
            this.m_LabelDifficulty.Size = new System.Drawing.Size(100, 52);
            this.m_LabelDifficulty.TabIndex = 4;
            this.m_LabelDifficulty.Text = "Difficulty";
            this.m_LabelDifficulty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_LabelPlayer
            // 
            this.m_LabelPlayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_LabelPlayer.Font = new System.Drawing.Font("Lucida Calligraphy", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_LabelPlayer.Location = new System.Drawing.Point(3, 0);
            this.m_LabelPlayer.Name = "m_LabelPlayer";
            this.m_LabelPlayer.Size = new System.Drawing.Size(100, 51);
            this.m_LabelPlayer.TabIndex = 3;
            this.m_LabelPlayer.Text = "Name";
            this.m_LabelPlayer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_TextBoxPlayer
            // 
            this.m_TextBoxPlayer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.m_TextBoxPlayer.BackColor = System.Drawing.Color.MidnightBlue;
            this.m_TextBoxPlayer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_TextBoxPlayer.Font = new System.Drawing.Font("Lucida Calligraphy", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_TextBoxPlayer.ForeColor = System.Drawing.Color.White;
            this.m_TextBoxPlayer.Location = new System.Drawing.Point(109, 13);
            this.m_TextBoxPlayer.MaxLength = 30;
            this.m_TextBoxPlayer.Name = "m_TextBoxPlayer";
            this.m_TextBoxPlayer.Size = new System.Drawing.Size(188, 24);
            this.m_TextBoxPlayer.TabIndex = 0;
            this.m_TextBoxPlayer.WordWrap = false;
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
            this.m_LabelBoardSizeExplanation.Location = new System.Drawing.Point(0, 43);
            this.m_LabelBoardSizeExplanation.Name = "m_LabelBoardSizeExplanation";
            this.m_LabelBoardSizeExplanation.Size = new System.Drawing.Size(188, 30);
            this.m_LabelBoardSizeExplanation.TabIndex = 6;
            this.m_LabelBoardSizeExplanation.Text = "Rows x Columns";
            this.m_LabelBoardSizeExplanation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_ComboBoxDifficulty
            // 
            this.m_ComboBoxDifficulty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.m_ComboBoxDifficulty.BackColor = System.Drawing.Color.MidnightBlue;
            this.m_ComboBoxDifficulty.DropDownHeight = 200;
            this.m_ComboBoxDifficulty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_ComboBoxDifficulty.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_ComboBoxDifficulty.Font = new System.Drawing.Font("Lucida Calligraphy", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_ComboBoxDifficulty.ForeColor = System.Drawing.Color.White;
            this.m_ComboBoxDifficulty.FormattingEnabled = true;
            this.m_ComboBoxDifficulty.IntegralHeight = false;
            this.m_ComboBoxDifficulty.Items.AddRange(new object[] {
            "4x4",
            "4x5",
            "4x6",
            "4x7",
            "4x8",
            "5x4",
            "5x5",
            "5x6",
            "5x7",
            "5x8",
            "6x4",
            "6x5",
            "6x6",
            "6x7",
            "6x8",
            "7x4",
            "7x5",
            "7x6",
            "7x7",
            "7x8",
            "8x4",
            "8x5",
            "8x6",
            "8x7",
            "8x8"});
            this.m_ComboBoxDifficulty.Location = new System.Drawing.Point(109, 65);
            this.m_ComboBoxDifficulty.MaxDropDownItems = 12;
            this.m_ComboBoxDifficulty.Name = "m_ComboBoxDifficulty";
            this.m_ComboBoxDifficulty.Size = new System.Drawing.Size(188, 24);
            this.m_ComboBoxDifficulty.TabIndex = 6;
            // 
            // FrameGameSettingsPc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.Controls.Add(this.m_TableLayoutPanel);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "FrameGameSettingsPc";
            this.Size = new System.Drawing.Size(300, 282);
            this.m_TableLayoutPanel.ResumeLayout(false);
            this.m_TableLayoutPanel.PerformLayout();
            this.m_PanelBoardSize.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel m_TableLayoutPanel;
		private System.Windows.Forms.Label m_LabelPlayer;
		private System.Windows.Forms.TextBox m_TextBoxPlayer;
		private System.Windows.Forms.Label m_LabelDifficulty;
		private System.Windows.Forms.Label m_LabelBoardSize;
		private System.Windows.Forms.Panel m_PanelBoardSize;
		private System.Windows.Forms.ComboBox m_ComboBoxBoardSize;
		private System.Windows.Forms.Label m_LabelBoardSizeExplanation;
		private System.Windows.Forms.ComboBox m_ComboBoxDifficulty;
	}
}
