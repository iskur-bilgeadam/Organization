namespace Organization.ENTITY
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Organizations
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Organizations()
        {
            OrganizationsUsers = new HashSet<OrganizationsUsers>();
        }

        [Key]
        public int OrganizationID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public DateTime OrganizationDate { get; set; }

        public DateTime AppealDate { get; set; }

        public int NumberofUsers { get; set; }

        [Column(TypeName = "image")]
        [Required]
        public byte[] Image { get; set; }

        public int UserID { get; set; }

        public virtual Users Users { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrganizationsUsers> OrganizationsUsers { get; set; }
    }
}
