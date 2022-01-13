using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Liga.Models
{
    [Table("KOLA")]
    public partial class Kola
    {
        public Kola()
        {
            Utakmices = new HashSet<Utakmice>();
        }

        [Key]
        [Column("ID_KOLO")]
        public int IdKolo { get; set; }
        [Required]
        [Column("REDNI_BROJ")]
        [StringLength(50)]
        public string RedniBroj { get; set; }

        [InverseProperty(nameof(Utakmice.IdKoloNavigation))]
        public virtual ICollection<Utakmice> Utakmices { get; set; }
    }
}
