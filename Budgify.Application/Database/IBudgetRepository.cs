using Budgify.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budgify.Application.Database
{
    public interface IBudgetRepository
    {
        bool CreateBudget(Budget budget);
        List<Budget> GetAllBudgets();
        Budget? GetSingleBudget(Guid id);

        bool UpdateBudget(Guid id, Budget budget);
        bool DeleteBudget(Guid id);
        bool BudgetExists(Guid id);

        bool AddBudgetIncome(Guid budgetId, Income income);
        List<Income> GetAllBudgetIncomes(Guid budgetId);
        Income GetSingleBudgetIncome(Guid budgetId,Guid incomeId);
        bool UpdateBudgetIncome(Guid budgetId, Guid incomeId, Income income);
        bool DeleteBudgetIncome(Guid budgetId, Guid incomeId);
        bool BudgetIncomeExists(Guid budgetId, Guid incomeId);

    }
}
