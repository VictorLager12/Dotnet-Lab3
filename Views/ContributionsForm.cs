using System;
using System.Data;
using System.Windows.Forms;
using IkiminaManager.Controllers;
using IkiminaManager.Models;

namespace IkiminaManager.Views
{
    public partial class ContributionsForm : Form
    {
        // Read by the Choose form after this form closes
        public bool LoggedOut = false;

        private readonly ContributionController controller = new ContributionController(new ContributionRepository());
        private readonly MemberController memberController = new MemberController(new MemberRepository());

        public ContributionsForm()
        {
            InitializeComponent();
            LoadMembers();
            RefreshGrid();
            ShowTotals();
        }

        // Only digits can be typed in the amount box
        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // Choosing a member shows that member's total
        private void cboMember_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowTotals();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                controller.RecordContribution(ReadContributionFromForm());
                MessageBox.Show("Contribution recorded.", "Contributions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAmount.Clear();
                RefreshGrid();
                ShowTotals();
                txtAmount.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Contribution", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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

        private Contribution ReadContributionFromForm()
        {
            if (cboMember.SelectedIndex < 0)
            {
                throw new ArgumentException("Select a member from the list.");
            }

            // TryParse fails for empty text, letters and decimals such as "2500.5"
            int amount;
            if (!int.TryParse(txtAmount.Text.Trim(), out amount))
            {
                throw new ArgumentException("Amount must be a whole number greater than 0.");
            }

            Contribution contribution = new Contribution();
            contribution.MemberID = Convert.ToInt32(cboMember.SelectedValue);
            contribution.Amount = amount;
            contribution.ContributionDate = dtpDate.Value.Date;
            return contribution;
        }

        private void LoadMembers()
        {
            try
            {
                DataTable members = memberController.SearchMembers("");

                // Adds one text column that joins code and name, for example "M001 - Aline Mukamana", for the drop-down list
                members.Columns.Add("DisplayText", typeof(string), "MemberCode + ' - ' + FullName");

                // Both properties are set before the data source so the list reads the right columns
                cboMember.DisplayMember = "DisplayText";
                cboMember.ValueMember = "MemberID";
                cboMember.DataSource = members;
                cboMember.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Contributions", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshGrid()
        {
            try
            {
                dgvContributions.DataSource = controller.GetContributions();
                dgvContributions.Columns["ContributionID"].Visible = false;
                dgvContributions.Columns["ContributionDate"].HeaderText = "Date";
                dgvContributions.Columns["ContributionDate"].DefaultCellStyle.Format = "yyyy-MM-dd";
                dgvContributions.Columns["Amount"].HeaderText = "Amount (RWF)";
                dgvContributions.Columns["Amount"].DefaultCellStyle.Format = "N0";
                dgvContributions.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Contributions", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowTotals()
        {
            try
            {
                lblGroupTotal.Text = "Group total: " + controller.GetGroupTotal().ToString("N0") + " RWF";

                if (cboMember.SelectedIndex < 0)
                {
                    lblMemberTotal.Text = "Selected member total: choose a member";
                }
                else
                {
                    int memberID = Convert.ToInt32(cboMember.SelectedValue);
                    lblMemberTotal.Text = "Selected member total: " + controller.GetMemberTotal(memberID).ToString("N0") + " RWF";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Contributions", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}