namespace Quản_Lý_Khách_Sạn.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BillRoom")]
    public partial class BillRoom
    {
        public int Id { get; set; }

        public int? BillId { get; set; }

        public int? RoomId { get; set; }

        public DateTime? StartDay { get; set; }

        public DateTime? EndDay { get; set; }

        public virtual Bill Bill { get; set; }

        public virtual Room Room { get; set; }
    }
}
