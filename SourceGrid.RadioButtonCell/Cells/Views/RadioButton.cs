using System;
using System.Collections.Generic;
using System.Text;


namespace SourceGrid.Cells.Views
{
	/// <summary>
	/// Summary description for VisualModelRadioButton.
	/// </summary>
	[Serializable]
	public class RadioButton : Cell
	{
		/// <summary>
		/// Represents a default RadioButton with the RadioButton image align to the Middle Center of the cell. You must use this VisualModel with a Cell of type ICellRadioButton.
		/// </summary>
		public new readonly static RadioButton Default = new RadioButton();
		/// <summary>
		/// Represents a RadioButton with the RadioButton image align to the Middle Left of the cell
		/// </summary>
		public readonly static RadioButton MiddleLeftAlign;

		#region Constructors

		static RadioButton()
		{
			MiddleLeftAlign = new RadioButton();
			MiddleLeftAlign.RadioButtonAlignment = DevAge.Drawing.ContentAlignment.MiddleLeft;
			MiddleLeftAlign.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleLeft;
		}

		/// <summary>
		/// Use default setting and construct a read and write VisualProperties
		/// </summary>
		public RadioButton()
		{
		}

		/// <summary>
		/// Copy constructor.  This method duplicate all the reference field (Image, Font, StringFormat) creating a new instance.
		/// </summary>
		/// <param name="p_Source"></param>
		/// <param name="p_bReadOnly"></param>
		public RadioButton(RadioButton p_Source)
			: base(p_Source)
		{
			m_RadioButtonAlignment = p_Source.m_RadioButtonAlignment;
		}
		#endregion

		private DevAge.Drawing.ContentAlignment m_RadioButtonAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
		/// <summary>
		/// Image Alignment
		/// </summary>
		public DevAge.Drawing.ContentAlignment RadioButtonAlignment
		{
			get { return m_RadioButtonAlignment; }
			set { m_RadioButtonAlignment = value; }
		}

		protected override void PrepareView(CellContext context)
		{
			base.PrepareView(context);

			PrepareVisualElementRadioButton(context, GetVisualElement_Check());
		}

		protected override IEnumerable<DevAge.Drawing.VisualElements.IVisualElement> GetElements()
		{
			DevAge.Drawing.VisualElements.IVisualElement check = GetVisualElement_Check();
			if (check != null)
				yield return check;

			foreach (DevAge.Drawing.VisualElements.IVisualElement v in GetBaseElements())
				yield return v;
		}
		private IEnumerable<DevAge.Drawing.VisualElements.IVisualElement> GetBaseElements()
		{
			return base.GetElements();
		}

		private DevAge.Drawing.VisualElements.IRadioButton mElementRadioButton = new DevAge.Drawing.VisualElements.RadioButtonThemed();
		protected virtual DevAge.Drawing.VisualElements.IRadioButton GetVisualElement_Check()
		{
			return mElementRadioButton;
		}

		protected virtual void PrepareVisualElementRadioButton(CellContext context, DevAge.Drawing.VisualElements.IRadioButton RadioButtonElement)
		{
			RadioButtonElement.AnchorArea = new DevAge.Drawing.AnchorArea(RadioButtonAlignment, false);

			Models.IRadioButton RadioButtonModel = (Models.IRadioButton)context.Cell.Model.FindModel(typeof(Models.IRadioButton));
			Models.RadioButtonStatus RadioButtonStatus = RadioButtonModel.GetRadioButtonStatus(context);

			if (context.CellRange.Contains(context.Grid.MouseCellPosition))
			{
				if (RadioButtonStatus.CheckEnable)
					RadioButtonElement.Style = DevAge.Drawing.ControlDrawStyle.Hot;
				else
					RadioButtonElement.Style = DevAge.Drawing.ControlDrawStyle.Disabled;
			}
			else
			{
				if (RadioButtonStatus.CheckEnable)
					RadioButtonElement.Style = DevAge.Drawing.ControlDrawStyle.Normal;
				else
					RadioButtonElement.Style = DevAge.Drawing.ControlDrawStyle.Disabled;
			}

			RadioButtonElement.RadioButtonState = RadioButtonStatus.CheckState;
			ElementText.Value = RadioButtonStatus.Caption;

		}

		#region Clone
		/// <summary>
		/// Clone this object. This method duplicate all the reference field (Image, Font, StringFormat) creating a new instance.
		/// </summary>
		/// <returns></returns>
		public override object Clone()
		{
			return new RadioButton(this);
		}
		#endregion
	}
}
