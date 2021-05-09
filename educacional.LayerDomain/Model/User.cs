using System.ComponentModel.DataAnnotations.Schema;

namespace educacional.LayerDomain.Model
{
    [Table("User")]    
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int Password { get; set; }
    }
}
