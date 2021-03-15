using System.Drawing;
using System.Windows.Forms;

namespace Guitar_Hero_Player
{
	public class ImageData
	{
		public double Green { get; set; }
		public double Red { get; set; }
		public double Yellow { get; set; }
		public double Blue { get; set; }
		public double Orange { get; set; }
	}

	public static class ImageAnalyser
	{
		public static float AnalyseBrightness(Bitmap image, Control control)
		{
			var totalBrightness = 0.0f;
			var pixels = 0;
			for (var y = control.Top; y < control.Top + control.Height; y++)
			{
				for (var x = control.Left; x < control.Left + control.Width; x++)
				{
					if (x < image.Width && y < image.Height)
					{
						pixels++;
						var pixel = image.GetPixel(x, y);
						totalBrightness += pixel.GetBrightness();
					}
				}
			}
			return totalBrightness / pixels;
		}
	}
}