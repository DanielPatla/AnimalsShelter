using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsShelter.DataAccess.Entities
{
    class AppUser : EntityBase
    {
        [Required]
        [MaxLength(35)]
        public string Login { get; set; }

        [Required]
        [MaxLength(35)]
        public string Password { get; set; }

        [Required]
        [MaxLength(25)]
        public string UserName { get; set; }
        public bool IsAdmin { get; set; }
        public bool Sex { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        [MaxLength(15)]
        public string PhoneNumber { get; set; }
    }
}
