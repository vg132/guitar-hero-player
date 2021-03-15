
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
			this.pnlGreen = new System.Windows.Forms.Panel();
			this.pnlYellow = new System.Windows.Forms.Panel();
			this.pnlOrange = new System.Windows.Forms.Panel();
			this.pnlBlue = new System.Windows.Forms.Panel();
			this.pnlRed = new System.Windows.Forms.Panel();
			this.SuspendLayout();
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Interval = 33;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// pnlGreen
			// 
			this.pnlGreen.BackColor = System.Drawing.Color.Green;
			this.pnlGreen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.pnlGreen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlGreen.Location = new System.Drawing.Point(482, 567);
			this.pnlGreen.Name = "pnlGreen";
			this.pnlGreen.Size = new System.Drawing.Size(12, 12);
			this.pnlGreen.TabIndex = 0;
			this.pnlGreen.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseDown);
			// 
			// pnlYellow
			// 
			this.pnlYellow.BackColor = System.Drawing.Color.Yellow;
			this.pnlYellow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlYellow.Location = new System.Drawing.Point(641, 567);
			this.pnlYellow.Name = "pnlYellow";
			this.pnlYellow.Size = new System.Drawing.Size(12, 12);
			this.pnlYellow.TabIndex = 1;
			this.pnlYellow.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseDown);
			// 
			// pnlOrange
			// 
			this.pnlOrange.BackColor = System.Drawing.Color.Orange;
			this.pnlOrange.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlOrange.Location = new System.Drawing.Point(801, 567);
			this.pnlOrange.Name = "pnlOrange";
			this.pnlOrange.Size = new System.Drawing.Size(12, 12);
			this.pnlOrange.TabIndex = 2;
			this.pnlOrange.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseDown);
			// 
			// pnlBlue
			// 
			this.pnlBlue.BackColor = System.Drawing.Color.Blue;
			this.pnlBlue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlBlue.Location = new System.Drawing.Point(722, 567);
			this.pnlBlue.Name = "pnlBlue";
			this.pnlBlue.Size = new System.Drawing.Size(12, 12);
			this.pnlBlue.TabIndex = 3;
			this.pnlBlue.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseDown);
			// 
			// pnlRed
			// 
			this.pnlRed.BackColor = System.Drawing.Color.Red;
			this.pnlRed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlRed.Location = new System.Drawing.Point(559, 567);
			this.pnlRed.Name = "pnlRed";
			this.pnlRed.Size = new System.Drawing.Size(12, 12);
			this.pnlRed.TabIndex = 4;
			this.pnlRed.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseDown);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.ClientSize = new System.Drawing.Size(1118, 728);
			this.Controls.Add(this.pnlRed);
			this.Controls.Add(this.pnlBlue);
			this.Controls.Add(this.pnlOrange);
			this.Controls.Add(this.pnlYellow);
			this.Controls.Add(this.pnlGreen);
			this.DoubleBuffered = true;
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Panel pnlGreen;
		private System.Windows.Forms.Panel pnlYellow;
		private System.Windows.Forms.Panel pnlOrange;
		private System.Windows.Forms.Panel pnlBlue;
		private System.Windows.Forms.Panel pnlRed;
	}
}

