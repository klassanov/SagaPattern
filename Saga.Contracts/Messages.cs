namespace Saga.Contracts
{
    public record OrderSubmitted
    {
        public Guid OrderId { get; init; }
        public decimal Total { get; init; }
        public string? Email { get; init; }
    }

    //public record OrderConfirmed
    //{
    //    public Guid OrderId { get; init; }
    //}

    public record ProcessPayment
    {
        public Guid OrderId { get; init; }
        public decimal Amount { get; init; }
    }

    public record PaymentFailed
    {
        public Guid OrderId { get; init; }
        public string? Reason { get; set; }
        public string? PaymentIntentId { get; init; }
    }

    public record PaymentProcessed
    {
        public Guid OrderId { get; init; }
        public string? PaymentIntentId { get; init; }
    }
}
