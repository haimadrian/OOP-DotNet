namespace Ex05.Connect4UI.Normal.Forms
{
	internal partial class FormMessageBox
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

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		// This must be with Capital letter, even though it is private, cause this is how VS designer generated it and it doesn't work with lower cased i.
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMessageBox));
			this.m_PanelButtons = new System.Windows.Forms.Panel();
			this.m_ButtonNo = new System.Windows.Forms.Button();
			this.m_ButtonYes = new System.Windows.Forms.Button();
			this.m_PanelContent = new System.Windows.Forms.Panel();
			this.m_LabelMessage = new System.Windows.Forms.Label();
			this.m_PictureBoxIcon = new System.Windows.Forms.PictureBox();
			this.m_PanelButtons.SuspendLayout();
			this.m_PanelContent.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.m_PictureBoxIcon)).BeginInit();
			this.SuspendLayout();
			// 
			// m_PanelButtons
			// 
			this.m_PanelButtons.Controls.Add(this.m_ButtonNo);
			this.m_PanelButtons.Controls.Add(this.m_ButtonYes);
			this.m_PanelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.m_PanelButtons.Location = new System.Drawing.Point(9, 90);
			this.m_PanelButtons.Name = "m_PanelButtons";
			this.m_PanelButtons.Size = new System.Drawing.Size(274, 38);
			this.m_PanelButtons.TabIndex = 2;
			// 
			// m_ButtonNo
			// 
			this.m_ButtonNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.m_ButtonNo.BackColor = System.Drawing.Color.IndianRed;
			this.m_ButtonNo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.m_ButtonNo.Font = new System.Drawing.Font("Lucida Calligraphy", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_ButtonNo.ForeColor = System.Drawing.Color.White;
			this.m_ButtonNo.Location = new System.Drawing.Point(173, 3);
			this.m_ButtonNo.Name = "m_ButtonNo";
			this.m_ButtonNo.Size = new System.Drawing.Size(100, 32);
			this.m_ButtonNo.TabIndex = 1;
			this.m_ButtonNo.UseVisualStyleBackColor = false;
			// 
			// m_ButtonYes
			// 
			this.m_ButtonYes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.m_ButtonYes.BackColor = System.Drawing.Color.RoyalBlue;
			this.m_ButtonYes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.m_ButtonYes.Font = new System.Drawing.Font("Lucida Calligraphy", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_ButtonYes.ForeColor = System.Drawing.Color.White;
			this.m_ButtonYes.Location = new System.Drawing.Point(67, 3);
			this.m_ButtonYes.Name = "m_ButtonYes";
			this.m_ButtonYes.Size = new System.Drawing.Size(100, 32);
			this.m_ButtonYes.TabIndex = 0;
			this.m_ButtonYes.UseVisualStyleBackColor = false;
			// 
			// m_PanelContent
			// 
			this.m_PanelContent.Controls.Add(this.m_LabelMessage);
			this.m_PanelContent.Controls.Add(this.m_PictureBoxIcon);
			this.m_PanelContent.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_PanelContent.Location = new System.Drawing.Point(9, 9);
			this.m_PanelContent.Name = "m_PanelContent";
			this.m_PanelContent.Size = new System.Drawing.Size(274, 81);
			this.m_PanelContent.TabIndex = 3;
			// 
			// m_LabelMessage
			// 
			this.m_LabelMessage.Dock = System.Windows.Forms.DockStyle.Right;
			this.m_LabelMessage.Font = new System.Drawing.Font("Lucida Calligraphy", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_LabelMessage.ForeColor = System.Drawing.Color.White;
			this.m_LabelMessage.Location = new System.Drawing.Point(41, 0);
			this.m_LabelMessage.Name = "m_LabelMessage";
			this.m_LabelMessage.Size = new System.Drawing.Size(233, 81);
			this.m_LabelMessage.TabIndex = 1;
			this.m_LabelMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_PictureBoxIcon
			// 
			this.m_PictureBoxIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.m_PictureBoxIcon.Location = new System.Drawing.Point(3, 24);
			this.m_PictureBoxIcon.Name = "m_PictureBoxIcon";
			this.m_PictureBoxIcon.Size = new System.Drawing.Size(32, 32);
			this.m_PictureBoxIcon.TabIndex = 0;
			this.m_PictureBoxIcon.TabStop = false;
			// 
			// FormMessageBox
			// 
			this.AcceptButton = this.m_ButtonYes;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
			this.CancelButton = this.m_ButtonNo;
			this.ClientSize = new System.Drawing.Size(292, 137);
			this.Controls.Add(this.m_PanelContent);
			this.Controls.Add(this.m_PanelButtons);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormMessageBox";
			this.Padding = new System.Windows.Forms.Padding(9);
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.TopMost = true;
			this.m_PanelButtons.ResumeLayout(false);
			this.m_PanelContent.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.m_PictureBoxIcon)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel m_PanelButtons;
		private System.Windows.Forms.Panel m_PanelContent;
		private System.Windows.Forms.Label m_LabelMessage;
		private System.Windows.Forms.PictureBox m_PictureBoxIcon;
		private System.Windows.Forms.Button m_ButtonYes;
		private System.Windows.Forms.Button m_ButtonNo;
	}
}
