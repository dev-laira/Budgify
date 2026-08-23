using Budgify.Application.Models;
using Budgify.Contracts.Requests;
using Budgify.Contracts.Responses;
using System.Security.Principal;

namespace Budgify.API.ContractMapping
{
    public static class ContractMapping
    {

        #region MAP TO MODELS

        public static Budget MapToBudget(this CreateBudgetRequest request)
        {
            return new Budget
            {
                Id = Guid.NewGuid(),
                Name = request.Name
            };
        }

        public static Budget MapToBudget(this UpdateBudgetRequest request)
        {
            return new Budget
            {
                Id = Guid.NewGuid(),
                Name = request.Name
            };
        }

        public static Income MapToIncome(this AddIncomeRequest request)
        {
            var validCategory = Enum.TryParse(typeof(IncomeCategory), request.Category, out object? category);

            if (!validCategory)
                return null!;

            return new Income
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Amount = request.Amount,
                Category = (IncomeCategory)category!,
                Distribution = request.Distribution ?? null
            };
        }

        #endregion

        #region MAP TO RESPONSES

        public static BudgetResponse MapToResponse(this Budget budget)
        {
            return new BudgetResponse
            {
                Id = budget.Id,
                Name = budget.Name,
                Incomes = budget.Incomes?.MapToResponse().BudgetIncomes ?? null
            };
        }

        public static BudgetResponses MapToResponse(this List<Budget> budgets)
        {
            return new BudgetResponses
            {
                Budgets = budgets.Select(x => x.MapToResponse()).ToList()
            };
        }

        public static IncomeResponse MapToResponse(this Income income)
        {
            return new IncomeResponse
            {
                Id = income.Id,
                Name = income.Name,
                Amount = income.Amount,
                Category = income.Category.ToString(),
                Distribution = income.Distribution ?? null
            };
        }

        public static IncomeResponses MapToResponse(this List<Income> incomes)
        {
            return new IncomeResponses
            {
                BudgetIncomes = incomes.Select(x => x.MapToResponse()).ToList()
            };
        }

        public static BudgetIncomeResponse MapToResponse(this Income income, Guid budgetId)
        {
            return new BudgetIncomeResponse
            {
                BudgetId = budgetId,
                Income = income.MapToResponse()
            };
        }
        #endregion
    }
}
