using Communication.Enums;
using Communication.Requests.Expense;

namespace CommonTestUtilities.Requests.Expanse
{
    public abstract class RequestCreateExpenseJsonBuilder
    {
        public static RequestCreateExpenseJson Build()
        {
            RequestCreateExpenseJson request = new("title",
                "description",
                1,
                DateTime.Now,
                PaymentType.Cash);

            return request;
        }

        public static RequestCreateExpenseJson Build(string title)
        {
            RequestCreateExpenseJson request = new(title,
                "description",
                1,
                DateTime.Now,
                PaymentType.Cash);

            return request;
        }

        public static RequestCreateExpenseJson Build(decimal amount)
        {
            RequestCreateExpenseJson request = new("title",
                "description",
                amount,
                DateTime.Now,
                PaymentType.Cash);

            return request;
        }
    }
}
