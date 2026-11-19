using System;

namespace IkiminaManager.Models
{
    public class Contribution
    {
        public int ContributionID { get; set; }
        public int MemberID { get; set; }
        public int Amount { get; set; }
        public DateTime ContributionDate { get; set; }
    }
}