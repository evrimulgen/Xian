namespace ClearCanvas.Ris.Client.Adt.View.WinForms
{
    partial class PatientSearchComponentControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this._searchButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this._familyName = new ClearCanvas.Controls.WinForms.TextField();
            this._mrn = new ClearCanvas.Controls.WinForms.TextField();
            this._givenName = new ClearCanvas.Controls.WinForms.TextField();
            this._sex = new ClearCanvas.Controls.WinForms.ComboBoxField();
            this._healthcard = new ClearCanvas.Controls.WinForms.TextField();
            this._dateOfBirth = new ClearCanvas.Controls.WinForms.DateTimeField();
            this._errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // _searchButton
            // 
            this._searchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._searchButton.Location = new System.Drawing.Point(207, 272);
            this._searchButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._searchButton.Name = "_searchButton";
            this._searchButton.Size = new System.Drawing.Size(75, 23);
            this._searchButton.TabIndex = 6;
            this._searchButton.Text = "Search";
            this._searchButton.UseVisualStyleBackColor = true;
            this._searchButton.Click += new System.EventHandler(this._searchButton_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this._familyName, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this._mrn, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this._givenName, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this._sex, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this._searchButton, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this._healthcard, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this._dateOfBirth, 1, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(285, 328);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // _familyName
            // 
            this._familyName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this._familyName, 2);
            this._familyName.LabelText = "Family Name";
            this._familyName.Location = new System.Drawing.Point(3, 110);
            this._familyName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._familyName.Name = "_familyName";
            this._familyName.Size = new System.Drawing.Size(279, 50);
            this._familyName.TabIndex = 2;
            this._familyName.Value = null;
            // 
            // _mrn
            // 
            this._mrn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this._mrn, 2);
            this._mrn.LabelText = "MRN";
            this._mrn.Location = new System.Drawing.Point(3, 2);
            this._mrn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._mrn.Name = "_mrn";
            this._mrn.Size = new System.Drawing.Size(279, 50);
            this._mrn.TabIndex = 0;
            this._mrn.Value = null;
            // 
            // _givenName
            // 
            this._givenName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this._givenName, 2);
            this._givenName.LabelText = "Given Name";
            this._givenName.Location = new System.Drawing.Point(3, 164);
            this._givenName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._givenName.Name = "_givenName";
            this._givenName.Size = new System.Drawing.Size(279, 50);
            this._givenName.TabIndex = 3;
            this._givenName.Value = null;
            // 
            // _sex
            // 
            this._sex.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._sex.DataSource = null;
            this._sex.LabelText = "Sex";
            this._sex.Location = new System.Drawing.Point(3, 218);
            this._sex.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._sex.Name = "_sex";
            this._sex.Size = new System.Drawing.Size(136, 50);
            this._sex.TabIndex = 4;
            this._sex.Value = null;
            // 
            // _healthcard
            // 
            this._healthcard.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this._healthcard, 2);
            this._healthcard.LabelText = "Healthcard";
            this._healthcard.Location = new System.Drawing.Point(3, 56);
            this._healthcard.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._healthcard.Name = "_healthcard";
            this._healthcard.Size = new System.Drawing.Size(279, 50);
            this._healthcard.TabIndex = 7;
            this._healthcard.Value = null;
            // 
            // _dateOfBirth
            // 
            this._dateOfBirth.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._dateOfBirth.LabelText = "Date of Birth";
            this._dateOfBirth.Location = new System.Drawing.Point(145, 218);
            this._dateOfBirth.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._dateOfBirth.Name = "_dateOfBirth";
            this._dateOfBirth.Nullable = true;
            this._dateOfBirth.Size = new System.Drawing.Size(137, 48);
            this._dateOfBirth.TabIndex = 5;
            this._dateOfBirth.Value = null;
            // 
            // _errorProvider
            // 
            this._errorProvider.ContainerControl = this;
            // 
            // PatientSearchComponentControl
            // 
            this.AcceptButton = this._searchButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "PatientSearchComponentControl";
            this.Size = new System.Drawing.Size(285, 328);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _searchButton;
        private ClearCanvas.Controls.WinForms.TextField _familyName;
        private ClearCanvas.Controls.WinForms.TextField _givenName;
        private ClearCanvas.Controls.WinForms.TextField _mrn;
        private ClearCanvas.Controls.WinForms.ComboBoxField _sex;
        private ClearCanvas.Controls.WinForms.DateTimeField _dateOfBirth;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ClearCanvas.Controls.WinForms.TextField _healthcard;
        private System.Windows.Forms.ErrorProvider _errorProvider;
    }
}
