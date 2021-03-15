
namespace Guitar_Hero_Player
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
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.orangeNoteDetector = new Guitar_Hero_Player.Controls.NoteDetector();
			this.redNoteDetector = new Guitar_Hero_Player.Controls.NoteDetector();
			this.greenNoteDetector = new Guitar_Hero_Player.Controls.NoteDetector();
			this.yellowNoteDetector = new Guitar_Hero_Player.Controls.NoteDetector();
			this.blueNoteDetector = new Guitar_Hero_Player.Controls.NoteDetector();
			this.SuspendLayout();
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Interval = 33;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// orangeNoteDetector
			// 
			this.orangeNoteDetector.BackColor = System.Drawing.Color.Orange;
			this.orangeNoteDetector.Location = new System.Drawing.Point(802, 569);
			this.orangeNoteDetector.Name = "orangeNoteDetector";
			this.orangeNoteDetector.NoteType = Guitar_Hero_Player.Controls.NoteType.Orange;
			this.orangeNoteDetector.Size = new System.Drawing.Size(12, 12);
			this.orangeNoteDetector.TabIndex = 5;
			// 
			// redNoteDetector
			// 
			this.redNoteDetector.BackColor = System.Drawing.Color.Red;
			this.redNoteDetector.Location = new System.Drawing.Point(559, 569);
			this.redNoteDetector.Name = "redNoteDetector";
			this.redNoteDetector.NoteType = Guitar_Hero_Player.Controls.NoteType.Red;
			this.redNoteDetector.Size = new System.Drawing.Size(12, 12);
			this.redNoteDetector.TabIndex = 6;
			// 
			// greenNoteDetector
			// 
			this.greenNoteDetector.BackColor = System.Drawing.Color.Green;
			this.greenNoteDetector.Location = new System.Drawing.Point(481, 569);
			this.greenNoteDetector.Name = "greenNoteDetector";
			this.greenNoteDetector.NoteType = Guitar_Hero_Player.Controls.NoteType.Green;
			this.greenNoteDetector.Size = new System.Drawing.Size(12, 12);
			this.greenNoteDetector.TabIndex = 7;
			// 
			// yellowNoteDetector
			// 
			this.yellowNoteDetector.BackColor = System.Drawing.Color.Yellow;
			this.yellowNoteDetector.Location = new System.Drawing.Point(641, 569);
			this.yellowNoteDetector.Name = "yellowNoteDetector";
			this.yellowNoteDetector.NoteType = Guitar_Hero_Player.Controls.NoteType.Yellow;
			this.yellowNoteDetector.Size = new System.Drawing.Size(12, 12);
			this.yellowNoteDetector.TabIndex = 8;
			// 
			// blueNoteDetector
			// 
			this.blueNoteDetector.BackColor = System.Drawing.Color.Blue;
			this.blueNoteDetector.Location = new System.Drawing.Point(721, 569);
			this.blueNoteDetector.Name = "blueNoteDetector";
			this.blueNoteDetector.NoteType = Guitar_Hero_Player.Controls.NoteType.Blue;
			this.blueNoteDetector.Size = new System.Drawing.Size(12, 12);
			this.blueNoteDetector.TabIndex = 9;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.ClientSize = new System.Drawing.Size(1118, 728);
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
		private System.Windows.Forms.Timer timer1;
		private Controls.NoteDetector orangeNoteDetector;
		private Controls.NoteDetector redNoteDetector;
		private Controls.NoteDetector greenNoteDetector;
		private Controls.NoteDetector yellowNoteDetector;
		private Controls.NoteDetector blueNoteDetector;
	}
}

