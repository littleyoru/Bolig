namespace Residences
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User : IdRecord
    {
        [Required]
        [StringLength(50)]
        public virtual string UserName { get; set; }

        [StringLength(50)]
        public virtual string LastName { get; set; }

        [Required]
        [StringLength(50)]
        public virtual string Email { get; set; }

        //public virtual List<Residence> UserResidences { get; set; }
    }
}
