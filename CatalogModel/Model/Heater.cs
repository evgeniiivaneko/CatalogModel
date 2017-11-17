namespace CatalogModel.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Heater")]
    public partial class Heater
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FK_ProductId { get; set; }

        [StringLength(128)]
        public string Type { get; set; }

        [StringLength(128)]
        public string HeatingElement { get; set; }

        public int? Power { get; set; }

        [StringLength(128)]
        public string Area { get; set; }

        [StringLength(128)]
        public string Control { get; set; }

        public bool? PowerLevelAdjustment { get; set; }

        public bool? Thermostat { get; set; }

        public bool? Rotation { get; set; }

        public bool? BuiltInIonizer { get; set; }

        public bool? AirCleaning { get; set; }

        public bool? Humidification { get; set; }

        public bool? Timer { get; set; }

        public bool? RemoteControl { get; set; }

        public bool? FrostPreventionMode { get; set; }

        public bool? Display { get; set; }

        public bool? BlowingWithoutHeating { get; set; }

        public bool? WaterproofHousing { get; set; }

        public bool? AutoPowerOff { get; set; }

        public bool? ProtectionFromChildren { get; set; }

        public bool? WallMounting { get; set; }

        public bool? TowelHolder { get; set; }

        [StringLength(128)]
        public string Width { get; set; }

        [StringLength(128)]
        public string Depth { get; set; }

        [StringLength(128)]
        public string Height { get; set; }

        [StringLength(128)]
        public string Weight { get; set; }

        public virtual Product Product { get; set; }
    }
}
