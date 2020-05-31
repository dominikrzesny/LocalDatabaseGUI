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
    public partial class Form7 : Form
    {

        public bool answer = false;
        public string date1;
        public string date2;
        public int oddzialID;
        public Form7()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(181, 211, 231);
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {

            date1 = dateTimePicker1.Text;
            date2 = dateTimePicker2.Text;

            date1 = date1.Replace(".", "-");
            date1 = date1.Substring(0, 10);
            date1 = date1.Substring(6, 4) + date1.Substring(2, 4) +
            date1.Substring(0, 2);

            date2 = date2.Replace(".", "-");
            date2 = date2.Substring(0, 10);
            date2 = date2.Substring(6, 4) + date2.Substring(2, 4) +
            date2.Substring(0, 2);

            try
            {
                oddzialID = Convert.ToInt32(textBox1.Text);
            }
            catch (System.FormatException fe)
            {
                MessageBox.Show("Wpisz dane o poprawnym formacie");
                return;
            }

            answer = true;
            this.Close();

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            answer = false;
            this.Close();
        }
    }
}
