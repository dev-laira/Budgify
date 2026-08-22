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

    }  
}
