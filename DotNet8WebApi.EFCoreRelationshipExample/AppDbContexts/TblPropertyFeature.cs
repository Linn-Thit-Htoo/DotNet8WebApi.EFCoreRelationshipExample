using System;
using System.Collections.Generic;

namespace DotNet8WebApi.EFCoreRelationshipExample.AppDbContexts;

public partial class TblPropertyFeature
{
    public string Id { get; set; } = null!;

    public string PropertyId { get; set; } = null!;

    public string FeatureId { get; set; } = null!;

    public virtual TblFeature Feature { get; set; } = null!;

    public virtual TblProperty Property { get; set; } = null!;
}
