using SharpConfig;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace FortuneWheel
{
    public partial class presetForm : Form
    {
        // some attributes to apply undo
        private Dictionary<(int, int), object> _previousValues = new Dictionary<(int, int), object>();
        private Stack<Action> _undoStack = new Stack<Action>();

        private string[,] _sectionNamesAndExampleValue;
        private List<String> _nonNullableColumns;
        public mainForm ParentForm { get; set; }




        public presetForm(string[,] sectionNamesAndExampleValue, List<String> nonNullableColumns)
        {
            InitializeComponent();

            _sectionNamesAndExampleValue = sectionNamesAndExampleValue;
            _nonNullableColumns = nonNullableColumns;

            loadPreset();
        }







        // to check type of a given value, then returns the value with new type (detected type)
        public dynamic checkTypeOfValue(string value)
        {
            // Try to parse the value as various data types
            bool boolValue;
            int intValue;
            float floatValue;
            double doubleValue;

            if (bool.TryParse(value, out boolValue))
            {
                return boolValue;
            }
            else if (int.TryParse(value, out intValue))
            {
                return intValue;
            }
            else if (float.TryParse(value, NumberStyles.Float, CultureInfo.InvariantCulture, out floatValue))
            {
                return floatValue;
            }
            else if (double.TryParse(value, NumberStyles.Float, CultureInfo.InvariantCulture, out doubleValue))
            {
                return doubleValue;
            }
            else
            {
                return value;
            }
        }


        // to load preset
        private void loadPreset()
        {
            // to clear all data in the table, in case there are any
            if (mainPresetTable.Columns.Count > 0 || mainPresetTable.Rows.Count > 0)
            {
                mainPresetTable.Columns.Clear();
                mainPresetTable.Rows.Clear();
            }

            // Create the columns
            var textBoxColumnSecName = new DataGridViewTextBoxColumn();
            textBoxColumnSecName.Name = "TextColumn";
            textBoxColumnSecName.HeaderText = "Sections";
            textBoxColumnSecName.ReadOnly = true;

            var textBoxColumntype = new DataGridViewTextBoxColumn();
            textBoxColumntype.Name = "ComboBoxColumn";
            textBoxColumntype.HeaderText = "Type";
            textBoxColumntype.ReadOnly = true;

            var checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.Name = "checkBoxColumn";
            checkBoxColumn.HeaderText = "Non-Nullable";

            var textBoxColumnMin = new DataGridViewTextBoxColumn();
            textBoxColumnMin.Name = "MinColumn";
            textBoxColumnMin.HeaderText = "Min Range";

            var textBoxColumnMax = new DataGridViewTextBoxColumn();
            textBoxColumnMax.Name = "MaxColumn";
            textBoxColumnMax.HeaderText = "Max Range";

            // Add the columns to the DataGridView
            mainPresetTable.Columns.Add(textBoxColumnSecName);
            mainPresetTable.Columns.Add(textBoxColumntype);
            mainPresetTable.Columns.Add(checkBoxColumn);
            mainPresetTable.Columns.Add(textBoxColumnMin);
            mainPresetTable.Columns.Add(textBoxColumnMax);

            // Add data to the DataGridView
            for (int i = 0; i < _sectionNamesAndExampleValue.GetLength(0); i++)
            {
                var row = new DataGridViewRow();

                var textBoxCellSecName = new DataGridViewTextBoxCell();
                textBoxCellSecName.Value = _sectionNamesAndExampleValue[i, 0];

                var textBoxCellType = new DataGridViewTextBoxCell();
                textBoxCellType.Value = _sectionNamesAndExampleValue[i, 1];

                var checkBoxCell = new DataGridViewCheckBoxCell();
                checkBoxCell.Value = _nonNullableColumns.Contains(_sectionNamesAndExampleValue[i, 0].ToString()) || _sectionNamesAndExampleValue[i, 1] == "Int32" || _sectionNamesAndExampleValue[i, 1] == "Single" ? true:false;

                var textBoxCellMin = new DataGridViewTextBoxCell();
                textBoxCellMin.Value = 0;

                var textBoxCellMax = new DataGridViewTextBoxCell();
                textBoxCellMax.Value = 1;

                row.Cells.Add(textBoxCellSecName);
                row.Cells.Add(textBoxCellType);
                row.Cells.Add(checkBoxCell);
                row.Cells.Add(textBoxCellMin);
                row.Cells.Add(textBoxCellMax);

                mainPresetTable.Rows.Add(row);

                // check if value type can be in range (!string || !bool)
                if (string.Equals(textBoxCellType.Value.ToString(), "string", StringComparison.OrdinalIgnoreCase) || string.Equals(textBoxCellType.Value.ToString(), "boolean", StringComparison.OrdinalIgnoreCase))
                {
                    // change the column both min and max to be appear as readonly and can't be sorted
                    textBoxCellMin.ReadOnly = true; textBoxCellMin.Value = "-"; 
                    textBoxCellMax.ReadOnly = true; textBoxCellMax.Value = "-";

                    // 3 represents for min, and 4 represents for max
                    mainPresetTable.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
                    mainPresetTable.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
                }

                // to update checkboxes for number type of row to be readonly
                if (string.Equals(textBoxCellType.Value.ToString(), "int32", StringComparison.OrdinalIgnoreCase) || string.Equals(textBoxCellType.Value.ToString(), "single", StringComparison.OrdinalIgnoreCase))
                {
                    // change the column checkbox to be appear as readonly
                    checkBoxCell.ReadOnly = true;
                }
            }

            // Add the DataGridView to the form
            Controls.Add(mainPresetTable);
        }


        // for the undo feature
        private void mainPresetTable_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            // Store the current value of the cell being edited
            _previousValues[(e.ColumnIndex, e.RowIndex)] = mainPresetTable[e.ColumnIndex, e.RowIndex].Value;
        }

        private void mainPresetTable_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Store the previous and current values of the cell being edited
            object previousValue = _previousValues[(e.ColumnIndex, e.RowIndex)];
            object currentValue = mainPresetTable[e.ColumnIndex, e.RowIndex].Value;

            // Add an undo action to the stack
            _undoStack.Push(() => mainPresetTable[e.ColumnIndex, e.RowIndex].Value = previousValue);

            // Update the previous value dictionary for this cell
            _previousValues[(e.ColumnIndex, e.RowIndex)] = currentValue;
        }


        // to restrict user inputs
        private void mainPresetTable_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (mainPresetTable.Columns[e.ColumnIndex]?.Name?.ToString() != null)       // to reasure if the value is not null
            {
                if (mainPresetTable.Columns[e.ColumnIndex].HeaderText == "Min Range" || mainPresetTable.Columns[e.ColumnIndex].HeaderText == "Max Range")
                {
                    if (string.Equals(mainPresetTable[1, e.RowIndex].Value.ToString(), "single", StringComparison.OrdinalIgnoreCase))     // to restrict the input to be only float/single
                    {
                        // Try to parse the entered value as a number
                        if (checkTypeOfValue(e.FormattedValue.ToString()).GetType().Name == "Single" || checkTypeOfValue(e.FormattedValue.ToString()).GetType().Name == "Int32")    // check if the inputted value is float/single
                        {
                            mainPresetTable.Rows[e.RowIndex].ErrorText = "";
                        }
                        else
                        {
                            // Cancel the event
                            e.Cancel = true;

                            // Show an error message
                            mainPresetTable.Rows[e.RowIndex].ErrorText = "Please enter only float for both min range and max range column.";
                        }
                    } else if (string.Equals(mainPresetTable[1, e.RowIndex].Value.ToString(), "int32", StringComparison.OrdinalIgnoreCase))            // to restrict the input to be only int
                    {
                        // Try to parse the entered value as a number
                        if (checkTypeOfValue(e.FormattedValue.ToString()).GetType().Name != "Int32")    // check if the inputted value is integer
                        {
                            // Cancel the event
                            e.Cancel = true;

                            // Show an error message
                            mainPresetTable.Rows[e.RowIndex].ErrorText = "Please enter only integer for both min range and max range column.";
                        }
                        else
                        {
                            mainPresetTable.Rows[e.RowIndex].ErrorText = "";
                        }
                    }
                }
            }
        }







        // File, Strip Functions
        // to save preset and close the preset form
        private void saveStripBtn_Click(object sender, EventArgs e)
        {
            List<String> newNonNullableColumns = new List<String>();
            List<String> oldNonNullableColumns = ParentForm.nonNullableColumns;
            Dictionary<string, (int, int)> newIntColumns = new Dictionary<string, (int, int)>();
            Dictionary<string, (int, int)> oldIntColumns = ParentForm.intColumns;
            Dictionary<string, (Single, Single)> newSingleColumns = new Dictionary<string, (Single, Single)>();
            Dictionary<string, (Single, Single)>oldSingleColumns = ParentForm.singleColumns;

            // get the information
            foreach (DataGridViewRow row in mainPresetTable.Rows)
            {
                // update nonnullable columns
                if ((bool)row.Cells[2].Value)       // get result of checkboxes
                {
                    newNonNullableColumns.Add(row.Cells[0].Value.ToString());
                }

                // for numbers
                if (string.Equals(row.Cells[1].Value.ToString(), "int32", StringComparison.OrdinalIgnoreCase))           // get result of int restriction
                {
                    newIntColumns.Add(row.Cells[0].Value.ToString(), (checkTypeOfValue(row.Cells[3].Value.ToString()), checkTypeOfValue(row.Cells[4].Value.ToString())));
                } else if (string.Equals(row.Cells[1].Value.ToString(), "single", StringComparison.OrdinalIgnoreCase))   // get result of float/single restriction
                {
                    newSingleColumns.Add(row.Cells[0].Value.ToString(), (checkTypeOfValue(row.Cells[3].Value.ToString()), checkTypeOfValue(row.Cells[4].Value.ToString())));
                }           
            }

            // update the nonnullable columns variable in the parent
            ParentForm.nonNullableColumns = newNonNullableColumns;
            ParentForm.intColumns = newIntColumns;
            ParentForm.singleColumns = newSingleColumns;

            // check if there is any null value already in new nonnullable columns
            ParentForm.isCancelable = false;            // to avoid cell from being canceled
            if (ParentForm.triggerCellValidating())
            {
                MessageBox.Show("Validating success");
                ParentForm.isCancelable = true;         // revert back the value
                this.Close();
            }
            else
            {
                MessageBox.Show("Validating fail. Please check the values of a column before change it.");
                ParentForm.nonNullableColumns = oldNonNullableColumns;    // revert back the nonNullableColumns columns
                ParentForm.intColumns = oldIntColumns;    // revert back the intColumns columns
                ParentForm.singleColumns = oldSingleColumns;    // revert back the singleColumns columns
            }
        }


        // to back to main form
        private void backStripBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        // to close entire program
        private void exitStripBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }







        // Edit, Strip Functions
        // to undo changes
        private void undoStripBtn_Click(object sender, EventArgs e)
        {
            // Pop the most recent undo action off the stack and invoke it
            if (_undoStack.Count > 0)
            {
                Action undoAction = _undoStack.Pop();
                undoAction.Invoke();
            }
        }







        // View, Strip Functions
        // to refresh data
        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadPreset();
        }


        // to full screen window size
        private void fullScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Set the WindowState property to Normal
            this.WindowState = FormWindowState.Maximized;

            // Show the taskbar
            this.ShowInTaskbar = true;
        }


        // to minimize window size
        private void minimizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Set the WindowState property to Normal
            this.WindowState = FormWindowState.Minimized;

            // Show the taskbar
            this.ShowInTaskbar = true;
        }


        // to restore window size
        private void restoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Set the WindowState property to Normal
            this.WindowState = FormWindowState.Normal;

            // Show the taskbar.
            this.ShowInTaskbar = true;
        }


        // to close current window
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}