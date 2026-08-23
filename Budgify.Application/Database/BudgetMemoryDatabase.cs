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

        public bool AddBudgetIncome(Guid budgetId, Income income)
        {
            if (!BudgetExists(budgetId)) return false;

            var budget = BudgetList.FirstOrDefault(x => x.Id == budgetId);
            budget!.Incomes?.Add(income);

            return true;
        }

        public List<Income> GetAllBudgetIncomes(Guid budgetId)
        {
            if (!BudgetExists(budgetId)) return null!;

            var budget = BudgetList.FirstOrDefault(x =>x.Id == budgetId);
            return budget!.Incomes; 
        }

        public Income GetSingleBudgetIncome(Guid budgetId, Guid incomeId)
        {
            if (!BudgetIncomeExists(budgetId,incomeId)) return null!;

            var budget = BudgetList.FirstOrDefault(x => x.Id == budgetId);
            
            var budgetIncome = budget!.Incomes.FirstOrDefault(x => x.Id == incomeId);

            return budgetIncome!;
        }

        public bool UpdateBudgetIncome(Guid budgetId, Guid incomeId, Income income)
        {
            if (!BudgetIncomeExists(budgetId, incomeId)) return false;
            var budget = BudgetList.FirstOrDefault(x => x.Id == budgetId);
            var budgetIncome = budget!.Incomes.FirstOrDefault(x => x.Id == incomeId);

            budgetIncome = new Income
            {
                Id = budgetId,
                Name = income.Name,
                Amount = income.Amount,
                Category = income.Category,
                Distribution = income.Distribution
            };

            return true;
        }

        public bool DeleteBudgetIncome(Guid budgetId, Guid incomeId)
        {
            if (!BudgetIncomeExists(budgetId, incomeId)) return false;
            var budget = BudgetList.FirstOrDefault(x => x.Id == budgetId);
            var budgetIncome = budget!.Incomes.FirstOrDefault(x => x.Id == incomeId);

            budget.Incomes.Remove(budgetIncome!);
            return true;
        }

        public bool BudgetIncomeExists(Guid budgetId, Guid incomeId)
        {
            if (!BudgetExists(budgetId)) return false!;

            var budget = BudgetList.FirstOrDefault(x => x.Id == budgetId);

            var income = budget!.Incomes?.FirstOrDefault(x => x.Id == incomeId);

            return income != null;
        }
    }
}
