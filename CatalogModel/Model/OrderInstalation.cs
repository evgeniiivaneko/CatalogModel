namespace CatalogModel.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderInstalation")]
    public partial class OrderInstalation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PK_OrderInstalationId { get; set; }

        public int FK_Order { get; set; }

        public int FK_Instalation { get; set; }

        public virtual Instalation Instalation { get; set; }

        public virtual Order Order { get; set; }
    }
}
