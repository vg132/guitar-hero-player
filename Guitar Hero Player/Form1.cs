using GuitarHeroPlayer.Debug;
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
		private bool _isGameRunning = false;

#if DEBUG
		private DebugSession _debugSession;
		private FrameInfo _currentFrame;
		private int _frameCounter = 0;
		private bool _markFrame = false;
#endif

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			var d = new Debug.DebugViewer();
			d.Show();

			_noteDetectors.Add(greenNoteDetector);
			_noteDetectors.Add(redNoteDetector);
			_noteDetectors.Add(yellowNoteDetector);
			_noteDetectors.Add(blueNoteDetector);
			_noteDetectors.Add(orangeNoteDetector);

			foreach (var noteDetector in _noteDetectors)
			{
				noteDetector.SendKeys = !_testing;
			}
#if DEBUG
			_debugSession = new DebugSession();
#endif
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
#if DEBUG
			_currentFrame = new FrameInfo();
			_currentFrame.Id = _frameCounter;
			_currentFrame.Start();
#endif
			var handle = GetCurrentHandle();
			if (handle != null)
			{
				AnalyseScreenShot(handle.Value);
			}
#if DEBUG
			_currentFrame.Stop();
			_currentFrame.KeyState = _noteDetectors.Select(item => item.IsKeyDown).ToArray();
			_currentFrame.Values = _noteDetectors.Select(item => item.CurrentBrightness).ToArray();
			_currentFrame.IsMarked = _markFrame;
			_markFrame = false;
			if(_isGameRunning)
			{
				_debugSession.AddFrame(_currentFrame);
			}
			_frameCounter++;
#endif
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
				gameRunningDetectorRock.ProcessImage(bitmap);
				gameRunningDetectorScore.ProcessImage(bitmap);
				if (_isGameRunning)
				{
					foreach (var noteDetector in _noteDetectors)
					{
						noteDetector.ProcessImage(handle, bitmap);
					}
#if DEBUG
					if ((_frameCounter % 1) == 0)
					{
						_currentFrame.ScreenShot = bitmap;
					}
#endif
				}
			}
		}

		private void gameRunningDetector_EntersThreshold(object sender, EventArgs e)
		{
			_isGameRunning = gameRunningDetectorRock.IsInThreshold && gameRunningDetectorScore.IsInThreshold;
		}

		private void gameRunningDetector_ExitsThreshold(object sender, EventArgs e)
		{
			_isGameRunning = false;
		}

		private void button1_Click(object sender, EventArgs e)
		{
#if DEBUG
			_markFrame = true;
#endif
		}
	}
}