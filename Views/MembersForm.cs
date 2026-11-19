using System;
using System.Windows.Forms;
using IkiminaManager.Controllers;
using IkiminaManager.Models;

namespace IkiminaManager.Views
{
    public partial class MembersForm : Form
    {
        // Read by the Choose form after this form closes
        public bool LoggedOut = false;

        private readonly MemberController controller = new MemberController(new MemberRepository());
        private readonly ReportController reportController = new ReportController(new ReportRepository());

        // ID of the member whose row was clicked; 0 means no member is selected
        private int selectedMemberID = 0;

        public MembersForm()
        {
            InitializeComponent();
            RefreshGrid();
        }

        // Only digits can be typed in the phone box
        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                controller.AddMember(ReadMemberFromForm());
                MessageBox.Show("Member registered.", "Members", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                RefreshGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Add member", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                controller.EditMember(ReadMemberFromForm());
                MessageBox.Show("Member updated.", "Members", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                RefreshGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update member", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (selectedMemberID <= 0)
            {
                MessageBox.Show("Select a member from the table first.", "Remove member", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult answer = MessageBox.Show("Remove this member?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer != DialogResult.Yes)
            {
                return;
            }

            try
            {
                controller.RemoveMember(selectedMemberID);
                MessageBox.Show("Member removed.", "Members", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                RefreshGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Remove member", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        // Shows the selected member's statement in a MessageBox
        private void btnStatement_Click(object sender, EventArgs e)
        {
            try
            {
                MemberStatement statement = reportController.GetMemberStatement(selectedMemberID);

                string text = "Member: " + statement.FullName + Environment.NewLine
                    + "Contributions: " + statement.ContributionCount + " (total " + statement.ContributionTotal.ToString("N0") + " RWF)" + Environment.NewLine;

                if (statement.HasLoan)
                {
                    text += "Latest loan: " + statement.LoanPrincipal.ToString("N0") + " RWF, status " + statement.LoanStatus + Environment.NewLine
                        + "Outstanding balance: " + statement.LoanOutstanding.ToString("N0") + " RWF" + Environment.NewLine
                        + "Due date: " + statement.LoanDueDate.ToString("yyyy-MM-dd");
                }
                else
                {
                    text += "Loans: none";
                }

                MessageBox.Show(text, "Member statement", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Member statement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // The list narrows as the treasurer types
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        // Clicking a row copies that member into the text boxes so it can be edited or removed
        private void dgvMembers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow row = dgvMembers.Rows[e.RowIndex];
            selectedMemberID = Convert.ToInt32(row.Cells["MemberID"].Value);
            txtName.Text = Convert.ToString(row.Cells["FullName"].Value);
            txtPhone.Text = Convert.ToString(row.Cells["Phone"].Value);
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

        private Member ReadMemberFromForm()
        {
            Member member = new Member();
            member.MemberID = selectedMemberID;
            member.FullName = txtName.Text.Trim();
            member.Phone = txtPhone.Text.Trim();
            return member;
        }

        private void RefreshGrid()
        {
            try
            {
                dgvMembers.DataSource = controller.SearchMembers(txtSearch.Text);
                dgvMembers.Columns["MemberID"].Visible = false;
                dgvMembers.Columns["MemberCode"].HeaderText = "ID";
                dgvMembers.Columns["FullName"].HeaderText = "Full name";
                dgvMembers.Columns["Phone"].HeaderText = "Phone number";
                dgvMembers.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Members", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearForm()
        {
            selectedMemberID = 0;
            txtName.Clear();
            txtPhone.Clear();
            txtName.Focus();
            dgvMembers.ClearSelection();
        }
    }
}