﻿using DotNet8WebApi.EFCoreRelationshipExample.Models.Feature;
using DotNet8WebApi.EFCoreRelationshipExample.Repositories.Feature;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNet8WebApi.EFCoreRelationshipExample.Controllers
{
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
    }
}
