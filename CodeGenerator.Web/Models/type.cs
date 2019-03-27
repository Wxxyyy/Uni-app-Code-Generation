namespace CodeGenerator.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("codegenerator.type")]
    public partial class type
    {
        [Key]
        public int t_id { get; set; }

        [Required]
        [StringLength(255)]
        public string t_title { get; set; }
    }
}
