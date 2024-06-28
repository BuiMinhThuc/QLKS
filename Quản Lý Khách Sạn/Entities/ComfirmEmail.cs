namespace Quản_Lý_Khách_Sạn.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ComfirmEmail")]
    public partial class ComfirmEmail
    {
        public int Id { get; set; }

        [StringLength(255)]
        public string Code { get; set; }

        public int? UserId { get; set; }

        public DateTime? EndTime { get; set; }

        public virtual User User { get; set; }
    }
}
