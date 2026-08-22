using Budgify.API.ContractMapping;
using Budgify.Application.Services;
using Budgify.Contracts.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Budgify.API.Controllers
{
    [ApiController]
    [Route("/api/budget")]
    public class BudgetController : ControllerBase
    {
        public readonly IBudgetService _budgetService;
        public BudgetController(IBudgetService budgetService)
        {
            _budgetService = budgetService;
        }

        [HttpPost]
        [Route("/")]
        public IActionResult CreateBudget([FromBody]CreateBudgetRequest request)
        {
            var newBudget = request.MapToBudget(); 
            var result = _budgetService.CreateBudget(newBudget);

            return CreatedAtAction("GetSingleBudget","BudgetController",new{id = newBudget.Id});
        }

        [HttpGet("Get")]
        [Route($"/{{id:guid}}")]
        public IActionResult GetSingleBudget([FromRoute] Guid id)
        {
            var budget = _budgetService.GetSingleBudget(id);

            if (budget is null)
                return NotFound();

            return Ok(budget);
        }

        [HttpGet]
        [Route("/")]
        public IActionResult GetAllBudget()
        {
            var budgets = _budgetService.GetAllBudgets();

            return Ok(budgets);
        }

        [HttpPut]
        [Route($"/{{id:guid}}")]
        public IActionResult UpdateBudget([FromRoute]Guid id, [FromBody] UpdateBudgetRequest request)
        {
            var updatedBudget = request.MapToBudget();
            var result = _budgetService.UpdateBudget(id, updatedBudget); ;

            if (!result) return NotFound();

            return Ok();
        }

        [HttpDelete]
        [Route($"/{{id:guid}}")]
        public IActionResult DeleteBudget([FromRoute]Guid id)
        {
            var result = _budgetService.DeleteBudget(id);

            if (!result) return NotFound();

            return Ok();
        }


    }
}
