using AutoMapper;
using Communication.Requests.Expense;
using Communication.Requests.Users;
using Communication.Responses.Expense;
using Domain.Entities;

namespace Application.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            RequestToEntity();
            EntityToRequest();
        }

        private void RequestToEntity()
        {
            CreateMap<RequestCreateExpenseJson, Expense>()
                .ForMember(dest =>
                    dest.Payment, config =>
                    config.MapFrom(source =>
                        source.PaymentType.ToString()));

            CreateMap<RequestUpdateExpenseJson, Expense>();
            CreateMap<RequestCreateUserJson, User>()
                .ForMember(dest =>
                    dest.Password, config =>
                    config.Ignore());
        }

        private void EntityToRequest()
        {
            CreateMap<Expense, ResponseCreateExpenseJson>();
            CreateMap<Expense, ResponseReadExpensesJson>();
            CreateMap<Expense, ResponseReadExpenseJson>();
        }
    }
}
