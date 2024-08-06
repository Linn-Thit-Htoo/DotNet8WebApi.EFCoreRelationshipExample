using DotNet8WebApi.EFCoreRelationshipExample.AppDbContexts;
using DotNet8WebApi.EFCoreRelationshipExample.Models.Property;

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

        public static TblProperty ToEntity(this PropertyRequestModel requestModel)
        {
            return new TblProperty
            {
                PropertyId = Convert.ToString(Ulid.NewUlid())!,
                PropertyName = requestModel.PropertyName,
                IsActive = true
            };
        }

        public static TblPropertyFeature ToEntity(this PropertyFeatureRequestModel requestModel, string propertyId)
        {
            return new TblPropertyFeature
            {
                Id = Convert.ToString(Ulid.NewUlid())!,
                PropertyId = propertyId,
                FeatureId = requestModel.FeatureId
            };
        }
    }
}
