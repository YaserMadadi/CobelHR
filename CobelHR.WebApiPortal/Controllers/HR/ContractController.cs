using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.HR.Abstract;
using CobelHR.Entities.HR;

using System.Threading.Tasks;

namespace CobelHR.ApiServices.Controllers.HR
{
    [Route("api/HR")]
    public class ContractController : BaseController
    {
        public ContractController(IContractService contractService)
        {
            this.contractService = contractService;
        }

        private IContractService contractService { get; set; }

        [HttpGet]
        [Route("Contract/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.contractService.RetrieveById(id, Contract.Informer, this.UserCredit);

			return result.ToActionResult<Contract>();
        }

        [HttpPost]
        [Route("Contract/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.contractService.RetrieveAll(Contract.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<Contract>();
        }
            

        
        [HttpPost]
        [Route("Contract/Save")]
        public async Task<IActionResult> Save([FromBody] Contract contract)
        {
            var result = await this.contractService.Save(contract, this.UserCredit);

			return result.ToActionResult<Contract>();
        }

        
        [HttpPost]
        [Route("Contract/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] Contract contract)
        {
            var result = await this.contractService.SaveAttached(contract, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("Contract/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<Contract> contractList)
        {
            var result = await this.contractService.SaveBulk(contractList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("Contract/Seek")]
        public async Task<IActionResult> Seek([FromBody] Contract contract)
        {
            var result = await this.contractService.Seek(contract, this.UserCredit);

			return result.ToActionResult<Contract>();
        }

        [HttpGet]
        [Route("Contract/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.contractService.SeekByValue(seekValue, Contract.Informer, this.UserCredit);

			return result.ToActionResult<Contract>();
        }

        [HttpPost]
        [Route("Contract/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] Contract contract)
        {
            var result = await this.contractService.Delete(contract, id, this.UserCredit);

			return result.ToActionResult();
        }

        
    }
}