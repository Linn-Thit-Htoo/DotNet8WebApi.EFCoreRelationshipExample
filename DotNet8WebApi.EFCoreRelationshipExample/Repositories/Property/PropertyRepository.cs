using DotNet8WebApi.EFCoreRelationshipExample.AppDbContexts;
using DotNet8WebApi.EFCoreRelationshipExample.Extensions;
using DotNet8WebApi.EFCoreRelationshipExample.Models;
using DotNet8WebApi.EFCoreRelationshipExample.Models.Property;
using Microsoft.EntityFrameworkCore;

namespace DotNet8WebApi.EFCoreRelationshipExample.Repositories.Property
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly EfcoreTableJoinContext _context;

        public PropertyRepository(EfcoreTableJoinContext context)
        {
            _context = context;
        }

        public async Task<Result<PropertyListResponseModel>> GetPropertyList()
        {
            Result<PropertyListResponseModel> responseModel;
            try
            {
                var lst = await _context.TblPropertyFeatures
                    .Include(x => x.Property)
                    .Include(x => x.Feature)
                    .ToListAsync();

                responseModel = Result<PropertyListResponseModel>.SuccessResult();
            }
            catch (Exception ex)
            {
                responseModel = Result<PropertyListResponseModel>.FailureResult(ex);
            }

            return responseModel;
        }

        public async Task<Result<PropertyResponseModel>> CreateProperty(PropertyRequestModel requestModel)
        {
            Result<PropertyResponseModel> responseModel;
            try
            {
                var property = requestModel.ToEntity();
                await _context.TblProperties.AddAsync(property);

                foreach (var feature in requestModel.Features!)
                {
                    await _context.TblPropertyFeatures.AddAsync(feature.ToEntity(property.PropertyId));
                }

                await _context.SaveChangesAsync();
                responseModel = Result<PropertyResponseModel>.SaveSuccessResult();
            }
            catch (Exception ex)
            {
                responseModel = Result<PropertyResponseModel>.FailureResult(ex);
            }

            return responseModel;
        }
    }
}
