namespace DotNet8WebApi.EFCoreRelationshipExample.AppDbContexts;

public partial class EfcoreTableJoinContext : DbContext
{
    public EfcoreTableJoinContext()
    {
    }

    public EfcoreTableJoinContext(DbContextOptions<EfcoreTableJoinContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblFeature> TblFeatures { get; set; }

    public virtual DbSet<TblProperty> TblProperties { get; set; }

    public virtual DbSet<TblPropertyFeature> TblPropertyFeatures { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblFeature>(entity =>
        {
            entity.HasKey(e => e.FeatureId);

            entity.ToTable("Tbl_Feature");

            entity.Property(e => e.FeatureId).HasMaxLength(50);
            entity.Property(e => e.FeatureName).HasMaxLength(50);
        });

        modelBuilder.Entity<TblProperty>(entity =>
        {
            entity.HasKey(e => e.PropertyId);

            entity.ToTable("Tbl_Property");

            entity.Property(e => e.PropertyId).HasMaxLength(50);
            entity.Property(e => e.PropertyName).HasMaxLength(50);
        });

        modelBuilder.Entity<TblPropertyFeature>(entity =>
        {
            entity.ToTable("Tbl_Property_Feature");

            entity.Property(e => e.Id).HasMaxLength(50);
            entity.Property(e => e.FeatureId).HasMaxLength(50);
            entity.Property(e => e.PropertyId).HasMaxLength(50);

            entity.HasOne(d => d.Feature).WithMany(p => p.TblPropertyFeatures)
                .HasForeignKey(d => d.FeatureId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tbl_Property_Feature_Tbl_Feature");

            entity.HasOne(d => d.Property).WithMany(p => p.TblPropertyFeatures)
                .HasForeignKey(d => d.PropertyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tbl_Property_Feature_Tbl_Property");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
