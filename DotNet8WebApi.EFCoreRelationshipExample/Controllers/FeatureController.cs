namespace DotNet8WebApi.EFCoreRelationshipExample.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FeatureController : BaseController
{
    private readonly IFeatureRepository _featureRepository;

    public FeatureController(IFeatureRepository featureRepository)
    {
        _featureRepository = featureRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetFeature()
    {
        var result = await _featureRepository.GetFeatureList();
        return Content(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateFeature([FromBody] FeatureRequestModel requestModel)
    {
        var result = await _featureRepository.CreateFeature(requestModel);
        return Content(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateFeature(
        [FromBody] FeatureRequestModel requestModel,
        string id
    )
    {
        var result = await _featureRepository.UpdateFeature(requestModel, id);
        return Content(result);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteFeature(string id)
    {
        var result = await _featureRepository.DeleteFeature(id);
        return Content(result);
    }
}
