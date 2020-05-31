using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Oracle.DataAccess.Client;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        public String connectionString = "DATA SOURCE = (DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)" +
                    "(HOST = LOCALHOST)(PORT = 1521))(CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME = ORCL)));" +
                    "User Id = domino; password=Domino123";
        public OracleConnection connection = new OracleConnection();
        public OracleDataAdapter dataAdapter;
        DataTable dataTable;
        DataGridViewRow currentRow;
        public int allRows;
        public int allRowsInDatabase;
        public string sqlInsert;
        public string sqlDelete;
        public string sqlUpdate;
        public Boolean buttonsEnablement = true;
        public string chosenTable;
        public string queryEdited;
        public int currentCellRow;
        public int currentCellColumn;
        public List<string> firstColumnsValues = new List<string>();
        public List<int> updatedRowsIndexes = new List<int>();
        public List<string> updatedRowsValues = new List<string>();

        public Form3(string theText)
        {
            InitializeComponent();
            this.BackgroundImage = Properties.Resources.gui2;
            connection.ConnectionString = connectionString;
            try
            {
                connection.Open();
            }
            catch (Oracle.DataAccess.Client.OracleException oe) {              
                this.Close();
            }


            try
            {
                userPicture.ImageLocation = @"C:\Users\Chąśno\source\repos\WindowsFormsApp1\admin.png";
                userPicture.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch (FileNotFoundException e)
            {
                System.Console.WriteLine(e.Message);
            }
            try
            {
                logoutPicture.ImageLocation = @"C:\Users\Chąśno\source\repos\WindowsFormsApp1\logout.png";
                logoutPicture.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch (FileNotFoundException f)
            {
                System.Console.WriteLine(f.Message);
            }

            labelUser.Text = "Zalogowano jako: " + theText;

            tableComboBox.Text = "Wybierz relację";
            tableComboBox.Items.Add("Banki");
            tableComboBox.Items.Add("Oddzialy_bankowe");
            tableComboBox.Items.Add("Klienci");
            tableComboBox.Items.Add("Pracownicy");
            tableComboBox.Items.Add("Wynagrodzenia");
            tableComboBox.Items.Add("Stanowiska");
            tableComboBox.Items.Add("Uslugi");
            tableComboBox.Items.Add("Konta");
            tableComboBox.Items.Add("Lokaty");
            tableComboBox.Items.Add("Karty_kredytowe");
            tableComboBox.Items.Add("Aplikacje_mobilne");
            tableComboBox.Items.Add("Kredyty");
            tableComboBox.Items.Add("Urzadzenia_terenowe");
            tableComboBox.Items.Add("Bankomaty");
            tableComboBox.Items.Add("Wplatomaty");
            tableComboBox.Items.Add("Korzystania");
            tableComboBox.Items.Add("Obslugi");
            tableComboBox.Sorted = true;

            queryComboBox.Text = "Typ zapytania";
            queryComboBox.Items.Add("Select");
            queryComboBox.Items.Add("Insert");
            queryComboBox.Items.Add("Update");
            queryComboBox.Items.Add("Delete");
            queryComboBox.Items.Add("Inne");

            deleteButton.Enabled = false;
            insertButton.Enabled = false;
            updateButton.Enabled = false;
        }

        private void dataView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
            MessageBox.Show("Niepoprawny typ danych");

        }

        private void refreshGrid()
        {
            
            dataView.Refresh();
            allRows = dataView.Rows.Count;
        }

        private void refreshGrid2()
        {
            dataView.AllowUserToAddRows = true;
            updatedRowsIndexes.Clear();
            updatedRowsValues.Clear();
            try
            {
                using (connection = new OracleConnection(connectionString))
                {
                    dataAdapter = new OracleDataAdapter("Select * from " + chosenTable, connection);
                    dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    dataView.DataSource = dataTable;
                    refreshGrid();
                    allRowsInDatabase = dataView.Rows.Count - 1;
                }
            }
            catch (Oracle.DataAccess.Client.OracleException oe)
            {
                MessageBox.Show("Nie ma takiej relacji w bazie!");
                return;
            }

            firstColumnsValues.Clear();
            for (int i = 0; i < dataView.Rows.Count - 1; i++)
            {
                firstColumnsValues.Add(dataView.Rows[i].Cells[0].Value.ToString());
                Console.WriteLine(firstColumnsValues[i]);
            }

            foreach (DataGridViewColumn column in dataView.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

        }

        private void logoutPicture_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Zostałeś Wylogowany!");

            this.Close();
        }

        private void showingTableButton_Click(object sender, EventArgs e)
        {

            updatedRowsIndexes.Clear();
            updatedRowsValues.Clear();
            dataTable = new DataTable();
            dataView.DataSource = dataTable;
            chosenTable = tableComboBox.GetItemText(tableComboBox.SelectedItem);
            buttonsEnablement = true;
            dataView.AllowUserToAddRows = true;

            try
            {
                using (connection = new OracleConnection(connectionString))
                {
                    dataAdapter = new OracleDataAdapter("Select * from " + chosenTable, connection);
                    dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    dataView.DataSource = dataTable;
                    refreshGrid();
                    allRowsInDatabase = dataView.Rows.Count - 1;
                }
            }
            catch (Oracle.DataAccess.Client.OracleException oe)
            {
                MessageBox.Show("Nie ma takiej relacji w bazie!");
                return;
            }

            firstColumnsValues.Clear();
            for(int i=0; i < dataView.Rows.Count - 1; i++)
            {
                firstColumnsValues.Add(dataView.Rows[i].Cells[0].Value.ToString());
                Console.WriteLine(firstColumnsValues[i]);
            }

            foreach (DataGridViewColumn column in dataView.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

        }

        private void deleteButton_MouseClick(object sender, MouseEventArgs e)
        {
            if (currentRow.Selected)
            {
                if (updatedRowsIndexes.Count > 0)
                {
                    
                    if (MessageBox.Show("Jeśli usuniesz wiersz, utracisz wszystkie zmiany " + Environment.NewLine + "wprowadzone do tabeli!", "MessageBox Title", MessageBoxButtons.OKCancel) == DialogResult.OK)

                    {
                        try
                        {
                            using (connection = new OracleConnection(connectionString))
                            {
                                connection.Open();

                                string firstColumnName = dataView.Columns[0].HeaderText;
                                string firstColumnValueFromSelectedRow = currentRow.Cells[0].Value.ToString();

                                if ((chosenTable == "Obslugi") || (chosenTable == "Korzystania"))
                                {
                                    string secondColumnName = dataView.Columns[1].HeaderText;
                                    string secondColumnValueFromSelectedRow = currentRow.Cells[1].Value.ToString();
                                    string thirdColumnName = dataView.Columns[2].HeaderText;
                                    string thirdColumnValueFromSelectedRow = currentRow.Cells[2].Value.ToString();
                                    thirdColumnValueFromSelectedRow = thirdColumnValueFromSelectedRow.Replace(".", "-");
                                    thirdColumnValueFromSelectedRow = thirdColumnValueFromSelectedRow.Substring(0, 10);
                                    thirdColumnValueFromSelectedRow = thirdColumnValueFromSelectedRow.Substring(6, 4) + thirdColumnValueFromSelectedRow.Substring(2, 4) +
                                        thirdColumnValueFromSelectedRow.Substring(0, 2);
                                    sqlDelete = "DELETE from " + chosenTable + " WHERE " + firstColumnName + "=" + firstColumnValueFromSelectedRow + " AND "
                                        + secondColumnName + "=" + secondColumnValueFromSelectedRow + " AND " + thirdColumnName + "= date '" + thirdColumnValueFromSelectedRow + "'";
                                }
                                else
                                {
                                    sqlDelete = "DELETE from " + chosenTable + " WHERE " + firstColumnName + "=" + firstColumnValueFromSelectedRow;
                                }

                                OracleCommand cmdDelete = new OracleCommand();
                                cmdDelete.Connection = connection;
                                cmdDelete.CommandText = sqlDelete;
                                cmdDelete.CommandType = CommandType.Text;
                                cmdDelete.ExecuteNonQuery();
                                cmdDelete.Dispose();

                            }
                        }
                        catch (Oracle.DataAccess.Client.OracleException oe)
                        {
                            MessageBox.Show("Błędne zapytanie!");
                        }

                        dataView.Rows.RemoveAt(currentRow.Index);
                        refreshGrid();
                        if (dataView.Rows.Count > allRowsInDatabase)
                        {
                            allRows = allRows - 1;
                        }
                        refreshGrid2();
                        deleteButton.Enabled = false;
                        updatedRowsIndexes.Clear();
                        updatedRowsValues.Clear();

                    }                  
                }
                else
                {
                    try
                    {
                        using (connection = new OracleConnection(connectionString))
                        {
                            connection.Open();

                            string firstColumnName = dataView.Columns[0].HeaderText;
                            string firstColumnValueFromSelectedRow = currentRow.Cells[0].Value.ToString();



                            if ((chosenTable == "Obslugi") || (chosenTable == "Korzystania"))
                            {
                                string secondColumnName = dataView.Columns[1].HeaderText;
                                string secondColumnValueFromSelectedRow = currentRow.Cells[1].Value.ToString();
                                string thirdColumnName = dataView.Columns[2].HeaderText;
                                string thirdColumnValueFromSelectedRow = currentRow.Cells[2].Value.ToString();
                                thirdColumnValueFromSelectedRow = thirdColumnValueFromSelectedRow.Replace(".", "-");
                                thirdColumnValueFromSelectedRow = thirdColumnValueFromSelectedRow.Substring(0, 10);
                                thirdColumnValueFromSelectedRow = thirdColumnValueFromSelectedRow.Substring(6, 4) + thirdColumnValueFromSelectedRow.Substring(2, 4) +
                                    thirdColumnValueFromSelectedRow.Substring(0, 2);
                                sqlDelete = "DELETE from " + chosenTable + " WHERE " + firstColumnName + "=" + firstColumnValueFromSelectedRow + " AND "
                                    + secondColumnName + "=" + secondColumnValueFromSelectedRow + " AND " + thirdColumnName + "= date '" + thirdColumnValueFromSelectedRow + "'";
                            }
                            else
                            {
                                sqlDelete = "DELETE from " + chosenTable + " WHERE " + firstColumnName + "=" + firstColumnValueFromSelectedRow;
                            }

                            OracleCommand cmdDelete = new OracleCommand();
                            cmdDelete.Connection = connection;
                            cmdDelete.CommandText = sqlDelete;
                            cmdDelete.CommandType = CommandType.Text;
                            cmdDelete.ExecuteNonQuery();
                            cmdDelete.Dispose();

                        }
                    }
                    catch (Oracle.DataAccess.Client.OracleException oe)
                    {
                        MessageBox.Show("Błędne zapytanie!");
                    }

                    dataView.Rows.RemoveAt(currentRow.Index);
                    refreshGrid();
                    if (dataView.Rows.Count > allRowsInDatabase)
                    {
                        allRows = allRows - 1;
                    }
                    refreshGrid2();
                    deleteButton.Enabled = false;
                    updatedRowsIndexes.Clear();
                    updatedRowsValues.Clear();
                }
            }

        }      

        private void dataView_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            currentRow = dataView.SelectedRows[0];
            if (currentRow.Index < (allRows - 1) && buttonsEnablement)
            {
                deleteButton.Enabled = true;

            }
            if (currentRow.Index < (allRows - 1) && buttonsEnablement && updatedRowsIndexes.Contains(e.RowIndex))
            {
                updateButton.Enabled = true;

            }
            if (currentRow.Index == (allRows - 1) && buttonsEnablement)
            {
                insertButton.Enabled = true;
            }
        }

        private void dataView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!updatedRowsIndexes.Contains(e.RowIndex) && e.RowIndex+1<allRows)
            {
                updatedRowsIndexes.Add(e.RowIndex);
            }
            if (e.RowIndex + 1 < allRows)
            {
                dataView.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Yellow;              

                if (updatedRowsValues.Count > 0) {
                  
                    for (int i = updatedRowsValues.Count - 1; i >= 0; i--)
                    {
                        if(updatedRowsValues[i].Split(' ')[0] == e.RowIndex.ToString() && updatedRowsValues[i].Split(' ')[1] == e.ColumnIndex.ToString())
                        updatedRowsValues.RemoveAt(i);
                    }
                }
                updatedRowsValues.Add(e.RowIndex + " " + e.ColumnIndex + " " + dataView.Columns[e.ColumnIndex].HeaderText);
            }

            foreach (string n in updatedRowsValues)
            {
                Console.WriteLine(n);
            }
        }

        private void dataView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            currentCellRow = e.RowIndex;
            updateButton.Enabled = false;
            deleteButton.Enabled = false;
            insertButton.Enabled = false;                       
            
                       
            if (e.RowIndex >= 0)
            {
                dataView.Rows[e.RowIndex].Cells[0].ReadOnly = false;

                try
                {
                    if (e.RowIndex + 1 > allRows)
                    {
                        dataView.Rows[e.RowIndex].ReadOnly = true;
                        MessageBox.Show("Zakończ dodawanie poprzedniego wiersza, aby dodać następne!");
                    }
                    else
                    {
                        dataView.Rows[e.RowIndex].ReadOnly = false;
                    }


                    if (chosenTable == "Banki" || chosenTable == "Oddzialy_bankowe" || chosenTable == "Pracownicy" || chosenTable == "Klienci" || chosenTable == "Stanowiska" ||
                            chosenTable == "Wynagrodzenia" || chosenTable == "Uslugi" || chosenTable == "Urzadzenia_terenowe")
                    {
                        dataView.Rows[e.RowIndex].Cells[0].ReadOnly = true;
                    }                   

                }
                catch(InvalidOperationException ioe)
                {
                    return;
                }
               
            }
        }

        private void insertButton_Click(object sender, EventArgs e)
        {
            var insertValues = new List<string>();
            for (int i = 0; i < dataView.Columns.Count; i++)
            {
                insertValues.Add(currentRow.Cells[i].Value.ToString());
            }


            if (currentRow.Selected)
            {

                if (updatedRowsIndexes.Count > 0)
                {
                    if (MessageBox.Show("Jeśli dodasz wiersz, utracisz wszystkie zmiany " + Environment.NewLine + "wprowadzone do tabeli!", "Uwaga!", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        try
                        {
                            using (connection = new OracleConnection(connectionString))
                            {
                                connection.Open();
                                string chosenTable = tableComboBox.GetItemText(tableComboBox.SelectedItem);
                                if (chosenTable == "Bankomaty")
                                {
                                    sqlInsert = "INSERT INTO " + chosenTable + " VALUES (:1, :2, :3, :4)";
                                }
                                if (chosenTable == "Aplikacje_mobilne")
                                {
                                    sqlInsert = "INSERT INTO " + chosenTable + " VALUES (:1, :2, :3, :4)";
                                }
                                if (chosenTable == "Banki")
                                {
                                    sqlInsert = "INSERT INTO " + chosenTable + " VALUES (:1, :2, :3, :4, :5, :6, :7, :8, :9)";
                                }
                                if (chosenTable == "Karty_kredytowe")
                                {
                                    insertValues[6] = insertValues[6].Replace(",", ".");
                                    insertValues[5] = insertValues[5].Replace(",", ".");
                                    if (insertValues[6] == "")
                                    {
                                        insertValues[6] = "null";
                                    }
                                    sqlInsert = "Insert into " + chosenTable + " VALUES(" + insertValues[0] + ",'" + insertValues[1] + "','" + insertValues[2] + "','" + insertValues[3] + "','" + insertValues[4] + "'," + insertValues[5]
                                                                    + "," + insertValues[6] + ",'" + insertValues[7] + "')";
                                }
                                if (chosenTable == "Klienci")
                                {
                                    insertValues[6] = insertValues[6].Replace(".", "-");
                                    insertValues[6] = insertValues[6].Substring(0, 10);
                                    insertValues[6] = insertValues[6].Substring(6, 4) + insertValues[6].Substring(2, 4) +
                                    insertValues[6].Substring(0, 2);
                                    sqlInsert = "Insert into " + chosenTable + " VALUES(null,'" + insertValues[1] + "','" + insertValues[2] + "','" + insertValues[3] + "','" + insertValues[4] + "','" + insertValues[5] + "', date '"
                                        + insertValues[6] + "','" + insertValues[7] + "','" + insertValues[8] + "','" + insertValues[9] + "','" + insertValues[10] + "','" + insertValues[11] + "','" + insertValues[12] + "'," + insertValues[13] + ")";

                                }
                                if (chosenTable == "Konta")
                                {
                                    insertValues[2] = insertValues[2].Replace(",", ".");
                                    sqlInsert = "Insert into " + chosenTable + " VALUES(" + insertValues[0] + "," + insertValues[1] + "," + insertValues[2] + ",'" + insertValues[3] + "','" + insertValues[4] + "','" + insertValues[5] + "')";
                                }
                                if ((chosenTable == "Korzystania") || (chosenTable == "Obslugi"))
                                {
                                    insertValues[2] = insertValues[2].Replace(".", "-");
                                    insertValues[2] = insertValues[2].Substring(0, 10);
                                    insertValues[2] = insertValues[2].Substring(6, 4) + insertValues[2].Substring(2, 4) +
                                    insertValues[2].Substring(0, 2);
                                    sqlInsert = "Insert into " + chosenTable + " VALUES(" + insertValues[0] + "," + insertValues[1] + ", date '"
                                        + insertValues[2] + "')";
                                }
                                if (chosenTable == "Kredyty")
                                {
                                    insertValues[1] = insertValues[1].Replace(",", ".");
                                    insertValues[3] = insertValues[3].Replace(",", ".");
                                    insertValues[4] = insertValues[4].Replace(".", "-");
                                    insertValues[4] = insertValues[4].Substring(0, 10);
                                    insertValues[4] = insertValues[4].Substring(6, 4) + insertValues[4].Substring(2, 4) +
                                    insertValues[4].Substring(0, 2);

                                    sqlInsert = "Insert into " + chosenTable + " VALUES(" + insertValues[0] + "," + insertValues[1] + ",'" + insertValues[2] + "'," + insertValues[3] + ", date '" + insertValues[4] + "')";
                                }
                                if (chosenTable == "Lokaty")
                                {
                                    insertValues[1] = insertValues[1].Replace(",", ".");
                                    insertValues[2] = insertValues[2].Replace(",", ".");
                                    insertValues[3] = insertValues[3].Replace(".", "-");
                                    insertValues[3] = insertValues[3].Substring(0, 10);
                                    insertValues[3] = insertValues[3].Substring(6, 4) + insertValues[3].Substring(2, 4) +
                                    insertValues[3].Substring(0, 2);

                                    sqlInsert = "Insert into " + chosenTable + " VALUES(" + insertValues[0] + "," + insertValues[1] + "," + insertValues[2] + ", date '" + insertValues[3] + "','" + insertValues[4] + "')";
                                }
                                if (chosenTable == "Oddzialy_bankowe")
                                {

                                    sqlInsert = "Insert into " + chosenTable + " VALUES(null,'" + insertValues[1] + "','" + insertValues[2] + "','" + insertValues[3] + "','" + insertValues[4] + "','" + insertValues[5]
                                        + "','" + insertValues[6] + "','" + insertValues[7] + "'," + insertValues[8] + ")";

                                }
                                if (chosenTable == "Pracownicy")
                                {
                                    insertValues[5] = insertValues[5].Replace(".", "-");
                                    insertValues[5] = insertValues[5].Substring(0, 10);
                                    insertValues[5] = insertValues[5].Substring(6, 4) + insertValues[5].Substring(2, 4) +
                                    insertValues[5].Substring(0, 2);
                                    insertValues[12] = insertValues[12].Replace(".", "-");
                                    insertValues[12] = insertValues[12].Substring(0, 10);
                                    insertValues[12] = insertValues[12].Substring(6, 4) + insertValues[12].Substring(2, 4) +
                                    insertValues[12].Substring(0, 2);

                                    sqlInsert = "Insert into " + chosenTable + " VALUES(null,'" + insertValues[1] + "','" + insertValues[2] + "','" + insertValues[3] + "','" + insertValues[4] + "', date '" + insertValues[5]
                                        + "','" + insertValues[6] + "','" + insertValues[7] + "','" + insertValues[8] + "','" + insertValues[9] + "','" + insertValues[10] + "','" + insertValues[11] + "',date '" + insertValues[12] + "','" + insertValues[13] + "'," + insertValues[14] + "," + insertValues[15] + ")";
                                }
                                if (chosenTable == "Stanowiska")
                                {

                                    sqlInsert = "Insert into " + chosenTable + " VALUES(null,'" + insertValues[1] + "','" + insertValues[2] + "')";

                                }
                                if (chosenTable == "Urzadzenia_terenowe")
                                {
                                    insertValues[4] = insertValues[4].Replace(",", ".");
                                    sqlInsert = "Insert into " + chosenTable + " VALUES(null,'" + insertValues[1] + "','" + insertValues[2] + "','" + insertValues[3] + "'," + insertValues[4] + ",'" + insertValues[5]
                                       + "','" + insertValues[6] + "'," + insertValues[7] + ")";
                                }
                                if (chosenTable == "Uslugi")
                                {
                                    insertValues[2] = insertValues[2].Replace(".", "-");
                                    insertValues[2] = insertValues[2].Substring(0, 10);
                                    insertValues[2] = insertValues[2].Substring(6, 4) + insertValues[2].Substring(2, 4) +
                                    insertValues[2].Substring(0, 2);
                                    sqlInsert = "Insert into " + chosenTable + " VALUES(null,'" + insertValues[1] + "', date '" + insertValues[2] + "'," + insertValues[3] + ")";
                                }
                                if (chosenTable == "Wplatomaty")
                                {
                                    insertValues[1] = insertValues[1].Replace(",", ".");
                                    insertValues[2] = insertValues[2].Replace(",", ".");
                                    sqlInsert = "Insert into " + chosenTable + " VALUES(" + insertValues[0] + "," + insertValues[1] + "," + insertValues[2] + ")";

                                }
                                if (chosenTable == "Wynagrodzenia")
                                {
                                    Console.WriteLine(insertValues[3]);
                                    insertValues[1] = insertValues[1].Replace(",", ".");
                                    insertValues[3] = insertValues[3].Replace(",", ".");
                                    if (insertValues[3] == "")
                                    {
                                        insertValues[3] = "null";
                                    }
                                    insertValues[2] = insertValues[2].Replace(".", "-");
                                    insertValues[2] = insertValues[2].Substring(0, 10);
                                    insertValues[2] = insertValues[2].Substring(6, 4) + insertValues[2].Substring(2, 4) +
                                    insertValues[2].Substring(0, 2);

                                    sqlInsert = "Insert into " + chosenTable + " VALUES(null," + insertValues[1] + ", date '" + insertValues[2] + "'," + insertValues[3] + "," + insertValues[4] + ")";
                                }

                                Console.WriteLine(sqlInsert);
                                OracleCommand cmdInsert = new OracleCommand();
                                cmdInsert.Connection = connection;
                                cmdInsert.CommandText = sqlInsert;

                                if (chosenTable == "Bankomaty")
                                {

                                    cmdInsert.Parameters.Add(new OracleParameter("1",
                                               OracleDbType.Int32,
                                               insertValues[0],
                                               ParameterDirection.Input));
                                    cmdInsert.Parameters.Add(new OracleParameter("2",
                                                   OracleDbType.Varchar2,
                                                   insertValues[1],
                                                   ParameterDirection.Input));
                                    cmdInsert.Parameters.Add(new OracleParameter("3",
                                                    OracleDbType.Varchar2,
                                                    insertValues[2],
                                                    ParameterDirection.Input));
                                    cmdInsert.Parameters.Add(new OracleParameter("4",
                                                    OracleDbType.Int32,
                                                    insertValues[3],
                                                    ParameterDirection.Input));
                                }
                                if (chosenTable == "Aplikacje_mobilne")
                                {
                                    cmdInsert.Parameters.Add(new OracleParameter("1",
                                               OracleDbType.Int32,
                                               insertValues[0],
                                               ParameterDirection.Input));
                                    cmdInsert.Parameters.Add(new OracleParameter("2",
                                                   OracleDbType.Char,
                                                   insertValues[1],
                                                   ParameterDirection.Input));
                                    cmdInsert.Parameters.Add(new OracleParameter("3",
                                                    OracleDbType.Char,
                                                    insertValues[2],
                                                    ParameterDirection.Input));
                                    cmdInsert.Parameters.Add(new OracleParameter("4",
                                                    OracleDbType.Char,
                                                    insertValues[3],
                                                    ParameterDirection.Input));
                                }
                                if (chosenTable == "Banki")
                                {
                                    cmdInsert.Parameters.Add(new OracleParameter("1",
                                               OracleDbType.Varchar2,
                                               insertValues[0],
                                               ParameterDirection.Input));
                                    cmdInsert.Parameters.Add(new OracleParameter("2",
                                                   OracleDbType.Varchar2,
                                                   insertValues[1],
                                                   ParameterDirection.Input));
                                    cmdInsert.Parameters.Add(new OracleParameter("3",
                                                    OracleDbType.Varchar2,
                                                    insertValues[2],
                                                    ParameterDirection.Input));
                                    cmdInsert.Parameters.Add(new OracleParameter("4",
                                                    OracleDbType.Varchar2,
                                                    insertValues[3],
                                                    ParameterDirection.Input));
                                    cmdInsert.Parameters.Add(new OracleParameter("5",
                                                    OracleDbType.Varchar2,
                                                    insertValues[4],
                                                    ParameterDirection.Input));
                                    cmdInsert.Parameters.Add(new OracleParameter("6",
                                                    OracleDbType.Char,
                                                    insertValues[5],
                                                    ParameterDirection.Input));
                                    cmdInsert.Parameters.Add(new OracleParameter("7",
                                                    OracleDbType.Varchar2,
                                                    insertValues[6],
                                                    ParameterDirection.Input));
                                    cmdInsert.Parameters.Add(new OracleParameter("8",
                                                    OracleDbType.Varchar2,
                                                    insertValues[7],
                                                    ParameterDirection.Input));
                                    cmdInsert.Parameters.Add(new OracleParameter("9",
                                                    OracleDbType.Varchar2,
                                                    insertValues[8],
                                                    ParameterDirection.Input));
                                }

                                cmdInsert.ExecuteNonQuery();
                                cmdInsert.Dispose();

                            }
                        }
                        catch (Oracle.DataAccess.Client.OracleException oe)
                        {
                            if (oe.ToString().Contains("ORA-00936"))
                            {
                                MessageBox.Show("Niektóre komórki nie mogą być puste! Uzupełnij!");
                            }
                            else if (oe.ToString().Contains("ORA-02291"))
                            {
                                MessageBox.Show("Błędny klucz obcy");
                            }
                            else if (oe.ToString().Contains("ORA-01438"))
                            {
                                MessageBox.Show("Jest już taki klucz główny");
                            }
                            else if (oe.ToString().Contains("ORA-12899"))
                            {
                                MessageBox.Show("Za dużo symboli w jednej z komórek");
                            }
                            else if (oe.ToString().Contains("ORA-02290"))
                            {
                                MessageBox.Show("Błędny format płci bądź statusu");
                            }
                            else
                            {
                                MessageBox.Show("Nie udało się dodać wiersza!");
                            }
                            return;
                        }

                        refreshGrid();
                        allRowsInDatabase = allRowsInDatabase + 1;
                        refreshGrid2();
                        MessageBox.Show("Poprawnie dodano wiersz!");
                        insertButton.Enabled = false;
                    }
                }
                else
                {
                    try
                    {
                        using (connection = new OracleConnection(connectionString))
                        {
                            connection.Open();
                            string chosenTable = tableComboBox.GetItemText(tableComboBox.SelectedItem);
                            if (chosenTable == "Bankomaty")
                            {
                                sqlInsert = "INSERT INTO " + chosenTable + " VALUES (:1, :2, :3, :4)";
                            }
                            if (chosenTable == "Aplikacje_mobilne")
                            {
                                sqlInsert = "INSERT INTO " + chosenTable + " VALUES (:1, :2, :3, :4)";
                            }
                            if (chosenTable == "Banki")
                            {
                                sqlInsert = "INSERT INTO " + chosenTable + " VALUES (:1, :2, :3, :4, :5, :6, :7, :8, :9)";
                            }
                            if (chosenTable == "Karty_kredytowe")
                            {
                                insertValues[6] = insertValues[6].Replace(",", ".");
                                insertValues[5] = insertValues[5].Replace(",", ".");
                                if (insertValues[6] == "")
                                {
                                    insertValues[6] = "null";
                                }
                                sqlInsert = "Insert into " + chosenTable + " VALUES(" + insertValues[0] + ",'" + insertValues[1] + "','" + insertValues[2] + "','" + insertValues[3] + "','" + insertValues[4] + "'," + insertValues[5]
                                                                + "," + insertValues[6] + ",'" + insertValues[7] + "')";
                            }
                            if (chosenTable == "Klienci")
                            {
                                insertValues[6] = insertValues[6].Replace(".", "-");
                                insertValues[6] = insertValues[6].Substring(0, 10);
                                insertValues[6] = insertValues[6].Substring(6, 4) + insertValues[6].Substring(2, 4) +
                                insertValues[6].Substring(0, 2);
                                sqlInsert = "Insert into " + chosenTable + " VALUES(null,'" + insertValues[1] + "','" + insertValues[2] + "','" + insertValues[3] + "','" + insertValues[4] + "','" + insertValues[5] + "', date '"
                                    + insertValues[6] + "','" + insertValues[7] + "','" + insertValues[8] + "','" + insertValues[9] + "','" + insertValues[10] + "','" + insertValues[11] + "','" + insertValues[12] + "'," + insertValues[13] + ")";

                            }
                            if (chosenTable == "Konta")
                            {
                                insertValues[2] = insertValues[2].Replace(",", ".");
                                sqlInsert = "Insert into " + chosenTable + " VALUES(" + insertValues[0] + "," + insertValues[1] + "," + insertValues[2] + ",'" + insertValues[3] + "','" + insertValues[4] + "','" + insertValues[5] + "')";
                            }
                            if ((chosenTable == "Korzystania") || (chosenTable == "Obslugi"))
                            {
                                insertValues[2] = insertValues[2].Replace(".", "-");
                                insertValues[2] = insertValues[2].Substring(0, 10);
                                insertValues[2] = insertValues[2].Substring(6, 4) + insertValues[2].Substring(2, 4) +
                                insertValues[2].Substring(0, 2);
                                sqlInsert = "Insert into " + chosenTable + " VALUES(" + insertValues[0] + "," + insertValues[1] + ", date '"
                                    + insertValues[2] + "')";
                            }
                            if (chosenTable == "Kredyty")
                            {
                                insertValues[1] = insertValues[1].Replace(",", ".");
                                insertValues[3] = insertValues[3].Replace(",", ".");
                                insertValues[4] = insertValues[4].Replace(".", "-");
                                insertValues[4] = insertValues[4].Substring(0, 10);
                                insertValues[4] = insertValues[4].Substring(6, 4) + insertValues[4].Substring(2, 4) +
                                insertValues[4].Substring(0, 2);

                                sqlInsert = "Insert into " + chosenTable + " VALUES(" + insertValues[0] + "," + insertValues[1] + ",'" + insertValues[2] + "'," + insertValues[3] + ", date '" + insertValues[4] + "')";
                            }
                            if (chosenTable == "Lokaty")
                            {
                                insertValues[1] = insertValues[1].Replace(",", ".");
                                insertValues[2] = insertValues[2].Replace(",", ".");
                                insertValues[3] = insertValues[3].Replace(".", "-");
                                insertValues[3] = insertValues[3].Substring(0, 10);
                                insertValues[3] = insertValues[3].Substring(6, 4) + insertValues[3].Substring(2, 4) +
                                insertValues[3].Substring(0, 2);

                                sqlInsert = "Insert into " + chosenTable + " VALUES(" + insertValues[0] + "," + insertValues[1] + "," + insertValues[2] + ", date '" + insertValues[3] + "','" + insertValues[4] + "')";
                            }
                            if (chosenTable == "Oddzialy_bankowe")
                            {

                                sqlInsert = "Insert into " + chosenTable + " VALUES(null,'" + insertValues[1] + "','" + insertValues[2] + "','" + insertValues[3] + "','" + insertValues[4] + "','" + insertValues[5]
                                    + "','" + insertValues[6] + "','" + insertValues[7] + "'," + insertValues[8] + ")";

                            }
                            if (chosenTable == "Pracownicy")
                            {
                                insertValues[5] = insertValues[5].Replace(".", "-");
                                insertValues[5] = insertValues[5].Substring(0, 10);
                                insertValues[5] = insertValues[5].Substring(6, 4) + insertValues[5].Substring(2, 4) +
                                insertValues[5].Substring(0, 2);
                                insertValues[12] = insertValues[12].Replace(".", "-");
                                insertValues[12] = insertValues[12].Substring(0, 10);
                                insertValues[12] = insertValues[12].Substring(6, 4) + insertValues[12].Substring(2, 4) +
                                insertValues[12].Substring(0, 2);

                                sqlInsert = "Insert into " + chosenTable + " VALUES(null,'" + insertValues[1] + "','" + insertValues[2] + "','" + insertValues[3] + "','" + insertValues[4] + "', date '" + insertValues[5]
                                    + "','" + insertValues[6] + "','" + insertValues[7] + "','" + insertValues[8] + "','" + insertValues[9] + "','" + insertValues[10] + "','" + insertValues[11] + "',date '" + insertValues[12] + "','" + insertValues[13] + "'," + insertValues[14] + "," + insertValues[15] + ")";
                            }
                            if (chosenTable == "Stanowiska")
                            {

                                sqlInsert = "Insert into " + chosenTable + " VALUES(null,'" + insertValues[1] + "','" + insertValues[2] + "')";

                            }
                            if (chosenTable == "Urzadzenia_terenowe")
                            {
                                insertValues[4] = insertValues[4].Replace(",", ".");
                                sqlInsert = "Insert into " + chosenTable + " VALUES(null,'" + insertValues[1] + "','" + insertValues[2] + "','" + insertValues[3] + "'," + insertValues[4] + ",'" + insertValues[5]
                                   + "','" + insertValues[6] + "'," + insertValues[7] + ")";
                            }
                            if (chosenTable == "Uslugi")
                            {
                                insertValues[2] = insertValues[2].Replace(".", "-");
                                insertValues[2] = insertValues[2].Substring(0, 10);
                                insertValues[2] = insertValues[2].Substring(6, 4) + insertValues[2].Substring(2, 4) +
                                insertValues[2].Substring(0, 2);
                                sqlInsert = "Insert into " + chosenTable + " VALUES(null,'" + insertValues[1] + "', date '" + insertValues[2] + "'," + insertValues[3] + ")";
                            }
                            if (chosenTable == "Wplatomaty")
                            {
                                insertValues[1] = insertValues[1].Replace(",", ".");
                                insertValues[2] = insertValues[2].Replace(",", ".");
                                sqlInsert = "Insert into " + chosenTable + " VALUES(" + insertValues[0] + "," + insertValues[1] + "," + insertValues[2] + ")";

                            }
                            if (chosenTable == "Wynagrodzenia")
                            {
                                Console.WriteLine(insertValues[3]);
                                insertValues[1] = insertValues[1].Replace(",", ".");
                                insertValues[3] = insertValues[3].Replace(",", ".");
                                if (insertValues[3] == "")
                                {
                                    insertValues[3] = "null";
                                }
                                insertValues[2] = insertValues[2].Replace(".", "-");
                                insertValues[2] = insertValues[2].Substring(0, 10);
                                insertValues[2] = insertValues[2].Substring(6, 4) + insertValues[2].Substring(2, 4) +
                                insertValues[2].Substring(0, 2);

                                sqlInsert = "Insert into " + chosenTable + " VALUES(null," + insertValues[1] + ", date '" + insertValues[2] + "'," + insertValues[3] + "," + insertValues[4] + ")";
                            }

                            Console.WriteLine(sqlInsert);
                            OracleCommand cmdInsert = new OracleCommand();
                            cmdInsert.Connection = connection;
                            cmdInsert.CommandText = sqlInsert;

                            if (chosenTable == "Bankomaty")
                            {

                                cmdInsert.Parameters.Add(new OracleParameter("1",
                                           OracleDbType.Int32,
                                           insertValues[0],
                                           ParameterDirection.Input));
                                cmdInsert.Parameters.Add(new OracleParameter("2",
                                               OracleDbType.Varchar2,
                                               insertValues[1],
                                               ParameterDirection.Input));
                                cmdInsert.Parameters.Add(new OracleParameter("3",
                                                OracleDbType.Varchar2,
                                                insertValues[2],
                                                ParameterDirection.Input));
                                cmdInsert.Parameters.Add(new OracleParameter("4",
                                                OracleDbType.Int32,
                                                insertValues[3],
                                                ParameterDirection.Input));
                            }
                            if (chosenTable == "Aplikacje_mobilne")
                            {
                                cmdInsert.Parameters.Add(new OracleParameter("1",
                                           OracleDbType.Int32,
                                           insertValues[0],
                                           ParameterDirection.Input));
                                cmdInsert.Parameters.Add(new OracleParameter("2",
                                               OracleDbType.Char,
                                               insertValues[1],
                                               ParameterDirection.Input));
                                cmdInsert.Parameters.Add(new OracleParameter("3",
                                                OracleDbType.Char,
                                                insertValues[2],
                                                ParameterDirection.Input));
                                cmdInsert.Parameters.Add(new OracleParameter("4",
                                                OracleDbType.Char,
                                                insertValues[3],
                                                ParameterDirection.Input));
                            }
                            if (chosenTable == "Banki")
                            {
                                cmdInsert.Parameters.Add(new OracleParameter("1",
                                           OracleDbType.Varchar2,
                                           insertValues[0],
                                           ParameterDirection.Input));
                                cmdInsert.Parameters.Add(new OracleParameter("2",
                                               OracleDbType.Varchar2,
                                               insertValues[1],
                                               ParameterDirection.Input));
                                cmdInsert.Parameters.Add(new OracleParameter("3",
                                                OracleDbType.Varchar2,
                                                insertValues[2],
                                                ParameterDirection.Input));
                                cmdInsert.Parameters.Add(new OracleParameter("4",
                                                OracleDbType.Varchar2,
                                                insertValues[3],
                                                ParameterDirection.Input));
                                cmdInsert.Parameters.Add(new OracleParameter("5",
                                                OracleDbType.Varchar2,
                                                insertValues[4],
                                                ParameterDirection.Input));
                                cmdInsert.Parameters.Add(new OracleParameter("6",
                                                OracleDbType.Char,
                                                insertValues[5],
                                                ParameterDirection.Input));
                                cmdInsert.Parameters.Add(new OracleParameter("7",
                                                OracleDbType.Varchar2,
                                                insertValues[6],
                                                ParameterDirection.Input));
                                cmdInsert.Parameters.Add(new OracleParameter("8",
                                                OracleDbType.Varchar2,
                                                insertValues[7],
                                                ParameterDirection.Input));
                                cmdInsert.Parameters.Add(new OracleParameter("9",
                                                OracleDbType.Varchar2,
                                                insertValues[8],
                                                ParameterDirection.Input));
                            }

                            cmdInsert.ExecuteNonQuery();
                            cmdInsert.Dispose();

                        }
                    }
                    catch (Oracle.DataAccess.Client.OracleException oe)
                    {
                        if (oe.ToString().Contains("ORA-00936"))
                        {
                            MessageBox.Show("Niektóre komórki nie mogą być puste! Uzupełnij!");
                        }
                        else if (oe.ToString().Contains("ORA-02291"))
                        {
                            MessageBox.Show("Błędny klucz obcy");
                        }
                        else if (oe.ToString().Contains("ORA-01438"))
                        {
                            MessageBox.Show("Jest już taki klucz główny");
                        }
                        else if (oe.ToString().Contains("ORA-12899"))
                        {
                            MessageBox.Show("Za dużo symboli w jednej z komórek");
                        }
                        else if (oe.ToString().Contains("ORA-02290"))
                        {
                            MessageBox.Show("Błędny format płci bądź statusu");
                        }
                        else
                        {
                            MessageBox.Show("Nie udało się dodać wiersza");
                        }
                        return;
                    }

                    refreshGrid();
                    allRowsInDatabase = allRowsInDatabase + 1;
                    refreshGrid2();
                    MessageBox.Show("Poprawnie dodano wiersz!");
                    insertButton.Enabled = false;
                }
            }
        }

        private void queryButton_Click(object sender, EventArgs e)
        {
            dataView.AllowUserToAddRows = true;
            if (queryComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Wybierz typ zapytania");
            }
            else 
            {
                dataTable = new DataTable();
                dataView.DataSource = dataTable;
                buttonsEnablement = false;
                insertButton.Enabled = false;
                deleteButton.Enabled = false;
                updateButton.Enabled = false;
                string chosenQueryType = queryComboBox.GetItemText(queryComboBox.SelectedItem);
                string query = queryTextBox.Text;
                string querySecure = query;
                if (query.Length <6)
                {

                    if (query=="")
                    {
                        MessageBox.Show("Wpisz zapytanie!");
                        return;
                    }

                    MessageBox.Show("Zapytanie musi być dłuższe!");
                    return;
                }
                else
                {
                    if (query.EndsWith(";"))
                    {
                        query = query.Substring(0, query.Length - 1);
                    }

                    querySecure = querySecure.Replace(" ", "");
                }
                    
                if (chosenQueryType == "Select" && querySecure.Substring(0, 6).ToLower() == "select")
                {
                    try
                    {
                        using (connection = new OracleConnection(connectionString))
                        {
                            dataAdapter = new OracleDataAdapter(query, connection);
                            dataTable = new DataTable();
                            dataAdapter.Fill(dataTable);
                            dataView.DataSource = dataTable;
                        }

                        refreshGrid();
                        allRowsInDatabase = dataView.Rows.Count - 1;
                    }
                    catch (Oracle.DataAccess.Client.OracleException oe)
                    {
                        MessageBox.Show("Błędne zapytanie");
                        return;
                    }


                    foreach (DataGridViewColumn column in dataView.Columns)
                    {
                        column.SortMode = DataGridViewColumnSortMode.NotSortable;
                    }

                    firstColumnsValues.Clear();
                    for (int i = 0; i < dataView.Rows.Count - 1; i++)
                    {
                        firstColumnsValues.Add(dataView.Rows[i].Cells[0].Value.ToString());
                        Console.WriteLine(firstColumnsValues[i]);
                    }

                    if (query.Contains(" "))
                    {
                        queryEdited = query.Replace(" ", "");
                        queryEdited = queryEdited.Substring(0, 11);
                        queryEdited = queryEdited.ToLower();
                    }
                    if (queryEdited == "select*from")
                    {
                        if (query.Contains(" "))
                        {
                            queryEdited = query.Split(' ')[3];
                            queryEdited = queryEdited.ToLower();
                            queryEdited = char.ToUpper(queryEdited[0]) + queryEdited.Substring(1);
                            tableComboBox.SelectedIndex = tableComboBox.Items.IndexOf(queryEdited);
                            chosenTable = tableComboBox.GetItemText(tableComboBox.SelectedItem);
                        }
                        buttonsEnablement = true;
                        updatedRowsIndexes.Clear();
                        updatedRowsValues.Clear();
                    }
                    else
                    {
                        dataView.AllowUserToAddRows = false;
                    }
                }
                else if ((chosenQueryType == "Insert" && querySecure.Substring(0,6).ToLower()=="insert") || (chosenQueryType =="Delete" && querySecure.Substring(0, 6).ToLower() == "delete"))
                {
                    try
                    {
                        using (connection = new OracleConnection(connectionString))
                        {
                            
                            OracleCommand cmdInsert = new OracleCommand();
                            connection.Open();
                            cmdInsert.Connection = connection;
                            cmdInsert.CommandText = query;
                            cmdInsert.CommandType = CommandType.Text;
                            cmdInsert.ExecuteNonQuery();
                            cmdInsert.Dispose();
                            
                        }
                        if (chosenQueryType == "Insert")
                        {
                            MessageBox.Show("Poprawnie dodano wiersz!");
                        }
                        else
                        {
                            MessageBox.Show("Poprawnie usunieto wiersz!");
                        }

                    }
                    catch (Oracle.DataAccess.Client.OracleException ence)
                    {                                        
                        MessageBox.Show("Błędne zapytanie");                                            
                        return;
                    }                    
                }
                else if (chosenQueryType == "Update" && querySecure.Substring(0, 6).ToLower() == "update")
                {
                    try
                    {
                        using (connection = new OracleConnection(connectionString))
                        {

                            OracleCommand cmdUpdate = new OracleCommand();
                            connection.Open();
                            cmdUpdate.Connection = connection;
                            cmdUpdate.CommandText = query;
                            cmdUpdate.CommandType = CommandType.Text;
                            cmdUpdate.ExecuteNonQuery();
                            cmdUpdate.Dispose();

                        }                                             
                        MessageBox.Show("Poprawnie uaktualniono wiersz!");                                               
                    }
                    catch (Oracle.DataAccess.Client.OracleException oe)
                    {
                        MessageBox.Show("Błędne zapytanie!");
                        return;
                    }
                }
                else if (chosenQueryType == "Inne" && querySecure.Substring(0, 6).ToLower() != "update" && querySecure.Substring(0, 6).ToLower() != "insert" && querySecure.Substring(0, 6).ToLower() != "select" && querySecure.Substring(0, 6).ToLower() != "delete") 
                {
                    try
                    {
                        using (connection = new OracleConnection(connectionString))
                        {

                            OracleCommand cmdUpdate = new OracleCommand();
                            connection.Open();
                            cmdUpdate.Connection = connection;
                            cmdUpdate.CommandText = query;
                            cmdUpdate.CommandType = CommandType.Text;
                            cmdUpdate.ExecuteNonQuery();
                            cmdUpdate.Dispose();

                        }
                        MessageBox.Show("Wysłano zapytanie do bazy");
                    }
                    catch (Oracle.DataAccess.Client.OracleException oe)
                    {
                        MessageBox.Show("Błędne zapytanie!");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Typ zapytania nie zgadza się z zapytaniem, bądź zapytanie jest błędne");
                    return;
                }
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (connection = new OracleConnection(connectionString))
                {
                    connection.Open();

                    string firstColumnName = dataView.Columns[0].HeaderText;

                    if ((chosenTable == "Obslugi") || (chosenTable == "Korzystania"))
                    {
                        MessageBox.Show("Nie ma uaktualniania dla tej relacji :(");
                    }
                    else
                    {
                        sqlUpdate = "Update " + chosenTable + " Set ";
                        foreach (string s in updatedRowsValues)
                        {
                            if (s.Split(' ')[0] == currentRow.Index.ToString())
                            {
                                int columnIndex = Convert.ToInt32(s.Split(' ')[1]);
                                Console.WriteLine(dataView.Columns[columnIndex].ValueType.ToString());
                                if (dataView.Columns[columnIndex].ValueType.ToString() == "System.String")
                                {
                                    sqlUpdate = sqlUpdate + s.Split(' ')[2] + " = '" + dataView.Rows[currentRow.Index].Cells[columnIndex].Value.ToString() + "',";
                                }
                                else if (dataView.Columns[columnIndex].ValueType.ToString() == "System.Decimal")
                                {
                                    sqlUpdate = sqlUpdate + s.Split(' ')[2] + " = " + dataView.Rows[currentRow.Index].Cells[columnIndex].Value.ToString() + ",";
                                }
                                else if (dataView.Columns[columnIndex].ValueType.ToString() == "System.Double")
                                {
                                    string value = dataView.Rows[currentRow.Index].Cells[columnIndex].Value.ToString();
                                    if (value.Contains(",")) 
                                    {
                                        value = value.Replace(",", ".");
                                    }
                                    sqlUpdate = sqlUpdate + s.Split(' ')[2] + " = " + value + ",";
                                }
                                else if (dataView.Columns[columnIndex].ValueType.ToString() == "System.DateTime")
                                {
                                    string value = dataView.Rows[currentRow.Index].Cells[columnIndex].Value.ToString();
                                    value = value.Replace(".", "-");
                                    value = value.Substring(0, 10);
                                    value = value.Substring(6, 4) + value.Substring(2, 4) +
                                    value.Substring(0, 2);
                                    sqlUpdate = sqlUpdate + s.Split(' ')[2] + " = date '" + value + "',";
                                }
                            }
                        }
                        sqlUpdate = sqlUpdate.Substring(0, sqlUpdate.Length - 1);
                        sqlUpdate = sqlUpdate + " WHERE " + firstColumnName + "=" + firstColumnsValues[currentRow.Index];
                        Console.WriteLine(sqlUpdate);
                    }

                    OracleCommand cmdUpdate = new OracleCommand();
                    cmdUpdate.Connection = connection;
                    cmdUpdate.CommandText = sqlUpdate;
                    cmdUpdate.CommandType = CommandType.Text;
                    cmdUpdate.ExecuteNonQuery();
                    cmdUpdate.Dispose();

                }
            }
            catch (Oracle.DataAccess.Client.OracleException oe)
            {
                if (oe.ToString().Contains("ORA-00936"))
                {
                    MessageBox.Show("Niektóre komórki nie mogą być puste! Uzupełnij!");
                }
                else if (oe.ToString().Contains("ORA-02291"))
                {
                    MessageBox.Show("Błędny klucz obcy");
                }
                else if (oe.ToString().Contains("ORA-01438"))
                {
                    MessageBox.Show("Jest już taki klucz główny");
                }
                else if (oe.ToString().Contains("ORA-12899"))
                {
                    MessageBox.Show("Za dużo symboli w jednej z komórek");
                }
                else if (oe.ToString().Contains("ORA-02290"))
                {
                    MessageBox.Show("Błędny format płci bądź statusu");
                }
                else
                {
                    MessageBox.Show("Nie udało się zaaktualizować!");
                }

                return;
            }

            refreshGrid();
            refreshGrid2();
            updateButton.Enabled = false;
            MessageBox.Show("Poprawnie uaktualniono wiersz!");


        }
    }
    
}
