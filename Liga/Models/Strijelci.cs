using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Liga.Models
{
    [Table("STRIJELCI")]
    public partial class Strijelci
    {
        [Key]
        [Column("ID_IGRAC")]
        public int IdIgrac { get; set; }
        [Column("BROJ_GOLOVA")]
        public int? BrojGolova { get; set; }

        [ForeignKey(nameof(IdIgrac))]
        [InverseProperty(nameof(Igrac.Strijelci))]
        public virtual Igrac IdIgracNavigation { get; set; }
    }
}
