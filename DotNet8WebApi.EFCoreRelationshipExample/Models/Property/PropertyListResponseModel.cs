using DotNet8WebApi.EFCoreRelationshipExample.Models.Feature;

namespace DotNet8WebApi.EFCoreRelationshipExample.Models.Property
{
    public class PropertyListResponseModel
    {
        public PropertyModel Property { get; set; }
        public List<FeatureModel> Features { get; set; }
    }
}
