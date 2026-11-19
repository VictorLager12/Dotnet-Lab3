namespace IkiminaManager.Views
{
    partial class ChooseForm
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
            this.lblSummaryTitle = new System.Windows.Forms.Label();
            this.lblContributionsCaption = new System.Windows.Forms.Label();
            this.lblContributionsValue = new System.Windows.Forms.Label();
            this.lblLoansCaption = new System.Windows.Forms.Label();
            this.lblLoansValue = new System.Windows.Forms.Label();
            this.lblRepaymentsCaption = new System.Windows.Forms.Label();
            this.lblRepaymentsValue = new System.Windows.Forms.Label();
            this.lblAvailableCaption = new System.Windows.Forms.Label();
            this.lblAvailableValue = new System.Windows.Forms.Label();
            this.btnMembers = new System.Windows.Forms.Button();
            this.btnContributions = new System.Windows.Forms.Button();
            this.btnLoans = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // lblTitle
            //
            this.lblTitle.AutoSize = false;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(31, 56, 100);
            this.lblTitle.Location = new System.Drawing.Point(0, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(520, 50);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Choose";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblSummaryTitle
            //
            this.lblSummaryTitle.AutoSize = true;
            this.lblSummaryTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblSummaryTitle.ForeColor = System.Drawing.Color.FromArgb(46, 92, 154);
            this.lblSummaryTitle.Location = new System.Drawing.Point(50, 80);
            this.lblSummaryTitle.Name = "lblSummaryTitle";
            this.lblSummaryTitle.TabIndex = 1;
            this.lblSummaryTitle.Text = "Fund summary";
            //
            // lblContributionsCaption
            //
            this.lblContributionsCaption.AutoSize = false;
            this.lblContributionsCaption.Location = new System.Drawing.Point(50, 115);
            this.lblContributionsCaption.Name = "lblContributionsCaption";
            this.lblContributionsCaption.Size = new System.Drawing.Size(200, 26);
            this.lblContributionsCaption.TabIndex = 2;
            this.lblContributionsCaption.Text = "Total contributions:";
            this.lblContributionsCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // lblContributionsValue
            //
            this.lblContributionsValue.AutoSize = false;
            this.lblContributionsValue.Location = new System.Drawing.Point(250, 115);
            this.lblContributionsValue.Name = "lblContributionsValue";
            this.lblContributionsValue.Size = new System.Drawing.Size(220, 26);
            this.lblContributionsValue.TabIndex = 3;
            this.lblContributionsValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // lblLoansCaption
            //
            this.lblLoansCaption.AutoSize = false;
            this.lblLoansCaption.Location = new System.Drawing.Point(50, 147);
            this.lblLoansCaption.Name = "lblLoansCaption";
            this.lblLoansCaption.Size = new System.Drawing.Size(200, 26);
            this.lblLoansCaption.TabIndex = 4;
            this.lblLoansCaption.Text = "Total loans disbursed:";
            this.lblLoansCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // lblLoansValue
            //
            this.lblLoansValue.AutoSize = false;
            this.lblLoansValue.Location = new System.Drawing.Point(250, 147);
            this.lblLoansValue.Name = "lblLoansValue";
            this.lblLoansValue.Size = new System.Drawing.Size(220, 26);
            this.lblLoansValue.TabIndex = 5;
            this.lblLoansValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // lblRepaymentsCaption
            //
            this.lblRepaymentsCaption.AutoSize = false;
            this.lblRepaymentsCaption.Location = new System.Drawing.Point(50, 179);
            this.lblRepaymentsCaption.Name = "lblRepaymentsCaption";
            this.lblRepaymentsCaption.Size = new System.Drawing.Size(200, 26);
            this.lblRepaymentsCaption.TabIndex = 6;
            this.lblRepaymentsCaption.Text = "Total repayments:";
            this.lblRepaymentsCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // lblRepaymentsValue
            //
            this.lblRepaymentsValue.AutoSize = false;
            this.lblRepaymentsValue.Location = new System.Drawing.Point(250, 179);
            this.lblRepaymentsValue.Name = "lblRepaymentsValue";
            this.lblRepaymentsValue.Size = new System.Drawing.Size(220, 26);
            this.lblRepaymentsValue.TabIndex = 7;
            this.lblRepaymentsValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // lblAvailableCaption
            //
            this.lblAvailableCaption.AutoSize = false;
            this.lblAvailableCaption.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblAvailableCaption.ForeColor = System.Drawing.Color.FromArgb(31, 56, 100);
            this.lblAvailableCaption.Location = new System.Drawing.Point(50, 218);
            this.lblAvailableCaption.Name = "lblAvailableCaption";
            this.lblAvailableCaption.Size = new System.Drawing.Size(200, 26);
            this.lblAvailableCaption.TabIndex = 8;
            this.lblAvailableCaption.Text = "Available Fund:";
            this.lblAvailableCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // lblAvailableValue
            //
            this.lblAvailableValue.AutoSize = false;
            this.lblAvailableValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblAvailableValue.ForeColor = System.Drawing.Color.FromArgb(31, 56, 100);
            this.lblAvailableValue.Location = new System.Drawing.Point(250, 218);
            this.lblAvailableValue.Name = "lblAvailableValue";
            this.lblAvailableValue.Size = new System.Drawing.Size(220, 26);
            this.lblAvailableValue.TabIndex = 9;
            this.lblAvailableValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // btnMembers
            //
            this.btnMembers.BackColor = System.Drawing.Color.FromArgb(0, 102, 204);
            this.btnMembers.FlatAppearance.BorderSize = 0;
            this.btnMembers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMembers.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.btnMembers.ForeColor = System.Drawing.Color.White;
            this.btnMembers.Location = new System.Drawing.Point(60, 280);
            this.btnMembers.Name = "btnMembers";
            this.btnMembers.Size = new System.Drawing.Size(400, 48);
            this.btnMembers.TabIndex = 10;
            this.btnMembers.Text = "Members";
            this.btnMembers.UseVisualStyleBackColor = false;
            this.btnMembers.Click += new System.EventHandler(this.btnMembers_Click);
            //
            // btnContributions
            //
            this.btnContributions.BackColor = System.Drawing.Color.FromArgb(0, 102, 204);
            this.btnContributions.FlatAppearance.BorderSize = 0;
            this.btnContributions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnContributions.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.btnContributions.ForeColor = System.Drawing.Color.White;
            this.btnContributions.Location = new System.Drawing.Point(60, 338);
            this.btnContributions.Name = "btnContributions";
            this.btnContributions.Size = new System.Drawing.Size(400, 48);
            this.btnContributions.TabIndex = 11;
            this.btnContributions.Text = "Contributions";
            this.btnContributions.UseVisualStyleBackColor = false;
            this.btnContributions.Click += new System.EventHandler(this.btnContributions_Click);
            //
            // btnLoans
            //
            this.btnLoans.BackColor = System.Drawing.Color.FromArgb(0, 102, 204);
            this.btnLoans.FlatAppearance.BorderSize = 0;
            this.btnLoans.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoans.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.btnLoans.ForeColor = System.Drawing.Color.White;
            this.btnLoans.Location = new System.Drawing.Point(60, 396);
            this.btnLoans.Name = "btnLoans";
            this.btnLoans.Size = new System.Drawing.Size(400, 48);
            this.btnLoans.TabIndex = 12;
            this.btnLoans.Text = "Loans";
            this.btnLoans.UseVisualStyleBackColor = false;
            this.btnLoans.Click += new System.EventHandler(this.btnLoans_Click);
            //
            // ChooseForm
            //
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(244, 247, 250);
            this.ClientSize = new System.Drawing.Size(520, 465);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblSummaryTitle);
            this.Controls.Add(this.lblContributionsCaption);
            this.Controls.Add(this.lblContributionsValue);
            this.Controls.Add(this.lblLoansCaption);
            this.Controls.Add(this.lblLoansValue);
            this.Controls.Add(this.lblRepaymentsCaption);
            this.Controls.Add(this.lblRepaymentsValue);
            this.Controls.Add(this.lblAvailableCaption);
            this.Controls.Add(this.lblAvailableValue);
            this.Controls.Add(this.btnMembers);
            this.Controls.Add(this.btnContributions);
            this.Controls.Add(this.btnLoans);
            this.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.ForeColor = System.Drawing.Color.FromArgb(33, 37, 41);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ChooseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Choose";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSummaryTitle;
        private System.Windows.Forms.Label lblContributionsCaption;
        private System.Windows.Forms.Label lblContributionsValue;
        private System.Windows.Forms.Label lblLoansCaption;
        private System.Windows.Forms.Label lblLoansValue;
        private System.Windows.Forms.Label lblRepaymentsCaption;
        private System.Windows.Forms.Label lblRepaymentsValue;
        private System.Windows.Forms.Label lblAvailableCaption;
        private System.Windows.Forms.Label lblAvailableValue;
        private System.Windows.Forms.Button btnMembers;
        private System.Windows.Forms.Button btnContributions;
        private System.Windows.Forms.Button btnLoans;
    }
}