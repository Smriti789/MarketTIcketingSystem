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
    public partial class Productaddform : Form
    {
        public Productaddform()
        {
            InitializeComponent();
        }
		public string projectName = string.Empty;
		public string projectDescription = string.Empty;
		public bool isActive = true;
		public bool isSystemGenerated = false;
		public int projectId;

		private void Productaddform_Load(object sender, EventArgs e)
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
			comboBox1.DataSource = isactive;
			comboBox1.DisplayMember = "Text";
			comboBox1.ValueMember = "Value";
			textBox1.Text = projectName;
			richTextBox1.Text = projectDescription;

			if (!string.IsNullOrEmpty(projectName))
			{
				buttonSave.Enabled = false;
			}
			else
			{
				buttonUpdate.Enabled = false;
			}
		}

        private void buttonSave_Click(object sender, EventArgs e)
        {
			ProductDataLogic projectDataLogic = new ProductDataLogic();
			projectName = textBox1.Text.Trim();
			projectDescription = richTextBox1.Text.Trim();
			string dropdownvalue = comboBox1.SelectedValue.ToString();
			isActive = dropdownvalue == "0" ? false : true;
			bool result = projectDataLogic.AddProduct(projectName, projectDescription, isActive, isSystemGenerated);
			if (result == true)
			{
				MessageBox.Show("Success!");
				ProductListForm projectListForm = new ProductListForm();
				this.Hide();
				projectListForm.Show();
			}
			else
			{
				MessageBox.Show("Error!");
			}
		}

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
			ProductDataLogic projectDataLogic = new ProductDataLogic();
			projectName = textBox1.Text.Trim();
			projectDescription = richTextBox1.Text.Trim();
			string dropdownvalue = comboBox1.SelectedValue.ToString();
			isActive = dropdownvalue == "0" ? false : true;
			bool result = projectDataLogic.UpdateProject(projectId, projectName, projectDescription, isActive, isSystemGenerated);
			if (result == true)
			{
				MessageBox.Show("Update Success!");
				ProductListForm projectListForm = new ProductListForm();
				this.Hide();
				projectListForm.Show();
			}
			else
			{
				MessageBox.Show("Update Error!");
			}
		}
    }
}
