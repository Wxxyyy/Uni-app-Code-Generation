namespace CodeGenerator.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("codegenerator.jb_const")]
    public partial class jb_const
    {
        public int id { get; set; }

        [StringLength(1073741823)]
        public string content { get; set; }
    }
}
