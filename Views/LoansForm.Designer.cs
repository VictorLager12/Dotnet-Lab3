namespace IkiminaManager.Views
{
    partial class LoansForm
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
            this.lblFund = new System.Windows.Forms.Label();
            this.lblMember = new System.Windows.Forms.Label();
            this.cboMember = new System.Windows.Forms.ComboBox();
            this.lblAmount = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.lblTerm = new System.Windows.Forms.Label();
            this.cboTerm = new System.Windows.Forms.ComboBox();
            this.btnCheck = new System.Windows.Forms.Button();
            this.btnApprove = new System.Windows.Forms.Button();
            this.lblResult = new System.Windows.Forms.Label();
            this.lblRepayTitle = new System.Windows.Forms.Label();
            this.lblSelected = new System.Windows.Forms.Label();
            this.lblRepay = new System.Windows.Forms.Label();
            this.txtRepayment = new System.Windows.Forms.TextBox();
            this.btnRepay = new System.Windows.Forms.Button();
            this.lblGridTitle = new System.Windows.Forms.Label();
            this.btnShowActive = new System.Windows.Forms.Button();
            this.btnShowOverdue = new System.Windows.Forms.Button();
            this.dgvLoans = new System.Windows.Forms.DataGridView();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoans)).BeginInit();
            this.SuspendLayout();
            //
            // lblTitle
            //
            this.lblTitle.AutoSize = false;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(31, 56, 100);
            this.lblTitle.Location = new System.Drawing.Point(0, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(960, 50);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Loans";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblFund
            //
            this.lblFund.AutoSize = false;
            this.lblFund.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblFund.ForeColor = System.Drawing.Color.FromArgb(31, 56, 100);
            this.lblFund.Location = new System.Drawing.Point(0, 60);
            this.lblFund.Name = "lblFund";
            this.lblFund.Size = new System.Drawing.Size(960, 26);
            this.lblFund.TabIndex = 1;
            this.lblFund.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblMember
            //
            this.lblMember.AutoSize = true;
            this.lblMember.Location = new System.Drawing.Point(30, 105);
            this.lblMember.Name = "lblMember";
            this.lblMember.TabIndex = 2;
            this.lblMember.Text = "Member:";
            //
            // cboMember
            //
            this.cboMember.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMember.Location = new System.Drawing.Point(160, 102);
            this.cboMember.Name = "cboMember";
            this.cboMember.Size = new System.Drawing.Size(310, 29);
            this.cboMember.TabIndex = 3;
            //
            // lblAmount
            //
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(30, 148);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.TabIndex = 4;
            this.lblAmount.Text = "Amount (RWF):";
            //
            // txtAmount
            //
            this.txtAmount.Location = new System.Drawing.Point(160, 145);
            this.txtAmount.MaxLength = 9;
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(200, 29);
            this.txtAmount.TabIndex = 5;
            this.txtAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AmountTextBox_KeyPress);
            //
            // lblTerm
            //
            this.lblTerm.AutoSize = true;
            this.lblTerm.Location = new System.Drawing.Point(30, 191);
            this.lblTerm.Name = "lblTerm";
            this.lblTerm.TabIndex = 6;
            this.lblTerm.Text = "Term (months):";
            //
            // cboTerm
            //
            this.cboTerm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTerm.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6"});
            this.cboTerm.Location = new System.Drawing.Point(160, 188);
            this.cboTerm.Name = "cboTerm";
            this.cboTerm.Size = new System.Drawing.Size(100, 29);
            this.cboTerm.TabIndex = 7;
            //
            // btnCheck
            //
            this.btnCheck.BackColor = System.Drawing.Color.FromArgb(73, 80, 87);
            this.btnCheck.FlatAppearance.BorderSize = 0;
            this.btnCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheck.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnCheck.ForeColor = System.Drawing.Color.White;
            this.btnCheck.Location = new System.Drawing.Point(30, 235);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(215, 40);
            this.btnCheck.TabIndex = 8;
            this.btnCheck.Text = "Check eligibility";
            this.btnCheck.UseVisualStyleBackColor = false;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            //
            // btnApprove
            //
            this.btnApprove.BackColor = System.Drawing.Color.FromArgb(0, 102, 204);
            this.btnApprove.FlatAppearance.BorderSize = 0;
            this.btnApprove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApprove.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnApprove.ForeColor = System.Drawing.Color.White;
            this.btnApprove.Location = new System.Drawing.Point(255, 235);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(215, 40);
            this.btnApprove.TabIndex = 9;
            this.btnApprove.Text = "Approve loan";
            this.btnApprove.UseVisualStyleBackColor = false;
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
            //
            // lblResult
            //
            this.lblResult.AutoSize = false;
            this.lblResult.BackColor = System.Drawing.Color.FromArgb(226, 234, 246);
            this.lblResult.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblResult.Location = new System.Drawing.Point(30, 285);
            this.lblResult.Name = "lblResult";
            this.lblResult.Padding = new System.Windows.Forms.Padding(10, 8, 10, 8);
            this.lblResult.Size = new System.Drawing.Size(440, 110);
            this.lblResult.TabIndex = 10;
            //
            // lblRepayTitle
            //
            this.lblRepayTitle.AutoSize = true;
            this.lblRepayTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblRepayTitle.ForeColor = System.Drawing.Color.FromArgb(31, 56, 100);
            this.lblRepayTitle.Location = new System.Drawing.Point(500, 105);
            this.lblRepayTitle.Name = "lblRepayTitle";
            this.lblRepayTitle.TabIndex = 11;
            this.lblRepayTitle.Text = "Record a repayment";
            //
            // lblSelected
            //
            this.lblSelected.AutoSize = false;
            this.lblSelected.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblSelected.Location = new System.Drawing.Point(500, 140);
            this.lblSelected.Name = "lblSelected";
            this.lblSelected.Size = new System.Drawing.Size(430, 60);
            this.lblSelected.TabIndex = 12;
            this.lblSelected.Text = "Click a loan in the table below to select it.";
            //
            // lblRepay
            //
            this.lblRepay.AutoSize = true;
            this.lblRepay.Location = new System.Drawing.Point(500, 215);
            this.lblRepay.Name = "lblRepay";
            this.lblRepay.TabIndex = 13;
            this.lblRepay.Text = "Repayment (RWF):";
            //
            // txtRepayment
            //
            this.txtRepayment.Location = new System.Drawing.Point(690, 212);
            this.txtRepayment.MaxLength = 9;
            this.txtRepayment.Name = "txtRepayment";
            this.txtRepayment.Size = new System.Drawing.Size(240, 29);
            this.txtRepayment.TabIndex = 14;
            this.txtRepayment.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AmountTextBox_KeyPress);
            //
            // btnRepay
            //
            this.btnRepay.BackColor = System.Drawing.Color.FromArgb(0, 102, 204);
            this.btnRepay.FlatAppearance.BorderSize = 0;
            this.btnRepay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRepay.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnRepay.ForeColor = System.Drawing.Color.White;
            this.btnRepay.Location = new System.Drawing.Point(500, 260);
            this.btnRepay.Name = "btnRepay";
            this.btnRepay.Size = new System.Drawing.Size(430, 40);
            this.btnRepay.TabIndex = 15;
            this.btnRepay.Text = "Record repayment";
            this.btnRepay.UseVisualStyleBackColor = false;
            this.btnRepay.Click += new System.EventHandler(this.btnRepay_Click);
            //
            // lblGridTitle
            //
            this.lblGridTitle.AutoSize = true;
            this.lblGridTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblGridTitle.ForeColor = System.Drawing.Color.FromArgb(31, 56, 100);
            this.lblGridTitle.Location = new System.Drawing.Point(30, 407);
            this.lblGridTitle.Name = "lblGridTitle";
            this.lblGridTitle.TabIndex = 16;
            this.lblGridTitle.Text = "Active loans";
            //
            // btnShowActive
            //
            this.btnShowActive.BackColor = System.Drawing.Color.FromArgb(73, 80, 87);
            this.btnShowActive.FlatAppearance.BorderSize = 0;
            this.btnShowActive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowActive.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnShowActive.ForeColor = System.Drawing.Color.White;
            this.btnShowActive.Location = new System.Drawing.Point(610, 400);
            this.btnShowActive.Name = "btnShowActive";
            this.btnShowActive.Size = new System.Drawing.Size(150, 34);
            this.btnShowActive.TabIndex = 17;
            this.btnShowActive.Text = "Active loans";
            this.btnShowActive.UseVisualStyleBackColor = false;
            this.btnShowActive.Click += new System.EventHandler(this.btnShowActive_Click);
            //
            // btnShowOverdue
            //
            this.btnShowOverdue.BackColor = System.Drawing.Color.FromArgb(176, 0, 32);
            this.btnShowOverdue.FlatAppearance.BorderSize = 0;
            this.btnShowOverdue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowOverdue.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnShowOverdue.ForeColor = System.Drawing.Color.White;
            this.btnShowOverdue.Location = new System.Drawing.Point(770, 400);
            this.btnShowOverdue.Name = "btnShowOverdue";
            this.btnShowOverdue.Size = new System.Drawing.Size(160, 34);
            this.btnShowOverdue.TabIndex = 18;
            this.btnShowOverdue.Text = "Overdue report";
            this.btnShowOverdue.UseVisualStyleBackColor = false;
            this.btnShowOverdue.Click += new System.EventHandler(this.btnShowOverdue_Click);
            //
            // dgvLoans
            //
            this.dgvLoans.AllowUserToAddRows = false;
            this.dgvLoans.AllowUserToDeleteRows = false;
            this.dgvLoans.AllowUserToResizeRows = false;
            this.dgvLoans.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLoans.BackgroundColor = System.Drawing.Color.White;
            this.dgvLoans.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLoans.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.dgvLoans.Location = new System.Drawing.Point(30, 440);
            this.dgvLoans.MultiSelect = false;
            this.dgvLoans.Name = "dgvLoans";
            this.dgvLoans.ReadOnly = true;
            this.dgvLoans.RowHeadersVisible = false;
            this.dgvLoans.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLoans.Size = new System.Drawing.Size(900, 155);
            this.dgvLoans.TabIndex = 19;
            this.dgvLoans.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLoans_CellClick);
            //
            // btnBack
            //
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(73, 80, 87);
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(30, 610);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(200, 42);
            this.btnBack.TabIndex = 20;
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
            this.btnLogout.Location = new System.Drawing.Point(730, 610);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(200, 42);
            this.btnLogout.TabIndex = 21;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            //
            // LoansForm
            //
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(244, 247, 250);
            this.ClientSize = new System.Drawing.Size(960, 665);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblFund);
            this.Controls.Add(this.lblMember);
            this.Controls.Add(this.cboMember);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.lblTerm);
            this.Controls.Add(this.cboTerm);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.btnApprove);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.lblRepayTitle);
            this.Controls.Add(this.lblSelected);
            this.Controls.Add(this.lblRepay);
            this.Controls.Add(this.txtRepayment);
            this.Controls.Add(this.btnRepay);
            this.Controls.Add(this.lblGridTitle);
            this.Controls.Add(this.btnShowActive);
            this.Controls.Add(this.btnShowOverdue);
            this.Controls.Add(this.dgvLoans);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnLogout);
            this.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.ForeColor = System.Drawing.Color.FromArgb(33, 37, 41);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "LoansForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Loans";
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoans)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblFund;
        private System.Windows.Forms.Label lblMember;
        private System.Windows.Forms.ComboBox cboMember;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label lblTerm;
        private System.Windows.Forms.ComboBox cboTerm;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Button btnApprove;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label lblRepayTitle;
        private System.Windows.Forms.Label lblSelected;
        private System.Windows.Forms.Label lblRepay;
        private System.Windows.Forms.TextBox txtRepayment;
        private System.Windows.Forms.Button btnRepay;
        private System.Windows.Forms.Label lblGridTitle;
        private System.Windows.Forms.Button btnShowActive;
        private System.Windows.Forms.Button btnShowOverdue;
        private System.Windows.Forms.DataGridView dgvLoans;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnLogout;
    }
}