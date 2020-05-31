namespace WindowsFormsApp1
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.labelUser = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataView = new System.Windows.Forms.DataGridView();
            this.tableComboBox = new System.Windows.Forms.ComboBox();
            this.showingTableButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.insertButton = new System.Windows.Forms.Button();
            this.queryTextBox = new System.Windows.Forms.TextBox();
            this.queryComboBox = new System.Windows.Forms.ComboBox();
            this.queryButton = new System.Windows.Forms.Button();
            this.updateButton = new System.Windows.Forms.Button();
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
            this.labelUser.Location = new System.Drawing.Point(430, 167);
            this.labelUser.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(127, 13);
            this.labelUser.TabIndex = 5;
            this.labelUser.Text = "WITAJ UŻYTKOWNIKU:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(430, 180);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Status konta: Administrator";
            // 
            // dataView
            // 
            this.dataView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataView.Location = new System.Drawing.Point(9, 12);
            this.dataView.Margin = new System.Windows.Forms.Padding(2);
            this.dataView.Name = "dataView";
            this.dataView.RowHeadersWidth = 51;
            this.dataView.RowTemplate.Height = 24;
            this.dataView.Size = new System.Drawing.Size(404, 341);
            this.dataView.TabIndex = 7;
            this.dataView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataView_CellClick);
            this.dataView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataView_CellValueChanged);
            this.dataView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataView_DataError);
            this.dataView.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataView_RowHeaderMouseClick);
            // 
            // tableComboBox
            // 
            this.tableComboBox.FormattingEnabled = true;
            this.tableComboBox.Location = new System.Drawing.Point(432, 206);
            this.tableComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.tableComboBox.Name = "tableComboBox";
            this.tableComboBox.Size = new System.Drawing.Size(151, 21);
            this.tableComboBox.TabIndex = 8;
            // 
            // showingTableButton
            // 
            this.showingTableButton.Location = new System.Drawing.Point(453, 237);
            this.showingTableButton.Margin = new System.Windows.Forms.Padding(2);
            this.showingTableButton.Name = "showingTableButton";
            this.showingTableButton.Size = new System.Drawing.Size(110, 26);
            this.showingTableButton.TabIndex = 9;
            this.showingTableButton.Text = "Pokaż relację";
            this.showingTableButton.UseVisualStyleBackColor = true;
            this.showingTableButton.Click += new System.EventHandler(this.showingTableButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(453, 268);
            this.deleteButton.Margin = new System.Windows.Forms.Padding(2);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(110, 25);
            this.deleteButton.TabIndex = 10;
            this.deleteButton.Text = "Usuń wiersz";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.deleteButton_MouseClick);
            // 
            // insertButton
            // 
            this.insertButton.Location = new System.Drawing.Point(453, 298);
            this.insertButton.Margin = new System.Windows.Forms.Padding(2);
            this.insertButton.Name = "insertButton";
            this.insertButton.Size = new System.Drawing.Size(110, 25);
            this.insertButton.TabIndex = 11;
            this.insertButton.Text = "Dodaj wiersz";
            this.insertButton.UseVisualStyleBackColor = true;
            this.insertButton.Click += new System.EventHandler(this.insertButton_Click);
            // 
            // queryTextBox
            // 
            this.queryTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.queryTextBox.Location = new System.Drawing.Point(9, 366);
            this.queryTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.queryTextBox.Multiline = true;
            this.queryTextBox.Name = "queryTextBox";
            this.queryTextBox.Size = new System.Drawing.Size(405, 54);
            this.queryTextBox.TabIndex = 12;
            this.queryTextBox.Text = "Wpisz dowolne zapytanie!";
            // 
            // queryComboBox
            // 
            this.queryComboBox.FormattingEnabled = true;
            this.queryComboBox.Location = new System.Drawing.Point(418, 366);
            this.queryComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.queryComboBox.Name = "queryComboBox";
            this.queryComboBox.Size = new System.Drawing.Size(94, 21);
            this.queryComboBox.TabIndex = 13;
            // 
            // queryButton
            // 
            this.queryButton.Location = new System.Drawing.Point(418, 390);
            this.queryButton.Margin = new System.Windows.Forms.Padding(2);
            this.queryButton.Name = "queryButton";
            this.queryButton.Size = new System.Drawing.Size(93, 28);
            this.queryButton.TabIndex = 14;
            this.queryButton.Text = "Wyślij zapytanie";
            this.queryButton.UseVisualStyleBackColor = true;
            this.queryButton.Click += new System.EventHandler(this.queryButton_Click);
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(453, 328);
            this.updateButton.Margin = new System.Windows.Forms.Padding(2);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(110, 25);
            this.updateButton.TabIndex = 15;
            this.updateButton.Text = "Uaktualnij wiersz";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // logoutPicture
            // 
            this.logoutPicture.BackColor = System.Drawing.Color.Transparent;
            this.logoutPicture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.logoutPicture.Location = new System.Drawing.Point(544, 10);
            this.logoutPicture.Margin = new System.Windows.Forms.Padding(2);
            this.logoutPicture.Name = "logoutPicture";
            this.logoutPicture.Size = new System.Drawing.Size(39, 41);
            this.logoutPicture.TabIndex = 4;
            this.logoutPicture.TabStop = false;
            this.logoutPicture.Click += new System.EventHandler(this.logoutPicture_Click);
            // 
            // userPicture
            // 
            this.userPicture.AccessibleName = "";
            this.userPicture.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userPicture.BackColor = System.Drawing.Color.Transparent;
            this.userPicture.Image = ((System.Drawing.Image)(resources.GetObject("userPicture.Image")));
            this.userPicture.Location = new System.Drawing.Point(431, 10);
            this.userPicture.Margin = new System.Windows.Forms.Padding(2);
            this.userPicture.Name = "userPicture";
            this.userPicture.Size = new System.Drawing.Size(151, 154);
            this.userPicture.TabIndex = 1;
            this.userPicture.TabStop = false;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 428);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.queryButton);
            this.Controls.Add(this.queryComboBox);
            this.Controls.Add(this.queryTextBox);
            this.Controls.Add(this.insertButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.showingTableButton);
            this.Controls.Add(this.tableComboBox);
            this.Controls.Add(this.dataView);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelUser);
            this.Controls.Add(this.logoutPicture);
            this.Controls.Add(this.userPicture);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form3";
            this.Text = "Perspektywa Administratora";
            ((System.ComponentModel.ISupportInitialize)(this.dataView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoutPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox logoutPicture;
        private System.Windows.Forms.Label labelUser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox userPicture;
        private System.Windows.Forms.DataGridView dataView;
        private System.Windows.Forms.ComboBox tableComboBox;
        private System.Windows.Forms.Button showingTableButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button insertButton;
        private System.Windows.Forms.TextBox queryTextBox;
        private System.Windows.Forms.ComboBox queryComboBox;
        private System.Windows.Forms.Button queryButton;
        private System.Windows.Forms.Button updateButton;
    }
}