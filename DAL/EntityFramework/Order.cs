namespace DAL.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OrderId { get; set; }

        public int? CustomerId { get; set; }

        public int? ProductId { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Amount { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? OrderDate { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Product Product { get; set; }
    }
}
