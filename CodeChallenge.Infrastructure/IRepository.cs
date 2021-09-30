namespace CodeChallenge.Infrastructure
{
    public interface IRepository<in TEntity> where TEntity : class
    {
        void Insert(TEntity entity);
    }
}
