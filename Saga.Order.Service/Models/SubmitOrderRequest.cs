namespace Saga.Order.Service.Models
{
    public class SubmitOrderRequest
    {
        public decimal Total { get; set; }
        public string Email { get; set; }
    }
}
