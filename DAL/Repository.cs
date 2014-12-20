using System.Linq;

namespace DAL
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public IQueryable<T> FindAll()
        {
            var context = new JobFinderContext();
            return context.Set<T>();
        }
    }
}