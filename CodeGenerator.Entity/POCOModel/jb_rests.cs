namespace CodeGenerator.Entity.POCOModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("codegeneration.jb_rests")]
    public partial class jb_rests
    {
        public int id { get; set; }

        [StringLength(255)]
        public string name { get; set; }

        [StringLength(1073741823)]
        public string content { get; set; }

        [StringLength(255)]
        public string desc { get; set; }

        public int? c_id { get; set; }

        public virtual control control { get; set; }
    }
}
