using System;
using System.Windows.Forms;
using Oracle.DataAccess.Client;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.BackgroundImage = Properties.Resources.gui;
        }

        private void logIn(object sender, EventArgs e)
        {
            //OracleConnection con = new OracleConnection();
            string theText = loginBox.Text;
            string theText2 = passwordBox.Text;
            if (theText == "admin" && theText2 == "admin")
            {
                try
                {
                    Form3 form3 = new Form3(theText);
                    form3.ShowDialog();
                }
                catch(System.ObjectDisposedException ode)
                {
                    MessageBox.Show("Nie udało się połączyć z lokalną bazą danych");
                    return;
                }
            }
            else if (theText == "user" && theText2 == "user")
            {
                Form2 form2 = new Form2(theText);
                form2.ShowDialog();
            }
            else
            {
                MessageBox.Show("Błędny login lub hasło. Spróbuj ponownie", "Niepoprawne logowanie");
            }                   
        }

    }
}
