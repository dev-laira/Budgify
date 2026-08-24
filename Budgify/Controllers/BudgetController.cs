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

            return CreatedAtAction(nameof(GetSingleBudget), new { budgetId = newBudget.Id},null);
        }

        [HttpGet]
        [Route(BudgetEndpoints.GetSingleBudget)]
        public IActionResult GetSingleBudget([FromRoute] Guid budgetId)
        {
            var budget = _budgetService.GetSingleBudget(budgetId);

            if (budget is null)
                return NotFound();

            return Ok(budget.MapToResponse());
        }

        [HttpGet]
        [Route(BudgetEndpoints.GetAllBudgets)]
        public IActionResult GetAllBudget()
        {
            var budgets = _budgetService.GetAllBudgets();

            return Ok(budgets.MapToResponse().Budgets);
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

            return NoContent();
        }

        [HttpPost]
        [Route(BudgetEndpoints.AddBudgetIncome)]
        public IActionResult AddBudgetIncome([FromRoute]Guid budgetId, [FromBody]AddIncomeRequest request)
        {
            var income = request.MapToIncome();

            if (income is null) return BadRequest();

            var result = _budgetService.AddBudgetIncome(budgetId, income);

            if (!result) return NotFound();

            return CreatedAtAction(nameof(GetSingleBudgetIncome), new { budgetId = budgetId, incomeId = income.Id},null);
        }

        [HttpGet]
        [Route(BudgetEndpoints.GetSingleBudgetIncome)]
        public IActionResult GetSingleBudgetIncome([FromRoute]Guid budgetId, [FromRoute] Guid incomeId)
        {
            var income  = _budgetService.GetSingleBudgetIncome(budgetId, incomeId);

            if(income is null) return NotFound();

            return Ok(income.MapToResponse(budgetId));
        }

        [HttpGet]
        [Route(BudgetEndpoints.GetAllBudgetIncomes)]
        public IActionResult GetAllBudgetIncomes([FromRoute] Guid budgetId) {

            var incomes = _budgetService.GetAllBudgetIncomes(budgetId);

            if(incomes is null) return NotFound();

            return Ok(incomes.MapToResponse(budgetId));
        }

        [HttpPut]
        [Route(BudgetEndpoints.UpdateBudgetIncome)]
        public IActionResult UpdateBudgetIncome([FromRoute] Guid budgetId, [FromRoute] Guid incomeId, [FromBody] UpdateIncomeRequest request)
        {

            var updatedIncome = request.MapToIncome(incomeId);

            if (updatedIncome is null) return BadRequest();

            var result = _budgetService.UpdateBudgetIncome(budgetId, incomeId, updatedIncome);

            if (!result) return NotFound();

            return Ok();
        }

        [HttpDelete]
        [Route(BudgetEndpoints.DeleteBudgetIncome)]
        public IActionResult DeleteBudgetIncome([FromRoute] Guid budgetId, [FromRoute] Guid incomeId)
        {
            var result = _budgetService.DeleteBudgetIncome(budgetId, incomeId);

            if (!result) return NotFound();

            return NoContent();
        }


    }
}
