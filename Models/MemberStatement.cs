using System;

namespace IkiminaManager.Models
{
    public class MemberStatement
    {
        public string FullName { get; set; } = "";
        public int ContributionCount { get; set; }
        public long ContributionTotal { get; set; }

        // The member's most recent loan, if they have ever borrowed
        public bool HasLoan { get; set; }
        public string LoanStatus { get; set; } = "";
        public int LoanPrincipal { get; set; }
        public long LoanOutstanding { get; set; }
        public DateTime LoanDueDate { get; set; }
    }
}