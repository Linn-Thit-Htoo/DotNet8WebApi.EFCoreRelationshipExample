using DotNet8WebApi.EFCoreRelationshipExample.AppDbContexts;
using DotNet8WebApi.EFCoreRelationshipExample.Models.Feature;

namespace DotNet8WebApi.EFCoreRelationshipExample.Extensions
{
    public static class Extension
    {
        public static FeatureModel ToDto(this TblFeature dataModel)
        {
            return new FeatureModel
            {
                FeatureId = dataModel.FeatureId,
                FeatureName = dataModel.FeatureName
            };
        }

        public static TblFeature ToEntity(this FeatureRequestModel requestModel)
        {
            return new TblFeature
            {
                FeatureId = Convert.ToString(Ulid.NewUlid())!,
                FeatureName = requestModel.FeatureName
            };
        }
    }
}
