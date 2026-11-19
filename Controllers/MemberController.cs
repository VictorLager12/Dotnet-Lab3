using System;
using System.Data;
using IkiminaManager.Models;

namespace IkiminaManager.Controllers
{
    // Applies the member rules and decides what happens. It never touches a TextBox or a DataGridView.
    public class MemberController
    {
        private readonly MemberRepository repository;

        public MemberController(MemberRepository repository)
        {
            this.repository = repository;
        }

        public DataTable SearchMembers(string keyword)
        {
            return repository.Search(keyword.Trim());
        }

        public void AddMember(Member member)
        {
            // A new member has no ID yet; the database assigns one
            member.MemberID = 0;
            Validate(member);
            repository.Insert(member);
        }

        public void EditMember(Member member)
        {
            if (member.MemberID <= 0)
            {
                throw new ArgumentException("Select a member from the table first.");
            }

            Validate(member);
            repository.Update(member);
        }

        public void RemoveMember(int memberID)
        {
            if (memberID <= 0)
            {
                throw new ArgumentException("Select a member from the table first.");
            }

            if (repository.HasRecords(memberID))
            {
                throw new ArgumentException("This member has contributions or loans, so they cannot be removed.");
            }

            repository.Delete(memberID);
        }

        // Each rule throws a message that the form shows in a MessageBox
        private void Validate(Member member)
        {
            if (string.IsNullOrWhiteSpace(member.FullName))
            {
                throw new ArgumentException("Full name cannot be empty.");
            }

            foreach (char letter in member.FullName)
            {
                if (!char.IsLetter(letter) && letter != ' ' && letter != '-')
                {
                    throw new ArgumentException("Full name can contain only letters, spaces and hyphens.");
                }
            }

            // Length is checked first so Substring is never called on a short text
            if (member.Phone.Length != 10 || member.Phone.Substring(0, 2) != "07" || !AllDigits(member.Phone))
            {
                throw new ArgumentException("Phone number must be exactly 10 digits and start with 07.");
            }

            if (repository.PhoneExists(member.Phone, member.MemberID))
            {
                throw new ArgumentException("This phone number is already registered.");
            }
        }

        private bool AllDigits(string text)
        {
            foreach (char c in text)
            {
                if (c < '0' || c > '9')
                {
                    return false;
                }
            }

            return true;
        }
    }
}