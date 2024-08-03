
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
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			gameTimer = new System.Windows.Forms.Timer(components);
			orangeNoteDetector = new Controls.NoteDetector();
			redNoteDetector = new Controls.NoteDetector();
			greenNoteDetector = new Controls.NoteDetector();
			yellowNoteDetector = new Controls.NoteDetector();
			blueNoteDetector = new Controls.NoteDetector();
			gameRunningDetectorRock = new Controls.BrightnessDetector();
			gameRunningDetectorScore = new Controls.BrightnessDetector();
			button1 = new System.Windows.Forms.Button();
			SuspendLayout();
			// 
			// gameTimer
			// 
			gameTimer.Enabled = true;
			gameTimer.Interval = 33;
			gameTimer.Tick += gameTimer_Tick;
			// 
			// orangeNoteDetector
			// 
			orangeNoteDetector.BackColor = System.Drawing.Color.Orange;
			orangeNoteDetector.BrightnessThreshold = 0.5F;
			orangeNoteDetector.Delay = 95;
			orangeNoteDetector.Location = new System.Drawing.Point(802, 569);
			orangeNoteDetector.Name = "orangeNoteDetector";
			orangeNoteDetector.NoteType = GuitarHeroPlayer.Controls.NoteType.Orange;
			orangeNoteDetector.SendKeys = true;
			orangeNoteDetector.Size = new System.Drawing.Size(12, 12);
			orangeNoteDetector.TabIndex = 5;
			// 
			// redNoteDetector
			// 
			redNoteDetector.BackColor = System.Drawing.Color.Red;
			redNoteDetector.BrightnessThreshold = 0.5F;
			redNoteDetector.Delay = 95;
			redNoteDetector.Location = new System.Drawing.Point(559, 569);
			redNoteDetector.Name = "redNoteDetector";
			redNoteDetector.NoteType = GuitarHeroPlayer.Controls.NoteType.Red;
			redNoteDetector.SendKeys = true;
			redNoteDetector.Size = new System.Drawing.Size(12, 12);
			redNoteDetector.TabIndex = 6;
			// 
			// greenNoteDetector
			// 
			greenNoteDetector.BackColor = System.Drawing.Color.Green;
			greenNoteDetector.BrightnessThreshold = 0.5F;
			greenNoteDetector.Delay = 95;
			greenNoteDetector.Location = new System.Drawing.Point(481, 569);
			greenNoteDetector.Name = "greenNoteDetector";
			greenNoteDetector.NoteType = GuitarHeroPlayer.Controls.NoteType.Green;
			greenNoteDetector.SendKeys = true;
			greenNoteDetector.Size = new System.Drawing.Size(12, 12);
			greenNoteDetector.TabIndex = 7;
			// 
			// yellowNoteDetector
			// 
			yellowNoteDetector.BackColor = System.Drawing.Color.Yellow;
			yellowNoteDetector.BrightnessThreshold = 0.5F;
			yellowNoteDetector.Delay = 95;
			yellowNoteDetector.Location = new System.Drawing.Point(641, 569);
			yellowNoteDetector.Name = "yellowNoteDetector";
			yellowNoteDetector.NoteType = GuitarHeroPlayer.Controls.NoteType.Yellow;
			yellowNoteDetector.SendKeys = true;
			yellowNoteDetector.Size = new System.Drawing.Size(12, 12);
			yellowNoteDetector.TabIndex = 8;
			// 
			// blueNoteDetector
			// 
			blueNoteDetector.BackColor = System.Drawing.Color.Blue;
			blueNoteDetector.BrightnessThreshold = 0.5F;
			blueNoteDetector.Delay = 95;
			blueNoteDetector.Location = new System.Drawing.Point(721, 569);
			blueNoteDetector.Name = "blueNoteDetector";
			blueNoteDetector.NoteType = GuitarHeroPlayer.Controls.NoteType.Blue;
			blueNoteDetector.SendKeys = true;
			blueNoteDetector.Size = new System.Drawing.Size(12, 12);
			blueNoteDetector.TabIndex = 9;
			// 
			// gameRunningDetectorRock
			// 
			gameRunningDetectorRock.Location = new System.Drawing.Point(926, 634);
			gameRunningDetectorRock.LowerThreshold = 0.27F;
			gameRunningDetectorRock.Name = "gameRunningDetectorRock";
			gameRunningDetectorRock.Size = new System.Drawing.Size(112, 20);
			gameRunningDetectorRock.TabIndex = 10;
			gameRunningDetectorRock.UpperThreshold = 0.28F;
			gameRunningDetectorRock.EntersThreshold += gameRunningDetector_EntersThreshold;
			gameRunningDetectorRock.ExitsThreshold += gameRunningDetector_ExitsThreshold;
			// 
			// gameRunningDetectorScore
			// 
			gameRunningDetectorScore.Location = new System.Drawing.Point(242, 634);
			gameRunningDetectorScore.LowerThreshold = 0.17F;
			gameRunningDetectorScore.Name = "gameRunningDetectorScore";
			gameRunningDetectorScore.Size = new System.Drawing.Size(139, 20);
			gameRunningDetectorScore.TabIndex = 11;
			gameRunningDetectorScore.UpperThreshold = 0.18F;
			gameRunningDetectorScore.EntersThreshold += gameRunningDetector_EntersThreshold;
			gameRunningDetectorScore.ExitsThreshold += gameRunningDetector_ExitsThreshold;
			// 
			// button1
			// 
			button1.Location = new System.Drawing.Point(132, 118);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(75, 23);
			button1.TabIndex = 12;
			button1.Text = "button1";
			button1.UseVisualStyleBackColor = true;
			button1.Click += button1_Click;
			// 
			// Form1
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackgroundImage = (System.Drawing.Image)resources.GetObject("$this.BackgroundImage");
			ClientSize = new System.Drawing.Size(1118, 728);
			Controls.Add(button1);
			Controls.Add(gameRunningDetectorScore);
			Controls.Add(gameRunningDetectorRock);
			Controls.Add(blueNoteDetector);
			Controls.Add(yellowNoteDetector);
			Controls.Add(greenNoteDetector);
			Controls.Add(redNoteDetector);
			Controls.Add(orangeNoteDetector);
			DoubleBuffered = true;
			Name = "Form1";
			Text = "Form1";
			ResumeLayout(false);
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

