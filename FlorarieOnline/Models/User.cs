using System.Security.Principal;

namespace FlorarieOnline.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool SubsribeToEmailPush { get; set; } = false;
        public Adres Adresa { get; set; }
        public List<Produs> ProduseCos {  get; set; }
    }
}
