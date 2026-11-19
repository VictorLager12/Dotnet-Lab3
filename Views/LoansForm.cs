using System;
using System.Data;
using System.Windows.Forms;
using IkiminaManager.Controllers;
using IkiminaManager.Models;

namespace IkiminaManager.Views
{
    public partial class LoansForm : Form
    {
        // Read by the Choose form after this form closes
        public bool LoggedOut = false;

        private readonly LoanController controller = new LoanController(new LoanRepository(), new ContributionRepository());
        private readonly MemberController memberController = new MemberController(new MemberRepository());

        // ID of the loan whose row was clicked; 0 means no loan is selected
        private int selectedLoanID = 0;

        // The table shows either the active loans or the overdue loans
        private bool showingOverdue = false;

        public LoansForm()
        {
            InitializeComponent();
            LoadMembers();
            RefreshLoans();
            ShowFund();
        }

        // Only digits can be typed in the amount and repayment boxes
        private void AmountTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            try
            {
                ShowCheck(controller.CheckEligibility(SelectedMemberID(), ReadWholeNumber(txtAmount.Text), SelectedTerm()));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Loans", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            try
            {
                int memberID = SelectedMemberID();
                int amount = ReadWholeNumber(txtAmount.Text);
                int term = SelectedTerm();

                LoanCheck check = controller.CheckEligibility(memberID, amount, term);
                ShowCheck(check);

                if (!check.IsEligible)
                {
                    MessageBox.Show(check.Reason, "Loan not approved", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // The treasurer sees the interest and the total repayable before confirming
                string question = "Approve this loan?" + Environment.NewLine + Environment.NewLine
                    + "Principal: " + amount.ToString("N0") + " RWF" + Environment.NewLine
                    + "Interest: " + check.Interest.ToString("N0") + " RWF" + Environment.NewLine
                    + "Total repayable: " + check.TotalRepayable.ToString("N0") + " RWF" + Environment.NewLine
                    + "Due date: " + check.DueDate.ToString("yyyy-MM-dd");

                DialogResult answer = MessageBox.Show(question, "Confirm loan", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (answer != DialogResult.Yes)
                {
                    return;
                }

                controller.ApproveLoan(memberID, amount, term);
                MessageBox.Show("Loan approved.", "Loans", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtAmount.Clear();
                cboTerm.SelectedIndex = -1;
                lblResult.Text = "";
                RefreshLoans();
                ShowFund();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Loans", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnRepay_Click(object sender, EventArgs e)
        {
            try
            {
                controller.RecordRepayment(selectedLoanID, ReadWholeNumber(txtRepayment.Text));
                MessageBox.Show("Repayment recorded.", "Loans", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtRepayment.Clear();
                RefreshLoans();
                ShowFund();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Repayment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnShowActive_Click(object sender, EventArgs e)
        {
            showingOverdue = false;
            RefreshLoans();
        }

        private void btnShowOverdue_Click(object sender, EventArgs e)
        {
            showingOverdue = true;
            RefreshLoans();

            if (dgvLoans.Rows.Count == 0)
            {
                MessageBox.Show("No overdue loans.", "Overdue report", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Clicking a loan selects it for a repayment
        private void dgvLoans_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow row = dgvLoans.Rows[e.RowIndex];
            selectedLoanID = Convert.ToInt32(row.Cells["LoanID"].Value);
            decimal outstanding = Convert.ToDecimal(row.Cells["Outstanding"].Value);

            lblSelected.Text = "Selected: " + Convert.ToString(row.Cells["Member"].Value)
                + Environment.NewLine + "Outstanding: " + outstanding.ToString("N0") + " RWF";
        }

        // Back closes this form and the Choose form reappears. Logout also sets LoggedOut, so the Choose form closes too and the Login form reappears.
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            LoggedOut = true;
            this.Close();
        }

        // Returns 0 for empty text, letters or decimals. The controller then rejects 0 with a clear message.
        private int ReadWholeNumber(string text)
        {
            int number;
            if (!int.TryParse(text.Trim(), out number))
            {
                return 0;
            }

            return number;
        }

        // 0 means nothing is selected
        private int SelectedMemberID()
        {
            if (cboMember.SelectedIndex < 0)
            {
                return 0;
            }

            return Convert.ToInt32(cboMember.SelectedValue);
        }

        private int SelectedTerm()
        {
            if (cboTerm.SelectedIndex < 0)
            {
                return 0;
            }

            return Convert.ToInt32(cboTerm.SelectedItem);
        }

        private void ShowCheck(LoanCheck check)
        {
            string text = "Maximum loan: " + check.MaxLoan.ToString("N0") + " RWF" + Environment.NewLine;

            if (check.IsEligible)
            {
                text += "Result: Eligible" + Environment.NewLine
                    + "Interest (" + LoanController.InterestPercentPerMonth + "% per month): " + check.Interest.ToString("N0") + " RWF" + Environment.NewLine
                    + "Total repayable: " + check.TotalRepayable.ToString("N0") + " RWF";
            }
            else
            {
                text += "Result: Not eligible" + Environment.NewLine + "Reason: " + check.Reason;
            }

            lblResult.Text = text;
        }

        private void LoadMembers()
        {
            try
            {
                DataTable members = memberController.SearchMembers("");

                // Adds one text column that joins code and name, for example "M001 - Aline Mukamana", for the drop-down list
                members.Columns.Add("DisplayText", typeof(string), "MemberCode + ' - ' + FullName");

                cboMember.DisplayMember = "DisplayText";
                cboMember.ValueMember = "MemberID";
                cboMember.DataSource = members;
                cboMember.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Loans", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowFund()
        {
            try
            {
                lblFund.Text = "Available Fund: " + controller.GetAvailableFund().ToString("N0") + " RWF";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Loans", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Loads whichever list is being shown and clears the selected loan
        private void RefreshLoans()
        {
            try
            {
                if (showingOverdue)
                {
                    dgvLoans.DataSource = controller.GetOverdueLoans();
                    lblGridTitle.Text = "Overdue loans";
                }
                else
                {
                    dgvLoans.DataSource = controller.GetActiveLoans();
                    lblGridTitle.Text = "Active loans";
                }

                dgvLoans.Columns["LoanID"].Visible = false;
                FormatColumn("Member", "Member", "");
                FormatColumn("Principal", "Principal (RWF)", "N0");
                FormatColumn("TotalRepayable", "Total repayable (RWF)", "N0");
                FormatColumn("Outstanding", "Outstanding (RWF)", "N0");
                FormatColumn("DueDate", "Due date", "yyyy-MM-dd");
                FormatColumn("DaysOverdue", "Days overdue", "");
                dgvLoans.ClearSelection();

                selectedLoanID = 0;
                lblSelected.Text = "Click a loan in the table below to select it.";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Loans", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // The two lists have different columns, so a column is only formatted if it exists
        private void FormatColumn(string name, string header, string format)
        {
            if (dgvLoans.Columns.Contains(name))
            {
                dgvLoans.Columns[name].HeaderText = header;

                if (format != "")
                {
                    dgvLoans.Columns[name].DefaultCellStyle.Format = format;
                }
            }
        }
    }
}