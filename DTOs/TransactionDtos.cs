using FinanceAPI.Models;

namespace FinanceAPI.DTOs
{
    public class TransactionDtos
    {
        public class CreateTransactionDto
        {
            public string Description { get; set; } = string.Empty;
            public decimal Amount { get; set; }
            public TransactionType Type { get; set; }
            public DateTime Date { get; set; }
            public int CategoryId { get; set; }
        }

        public class TransactionResponseDto
        {
            public int Id { get; set; }
            public string Description { get; set; } = string.Empty;
            public decimal Amount { get; set; }
            public string Type { get; set; } = string.Empty;
            public DateTime Date { get; set; }
            public string CategoryName { get; set; } = string.Empty;
        }

        public class SummaryDto
        {
            public decimal TotalIncome { get; set; }
            public decimal TotalExpense { get; set; }
            public decimal Balance { get; set; }
        }
    }
}
