using System;
using System.Collections.Generic;
using System.Text;

namespace Budgify.Contracts.Responses
{
    public class IncomeResponse
    {
        public Guid Id { get; init; } = Guid.Empty;
        public string Name { get; init; } = string.Empty;
        public decimal Amount { get; init; }
        public string Category { get; init; } = string.Empty;
        public Dictionary<string, string>? Distribution { get; init; } = new();
    }
}
