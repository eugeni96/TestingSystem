using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ORM
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }
}
