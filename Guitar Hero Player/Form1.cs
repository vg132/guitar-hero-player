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
		private DebugForm _debugForm;
		private IList<Controls.NoteDetector> _noteDetectors = new List<Controls.NoteDetector>();

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			_debugForm = new DebugForm();
			_debugForm.Show();

			_noteDetectors.Add(greenNoteDetector);
			_noteDetectors.Add(redNoteDetector);
			_noteDetectors.Add(yellowNoteDetector);
			_noteDetectors.Add(blueNoteDetector);
			_noteDetectors.Add(orangeNoteDetector);
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

		private long ticks = 0;
		private void timer1_Tick(object sender, EventArgs e)
		{
			var handle = GetCurrentHandle();
			if (handle != null)
			{
				AnalyseScreenShot(handle.Value);
				//AnalyseImage();
			}
		}

		//private void AnalyseImage()
		//{
		//	ticks++;
		//	//var screenShot = new Bitmap("C:\\Temp\\good images\\2021_28_14_22_28_16_45.png");
		//	var screenShot = new Bitmap("C:\\Temp\\good images\\good4.png");
		//	//var screenShot = new Bitmap("C:\\Temp\\good images\\2021_27_14_22_27_57_36.png");
			
		//	if (screenShot != null)
		//	{
		//		Analyse(screenShot);
		//		if ((ticks % 15) == 0)
		//		{
		//			var g = CreateGraphics();
		//			g.DrawImage(screenShot, 0, 0);
		//		}
		//	}
		//}

		private void AnalyseScreenShot(IntPtr handle)
		{
			ticks++;
			var screenShot = ScreenShot.GetPS3ScreenShot(handle);
			if (screenShot != null)
			{
				_debugForm.AddImage(screenShot);
				var bitmap = new Bitmap(screenShot);
				foreach (var noteDetector in _noteDetectors)
				{
					noteDetector.ProcessImage(handle, bitmap);
				}
				if ((ticks % 15) == 0)
				{
					var g = CreateGraphics();
					g.DrawImage(screenShot, 0, 0);
				}
			}
		}

	}
}