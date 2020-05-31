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
    public partial class Form6 : Form
    {
        public bool answer = false;
        public string date;
        public string bonuses;
        public string salary;
        public float x;
        public float y;
        public int employeeID;

        public Form6(int employeeID)
        {
            this.employeeID = employeeID;
            InitializeComponent();
            this.BackColor = Color.FromArgb(181, 211, 231);
            textBox4.Text = employeeID.ToString();
            textBox4.ReadOnly = true;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {                       
                answer = false;
                this.Close();           
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            date = textBox3.Text;
            bonuses = textBox2.Text;
            salary = textBox1.Text;


            if ( date == "" || salary == "")
            {
                MessageBox.Show("Data i pensja nie mogą byc puste");
                return;
            }
            if (date.Length<=4)
            {
                MessageBox.Show("Za krótki format daty");
                return;
            }
            else
            {
                if (date[4] != '-' || date.Length != 10)
                {

                    MessageBox.Show("Zły format daty");
                    return;
                }
            }

            if (bonuses == "")
            {
                bonuses = "null";
            }
            else
            {
                bonuses = bonuses.Replace(",", ".");
            }

            if (salary.Contains(","))
            {
                salary = salary.Replace(",", ".");
            }

            answer = true;
            this.Close();
        }
    }
}
