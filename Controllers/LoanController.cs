using System;
using System.Data;
using IkiminaManager.Models;

namespace IkiminaManager.Controllers
{
    // Applies the loan rules. It never touches a TextBox or a DataGridView.
    public class LoanController
    {
        // Default loan rules from the SRS. Change them here and the whole program follows.
        public const int LimitMultiplier = 3;           // a member may borrow up to 3 x their total contributions
        public const int InterestPercentPerMonth = 5;   // simple interest on the principal
        public const int MinMonths = 1;
        public const int MaxMonths = 6;

        private readonly LoanRepository loanRepository;
        private readonly ContributionRepository contributionRepository;

        public LoanController(LoanRepository loanRepository, ContributionRepository contributionRepository)
        {
            this.loanRepository = loanRepository;
            this.contributionRepository = contributionRepository;
        }

        public long GetAvailableFund()
        {
            return loanRepository.GetAvailableFund();
        }

        public DataTable GetActiveLoans()
        {
            return loanRepository.GetActiveLoans();
        }

        public DataTable GetOverdueLoans()
        {
            return loanRepository.GetOverdueLoans(DateTime.Today);
        }

        // Works out the maximum loan and checks the rules in this order: amount, maximum, term, existing loan.
        // The first rule that fails becomes the reason shown to the treasurer.
        public LoanCheck CheckEligibility(int memberID, int amount, int termMonths)
        {
            LoanCheck check = new LoanCheck();

            if (memberID <= 0)
            {
                check.Reason = "Select a member from the list.";
                return check;
            }

            // Maximum loan = the lower of (3 x the member's contributions) and the Available Fund
            long contributions = contributionRepository.GetMemberTotal(memberID);
            long fund = loanRepository.GetAvailableFund();
            check.MaxLoan = Math.Min(LimitMultiplier * contributions, fund);

            if (amount <= 0)
            {
                check.Reason = "Amount must be a whole number greater than 0.";
                return check;
            }

            if (amount > check.MaxLoan)
            {
                check.Reason = "The amount is more than the maximum loan of " + check.MaxLoan.ToString("N0") + " RWF.";
                return check;
            }

            if (termMonths < MinMonths || termMonths > MaxMonths)
            {
                check.Reason = "The term must be a whole number from " + MinMonths + " to " + MaxMonths + " months.";
                return check;
            }

            if (loanRepository.HasActiveLoan(memberID))
            {
                check.Reason = "This member already has an active loan.";
                return check;
            }

            // Simple interest, rounded to a whole RWF
            long interest = ((long)amount * InterestPercentPerMonth * termMonths + 50) / 100;
            check.Interest = (int)interest;
            check.TotalRepayable = amount + check.Interest;
            check.DueDate = DateTime.Today.AddMonths(termMonths);
            check.IsEligible = true;
            return check;
        }

        public void ApproveLoan(int memberID, int amount, int termMonths)
        {
            // Check again so a loan can never be saved without passing every rule
            LoanCheck check = CheckEligibility(memberID, amount, termMonths);
            if (!check.IsEligible)
            {
                throw new ArgumentException(check.Reason);
            }

            Loan loan = new Loan();
            loan.MemberID = memberID;
            loan.Principal = amount;
            loan.TermMonths = termMonths;
            loan.Interest = check.Interest;
            loan.TotalRepayable = check.TotalRepayable;
            loan.IssueDate = DateTime.Today;
            loan.DueDate = check.DueDate;
            loan.Status = "Active";

            loanRepository.Insert(loan);
        }

        public void RecordRepayment(int loanID, int amount)
        {
            if (loanID <= 0)
            {
                throw new ArgumentException("Select a loan from the table first.");
            }

            if (amount <= 0)
            {
                throw new ArgumentException("Repayment must be a whole number greater than 0.");
            }

            long outstanding = loanRepository.GetOutstanding(loanID);

            if (outstanding < 0)
            {
                throw new ArgumentException("The selected loan was not found.");
            }

            if (amount > outstanding)
            {
                throw new ArgumentException("The repayment cannot be more than the outstanding balance of " + outstanding.ToString("N0") + " RWF.");
            }

            loanRepository.AddRepayment(loanID, amount, DateTime.Today);
        }
    }
}