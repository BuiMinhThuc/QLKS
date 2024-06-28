namespace Quản_Lý_Khách_Sạn.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BillService")]
    public partial class BillService
    {
        public int Id { get; set; }

        public int? BillId { get; set; }

        public int? ServiceId { get; set; }

        public virtual Bill Bill { get; set; }

        public virtual Service Service { get; set; }
    }
}
