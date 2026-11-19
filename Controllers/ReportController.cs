using System;
using IkiminaManager.Models;

namespace IkiminaManager.Controllers
{
    public class ReportController
    {
        private readonly ReportRepository repository;

        public ReportController(ReportRepository repository)
        {
            this.repository = repository;
        }

        public FundSummary GetFundSummary()
        {
            FundSummary summary = repository.GetFundTotals();

            // Available Fund = contributions + repayments - loans paid out
            summary.AvailableFund = summary.TotalContributions + summary.TotalRepayments - summary.TotalLoansDisbursed;
            return summary;
        }

        public MemberStatement GetMemberStatement(int memberID)
        {
            if (memberID <= 0)
            {
                throw new ArgumentException("Select a member from the table first.");
            }

            MemberStatement statement = repository.GetMemberStatement(memberID);

            if (statement.FullName == "")
            {
                throw new ArgumentException("The selected member was not found.");
            }

            return statement;
        }
    }
}