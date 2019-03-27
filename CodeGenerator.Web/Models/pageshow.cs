namespace CodeGenerator.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("codegenerator.pageshow")]
    public partial class pageshow
    {
        [Key]
        public int p_id { get; set; }

        [Required]
        [StringLength(255)]
        public string p_title { get; set; }

        public int c_id { get; set; }

        public int? definition_id { get; set; }

        public int? components_id { get; set; }

        public int? const_id { get; set; }

        public int? default_id { get; set; }

        public int? computed { get; set; }

        public int? methods_id { get; set; }

        public int? s_id { get; set; }

        public int t_id { get; set; }
    }
}
