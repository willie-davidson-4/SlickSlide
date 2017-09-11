using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SlickSlideLevelBuilder
{
	public partial class Line : Control
	{
		public Line(Point intPosition1, Point intPosition2)
		{
			intPos1 = intPosition1;
			intPos2 = intPosition2;

			InitializeComponent();
		}

		Point intPos1;
		Point intPos2;

		private Color m_LineColor = Color.Green;
		/// <summary>
		/// Gets or sets the color of the divider line
		/// </summary>
		[Category("Appearance")]
		[Description("Gets or sets the color of the divider line")]
		public Color LineColor
		{
			get
			{
				return m_LineColor;
			}
			set
			{
				m_LineColor = value;
				Invalidate();
			}
		}

		protected override void OnPaint(PaintEventArgs pe)
		{
			using (Pen brush = new Pen(LineColor, 50))
			{
				pe.Graphics.DrawLine(brush, intPos1, intPos2);
			}
		}
	}
}
