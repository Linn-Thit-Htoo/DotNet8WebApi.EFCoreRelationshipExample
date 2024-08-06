namespace DotNet8WebApi.EFCoreRelationshipExample.Repositories.Feature
{
    public interface IFeatureRepository
    {
        Task<Result<FeatureListResponseModel>> GetFeatureList();
        Task<Result<FeatureResponseModel>> CreateFeature(FeatureRequestModel requestModel);
        Task<Result<FeatureResponseModel>> UpdateFeature(FeatureRequestModel requestModel, string id);
        Task<Result<FeatureResponseModel>> DeleteFeature(string id);
    }
}
