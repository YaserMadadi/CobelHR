using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.Base.HR.Abstract;
using CobelHR.Entities.Base.HR;
using CobelHR.Entities.HR;

using System.Threading.Tasks;

namespace CobelHR.ApiServices.Controllers.Base.HR
{
    [Route("api/Base.HR")]
    public class ContractTypeController : BaseController
    {
        public ContractTypeController(IContractTypeService contractTypeService)
        {
            this.contractTypeService = contractTypeService;
        }

        private IContractTypeService contractTypeService { get; set; }

        [HttpGet]
        [Route("ContractType/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.contractTypeService.RetrieveById(id, ContractType.Informer, this.UserCredit);

			return result.ToActionResult<ContractType>();
        }

        [HttpPost]
        [Route("ContractType/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.contractTypeService.RetrieveAll(ContractType.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<ContractType>();
        }
            

        
        [HttpPost]
        [Route("ContractType/Save")]
        public async Task<IActionResult> Save([FromBody] ContractType contractType)
        {
            var result = await this.contractTypeService.Save(contractType, this.UserCredit);

			return result.ToActionResult<ContractType>();
        }

        
        [HttpPost]
        [Route("ContractType/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] ContractType contractType)
        {
            var result = await this.contractTypeService.SaveAttached(contractType, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("ContractType/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<ContractType> contractTypeList)
        {
            var result = await this.contractTypeService.SaveBulk(contractTypeList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("ContractType/Seek")]
        public async Task<IActionResult> Seek([FromBody] ContractType contractType)
        {
            var result = await this.contractTypeService.Seek(contractType, this.UserCredit);

			return result.ToActionResult<ContractType>();
        }

        [HttpGet]
        [Route("ContractType/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.contractTypeService.SeekByValue(seekValue, ContractType.Informer, this.UserCredit);

			return result.ToActionResult<ContractType>();
        }

        [HttpPost]
        [Route("ContractType/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] ContractType contractType)
        {
            var result = await this.contractTypeService.Delete(contractType, id, this.UserCredit);

			return result.ToActionResult();
        }

        // CollectionOfContract
        [HttpPost]
        [Route("ContractType/{contractType_id:int}/Contract")]
        public IActionResult CollectionOfContract([FromRoute(Name = "contractType_id")] int id, Contract contract)
        {
            return this.contractTypeService.CollectionOfContract(id, contract, this.UserCredit).ToActionResult();
        }
    }
}