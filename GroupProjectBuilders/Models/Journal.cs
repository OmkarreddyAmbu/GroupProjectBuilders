namespace GroupProjectBuilders.Models
{
    public class Journal
    {

        public int JournalId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public User User { get; set; }
        public int UserNumber { get; set; }
 
        public User Editor { get; set; }
        public User Owner { get; set; }


    }
}
