using System;
using System.Collections.Generic;
using System.Text;

namespace Budgify.Contracts.Responses
{
    public class IncomeResponses
    {
        public List<IncomeResponse> BudgetIncomes { get; init; } = new();
    }
}
