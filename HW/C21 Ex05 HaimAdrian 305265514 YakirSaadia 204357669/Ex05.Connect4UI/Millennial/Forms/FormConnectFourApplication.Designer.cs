namespace Ex05.Connect4UI.Millennial.Forms
{
	internal partial class FormConnectFourApplication
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormConnectFourApplication));
            this.m_StatusStrip = new System.Windows.Forms.StatusStrip();
            this.m_ToolStripStatusLabelGameStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.m_ToolStripProgressBarPc = new System.Windows.Forms.ToolStripProgressBar();
            this.m_PictureBoxTitle = new System.Windows.Forms.PictureBox();
            this.m_MenuStripActions = new System.Windows.Forms.MenuStrip();
            this.m_ToolStripMenuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.m_ToolStripMenuItemHome = new System.Windows.Forms.ToolStripMenuItem();
            this.m_ToolStripMenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.m_ToolStripMenuItemGame = new System.Windows.Forms.ToolStripMenuItem();
            this.m_ToolStripMenuItemRestart = new System.Windows.Forms.ToolStripMenuItem();
            this.m_ToolStripMenuItemUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.m_ToolStripMenuItemRedo = new System.Windows.Forms.ToolStripMenuItem();
            this.m_ToolStripMenuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.m_ToolStripMenuItemBoomerView = new System.Windows.Forms.ToolStripMenuItem();
            this.m_TableLayoutPanelScore = new System.Windows.Forms.TableLayoutPanel();
            this.m_LabelPlayer1Score = new System.Windows.Forms.Label();
            this.m_LabelScoreSeparator = new System.Windows.Forms.Label();
            this.m_LabelPlayer2Score = new System.Windows.Forms.Label();
            this.m_PanelBoardView = new Ex05.Connect4UI.Millennial.Components.Board.PanelBoardView();
            this.m_PanelGameSettings = new Ex05.Connect4UI.Millennial.Components.PanelDoubleBuffered();
            this.m_PanelStartButtons = new System.Windows.Forms.Panel();
            this.m_GameButtonStart = new Ex05.Connect4UI.Millennial.Components.GameButton();
            this.m_GameButtonBack = new Ex05.Connect4UI.Millennial.Components.GameButton();
            this.m_GameButtonMultiPlayer = new Ex05.Connect4UI.Millennial.Components.GameButton();
            this.m_GameButtonPc = new Ex05.Connect4UI.Millennial.Components.GameButton();
            this.m_StatusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_PictureBoxTitle)).BeginInit();
            this.m_MenuStripActions.SuspendLayout();
            this.m_TableLayoutPanelScore.SuspendLayout();
            this.m_PanelBoardView.SuspendLayout();
            this.m_PanelGameSettings.SuspendLayout();
            this.m_PanelStartButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_StatusStrip
            // 
            this.m_StatusStrip.BackColor = System.Drawing.Color.DodgerBlue;
            this.m_StatusStrip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.m_StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_ToolStripStatusLabelGameStatus,
            this.m_ToolStripProgressBarPc});
            this.m_StatusStrip.Location = new System.Drawing.Point(0, 419);
            this.m_StatusStrip.Name = "m_StatusStrip";
            this.m_StatusStrip.Size = new System.Drawing.Size(464, 22);
            this.m_StatusStrip.SizingGrip = false;
            this.m_StatusStrip.TabIndex = 1;
            // 
            // m_ToolStripStatusLabelGameStatus
            // 
            this.m_ToolStripStatusLabelGameStatus.ForeColor = System.Drawing.Color.White;
            this.m_ToolStripStatusLabelGameStatus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_ToolStripStatusLabelGameStatus.Name = "m_ToolStripStatusLabelGameStatus";
            this.m_ToolStripStatusLabelGameStatus.Size = new System.Drawing.Size(449, 17);
            this.m_ToolStripStatusLabelGameStatus.Spring = true;
            this.m_ToolStripStatusLabelGameStatus.Text = global::Ex05.Connect4UI.Properties.Resources.TextReady;
            this.m_ToolStripStatusLabelGameStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_ToolStripProgressBarPc
            // 
            this.m_ToolStripProgressBarPc.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.m_ToolStripProgressBarPc.MarqueeAnimationSpeed = 25;
            this.m_ToolStripProgressBarPc.Name = "m_ToolStripProgressBarPc";
            this.m_ToolStripProgressBarPc.Size = new System.Drawing.Size(100, 16);
            this.m_ToolStripProgressBarPc.Step = 1;
            this.m_ToolStripProgressBarPc.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.m_ToolStripProgressBarPc.Visible = false;
            // 
            // m_PictureBoxTitle
            // 
            this.m_PictureBoxTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_PictureBoxTitle.Image = ((System.Drawing.Image)(resources.GetObject("m_PictureBoxTitle.Image")));
            this.m_PictureBoxTitle.Location = new System.Drawing.Point(0, 27);
            this.m_PictureBoxTitle.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.m_PictureBoxTitle.Name = "m_PictureBoxTitle";
            this.m_PictureBoxTitle.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.m_PictureBoxTitle.Size = new System.Drawing.Size(464, 62);
            this.m_PictureBoxTitle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.m_PictureBoxTitle.TabIndex = 3;
            this.m_PictureBoxTitle.TabStop = false;
            // 
            // m_MenuStripActions
            // 
            this.m_MenuStripActions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.m_MenuStripActions.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.m_MenuStripActions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_ToolStripMenuItemFile,
            this.m_ToolStripMenuItemGame,
            this.m_ToolStripMenuItemHelp});
            this.m_MenuStripActions.Location = new System.Drawing.Point(0, 0);
            this.m_MenuStripActions.Name = "m_MenuStripActions";
            this.m_MenuStripActions.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.m_MenuStripActions.Size = new System.Drawing.Size(464, 27);
            this.m_MenuStripActions.TabIndex = 0;
            // 
            // m_ToolStripMenuItemFile
            // 
            this.m_ToolStripMenuItemFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.m_ToolStripMenuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_ToolStripMenuItemHome,
            this.m_ToolStripMenuItemExit});
            this.m_ToolStripMenuItemFile.ForeColor = System.Drawing.Color.White;
            this.m_ToolStripMenuItemFile.Name = "m_ToolStripMenuItemFile";
            this.m_ToolStripMenuItemFile.Size = new System.Drawing.Size(41, 23);
            this.m_ToolStripMenuItemFile.Text = global::Ex05.Connect4UI.Properties.Resources.TextFile;
            this.m_ToolStripMenuItemFile.DropDownClosed += new System.EventHandler(this.toolStripMenuItem_DropDownToggle);
            this.m_ToolStripMenuItemFile.DropDownOpened += new System.EventHandler(this.toolStripMenuItem_DropDownToggle);
            // 
            // m_ToolStripMenuItemHome
            // 
            this.m_ToolStripMenuItemHome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.m_ToolStripMenuItemHome.ForeColor = System.Drawing.Color.White;
            this.m_ToolStripMenuItemHome.Image = global::Ex05.Connect4UI.Properties.Resources.Home;
            this.m_ToolStripMenuItemHome.Name = "m_ToolStripMenuItemHome";
            this.m_ToolStripMenuItemHome.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.m_ToolStripMenuItemHome.Size = new System.Drawing.Size(164, 24);
            this.m_ToolStripMenuItemHome.Text = global::Ex05.Connect4UI.Properties.Resources.TextHome;
            this.m_ToolStripMenuItemHome.Click += new System.EventHandler(this.homeToolStripMenuItem_Click);
            // 
            // m_ToolStripMenuItemExit
            // 
            this.m_ToolStripMenuItemExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.m_ToolStripMenuItemExit.ForeColor = System.Drawing.Color.White;
            this.m_ToolStripMenuItemExit.Image = global::Ex05.Connect4UI.Properties.Resources.Exit;
            this.m_ToolStripMenuItemExit.Name = "m_ToolStripMenuItemExit";
            this.m_ToolStripMenuItemExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.m_ToolStripMenuItemExit.Size = new System.Drawing.Size(164, 24);
            this.m_ToolStripMenuItemExit.Text = global::Ex05.Connect4UI.Properties.Resources.TextExit;
            this.m_ToolStripMenuItemExit.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // m_ToolStripMenuItemGame
            // 
            this.m_ToolStripMenuItemGame.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_ToolStripMenuItemRestart,
            this.m_ToolStripMenuItemUndo,
            this.m_ToolStripMenuItemRedo});
            this.m_ToolStripMenuItemGame.ForeColor = System.Drawing.Color.White;
            this.m_ToolStripMenuItemGame.Name = "m_ToolStripMenuItemGame";
            this.m_ToolStripMenuItemGame.Size = new System.Drawing.Size(57, 23);
            this.m_ToolStripMenuItemGame.Text = global::Ex05.Connect4UI.Properties.Resources.TextGame;
            this.m_ToolStripMenuItemGame.DropDownClosed += new System.EventHandler(this.toolStripMenuItem_DropDownToggle);
            this.m_ToolStripMenuItemGame.DropDownOpened += new System.EventHandler(this.toolStripMenuItem_DropDownToggle);
            // 
            // m_ToolStripMenuItemRestart
            // 
            this.m_ToolStripMenuItemRestart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.m_ToolStripMenuItemRestart.ForeColor = System.Drawing.Color.White;
            this.m_ToolStripMenuItemRestart.Image = global::Ex05.Connect4UI.Properties.Resources.Reload;
            this.m_ToolStripMenuItemRestart.Name = "m_ToolStripMenuItemRestart";
            this.m_ToolStripMenuItemRestart.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.m_ToolStripMenuItemRestart.Size = new System.Drawing.Size(170, 24);
            this.m_ToolStripMenuItemRestart.Text = global::Ex05.Connect4UI.Properties.Resources.TextRestart;
            this.m_ToolStripMenuItemRestart.Click += new System.EventHandler(this.restartToolStripMenuItem_Click);
            // 
            // m_ToolStripMenuItemUndo
            // 
            this.m_ToolStripMenuItemUndo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.m_ToolStripMenuItemUndo.ForeColor = System.Drawing.Color.White;
            this.m_ToolStripMenuItemUndo.Image = global::Ex05.Connect4UI.Properties.Resources.Undo;
            this.m_ToolStripMenuItemUndo.Name = "m_ToolStripMenuItemUndo";
            this.m_ToolStripMenuItemUndo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.m_ToolStripMenuItemUndo.Size = new System.Drawing.Size(170, 24);
            this.m_ToolStripMenuItemUndo.Text = global::Ex05.Connect4UI.Properties.Resources.TextUndo;
			this.m_ToolStripMenuItemUndo.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // m_ToolStripMenuItemRedo
            // 
            this.m_ToolStripMenuItemRedo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.m_ToolStripMenuItemRedo.ForeColor = System.Drawing.Color.White;
            this.m_ToolStripMenuItemRedo.Image = global::Ex05.Connect4UI.Properties.Resources.Redo;
            this.m_ToolStripMenuItemRedo.Name = "m_ToolStripMenuItemRedo";
            this.m_ToolStripMenuItemRedo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.m_ToolStripMenuItemRedo.Size = new System.Drawing.Size(170, 24);
            this.m_ToolStripMenuItemRedo.Text = global::Ex05.Connect4UI.Properties.Resources.TextRedo;
			this.m_ToolStripMenuItemRedo.Click += new System.EventHandler(this.redoToolStripMenuItem_Click);
            // 
            // m_ToolStripMenuItemHelp
            // 
            this.m_ToolStripMenuItemHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_ToolStripMenuItemBoomerView});
            this.m_ToolStripMenuItemHelp.ForeColor = System.Drawing.Color.White;
            this.m_ToolStripMenuItemHelp.Name = "m_ToolStripMenuItemHelp";
            this.m_ToolStripMenuItemHelp.Size = new System.Drawing.Size(49, 23);
            this.m_ToolStripMenuItemHelp.Text = global::Ex05.Connect4UI.Properties.Resources.TextHelp;
			this.m_ToolStripMenuItemHelp.DropDownClosed += new System.EventHandler(this.toolStripMenuItem_DropDownToggle);
            this.m_ToolStripMenuItemHelp.DropDownOpened += new System.EventHandler(this.toolStripMenuItem_DropDownToggle);
            // 
            // m_ToolStripMenuItemBoomerView
            // 
            this.m_ToolStripMenuItemBoomerView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.m_ToolStripMenuItemBoomerView.ForeColor = System.Drawing.Color.White;
            this.m_ToolStripMenuItemBoomerView.Image = global::Ex05.Connect4UI.Properties.Resources.Poop;
            this.m_ToolStripMenuItemBoomerView.Name = "m_ToolStripMenuItemBoomerView";
            this.m_ToolStripMenuItemBoomerView.Size = new System.Drawing.Size(208, 24);
            this.m_ToolStripMenuItemBoomerView.Text = global::Ex05.Connect4UI.Properties.Resources.TextBackToBoomer;
			this.m_ToolStripMenuItemBoomerView.Click += new System.EventHandler(this.boomerViewToolStripMenuItem_Click);
            // 
            // m_TableLayoutPanelScore
            // 
            this.m_TableLayoutPanelScore.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.m_TableLayoutPanelScore.ColumnCount = 3;
            this.m_TableLayoutPanelScore.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.m_TableLayoutPanelScore.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.m_TableLayoutPanelScore.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.m_TableLayoutPanelScore.Controls.Add(this.m_LabelPlayer1Score, 0, 0);
            this.m_TableLayoutPanelScore.Controls.Add(this.m_LabelScoreSeparator, 1, 0);
            this.m_TableLayoutPanelScore.Controls.Add(this.m_LabelPlayer2Score, 2, 0);
            this.m_TableLayoutPanelScore.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_TableLayoutPanelScore.Location = new System.Drawing.Point(0, 397);
            this.m_TableLayoutPanelScore.Name = "m_TableLayoutPanelScore";
            this.m_TableLayoutPanelScore.RowCount = 1;
            this.m_TableLayoutPanelScore.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.m_TableLayoutPanelScore.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.m_TableLayoutPanelScore.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.m_TableLayoutPanelScore.Size = new System.Drawing.Size(464, 22);
            this.m_TableLayoutPanelScore.TabIndex = 4;
            this.m_TableLayoutPanelScore.Visible = false;
            // 
            // m_LabelPlayer1Score
            // 
            this.m_LabelPlayer1Score.AutoEllipsis = true;
            this.m_LabelPlayer1Score.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_LabelPlayer1Score.Font = new System.Drawing.Font("Lucida Calligraphy", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_LabelPlayer1Score.ForeColor = System.Drawing.Color.White;
            this.m_LabelPlayer1Score.Location = new System.Drawing.Point(3, 0);
            this.m_LabelPlayer1Score.Name = "m_LabelPlayer1Score";
            this.m_LabelPlayer1Score.Size = new System.Drawing.Size(202, 22);
            this.m_LabelPlayer1Score.TabIndex = 0;
            this.m_LabelPlayer1Score.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_LabelScoreSeparator
            // 
            this.m_LabelScoreSeparator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_LabelScoreSeparator.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_LabelScoreSeparator.ForeColor = System.Drawing.Color.White;
            this.m_LabelScoreSeparator.Location = new System.Drawing.Point(211, 0);
            this.m_LabelScoreSeparator.Name = "m_LabelScoreSeparator";
            this.m_LabelScoreSeparator.Size = new System.Drawing.Size(40, 22);
            this.m_LabelScoreSeparator.TabIndex = 2;
            this.m_LabelScoreSeparator.Text = "|";
            this.m_LabelScoreSeparator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_LabelPlayer2Score
            // 
            this.m_LabelPlayer2Score.AutoEllipsis = true;
            this.m_LabelPlayer2Score.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_LabelPlayer2Score.Font = new System.Drawing.Font("Lucida Calligraphy", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_LabelPlayer2Score.ForeColor = System.Drawing.Color.White;
            this.m_LabelPlayer2Score.Location = new System.Drawing.Point(257, 0);
            this.m_LabelPlayer2Score.Name = "m_LabelPlayer2Score";
            this.m_LabelPlayer2Score.Size = new System.Drawing.Size(204, 22);
            this.m_LabelPlayer2Score.TabIndex = 1;
            this.m_LabelPlayer2Score.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_PanelBoardView
            // 
            this.m_PanelBoardView.Board = null;
            this.m_PanelBoardView.Controls.Add(this.m_PanelGameSettings);
            this.m_PanelBoardView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_PanelBoardView.Location = new System.Drawing.Point(0, 89);
            this.m_PanelBoardView.Name = "m_PanelBoardView";
            this.m_PanelBoardView.Size = new System.Drawing.Size(464, 308);
            this.m_PanelBoardView.TabIndex = 2;
            // 
            // m_PanelGameSettings
            // 
            this.m_PanelGameSettings.Controls.Add(this.m_PanelStartButtons);
            this.m_PanelGameSettings.Controls.Add(this.m_GameButtonMultiPlayer);
            this.m_PanelGameSettings.Controls.Add(this.m_GameButtonPc);
            this.m_PanelGameSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_PanelGameSettings.Location = new System.Drawing.Point(0, 0);
            this.m_PanelGameSettings.Name = "m_PanelGameSettings";
            this.m_PanelGameSettings.Padding = new System.Windows.Forms.Padding(10);
            this.m_PanelGameSettings.Size = new System.Drawing.Size(464, 308);
            this.m_PanelGameSettings.TabIndex = 0;
            // 
            // m_PanelStartButtons
            // 
            this.m_PanelStartButtons.Controls.Add(this.m_GameButtonStart);
            this.m_PanelStartButtons.Controls.Add(this.m_GameButtonBack);
            this.m_PanelStartButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_PanelStartButtons.Location = new System.Drawing.Point(10, 246);
            this.m_PanelStartButtons.Name = "m_PanelStartButtons";
            this.m_PanelStartButtons.Size = new System.Drawing.Size(444, 52);
            this.m_PanelStartButtons.TabIndex = 4;
            this.m_PanelStartButtons.Visible = false;
            // 
            // m_GameButtonStart
            // 
            this.m_GameButtonStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_GameButtonStart.BackColor = System.Drawing.Color.Transparent;
            this.m_GameButtonStart.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("m_GameButtonStart.BackgroundImage")));
            this.m_GameButtonStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.m_GameButtonStart.FlatAppearance.BorderSize = 0;
            this.m_GameButtonStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_GameButtonStart.Font = new System.Drawing.Font("Lucida Calligraphy", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_GameButtonStart.ForeColor = System.Drawing.Color.White;
            this.m_GameButtonStart.Location = new System.Drawing.Point(116, 5);
            this.m_GameButtonStart.Name = "m_GameButtonStart";
            this.m_GameButtonStart.Size = new System.Drawing.Size(100, 42);
            this.m_GameButtonStart.TabIndex = 2;
            this.m_GameButtonStart.TabStop = false;
            this.m_GameButtonStart.Text = global::Ex05.Connect4UI.Properties.Resources.TextStart;
			this.m_GameButtonStart.UseVisualStyleBackColor = false;
            this.m_GameButtonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // m_GameButtonBack
            // 
            this.m_GameButtonBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_GameButtonBack.BackColor = System.Drawing.Color.Transparent;
            this.m_GameButtonBack.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("m_GameButtonBack.BackgroundImage")));
            this.m_GameButtonBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.m_GameButtonBack.FlatAppearance.BorderSize = 0;
            this.m_GameButtonBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_GameButtonBack.Font = new System.Drawing.Font("Lucida Calligraphy", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_GameButtonBack.ForeColor = System.Drawing.Color.White;
            this.m_GameButtonBack.Location = new System.Drawing.Point(228, 5);
            this.m_GameButtonBack.Name = "m_GameButtonBack";
            this.m_GameButtonBack.Size = new System.Drawing.Size(100, 42);
            this.m_GameButtonBack.TabIndex = 3;
            this.m_GameButtonBack.TabStop = false;
            this.m_GameButtonBack.Text = global::Ex05.Connect4UI.Properties.Resources.TextBack;
            this.m_GameButtonBack.UseVisualStyleBackColor = false;
            this.m_GameButtonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // m_GameButtonMultiPlayer
            // 
            this.m_GameButtonMultiPlayer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_GameButtonMultiPlayer.BackColor = System.Drawing.Color.Transparent;
            this.m_GameButtonMultiPlayer.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("m_GameButtonMultiPlayer.BackgroundImage")));
            this.m_GameButtonMultiPlayer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.m_GameButtonMultiPlayer.FlatAppearance.BorderSize = 0;
            this.m_GameButtonMultiPlayer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_GameButtonMultiPlayer.Font = new System.Drawing.Font("Lucida Calligraphy", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_GameButtonMultiPlayer.ForeColor = System.Drawing.Color.White;
            this.m_GameButtonMultiPlayer.Location = new System.Drawing.Point(126, 170);
            this.m_GameButtonMultiPlayer.Name = "m_GameButtonMultiPlayer";
            this.m_GameButtonMultiPlayer.Size = new System.Drawing.Size(212, 80);
            this.m_GameButtonMultiPlayer.TabIndex = 0;
            this.m_GameButtonMultiPlayer.TabStop = false;
            this.m_GameButtonMultiPlayer.Text = global::Ex05.Connect4UI.Properties.Resources.TextMultiPlayer;
			this.m_GameButtonMultiPlayer.UseVisualStyleBackColor = false;
            this.m_GameButtonMultiPlayer.Click += new System.EventHandler(this.gameButtonMultiPlayer_Click);
            // 
            // m_GameButtonPc
            // 
            this.m_GameButtonPc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_GameButtonPc.BackColor = System.Drawing.Color.Transparent;
            this.m_GameButtonPc.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("m_GameButtonPc.BackgroundImage")));
            this.m_GameButtonPc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.m_GameButtonPc.FlatAppearance.BorderSize = 0;
            this.m_GameButtonPc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_GameButtonPc.Font = new System.Drawing.Font("Lucida Calligraphy", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_GameButtonPc.ForeColor = System.Drawing.Color.White;
            this.m_GameButtonPc.Location = new System.Drawing.Point(126, 80);
            this.m_GameButtonPc.Name = "m_GameButtonPc";
            this.m_GameButtonPc.Size = new System.Drawing.Size(212, 80);
            this.m_GameButtonPc.TabIndex = 1;
            this.m_GameButtonPc.TabStop = false;
            this.m_GameButtonPc.Text = global::Ex05.Connect4UI.Properties.Resources.TextPc;
			this.m_GameButtonPc.UseVisualStyleBackColor = false;
            this.m_GameButtonPc.Click += new System.EventHandler(this.gameButtonPc_Click);
            // 
            // FormConnectFourApplication
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.ClientSize = new System.Drawing.Size(464, 441);
            this.Controls.Add(this.m_PanelBoardView);
            this.Controls.Add(this.m_PictureBoxTitle);
            this.Controls.Add(this.m_MenuStripActions);
            this.Controls.Add(this.m_TableLayoutPanelScore);
            this.Controls.Add(this.m_StatusStrip);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.m_MenuStripActions;
            this.MinimumSize = new System.Drawing.Size(480, 480);
            this.Name = "FormConnectFourApplication";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = global::Ex05.Connect4UI.Properties.Resources.TextConnectFour;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formConnectFourApplication_FormClosing);
            this.m_StatusStrip.ResumeLayout(false);
            this.m_StatusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_PictureBoxTitle)).EndInit();
            this.m_MenuStripActions.ResumeLayout(false);
            this.m_MenuStripActions.PerformLayout();
            this.m_TableLayoutPanelScore.ResumeLayout(false);
            this.m_PanelBoardView.ResumeLayout(false);
            this.m_PanelGameSettings.ResumeLayout(false);
            this.m_PanelStartButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip m_MenuStripActions;
		private System.Windows.Forms.PictureBox m_PictureBoxTitle;
		private System.Windows.Forms.StatusStrip m_StatusStrip;
		private System.Windows.Forms.ToolStripStatusLabel m_ToolStripStatusLabelGameStatus;
		private System.Windows.Forms.ToolStripProgressBar m_ToolStripProgressBarPc;
		private Ex05.Connect4UI.Millennial.Components.Board.PanelBoardView m_PanelBoardView;
		private Ex05.Connect4UI.Millennial.Components.PanelDoubleBuffered m_PanelGameSettings;
		private Ex05.Connect4UI.Millennial.Components.GameButton m_GameButtonPc;
		private Ex05.Connect4UI.Millennial.Components.GameButton m_GameButtonMultiPlayer;
		private System.Windows.Forms.ToolStripMenuItem m_ToolStripMenuItemFile;
		private System.Windows.Forms.ToolStripMenuItem m_ToolStripMenuItemHome;
		private System.Windows.Forms.ToolStripMenuItem m_ToolStripMenuItemExit;
		private System.Windows.Forms.ToolStripMenuItem m_ToolStripMenuItemGame;
		private System.Windows.Forms.ToolStripMenuItem m_ToolStripMenuItemRestart;
		private System.Windows.Forms.ToolStripMenuItem m_ToolStripMenuItemUndo;
		private System.Windows.Forms.ToolStripMenuItem m_ToolStripMenuItemRedo;
		private System.Windows.Forms.ToolStripMenuItem m_ToolStripMenuItemHelp;
		private System.Windows.Forms.ToolStripMenuItem m_ToolStripMenuItemBoomerView;
		private Ex05.Connect4UI.Millennial.Components.GameButton m_GameButtonBack;
		private Ex05.Connect4UI.Millennial.Components.GameButton m_GameButtonStart;
		private System.Windows.Forms.Panel m_PanelStartButtons;
		private System.Windows.Forms.TableLayoutPanel m_TableLayoutPanelScore;
		private System.Windows.Forms.Label m_LabelScoreSeparator;
		private System.Windows.Forms.Label m_LabelPlayer2Score;
		private System.Windows.Forms.Label m_LabelPlayer1Score;
	}
}