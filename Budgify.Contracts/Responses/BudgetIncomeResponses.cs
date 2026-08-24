using System;
using System.Collections.Generic;
using System.Text;

namespace Budgify.Contracts.Responses
{
    public class BudgetIncomeResponses
    {
        public Guid BudgetId { get; init; } = Guid.Empty;

        public List<IncomeResponse> Incomes { get; init; } = new();
    }
}
