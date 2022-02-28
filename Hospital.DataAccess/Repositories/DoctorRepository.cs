namespace Hospital.DataAccess.Repositories
{
    using System;
    using System.Linq;
    using Hospital.DataAccess.Repositories.Abstraction;
    using Hospital.Domain;
    using NHibernate;

    public class DoctorRepository : IRepository<Doctor>
    {
        public bool Create<TEntity>(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete<TEntity>(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Doctor> Filter(ISession session, System.Linq.Expressions.Expression<Func<Doctor, bool>> predicate)
        {
            return this.GetAll(session)
                .Where(predicate);
        }

        public Doctor Find(ISession session, System.Linq.Expressions.Expression<Func<Doctor, bool>> predicate)
        {
            return this.GetAll(session)
                .FirstOrDefault(predicate);
        }

        public Doctor Get(ISession session, int id) =>
                  session?.Get<Doctor>(id);

        public IQueryable<Doctor> GetAll(ISession session) =>
                  session?.Query<Doctor>();

        public bool Update<TEntity>(TEntity oldEntity, TEntity newEntity)
        {
            throw new NotImplementedException();
        }
    }
}
