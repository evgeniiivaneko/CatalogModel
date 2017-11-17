namespace CatalogModel.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Image")]
    public partial class Image
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Image()
        {
            Product = new HashSet<Product>();
            User = new HashSet<User>();
        }

        [Key]
        public int PK_ImageId { get; set; }

        [Column(TypeName = "image")]
        [Required]
        public byte[] Picture { get; set; }

        [StringLength(128)]
        public string Description { get; set; }

        public int? FK_Product { get; set; }

        public int? FK_Review { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Product { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User> User { get; set; }

        public virtual Product Product1 { get; set; }

        public virtual Review Review { get; set; }
    }
}
