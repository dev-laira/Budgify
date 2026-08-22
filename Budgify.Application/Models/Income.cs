using System;
using System.Collections.Generic;
using System.Text;

namespace Budgify.Application.Models
{
    public class Income
    {
        public Guid id { get; init; } = Guid.NewGuid();
        public string Name { get; init; } = string.Empty;
        public decimal Amount { get; init; }
        public IncomeCategory Category { get; init; }
        public Dictionary<string, string>? Distribution { get; init; } = new Dictionary<String,String>();
    }
}
