namespace Ex05.Connect4UI.Boomer.Forms
{
	internal partial class FormGameSettings
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool i_Disposing)
		{
			if (i_Disposing && (components != null))
			{
				components.Dispose();
			}

			base.Dispose(i_Disposing);
		}

		#region Windows Form Designer generated code

		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGameSettings));
            this.m_LabelPlayers = new System.Windows.Forms.Label();
            this.m_CheckBoxPlayer2 = new System.Windows.Forms.CheckBox();
            this.m_TextBoxPlayer1 = new System.Windows.Forms.TextBox();
            this.m_TextBoxPlayer2 = new System.Windows.Forms.TextBox();
            this.m_LabelBoardSize = new System.Windows.Forms.Label();
            this.m_NumericUpDownRows = new System.Windows.Forms.NumericUpDown();
            this.m_LabelBoardSizeRows = new System.Windows.Forms.Label();
            this.m_LabelBoardSizeCols = new System.Windows.Forms.Label();
            this.m_NumericUpDownCols = new System.Windows.Forms.NumericUpDown();
            this.m_ButtonStart = new System.Windows.Forms.Button();
            this.m_LabelPlayer1 = new System.Windows.Forms.Label();
            this.m_ButtonSwitchToMillennial = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.m_NumericUpDownRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_NumericUpDownCols)).BeginInit();
            this.SuspendLayout();
            // 
            // m_LabelPlayers
            // 
            this.m_LabelPlayers.AutoSize = true;
            this.m_LabelPlayers.Location = new System.Drawing.Point(20, 15);
            this.m_LabelPlayers.Name = "m_LabelPlayers";
            this.m_LabelPlayers.Size = new System.Drawing.Size(44, 13);
            this.m_LabelPlayers.TabIndex = 0;
            this.m_LabelPlayers.Text = "Players:";
            // 
            // m_CheckBoxPlayer2
            // 
            this.m_CheckBoxPlayer2.AutoSize = true;
            this.m_CheckBoxPlayer2.Location = new System.Drawing.Point(37, 65);
            this.m_CheckBoxPlayer2.Name = "m_CheckBoxPlayer2";
            this.m_CheckBoxPlayer2.Size = new System.Drawing.Size(67, 17);
            this.m_CheckBoxPlayer2.TabIndex = 3;
            this.m_CheckBoxPlayer2.Text = "Player 2:";
            this.m_CheckBoxPlayer2.UseVisualStyleBackColor = true;
            this.m_CheckBoxPlayer2.CheckedChanged += new System.EventHandler(this.checkBoxPlayer2_CheckedChanged);
            // 
            // m_TextBoxPlayer1
            // 
            this.m_TextBoxPlayer1.Location = new System.Drawing.Point(110, 37);
            this.m_TextBoxPlayer1.MaxLength = 14;
            this.m_TextBoxPlayer1.Name = "m_TextBoxPlayer1";
            this.m_TextBoxPlayer1.Size = new System.Drawing.Size(100, 20);
            this.m_TextBoxPlayer1.TabIndex = 2;
            // 
            // m_TextBoxPlayer2
            // 
            this.m_TextBoxPlayer2.Enabled = false;
            this.m_TextBoxPlayer2.Location = new System.Drawing.Point(110, 63);
            this.m_TextBoxPlayer2.MaxLength = 14;
            this.m_TextBoxPlayer2.Name = "m_TextBoxPlayer2";
            this.m_TextBoxPlayer2.Size = new System.Drawing.Size(100, 20);
            this.m_TextBoxPlayer2.TabIndex = 4;
            this.m_TextBoxPlayer2.Text = "[Computer]";
            // 
            // m_LabelBoardSize
            // 
            this.m_LabelBoardSize.AutoSize = true;
            this.m_LabelBoardSize.Location = new System.Drawing.Point(20, 114);
            this.m_LabelBoardSize.Name = "m_LabelBoardSize";
            this.m_LabelBoardSize.Size = new System.Drawing.Size(61, 13);
            this.m_LabelBoardSize.TabIndex = 5;
            this.m_LabelBoardSize.Text = "Board Size:";
            // 
            // m_NumericUpDownRows
            // 
            this.m_NumericUpDownRows.Location = new System.Drawing.Point(77, 134);
            this.m_NumericUpDownRows.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.m_NumericUpDownRows.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.m_NumericUpDownRows.Name = "m_NumericUpDownRows";
            this.m_NumericUpDownRows.ReadOnly = true;
            this.m_NumericUpDownRows.Size = new System.Drawing.Size(32, 20);
            this.m_NumericUpDownRows.TabIndex = 7;
            this.m_NumericUpDownRows.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // m_LabelBoardSizeRows
            // 
            this.m_LabelBoardSizeRows.AutoSize = true;
            this.m_LabelBoardSizeRows.Location = new System.Drawing.Point(34, 136);
            this.m_LabelBoardSizeRows.Name = "m_LabelBoardSizeRows";
            this.m_LabelBoardSizeRows.Size = new System.Drawing.Size(37, 13);
            this.m_LabelBoardSizeRows.TabIndex = 6;
            this.m_LabelBoardSizeRows.Text = "Rows:";
            // 
            // m_LabelBoardSizeCols
            // 
            this.m_LabelBoardSizeCols.AutoSize = true;
            this.m_LabelBoardSizeCols.Location = new System.Drawing.Point(142, 136);
            this.m_LabelBoardSizeCols.Name = "m_LabelBoardSizeCols";
            this.m_LabelBoardSizeCols.Size = new System.Drawing.Size(30, 13);
            this.m_LabelBoardSizeCols.TabIndex = 8;
            this.m_LabelBoardSizeCols.Text = "Cols:";
            // 
            // m_NumericUpDownCols
            // 
            this.m_NumericUpDownCols.Location = new System.Drawing.Point(178, 134);
            this.m_NumericUpDownCols.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.m_NumericUpDownCols.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.m_NumericUpDownCols.Name = "m_NumericUpDownCols";
            this.m_NumericUpDownCols.ReadOnly = true;
            this.m_NumericUpDownCols.Size = new System.Drawing.Size(32, 20);
            this.m_NumericUpDownCols.TabIndex = 9;
            this.m_NumericUpDownCols.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // m_ButtonStart
            // 
            this.m_ButtonStart.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.m_ButtonStart.Location = new System.Drawing.Point(23, 176);
            this.m_ButtonStart.Name = "m_ButtonStart";
            this.m_ButtonStart.Size = new System.Drawing.Size(187, 23);
            this.m_ButtonStart.TabIndex = 10;
            this.m_ButtonStart.Text = "Start!";
            this.m_ButtonStart.UseVisualStyleBackColor = true;
            this.m_ButtonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // m_LabelPlayer1
            // 
            this.m_LabelPlayer1.AutoSize = true;
            this.m_LabelPlayer1.Location = new System.Drawing.Point(34, 40);
            this.m_LabelPlayer1.Name = "m_LabelPlayer1";
            this.m_LabelPlayer1.Size = new System.Drawing.Size(48, 13);
            this.m_LabelPlayer1.TabIndex = 1;
            this.m_LabelPlayer1.Text = "Player 1:";
            // 
            // m_ButtonSwitchToMillennial
            // 
            this.m_ButtonSwitchToMillennial.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_ButtonSwitchToMillennial.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.m_ButtonSwitchToMillennial.Location = new System.Drawing.Point(23, 205);
            this.m_ButtonSwitchToMillennial.Name = "m_ButtonSwitchToMillennial";
            this.m_ButtonSwitchToMillennial.Size = new System.Drawing.Size(187, 23);
            this.m_ButtonSwitchToMillennial.TabIndex = 11;
            this.m_ButtonSwitchToMillennial.Text = "I don\'t like this boomer design";
            this.m_ButtonSwitchToMillennial.UseVisualStyleBackColor = true;
            this.m_ButtonSwitchToMillennial.Click += new System.EventHandler(this.buttonSwitchToMillennial_Click);
            // 
            // FormGameSettings
            // 
            this.AcceptButton = this.m_ButtonStart;
            this.CancelButton = this.m_ButtonSwitchToMillennial;
            this.ClientSize = new System.Drawing.Size(234, 243);
            this.Controls.Add(this.m_ButtonSwitchToMillennial);
            this.Controls.Add(this.m_LabelPlayer1);
            this.Controls.Add(this.m_ButtonStart);
            this.Controls.Add(this.m_LabelBoardSizeCols);
            this.Controls.Add(this.m_NumericUpDownCols);
            this.Controls.Add(this.m_LabelBoardSizeRows);
            this.Controls.Add(this.m_NumericUpDownRows);
            this.Controls.Add(this.m_LabelBoardSize);
            this.Controls.Add(this.m_TextBoxPlayer2);
            this.Controls.Add(this.m_TextBoxPlayer1);
            this.Controls.Add(this.m_CheckBoxPlayer2);
            this.Controls.Add(this.m_LabelPlayers);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormGameSettings";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game Settings";
            ((System.ComponentModel.ISupportInitialize)(this.m_NumericUpDownRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_NumericUpDownCols)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label m_LabelPlayers;
		private System.Windows.Forms.Label m_LabelPlayer1;
		private System.Windows.Forms.TextBox m_TextBoxPlayer1;
		private System.Windows.Forms.CheckBox m_CheckBoxPlayer2;
		private System.Windows.Forms.TextBox m_TextBoxPlayer2;
		private System.Windows.Forms.Label m_LabelBoardSize;
		private System.Windows.Forms.Label m_LabelBoardSizeRows;
		private System.Windows.Forms.NumericUpDown m_NumericUpDownRows;
		private System.Windows.Forms.Label m_LabelBoardSizeCols;
		private System.Windows.Forms.NumericUpDown m_NumericUpDownCols;
		private System.Windows.Forms.Button m_ButtonStart;
		private System.Windows.Forms.Button m_ButtonSwitchToMillennial;
	}
}
