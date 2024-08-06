namespace DotNet8WebApi.EFCoreRelationshipExample.Models.Feature;

public class FeatureListResponseModel
{
    public List<FeatureModel> DataLst { get; set; }

    public FeatureListResponseModel(List<FeatureModel> dataLst)
    {
        DataLst = dataLst;
    }
}
