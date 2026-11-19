using System;

namespace IkiminaManager.Models
{
    // The answer to "can this member borrow this amount?" together with the figures the screen needs to show
    public class LoanCheck
    {
        public long MaxLoan { get; set; }
        public bool IsEligible { get; set; }
        public string Reason { get; set; } = "";
        public int Interest { get; set; }
        public int TotalRepayable { get; set; }
        public DateTime DueDate { get; set; }
    }
}