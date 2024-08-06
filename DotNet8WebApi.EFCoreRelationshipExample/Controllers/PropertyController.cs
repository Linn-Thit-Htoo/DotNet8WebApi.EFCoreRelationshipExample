namespace DotNet8WebApi.EFCoreRelationshipExample.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PropertyController : BaseController
{
    private readonly EfcoreTableJoinContext _context;
    private readonly IPropertyRepository _propertyRepository;

    public PropertyController(
        EfcoreTableJoinContext context,
        IPropertyRepository propertyRepository
    )
    {
        _context = context;
        _propertyRepository = propertyRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetProperty()
    {
        var result = await _propertyRepository.GetPropertyList();
        return Content(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProperty([FromBody] PropertyRequestModel requestModel)
    {
        var result = await _propertyRepository.CreateProperty(requestModel);
        return Content(result);
    }
}
