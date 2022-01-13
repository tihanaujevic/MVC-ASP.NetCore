using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Liga.Models
{
    [Table("KARTONIRANI")]
    public partial class Kartonirani
    {
        [Key]
        [Column("ID_IGRAC")]
        public int IdIgrac { get; set; }
        [Column("BROJ_CRVENIH_KARTONA")]
        public int? BrojCrvenihKartona { get; set; }

        [ForeignKey(nameof(IdIgrac))]
        [InverseProperty(nameof(Igrac.Kartonirani))]
        public virtual Igrac IdIgracNavigation { get; set; }
    }
}
