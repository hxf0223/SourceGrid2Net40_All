using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace DevAge.Drawing.VisualElements
{
	[Serializable]
	public class RadioButton : RadioButtonBase
	{
		#region Constuctor
		/// <summary>
		/// Default constructor
		/// </summary>
		public RadioButton()
		{
		}

		/// <summary>
		/// Copy constructor
		/// </summary>
		/// <param name="other"></param>
		public RadioButton(RadioButton other)
			: base(other)
		{
		}
		#endregion
		/// <summary>
		/// Clone
		/// </summary>
		/// <returns></returns>
		public override object Clone()
		{
			return new RadioButton(this);
		}

		protected override void OnDraw(GraphicsCache graphics, RectangleF area)
		{
			ButtonState state;
			if (Style == ControlDrawStyle.Disabled)
				state = ButtonState.Inactive;
			else if (Style == ControlDrawStyle.Pressed)
				state = ButtonState.Pushed;
			else if (Style == ControlDrawStyle.Hot)
				state = ButtonState.Normal;
			else
				state = ButtonState.Normal;

			if (RadioButtonState == RadioButtonState.Checked)
				state |= ButtonState.Checked;

			ControlPaint.DrawRadioButton(graphics.Graphics, Rectangle.Round(area), state);
		}

		protected override SizeF OnMeasureContent(MeasureHelper measure, SizeF maxSize)
		{
			//TODO Check to see if it is possible to get the real default size...
			return new SizeF(16, 16);
		}
	}
}
