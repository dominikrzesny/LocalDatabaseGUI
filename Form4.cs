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
    public partial class Form4 : Form
    {
        public string bankTown;
        public string bankStreet;
        public int OddzialID = 0;
        public bool answer = false;
        public Form4()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(181, 211, 231);
        }

        public int getID()
        {
            return OddzialID;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            answer = false;
            this.Close();
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            bankTown = textBox1.Text;
            bankStreet = textBox2.Text;
            try
            {
                OddzialID = Convert.ToInt32(textBox3.Text);
            }
            catch(System.FormatException fe)
            {
                MessageBox.Show("Wpisz dane o poprawnym formacie");
                return;
            }

            if (OddzialID == 0 && (bankStreet=="" || bankTown==""))
            {
                MessageBox.Show("Uzupełnij ID lub Miasto i Ulice oddziału");
                return;
            }
            
            answer = true;
            this.Close();
        }

    }
}
