using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGrid.Cells.Models
{

	/// <summary>
	/// RadioButton model.
	/// </summary>
	public class RadioButton : IRadioButton
	{
		#region IRadioButton Members

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="cellContext"></param>
		/// <returns></returns>
		public RadioButtonStatus GetRadioButtonStatus(CellContext cellContext)
		{
			bool enableEdit = false;
			if (cellContext.Cell.Editor != null && cellContext.Cell.Editor.EnableEdit)
				enableEdit = true;

			object val = cellContext.Cell.Model.ValueModel.GetValue(cellContext);
			if (val == null)
				return new RadioButtonStatus(enableEdit, DevAge.Drawing.RadioButtonState.Undefined, m_Caption);
			else if (val is bool)
				return new RadioButtonStatus(enableEdit, (bool)val, m_Caption);
			else
				throw new ApplicationException("Cell value not supported for this cell. Expected bool value or null.");
		}

		/// <summary>
		/// Set the checked value
		/// </summary>
		/// <param name="cellContext"></param>
		/// <param name="pChecked"></param>
		public void SetCheckedValue(CellContext cellContext, bool pChecked)
		{
			if (cellContext.Cell.Editor != null && cellContext.Cell.Editor.EnableEdit)
				cellContext.Cell.Editor.SetCellValue(cellContext, pChecked);
		}
		#endregion

		private string m_Caption = null;
		public string Caption
		{
			get { return m_Caption; }
			set { m_Caption = value; }
		}
	}
}
