using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using Oracle.DataAccess.Client;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public String connectionString = "DATA SOURCE = (DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)" +
                    "(HOST = LOCALHOST)(PORT = 1521))(CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME = ORCL)));" +
                    "User Id = domino; password=Domino123";
        public OracleConnection connection = new OracleConnection();
        public OracleDataAdapter dataAdapter;
        DataTable dataTable;
        public string query;
        public bool addSalaryAllow;
        public bool showEmployeeSalaryAllow;
        public int employeeID;



        public Form2(string theText)
        {

            InitializeComponent();
            this.BackgroundImage = Properties.Resources.gui2;
            connection.ConnectionString = connectionString;
            connection.Open();
            try
            {
                userPicture.ImageLocation = @"C:\Users\Chąśno\source\repos\WindowsFormsApp1\user.png";
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
            addSalaryButton.Enabled = false;
            ShowEmployeeSalary.Enabled = false;

        }

        private void logoutPicture_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Zostałeś Wylogowany!");
            this.Close();
        }

        private void showEmployeesButton_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.ShowDialog();

            if (form4.answer)
            {
                dataView.AllowUserToAddRows = false;
                dataView.ReadOnly = true;
                addSalaryButton.Enabled = false;
                ShowEmployeeSalary.Enabled = false;

                if (form4.getID() != 0)
                {
                    query = "Select * from Pracownicy WHERE Nr_Oddzialu=" + form4.OddzialID;

                }
                else
                {
                    if (form4.bankTown != "")
                    {
                        query = "Select * from Pracownicy WHERE Nr_Oddzialu=(Select nr_oddzialu from Oddzialy_bankowe WHERE Miasto = '" + form4.bankTown + "' AND Ulica = '" + form4.bankStreet + "')";
                    }
                }
                Console.WriteLine(query);
                try
                {
                    using (connection = new OracleConnection(connectionString))
                    {
                        dataAdapter = new OracleDataAdapter(query, connection);
                        dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);
                        dataView.DataSource = dataTable;

                    }
                }
                catch (Oracle.DataAccess.Client.OracleException oe)
                {
                    MessageBox.Show("Nie ma takiego oddziału, dane się nie zgadzają");
                    return;
                }
            }
        }

        private void ShowEmployeeSalary_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5(employeeID);
            form5.ShowDialog();

            if (form5.answer)
            {
                dataView.AllowUserToAddRows = false;
                dataView.ReadOnly = true;
                addSalaryButton.Enabled = false;
                ShowEmployeeSalary.Enabled = false;

                

                query = "Select Pensja_brutto,Bonusy From Wynagrodzenia WHERE nr_pracownika=" + form5.employeeID + " AND to_char(Data,'MM')=" + form5.month + "AND to_char(Data,'YYYY')=" + form5.year;
                Console.WriteLine(query);
                try
                {
                    using (connection = new OracleConnection(connectionString))
                    {
                        dataAdapter = new OracleDataAdapter(query, connection);
                        dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);
                        dataView.DataSource = dataTable;

                    }
                }
                catch (Oracle.DataAccess.Client.OracleException oe)
                {
                    MessageBox.Show("Nie ma takiego pracownika, dane się nie zgadzają");
                    return;
                }
            }

        }

        private void addSalaryButton_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6(employeeID);
            form6.ShowDialog();

            if (form6.answer)
            {

                query = "Insert Into Wynagrodzenia VALUES(null," + form6.salary + ",date '" + form6.date + "'," + form6.bonuses + "," + form6.employeeID + ")";
                Console.WriteLine(query);
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
                }
                catch (Oracle.DataAccess.Client.OracleException oe)
                {
                    MessageBox.Show("Nie udało się dodać wynagrodzenia");
                    return;
                }
                MessageBox.Show("Poprawnie dodano wynagrodzenie");
            }
        }

        private void countMonthlySalaryButton_Click(object sender, EventArgs e)
        {
            Form7 form7 = new Form7();
            form7.ShowDialog();

            if (form7.answer)
            {
                dataView.AllowUserToAddRows = false;
                dataView.ReadOnly = true;
                addSalaryButton.Enabled = false;
                ShowEmployeeSalary.Enabled = false;

                query = "Select SUM(pensja_brutto+Bonusy) as SUMA_Wynagrodzen from Wynagrodzenia where data>date '" + form7.date1 + "' AND data< date '" + form7.date2 + "' AND nr_pracownika IN(Select nr_pracownika from Pracownicy WHERE nr_oddzialu=" + form7.oddzialID + ")";
                Console.WriteLine(query);
                try
                {
                    using (connection = new OracleConnection(connectionString))
                    {
                        dataAdapter = new OracleDataAdapter(query, connection);
                        dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);
                        dataView.DataSource = dataTable;

                    }
                }
                catch (Oracle.DataAccess.Client.OracleException oe)
                {
                    MessageBox.Show("Nie udało się podliczyć sumy, błędne dane");
                    return;
                }
            }
        }

        private void searchEmployeeButton_Click(object sender, EventArgs e)
        {
            Form8 form8 = new Form8();
            form8.ShowDialog();

            if (form8.answer)
            {
                dataView.AllowUserToAddRows = false;
                dataView.ReadOnly = true;
                addSalaryButton.Enabled = false;
                ShowEmployeeSalary.Enabled = false;

                query = "SELECT * from Pracownicy WHERE ";
                if (form8.employeeID != 0)
                {
                    query = query + "nr_pracownika=" + form8.employeeID + " AND ";
                }
                if(form8.oddzialID != 0)
                {
                    query = query + "nr_oddzialu=" + form8.oddzialID + " AND ";
                }
                if (form8.name != "")
                {
                    query = query + "Imie='" + form8.name + "' AND ";
                }
                if (form8.surname != "")
                {
                    query = query + "Nazwisko='" + form8.surname + "' AND ";
                }
                if (form8.numberPESEL != "")
                {
                    query = query + "PESEL='" + form8.numberPESEL + "' AND ";
                }
                if (form8.birthDate != "")
                {
                    query = query + "Data_urodzenia=date '" + form8.birthDate + "' AND ";
                }
                if (form8.jobTitle != "")
                {
                    query = query + "Nr_stanowiska=(SELECT nr_stanowiska from Stanowiska WHERE Nazwa='" + form8.jobTitle + "') AND ";
                }              
               
                query = query.Substring(0, query.Length-5);
                if(form8.employeeID == 0 && form8.oddzialID == 0 && form8.name == "" && form8.surname == "" && form8.numberPESEL == "" && form8.birthDate == "" && form8.jobTitle == "")
                {
                    query = "SELECT * from Pracownicy";
                }


                Console.WriteLine(query);
                try
                {
                    using (connection = new OracleConnection(connectionString))
                    {
                        dataAdapter = new OracleDataAdapter(query, connection);
                        dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);
                        dataView.DataSource = dataTable;

                    }
                }
                catch (Oracle.DataAccess.Client.OracleException oe)
                {
                    MessageBox.Show("Nie udało sie znależć takiego pracownika");
                    return;
                }
            }
        }

        private void dataView_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataView.Columns.Contains("Nr_pracownika") && dataView.Columns["Nr_pracownika"].Visible)
            {
                addSalaryButton.Enabled = true;
                ShowEmployeeSalary.Enabled = true;
                addSalaryAllow = true;
                showEmployeeSalaryAllow = true;
                employeeID = Convert.ToInt32(dataView.SelectedRows[0].Cells["Nr_pracownika"].Value);
                Console.WriteLine(employeeID);
            }

        }
    }
}
