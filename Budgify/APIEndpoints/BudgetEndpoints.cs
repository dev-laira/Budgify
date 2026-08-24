namespace Budgify.API.APIEndpoints
{
    public static class BudgetEndpoints
    {
        public const string Base = "/api/budget";
        public const string CreateBudget = $"{Base}";
        public const string GetAllBudgets = $"{Base}";
        public const string GetSingleBudget = $"{Base}/{{budgetId:guid}}";
        public const string UpdateBudget = $"{Base}/{{budgetId:guid}}";
        public const string DeleteBudget = $"{Base}/{{budgetId:guid}}";
        public const string AddBudgetIncome = $"{Base}/{{budgetId:guid}}/income";
        public const string GetAllBudgetIncomes = $"{Base}/{{budgetId:guid}}/income";
        public const string GetSingleBudgetIncome = $"{Base}/{{budgetId:guid}}/income/{{incomeId:guid}}";
        public const string UpdateBudgetIncome = $"{Base}/{{budgetId:guid}}/income/{{incomeId:guid}}";
        public const string DeleteBudgetIncome = $"{Base}/{{budgetId:guid}}/income/{{incomeId:guid}}";
    }  
}
