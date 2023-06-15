using System.Text.RegularExpressions;

namespace LibraryRegisterAPI.Services
{
    public class MemberService
    {
        public bool IsNameValid(string name)
        {
            string pattern = @"^[a-zA-Z0-9]+$";

            bool isMatch = Regex.IsMatch(name, pattern) && !string.IsNullOrWhiteSpace(name) && !name.Contains(" ");

            return isMatch;
        }
    }
}
