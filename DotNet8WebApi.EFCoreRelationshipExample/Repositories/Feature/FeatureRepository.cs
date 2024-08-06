using DotNet8WebApi.EFCoreRelationshipExample.AppDbContexts;
using DotNet8WebApi.EFCoreRelationshipExample.Extensions;
using DotNet8WebApi.EFCoreRelationshipExample.Models;
using DotNet8WebApi.EFCoreRelationshipExample.Models.Feature;
using Microsoft.EntityFrameworkCore;

namespace DotNet8WebApi.EFCoreRelationshipExample.Repositories.Feature
{
    public class FeatureRepository : IFeatureRepository
    {
        private readonly EfcoreTableJoinContext _context;

        public FeatureRepository(EfcoreTableJoinContext context)
        {
            _context = context;
        }

        public async Task<Result<FeatureListResponseModel>> GetFeatureList()
        {
            Result<FeatureListResponseModel> responseModel;
            try
            {
                var lst = await _context.TblFeatures.OrderByDescending(x => x.FeatureId).ToListAsync();
                var model = new FeatureListResponseModel(lst.Select(x => x.ToDto()).ToList());

                responseModel = Result<FeatureListResponseModel>.SuccessResult(model);
            }
            catch (Exception ex)
            {
                responseModel = Result<FeatureListResponseModel>.FailureResult(ex);
            }

            return responseModel;
        }

        public async Task<Result<FeatureResponseModel>> CreateFeature(FeatureRequestModel requestModel)
        {
            Result<FeatureResponseModel> responseModel;
            try
            {
                bool featureDuplicate = await FeatureDuplicate(requestModel.FeatureName);
                if (featureDuplicate)
                {
                    responseModel = Result<FeatureResponseModel>.DuplicateResult("Feature Duplicate.");
                    goto result;
                }

                await _context.TblFeatures.AddAsync(requestModel.ToEntity());
                await _context.SaveChangesAsync();

                responseModel = Result<FeatureResponseModel>.SaveSuccessResult();
            }
            catch (Exception ex)
            {
                responseModel = Result<FeatureResponseModel>.FailureResult(ex);
            }

        result:
            return responseModel;
        }

        private async Task<bool> FeatureDuplicate(string featureName)
        {
            return await _context.TblFeatures.AnyAsync(x => x.FeatureName == featureName);
        }
    }
}
