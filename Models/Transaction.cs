namespace FinanceAPI.Models
{
    public enum TransactionType
    {
        Income,
        Expense
    }
    public class Transaction
    {
        public int Id { get; set; }
        public string Description {  get; set; } = string.Empty;
        public decimal Amount {  get; set; }
        public TransactionType Type { get; set; }
        public DateTime Date { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public int UserId { get; set; }
        public Category Category { get; set; } = null;

    }
}
