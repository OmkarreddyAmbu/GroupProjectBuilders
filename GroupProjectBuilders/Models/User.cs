namespace GroupProjectBuilders.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public ICollection<Journal> Journals { get; set; }
        public User()
        {
            Journals = new HashSet<Journal>();
        }
    }
}
