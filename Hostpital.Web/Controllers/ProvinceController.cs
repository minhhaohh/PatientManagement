﻿using Hospital.Domain.Objects;
using Hostpital.Service.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers
{
    [Route("[controller]/[action]")]
    public class ProvinceController : Controller
    {
        private readonly ILogger<ProvinceController> _logger;

        private readonly IGeographyService _geographyService;

        public ProvinceController(ILogger<ProvinceController> logger, IGeographyService geographyService)
        {
            _logger = logger;
            _geographyService = geographyService;
        }

        [Route("/Province")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> GetDataGrid(int page, int rows)
        {
            var paging = new PagingParams() { PageIndex = page - 1, PageSize = rows };

            var data = await _geographyService.SearchProvincesAsync(paging);

            return Json(data);
        }
    }
}
