using System;
using System.Collections.Generic;

namespace DotNet8WebApi.EFCoreRelationshipExample.AppDbContexts;

public partial class TblFeature
{
    public string FeatureId { get; set; } = null!;

    public string FeatureName { get; set; } = null!;

    public virtual ICollection<TblPropertyFeature> TblPropertyFeatures { get; set; } = new List<TblPropertyFeature>();
}
