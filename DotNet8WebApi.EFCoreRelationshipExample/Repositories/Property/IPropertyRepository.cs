namespace DotNet8WebApi.EFCoreRelationshipExample.Repositories.Property
{
    public interface IPropertyRepository
    {
        Task<Result<PropertyListResponseModel>> GetPropertyList();
        Task<Result<PropertyResponseModel>> CreateProperty(PropertyRequestModel requestModel);
    }
}
