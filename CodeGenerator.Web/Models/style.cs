namespace CodeGenerator.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("codegenerator.style")]
    public partial class style
    {
        public int id { get; set; }

        [StringLength(1073741823)]
        public string content_css { get; set; }
    }
}
