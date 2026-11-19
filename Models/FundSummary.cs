namespace IkiminaManager.Models
{
    public class FundSummary
    {
        public long TotalContributions { get; set; }
        public long TotalLoansDisbursed { get; set; }
        public long TotalRepayments { get; set; }
        public long AvailableFund { get; set; }
    }
}