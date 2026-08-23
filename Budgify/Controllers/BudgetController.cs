using Budgify.API.APIEndpoints;
using Budgify.API.ContractMapping;
using Budgify.Application.Services;
using Budgify.Contracts.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Budgify.API.Controllers
{
    [ApiController]
    public class BudgetController : ControllerBase
    {
        public readonly IBudgetService _budgetService;
        public BudgetController(IBudgetService budgetService)
        {
            _budgetService = budgetService;
        }

        [HttpPost]
        [Route(BudgetEndpoints.CreateBudget)]
        public IActionResult CreateBudget([FromBody]CreateBudgetRequest request)
        {
            var newBudget = request.MapToBudget(); 
            var result = _budgetService.CreateBudget(newBudget);

            return CreatedAtAction(nameof(CreateBudget), new {bugdetId=newBudget.Id});
        }

        [HttpGet]
        [Route(BudgetEndpoints.GetSingleBudget)]
        public IActionResult GetSingleBudget([FromRoute] Guid budgetId)
        {
            var budget = _budgetService.GetSingleBudget(budgetId);

            if (budget is null)
                return NotFound();

            return Ok(budget);
        }

        [HttpGet]
        [Route(BudgetEndpoints.GetAllBudgets)]
        public IActionResult GetAllBudget()
        {
            var budgets = _budgetService.GetAllBudgets();

            return Ok(budgets);
        }

        [HttpPut]
        [Route(BudgetEndpoints.UpdateBudget)]
        public IActionResult UpdateBudget([FromRoute]Guid budgetId, [FromBody] UpdateBudgetRequest request)
        {
            var updatedBudget = request.MapToBudget();
            var result = _budgetService.UpdateBudget(budgetId, updatedBudget); 

            if (!result) return NotFound();

            return Ok();
        }

        [HttpDelete]
        [Route(BudgetEndpoints.DeleteBudget)]
        public IActionResult DeleteBudget([FromRoute]Guid budgetId)
        {
            var result = _budgetService.DeleteBudget(budgetId);
            if (!result) return NotFound();

            return Ok();
        }

    }
}
