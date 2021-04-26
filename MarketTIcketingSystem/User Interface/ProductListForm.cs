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
    public partial class ProductListForm : Form
    {
        public ProductListForm()
        {
            InitializeComponent();
        }
        public string projectName = string.Empty;
        public string projectDescription = string.Empty;
        public bool isActive = false;
        public bool isSystemGenerated = false;
        private void ProductListForm_Load(object sender, EventArgs e)
        {
            ProductDataLogic projectDataLogic = new ProductDataLogic();
            DataTable dataTable = new DataTable();
            dataTable = projectDataLogic.GetProductList();
            dataGridView1.DataSource = dataTable;
            this.ControlBox = false;
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Productaddform projectAddForm = new Productaddform();
            this.Hide();
            projectAddForm.Show();
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            int projectId = int.Parse(dataGridView1.Rows[rowIndex].Cells[0].Value.ToString());
            ProductDataLogic projectDataLogic = new ProductDataLogic();
            //string projectName, projectDescription;
            //bool isActive, isSystemGenerated;
            bool result = projectDataLogic.GetProjectInfo(projectId, out projectName, out projectDescription, out isActive, out isSystemGenerated);
            if (result == true)
            {
                Productaddform projectAddForm = new Productaddform()
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
