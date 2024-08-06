using DotNet8WebApi.EFCoreRelationshipExample.AppDbContexts;
using DotNet8WebApi.EFCoreRelationshipExample.Models.Property;
using DotNet8WebApi.EFCoreRelationshipExample.Repositories.Property;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotNet8WebApi.EFCoreRelationshipExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : BaseController
    {
        private readonly EfcoreTableJoinContext _context;
        private readonly IPropertyRepository _propertyRepository;

        public PropertyController(EfcoreTableJoinContext context, IPropertyRepository propertyRepository)
        {
            _context = context;
            _propertyRepository = propertyRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetProperty()
        {

            var lst = await _context.TblPropertyFeatures
                .Include(x => x.Property)
                .Include(x => x.Feature)
                .ToListAsync();

            return Content(lst);
        }

        //[HttpPost]
        //public async Task<IActionResult> CreateProperty([FromBody] PropertyRequestModel requestModel)
        //{

        //}
    }
}
