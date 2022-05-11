using Microsoft.AspNetCore.Identity;
namespace PLUMWEB.Data
{
    public class Admin : IdentityUser
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime DateJoined { get; set; }
    }
}
