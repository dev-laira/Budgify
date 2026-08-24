using System;
using System.Collections.Generic;
using System.Text;

namespace Budgify.Contracts.Responses
{
    public class BudgetResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<IncomeResponse>? Incomes { get; set; } = null;
    }
}
