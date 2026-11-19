using System;
using System.Data;
using IkiminaManager.Models;

namespace IkiminaManager.Controllers
{
    // Applies the contribution rules. It never touches a TextBox or a DataGridView.
    public class ContributionController
    {
        private readonly ContributionRepository repository;

        public ContributionController(ContributionRepository repository)
        {
            this.repository = repository;
        }

        public DataTable GetContributions()
        {
            return repository.GetAll();
        }

        public long GetMemberTotal(int memberID)
        {
            return repository.GetMemberTotal(memberID);
        }

        public long GetGroupTotal()
        {
            return repository.GetGroupTotal();
        }

        public void RecordContribution(Contribution contribution)
        {
            if (contribution.MemberID <= 0)
            {
                throw new ArgumentException("Select a member from the list.");
            }

            if (contribution.Amount <= 0)
            {
                throw new ArgumentException("Amount must be a whole number greater than 0.");
            }

            if (contribution.ContributionDate.Date > DateTime.Today)
            {
                throw new ArgumentException("The date cannot be in the future.");
            }

            repository.Insert(contribution);
        }
    }
}