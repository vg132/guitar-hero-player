using System;
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
		public static double AnalysePanel(Bitmap image, Panel panel)
		{
			var totalDistance = 0d;
			var pixels = 0;
			for (var y = panel.Top; y < panel.Top + panel.Height; y++)
			{
				for (var x = panel.Left; x < panel.Left + panel.Width; x++)
				{
					if (x < image.Width && y < image.Height)
					{
						pixels++;
						var pixel = image.GetPixel(x, y);
						totalDistance += pixel.GetBrightness();
						//totalDistance += GetColourDistance(baseColor, pixel);
					}
				}
			}
			//System.Drawing.Color color = System.Drawing.Color.FromArgb(red, green, blue);
			//float hue = color.GetHue();
			//float saturation = color.GetSaturation();
			//float lightness = color.GetBrightness();
			return totalDistance / pixels;
		}

		private static double GetColourDistance(Color e1, Color e2)
		{
			return Math.Sqrt((e1.R - e2.R) * (e1.R - e2.R) + (e1.G - e2.G) * (e1.G - e2.G) + (e1.B - e2.B) * (e1.B - e2.B));
		}
	}
}