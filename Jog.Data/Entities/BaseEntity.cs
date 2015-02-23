using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jog.Data
{
    public abstract class BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
    }
}