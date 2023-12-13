namespace MiniProjektAPI.Model
{
    public class Interest
    {
        public int Id { get; set; }
        public string Interests { get; set; }
        public string? InterestDescription { get; set; }

        public virtual ICollection<Person> Persons { get; set; }
        public virtual ICollection<InterestLinks> WebLinks { get; set; }
    }
}
