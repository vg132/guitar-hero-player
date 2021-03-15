using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Guitar_Hero_Player
{
	public class ColorData
	{
		private const int ValuesToSave = 90;
		private IList<double> _values = new List<double>();

		public Panel Panel { get; set; }
		public double CurrentDistance
		{
			get { return _values.LastOrDefault(); }
			set
			{
				_values.Add(value);
				if (Max < value)
				{
					Max = value;
				}
				if (Min == 0 || Min > value)
				{
					Min = value;
				}
				_values = _values.Skip(Math.Min(_values.Count() - ValuesToSave, 0))
					.Take(ValuesToSave)
					.ToList();
			}
		}

		public double Max { get; private set; }
		public double Min { get; private set; }
		public double Avg { get; private set; }
	}
}