using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.Base.Abstract;
using CobelHR.Entities.Base;

using System.Threading.Tasks;

namespace CobelHR.ApiServices.Controllers.Base
{
    [Route("api/Base")]
    public class ProvinceController : BaseController
    {
        public ProvinceController(IProvinceService provinceService)
        {
            this.provinceService = provinceService;
        }

        private IProvinceService provinceService { get; set; }

        [HttpGet]
        [Route("Province/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.provinceService.RetrieveById(id, Province.Informer, this.UserCredit);

			return result.ToActionResult<Province>();
        }

        [HttpPost]
        [Route("Province/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.provinceService.RetrieveAll(Province.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<Province>();
        }
            

        
        [HttpPost]
        [Route("Province/Save")]
        public async Task<IActionResult> Save([FromBody] Province province)
        {
            var result = await this.provinceService.Save(province, this.UserCredit);

			return result.ToActionResult<Province>();
        }

        
        [HttpPost]
        [Route("Province/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] Province province)
        {
            var result = await this.provinceService.SaveAttached(province, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("Province/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<Province> provinceList)
        {
            var result = await this.provinceService.SaveBulk(provinceList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("Province/Seek")]
        public async Task<IActionResult> Seek([FromBody] Province province)
        {
            var result = await this.provinceService.Seek(province, this.UserCredit);

			return result.ToActionResult<Province>();
        }

        [HttpGet]
        [Route("Province/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.provinceService.SeekByValue(seekValue, Province.Informer, this.UserCredit);

			return result.ToActionResult<Province>();
        }

        [HttpPost]
        [Route("Province/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] Province province)
        {
            var result = await this.provinceService.Delete(province, id, this.UserCredit);

			return result.ToActionResult();
        }

        // CollectionOfCity
        [HttpPost]
        [Route("Province/{province_id:int}/City")]
        public IActionResult CollectionOfCity([FromRoute(Name = "province_id")] int id, City city)
        {
            return this.provinceService.CollectionOfCity(id, city, this.UserCredit).ToActionResult();
        }
    }
}