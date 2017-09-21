using System;
using System.Collections.Generic;
using System.Text;


namespace SourceGrid.Cells.Virtual
{
	/// <summary>
	/// A Cell with a RadioButton. This Cell is of type bool. Abstract, you must override GetValue and SetValue.
	/// </summary>
	public class RadioButton : CellVirtual
	{
		/// <summary>
		/// Constructor of a RadioButton style cell. You must st a valid Model to use this type of cell with this constructor.
		/// </summary>
		public RadioButton()
		{
			View = Views.RadioButton.Default;
			AddController(Controllers.RadioButton.Default);
			AddController(Controllers.MouseInvalidate.Default);
			Editor = new Editors.EditorBase(typeof(bool));
			Editor.EditableMode = SourceGrid.EditableMode.None; //used also because the space key are directly used by the controller, so must not start an edit operation
			Model.AddModel(new Models.RadioButton());
		}
	}
}

namespace SourceGrid.Cells
{
	/// <summary>
	/// A Cell with a RadioButton. This Cell is of type bool.
	/// </summary>
	public class RadioButton : Cell
	{
		#region Constructor

		/// <summary>
		/// Constrcutor
		/// </summary>
		public RadioButton()
			: this(null, false, null)
		{
		}

		/// <summary>
		/// Construct a CellRadioButton class with caption and align RadioButton in the 
		/// MiddleLeft, using BehaviorModels.RadioButton.Default
		/// </summary>
		/// <param name="caption"></param>
		/// <param name="checkValue"></param>
		public RadioButton(string caption, bool checkValue, 
			SourceGrid.Cells.Controllers.RadioButtonGroupController group)
			: base(checkValue)
		{
			if (caption != null && caption.Length > 0)
				View = Views.RadioButton.MiddleLeftAlign;
			else
				View = Views.RadioButton.Default;

			Model.AddModel(new Models.RadioButton());
			AddController(Controllers.RadioButton.Default);
			AddController(Controllers.MouseInvalidate.Default);
			Editor = new Editors.EditorBase(typeof(bool));

			//used also because the space key are directly used by the controller, so must not start an edit operation
			Editor.EditableMode = SourceGrid.EditableMode.None; 
			Caption = caption;

			// Add this cell to the group. 
			if (group != null)
			{
				group.AppendCell(this);
				AddController(group);
			}
		}
		#endregion

		#region Properties
		private Models.RadioButton RadioButtonModel
		{
			get { return (Models.RadioButton)Model.FindModel(typeof(Models.RadioButton)); }
		}
		/// <summary>
		/// Checked status (equal to the Value property but returns a bool)
		/// </summary>
		public bool Checked
		{
			get { return RadioButtonModel.GetRadioButtonStatus(GetContext()).Checked; }
			set { RadioButtonModel.SetCheckedValue(GetContext(), value); }
		}

		/// <summary>
		/// Caption of the cell
		/// </summary>
		public string Caption
		{
			get { return RadioButtonModel.Caption; }
			set { RadioButtonModel.Caption = value; }
		}
		#endregion
	}
}
