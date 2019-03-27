namespace CodeGenerator.Web.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CGDataBase : DbContext
    {
        public CGDataBase()
            : base("name=CGDataBase")
        {
        }

        public virtual DbSet<control> control { get; set; }
        public virtual DbSet<jb_components> jb_components { get; set; }
        public virtual DbSet<jb_computed> jb_computed { get; set; }
        public virtual DbSet<jb_const> jb_const { get; set; }
        public virtual DbSet<jb_default> jb_default { get; set; }
        public virtual DbSet<jb_definition> jb_definition { get; set; }
        public virtual DbSet<jb_methods> jb_methods { get; set; }
        public virtual DbSet<pageshow> pageshow { get; set; }
        public virtual DbSet<style> style { get; set; }
        public virtual DbSet<type> type { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<control>()
                .Property(e => e.content)
                .IsUnicode(false);

            modelBuilder.Entity<jb_components>()
                .Property(e => e.content)
                .IsUnicode(false);

            modelBuilder.Entity<jb_computed>()
                .Property(e => e.content)
                .IsUnicode(false);

            modelBuilder.Entity<jb_const>()
                .Property(e => e.content)
                .IsUnicode(false);

            modelBuilder.Entity<jb_default>()
                .Property(e => e.content)
                .IsUnicode(false);

            modelBuilder.Entity<jb_definition>()
                .Property(e => e.content)
                .IsUnicode(false);

            modelBuilder.Entity<jb_methods>()
                .Property(e => e.content)
                .IsUnicode(false);

            modelBuilder.Entity<pageshow>()
                .Property(e => e.p_title)
                .IsUnicode(false);

            modelBuilder.Entity<style>()
                .Property(e => e.content_css)
                .IsUnicode(false);

            modelBuilder.Entity<type>()
                .Property(e => e.t_title)
                .IsUnicode(false);
        }
    }
}
