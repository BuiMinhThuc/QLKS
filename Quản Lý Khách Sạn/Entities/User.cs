namespace Quản_Lý_Khách_Sạn.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            Bills = new HashSet<Bill>();
            ComfirmEmails = new HashSet<ComfirmEmail>();
            LichLamViecs = new HashSet<LichLamViec>();
        }

        public int Id { get; set; }

        [StringLength(255)]
        public string UserName { get; set; }

        [StringLength(255)]
        public string PassWord { get; set; }

        [StringLength(255)]
        public string Email { get; set; }

        [StringLength(255)]
        public string PhoneNumber { get; set; }

        public bool? IsActive { get; set; }

        public int? RoleID { get; set; } 

        [StringLength(255)]
        public string AvtUrl { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bill> Bills { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ComfirmEmail> ComfirmEmails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LichLamViec> LichLamViecs { get; set; }

        public virtual Role Role { get; set; }
    }
}
