using System;
using System.Windows.Forms;
using IkiminaManager.Controllers;
using IkiminaManager.Models;

namespace IkiminaManager.Views
{
    public partial class ChooseForm : Form
    {
        private readonly ReportController controller = new ReportController(new ReportRepository());

        public ChooseForm()
        {
            InitializeComponent();
            ShowFundSummary();
        }

        private void btnMembers_Click(object sender, EventArgs e)
        {
            MembersForm members = new MembersForm();

            members.FormClosed += (s, args) =>
            {
                if (members.LoggedOut)
                {
                    // Logout: closing this form makes the Login form reappear
                    this.Close();
                }
                else
                {
                    // Back (or the title-bar X): come back here with the fund summary brought up to date
                    ShowFundSummary();
                    this.Show();
                }
            };

            // Hide (not close) this form while the chosen form is open
            this.Hide();
            members.Show();
        }

        private void btnContributions_Click(object sender, EventArgs e)
        {
            ContributionsForm contributions = new ContributionsForm();

            contributions.FormClosed += (s, args) =>
            {
                if (contributions.LoggedOut)
                {
                    this.Close();
                }
                else
                {
                    ShowFundSummary();
                    this.Show();
                }
            };

            this.Hide();
            contributions.Show();
        }

        private void btnLoans_Click(object sender, EventArgs e)
        {
            LoansForm loans = new LoansForm();

            loans.FormClosed += (s, args) =>
            {
                if (loans.LoggedOut)
                {
                    this.Close();
                }
                else
                {
                    ShowFundSummary();
                    this.Show();
                }
            };

            this.Hide();
            loans.Show();
        }

        private void ShowFundSummary()
        {
            try
            {
                FundSummary summary = controller.GetFundSummary();
                lblContributionsValue.Text = summary.TotalContributions.ToString("N0") + " RWF";
                lblLoansValue.Text = summary.TotalLoansDisbursed.ToString("N0") + " RWF";
                lblRepaymentsValue.Text = summary.TotalRepayments.ToString("N0") + " RWF";
                lblAvailableValue.Text = summary.AvailableFund.ToString("N0") + " RWF";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fund summary", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}