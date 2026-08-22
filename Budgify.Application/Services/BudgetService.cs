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
    }
}
