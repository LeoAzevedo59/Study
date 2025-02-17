using Communication.Enums;
using Communication.Requests.Expense;

namespace CommonTestUtilities.Requests.Expanse
{
    public abstract class RequestCreateExpenseJsonBuilder
    {
        public static RequestCreateExpenseJson Build()
        {
            RequestCreateExpenseJson request = new()
            {
                Title = "title",
                Description = "description",
                Amount = 1,
                MovementAt = DateTime.Now,
                PaymentType = PaymentType.Cash
            };

            return request;
        }
    }
}
