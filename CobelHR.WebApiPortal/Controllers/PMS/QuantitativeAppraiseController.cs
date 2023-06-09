using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.PMS.Abstract;
using CobelHR.Entities.PMS;

using System.Threading.Tasks;

namespace CobelHR.ApiServices.Controllers.PMS
{
    [Route("api/PMS")]
    public class QuantitativeAppraiseController : BaseController
    {
        public QuantitativeAppraiseController(IQuantitativeAppraiseService quantitativeAppraiseService)
        {
            this.quantitativeAppraiseService = quantitativeAppraiseService;
        }

        private IQuantitativeAppraiseService quantitativeAppraiseService { get; set; }

        [HttpGet]
        [Route("QuantitativeAppraise/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.quantitativeAppraiseService.RetrieveById(id, QuantitativeAppraise.Informer, this.UserCredit);

			return result.ToActionResult<QuantitativeAppraise>();
        }

        [HttpPost]
        [Route("QuantitativeAppraise/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.quantitativeAppraiseService.RetrieveAll(QuantitativeAppraise.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<QuantitativeAppraise>();
        }
            

        
        [HttpPost]
        [Route("QuantitativeAppraise/Save")]
        public async Task<IActionResult> Save([FromBody] QuantitativeAppraise quantitativeAppraise)
        {
            var result = await this.quantitativeAppraiseService.Save(quantitativeAppraise, this.UserCredit);

			return result.ToActionResult<QuantitativeAppraise>();
        }

        
        [HttpPost]
        [Route("QuantitativeAppraise/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] QuantitativeAppraise quantitativeAppraise)
        {
            var result = await this.quantitativeAppraiseService.SaveAttached(quantitativeAppraise, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("QuantitativeAppraise/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<QuantitativeAppraise> quantitativeAppraiseList)
        {
            var result = await this.quantitativeAppraiseService.SaveBulk(quantitativeAppraiseList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("QuantitativeAppraise/Seek")]
        public async Task<IActionResult> Seek([FromBody] QuantitativeAppraise quantitativeAppraise)
        {
            var result = await this.quantitativeAppraiseService.Seek(quantitativeAppraise, this.UserCredit);

			return result.ToActionResult<QuantitativeAppraise>();
        }

        [HttpGet]
        [Route("QuantitativeAppraise/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.quantitativeAppraiseService.SeekByValue(seekValue, QuantitativeAppraise.Informer, this.UserCredit);

			return result.ToActionResult<QuantitativeAppraise>();
        }

        [HttpPost]
        [Route("QuantitativeAppraise/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] QuantitativeAppraise quantitativeAppraise)
        {
            var result = await this.quantitativeAppraiseService.Delete(quantitativeAppraise, id, this.UserCredit);

			return result.ToActionResult();
        }

        
    }
}