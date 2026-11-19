using System;

namespace IkiminaManager.Models
{
    public class Loan
    {
        public int LoanID { get; set; }
        public int MemberID { get; set; }
        public int Principal { get; set; }
        public int TermMonths { get; set; }
        public int Interest { get; set; }
        public int TotalRepayable { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime DueDate { get; set; }
        public string Status { get; set; } = "Active";
    }
}