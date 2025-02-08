namespace Domain.Repositories;

public interface IUnityOfWork
{
    Task Commit();
}