namespace DotNet8WebApi.EFCoreRelationshipExample.Models.Property;

public class PropertyRequestModel
{
    public string PropertyName { get; set; } = null!;
    public List<PropertyFeatureRequestModel>? Features { get; set; }
}
