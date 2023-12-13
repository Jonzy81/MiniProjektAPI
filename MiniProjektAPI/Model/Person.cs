namespace MiniProjektAPI.Model
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PhoneNumber { get; set; }

        public virtual ICollection<Interest> Interests { get; set; }
        public virtual ICollection<InterestLinks> WebLinks { get; set; }
    }
}
