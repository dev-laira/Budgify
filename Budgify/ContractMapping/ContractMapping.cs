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
                Name = request.Name
            };
        }

        public static Income MapToIncome(this AddIncomeRequest request)
            => BuildIncome(Guid.NewGuid(), request.Name, request.Amount, request.Category, request.Distribution);

        public static Income MapToIncome(this UpdateIncomeRequest request, Guid incomeId)
            => BuildIncome(incomeId, request.Name, request.Amount, request.Category, request.Distribution);

        private static Income BuildIncome(Guid id, string name, decimal amount, string category, Dictionary<string, string>? distribution)
        {
            var validCategory = Enum.TryParse(typeof(IncomeCategory), category, out object? parsedCategory);

            if (!validCategory)
                return null!;

            return new Income
            {
                Id = id,
                Name = name,
                Amount = amount,
                Category = (IncomeCategory)parsedCategory!,
                Distribution = distribution ?? null
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

        public static BudgetIncomeResponses MapToResponse(this List<Income> incomes, Guid budgetId)
        {
            return new BudgetIncomeResponses
            {
                BudgetId = budgetId,
                Incomes = incomes.MapToResponse().BudgetIncomes
            };
        }
        #endregion
    }
}
