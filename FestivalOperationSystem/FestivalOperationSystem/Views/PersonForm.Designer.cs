namespace FestivalOperationSystem.Views
{
    partial class PersonForm
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
            components = new System.ComponentModel.Container();
            RoleLabel = new Label();
            RoleComboBox = new ComboBox();
            NameLabel = new Label();
            NameTextBox = new TextBox();
            TelephoneLabel = new Label();
            TelephoneTextBox = new TextBox();
            EmailLabel = new Label();
            EmailTextBox = new TextBox();
            PerformerGroupBox = new GroupBox();
            FeeLabel = new Label();
            FeeNumericUpDown = new NumericUpDown();
            Genre1Label = new Label();
            Genre1ComboBox = new ComboBox();
            Genre2Label = new Label();
            Genre2ComboBox = new ComboBox();
            CrewGroupBox = new GroupBox();
            HourlyRateLabel = new Label();
            HourlyRateNumericUpDown = new NumericUpDown();
            EmploymentTypeLabel = new Label();
            EmploymentTypeComboBox = new ComboBox();
            WeeklyHoursLabel = new Label();
            WeeklyHoursNumericUpDown = new NumericUpDown();
            VendorGroupBox = new GroupBox();
            StallNameLabel = new Label();
            StallNameTextBox = new TextBox();
            Category1Label = new Label();
            Category1TextBox = new TextBox();
            Category2Label = new Label();
            Category2TextBox = new TextBox();
            Category3Label = new Label();
            Category3TextBox = new TextBox();
            SaveButton = new Button();
            CancelEditButton = new Button();
            InputErrorProvider = new ErrorProvider(components);
            PerformerGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)FeeNumericUpDown).BeginInit();
            CrewGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)HourlyRateNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)WeeklyHoursNumericUpDown).BeginInit();
            VendorGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)InputErrorProvider).BeginInit();
            SuspendLayout();
            //
            // RoleLabel
            //
            RoleLabel.AutoSize = true;
            RoleLabel.Location = new Point(20, 23);
            RoleLabel.Name = "RoleLabel";
            RoleLabel.Size = new Size(33, 15);
            RoleLabel.TabIndex = 0;
            RoleLabel.Text = "Role:";
            //
            // RoleComboBox
            //
            RoleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            RoleComboBox.Location = new Point(120, 20);
            RoleComboBox.Name = "RoleComboBox";
            RoleComboBox.Size = new Size(150, 23);
            RoleComboBox.TabIndex = 1;
            RoleComboBox.SelectedIndexChanged += RoleComboBox_SelectedIndexChanged;
            //
            // NameLabel
            //
            NameLabel.AutoSize = true;
            NameLabel.Location = new Point(20, 58);
            NameLabel.Name = "NameLabel";
            NameLabel.Size = new Size(42, 15);
            NameLabel.TabIndex = 2;
            NameLabel.Text = "Name:";
            //
            // NameTextBox
            //
            NameTextBox.Location = new Point(120, 55);
            NameTextBox.MaxLength = 100;
            NameTextBox.Name = "NameTextBox";
            NameTextBox.Size = new Size(300, 23);
            NameTextBox.TabIndex = 3;
            //
            // TelephoneLabel
            //
            TelephoneLabel.AutoSize = true;
            TelephoneLabel.Location = new Point(20, 93);
            TelephoneLabel.Name = "TelephoneLabel";
            TelephoneLabel.Size = new Size(64, 15);
            TelephoneLabel.TabIndex = 4;
            TelephoneLabel.Text = "Telephone:";
            //
            // TelephoneTextBox
            //
            TelephoneTextBox.Location = new Point(120, 90);
            TelephoneTextBox.MaxLength = 20;
            TelephoneTextBox.Name = "TelephoneTextBox";
            TelephoneTextBox.Size = new Size(180, 23);
            TelephoneTextBox.TabIndex = 5;
            //
            // EmailLabel
            //
            EmailLabel.AutoSize = true;
            EmailLabel.Location = new Point(20, 128);
            EmailLabel.Name = "EmailLabel";
            EmailLabel.Size = new Size(39, 15);
            EmailLabel.TabIndex = 6;
            EmailLabel.Text = "Email:";
            //
            // EmailTextBox
            //
            EmailTextBox.Location = new Point(120, 125);
            EmailTextBox.MaxLength = 255;
            EmailTextBox.Name = "EmailTextBox";
            EmailTextBox.Size = new Size(300, 23);
            EmailTextBox.TabIndex = 7;
            EmailTextBox.Leave += EmailTextBox_Leave;
            //
            // PerformerGroupBox
            //
            PerformerGroupBox.Controls.Add(FeeLabel);
            PerformerGroupBox.Controls.Add(FeeNumericUpDown);
            PerformerGroupBox.Controls.Add(Genre1Label);
            PerformerGroupBox.Controls.Add(Genre1ComboBox);
            PerformerGroupBox.Controls.Add(Genre2Label);
            PerformerGroupBox.Controls.Add(Genre2ComboBox);
            PerformerGroupBox.Location = new Point(20, 165);
            PerformerGroupBox.Name = "PerformerGroupBox";
            PerformerGroupBox.Size = new Size(430, 180);
            PerformerGroupBox.TabIndex = 8;
            PerformerGroupBox.TabStop = false;
            PerformerGroupBox.Text = "Performer";
            //
            // FeeLabel
            //
            FeeLabel.AutoSize = true;
            FeeLabel.Location = new Point(15, 33);
            FeeLabel.Name = "FeeLabel";
            FeeLabel.Size = new Size(28, 15);
            FeeLabel.TabIndex = 0;
            FeeLabel.Text = "Fee:";
            //
            // FeeNumericUpDown
            //
            FeeNumericUpDown.DecimalPlaces = 2;
            FeeNumericUpDown.Location = new Point(110, 30);
            FeeNumericUpDown.Maximum = new decimal(new int[] { 99999999, 0, 0, 0 });
            FeeNumericUpDown.Name = "FeeNumericUpDown";
            FeeNumericUpDown.Size = new Size(150, 23);
            FeeNumericUpDown.TabIndex = 1;
            FeeNumericUpDown.ThousandsSeparator = true;
            //
            // Genre1Label
            //
            Genre1Label.AutoSize = true;
            Genre1Label.Location = new Point(15, 68);
            Genre1Label.Name = "Genre1Label";
            Genre1Label.Size = new Size(51, 15);
            Genre1Label.TabIndex = 2;
            Genre1Label.Text = "Genre 1:";
            //
            // Genre1ComboBox
            //
            Genre1ComboBox.Location = new Point(110, 65);
            Genre1ComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            Genre1ComboBox.Name = "Genre1ComboBox";
            Genre1ComboBox.Size = new Size(200, 23);
            Genre1ComboBox.TabIndex = 3;
            //
            // Genre2Label
            //
            Genre2Label.AutoSize = true;
            Genre2Label.Location = new Point(15, 103);
            Genre2Label.Name = "Genre2Label";
            Genre2Label.Size = new Size(51, 15);
            Genre2Label.TabIndex = 4;
            Genre2Label.Text = "Genre 2:";
            //
            // Genre2ComboBox
            //
            Genre2ComboBox.Location = new Point(110, 100);
            Genre2ComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            Genre2ComboBox.Name = "Genre2ComboBox";
            Genre2ComboBox.Size = new Size(200, 23);
            Genre2ComboBox.TabIndex = 5;
            //
            // CrewGroupBox
            //
            CrewGroupBox.Controls.Add(HourlyRateLabel);
            CrewGroupBox.Controls.Add(HourlyRateNumericUpDown);
            CrewGroupBox.Controls.Add(EmploymentTypeLabel);
            CrewGroupBox.Controls.Add(EmploymentTypeComboBox);
            CrewGroupBox.Controls.Add(WeeklyHoursLabel);
            CrewGroupBox.Controls.Add(WeeklyHoursNumericUpDown);
            CrewGroupBox.Location = new Point(20, 165);
            CrewGroupBox.Name = "CrewGroupBox";
            CrewGroupBox.Size = new Size(430, 180);
            CrewGroupBox.TabIndex = 9;
            CrewGroupBox.TabStop = false;
            CrewGroupBox.Text = "Crew";
            CrewGroupBox.Visible = false;
            //
            // HourlyRateLabel
            //
            HourlyRateLabel.AutoSize = true;
            HourlyRateLabel.Location = new Point(15, 33);
            HourlyRateLabel.Name = "HourlyRateLabel";
            HourlyRateLabel.Size = new Size(70, 15);
            HourlyRateLabel.TabIndex = 0;
            HourlyRateLabel.Text = "Hourly rate:";
            //
            // HourlyRateNumericUpDown
            //
            HourlyRateNumericUpDown.DecimalPlaces = 2;
            HourlyRateNumericUpDown.Location = new Point(130, 30);
            HourlyRateNumericUpDown.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            HourlyRateNumericUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 131072 });
            HourlyRateNumericUpDown.Name = "HourlyRateNumericUpDown";
            HourlyRateNumericUpDown.Size = new Size(150, 23);
            HourlyRateNumericUpDown.TabIndex = 1;
            HourlyRateNumericUpDown.Value = new decimal(new int[] { 15, 0, 0, 0 });
            //
            // EmploymentTypeLabel
            //
            EmploymentTypeLabel.AutoSize = true;
            EmploymentTypeLabel.Location = new Point(15, 68);
            EmploymentTypeLabel.Name = "EmploymentTypeLabel";
            EmploymentTypeLabel.Size = new Size(103, 15);
            EmploymentTypeLabel.TabIndex = 2;
            EmploymentTypeLabel.Text = "Employment type:";
            //
            // EmploymentTypeComboBox
            //
            EmploymentTypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            EmploymentTypeComboBox.Location = new Point(130, 65);
            EmploymentTypeComboBox.Name = "EmploymentTypeComboBox";
            EmploymentTypeComboBox.Size = new Size(150, 23);
            EmploymentTypeComboBox.TabIndex = 3;
            EmploymentTypeComboBox.SelectedIndexChanged += EmploymentTypeComboBox_SelectedIndexChanged;
            //
            // WeeklyHoursLabel
            //
            WeeklyHoursLabel.AutoSize = true;
            WeeklyHoursLabel.Location = new Point(15, 103);
            WeeklyHoursLabel.Name = "WeeklyHoursLabel";
            WeeklyHoursLabel.Size = new Size(80, 15);
            WeeklyHoursLabel.TabIndex = 4;
            WeeklyHoursLabel.Text = "Weekly hours:";
            //
            // WeeklyHoursNumericUpDown
            //
            WeeklyHoursNumericUpDown.Location = new Point(130, 100);
            WeeklyHoursNumericUpDown.Maximum = new decimal(new int[] { 40, 0, 0, 0 });
            WeeklyHoursNumericUpDown.Minimum = new decimal(new int[] { 25, 0, 0, 0 });
            WeeklyHoursNumericUpDown.Name = "WeeklyHoursNumericUpDown";
            WeeklyHoursNumericUpDown.Size = new Size(80, 23);
            WeeklyHoursNumericUpDown.TabIndex = 5;
            WeeklyHoursNumericUpDown.Value = new decimal(new int[] { 40, 0, 0, 0 });
            //
            // VendorGroupBox
            //
            VendorGroupBox.Controls.Add(StallNameLabel);
            VendorGroupBox.Controls.Add(StallNameTextBox);
            VendorGroupBox.Controls.Add(Category1Label);
            VendorGroupBox.Controls.Add(Category1TextBox);
            VendorGroupBox.Controls.Add(Category2Label);
            VendorGroupBox.Controls.Add(Category2TextBox);
            VendorGroupBox.Controls.Add(Category3Label);
            VendorGroupBox.Controls.Add(Category3TextBox);
            VendorGroupBox.Location = new Point(20, 165);
            VendorGroupBox.Name = "VendorGroupBox";
            VendorGroupBox.Size = new Size(430, 180);
            VendorGroupBox.TabIndex = 10;
            VendorGroupBox.TabStop = false;
            VendorGroupBox.Text = "Vendor";
            VendorGroupBox.Visible = false;
            //
            // StallNameLabel
            //
            StallNameLabel.AutoSize = true;
            StallNameLabel.Location = new Point(15, 33);
            StallNameLabel.Name = "StallNameLabel";
            StallNameLabel.Size = new Size(67, 15);
            StallNameLabel.TabIndex = 0;
            StallNameLabel.Text = "Stall name:";
            //
            // StallNameTextBox
            //
            StallNameTextBox.Location = new Point(110, 30);
            StallNameTextBox.MaxLength = 100;
            StallNameTextBox.Name = "StallNameTextBox";
            StallNameTextBox.Size = new Size(290, 23);
            StallNameTextBox.TabIndex = 1;
            //
            // Category1Label
            //
            Category1Label.AutoSize = true;
            Category1Label.Location = new Point(15, 68);
            Category1Label.Name = "Category1Label";
            Category1Label.Size = new Size(67, 15);
            Category1Label.TabIndex = 2;
            Category1Label.Text = "Category 1:";
            //
            // Category1TextBox
            //
            Category1TextBox.Location = new Point(110, 65);
            Category1TextBox.MaxLength = 50;
            Category1TextBox.Name = "Category1TextBox";
            Category1TextBox.Size = new Size(290, 23);
            Category1TextBox.TabIndex = 3;
            //
            // Category2Label
            //
            Category2Label.AutoSize = true;
            Category2Label.Location = new Point(15, 103);
            Category2Label.Name = "Category2Label";
            Category2Label.Size = new Size(67, 15);
            Category2Label.TabIndex = 4;
            Category2Label.Text = "Category 2:";
            //
            // Category2TextBox
            //
            Category2TextBox.Location = new Point(110, 100);
            Category2TextBox.MaxLength = 50;
            Category2TextBox.Name = "Category2TextBox";
            Category2TextBox.Size = new Size(290, 23);
            Category2TextBox.TabIndex = 5;
            //
            // Category3Label
            //
            Category3Label.AutoSize = true;
            Category3Label.Location = new Point(15, 138);
            Category3Label.Name = "Category3Label";
            Category3Label.Size = new Size(67, 15);
            Category3Label.TabIndex = 6;
            Category3Label.Text = "Category 3:";
            //
            // Category3TextBox
            //
            Category3TextBox.Location = new Point(110, 135);
            Category3TextBox.MaxLength = 50;
            Category3TextBox.Name = "Category3TextBox";
            Category3TextBox.Size = new Size(290, 23);
            Category3TextBox.TabIndex = 7;
            //
            // SaveButton
            //
            SaveButton.Location = new Point(264, 362);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(90, 30);
            SaveButton.TabIndex = 11;
            SaveButton.Text = "&Save";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            //
            // CancelEditButton
            //
            CancelEditButton.DialogResult = DialogResult.Cancel;
            CancelEditButton.Location = new Point(360, 362);
            CancelEditButton.Name = "CancelEditButton";
            CancelEditButton.Size = new Size(90, 30);
            CancelEditButton.TabIndex = 12;
            CancelEditButton.Text = "Cancel";
            CancelEditButton.UseVisualStyleBackColor = true;
            //
            // InputErrorProvider
            //
            InputErrorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            InputErrorProvider.ContainerControl = this;
            //
            // PersonForm
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = CancelEditButton;
            ClientSize = new Size(474, 410);
            Controls.Add(RoleLabel);
            Controls.Add(RoleComboBox);
            Controls.Add(NameLabel);
            Controls.Add(NameTextBox);
            Controls.Add(TelephoneLabel);
            Controls.Add(TelephoneTextBox);
            Controls.Add(EmailLabel);
            Controls.Add(EmailTextBox);
            Controls.Add(PerformerGroupBox);
            Controls.Add(CrewGroupBox);
            Controls.Add(VendorGroupBox);
            Controls.Add(SaveButton);
            Controls.Add(CancelEditButton);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PersonForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Record";
            PerformerGroupBox.ResumeLayout(false);
            PerformerGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)FeeNumericUpDown).EndInit();
            CrewGroupBox.ResumeLayout(false);
            CrewGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)HourlyRateNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)WeeklyHoursNumericUpDown).EndInit();
            VendorGroupBox.ResumeLayout(false);
            VendorGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)InputErrorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label RoleLabel;
        private ComboBox RoleComboBox;
        private Label NameLabel;
        private TextBox NameTextBox;
        private Label TelephoneLabel;
        private TextBox TelephoneTextBox;
        private Label EmailLabel;
        private TextBox EmailTextBox;
        private GroupBox PerformerGroupBox;
        private Label FeeLabel;
        private NumericUpDown FeeNumericUpDown;
        private Label Genre1Label;
        private ComboBox Genre1ComboBox;
        private Label Genre2Label;
        private ComboBox Genre2ComboBox;
        private GroupBox CrewGroupBox;
        private Label HourlyRateLabel;
        private NumericUpDown HourlyRateNumericUpDown;
        private Label EmploymentTypeLabel;
        private ComboBox EmploymentTypeComboBox;
        private Label WeeklyHoursLabel;
        private NumericUpDown WeeklyHoursNumericUpDown;
        private GroupBox VendorGroupBox;
        private Label StallNameLabel;
        private TextBox StallNameTextBox;
        private Label Category1Label;
        private TextBox Category1TextBox;
        private Label Category2Label;
        private TextBox Category2TextBox;
        private Label Category3Label;
        private TextBox Category3TextBox;
        private Button SaveButton;
        private Button CancelEditButton;
        private ErrorProvider InputErrorProvider;
    }
}
