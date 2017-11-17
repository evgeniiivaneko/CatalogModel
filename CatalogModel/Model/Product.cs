namespace CatalogModel.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            Image1 = new HashSet<Image>();
            Order = new HashSet<Order>();
            Review = new HashSet<Review>();
        }

        [Key]
        public int PK_ProductId { get; set; }

        [Required]
        [StringLength(50)]
        public string Model { get; set; }

        [Required]
        [StringLength(1024)]
        public string Description { get; set; }

        public decimal Price { get; set; }

        public int FK_Type { get; set; }

        public int FK_Brand { get; set; }

        public int FK_Image { get; set; }

        public virtual Brand Brand { get; set; }

        public virtual Conditioner Conditioner { get; set; }

        public virtual Heater Heater { get; set; }

        public virtual Image Image { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Image> Image1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Order { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Review> Review { get; set; }

        public virtual Type Type { get; set; }
    }
}
