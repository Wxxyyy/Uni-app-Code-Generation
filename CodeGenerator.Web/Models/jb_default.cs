namespace CodeGenerator.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("codegenerator.jb_default")]
    public partial class jb_default
    {
        public int id { get; set; }

        [Required]
        [StringLength(1073741823)]
        public string content { get; set; }
    }
}
