namespace CatalogModel.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            OrderDelivery = new HashSet<OrderDelivery>();
            OrderInstalation = new HashSet<OrderInstalation>();
        }

        [Key]
        public int PK_OrderId { get; set; }

        public DateTime Date { get; set; }

        [StringLength(1024)]
        public string Comment { get; set; }

        public int FK_User { get; set; }

        public int FK_Product { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDelivery> OrderDelivery { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderInstalation> OrderInstalation { get; set; }

        public virtual Product Product { get; set; }

        public virtual User User { get; set; }
    }
}
