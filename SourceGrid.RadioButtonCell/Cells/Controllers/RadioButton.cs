using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace SourceGrid.Cells.Controllers
{
	//TODO I can now use the VisualElement GetElementsAtPoint method to check the RadioButton only when clicking on the check and not when clicking on the header. This can also be used with the HeaderRadioButton cell (to enable the sort when clicking outside the check and to select all when clicking the check box.

	/// <summary>
	/// Summary description for BehaviorModelRadioButton. This behavior can be shared between multiple cells.
	/// </summary>
	public class RadioButton : ControllerBase
	{
		/// <summary>
		/// Default behavior RadioButton
		/// </summary>
		public readonly static RadioButton Default = new RadioButton();

		/// <summary>
		/// Constructor
		/// </summary>
		public RadioButton()
		{
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="p_bAutoChangeValueOfSelectedCells">Indicates if this cells when checked or uncheck must change also the value of the selected cells of type CellRadioButton.</param>
		public RadioButton(bool p_bAutoChangeValueOfSelectedCells)
		{
			m_bAutoChangeValueOfSelectedCells = p_bAutoChangeValueOfSelectedCells;
		}

		#region Controller Events
		public override void OnKeyPress(CellContext sender, KeyPressEventArgs e)
		{
			base.OnKeyPress(sender, e);

			if (e.KeyChar == ' ')
				UIChangeChecked(sender, e);
		}

		/// <summary>
		/// I mantain the last mouse button pressed here to simulate exactly the behavior of the standard system RadioButton.
		/// 
		/// Here are the events executed on a system RadioButton:
		/// 
		/// [status checked = false]
		/// MouseDown [status checked = false]
		/// CheckedChanged [status checked = true]
		/// Click [status checked = true]
		/// MouseUp [status checked = true]
		/// 
		/// Consider that I can use this member varialbes because also if you have multiple grid or multiple threads there is only one mouse that can fire the events.
		/// Consider also that I cannot use the Click event because in that event I don't have informations about the button pressed.
		/// </summary>
		private MouseButtons mLastButton = MouseButtons.None;

		public override void OnMouseDown(CellContext sender, MouseEventArgs e)
		{
			base.OnMouseDown(sender, e);

			mLastButton = e.Button;
		}
		public override void OnClick(CellContext sender, EventArgs e)
		{
			base.OnClick(sender, e);

			if (mLastButton == MouseButtons.Left)
				UIChangeChecked(sender, e);
		}

		#endregion

		private bool m_bAutoChangeValueOfSelectedCells = false;
		/// <summary>
		/// Indicates if this cells when checked or uncheck must change also the value of the selected cells of type CellRadioButton. Default is false
		/// </summary>
		public bool AutoChangeValueOfSelectedCells
		{
			get { return m_bAutoChangeValueOfSelectedCells; }
		}

		/// <summary>
		/// Toggle the value of the current cell and if AutoChangeValueOfSelectedCells is true of all the selected cells.
		/// Simulate an edit operation.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void UIChangeChecked(CellContext sender, EventArgs e)
		{
			Models.IRadioButton l_Check = (Models.IRadioButton)sender.Cell.Model.FindModel(typeof(Models.IRadioButton)); ;
			if (l_Check == null)
				throw new SourceGrid.SourceGridException("Models.IRadioButton not found");

			Models.RadioButtonStatus checkStatus = l_Check.GetRadioButtonStatus(sender);
			if (checkStatus.CheckEnable)
			{
				bool l_NewVal = !checkStatus.Checked;
				sender.StartEdit();
				try
				{
					l_Check.SetCheckedValue(sender, l_NewVal);
					sender.EndEdit(false);
				}
				catch (Exception)
				{
					sender.EndEdit(true);
					throw;
				}

				//change the status of all selected control
				if (AutoChangeValueOfSelectedCells)
				{
					foreach ( Position pos in sender.Grid.Selection.GetSelectionRegion().GetCellsPositions() )
					{
						Cells.ICellVirtual c = sender.Grid.GetCell(pos);
						Models.IRadioButton check;
						if (c != this && c != null &&
							 (check = (Models.IRadioButton)c.Model.FindModel(typeof(Models.IRadioButton))) != null)
						{
							CellContext context = new CellContext(sender.Grid, pos, c);
							context.StartEdit();
							try
							{
								check.SetCheckedValue(context, l_NewVal);
								context.EndEdit(false);
							}
							catch (Exception)
							{
								context.EndEdit(true);
								throw;
							}
						}
					}
				}
			}
		}

	}
}
