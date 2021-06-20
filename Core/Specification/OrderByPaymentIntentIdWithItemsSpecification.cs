using Core.Entities.OrderAggregate;

namespace Core.Specification
{
    class OrderByPaymentIntentIdWithItemsSpecification : BaseSpecification<Order>
    {
        public OrderByPaymentIntentIdWithItemsSpecification(string PaymentIntentId) : base(o => o.PaymentIntentId == PaymentIntentId)
        { 
        
        }
    }
}
