namespace Ex05.Connect4UI.Boomer.Forms
{
	internal partial class FormConnectFourMain
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormConnectFourMain));
            this.m_TableLayoutPanelScore = new System.Windows.Forms.TableLayoutPanel();
            this.m_LabelPlayer1Score = new System.Windows.Forms.Label();
            this.m_LabelScoreSeparator = new System.Windows.Forms.Label();
            this.m_LabelPlayer2Score = new System.Windows.Forms.Label();
            this.m_ButtonSwitchToMillennial = new System.Windows.Forms.Button();
            this.m_PanelBoardActionsView = new Ex05.Connect4UI.Boomer.Components.PanelBoardActionsView();
            this.m_PanelBoardView = new Ex05.Connect4UI.Boomer.Components.PanelBoardView();
            this.m_TableLayoutPanelScore.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_TableLayoutPanelScore
            // 
            this.m_TableLayoutPanelScore.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.m_TableLayoutPanelScore.ColumnCount = 3;
            this.m_TableLayoutPanelScore.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.5F));
            this.m_TableLayoutPanelScore.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.m_TableLayoutPanelScore.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.5F));
            this.m_TableLayoutPanelScore.Controls.Add(this.m_LabelPlayer1Score, 0, 0);
            this.m_TableLayoutPanelScore.Controls.Add(this.m_LabelScoreSeparator, 1, 0);
            this.m_TableLayoutPanelScore.Controls.Add(this.m_LabelPlayer2Score, 2, 0);
            this.m_TableLayoutPanelScore.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_TableLayoutPanelScore.Location = new System.Drawing.Point(0, 291);
            this.m_TableLayoutPanelScore.Name = "m_TableLayoutPanelScore";
            this.m_TableLayoutPanelScore.RowCount = 1;
            this.m_TableLayoutPanelScore.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.m_TableLayoutPanelScore.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.m_TableLayoutPanelScore.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.m_TableLayoutPanelScore.Size = new System.Drawing.Size(323, 22);
            this.m_TableLayoutPanelScore.TabIndex = 5;
            // 
            // m_LabelPlayer1Score
            // 
            this.m_LabelPlayer1Score.AutoEllipsis = true;
            this.m_LabelPlayer1Score.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_LabelPlayer1Score.ForeColor = System.Drawing.SystemColors.ControlText;
            this.m_LabelPlayer1Score.Location = new System.Drawing.Point(3, 0);
            this.m_LabelPlayer1Score.Name = "m_LabelPlayer1Score";
            this.m_LabelPlayer1Score.Size = new System.Drawing.Size(147, 22);
            this.m_LabelPlayer1Score.TabIndex = 0;
            this.m_LabelPlayer1Score.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_LabelScoreSeparator
            // 
            this.m_LabelScoreSeparator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_LabelScoreSeparator.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_LabelScoreSeparator.ForeColor = System.Drawing.SystemColors.ControlText;
            this.m_LabelScoreSeparator.Location = new System.Drawing.Point(156, 0);
            this.m_LabelScoreSeparator.Name = "m_LabelScoreSeparator";
            this.m_LabelScoreSeparator.Size = new System.Drawing.Size(10, 22);
            this.m_LabelScoreSeparator.TabIndex = 2;
            this.m_LabelScoreSeparator.Text = "|";
            this.m_LabelScoreSeparator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_LabelPlayer2Score
            // 
            this.m_LabelPlayer2Score.AutoEllipsis = true;
            this.m_LabelPlayer2Score.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_LabelPlayer2Score.ForeColor = System.Drawing.SystemColors.ControlText;
            this.m_LabelPlayer2Score.Location = new System.Drawing.Point(172, 0);
            this.m_LabelPlayer2Score.Name = "m_LabelPlayer2Score";
            this.m_LabelPlayer2Score.Size = new System.Drawing.Size(148, 22);
            this.m_LabelPlayer2Score.TabIndex = 1;
            this.m_LabelPlayer2Score.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_ButtonSwitchToMillennial
            // 
            this.m_ButtonSwitchToMillennial.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_ButtonSwitchToMillennial.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_ButtonSwitchToMillennial.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.m_ButtonSwitchToMillennial.Location = new System.Drawing.Point(0, 313);
            this.m_ButtonSwitchToMillennial.Name = "m_ButtonSwitchToMillennial";
            this.m_ButtonSwitchToMillennial.Size = new System.Drawing.Size(323, 23);
            this.m_ButtonSwitchToMillennial.TabIndex = 12;
            this.m_ButtonSwitchToMillennial.Text = global::Ex05.Connect4UI.Properties.Resources.TextGoToSeriousView;
            this.m_ButtonSwitchToMillennial.UseVisualStyleBackColor = true;
            this.m_ButtonSwitchToMillennial.Click += new System.EventHandler(this.buttonSwitchToMillennial_Click);
            // 
            // m_PanelBoardActionsView
            // 
            this.m_PanelBoardActionsView.AutoSize = true;
            this.m_PanelBoardActionsView.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.m_PanelBoardActionsView.Count = 6;
            this.m_PanelBoardActionsView.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_PanelBoardActionsView.Location = new System.Drawing.Point(0, 0);
            this.m_PanelBoardActionsView.Name = "m_PanelBoardActionsView";
            this.m_PanelBoardActionsView.Size = new System.Drawing.Size(323, 70);
            this.m_PanelBoardActionsView.TabIndex = 0;
            // 
            // m_PanelBoardView
            // 
            this.m_PanelBoardView.AutoSize = true;
            this.m_PanelBoardView.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.m_PanelBoardView.Board = null;
            this.m_PanelBoardView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_PanelBoardView.Location = new System.Drawing.Point(0, 70);
            this.m_PanelBoardView.Name = "m_PanelBoardView";
            this.m_PanelBoardView.Size = new System.Drawing.Size(323, 221);
            this.m_PanelBoardView.TabIndex = 1;
            // 
            // FormConnectFourMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(323, 336);
            this.Controls.Add(this.m_PanelBoardView);
            this.Controls.Add(this.m_TableLayoutPanelScore);
            this.Controls.Add(this.m_ButtonSwitchToMillennial);
            this.Controls.Add(this.m_PanelBoardActionsView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormConnectFourMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = global::Ex05.Connect4UI.Properties.Resources.TextConnectFourBoomer;
            this.m_TableLayoutPanelScore.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private Ex05.Connect4UI.Boomer.Components.PanelBoardActionsView m_PanelBoardActionsView;
		private Ex05.Connect4UI.Boomer.Components.PanelBoardView m_PanelBoardView;
		private System.Windows.Forms.TableLayoutPanel m_TableLayoutPanelScore;
		private System.Windows.Forms.Label m_LabelPlayer1Score;
		private System.Windows.Forms.Label m_LabelScoreSeparator;
		private System.Windows.Forms.Label m_LabelPlayer2Score;
		private System.Windows.Forms.Button m_ButtonSwitchToMillennial;
	}
}
