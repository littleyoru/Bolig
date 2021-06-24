namespace Residences
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Login : IdRecord
    {
        [Required]
        [StringLength(50)]
        public virtual string Password { get; set; }

        [Required]
        public virtual User User { get; set; }
    }
}
