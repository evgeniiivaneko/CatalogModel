namespace CatalogModel.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Conditioner")]
    public partial class Conditioner
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FK_ProductId { get; set; }

        [StringLength(128)]
        public string Type { get; set; }

        [StringLength(128)]
        public string TypeBlock { get; set; }

        public bool? ExternalBlock { get; set; }

        public bool? IndoorBlock { get; set; }

        [StringLength(128)]
        public string Mode { get; set; }

        public double? PowerCold { get; set; }

        public double? PowerHot { get; set; }

        [StringLength(128)]
        public string Coolant { get; set; }

        [StringLength(128)]
        public string TempCold { get; set; }

        [Required]
        [StringLength(128)]
        public string TempHot { get; set; }

        public double? ConsumotionPowerCold { get; set; }

        public double? ConsumotionPowerHot { get; set; }

        public bool? Inverter { get; set; }

        public double? Area { get; set; }

        public bool? Console { get; set; }

        public bool? DirectionAir { get; set; }

        public bool? SpeedFan { get; set; }

        public bool? Timer { get; set; }

        public bool? Autorestart { get; set; }

        public bool? Sleep { get; set; }

        public bool? Dehumidification { get; set; }

        public bool? Humidification { get; set; }

        public bool? Noise { get; set; }

        public bool? BioFiltr { get; set; }

        public bool? PlasmaFiltr { get; set; }

        public bool? Ionization { get; set; }

        public bool? CarbonFiltr { get; set; }

        public bool? PhotocatalyticFiltr { get; set; }

        public bool? ElectrostaticFiltr { get; set; }

        public bool? OdourControl { get; set; }

        [StringLength(128)]
        public string ExternalDimension { get; set; }

        [StringLength(128)]
        public string IndoorDimension { get; set; }

        public virtual Product Product { get; set; }
    }
}
