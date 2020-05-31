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

    public partial class Form8 : Form
    {
        public bool answer = false;
        public string birthDate;
        public string name;
        public string surname;
        public int oddzialID = 0;
        public string jobTitle;
        public int employeeID = 0;
        public string numberPESEL;
        public Form8()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(181, 211, 231);
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {

            birthDate = textBox5.Text;
            name = textBox2.Text;
            surname = textBox3.Text;
            numberPESEL = textBox4.Text;
            jobTitle = textBox7.Text;

            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                try
                {
                    employeeID = Convert.ToInt32(textBox1.Text);
                }
                catch (System.FormatException fe)
                {
                    employeeID = 0;
                    MessageBox.Show("Zły format numeru pracownika");
                    return;
                }
            }
            if (!string.IsNullOrWhiteSpace(textBox6.Text))
            {

                try
                {
                    oddzialID = Convert.ToInt32(textBox6.Text);
                }
                catch (System.FormatException fe)
                {
                    oddzialID = 0;
                    MessageBox.Show("Zły format numeru oddziału");
                    return;
                }
            }

            if (!(birthDate == "")) 
            { 
                if (birthDate[4] != '-' || birthDate.Length != 10)
                {
                     MessageBox.Show("Zły format daty");
                     return;
                } 
            }
            if (!(numberPESEL == ""))
            {
                if (numberPESEL.Length >= 11)
                {
                    MessageBox.Show("Zły format numeru PESEL");
                    return;
                }
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
