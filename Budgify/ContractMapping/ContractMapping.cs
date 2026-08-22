using Budgify.Application.Models;
using Budgify.Contracts.Requests;

namespace Budgify.API.ContractMapping
{
    public static class ContractMapping
    {
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
        
    }
}
