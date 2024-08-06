using DotNet8WebApi.EFCoreRelationshipExample.Models.Feature;

namespace DotNet8WebApi.EFCoreRelationshipExample.Models.Property
{
    public class PropertyDataModel
    {
        public string Id { get; set; }
        public PropertyModel Property { get; set; }
        public List<FeatureModel> Features { get; set; }
    }

    public record PropertyListResponseModel(List<PropertyDataModel> DataLst);
}
