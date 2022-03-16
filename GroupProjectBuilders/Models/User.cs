using Microsoft.AspNetCore.Identity;

namespace GroupProjectBuilders.Models
{
    public class User : IdentityUser
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public ICollection<Journal> Journals { get; set; }
        public List<Journal> ownedJournels { get; set; }
        public List<Journal> editedJournels { get; set; }
        public User()
        {
            Journals = new HashSet<Journal>();
        }

    }
}
