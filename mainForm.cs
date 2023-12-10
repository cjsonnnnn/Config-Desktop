using SharpConfig;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace FortuneWheel
{
    public partial class mainForm : Form
    {
        // for multiwindow, so when the child is closed, then the parent won't be closed as well
        private mainForm childForm;

        // for the observer
        private readonly DataCollection _dataCollection;

        // to tell the location of the config file
        private string _configPath = String.Concat(Directory.GetCurrentDirectory(), @"\", "configs");
        private string _configFileName = "";

        // some attributes to apply undo
        private Dictionary<(int, int), object> _previousValues = new Dictionary<(int, int), object>();
        private Stack<Action> _undoStack = new Stack<Action> ();

        // to list all nonnullables columns
        public List<String> nonNullableColumns = new List<String>() { };

        // to list all integer columns
        public Dictionary<string, (int, int)> intColumns = new Dictionary<string, (int, int)> { };

        // to list all float/single columns
        public Dictionary<string, (Single, Single)> singleColumns = new Dictionary<string, (Single, Single)>() { };

        // to avoid cancel in cell, which will be used for preset form implementation of 'save preset'
        public bool isCancelable = true;
        private bool isForcedBreak = false;




        public mainForm(Boolean fileAvailable, string fileName="")
        {
            // inflate
            InitializeComponent();

            // set constructor values
            _dataCollection = new DataCollection();
            _dataCollection.PropertyChanged += DataCollectionPropertyChanged;
            _configFileName = fileName;
            _dataCollection.isFileAvailable = fileAvailable;

            // load cfg file
            loadData();
        }







        // action regarding to observer
        private void DataCollectionPropertyChanged(object sender, EventArgs e)
        {
            // update strip menu "Enabled" value, based on whether or not the file isFileAvailable
            saveStripBtn.Enabled = _dataCollection.isFileAvailable;
            saveAsStripBtn.Enabled = _dataCollection.isFileAvailable;
            editPresetStripBtn.Enabled = _dataCollection.isFileAvailable;
            refreshStripBtn.Enabled = _dataCollection.isFileAvailable;
            undoStripBtn.Enabled = _dataCollection.isFileAvailable;
            mainConfigTable.Visible = _dataCollection.isFileAvailable;

            // opposite dependation
            availableFilesListView.Visible = _dataCollection.isFileAvailable ? false : true;

            // update window's title
            if (_dataCollection.isFileAvailable)
            {
                this.Text = $"{this.Text} (currently open: {_configFileName})";
            } else
            {
                this.Text = "Fortune Wheel Config Editor";
            }
            
        }


        // to show available config files in the _configPath (target directory)
        private void showAvailableConfigFiles()
        {
            // get all the available files
            string[] availableFiles = Directory.GetFiles(String.Concat(_configPath, @"\", _configFileName), "*.cfg");

            // clear previous items
            availableFilesListView.Items.Clear();

            // show to screen using list view
            foreach(string cfgFileName in availableFiles)
            {
                ListViewItem item = new ListViewItem(Path.GetFileName(cfgFileName));
                item.SubItems.Add(cfgFileName);
                availableFilesListView.Items.Add(item);
            }
        }


        // to load data
        private void loadData()
        {

            if (_configFileName != "")
            {
                // Load data from the cfg file
                var config = Configuration.LoadFromFile(String.Concat(_configPath, @"\", _configFileName));

                // get all the section names
                IEnumerator<Section> enumerator = config.GetEnumerator();
                List<string> sectionNames = new List<string>();
                int iter = 1;
                while (enumerator.MoveNext())
                {
                    if (iter != 1)
                    {
                        // Add the name of the current section to the list
                        sectionNames.Add(enumerator.Current.Name);
                    }
                    iter++;
                }

                // Define a table
                var table = new DataTable();

                // fill the headers
                foreach (string header in sectionNames)
                {
                    table.Columns.Add(header);
                }

                // get all data
                List<string[]> data = new List<string[]>();
                foreach (string section in sectionNames)
                {
                    data.Add(config[section]["All"].GetValueArray<string>());
                }

                // fill each row
                int length = config[sectionNames[0]]["All"].ArraySize;
                for (int i = 0; i < length; i++)
                {
                    DataRow row = table.NewRow();
                    for (int j = 0; j < sectionNames.Count; j++)
                    {
                        row[j] = data[j][i];
                    }
                    table.Rows.Add(row);
                }

                // sinc with the table on the screen
                mainConfigTable.DataSource = table;
            } else
            {
                showAvailableConfigFiles();
            }
        }


        // for the undo feature
        private void mainConfigTable_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            // Store the current value of the cell being edited
            _previousValues[(e.ColumnIndex, e.RowIndex)] = mainConfigTable[e.ColumnIndex, e.RowIndex].Value;
        }

        private void mainConfigTable_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Store the previous and current values of the cell being edited
            object previousValue = _previousValues[(e.ColumnIndex, e.RowIndex)];
            object currentValue = mainConfigTable[e.ColumnIndex, e.RowIndex].Value;

            // Add an undo action to the stack
            _undoStack.Push(() => mainConfigTable[e.ColumnIndex, e.RowIndex].Value = previousValue);

            // Update the previous value dictionary for this cell
            _previousValues[(e.ColumnIndex, e.RowIndex)] = currentValue;
        }


        // to update config after changes
        private Configuration generateLatestConfig()
        {
            // Get the original configuration from the cfg file
            Configuration config = Configuration.LoadFromFile(String.Concat(_configPath, @"\", _configFileName));

            // iterate over headers/section names
            for (int i = 0; i < mainConfigTable.Columns.Count; i++)
            {
                // get a data of current column/section from the config file
                string[] secData = config[mainConfigTable.Columns[i].Name]["All"].GetValueArray<string>();

                for (int j = 0; j < secData.Length; j++)
                {
                    string value = mainConfigTable.Rows[j].Cells[i].Value == DBNull.Value ? "-" : mainConfigTable.Rows[j].Cells[i].Value.ToString();

                    if (secData[j] != value)
                    {
                        secData[j] = value;
                    }

                    // add new rows of data
                    if (j == secData.Length - 1 && mainConfigTable.Rows.Count - 1 > secData.Length)
                    {
                        for (int k = 0; k < (mainConfigTable.Rows.Count - 1) - secData.Length; k++)
                        {
                            string additionalValue = mainConfigTable.Rows[j + k + 1].Cells[i].Value == DBNull.Value ? "-" : mainConfigTable.Rows[j + k + 1].Cells[i].Value.ToString();
                            
                            // resize the array to add one more element
                            Array.Resize(ref secData, secData.Length + 1);

                            // add a new element at the last index of the array
                            secData[secData.Length - 1] = additionalValue;
                        }
                    }
                }

                // update the config
                config[mainConfigTable.Columns[i].Name]["All"].StringValueArray = secData;
            }

            return config;
        }


        // to navigate to a selected file in available cfg file list view
        private void availableFilesListView_MouseClick(object sender, MouseEventArgs e)
        {
            // Get the item at the mouse position
            ListViewItem clickedItem = availableFilesListView.GetItemAt(e.X, e.Y);

            // Check if an item was clicked
            if (clickedItem != null)
            {
                // update configFileName and notify the observer
                _configFileName = clickedItem.Text;
                _dataCollection.isFileAvailable = true;

                // load data
                loadData();
            }
        }


        // to prevent the child being closed when the parent is closed
        private void mainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Check if the child form is open
            if (childForm != null)
            {
                // Cancel the close event to prevent the parent form from closing
                e.Cancel = true;

                // Hide the parent form
                this.Hide();

                // Show the child form
                childForm.Show();
            }
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


        // to check the value type of all data inside a column. The orders are from int -> single -> string
        private string checkTypeOfColumn(int colIndex)
        {
            string state = null;

            for (int i= 0; i < mainConfigTable.Rows.Count-1; i++)
            {
                if (checkTypeOfValue(mainConfigTable[colIndex, i].Value.ToString()).GetType().Name == "Int32" && state != "Single") // check if the data is integer and the there is no any data with single type
                {
                    state = "Int32";
                } else if (checkTypeOfValue(mainConfigTable[colIndex, i].Value.ToString()).GetType().Name == "Single")  // check if the data is single
                {
                    state = "Single";
                } else if (checkTypeOfValue(mainConfigTable[colIndex, i].Value.ToString()).GetType().Name == "String")  // check if the data is single, and will immediately return 'String', as it is the last order
                {
                    return "String";
                }
            }

            return state;
        }


        // to restrict user inputs
        private void mainConfigTable_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (mainConfigTable.Columns[e.ColumnIndex]?.Name?.ToString() != null)       // to reasure if the value is not null
            {
                // to restrict user from inputting null value
                if (nonNullableColumns.Contains(mainConfigTable.Columns[e.ColumnIndex].Name.ToString()))     // check if the cell being edited is included in the nonnullable columns
                {
                    if (string.IsNullOrEmpty(e.FormattedValue.ToString()))              // to restrict the input to be only not null
                    {
                        if (isCancelable)
                        {
                            e.Cancel = true;
                            mainConfigTable.Rows[e.RowIndex].ErrorText = "The value in this cell cannot be empty.";
                        } else
                        {
                            isForcedBreak = true;
                        }
                    }
                    else
                    {
                        mainConfigTable.Rows[e.RowIndex].ErrorText = "";
                    }
                }

                // to restrict user from inputting wrong number type of value
                if (((List<string>)singleColumns.Keys.ToList()).Contains(mainConfigTable.Columns[e.ColumnIndex].Name.ToString()))
                {   // to restrict the input to be only number (single/float/int)
                    if (checkTypeOfValue(e.FormattedValue.ToString()).GetType().Name == "Single" || checkTypeOfValue(e.FormattedValue.ToString()).GetType().Name == "Int32")              
                    {
                        // to check if the value is in range
                        if (checkTypeOfValue(e.FormattedValue.ToString()) < singleColumns[mainConfigTable.Columns[e.ColumnIndex].Name.ToString()].Item1
                            || checkTypeOfValue(e.FormattedValue.ToString()) > singleColumns[mainConfigTable.Columns[e.ColumnIndex].Name.ToString()].Item2)
                        {
                            if (isCancelable)
                            {
                                e.Cancel = true;
                                mainConfigTable.Rows[e.RowIndex].ErrorText = "The value in this cell should be in range.";
                            }
                            else
                            {
                                isForcedBreak = true;
                            }
                        }
                        else
                        {
                            mainConfigTable.Rows[e.RowIndex].ErrorText = "";
                        }
                    }
                    else
                    {
                        if (isCancelable)
                        {
                            e.Cancel = true;
                            mainConfigTable.Rows[e.RowIndex].ErrorText = "The value in this cell should be number.";
                        }
                        else
                        {
                            isForcedBreak = true;
                        }
                    }
                } else if (((List<string>)intColumns.Keys.ToList()).Contains(mainConfigTable.Columns[e.ColumnIndex].Name.ToString()))
                {   // to restrict the input to be only integer
                    if (checkTypeOfValue(e.FormattedValue.ToString()).GetType().Name != "Int32")               
                    {
                        if (isCancelable)
                        {
                            e.Cancel = true;
                            mainConfigTable.Rows[e.RowIndex].ErrorText = "The value in this cell should be integer.";
                        }
                        else
                        {
                            isForcedBreak = true;
                        }
                    }
                    else
                    {
                        // to check if the value is in range
                        if (checkTypeOfValue(e.FormattedValue.ToString()) < intColumns[mainConfigTable.Columns[e.ColumnIndex].Name.ToString()].Item1 
                            || checkTypeOfValue(e.FormattedValue.ToString()) > intColumns[mainConfigTable.Columns[e.ColumnIndex].Name.ToString()].Item2)
                        {
                            if (isCancelable)
                            {
                                e.Cancel = true;
                                mainConfigTable.Rows[e.RowIndex].ErrorText = "The value in this cell should be in range.";
                            }
                            else
                            {
                                isForcedBreak = true;
                            }
                        } else
                        {
                            mainConfigTable.Rows[e.RowIndex].ErrorText = "";
                        }
                    }
                }
            } 
        }


        // to select all cells in order to trigger a cell validating function
        public bool triggerCellValidating()
        {
            // select all cells
            for (int rowIndex = 0; rowIndex < mainConfigTable.Rows.Count-1; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < mainConfigTable.Columns.Count; columnIndex++)
                {
                    if (!isForcedBreak)
                    {
                        mainConfigTable.CurrentCell = mainConfigTable[columnIndex, rowIndex];
                    } else
                    {
                        mainConfigTable.CurrentCell = null;
                        isForcedBreak = false;      // revert back the value
                        return false;
                    }
                }
            }

            mainConfigTable.CurrentCell = null;

            return true;
        }







        // File, Strip Functions
        // to open a config file
        private void openStripBtn_Click(object sender, EventArgs e)
        {
            // Create an instance of the OpenFileDialog class
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            // Set the title and filter for the dialog
            openFileDialog1.Title = "Select a file to upload";
            openFileDialog1.Filter = "Configuration files (*.cfg)|*.cfg";

            // Display the dialog and check if the user clicked OK
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (_configFileName == "")       // condition when opening a file when there is no file opened
                {
                    // Save the uploaded file to the user's desktop
                    _configFileName = Path.GetFileName(openFileDialog1.FileName);
                    string filePath = String.Concat(_configPath, "/", _configFileName);

                    if (Path.GetDirectoryName(openFileDialog1.FileName) != _configPath)
                    {
                        File.Copy(openFileDialog1.FileName, filePath, true);
                    }

                    // Load data
                    loadData();

                    // notify observer
                    _dataCollection.isFileAvailable = true;
                }
                else                            // condition when opening a file when there is no file opened
                {
                    // Save the uploaded file to the user's desktop
                    string configFileNameAnother = Path.GetFileName(openFileDialog1.FileName);
                    string filePath = String.Concat(_configPath, "/", configFileNameAnother);

                    if (Path.GetDirectoryName(openFileDialog1.FileName) != _configPath)
                    {
                        File.Copy(openFileDialog1.FileName, filePath, true);
                    }

                    // ask to user where the project should be opened
                    DialogResult result = MessageBox.Show($"Do you want to create a new window to open project {configFileNameAnother}?", "Open Project", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.No)
                    {
                        // update configFileName
                        _configFileName = configFileNameAnother;

                        // update window's title
                        this.Text = $"Fortune Wheel Config Editor (currently open: {_configFileName})";

                        // Load data
                        loadData();
                    } else
                    {
                        // define the form and setting up the constructor
                        childForm = new mainForm(true, configFileNameAnother);
                        childForm.Show();
                    }
                }
            }
        }


        // to save changes
        private void saveStripBtn_Click(object sender, EventArgs e)
        {
            // get the file
            Configuration theConfigFile = generateLatestConfig();

            try
            {
                theConfigFile.SaveToFile(String.Concat(_configPath, @"\", _configFileName));
                MessageBox.Show($"Changes Saved!");
            }
            catch
            {
                MessageBox.Show($"Changes Failed to Save!");
            }

            loadData();
        }


        // to save as changes
        private void saveAsStripBtn_Click(object sender, EventArgs e)
        {
            // get the file
            Configuration theConfigFile = generateLatestConfig();

            try
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "Configuration files (*.cfg)|*.cfg";
                saveFileDialog1.Title = "Save As";
                saveFileDialog1.ShowDialog();

                if (saveFileDialog1.FileName != "")
                {
                    // Save the file (Filename: is not solely the filename, but it is also included the exact path)
                    theConfigFile.SaveToFile(String.Concat(_configPath, "/", _configFileName));               // overwrite file, so when user refresh the data, then it will generate the saved changes
                    theConfigFile.SaveToFile(saveFileDialog1.FileName);
                }
            }
            catch
            {
                MessageBox.Show($"Changes Failed to Save As!");
            }
            
        }


        // to go back to menu 
        private void backStripBtn_Click(object sender, EventArgs e)
        {
            if (_configFileName != "") 
            {
                // update configFileName and notify the observer
                _configFileName = "";
                _dataCollection.isFileAvailable = false;

                // update list view
                showAvailableConfigFiles();
            } else
            {
                this.Close();
            }
        }


        // to exit window
        private void exitStripBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        



        // Edit, Strip Functions
        // to navigate to presetForm
        private void editPresetStripBtn_Click(object sender, EventArgs e)
        {
            // get section names and the example value
            string[,] sectionNames = new string[mainConfigTable.Columns.Count, 2];
            for (int i = 0; i < mainConfigTable.Columns.Count; i++)
            {
                // Get the header text for each column
                sectionNames[i, 0] = mainConfigTable.Columns[i].Name;
                //sectionNames[i, 1] = mainConfigTable[i, 0].Value.ToString();
                sectionNames[i, 1] = checkTypeOfColumn(i);
            }

            // trigger the form
            presetForm presetForm = new presetForm(sectionNames, nonNullableColumns);
            presetForm.ParentForm = this;
            presetForm.ShowDialog();
        }


        // to undo changes on the table
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
        // to full screen window size
        private void fullScreenStripBtn_Click(object sender, EventArgs e)
        {
            // Set the WindowState property to Normal
            this.WindowState = FormWindowState.Maximized;

            // Show the taskbar
            this.ShowInTaskbar = true;
        }


        // to minimize window size
        private void minimizeStripBtn_Click(object sender, EventArgs e)
        {
            // Set the WindowState property to Normal
            this.WindowState = FormWindowState.Minimized;

            // Show the taskbar
            this.ShowInTaskbar = true;
        }


        // to restore window size
        private void restoreStripBtn_Click(object sender, EventArgs e)
        {
            // Set the WindowState property to Normal
            this.WindowState = FormWindowState.Normal;

            // Show the taskbar.
            this.ShowInTaskbar = true;
        }


        // to close window
        private void closeStripBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        // to reload data by triggering the LoadData()
        private void refreshStripBtn_Click(object sender, EventArgs e)
        {
            loadData();
        }
    }


    // observer
    public class DataCollection
    {
        private bool _isFileAvailable = false;
        public bool isFileAvailable
        {
            get => _isFileAvailable;
            set
            {
                if (_isFileAvailable != value)        // this is an alternative of using ValueChanged, so then the value shouldn't be an object
                {
                    _isFileAvailable = value;
                    OnPropertyChanged("Value");
                }
                //_value = value;
                //MessageBox.Show("asd");
                //ValueChanged?.Invoke(this, EventArgs.Empty);      // the ValueChanged is an event provided from the value (toolbox object)
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //public event EventHandler ValueChanged;
    }
}



// there are 2 types of observer at least in winform:
// - using data binding, means that the data being observed is from property value of a value (which should be an object, ex: toolbox)
// - another is not using, means that the data being observed is from normal variable that is (at least in my case) declared inside the observer (ex: DataCollection)