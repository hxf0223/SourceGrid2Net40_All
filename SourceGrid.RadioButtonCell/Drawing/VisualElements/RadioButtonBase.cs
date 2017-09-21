using System;
using System.Collections.Generic;
using System.Text;

namespace DevAge.Drawing.VisualElements
{
	public interface IRadioButton : IVisualElement
	{
		ControlDrawStyle Style
		{
			get;
			set;
		}

		RadioButtonState RadioButtonState
		{
			get;
			set;
		}
	}

	[Serializable]
	public abstract class RadioButtonBase : VisualElementBase, IRadioButton
	{
		#region Constuctor
		/// <summary>
		/// Default constructor
		/// </summary>
		public RadioButtonBase()
		{
			AnchorArea = new AnchorArea(float.NaN, float.NaN, float.NaN, float.NaN, true, true);
		}

		/// <summary>
		/// Copy constructor
		/// </summary>
		/// <param name="other"></param>
		public RadioButtonBase(RadioButtonBase other)
			: base(other)
		{
			Style = other.Style;
			RadioButtonState = other.RadioButtonState;
		}
		#endregion

		#region Properties
		private ControlDrawStyle mControlDrawStyle = ControlDrawStyle.Normal;
		public virtual ControlDrawStyle Style
		{
			get { return mControlDrawStyle; }
			set { mControlDrawStyle = value; }
		}
		protected virtual bool ShouldSerializeStyle()
		{
			return Style != ControlDrawStyle.Normal;
		}

		private RadioButtonState mRadioButtonState = RadioButtonState.Undefined;

		public virtual RadioButtonState RadioButtonState
		{
			get { return mRadioButtonState; }
			set { mRadioButtonState = value; }
		}
		protected virtual bool ShouldSerializeRadioButtonState()
		{
			return RadioButtonState != RadioButtonState.Undefined;
		}
		#endregion
	}
}
