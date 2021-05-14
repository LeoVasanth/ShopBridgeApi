using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ShopBridgeApi.Models
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Tblitem> Tblitems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
              
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "USING_NLS_COMP");

            modelBuilder.Entity<Tblitem>(entity =>
            {
                entity.HasKey(e => e.ItemId)
                    .HasName("SYS_C007463");

                entity.ToTable("TBLITEMS");

                entity.Property(e => e.ItemId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("ITEM_ID");

                entity.Property(e => e.Description)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.Price)
                    .HasColumnType("NUMBER(10,2)")
                    .HasColumnName("PRICE");

                entity.Property(e => e.Stock)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("STOCK");
            });

            modelBuilder.HasSequence("LOGMNR_DIDS$");

            modelBuilder.HasSequence("LOGMNR_EVOLVE_SEQ$");

            modelBuilder.HasSequence("LOGMNR_SEQ$");

            modelBuilder.HasSequence("LOGMNR_UIDS$").IsCyclic();

            modelBuilder.HasSequence("MVIEW$_ADVSEQ_GENERIC");

            modelBuilder.HasSequence("MVIEW$_ADVSEQ_ID");

            modelBuilder.HasSequence("ROLLING_EVENT_SEQ$");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
