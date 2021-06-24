using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Residences
{
    public abstract class IdRecord
    {
        [Required]
        public virtual int Id { get; set; }
    }
}
