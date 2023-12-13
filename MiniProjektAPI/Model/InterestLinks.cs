namespace MiniProjektAPI.Model
{
    public class InterestLinks
    {
        public int Id { get; set; }
        public string WebLinks { get; set; }

        public virtual Interest Interest { get; set; }
        public virtual Person Person { get; set; }
    }
}
