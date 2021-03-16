using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GuitarHeroPlayer.Controls
{
	public partial class BrightnessDetector : UserControl
	{
		public BrightnessDetector()
		{
			InitializeComponent();
		}

		[Browsable(false)]
		public float CurrentBrightness { get; private set; }

		[Browsable(false)]
		public bool IsInThreshold => InThreshold(CurrentBrightness);
		public float LowerThreshold { get; set; }
		public float UpperThreshold { get; set; }

		[Browsable(true)]
		[Category("Action")]
		[Description("Invoked when then brightness is changed")]
		public event EventHandler BrightnessChanged;

		[Browsable(true)]
		[Category("Action")]
		[Description("Invoked when then brightness enters the threshold")]
		public event EventHandler EntersThreshold;

		[Browsable(true)]
		[Category("Action")]
		[Description("Invoked when then brightness exits the threshold")]
		public event EventHandler ExitsThreshold;

		public void ProcessImage(Bitmap image)
		{
			var value = ImageAnalyser.AnalyseBrightness(image, this);
			if (value != CurrentBrightness)
			{
				var oldValue = CurrentBrightness;
				CurrentBrightness = value;
				if (BrightnessChanged != null)
				{
					BrightnessChanged(this, new BrightnessEventArgs(value));
				}
				if (InThreshold(oldValue) != InThreshold(value))
				{
					if (InThreshold(value) && EntersThreshold != null)
					{
						EntersThreshold(this, new BrightnessEventArgs(value));
					}
					else if (ExitsThreshold != null)
					{
						ExitsThreshold(this, new BrightnessEventArgs(value));
					}
				}
			}
		}

		public bool InThreshold(float value)
		{
			return value >= LowerThreshold && value <= UpperThreshold;
		}

		public class BrightnessEventArgs : EventArgs
		{
			public BrightnessEventArgs(float value)
			{
				Brightness = value;
			}

			public float Brightness { get; set; }
		}
	}
}
