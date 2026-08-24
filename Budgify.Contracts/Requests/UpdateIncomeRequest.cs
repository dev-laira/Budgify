using System;
using System.Collections.Generic;
using System.Text;

namespace Budgify.Contracts.Requests
{
    public class UpdateIncomeRequest
    {
        public string Name { get; init; } = string.Empty;
        public decimal Amount { get; init; }
        public string Category { get; init; } = string.Empty;
        public Dictionary<string, string>? Distribution { get; init; } = new();
    }
}
