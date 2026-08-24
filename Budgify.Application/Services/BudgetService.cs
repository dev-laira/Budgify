using Budgify.Application.Database;
using Budgify.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budgify.Application.Services
{
    public class BudgetService : IBudgetService
    {
        private readonly IBudgetRepository _budgetRepository;
        public BudgetService(IBudgetRepository budgetRepository)
        {
            _budgetRepository = budgetRepository;
        }
        public bool BudgetExists(Guid id)
        {
            return _budgetRepository.BudgetExists(id);
        }

        public bool CreateBudget(Budget budget)
        {
            return _budgetRepository.CreateBudget(budget);
        }

        public bool DeleteBudget(Guid id)
        {
            if (!BudgetExists(id))
                return false;

            return _budgetRepository.DeleteBudget(id);
        }

        public List<Budget> GetAllBudgets()
        {
            return _budgetRepository.GetAllBudgets();
        }

        public Budget? GetSingleBudget(Guid id)
        {
            return _budgetRepository.GetSingleBudget(id);
        }

        public bool UpdateBudget(Guid id, Budget budget)
        {
            if (!BudgetExists(id))
                return false;

            return _budgetRepository.UpdateBudget(id, budget);
        }

        public bool AddBudgetIncome(Guid budgetId, Income income)
        {
            return _budgetRepository.AddBudgetIncome(budgetId, income);
        }

        public bool BudgetIncomeExists(Guid budgetId, Guid incomeId)
        {
            return _budgetRepository.BudgetIncomeExists(budgetId, incomeId);
        }

        public bool DeleteBudgetIncome(Guid budgetId, Guid incomeId)
        {
            if (!BudgetIncomeExists(budgetId, incomeId)) return false;

            return _budgetRepository.DeleteBudgetIncome(budgetId, incomeId);
        }

        public List<Income> GetAllBudgetIncomes(Guid budgetId)
        {
            if (!BudgetExists(budgetId)) return null!;

            return _budgetRepository.GetAllBudgetIncomes(budgetId);
        }

        public Income GetSingleBudgetIncome(Guid budgetId, Guid incomeId)
        {
            if (!BudgetIncomeExists(budgetId, incomeId)) return null!;

            return _budgetRepository.GetSingleBudgetIncome(budgetId, incomeId);
        }

        public bool UpdateBudgetIncome(Guid budgetId, Guid incomeId, Income income)
        {
            if (!BudgetIncomeExists(budgetId, incomeId)) return false;

            return _budgetRepository.UpdateBudgetIncome(budgetId, incomeId, income);
        }
    }
}
