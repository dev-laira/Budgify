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
    }
}
