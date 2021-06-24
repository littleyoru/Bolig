namespace Residences
{
    using Residences.Enums;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Residence : IdRecord
    {
        public virtual ResidenceType? ResidenceType { get; set; }

        [StringLength(255)]
        public virtual string Title { get; set; }

        public virtual int Rent { get; set; }

        public virtual short Size { get; set; }

        public virtual byte Rooms { get; set; }

        public virtual bool? AllowPets { get; set; }

        [Required]
        [StringLength(50)]
        public virtual string Street { get; set; }

        [Required]
        public virtual PostCode PostCode { get; set; }

        public virtual DateTime? AvailableFrom { get; set; }

        public virtual int? RentDuration { get; set; }

        public virtual DateTime PublishDate { get; set; }

        public virtual int? Deposit { get; set; }

        public virtual int? UtilitiesCost { get; set; }

        [Required]
        public virtual User User { get; set; }
    }
}
