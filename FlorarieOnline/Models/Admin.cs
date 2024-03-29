namespace FlorarieOnline.Models
{
    public class Admin 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public DateTime RegistredDate { get; set; } = DateTime.Now.Date;
    }
}
