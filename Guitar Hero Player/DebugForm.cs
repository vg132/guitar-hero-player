using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuitarHeroPlayer
{
	public partial class DebugForm : Form
	{
		private string lastMessage = null;
		private ConcurrentQueue<Image> _images = new ConcurrentQueue<Image>();
		private Task _imageProcessingTask;
		private int _debugRepeatMessageCounter;
		private IList<double> _greenValues = new List<double>();
		private IList<double> _redValues = new List<double>();
		private IList<double> _yellowValues = new List<double>();
		private IList<double> _blueValues = new List<double>();
		private IList<double> _orageValues = new List<double>();

		public DebugForm()
		{
			InitializeComponent();

			_imageProcessingTask = new Task(() =>
				{
					ImageProcessing();
				});
			_imageProcessingTask.Start();
		}

		public void AddImage(Image image)
		{
			if(chkSaveScreenShots.Checked)
			{
				_images.Enqueue(image);
			}
		}

		private void ImageProcessing()
		{
			while (true)
			{
				//lblScreenShotsInQueue.Text = $"Screen shots in queue: {_images.Count()}";
				if (_images.TryDequeue(out Image image))
				{
					image.Save("c:\\temp\\Images\\" + DateTime.Now.ToString("yyyy_mm_dd_HH_mm_ss_ff") + ".png", ImageFormat.Png);
					image.Dispose();
				}
				else
				{
					System.Threading.Thread.Sleep(500);
				}
			};
		}

		public void Debug(string text)
		{
			if (lastMessage == text)
			{
				_debugRepeatMessageCounter++;
				var lines = txtDebug.Lines;
				txtDebug.Lines = txtDebug.Lines.Take(lines.Count() - 1).ToArray();
				txtDebug.AppendText($"\r\n[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}][{_debugRepeatMessageCounter}] {text} ");
				return;
			}
			_debugRepeatMessageCounter = 0;
			txtDebug.AppendText($"\r\n[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}] {text}");
			lastMessage = text;
		}

		public void UpdateValue(string name, double value)
		{
			if(!chkDebug.Checked)
			{
				return;
			}
			IList<double> values = null;
			switch (name.ToLower())
			{
				case "pnlgreen":
					values = _greenValues;
					break;
				case "pnlred":
					values = _redValues;
					break;
				case "pnlyellow":
					values = _yellowValues;
					break;
				case "pnlblue":
					values = _blueValues;
					break;
				case "pnlorange":
					values = _orageValues;
					break;
			}
			if (values != null)
			{
				values.Add(value);
				if (values.Count > 10)
				{
					values.RemoveAt(0);
				}
			}
			switch (name.ToLower())
			{
				case "pnlgreen":
					lblGreenCurrent.Text = value.ToString();
					if (double.Parse(lblGreenMax.Text) < value)
					{
						lblGreenMax.Text = value.ToString();
					}
					if (double.Parse(lblGreenMin.Text) > value || double.Parse(lblGreenMin.Text) == 0)
					{
						lblGreenMin.Text = value.ToString();
					}
					lblGreenAvg.Text = values.Average().ToString();
					break;
				case "pnlred":
					lblRedCurrent.Text = value.ToString();
					if (double.Parse(lblRedMax.Text) < value)
					{
						lblRedMax.Text = value.ToString();
					}
					if (double.Parse(lblRedMin.Text) > value || double.Parse(lblRedMin.Text) == 0)
					{
						lblRedMin.Text = value.ToString();
					}
					lblRedAvg.Text = values.Average().ToString();
					break;
				case "pnlyellow":
					lblYellowCurrent.Text = value.ToString();
					if (double.Parse(lblYellowMax.Text) < value)
					{
						lblYellowMax.Text = value.ToString();
					}
					if (double.Parse(lblYellowMin.Text) > value || double.Parse(lblYellowMin.Text) == 0)
					{
						lblYellowMin.Text = value.ToString();
					}
					lblYellowAvg.Text = values.Average().ToString();
					break;
				case "pnlblue":
					lblBlueCurrent.Text = value.ToString();
					if (double.Parse(lblBlueMax.Text) < value)
					{
						lblBlueMax.Text = value.ToString();
					}
					if (double.Parse(lblBlueMin.Text) > value || double.Parse(lblBlueMin.Text) == 0)
					{
						lblBlueMin.Text = value.ToString();
					}
					lblBlueAvg.Text = values.Average().ToString();
					break;
				case "pnlorange":
					lblOrangeCurrentValue.Text = value.ToString();
					if (double.Parse(lblOrangeMax.Text) < value)
					{
						lblOrangeMax.Text = value.ToString();
					}
					if (double.Parse(lblOrangeMin.Text) > value || double.Parse(lblOrangeMin.Text) == 0)
					{
						lblOrangeMin.Text = value.ToString();
					}
					lblOrangeAvg.Text = values.Average().ToString();
					break;
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			lblGreenCurrent.Text = "0";
			lblGreenMin.Text = "0";
			lblGreenMax.Text = "0";
			lblGreenAvg.Text = "0";

			lblRedCurrent.Text = "0";
			lblRedMin.Text = "0";
			lblRedMax.Text = "0";
			lblRedAvg.Text = "0";

			lblYellowCurrent.Text = "0";
			lblYellowMin.Text = "0";
			lblYellowMax.Text = "0";
			lblYellowAvg.Text = "0";

			lblBlueCurrent.Text = "0";
			lblBlueMin.Text = "0";
			lblBlueMax.Text = "0";
			lblBlueAvg.Text = "0";

			lblOrangeCurrentValue.Text = "0";
			lblOrangeMin.Text = "0";
			lblOrangeMax.Text = "0";
			lblOrangeAvg.Text = "0";
		}

		private void DebugForm_Load(object sender, EventArgs e)
		{

		}
	}
}
