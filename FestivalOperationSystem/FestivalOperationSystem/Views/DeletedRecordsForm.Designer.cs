namespace FestivalOperationSystem.Views
{
    partial class DeletedRecordsForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DeletedDataGridView = new DataGridView();
            IdColumn = new DataGridViewTextBoxColumn();
            NameColumn = new DataGridViewTextBoxColumn();
            RoleColumn = new DataGridViewTextBoxColumn();
            EmailColumn = new DataGridViewTextBoxColumn();
            DeletedAtColumn = new DataGridViewTextBoxColumn();
            BottomPanel = new Panel();
            SummaryLabel = new Label();
            RestoreButton = new Button();
            CloseButton = new Button();
            ((System.ComponentModel.ISupportInitialize)DeletedDataGridView).BeginInit();
            BottomPanel.SuspendLayout();
            SuspendLayout();
            //
            // DeletedDataGridView
            //
            DeletedDataGridView.AllowUserToAddRows = false;
            DeletedDataGridView.AllowUserToDeleteRows = false;
            DeletedDataGridView.AllowUserToResizeRows = false;
            DeletedDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DeletedDataGridView.Columns.AddRange(new DataGridViewColumn[] { IdColumn, NameColumn, RoleColumn, EmailColumn, DeletedAtColumn });
            DeletedDataGridView.Dock = DockStyle.Fill;
            DeletedDataGridView.Location = new Point(0, 0);
            DeletedDataGridView.MultiSelect = false;
            DeletedDataGridView.Name = "DeletedDataGridView";
            DeletedDataGridView.ReadOnly = true;
            DeletedDataGridView.RowHeadersVisible = false;
            DeletedDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DeletedDataGridView.Size = new Size(760, 350);
            DeletedDataGridView.TabIndex = 0;
            //
            // IdColumn
            //
            IdColumn.HeaderText = "ID";
            IdColumn.Name = "IdColumn";
            IdColumn.ReadOnly = true;
            IdColumn.Width = 50;
            //
            // NameColumn
            //
            NameColumn.HeaderText = "Name";
            NameColumn.Name = "NameColumn";
            NameColumn.ReadOnly = true;
            NameColumn.Width = 170;
            //
            // RoleColumn
            //
            RoleColumn.HeaderText = "Role";
            RoleColumn.Name = "RoleColumn";
            RoleColumn.ReadOnly = true;
            RoleColumn.Width = 90;
            //
            // EmailColumn
            //
            EmailColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            EmailColumn.HeaderText = "Email";
            EmailColumn.Name = "EmailColumn";
            EmailColumn.ReadOnly = true;
            //
            // DeletedAtColumn
            //
            DeletedAtColumn.HeaderText = "Deleted at";
            DeletedAtColumn.Name = "DeletedAtColumn";
            DeletedAtColumn.ReadOnly = true;
            DeletedAtColumn.Width = 130;
            //
            // BottomPanel
            //
            BottomPanel.Controls.Add(SummaryLabel);
            BottomPanel.Controls.Add(RestoreButton);
            BottomPanel.Controls.Add(CloseButton);
            BottomPanel.Dock = DockStyle.Bottom;
            BottomPanel.Location = new Point(0, 350);
            BottomPanel.Name = "BottomPanel";
            BottomPanel.Size = new Size(760, 50);
            BottomPanel.TabIndex = 1;
            //
            // SummaryLabel
            //
            SummaryLabel.AutoSize = true;
            SummaryLabel.Location = new Point(12, 18);
            SummaryLabel.Name = "SummaryLabel";
            SummaryLabel.Size = new Size(0, 15);
            SummaryLabel.TabIndex = 0;
            //
            // RestoreButton
            //
            RestoreButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            RestoreButton.Location = new Point(562, 11);
            RestoreButton.Name = "RestoreButton";
            RestoreButton.Size = new Size(90, 28);
            RestoreButton.TabIndex = 1;
            RestoreButton.Text = "&Restore";
            RestoreButton.UseVisualStyleBackColor = true;
            RestoreButton.Click += RestoreButton_Click;
            //
            // CloseButton
            //
            CloseButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            CloseButton.DialogResult = DialogResult.Cancel;
            CloseButton.Location = new Point(658, 11);
            CloseButton.Name = "CloseButton";
            CloseButton.Size = new Size(90, 28);
            CloseButton.TabIndex = 2;
            CloseButton.Text = "&Close";
            CloseButton.UseVisualStyleBackColor = true;
            CloseButton.Click += CloseButton_Click;
            //
            // DeletedRecordsForm
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = CloseButton;
            ClientSize = new Size(760, 400);
            Controls.Add(DeletedDataGridView);
            Controls.Add(BottomPanel);
            MinimizeBox = false;
            MinimumSize = new Size(600, 300);
            Name = "DeletedRecordsForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Deleted records";
            Load += DeletedRecordsForm_Load;
            ((System.ComponentModel.ISupportInitialize)DeletedDataGridView).EndInit();
            BottomPanel.ResumeLayout(false);
            BottomPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView DeletedDataGridView;
        private DataGridViewTextBoxColumn IdColumn;
        private DataGridViewTextBoxColumn NameColumn;
        private DataGridViewTextBoxColumn RoleColumn;
        private DataGridViewTextBoxColumn EmailColumn;
        private DataGridViewTextBoxColumn DeletedAtColumn;
        private Panel BottomPanel;
        private Label SummaryLabel;
        private Button RestoreButton;
        private Button CloseButton;
    }
}
