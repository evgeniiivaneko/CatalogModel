namespace CatalogModel.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Review")]
    public partial class Review
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Review()
        {
            Image = new HashSet<Image>();
        }

        [Key]
        public int PK_ReviewId { get; set; }

        [Required]
        [StringLength(1024)]
        public string Message { get; set; }

        public int FK_Product { get; set; }

        public int FK_User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Image> Image { get; set; }

        public virtual Product Product { get; set; }

        public virtual User User { get; set; }
    }
}
