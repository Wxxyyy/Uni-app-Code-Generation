namespace CodeGenerator.Entity.POCOModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("codegeneration.pageshow")]
    public partial class pageshow
    {
        [Key]
        public int p_id { get; set; }

        [Required]
        [StringLength(255)]
        public string p_title { get; set; }

        public int c_id { get; set; }

        public int? t_id { get; set; }

        public virtual control control { get; set; }

        public virtual type type { get; set; }
    }
}
