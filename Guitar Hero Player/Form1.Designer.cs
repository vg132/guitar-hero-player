
namespace GuitarHeroPlayer
{
	partial class Form1
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.gameTimer = new System.Windows.Forms.Timer(this.components);
			this.orangeNoteDetector = new GuitarHeroPlayer.Controls.NoteDetector();
			this.redNoteDetector = new GuitarHeroPlayer.Controls.NoteDetector();
			this.greenNoteDetector = new GuitarHeroPlayer.Controls.NoteDetector();
			this.yellowNoteDetector = new GuitarHeroPlayer.Controls.NoteDetector();
			this.blueNoteDetector = new GuitarHeroPlayer.Controls.NoteDetector();
			this.gameRunningDetectorRock = new GuitarHeroPlayer.Controls.BrightnessDetector();
			this.gameRunningDetectorScore = new GuitarHeroPlayer.Controls.BrightnessDetector();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// gameTimer
			// 
			this.gameTimer.Enabled = true;
			this.gameTimer.Interval = 33;
			this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
			// 
			// orangeNoteDetector
			// 
			this.orangeNoteDetector.BackColor = System.Drawing.Color.Orange;
			this.orangeNoteDetector.BrightnessThreshold = 0.5F;
			this.orangeNoteDetector.Delay = 100;
			this.orangeNoteDetector.Location = new System.Drawing.Point(802, 569);
			this.orangeNoteDetector.Name = "orangeNoteDetector";
			this.orangeNoteDetector.NoteType = GuitarHeroPlayer.Controls.NoteType.Orange;
			this.orangeNoteDetector.SendKeys = true;
			this.orangeNoteDetector.Size = new System.Drawing.Size(12, 12);
			this.orangeNoteDetector.TabIndex = 5;
			// 
			// redNoteDetector
			// 
			this.redNoteDetector.BackColor = System.Drawing.Color.Red;
			this.redNoteDetector.BrightnessThreshold = 0.5F;
			this.redNoteDetector.Delay = 100;
			this.redNoteDetector.Location = new System.Drawing.Point(559, 569);
			this.redNoteDetector.Name = "redNoteDetector";
			this.redNoteDetector.NoteType = GuitarHeroPlayer.Controls.NoteType.Red;
			this.redNoteDetector.SendKeys = true;
			this.redNoteDetector.Size = new System.Drawing.Size(12, 12);
			this.redNoteDetector.TabIndex = 6;
			// 
			// greenNoteDetector
			// 
			this.greenNoteDetector.BackColor = System.Drawing.Color.Green;
			this.greenNoteDetector.BrightnessThreshold = 0.5F;
			this.greenNoteDetector.Delay = 90;
			this.greenNoteDetector.Location = new System.Drawing.Point(481, 569);
			this.greenNoteDetector.Name = "greenNoteDetector";
			this.greenNoteDetector.NoteType = GuitarHeroPlayer.Controls.NoteType.Green;
			this.greenNoteDetector.SendKeys = true;
			this.greenNoteDetector.Size = new System.Drawing.Size(12, 12);
			this.greenNoteDetector.TabIndex = 7;
			// 
			// yellowNoteDetector
			// 
			this.yellowNoteDetector.BackColor = System.Drawing.Color.Yellow;
			this.yellowNoteDetector.BrightnessThreshold = 0.5F;
			this.yellowNoteDetector.Delay = 100;
			this.yellowNoteDetector.Location = new System.Drawing.Point(641, 569);
			this.yellowNoteDetector.Name = "yellowNoteDetector";
			this.yellowNoteDetector.NoteType = GuitarHeroPlayer.Controls.NoteType.Yellow;
			this.yellowNoteDetector.SendKeys = true;
			this.yellowNoteDetector.Size = new System.Drawing.Size(12, 12);
			this.yellowNoteDetector.TabIndex = 8;
			// 
			// blueNoteDetector
			// 
			this.blueNoteDetector.BackColor = System.Drawing.Color.Blue;
			this.blueNoteDetector.BrightnessThreshold = 0.5F;
			this.blueNoteDetector.Delay = 100;
			this.blueNoteDetector.Location = new System.Drawing.Point(721, 569);
			this.blueNoteDetector.Name = "blueNoteDetector";
			this.blueNoteDetector.NoteType = GuitarHeroPlayer.Controls.NoteType.Blue;
			this.blueNoteDetector.SendKeys = true;
			this.blueNoteDetector.Size = new System.Drawing.Size(12, 12);
			this.blueNoteDetector.TabIndex = 9;
			// 
			// gameRunningDetectorRock
			// 
			this.gameRunningDetectorRock.Location = new System.Drawing.Point(926, 634);
			this.gameRunningDetectorRock.LowerThreshold = 0.27F;
			this.gameRunningDetectorRock.Name = "gameRunningDetectorRock";
			this.gameRunningDetectorRock.Size = new System.Drawing.Size(112, 20);
			this.gameRunningDetectorRock.TabIndex = 10;
			this.gameRunningDetectorRock.UpperThreshold = 0.28F;
			this.gameRunningDetectorRock.EntersThreshold += new System.EventHandler(this.gameRunningDetector_EntersThreshold);
			this.gameRunningDetectorRock.ExitsThreshold += new System.EventHandler(this.gameRunningDetector_ExitsThreshold);
			// 
			// gameRunningDetectorScore
			// 
			this.gameRunningDetectorScore.Location = new System.Drawing.Point(242, 634);
			this.gameRunningDetectorScore.LowerThreshold = 0.17F;
			this.gameRunningDetectorScore.Name = "gameRunningDetectorScore";
			this.gameRunningDetectorScore.Size = new System.Drawing.Size(139, 20);
			this.gameRunningDetectorScore.TabIndex = 11;
			this.gameRunningDetectorScore.UpperThreshold = 0.18F;
			this.gameRunningDetectorScore.EntersThreshold += new System.EventHandler(this.gameRunningDetector_EntersThreshold);
			this.gameRunningDetectorScore.ExitsThreshold += new System.EventHandler(this.gameRunningDetector_ExitsThreshold);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(132, 118);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 12;
			this.button1.Text = "button1";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.ClientSize = new System.Drawing.Size(1118, 728);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.gameRunningDetectorScore);
			this.Controls.Add(this.gameRunningDetectorRock);
			this.Controls.Add(this.blueNoteDetector);
			this.Controls.Add(this.yellowNoteDetector);
			this.Controls.Add(this.greenNoteDetector);
			this.Controls.Add(this.redNoteDetector);
			this.Controls.Add(this.orangeNoteDetector);
			this.DoubleBuffered = true;
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Timer gameTimer;
		private Controls.NoteDetector orangeNoteDetector;
		private Controls.NoteDetector redNoteDetector;
		private Controls.NoteDetector greenNoteDetector;
		private Controls.NoteDetector yellowNoteDetector;
		private Controls.NoteDetector blueNoteDetector;
		private Controls.BrightnessDetector gameRunningDetectorRock;
		private Controls.BrightnessDetector gameRunningDetectorScore;
		private System.Windows.Forms.Button button1;
	}
}

