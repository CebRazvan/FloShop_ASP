namespace FlorarieOnline.Models
{
    public class Order
    {
        public int Id { get; set; }
        public List<Produs> Produs { get; set; }
        public double PretTotal { get; set; }
        public DateTime DataComenzi { get; set; }
        public string StatusComanda { get; set; }
    }
}
