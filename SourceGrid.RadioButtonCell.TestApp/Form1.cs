using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace SourceGrid.RadioButtonCell.TestApp
{
	/// <summary>
	/// 
	/// </summary>
	public partial class Form1 : Form
	{
		/// <summary>
		/// 
		/// </summary>
		public Form1()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Fill the grid with three groups of radio button cells.
		/// Following code shows how to use the radio button cells.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Form1_Load(object sender, EventArgs e)
		{
			// Initialize the grid with row and column count and 
			// set up column and row header cells.

			this._sourceGrid.Redim(26, 7);
			this._sourceGrid.FixedRows = 1;
			this._sourceGrid.FixedColumns = 1;

			// Add the header cells.
			this._sourceGrid[0, 0] = new SourceGrid.Cells.Header();
			for (int i = 1; i < this._sourceGrid.ColumnsCount; i++)
			{
				this._sourceGrid[0, i] = new SourceGrid.Cells.ColumnHeader(i.ToString());
				this._sourceGrid[0, i].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
			}
			for (int i = 1; i < this._sourceGrid.RowsCount; i++)
			{
				this._sourceGrid[i, 0] = new SourceGrid.Cells.RowHeader(i.ToString());
				this._sourceGrid[i, 0].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleRight;
			}

			// Set the column widths to something reasonable.
			this._sourceGrid.Columns[0].Width = 30;
			for (int i = 1; i < this._sourceGrid.ColumnsCount; i++)
				this._sourceGrid.Columns[i].Width = 100;

			// Initially fill the grid with empty cells.
			for (int col = 1; col < this._sourceGrid.ColumnsCount; col++)
			{
				for (int row = 1; row < this._sourceGrid.RowsCount; row++)
					this._sourceGrid[row, col] = new SourceGrid.Cells.Cell();
			}

			// Now build the radio button cells...

			// We'll five groups of radio button cells.  The first group will have 
			// three radio button cells, the second group will have 5 radio button cells 
			// and the final group will have 4 radio button cells and they will all 
			// be oriented vertically.  The fourth group will have three cells and
			// be oriented horizontally and the finaly group will have seven cells 
			// and they will be palced apparently semi-randomly to show that they
			// don't need to occupy adjacent cells.
			
			// Build the radio button groups.
			// See comments in BuildRadioButtonCellGroup1 on how to do this.
			BuildRadioButtonCellGroup1();
			BuildRadioButtonCellGroup2();
			BuildRadioButtonCellGroup3();
			BuildRadioButtonCellGroup4();
			BuildRadioButtonCellGroup5();
		}

		/// <summary>
		/// 
		/// </summary>
		private void BuildRadioButtonCellGroup1()
		{
			// We start by creating a RadioButtonGroupController for the group.
			// This controller gets passed to each radio button cell's constructor
			// where 'group registration' takes place. 
			// The RadioButtonGroupController class is the glue' that holds a radio 
			// button group together and makes sure that only one radio button cell 
			// is ever checked. We must construct a single RadioButtonGroupController 
			// for each group of radio buttons in a grid.  
			SourceGrid.Cells.Controllers.RadioButtonGroupController group = new SourceGrid.Cells.Controllers.RadioButtonGroupController();

			// Construct the cells. They will self-register with the group controller in their constructors.
			// The second parameter indicates the cell's initial checked state.  It only makes 
			// sense for one of thes cells in the group to be initially checked.
			SourceGrid.Cells.RadioButton cell1 = new SourceGrid.Cells.RadioButton("Group 1, Cell 1", true, group);
			SourceGrid.Cells.RadioButton cell2 = new SourceGrid.Cells.RadioButton("Group 1, Cell 2", false, group);
			SourceGrid.Cells.RadioButton cell3 = new SourceGrid.Cells.RadioButton("Group 1, Cell 3", false, group);

			// Add the cells to the grid.
			this._sourceGrid[1, 1] = cell1;
			this._sourceGrid[2, 1] = cell2;
			this._sourceGrid[3, 1] = cell3;

			// That's it.  We're done.
			// NOTE: You will need to subscribe to cell events if outside entities
			//       need notification of a cell's state changing.
		}

		/// <summary>
		/// 
		/// </summary>
		private void BuildRadioButtonCellGroup2()
		{
			// Allocate a RadioButtonGroupController for this group.
			SourceGrid.Cells.Controllers.RadioButtonGroupController group = new SourceGrid.Cells.Controllers.RadioButtonGroupController();

			// Construct the cells.
			SourceGrid.Cells.RadioButton cell1 = new SourceGrid.Cells.RadioButton("Group 2, Cell 1", true, group);
			SourceGrid.Cells.RadioButton cell2 = new SourceGrid.Cells.RadioButton("Group 2, Cell 2", false, group);
			SourceGrid.Cells.RadioButton cell3 = new SourceGrid.Cells.RadioButton("Group 2, Cell 3", false, group);
			SourceGrid.Cells.RadioButton cell4 = new SourceGrid.Cells.RadioButton("Group 2, Cell 4", false, group);
			SourceGrid.Cells.RadioButton cell5 = new SourceGrid.Cells.RadioButton("Group 2, Cell 5", false, group);

			// Add the cells to the grid.
			this._sourceGrid[5, 1] = cell1;
			this._sourceGrid[6, 1] = cell2;
			this._sourceGrid[7, 1] = cell3;
			this._sourceGrid[8, 1] = cell4;
			this._sourceGrid[9, 1] = cell5;
		}

		/// <summary>
		/// 
		/// </summary>
		private void BuildRadioButtonCellGroup3()
		{
			// Allocate a RadioButtonGroupController for this group.
			SourceGrid.Cells.Controllers.RadioButtonGroupController group = new SourceGrid.Cells.Controllers.RadioButtonGroupController();

			// Construct the cells.
			SourceGrid.Cells.RadioButton cell1 = new SourceGrid.Cells.RadioButton("Group 3, Cell 1", true, group);
			SourceGrid.Cells.RadioButton cell2 = new SourceGrid.Cells.RadioButton("Group 3, Cell 2", false, group);
			SourceGrid.Cells.RadioButton cell3 = new SourceGrid.Cells.RadioButton("Group 3, Cell 3", false, group);
			SourceGrid.Cells.RadioButton cell4 = new SourceGrid.Cells.RadioButton("Group 3, Cell 4", false, group);

			// Add the cells to the grid.
			this._sourceGrid[11, 1] = cell1;
			this._sourceGrid[12, 1] = cell2;
			this._sourceGrid[13, 1] = cell3;
			this._sourceGrid[14, 1] = cell4;
		}

		/// <summary>
		/// 
		/// </summary>
		private void BuildRadioButtonCellGroup4()
		{
			// Allocate a RadioButtonGroupController for this group.
			SourceGrid.Cells.Controllers.RadioButtonGroupController group = new SourceGrid.Cells.Controllers.RadioButtonGroupController();

			// Construct the cells.
			SourceGrid.Cells.RadioButton cell1 = new SourceGrid.Cells.RadioButton("Group 4, Cell 1", true, group);
			SourceGrid.Cells.RadioButton cell2 = new SourceGrid.Cells.RadioButton("Group 4, Cell 2", false, group);
			SourceGrid.Cells.RadioButton cell3 = new SourceGrid.Cells.RadioButton("Group 4, Cell 3", false, group);

			// Add the cells to the grid.
			this._sourceGrid[2, 3] = cell1;
			this._sourceGrid[2, 4] = cell2;
			this._sourceGrid[2, 5] = cell3;
		}

		/// <summary>
		/// 
		/// </summary>
		private void BuildRadioButtonCellGroup5()
		{
			// Allocate a RadioButtonGroupController for this group.
			SourceGrid.Cells.Controllers.RadioButtonGroupController group = new SourceGrid.Cells.Controllers.RadioButtonGroupController();

			// Construct the cells.
			SourceGrid.Cells.RadioButton cell1 = new SourceGrid.Cells.RadioButton("Group 5, Cell 1", true, group);
			SourceGrid.Cells.RadioButton cell2 = new SourceGrid.Cells.RadioButton("Group 5, Cell 2", false, group);
			SourceGrid.Cells.RadioButton cell3 = new SourceGrid.Cells.RadioButton("Group 5, Cell 3", false, group);
			SourceGrid.Cells.RadioButton cell4 = new SourceGrid.Cells.RadioButton("Group 5, Cell 4", false, group);
			SourceGrid.Cells.RadioButton cell5 = new SourceGrid.Cells.RadioButton("Group 5, Cell 5", false, group);
			SourceGrid.Cells.RadioButton cell6 = new SourceGrid.Cells.RadioButton("Group 5, Cell 6", false, group);
			SourceGrid.Cells.RadioButton cell7 = new SourceGrid.Cells.RadioButton("Group 5, Cell 7", false, group);

			// Add the cells to the grid.
			this._sourceGrid[7, 3] = cell1;
			this._sourceGrid[8, 4] = cell2;
			this._sourceGrid[9, 5] = cell3;
			this._sourceGrid[10, 4] = cell4;
			this._sourceGrid[9, 6] = cell5;
			this._sourceGrid[15, 3] = cell6;
			this._sourceGrid[19, 4] = cell7;
		}
	}
}