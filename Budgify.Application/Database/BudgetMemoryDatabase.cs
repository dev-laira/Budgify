using Budgify.Application.Models;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace Budgify.Application.Database
{
    public class BudgetMemoryDatabase:IBudgetRepository
    {
        public static List<Budget> BudgetList = new List<Budget>();

        public BudgetMemoryDatabase()
        {
            BudgetList.Add(new Budget { Id = Guid.NewGuid(), Name = "July 1st Half"});
            BudgetList.Add(new Budget { Id = Guid.NewGuid(), Name = "July 2nd Half" });
        }

        public bool CreateBudget(Budget budget)
        {
            BudgetList.Add(budget);
            return true;
        }

        public bool DeleteBudget(Guid id)
        {
            var budget = BudgetList.FirstOrDefault(x => x.Id == id);
            BudgetList.Remove(budget!);
            return true;
        }

        public List<Budget> GetAllBudgets()
        {
            return BudgetList;
        }

        public Budget? GetSingleBudget(Guid id)
        {
            var budget = BudgetList.FirstOrDefault(x =>x.Id == id);
            return budget;
        }

        public bool UpdateBudget(Guid id, Budget budget)
        {
            var currentValue = BudgetList.FirstOrDefault(x => x.Id == id);
            currentValue!.Name = budget.Name;
            return true;
        }

        public bool BudgetExists(Guid id)
        {
            var budget = BudgetList.FirstOrDefault(x => x.Id == id);
            return budget != null;
        }
    }
}
