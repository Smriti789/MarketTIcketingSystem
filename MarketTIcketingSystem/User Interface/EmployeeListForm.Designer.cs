
namespace MarketTIcketingSystem.User_Interface
{
    partial class EmployeeListForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonAddEmployee = new System.Windows.Forms.Button();
            this.buttonBackEmployee = new System.Windows.Forms.Button();
            this.DataGridViewEmployee = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewEmployee)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonAddEmployee
            // 
            this.buttonAddEmployee.Location = new System.Drawing.Point(24, 12);
            this.buttonAddEmployee.Name = "buttonAddEmployee";
            this.buttonAddEmployee.Size = new System.Drawing.Size(75, 23);
            this.buttonAddEmployee.TabIndex = 1;
            this.buttonAddEmployee.Text = "ADD";
            this.buttonAddEmployee.UseVisualStyleBackColor = true;
            this.buttonAddEmployee.Click += new System.EventHandler(this.buttonAddEmployee_Click);
            // 
            // buttonBackEmployee
            // 
            this.buttonBackEmployee.Location = new System.Drawing.Point(105, 12);
            this.buttonBackEmployee.Name = "buttonBackEmployee";
            this.buttonBackEmployee.Size = new System.Drawing.Size(75, 23);
            this.buttonBackEmployee.TabIndex = 2;
            this.buttonBackEmployee.Text = "BACK";
            this.buttonBackEmployee.UseVisualStyleBackColor = true;
            this.buttonBackEmployee.Click += new System.EventHandler(this.buttonBackEmployee_Click);
            // 
            // DataGridViewEmployee
            // 
            this.DataGridViewEmployee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewEmployee.Location = new System.Drawing.Point(13, 60);
            this.DataGridViewEmployee.Name = "DataGridViewEmployee";
            this.DataGridViewEmployee.RowHeadersWidth = 51;
            this.DataGridViewEmployee.RowTemplate.Height = 24;
            this.DataGridViewEmployee.Size = new System.Drawing.Size(775, 366);
            this.DataGridViewEmployee.TabIndex = 3;
            this.DataGridViewEmployee.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGridViewEmployee_RowHeaderMouseDoubleClick);
            // 
            // EmployeeListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DataGridViewEmployee);
            this.Controls.Add(this.buttonBackEmployee);
            this.Controls.Add(this.buttonAddEmployee);
            this.Name = "EmployeeListForm";
            this.Text = "EmployeeListForm";
            this.Load += new System.EventHandler(this.EmployeeListForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewEmployee)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonAddEmployee;
        private System.Windows.Forms.Button buttonBackEmployee;
        private System.Windows.Forms.DataGridView DataGridViewEmployee;
    }
}