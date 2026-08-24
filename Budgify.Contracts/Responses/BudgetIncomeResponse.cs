using System;
using System.Collections.Generic;
using System.Text;

namespace Budgify.Contracts.Responses
{
    public class BudgetIncomeResponse
    {
        public Guid BudgetId { get; init; } = Guid.Empty;
        public IncomeResponse Income { get; init; } = new();
    }
}
