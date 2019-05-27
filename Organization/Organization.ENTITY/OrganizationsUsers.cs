namespace Organization.ENTITY
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class OrganizationsUsers
    {
        [Key]
        public int OrganizationUserID { get; set; }

        public int OrganizationID { get; set; }

        public int UserID { get; set; }

        public DateTime Date { get; set; }

        public virtual Organizations Organizations { get; set; }

        public virtual Users Users { get; set; }
    }
}
