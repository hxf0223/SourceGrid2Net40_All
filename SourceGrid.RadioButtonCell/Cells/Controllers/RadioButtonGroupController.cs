using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Windows.Forms;

namespace SourceGrid.Cells.Controllers
{
	/// <summary>
	/// 
	/// </summary>
	public class RadioButtonGroupController : ControllerBase
	{
		// Arraylist for local storage of references of the 
		// radio button cells in the group.
		private ArrayList _radioButtons = new ArrayList();

		/// <summary>
		/// 
		/// </summary>
		public RadioButtonGroupController()
		{
		}

		/// <summary>
		/// Append a radio button cell to the local array list.
		/// The collection of radio button cells int he array list 
		/// represent the entire radio group.
		/// </summary>
		/// <param name="cell"></param>
		public void AppendCell(SourceGrid.Cells.Cell cell)
		{
			this._radioButtons.Add(cell);
		}

		#region Controller Events

		/// <summary>
		/// Handle a key press.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public override void OnKeyPress(CellContext sender, KeyPressEventArgs e)
		{
			// Let the base class do it's thing.
			base.OnKeyPress(sender, e);

			// Update the radio group.
			if (e.KeyChar == ' ')
				UIChangeChecked(sender, e);
		}

		/// <summary>
		/// 
		/// </summary>
		private MouseButtons mLastButton = MouseButtons.None;

		/// <summary>
		/// Handle a OnMouseDown event.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public override void OnMouseDown(CellContext sender, MouseEventArgs e)
		{
			base.OnMouseDown(sender, e);

			// Take note of the last mouse button that was pressed.
			mLastButton = e.Button;
		}

		/// <summary>
		/// Handle an OnClick event
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public override void OnClick(CellContext sender, EventArgs e)
		{
			// Let the base class do its thing.
			base.OnClick(sender, e);

			// Update the group of buttons.
			if (mLastButton == MouseButtons.Left)
				UIChangeChecked(sender, e);
		}

		#endregion

		/// <summary>
		/// Called when the checked button has changed in a radio button cell group.
		/// Basically, note the cell passed in sender's state and if it is checked
		/// we uncheck all other buttons in the array list.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void UIChangeChecked(CellContext sender, EventArgs e)
		{
			// See if the passed cell is checked.
			// If so, unckeck all the other cells.

			SourceGrid.Cells.RadioButton cell = sender.Cell as SourceGrid.Cells.RadioButton;
			if (cell != null)
			{
				if (cell.Checked)
				{
					foreach (SourceGrid.Cells.RadioButton c in this._radioButtons)
					{
						if (c != cell)
						{
							if (c.Checked)
								c.Checked = false;
						}
					}
				}
			}
		}
	}
}
