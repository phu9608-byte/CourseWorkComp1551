namespace FestivalOperationSystem.Views
{
    partial class MainForm
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
            AppMenuStrip = new MenuStrip();
            FileMenuItem = new ToolStripMenuItem();
            ExitMenuItem = new ToolStripMenuItem();
            RecordsMenuItem = new ToolStripMenuItem();
            AddMenuItem = new ToolStripMenuItem();
            EditMenuItem = new ToolStripMenuItem();
            DeleteMenuItem = new ToolStripMenuItem();
            ViewMenuItem = new ToolStripMenuItem();
            AllRecordsMenuItem = new ToolStripMenuItem();
            PerformersMenuItem = new ToolStripMenuItem();
            CrewMenuItem = new ToolStripMenuItem();
            VendorsMenuItem = new ToolStripMenuItem();
            ViewMenuSeparator = new ToolStripSeparator();
            DeletedRecordsMenuItem = new ToolStripMenuItem();
            ToolbarPanel = new Panel();
            RoleLabel = new Label();
            RoleComboBox = new ComboBox();
            PersonIdLabel = new Label();
            PersonIdNumericUpDown = new NumericUpDown();
            EditButton = new Button();
            DeleteButton = new Button();
            AddButton = new Button();
            PeopleDataGridView = new DataGridView();
            IdColumn = new DataGridViewTextBoxColumn();
            NameColumn = new DataGridViewTextBoxColumn();
            RoleColumn = new DataGridViewTextBoxColumn();
            TelephoneColumn = new DataGridViewTextBoxColumn();
            EmailColumn = new DataGridViewTextBoxColumn();
            DetailsColumn = new DataGridViewTextBoxColumn();
            AppStatusStrip = new StatusStrip();
            StatusLabel = new ToolStripStatusLabel();
            AppMenuStrip.SuspendLayout();
            ToolbarPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PersonIdNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PeopleDataGridView).BeginInit();
            AppStatusStrip.SuspendLayout();
            SuspendLayout();
            //
            // AppMenuStrip
            //
            AppMenuStrip.Items.AddRange(new ToolStripItem[] { FileMenuItem, RecordsMenuItem, ViewMenuItem });
            AppMenuStrip.Location = new Point(0, 0);
            AppMenuStrip.Name = "AppMenuStrip";
            AppMenuStrip.Size = new Size(1000, 24);
            AppMenuStrip.TabIndex = 0;
            //
            // FileMenuItem
            //
            FileMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ExitMenuItem });
            FileMenuItem.Name = "FileMenuItem";
            FileMenuItem.Text = "&File";
            //
            // ExitMenuItem
            //
            ExitMenuItem.Name = "ExitMenuItem";
            ExitMenuItem.Text = "E&xit";
            ExitMenuItem.Click += ExitMenuItem_Click;
            //
            // RecordsMenuItem
            //
            RecordsMenuItem.DropDownItems.AddRange(new ToolStripItem[] { AddMenuItem, EditMenuItem, DeleteMenuItem });
            RecordsMenuItem.Name = "RecordsMenuItem";
            RecordsMenuItem.Text = "&Records";
            //
            // AddMenuItem
            //
            AddMenuItem.Name = "AddMenuItem";
            AddMenuItem.ShortcutKeys = Keys.Control | Keys.N;
            AddMenuItem.Text = "&Add new record...";
            AddMenuItem.Click += AddMenuItem_Click;
            //
            // EditMenuItem
            //
            EditMenuItem.Name = "EditMenuItem";
            EditMenuItem.Text = "&Edit record by ID";
            EditMenuItem.Click += EditMenuItem_Click;
            //
            // DeleteMenuItem
            //
            DeleteMenuItem.Name = "DeleteMenuItem";
            DeleteMenuItem.Text = "&Delete record by ID";
            DeleteMenuItem.Click += DeleteMenuItem_Click;
            //
            // ViewMenuItem
            //
            ViewMenuItem.DropDownItems.AddRange(new ToolStripItem[] { AllRecordsMenuItem, PerformersMenuItem, CrewMenuItem, VendorsMenuItem, ViewMenuSeparator, DeletedRecordsMenuItem });
            ViewMenuItem.Name = "ViewMenuItem";
            ViewMenuItem.Text = "&View";
            //
            // AllRecordsMenuItem
            //
            AllRecordsMenuItem.Name = "AllRecordsMenuItem";
            AllRecordsMenuItem.Text = "&All records";
            AllRecordsMenuItem.Click += AllRecordsMenuItem_Click;
            //
            // PerformersMenuItem
            //
            PerformersMenuItem.Name = "PerformersMenuItem";
            PerformersMenuItem.Text = "&Performers only";
            PerformersMenuItem.Click += PerformersMenuItem_Click;
            //
            // CrewMenuItem
            //
            CrewMenuItem.Name = "CrewMenuItem";
            CrewMenuItem.Text = "&Crew only";
            CrewMenuItem.Click += CrewMenuItem_Click;
            //
            // VendorsMenuItem
            //
            VendorsMenuItem.Name = "VendorsMenuItem";
            VendorsMenuItem.Text = "&Vendors only";
            VendorsMenuItem.Click += VendorsMenuItem_Click;
            //
            // ViewMenuSeparator
            //
            ViewMenuSeparator.Name = "ViewMenuSeparator";
            //
            // DeletedRecordsMenuItem
            //
            DeletedRecordsMenuItem.Name = "DeletedRecordsMenuItem";
            DeletedRecordsMenuItem.Text = "&Deleted records...";
            DeletedRecordsMenuItem.Click += DeletedRecordsMenuItem_Click;
            //
            // ToolbarPanel
            //
            ToolbarPanel.Controls.Add(RoleLabel);
            ToolbarPanel.Controls.Add(RoleComboBox);
            ToolbarPanel.Controls.Add(PersonIdLabel);
            ToolbarPanel.Controls.Add(PersonIdNumericUpDown);
            ToolbarPanel.Controls.Add(EditButton);
            ToolbarPanel.Controls.Add(DeleteButton);
            ToolbarPanel.Controls.Add(AddButton);
            ToolbarPanel.Dock = DockStyle.Top;
            ToolbarPanel.Location = new Point(0, 24);
            ToolbarPanel.Name = "ToolbarPanel";
            ToolbarPanel.Size = new Size(1000, 46);
            ToolbarPanel.TabIndex = 1;
            //
            // RoleLabel
            //
            RoleLabel.AutoSize = true;
            RoleLabel.Location = new Point(12, 15);
            RoleLabel.Name = "RoleLabel";
            RoleLabel.Size = new Size(33, 15);
            RoleLabel.TabIndex = 0;
            RoleLabel.Text = "Role:";
            //
            // RoleComboBox
            //
            RoleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            RoleComboBox.Location = new Point(55, 11);
            RoleComboBox.Name = "RoleComboBox";
            RoleComboBox.Size = new Size(130, 23);
            RoleComboBox.TabIndex = 1;
            RoleComboBox.SelectedIndexChanged += RoleComboBox_SelectedIndexChanged;
            //
            // PersonIdLabel
            //
            PersonIdLabel.AutoSize = true;
            PersonIdLabel.Location = new Point(215, 15);
            PersonIdLabel.Name = "PersonIdLabel";
            PersonIdLabel.Size = new Size(57, 15);
            PersonIdLabel.TabIndex = 2;
            PersonIdLabel.Text = "PersonID:";
            //
            // PersonIdNumericUpDown
            //
            PersonIdNumericUpDown.Location = new Point(280, 11);
            PersonIdNumericUpDown.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            PersonIdNumericUpDown.Name = "PersonIdNumericUpDown";
            PersonIdNumericUpDown.Size = new Size(90, 23);
            PersonIdNumericUpDown.TabIndex = 3;
            //
            // EditButton
            //
            EditButton.Location = new Point(380, 9);
            EditButton.Name = "EditButton";
            EditButton.Size = new Size(90, 27);
            EditButton.TabIndex = 4;
            EditButton.Text = "&Edit";
            EditButton.UseVisualStyleBackColor = true;
            EditButton.Click += EditButton_Click;
            //
            // DeleteButton
            //
            DeleteButton.Location = new Point(476, 9);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(90, 27);
            DeleteButton.TabIndex = 5;
            DeleteButton.Text = "&Delete";
            DeleteButton.UseVisualStyleBackColor = true;
            DeleteButton.Click += DeleteButton_Click;
            //
            // AddButton
            //
            AddButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            AddButton.Location = new Point(878, 9);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(110, 27);
            AddButton.TabIndex = 6;
            AddButton.Text = "&Add new...";
            AddButton.UseVisualStyleBackColor = true;
            AddButton.Click += AddButton_Click;
            //
            // PeopleDataGridView
            //
            PeopleDataGridView.AllowUserToAddRows = false;
            PeopleDataGridView.AllowUserToDeleteRows = false;
            PeopleDataGridView.AllowUserToResizeRows = false;
            PeopleDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            PeopleDataGridView.Columns.AddRange(new DataGridViewColumn[] { IdColumn, NameColumn, RoleColumn, TelephoneColumn, EmailColumn, DetailsColumn });
            PeopleDataGridView.Dock = DockStyle.Fill;
            PeopleDataGridView.Location = new Point(0, 70);
            PeopleDataGridView.MultiSelect = false;
            PeopleDataGridView.Name = "PeopleDataGridView";
            PeopleDataGridView.ReadOnly = true;
            PeopleDataGridView.RowHeadersVisible = false;
            PeopleDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            PeopleDataGridView.Size = new Size(1000, 508);
            PeopleDataGridView.TabIndex = 2;
            PeopleDataGridView.CellDoubleClick += PeopleDataGridView_CellDoubleClick;
            PeopleDataGridView.SelectionChanged += PeopleDataGridView_SelectionChanged;
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
            // TelephoneColumn
            //
            TelephoneColumn.HeaderText = "Telephone";
            TelephoneColumn.Name = "TelephoneColumn";
            TelephoneColumn.ReadOnly = true;
            TelephoneColumn.Width = 130;
            //
            // EmailColumn
            //
            EmailColumn.HeaderText = "Email";
            EmailColumn.Name = "EmailColumn";
            EmailColumn.ReadOnly = true;
            EmailColumn.Width = 220;
            //
            // DetailsColumn
            //
            DetailsColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DetailsColumn.HeaderText = "Details";
            DetailsColumn.Name = "DetailsColumn";
            DetailsColumn.ReadOnly = true;
            //
            // AppStatusStrip
            //
            AppStatusStrip.Items.AddRange(new ToolStripItem[] { StatusLabel });
            AppStatusStrip.Location = new Point(0, 578);
            AppStatusStrip.Name = "AppStatusStrip";
            AppStatusStrip.Size = new Size(1000, 22);
            AppStatusStrip.TabIndex = 3;
            //
            // StatusLabel
            //
            StatusLabel.Name = "StatusLabel";
            StatusLabel.Text = "Ready";
            //
            // MainForm
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 600);
            Controls.Add(PeopleDataGridView);
            Controls.Add(ToolbarPanel);
            Controls.Add(AppStatusStrip);
            Controls.Add(AppMenuStrip);
            MainMenuStrip = AppMenuStrip;
            MinimumSize = new Size(800, 400);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Festival Operations System";
            Load += MainForm_Load;
            AppMenuStrip.ResumeLayout(false);
            AppMenuStrip.PerformLayout();
            ToolbarPanel.ResumeLayout(false);
            ToolbarPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)PersonIdNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)PeopleDataGridView).EndInit();
            AppStatusStrip.ResumeLayout(false);
            AppStatusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip AppMenuStrip;
        private ToolStripMenuItem FileMenuItem;
        private ToolStripMenuItem ExitMenuItem;
        private ToolStripMenuItem RecordsMenuItem;
        private ToolStripMenuItem AddMenuItem;
        private ToolStripMenuItem EditMenuItem;
        private ToolStripMenuItem DeleteMenuItem;
        private ToolStripMenuItem ViewMenuItem;
        private ToolStripMenuItem AllRecordsMenuItem;
        private ToolStripMenuItem PerformersMenuItem;
        private ToolStripMenuItem CrewMenuItem;
        private ToolStripMenuItem VendorsMenuItem;
        private ToolStripSeparator ViewMenuSeparator;
        private ToolStripMenuItem DeletedRecordsMenuItem;
        private Panel ToolbarPanel;
        private Label RoleLabel;
        private ComboBox RoleComboBox;
        private Label PersonIdLabel;
        private NumericUpDown PersonIdNumericUpDown;
        private Button EditButton;
        private Button DeleteButton;
        private Button AddButton;
        private DataGridView PeopleDataGridView;
        private DataGridViewTextBoxColumn IdColumn;
        private DataGridViewTextBoxColumn NameColumn;
        private DataGridViewTextBoxColumn RoleColumn;
        private DataGridViewTextBoxColumn TelephoneColumn;
        private DataGridViewTextBoxColumn EmailColumn;
        private DataGridViewTextBoxColumn DetailsColumn;
        private StatusStrip AppStatusStrip;
        private ToolStripStatusLabel StatusLabel;
    }
}
