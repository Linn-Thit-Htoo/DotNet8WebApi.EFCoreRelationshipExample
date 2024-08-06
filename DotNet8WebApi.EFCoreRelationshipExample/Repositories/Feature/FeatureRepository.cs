using DotNet8WebApi.EFCoreRelationshipExample.AppDbContexts;
using DotNet8WebApi.EFCoreRelationshipExample.Extensions;
using DotNet8WebApi.EFCoreRelationshipExample.Models;
using System.Linq.Expressions;

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
                bool featureDuplicate = await FeatureDuplicate(x => x.FeatureName == requestModel.FeatureName);
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

        public async Task<Result<FeatureResponseModel>> UpdateFeature(FeatureRequestModel requestModel, string id)
        {
            Result<FeatureResponseModel> responseModel;
            try
            {
                bool featureDuplicate = await FeatureDuplicate(x => x.FeatureName == requestModel.FeatureName && x.FeatureId != id);
                if (featureDuplicate)
                {
                    responseModel = GetFeatureDuplicateResult();
                    goto result;
                }

                var item = await _context.TblFeatures.FindAsync(id);
                if (item is null)
                {
                    responseModel = GetFeatureNotFoundResult();
                    goto result;
                }

                item.FeatureName = requestModel.FeatureName;
                _context.TblFeatures.Update(item);
                await _context.SaveChangesAsync();

                responseModel = Result<FeatureResponseModel>.UpdateSuccessResult();
            }
            catch (Exception ex)
            {
                responseModel = Result<FeatureResponseModel>.FailureResult(ex);
            }

        result:
            return responseModel;
        }

        public async Task<Result<FeatureResponseModel>> DeleteFeature(string id)
        {
            Result<FeatureResponseModel> responseModel;
            try
            {
                var item = await _context.TblFeatures.FindAsync(id);
                if (item is null)
                {
                    responseModel = GetFeatureNotFoundResult();
                    goto result;
                }

                _context.TblFeatures.Remove(item);
                await _context.SaveChangesAsync();

                responseModel = Result<FeatureResponseModel>.DeleteSuccessResult();
            }
            catch (Exception ex)
            {
                responseModel = Result<FeatureResponseModel>.FailureResult(ex);
            }

        result:
            return responseModel;
        }

        private async Task<bool> FeatureDuplicate(Expression<Func<TblFeature, bool>> expression)
        {
            return await _context.TblFeatures.AnyAsync(expression);
        }

        private Result<FeatureResponseModel> GetFeatureDuplicateResult()
            => Result<FeatureResponseModel>.DuplicateResult("Feature Duplicate.");

        private Result<FeatureResponseModel> GetFeatureNotFoundResult() =>
            Result<FeatureResponseModel>.NotFoundResult("Feature Not Found.");
    }
}
