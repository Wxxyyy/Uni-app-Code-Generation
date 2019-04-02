namespace CodeGenerator.Entity.POCOModel
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
        public virtual DbSet<jb_data> jb_data { get; set; }
        public virtual DbSet<jb_default> jb_default { get; set; }
        public virtual DbSet<jb_definition> jb_definition { get; set; }
        public virtual DbSet<jb_methods> jb_methods { get; set; }
        public virtual DbSet<jb_rests> jb_rests { get; set; }
        public virtual DbSet<style> style { get; set; }
        public virtual DbSet<type> type { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<control>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<control>()
                .Property(e => e.content)
                .IsUnicode(false);

            modelBuilder.Entity<control>()
                .Property(e => e.desc)
                .IsUnicode(false);

            modelBuilder.Entity<control>()
                .HasMany(e => e.jb_components)
                .WithOptional(e => e.control)
                .HasForeignKey(e => e.c_id);

            modelBuilder.Entity<control>()
                .HasMany(e => e.jb_computed)
                .WithOptional(e => e.control)
                .HasForeignKey(e => e.c_id);

            modelBuilder.Entity<control>()
                .HasMany(e => e.jb_data)
                .WithOptional(e => e.control)
                .HasForeignKey(e => e.c_id);

            modelBuilder.Entity<control>()
                .HasMany(e => e.jb_default)
                .WithOptional(e => e.control)
                .HasForeignKey(e => e.c_id);

            modelBuilder.Entity<control>()
                .HasMany(e => e.jb_definition)
                .WithOptional(e => e.control)
                .HasForeignKey(e => e.c_id);

            modelBuilder.Entity<control>()
                .HasMany(e => e.jb_methods)
                .WithOptional(e => e.control)
                .HasForeignKey(e => e.c_id);

            modelBuilder.Entity<control>()
                .HasMany(e => e.jb_rests)
                .WithOptional(e => e.control)
                .HasForeignKey(e => e.c_id);

            modelBuilder.Entity<control>()
                .HasMany(e => e.style)
                .WithOptional(e => e.control)
                .HasForeignKey(e => e.c_id);

            modelBuilder.Entity<jb_components>()
                .Property(e => e.content)
                .IsUnicode(false);

            modelBuilder.Entity<jb_components>()
                .Property(e => e.desc)
                .IsUnicode(false);

            modelBuilder.Entity<jb_computed>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<jb_computed>()
                .Property(e => e.content)
                .IsUnicode(false);

            modelBuilder.Entity<jb_computed>()
                .Property(e => e.desc)
                .IsUnicode(false);

            modelBuilder.Entity<jb_data>()
                .Property(e => e.content)
                .IsUnicode(false);

            modelBuilder.Entity<jb_data>()
                .Property(e => e.desc)
                .IsUnicode(false);

            modelBuilder.Entity<jb_default>()
                .Property(e => e.key)
                .IsUnicode(false);

            modelBuilder.Entity<jb_default>()
                .Property(e => e.value)
                .IsUnicode(false);

            modelBuilder.Entity<jb_default>()
                .Property(e => e.desc)
                .IsUnicode(false);

            modelBuilder.Entity<jb_definition>()
                .Property(e => e.content)
                .IsUnicode(false);

            modelBuilder.Entity<jb_definition>()
                .Property(e => e.desc)
                .IsUnicode(false);

            modelBuilder.Entity<jb_methods>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<jb_methods>()
                .Property(e => e.content)
                .IsUnicode(false);

            modelBuilder.Entity<jb_methods>()
                .Property(e => e.desc)
                .IsUnicode(false);

            modelBuilder.Entity<jb_rests>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<jb_rests>()
                .Property(e => e.content)
                .IsUnicode(false);

            modelBuilder.Entity<jb_rests>()
                .Property(e => e.desc)
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
