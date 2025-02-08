using AutoMapper;
using Communication.Requests.Expense;
using Communication.Responses.Expense;
using Domain.Entities;

namespace Application.AutoMapper;

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
    }

    private void EntityToRequest()
    {
        CreateMap<Expense, ResponseCreateExpenseJson>();
    }
}