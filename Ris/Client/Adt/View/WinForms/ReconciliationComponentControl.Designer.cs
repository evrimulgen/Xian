namespace ClearCanvas.Ris.Client.Adt.View.WinForms
{
    partial class ReconciliationComponentControl
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
            this._reconciliationTableView = new ClearCanvas.Desktop.View.WinForms.TableView();
            this.label1 = new System.Windows.Forms.Label();
            this._reconcileButton = new System.Windows.Forms.Button();
            this._cancelButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this._targetTableView = new ClearCanvas.Desktop.View.WinForms.TableView();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this._diffViewPanel = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _reconciliationTableView
            // 
            this._reconciliationTableView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._reconciliationTableView.AutoSize = true;
            this._reconciliationTableView.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._reconciliationTableView.Location = new System.Drawing.Point(5, 22);
            this._reconciliationTableView.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this._reconciliationTableView.MenuModel = null;
            this._reconciliationTableView.MultiSelect = false;
            this._reconciliationTableView.Name = "_reconciliationTableView";
            this._reconciliationTableView.ReadOnly = false;
            this._reconciliationTableView.ShowToolbar = false;
            this._reconciliationTableView.Size = new System.Drawing.Size(647, 110);
            this._reconciliationTableView.TabIndex = 7;
            this._reconciliationTableView.Table = null;
            this._reconciliationTableView.TabStop = false;
            this._reconciliationTableView.ToolbarModel = null;
            this._reconciliationTableView.ToolStripItemDisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._reconciliationTableView.ToolStripRightToLeft = System.Windows.Forms.RightToLeft.No;
            this._reconciliationTableView.SelectionChanged += new System.EventHandler(this._reconciliationTableView_SelectionChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Reconciliation Candidates";
            // 
            // _reconcileButton
            // 
            this._reconcileButton.Location = new System.Drawing.Point(460, 2);
            this._reconcileButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._reconcileButton.Name = "_reconcileButton";
            this._reconcileButton.Size = new System.Drawing.Size(113, 23);
            this._reconcileButton.TabIndex = 11;
            this._reconcileButton.Text = "Reconcile";
            this._reconcileButton.UseVisualStyleBackColor = true;
            this._reconcileButton.Click += new System.EventHandler(this._reconcileButton_Click);
            // 
            // _cancelButton
            // 
            this._cancelButton.Location = new System.Drawing.Point(579, 2);
            this._cancelButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(75, 23);
            this._cancelButton.TabIndex = 13;
            this._cancelButton.Text = "Cancel";
            this._cancelButton.UseVisualStyleBackColor = true;
            this._cancelButton.Click += new System.EventHandler(this._cancelButton_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this._diffViewPanel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1325, 750);
            this.tableLayoutPanel1.TabIndex = 14;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this._targetTableView, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 2);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(656, 137);
            this.tableLayoutPanel2.TabIndex = 15;
            // 
            // _targetTableView
            // 
            this._targetTableView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._targetTableView.AutoSize = true;
            this._targetTableView.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._targetTableView.Location = new System.Drawing.Point(5, 22);
            this._targetTableView.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this._targetTableView.MenuModel = null;
            this._targetTableView.MultiSelect = false;
            this._targetTableView.Name = "_targetTableView";
            this._targetTableView.ReadOnly = false;
            this._targetTableView.ShowToolbar = false;
            this._targetTableView.Size = new System.Drawing.Size(646, 110);
            this._targetTableView.TabIndex = 8;
            this._targetTableView.Table = null;
            this._targetTableView.TabStop = false;
            this._targetTableView.ToolbarModel = null;
            this._targetTableView.ToolStripItemDisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._targetTableView.ToolStripRightToLeft = System.Windows.Forms.RightToLeft.No;
            this._targetTableView.SelectionChanged += new System.EventHandler(this._targetTableView_SelectionChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Patient";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this._reconciliationTableView, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(665, 2);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(657, 137);
            this.tableLayoutPanel3.TabIndex = 16;
            // 
            // _diffViewPanel
            // 
            this.tableLayoutPanel1.SetColumnSpan(this._diffViewPanel, 2);
            this._diffViewPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._diffViewPanel.Location = new System.Drawing.Point(3, 143);
            this._diffViewPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._diffViewPanel.Name = "_diffViewPanel";
            this._diffViewPanel.Size = new System.Drawing.Size(1319, 562);
            this._diffViewPanel.TabIndex = 17;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this._cancelButton);
            this.flowLayoutPanel1.Controls.Add(this._reconcileButton);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(665, 709);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.flowLayoutPanel1.Size = new System.Drawing.Size(657, 38);
            this.flowLayoutPanel1.TabIndex = 19;
            // 
            // ReconciliationComponentControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ReconciliationComponentControl";
            this.Size = new System.Drawing.Size(1325, 750);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ClearCanvas.Desktop.View.WinForms.TableView _reconciliationTableView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button _reconcileButton;
        private System.Windows.Forms.Button _cancelButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Panel _diffViewPanel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private ClearCanvas.Desktop.View.WinForms.TableView _targetTableView;
    }
}
