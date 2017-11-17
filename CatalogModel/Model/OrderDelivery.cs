namespace CatalogModel.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderDelivery")]
    public partial class OrderDelivery
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PK_OrderDeliveryId { get; set; }

        public int FK_Order { get; set; }

        public int FK_Delivery { get; set; }

        public virtual Delivery Delivery { get; set; }

        public virtual Order Order { get; set; }
    }
}
