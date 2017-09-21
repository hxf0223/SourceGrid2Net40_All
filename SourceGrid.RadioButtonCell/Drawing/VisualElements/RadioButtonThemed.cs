using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace DevAge.Drawing.VisualElements
{
	[Serializable]
	public class RadioButtonThemed : RadioButtonBase
	{
		#region Constuctor
		/// <summary>
		/// Default constructor
		/// </summary>
		public RadioButtonThemed()
		{
		}

		/// <summary>
		/// Copy constructor
		/// </summary>
		/// <param name="other"></param>
		public RadioButtonThemed(RadioButtonThemed other)
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
			return new RadioButtonThemed(this);
		}

		#region Properties
		/// <summary>
		/// Standard RadioButton used when the XP style are disabled.
		/// </summary>
		private RadioButton mStandardRadioButton = new RadioButton();

		public override ControlDrawStyle Style
		{
			get { return base.Style; }
			set { base.Style = value; mStandardRadioButton.Style = value; }
		}

		public override RadioButtonState RadioButtonState
		{
			get { return base.RadioButtonState; }
			set { base.RadioButtonState = value; mStandardRadioButton.RadioButtonState = value; }
		}
		#endregion

		#region Helper methods
		protected VisualStyleElement GetBackgroundElement()
		{
			if (Style == ControlDrawStyle.Hot)
			{
				if (RadioButtonState == RadioButtonState.Checked)
					return VisualStyleElement.Button.RadioButton.CheckedHot;
				else //if (RadioButtonState == RadioButtonState.Unchecked)
					return VisualStyleElement.Button.RadioButton.UncheckedHot;
//				else
//					return VisualStyleElement.Button.RadioButton..MixedHot;
			}
			else if (Style == ControlDrawStyle.Pressed)
			{
				if (RadioButtonState == RadioButtonState.Checked)
					return VisualStyleElement.Button.RadioButton.CheckedPressed;
				else //if (RadioButtonState == RadioButtonState.Unchecked)
					return VisualStyleElement.Button.RadioButton.UncheckedPressed;
//				else
//					return VisualStyleElement.Button.RadioButton.MixedPressed;
			}
			else if (Style == ControlDrawStyle.Disabled)
			{
				if (RadioButtonState == RadioButtonState.Checked)
					return VisualStyleElement.Button.RadioButton.CheckedDisabled;
				else //if (RadioButtonState == RadioButtonState.Unchecked)
					return VisualStyleElement.Button.RadioButton.UncheckedDisabled;
//				else
//					return VisualStyleElement.Button.RadioButton.MixedDisabled;
			}
			else
			{
				if (RadioButtonState == RadioButtonState.Checked)
					return VisualStyleElement.Button.RadioButton.CheckedNormal;
				else //if (RadioButtonState == RadioButtonState.Unchecked)
					return VisualStyleElement.Button.RadioButton.UncheckedNormal;
//				else
//					return VisualStyleElement.Button.RadioButton.MixedNormal;
			}
		}

		/// <summary>
		/// Gets the System.Windows.Forms.VisualStyles.VisualStyleRenderer to draw the specified element.
		/// </summary>
		/// <param name="element"></param>
		/// <returns></returns>
		protected System.Windows.Forms.VisualStyles.VisualStyleRenderer GetRenderer(VisualStyleElement element)
		{
			return new System.Windows.Forms.VisualStyles.VisualStyleRenderer(element);
		}
		#endregion

		protected override void OnDraw(GraphicsCache graphics, RectangleF area)
		{
			if (Application.RenderWithVisualStyles && VisualStyleRenderer.IsElementDefined(GetBackgroundElement()))
				GetRenderer(GetBackgroundElement()).DrawBackground(graphics.Graphics, Rectangle.Round(area));
			else
				mStandardRadioButton.Draw(graphics, area);
		}

		protected override SizeF OnMeasureContent(MeasureHelper measure, SizeF maxSize)
		{
			if (Application.RenderWithVisualStyles && VisualStyleRenderer.IsElementDefined(GetBackgroundElement()))
				return GetRenderer(GetBackgroundElement()).GetPartSize(measure.Graphics, ThemeSizeType.True);
			else
				return mStandardRadioButton.Measure(measure, Size.Empty, maxSize);
		}
	}
}
