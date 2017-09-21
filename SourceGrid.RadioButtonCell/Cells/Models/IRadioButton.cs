using System;
using System.Collections.Generic;
using System.Text;
using DevAge.Drawing;

namespace SourceGrid.Cells.Models
{
	/// <summary>
	/// Interface for informations about a cechkbox
	/// </summary>
	public interface IRadioButton : IModel
	{
		/// <summary>
		/// Get the status of the RadioButton at the current position
		/// </summary>
		/// <param name="cellContext"></param>
		/// <returns></returns>
		RadioButtonStatus GetRadioButtonStatus(CellContext cellContext);

		/// <summary>
		/// Set the checked value
		/// </summary>
		/// <param name="cellContext"></param>
		/// <param name="pChecked"></param>
		void SetCheckedValue(CellContext cellContext, bool pChecked);
	}

	public struct RadioButtonStatus
	{
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="checkEnable"></param>
		/// <param name="bChecked"></param>
		/// <param name="caption"></param>
		public RadioButtonStatus(bool checkEnable, bool bChecked, string caption)
		{
			CheckEnable = checkEnable;
			if (bChecked)
				mCheckState = DevAge.Drawing.RadioButtonState.Checked;
			else
				mCheckState = DevAge.Drawing.RadioButtonState.Unchecked;
			Caption = caption;
		}
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="checkEnable"></param>
		/// <param name="checkState"></param>
		/// <param name="caption"></param>
		public RadioButtonStatus(bool checkEnable, DevAge.Drawing.RadioButtonState checkState, string caption)
		{
			CheckEnable = checkEnable;
			mCheckState = checkState;
			Caption = caption;
		}

		private DevAge.Drawing.RadioButtonState mCheckState;
		/// <summary>
		/// Gets or sets the state of the check box.
		/// </summary>
		public DevAge.Drawing.RadioButtonState CheckState
		{
			get { return mCheckState; }
			set { mCheckState = value; }
		}

		/// <summary>
		/// Enable or disable the RadioButton
		/// </summary>
		public bool CheckEnable;

		/// <summary>
		/// Gets or set Checked status. Return true for either a Checked or Indeterminate CheckState
		/// </summary>
		public bool Checked
		{
			get
			{
				if (CheckState == DevAge.Drawing.RadioButtonState.Checked ||
					CheckState == DevAge.Drawing.RadioButtonState.Undefined)
					return true;
				else
					return false;
			}
			set
			{
				if (value)
					CheckState = DevAge.Drawing.RadioButtonState.Checked;
				else
					CheckState = DevAge.Drawing.RadioButtonState.Unchecked;
			}
		}

		/// <summary>
		/// Caption of the RadioButton
		/// </summary>
		public string Caption;
	}
}


