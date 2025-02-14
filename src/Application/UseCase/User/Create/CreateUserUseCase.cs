using AutoMapper;
using Communication.Requests.Users;
using Communication.Utils;
using Domain.Repositories;
using Domain.Repositories.User;
using Exception.Exceptions;
using Microsoft.Extensions.Options;

namespace Application.UseCase.User.Create;

public class CreateUserUseCase(
    IUserWriteOnlyRepository userWriteOnlyRepository,
    IMapper mapper,
    IUnityOfWork unityOfWork
    ) : ICreateUserUseCase
{
    public async Task Execute(RequestCreateUserJson request)
    {
        Validate(request);

        var entity = mapper.Map<Domain.Entities.User>(request);
        
        await userWriteOnlyRepository.Add(entity);
        await unityOfWork.Commit();
    }

    private void Validate(RequestCreateUserJson request)
    {
        CreateUserValidator validator = new ();
        var result = validator.Validate(request);
        var errorMessages = ErrorMessagesFilter.GetMessages(result);
        
        if(!result.IsValid)
            throw new ErrorOnValidationException(errorMessages, "Valide os campos obrigatórios.");
    }
}