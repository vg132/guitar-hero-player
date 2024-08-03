using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuitarHeroPlayer.Controls
{
	public enum NoteType
	{
		Green = 0,
		Red = 1,
		Yellow = 2,
		Blue = 3,
		Orange = 4
	}

	public partial class NoteDetector : UserControl
	{
		private NoteType _noteType = NoteType.Green;
		private bool _keyDown = false;

		public NoteDetector()
		{
			InitializeComponent();
		}

		#region Properties

		public bool IsKeyDown => _keyDown;

		public NoteType NoteType
		{
			get
			{
				return _noteType;
			}
			set
			{
				_noteType = value;
				switch (value)
				{
					case NoteType.Green:
						BackColor = Color.Green;
						break;
					case NoteType.Red:
						BackColor = Color.Red;
						break;
					case NoteType.Yellow:
						BackColor = Color.Yellow;
						break;
					case NoteType.Blue:
						BackColor = Color.Blue;
						break;
					case NoteType.Orange:
						BackColor = Color.Orange;
						break;
				}
			}
		}

		public float BrightnessThreshold { get; set; } = 0.35f;
		public float CurrentBrightness { get; private set; }
		public int Delay { get; set; } = 100;
		public bool SendKeys { get; set; } = true;

		#endregion

		private Bitmap currentImage;
		private Bitmap detectionImage;
		private int imageId = 0;

		public void ProcessImage(IntPtr handle, Bitmap image)
		{
			imageId++;
			currentImage = image;
			CurrentBrightness = ImageAnalyser.AnalyseBrightness(image, this);
			if (CurrentBrightness >= BrightnessThreshold && !_keyDown)
			{
				new Task(() =>
				{
					//if (_noteType == NoteType.Green)
					//{
					try
					{
						if (detectionImage == null)
						{
							detectionImage = image;
						}
					}
					catch { }
					//}
					Thread.Sleep(Delay);
					//if (_noteType == NoteType.Green)
					//{
					try
					{
						detectionImage.Save($"c:\\temp\\GH3\\{imageId}-detection.png");
						detectionImage.Dispose();
						detectionImage = null;
						currentImage.Save($"c:\\temp\\GH3\\{imageId}-send-key.png");
					}
					catch { }
					//}
					SendKeyDown(handle);
				}).Start();
				_keyDown = true;
			}
			else if (CurrentBrightness < BrightnessThreshold && _keyDown)
			{
				new Task(() =>
				{
					Thread.Sleep(Delay / 2);
					SendKeyUp(handle);
				}).Start();
				_keyDown = false;
			}
		}

		private void SendKeyDown(IntPtr handle)
		{
			if (SendKeys)
			{
				WindowsAPI.SendMessage(handle, WindowsAPI.WM_KEYDOWN, Key, WindowsAPI.KEY_LPARAM);
				WindowsAPI.SendMessage(handle, WindowsAPI.WM_CHAR, Key, WindowsAPI.KEY_LPARAM);
			}
		}

		private void SendKeyUp(IntPtr handle)
		{
			if (SendKeys)
			{
				WindowsAPI.SendMessage(handle, WindowsAPI.WM_KEYUP, Key, WindowsAPI.KEY_LPARAM);
			}
		}

		private char Key
		{
			get
			{
				switch (NoteType)
				{
					case NoteType.Green:
						return 'R';
					case NoteType.Red:
						return 'Q';
					case NoteType.Yellow:
						return 'E';
					case NoteType.Blue:
						return 'T';
					case NoteType.Orange:
					default:
						return 'X';
				}
			}
		}
	}
}