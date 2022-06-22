//Christian Lara
//000983220
//3/16/2020
//3/16/2020
/*This program uses a local database to store information about employees. The program uses a datasource view to add, delete or update records.
 The program also uses SQL querys to get spesific data from the employees table in the database.*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3343_LaraC_Lab03
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void employeeBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.employeeBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.personnelDataSet);

        }

        private void Main_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'personnelDataSet.Employee' table. You can move, or remove it, as needed.
            this.employeeTableAdapter.Fill(this.personnelDataSet.Employee);

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void showDetailsButton_Click(object sender, EventArgs e)
        {
            PersonnelDetails newPersonnelDetails = new PersonnelDetails();
            newPersonnelDetails.ShowDialog();
            this.employeeTableAdapter.Fill(this.personnelDataSet.Employee);
        }

        private void sortPayRateAcendingButton_Click(object sender, EventArgs e)
        {
            this.employeeTableAdapter.OrderByHourlyPayRateAsc(this.personnelDataSet.Employee);
        }

        private void sortPayRateDecending_Click(object sender, EventArgs e)
        {
            this.employeeTableAdapter.OrderByHourlyPayRateDesc(this.personnelDataSet.Employee);
        }

        private void maxPayRateButton_Click(object sender, EventArgs e)
        {
            decimal maxPay;

            maxPay = (decimal) this.employeeTableAdapter.MaxHourlyPayRate();

            MessageBox.Show("Maximum Hourly Pay Rate is: " + maxPay.ToString("c2"));
        }

        private void minPayRateButton_Click(object sender, EventArgs e)
        {
            decimal minPay;

            minPay = (decimal)this.employeeTableAdapter.MinHourlyPayRate();

            MessageBox.Show("Minimum Hourly Pay Rate is: " + minPay.ToString("c2"));
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            this.employeeTableAdapter.Fill(this.personnelDataSet.Employee);
        }

        private void searchNameButton_Click(object sender, EventArgs e)
        {
            if(searchNameTextBox.Text != "")
            {
                this.employeeTableAdapter.SearchName(this.personnelDataSet.Employee, searchNameTextBox.Text);
                searchNameTextBox.Clear();
            }
            else
            {
                MessageBox.Show("Name cannot be blank. Please reenter.");
                searchNameTextBox.Focus();
            }
            
        }
    }
}
