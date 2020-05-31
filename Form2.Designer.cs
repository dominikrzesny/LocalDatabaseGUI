namespace WindowsFormsApp1
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.labelUser = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataView = new System.Windows.Forms.DataGridView();
            this.showEmployeesButton = new System.Windows.Forms.Button();
            this.countMonthlySalaryButton = new System.Windows.Forms.Button();
            this.addSalaryButton = new System.Windows.Forms.Button();
            this.searchEmployeeButton = new System.Windows.Forms.Button();
            this.ShowEmployeeSalary = new System.Windows.Forms.Button();
            this.logoutPicture = new System.Windows.Forms.PictureBox();
            this.userPicture = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoutPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // labelUser
            // 
            this.labelUser.AutoSize = true;
            this.labelUser.BackColor = System.Drawing.Color.Transparent;
            this.labelUser.ForeColor = System.Drawing.Color.White;
            this.labelUser.Location = new System.Drawing.Point(311, 166);
            this.labelUser.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(127, 13);
            this.labelUser.TabIndex = 1;
            this.labelUser.Text = "WITAJ UŻYTKOWNIKU:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(311, 180);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Stanowisko: Księgowa";
            // 
            // dataView
            // 
            this.dataView.AllowUserToOrderColumns = true;
            this.dataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataView.Location = new System.Drawing.Point(9, 220);
            this.dataView.Margin = new System.Windows.Forms.Padding(2);
            this.dataView.Name = "dataView";
            this.dataView.RowHeadersWidth = 51;
            this.dataView.RowTemplate.Height = 24;
            this.dataView.Size = new System.Drawing.Size(438, 198);
            this.dataView.TabIndex = 4;
            this.dataView.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataView_RowHeaderMouseClick);
            // 
            // showEmployeesButton
            // 
            this.showEmployeesButton.Location = new System.Drawing.Point(18, 141);
            this.showEmployeesButton.Margin = new System.Windows.Forms.Padding(2);
            this.showEmployeesButton.Name = "showEmployeesButton";
            this.showEmployeesButton.Size = new System.Drawing.Size(130, 52);
            this.showEmployeesButton.TabIndex = 5;
            this.showEmployeesButton.Text = "Wyświetl pracowników danego oddziału";
            this.showEmployeesButton.UseVisualStyleBackColor = true;
            this.showEmployeesButton.Click += new System.EventHandler(this.showEmployeesButton_Click);
            // 
            // countMonthlySalaryButton
            // 
            this.countMonthlySalaryButton.Location = new System.Drawing.Point(153, 10);
            this.countMonthlySalaryButton.Margin = new System.Windows.Forms.Padding(2);
            this.countMonthlySalaryButton.Name = "countMonthlySalaryButton";
            this.countMonthlySalaryButton.Size = new System.Drawing.Size(130, 52);
            this.countMonthlySalaryButton.TabIndex = 6;
            this.countMonthlySalaryButton.Text = "Sumuj pensje pracowników danego oddziału";
            this.countMonthlySalaryButton.UseVisualStyleBackColor = true;
            this.countMonthlySalaryButton.Click += new System.EventHandler(this.countMonthlySalaryButton_Click);
            // 
            // addSalaryButton
            // 
            this.addSalaryButton.Location = new System.Drawing.Point(18, 10);
            this.addSalaryButton.Margin = new System.Windows.Forms.Padding(2);
            this.addSalaryButton.Name = "addSalaryButton";
            this.addSalaryButton.Size = new System.Drawing.Size(130, 52);
            this.addSalaryButton.TabIndex = 7;
            this.addSalaryButton.Text = "Dodaj wynagrodzenie";
            this.addSalaryButton.UseVisualStyleBackColor = true;
            this.addSalaryButton.Click += new System.EventHandler(this.addSalaryButton_Click);
            // 
            // searchEmployeeButton
            // 
            this.searchEmployeeButton.Location = new System.Drawing.Point(19, 75);
            this.searchEmployeeButton.Margin = new System.Windows.Forms.Padding(2);
            this.searchEmployeeButton.Name = "searchEmployeeButton";
            this.searchEmployeeButton.Size = new System.Drawing.Size(130, 52);
            this.searchEmployeeButton.TabIndex = 8;
            this.searchEmployeeButton.Text = "Wyszukaj pracownika";
            this.searchEmployeeButton.UseVisualStyleBackColor = true;
            this.searchEmployeeButton.Click += new System.EventHandler(this.searchEmployeeButton_Click);
            // 
            // ShowEmployeeSalary
            // 
            this.ShowEmployeeSalary.Location = new System.Drawing.Point(153, 75);
            this.ShowEmployeeSalary.Margin = new System.Windows.Forms.Padding(2);
            this.ShowEmployeeSalary.Name = "ShowEmployeeSalary";
            this.ShowEmployeeSalary.Size = new System.Drawing.Size(130, 52);
            this.ShowEmployeeSalary.TabIndex = 9;
            this.ShowEmployeeSalary.Text = "Wyświetl miesięczne wynagrodzenie pracownika";
            this.ShowEmployeeSalary.UseVisualStyleBackColor = true;
            this.ShowEmployeeSalary.Click += new System.EventHandler(this.ShowEmployeeSalary_Click);
            // 
            // logoutPicture
            // 
            this.logoutPicture.BackColor = System.Drawing.Color.Transparent;
            this.logoutPicture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.logoutPicture.Location = new System.Drawing.Point(408, 10);
            this.logoutPicture.Margin = new System.Windows.Forms.Padding(2);
            this.logoutPicture.Name = "logoutPicture";
            this.logoutPicture.Size = new System.Drawing.Size(39, 41);
            this.logoutPicture.TabIndex = 3;
            this.logoutPicture.TabStop = false;
            this.logoutPicture.Click += new System.EventHandler(this.logoutPicture_Click);
            // 
            // userPicture
            // 
            this.userPicture.BackColor = System.Drawing.Color.Transparent;
            this.userPicture.Image = ((System.Drawing.Image)(resources.GetObject("userPicture.Image")));
            this.userPicture.Location = new System.Drawing.Point(296, 10);
            this.userPicture.Margin = new System.Windows.Forms.Padding(2);
            this.userPicture.Name = "userPicture";
            this.userPicture.Size = new System.Drawing.Size(151, 154);
            this.userPicture.TabIndex = 0;
            this.userPicture.TabStop = false;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(458, 428);
            this.Controls.Add(this.ShowEmployeeSalary);
            this.Controls.Add(this.searchEmployeeButton);
            this.Controls.Add(this.addSalaryButton);
            this.Controls.Add(this.countMonthlySalaryButton);
            this.Controls.Add(this.showEmployeesButton);
            this.Controls.Add(this.dataView);
            this.Controls.Add(this.logoutPicture);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelUser);
            this.Controls.Add(this.userPicture);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form2";
            this.Text = "Perspektywa Księgowej";
            ((System.ComponentModel.ISupportInitialize)(this.dataView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoutPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox userPicture;
        private System.Windows.Forms.Label labelUser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox logoutPicture;
        private System.Windows.Forms.DataGridView dataView;
        private System.Windows.Forms.Button showEmployeesButton;
        private System.Windows.Forms.Button countMonthlySalaryButton;
        private System.Windows.Forms.Button addSalaryButton;
        private System.Windows.Forms.Button searchEmployeeButton;
        private System.Windows.Forms.Button ShowEmployeeSalary;
    }
}