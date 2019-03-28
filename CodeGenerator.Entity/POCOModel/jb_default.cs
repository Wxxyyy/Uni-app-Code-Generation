namespace CodeGenerator.Entity.POCOModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("codegeneration.jb_default")]
    public partial class jb_default
    {
        public int id { get; set; }

        [StringLength(255)]
        public string key { get; set; }

        [Required]
        [StringLength(255)]
        public string value { get; set; }

        [StringLength(255)]
        public string desc { get; set; }

        public int? c_id { get; set; }

        public virtual control control { get; set; }
    }
}
