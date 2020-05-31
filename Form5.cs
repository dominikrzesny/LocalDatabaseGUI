using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form5 : Form
    {
        public bool answer = false;
        public string month;
        public int year;
        public int employeeID;

        public Form5(int employeeID)
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(181, 211, 231);
            comboBox1.Items.Add("01");
            comboBox1.Items.Add("02");
            comboBox1.Items.Add("03");
            comboBox1.Items.Add("04");
            comboBox1.Items.Add("05");
            comboBox1.Items.Add("06");
            comboBox1.Items.Add("07");
            comboBox1.Items.Add("08");
            comboBox1.Items.Add("09");
            comboBox1.Items.Add("10");
            comboBox1.Items.Add("11");
            comboBox1.Items.Add("12");
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            this.employeeID = employeeID;
            textBox1.Text = employeeID.ToString();
            textBox1.ReadOnly = true;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            answer = false;
            this.Close();
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            month = comboBox1.GetItemText(comboBox1.SelectedItem);

            try
            {
                year = Convert.ToInt32(textBox3.Text);               
            }
            catch (System.FormatException fe)
            {
                MessageBox.Show("Wpisz dane o poprawnym formacie");
                return;
            }

            if (!(year.ToString().Length == 4))
            {
                MessageBox.Show("Wpisz pełny rok, składający sie z 4 cyfr");
                return;
            }

            if (month == "" || year == 0)
            {
                MessageBox.Show("Uzupełnij wszystkie dane");
                return;
            }

            answer = true;
            this.Close();
        }
    }
    
}
