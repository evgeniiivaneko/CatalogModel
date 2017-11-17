namespace CatalogModel.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Instalation")]
    public partial class Instalation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Instalation()
        {
            OrderInstalation = new HashSet<OrderInstalation>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PK_InstalationId { get; set; }

        [Required]
        [StringLength(512)]
        public string Address { get; set; }

        [Required]
        [StringLength(10)]
        public string Number { get; set; }

        public DateTime Date { get; set; }

        public decimal? Cost { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderInstalation> OrderInstalation { get; set; }
    }
}
