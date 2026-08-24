using System;
using System.Collections.Generic;
using System.Text;

namespace Budgify.Application.Models
{
    public class Income
    {
        public Guid Id { get; init; } = Guid.Empty;
        public string Name { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public IncomeCategory Category { get; set; }
        public Dictionary<string, string>? Distribution { get; set; } = new();
    }
}
