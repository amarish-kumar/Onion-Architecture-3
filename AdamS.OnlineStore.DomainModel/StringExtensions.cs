using System.Text.RegularExpressions;

namespace AdamS.OnlineStore.DomainModel
{
    public static class StringExtensions
    {
        public static bool IsValidEmailAddress(this string emailAddress)
        {
            Regex regex = new Regex(@"^[\w-]+(?:\.[\w-]+)*@(?:[\w-]+\.)+[a-zA-Z]{2,7}$");
            Match match = regex.Match(emailAddress);
            return match.Success;

        }
        
    }
    
}