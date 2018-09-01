namespace Nomoni.Data.Abstractions
{
    public interface IStorage
    {
        T GetRepository<T>();

        void Save();
    }
}
