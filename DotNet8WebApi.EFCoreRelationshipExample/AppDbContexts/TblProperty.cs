namespace DotNet8WebApi.EFCoreRelationshipExample.AppDbContexts;

public partial class TblProperty
{
    public string PropertyId { get; set; } = null!;

    public string PropertyName { get; set; } = null!;

    public bool IsActive { get; set; }

    public virtual ICollection<TblPropertyFeature> TblPropertyFeatures { get; set; } =
        new List<TblPropertyFeature>();
}
