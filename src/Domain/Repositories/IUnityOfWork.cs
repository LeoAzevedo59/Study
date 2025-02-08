namespace Domain.Repositories;

public interface IUnityOfWork
{
    void Commit();
}