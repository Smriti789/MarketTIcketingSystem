using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MarketTIcketingSystem.DataAccess;

namespace MarketTIcketingSystem.User_Interface
{
    public partial class EmployeeListForm : Form
    {
        public EmployeeListForm()
        {
            InitializeComponent();
        }
        public string EmployeeName = string.Empty;
        public string UserName = string.Empty;
        public string Email = string.Empty;
        public string Password = string.Empty;
        public string RoleId = string.Empty;
        public string PasswordSalt = string.Empty;
        public bool IsApproved = false;
        public bool IsLockedOut = false;
        public string CreateDate = string.Empty;
        public bool IsActive = false;
        public bool SystemGenerate = false;
        public string Contact = string.Empty;

        private void EmployeeListForm_Load(object sender, EventArgs e)
        {
            EmployeeDataLogic employeeDataLogic = new EmployeeDataLogic();
            DataTable dataTable = new DataTable();
            dataTable = employeeDataLogic.GetEmployeeList();
            DataGridViewEmployee.DataSource = dataTable;
            this.ControlBox = false;
        }

        private void buttonBackEmployee_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonAddEmployee_Click(object sender, EventArgs e)
        {
            EmployeeAddForm employeeaddform = new EmployeeAddForm();
            this.Hide();
            employeeaddform.Show();
        }
           

        private void DataGridViewEmployee_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            int employeeId = int.Parse(DataGridViewEmployee.Rows[rowIndex].Cells[0].Value.ToString());
            EmployeeDataLogic employeeDataLogic = new EmployeeDataLogic();          
            bool result = employeeDataLogic.GetEmployeeInfo(employeeId, out EmployeeName, out UserName, out Email, out IsActive, out SystemGenerate, out RoleId, out PasswordSalt, out IsApproved, out CreateDate, out IsLockedOut, out Contact, out Password);
            if (result == true)
            {
                EmployeeAddForm employeeAddForm = new EmployeeAddForm()
                {
                    MdiParent = this.Parent.FindForm()
                };
                projectAddForm.projectName = projectName;
                projectAddForm.projectDescription = projectDescription;
                projectAddForm.isActive = isActive;
                projectAddForm.isSystemGenerated = isSystemGenerated;
                projectAddForm.projectId = projectId;
                this.Hide();
                projectAddForm.Show();
            }
            else
            {

                MessageBox.Show("No Valid Information Found!", "Error!");
            }
        }
    }
}
