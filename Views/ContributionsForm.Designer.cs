namespace IkiminaManager.Views
{
    partial class ContributionsForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblMember = new System.Windows.Forms.Label();
            this.cboMember = new System.Windows.Forms.ComboBox();
            this.lblAmount = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblMemberTotal = new System.Windows.Forms.Label();
            this.lblGroupTotal = new System.Windows.Forms.Label();
            this.lblHistory = new System.Windows.Forms.Label();
            this.dgvContributions = new System.Windows.Forms.DataGridView();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContributions)).BeginInit();
            this.SuspendLayout();
            //
            // lblTitle
            //
            this.lblTitle.AutoSize = false;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(31, 56, 100);
            this.lblTitle.Location = new System.Drawing.Point(0, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(780, 50);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Contributions";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblMember
            //
            this.lblMember.AutoSize = true;
            this.lblMember.Location = new System.Drawing.Point(30, 80);
            this.lblMember.Name = "lblMember";
            this.lblMember.TabIndex = 1;
            this.lblMember.Text = "Member:";
            //
            // cboMember
            //
            this.cboMember.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMember.Location = new System.Drawing.Point(190, 77);
            this.cboMember.Name = "cboMember";
            this.cboMember.Size = new System.Drawing.Size(360, 29);
            this.cboMember.TabIndex = 2;
            this.cboMember.SelectedIndexChanged += new System.EventHandler(this.cboMember_SelectedIndexChanged);
            //
            // lblAmount
            //
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(30, 125);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.TabIndex = 3;
            this.lblAmount.Text = "Amount (RWF):";
            //
            // txtAmount
            //
            this.txtAmount.Location = new System.Drawing.Point(190, 122);
            this.txtAmount.MaxLength = 9;
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(200, 29);
            this.txtAmount.TabIndex = 4;
            this.txtAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAmount_KeyPress);
            //
            // lblDate
            //
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(30, 170);
            this.lblDate.Name = "lblDate";
            this.lblDate.TabIndex = 5;
            this.lblDate.Text = "Date:";
            //
            // dtpDate
            //
            this.dtpDate.CustomFormat = "yyyy-MM-dd";
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(190, 167);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(200, 29);
            this.dtpDate.TabIndex = 6;
            //
            // btnSave
            //
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(0, 102, 204);
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(190, 215);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(200, 42);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save contribution";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            //
            // lblMemberTotal
            //
            this.lblMemberTotal.AutoSize = false;
            this.lblMemberTotal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblMemberTotal.Location = new System.Drawing.Point(30, 275);
            this.lblMemberTotal.Name = "lblMemberTotal";
            this.lblMemberTotal.Size = new System.Drawing.Size(720, 28);
            this.lblMemberTotal.TabIndex = 8;
            //
            // lblGroupTotal
            //
            this.lblGroupTotal.AutoSize = false;
            this.lblGroupTotal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblGroupTotal.ForeColor = System.Drawing.Color.FromArgb(31, 56, 100);
            this.lblGroupTotal.Location = new System.Drawing.Point(30, 305);
            this.lblGroupTotal.Name = "lblGroupTotal";
            this.lblGroupTotal.Size = new System.Drawing.Size(720, 28);
            this.lblGroupTotal.TabIndex = 9;
            //
            // lblHistory
            //
            this.lblHistory.AutoSize = true;
            this.lblHistory.Location = new System.Drawing.Point(30, 345);
            this.lblHistory.Name = "lblHistory";
            this.lblHistory.TabIndex = 10;
            this.lblHistory.Text = "Contribution history (newest first):";
            //
            // dgvContributions
            //
            this.dgvContributions.AllowUserToAddRows = false;
            this.dgvContributions.AllowUserToDeleteRows = false;
            this.dgvContributions.AllowUserToResizeRows = false;
            this.dgvContributions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvContributions.BackgroundColor = System.Drawing.Color.White;
            this.dgvContributions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvContributions.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.dgvContributions.Location = new System.Drawing.Point(30, 378);
            this.dgvContributions.MultiSelect = false;
            this.dgvContributions.Name = "dgvContributions";
            this.dgvContributions.ReadOnly = true;
            this.dgvContributions.RowHeadersVisible = false;
            this.dgvContributions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvContributions.Size = new System.Drawing.Size(720, 190);
            this.dgvContributions.TabIndex = 11;
            //
            // btnBack
            //
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(73, 80, 87);
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(30, 590);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(200, 45);
            this.btnBack.TabIndex = 12;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            //
            // btnLogout
            //
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(176, 0, 32);
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(550, 590);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(200, 45);
            this.btnLogout.TabIndex = 13;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            //
            // ContributionsForm
            //
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(244, 247, 250);
            this.ClientSize = new System.Drawing.Size(780, 655);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblMember);
            this.Controls.Add(this.cboMember);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblMemberTotal);
            this.Controls.Add(this.lblGroupTotal);
            this.Controls.Add(this.lblHistory);
            this.Controls.Add(this.dgvContributions);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnLogout);
            this.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.ForeColor = System.Drawing.Color.FromArgb(33, 37, 41);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ContributionsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Contributions";
            ((System.ComponentModel.ISupportInitialize)(this.dgvContributions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblMember;
        private System.Windows.Forms.ComboBox cboMember;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblMemberTotal;
        private System.Windows.Forms.Label lblGroupTotal;
        private System.Windows.Forms.Label lblHistory;
        private System.Windows.Forms.DataGridView dgvContributions;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnLogout;
    }
}