namespace CodeGenerator.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("codegenerator.jb_components")]
    public partial class jb_components
    {
        public int id { get; set; }

        [Required]
        [StringLength(1073741823)]
        public string content { get; set; }
    }
}
