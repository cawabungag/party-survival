namespace Core.Utils.Dao
{
    public interface IDao<T>
    {
        bool Exists();
        void Save(T entity);
        T Load();
        void Remove();
    }
}