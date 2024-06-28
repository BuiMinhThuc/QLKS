namespace Quản_Lý_Khách_Sạn.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Supply
    {
        public int Id { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        public int? RoomId { get; set; }

        public virtual Room Room { get; set; }
    }
}
