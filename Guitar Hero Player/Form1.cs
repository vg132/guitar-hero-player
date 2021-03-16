using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GuitarHeroPlayer
{
	public partial class Form1 : Form
	{
		private IList<Controls.NoteDetector> _noteDetectors = new List<Controls.NoteDetector>();
		private bool _testing = false;

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			_noteDetectors.Add(greenNoteDetector);
			_noteDetectors.Add(redNoteDetector);
			_noteDetectors.Add(yellowNoteDetector);
			_noteDetectors.Add(blueNoteDetector);
			_noteDetectors.Add(orangeNoteDetector);

			foreach (var noteDetector in _noteDetectors)
			{
				noteDetector.SendKeys = !_testing;
			}
		}

		public Form1()
		{
			InitializeComponent();
		}


		private IntPtr? GetCurrentHandle()
		{
			var process = Process.GetProcessesByName("rpcs3").FirstOrDefault();
			if (process == null)
			{
				return null;
			}
			return process.MainWindowHandle;
		}

		private void gameTimer_Tick(object sender, EventArgs e)
		{
			var handle = GetCurrentHandle();
			if (handle != null)
			{
				AnalyseScreenShot(handle.Value);
			}
		}

		private void AnalyseScreenShot(IntPtr handle)
		{
			Image image;
			if (_testing)
			{
				image = new Bitmap("C:\\Temp\\good images\\good4.png");
			}
			else
			{
				image = ScreenShot.GetPS3ScreenShot(handle);
			}
			if (image != null)
			{
				var bitmap = new Bitmap(image);
				foreach (var noteDetector in _noteDetectors)
				{
					noteDetector.ProcessImage(handle, bitmap);
				}
			}
		}
	}
}