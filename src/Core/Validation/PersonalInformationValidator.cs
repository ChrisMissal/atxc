using System.Linq;
using System.Text.RegularExpressions;

namespace Core.Validation
{
    public class PersonalInformationValidator
    {
        private const string EmailRule = @"^([a-zA-Z0-9_\-\.]+)(\+[a-zA-Z0-9_\-\.]+)?@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

        public bool IsValid(IPersonalInformation personalInformation)
        {
            var info = personalInformation;

            if (info.Name.IsNullOrWhitespace())
                return false;
            if (!info.Name.Contains(" "))
                return false;

            if (info.Bio.IsNullOrWhitespace())
                return false;
            if (!info.Bio.Length.IsBetween(15, 160))
                return false;

            if (!new Regex(EmailRule).IsMatch(info.Email))
                return false;

            if (info.Location == null)
                return false;

            if (!info.Categories.Any())
                return false;

            return true;
        }
    }
}