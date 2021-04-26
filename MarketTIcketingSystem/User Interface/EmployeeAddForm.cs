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
using MarketTIcketingSystem.Helper;

namespace MarketTIcketingSystem.User_Interface
{
    public partial class EmployeeAddForm : Form
    {
        public EmployeeAddForm()
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
        public int EmployeeId;

        private void EmployeeAddForm_Load(object sender, EventArgs e)
        {

            
            
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            

        }

        private void buttonSav_Click(object sender, EventArgs e)
        {
            EmployeeDataLogic employeeDataLogic = new EmployeeDataLogic();
            EmployeeName = textBoxName.Text.Trim();
            Contact = textBoxCont.Text.Trim();
            Email = textBoxGmail.Text.Trim();
            RoleId = textBoxID.Text.Trim();
            UserName = textBoxUsernam.Text.Trim();
            Password = textBoxPass.Text.Trim();
            PasswordSalt = textBoxPassSalt.Text.Trim();
            CreateDate = textBoxCreateDate.Text.Trim();
            string isactive = comboBoxActive.SelectedValue.ToString();
            IsActive = isactive == "0" ? false : true;
            string approval = comboBoxApprove.SelectedValue.ToString();
            IsApproved = approval == "0" ? false : true;
            string isLockedOut = comboBoxLocked.SelectedValue.ToString();
            IsLockedOut = isLockedOut == "0" ? false : true;
            bool result = employeeDataLogic.AddEmployee(EmployeeName, Contact, Email, RoleId, IsActive, UserName, Password, PasswordSalt, CreateDate, IsApproved, IsLockedOut, SystemGenerate);
            if (result == true)
            {
                MessageBox.Show("Success!");
                EmployeeListForm employeeListForm = new EmployeeListForm();
                this.Hide();
                employeeListForm.Show();
            }
            else
            {
                MessageBox.Show("Error!");
            }
        }

        private void EmployeeAddForm_Load_1(object sender, EventArgs e)
        {
            List<Isactive> isactive = new List<Isactive>();
            isactive.Add(new Isactive()
            {
                Value = 1,
                Text = "Is Active"
            });
            isactive.Add(new Isactive()
            {
                Value = 0,
                Text = "Not Active"
            });
            comboBoxActive.DataSource = isactive;
            comboBoxActive.DisplayMember = "Text";
            comboBoxActive.ValueMember = "Value";

            List<IsLockedOut> isLockedOut = new List<IsLockedOut>();
            isLockedOut.Add(new IsLockedOut()
            {
                Value = 1,
                Text = "Yes"
            });
            isLockedOut.Add(new IsLockedOut()
            {
                Value = 0,
                Text = "No"
            });
            comboBoxLocked.DataSource = isLockedOut;
            comboBoxLocked.DisplayMember = "Text";
            comboBoxLocked.ValueMember = "Value";

            List<IsApproved> approval = new List<IsApproved>();
            approval.Add(new IsApproved()
            {
                Value = 1,
                Text = "Yes"
            });
            approval.Add(new IsApproved()
            {
                Value = 0,
                Text = "No"
            });
            comboBoxApprove.DataSource = approval;
            comboBoxApprove.DisplayMember = "Text";
            comboBoxApprove.ValueMember = "Value";
            textBoxName.Text = EmployeeName;
            textBoxCont.Text = Contact;
            textBoxCreateDate.Text = CreateDate;
            textBoxGmail.Text = Email;
            textBoxID.Text = RoleId;
            textBoxUsernam.Text = UserName;
            textBoxPass.Text = Password;
            textBoxPassSalt.Text = PasswordSalt;

            if (!string.IsNullOrEmpty(EmployeeName))
            {
                buttonSav.Enabled = false;
            }
            else
            {
                buttonUpd.Enabled = false;
            }
        }

        private void buttonUpd_Click(object sender, EventArgs e)
        {
            EmployeeDataLogic employeeDataLogic = new EmployeeDataLogic();
            EmployeeName = textBoxName.Text.Trim();
            Contact = textBoxCont.Text.Trim();
            Email = textBoxGmail.Text.Trim();
            RoleId = textBoxID.Text.Trim();
            UserName = textBoxUsernam.Text.Trim();
            Password = textBoxPass.Text.Trim();
            PasswordSalt = textBoxPassSalt.Text.Trim();
            CreateDate = textBoxCreateDate.Text.Trim();
            string isactive = comboBoxActive.SelectedValue.ToString();
            IsActive = isactive == "0" ? false : true;
            string approval = comboBoxApprove.SelectedValue.ToString();
            IsApproved = approval == "0" ? false : true;
            string isLockedOut = comboBoxLocked.SelectedValue.ToString();
            IsLockedOut = isLockedOut == "0" ? false : true;
            bool result = employeeDataLogic.UpdateEmployee(EmployeeName, Contact, Email, RoleId, IsActive, UserName, Password, PasswordSalt, CreateDate, IsApproved, IsLockedOut, SystemGenerate);
            if (result == true)
            {
                MessageBox.Show("Success!");
                EmployeeListForm employeeListForm = new EmployeeListForm();
                this.Hide();
                employeeListForm.Show();
            }
            else
            {
                MessageBox.Show("Error!");
            }
        }
    }
}
